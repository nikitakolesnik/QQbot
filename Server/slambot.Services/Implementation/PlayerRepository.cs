using Microsoft.EntityFrameworkCore;
using slambot.Common.Configuration;
using slambot.DataAccess.Entities;
using slambot.DataAccess.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using slambot.Services.Models;
using slambot.Common.Enums;
using slambot.Common;

namespace slambot.Services.Implementation
{
	public class PlayerRepository : IPlayerRepository
	{
		private readonly ApplicationDbContext _context;
        private readonly IRatingCalculator _calc;

        public PlayerRepository(ApplicationDbContext context, IRatingCalculator calc)
		{
			_context = context ?? throw new ArgumentNullException(nameof(context));
            _calc = calc ?? throw new ArgumentNullException(nameof(calc));
        }

		public async Task<Player> ActionPlayerAsync(int id, Status action)
		{
			// Find player & apply change 
			
			Player player = await _context.Players.SingleAsync(p => p.Id == id);
			player.Status = action;

			Player admin = await _context.Players.SingleAsync(p => p.Id == 1); // TEMP

			// Add this to admin action log
			
			await _context.AdminActions.AddAsync(new() { 
				Admin = admin, // todo
				Type = AdminActionType.ActionPlayer,
				SubjectPlayer = player,
				Action = action
			});
			
			// Done
			
			await _context.SaveChangesAsync();
			return player;
        }

        public async Task<Player> AddPlayerAsync(SubmittedPlayer playerData)
		{
			if (string.IsNullOrEmpty(playerData.Name))
			{
				throw new ArgumentException(ExceptionMessage.PlayerNameEmpty);
			}

			Player newPlayer = new() { Name = playerData.Name, Discord = playerData.Discord, Status = Status.PendingReview };
			await _context.Players.AddAsync(newPlayer);
			await _context.SaveChangesAsync();
			return newPlayer;
		}

		public async Task<Player> EditPlayerAsync(int id, SubmittedPlayer playerData)
		{
			Player player = await _context.Players.Where(p => p.Id == id).SingleAsync();
			player.Name = playerData.Name;
			player.Discord = playerData.Discord;
			await _context.SaveChangesAsync();
			return player;
		}

		public async Task<SubmittedPlayer> PlayerNameDiscordAsync(int id)
		{
			return await _context.Players
				.Where(p => p.Id == id)
				.Select(sp => new SubmittedPlayer 
				{ 
					Name = sp.Name, 
					Discord = sp.Discord 
				})
				.SingleAsync();
		}

		public async Task<IEnumerable<LeaderboardPlayer>> LeaderboardAsync()
		{
			List<Player> players = await _context.Players
				.OrderByDescending(x => x.Rating)
				.ToListAsync();
			List<LeaderboardPlayer> leaderboard = new();
			int rank = 1;

			foreach (var player in players)
			{
				leaderboard.Add(new() 
				{ 
					Id     = player.Id,
					Rank   = rank++, 
					Name   = player.Name, 
					Rating = player.Rating
				});
			}

			return leaderboard;
        }

        public async Task<PlayerProfile> ProfileAsync(int id)
        {
			// Find player

			Player player = await _context.Players.SingleAsync(p => p.Id == id);


			// Prepare return object & initialize containers for finding relative player data

			PlayerProfile profile = new() 
			{ 
				Name = player.Name, 
				//Rating = player.Rating,
				PeakRating = player.Rating
			};
			int playerCount = _context.Players.Max(p => p.Id);
			Dictionary<int, int> allPlayerRatings = new();
			Dictionary<int, int> playersWonWith = new();
			Dictionary<int, int> playersWonAgainst = new();
			Dictionary<int, int> playersLostWith = new();
			Dictionary<int, int> playersLostAgainst = new();

			for (int i = 1; i <= playerCount; i++)
            {
				allPlayerRatings.Add(i, PlayerConfiguration.DefaultRating);
                playersWonWith.Add(i, 0);
                playersWonAgainst.Add(i, 0);
                playersLostWith.Add(i, 0);
                playersLostAgainst.Add(i, 0);
            }


			// Go through the match history, rebuilding player rating

			await foreach (Match match in _context.Matches.AsAsyncEnumerable())
			{
				// Skip disabled or pending-approval matches

				if (match.Status != Status.Approved)
                {
					continue;
                }


				// Build collection of player IDs for each team

				List<int> team1Ids = Utilities.StrToList(match.Team1);
				List<int> team2Ids = Utilities.StrToList(match.Team2);


				// calculate all rating changes for this match

				int team1RatingAvg = (int)team1Ids.Average();
				int team2RatingAvg = (int)team2Ids.Average();
				int maxRatingDiff = allPlayerRatings.Values.Max() - allPlayerRatings.Values.Min();

				foreach (int t1PlayerId in team1Ids)
                {
                    allPlayerRatings[t1PlayerId] = _calc.PlayerRating(allPlayerRatings[t1PlayerId], team2RatingAvg, maxRatingDiff, match.WinningTeam == TeamNumber.Team1 ? MatchResult.Win : MatchResult.Lose);
                }
				foreach (int t2PlayerId in team2Ids)
                {
					allPlayerRatings[t2PlayerId] = _calc.PlayerRating(allPlayerRatings[t2PlayerId], team1RatingAvg, maxRatingDiff, match.WinningTeam == TeamNumber.Team2 ? MatchResult.Win : MatchResult.Lose);
                }

				
				// if the player participated in this match, increment their stats
				//		this section is very ugly and im not sure how to fix that yet

				if (team1Ids.Contains(player.Id)) // If player was on Team 1
				{
					profile.RatingOverTime.Add(allPlayerRatings[player.Id]);

					if (match.WinningTeam == TeamNumber.Team1)
					{
						profile.Wins++;
						profile.CurrentWinStreak++;
						if (profile.HighestWinStreak < profile.CurrentWinStreak)
							profile.HighestWinStreak = profile.CurrentWinStreak;
						if (profile.PeakRating < allPlayerRatings[player.Id])
							profile.PeakRating = allPlayerRatings[player.Id];

						foreach (int t1PlayerId in team1Ids) // Add Team 1 to friendly stats
						{
							if (t1PlayerId == player.Id)
								continue;
							playersWonWith[t1PlayerId] += 1;
						}
						foreach (int t2PlayerId in team2Ids) // Add Team 2 to enemy stats
						{
							playersWonAgainst[t2PlayerId] += 1;
						}
					}
					else if (match.WinningTeam == TeamNumber.Team2)
					{
						profile.Losses++;
						profile.CurrentWinStreak = 0;

						foreach (int t1PlayerId in team1Ids) // Add Team 1 to friendly stats
						{
							if (t1PlayerId == player.Id)
								continue;
							playersLostWith[t1PlayerId] += 1;
						}
						foreach (int t2PlayerId in team2Ids) // Add Team 2 to enemy stats
						{
							playersLostAgainst[t2PlayerId] += 1;
						}
					}
				}
				else if (team2Ids.Contains(player.Id)) // If player was on Team 2
				{
					profile.RatingOverTime.Add(allPlayerRatings[player.Id]);

					if (match.WinningTeam == TeamNumber.Team1)
					{
						profile.Losses++;
						profile.CurrentWinStreak = 0;

						foreach (int t1PlayerId in team1Ids) // Add Team 1 to enemy stats
						{
							playersLostAgainst[t1PlayerId] += 1;
						}
						foreach (int t2PlayerId in team2Ids) // Add Team 2 to friendly stats
						{
							if (t2PlayerId == player.Id)
								continue;
							playersLostWith[t2PlayerId] += 1;
						}
					}
					else if (match.WinningTeam == TeamNumber.Team2)
					{
						profile.Wins++;
						profile.CurrentWinStreak++;
						if (profile.HighestWinStreak < profile.CurrentWinStreak)
							profile.HighestWinStreak = profile.CurrentWinStreak;
						if (profile.PeakRating < allPlayerRatings[player.Id])
							profile.PeakRating = allPlayerRatings[player.Id];

						foreach (int t1PlayerId in team1Ids) // Add Team 1 to enemy stats
						{
                            playersWonAgainst[t1PlayerId] += 1;
						}
						foreach (int t2PlayerId in team2Ids) // Add Team 2 to friendly stats
						{
							if (t2PlayerId == player.Id)
								continue;
							playersWonWith[t2PlayerId] += 1;
						}
					}
				}
			}


			// map dictionary results to profile

			profile.MostLossesAgainstPlayerId = playersLostAgainst.Aggregate((l, r) => l.Value > r.Value ? l : r).Key;
			profile.MostLossesWithPlayerId = playersLostWith.Aggregate((l, r) => l.Value > r.Value ? l : r).Key;
			profile.MostWinsAgainstPlayerId = playersWonAgainst.Aggregate((l, r) => l.Value > r.Value ? l : r).Key;
			profile.MostWinsWithPlayerId = playersWonWith.Aggregate((l, r) => l.Value > r.Value ? l : r).Key;
			profile.WinPercent = (int)(100 * ((double)profile.Wins / (double)(profile.Wins + profile.Losses)));
			
			profile.Rating = allPlayerRatings[player.Id]; // temp

			// Done

			return profile;
        }
    }
}
