using Microsoft.EntityFrameworkCore;
using slambot.Common;
using slambot.Common.Configuration;
using slambot.Common.Enums;
using slambot.DataAccess.Contexts;
using slambot.DataAccess.Entities;
using slambot.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

			Player admin = await _context.Players.SingleAsync(p => p.Id == 1); // TEMP
			Player player = await _context.Players.SingleAsync(p => p.Id == id);
			player.Status = action;

			// Add this to admin action log

			await _context.AdminActions.AddAsync(new()
			{
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
				throw new ArgumentException(ExceptionMessage.PlayerNameEmpty);

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
					Id = player.Id,
					Rank = rank++,
					Name = player.Name,
					Rating = player.Rating
				});
			}

			return leaderboard;
		}

		public async Task<PlayerProfile> ProfileAsync(int id)
		{
			// Find player

			Player player = await _context.Players.SingleAsync(p => p.Id == id);


			// Prepare return object

			PlayerProfile profile = new()
			{
				Name = player.Name,
				//Rating = player.Rating,
				PeakRating = player.Rating
			};


			// initialize containers for calculating relative player data

			int playerCount = _context.Players.Max(p => p.Id);
			Dictionary<int, int> allPlayerRatings = new(playerCount);
			Dictionary<int, int> playersWonWith = new(playerCount);
			Dictionary<int, int> playersWonAgainst = new(playerCount);
			Dictionary<int, int> playersLostWith = new(playerCount);
			Dictionary<int, int> playersLostAgainst = new(playerCount);

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
				if (match.Status != Status.Approved // Skip disabled or pending-approval matches
					|| match.WinningTeam == TeamNumber.None) // No need to count anything for a draw
					continue;


				// Get collection of player IDs for each team

				List<int> team1Ids = Utilities.StrToList(match.Team1);
				List<int> team2Ids = Utilities.StrToList(match.Team2);


				// Calculate all rating changes for this match

				static int TeamRatingAverage(List<int> team, Dictionary<int, int> all)
				{
					return (int)all.Where(x => team.Contains(x.Key)).Select(x => x.Value).ToList().Average();
				}

				int team1RatingAvg = TeamRatingAverage(team1Ids, allPlayerRatings);
				int team2RatingAvg = TeamRatingAverage(team2Ids, allPlayerRatings);
				int maxRatingDiff = allPlayerRatings.Values.Max() - allPlayerRatings.Values.Min();

				foreach (int t1PlayerId in team1Ids)
					allPlayerRatings[t1PlayerId] = _calc.PlayerRating(allPlayerRatings[t1PlayerId], team2RatingAvg, maxRatingDiff, match.WinningTeam == TeamNumber.Team1 ? MatchResult.Win : MatchResult.Lose);

				foreach (int t2PlayerId in team2Ids)
					allPlayerRatings[t2PlayerId] = _calc.PlayerRating(allPlayerRatings[t2PlayerId], team1RatingAvg, maxRatingDiff, match.WinningTeam == TeamNumber.Team2 ? MatchResult.Win : MatchResult.Lose);


				// If the player participated in this match, add to profile

				List<int> winningTeam = (match.WinningTeam == TeamNumber.Team1) ? team1Ids : team2Ids;
				List<int> losingTeam = (match.WinningTeam == TeamNumber.Team1) ? team2Ids : team1Ids;

				if (winningTeam.Contains(player.Id)) // Player won
				{
					profile.Wins++;
					profile.CurrentWinStreak++;
					profile.HighestWinStreak = Math.Max(profile.CurrentWinStreak, profile.HighestWinStreak);
					profile.PeakRating = Math.Max(profile.PeakRating, allPlayerRatings[player.Id]);

					foreach (int winningPlayerId in winningTeam)
						if (winningPlayerId != player.Id)
							playersWonWith[winningPlayerId]++;

					foreach (int losingPlayerId in losingTeam)
						playersWonAgainst[losingPlayerId]++;
				}
				else if (losingTeam.Contains(player.Id)) // Player lost
				{
					profile.Losses++;
					profile.CurrentWinStreak = 0;

					foreach (int losingPlayerId in losingTeam)
						if (losingPlayerId != player.Id)
							playersLostWith[losingPlayerId]++;

					foreach (int winningPlayerId in winningTeam)
						playersLostAgainst[winningPlayerId]++;
				}
				else 
				{
					// Player wasn't on either team, so do nothing to their profile
				}
			}


			// get player names for IDs

			static int HighestValueKey(Dictionary<int, int> dict)
			{
				return dict.Aggregate((l, r) => l.Value > r.Value ? l : r).Key;
			}

			int la = HighestValueKey(playersLostAgainst);
			int lw = HighestValueKey(playersLostWith);
			int wa = HighestValueKey(playersWonAgainst);
			int ww = HighestValueKey(playersWonWith);

			List<int> ids = new() { la, lw, wa, ww };
			List<Tuple<int, string>> idNames = await _context.Players
				.Where(p => ids.Contains(p.Id))
				.Select(p => new Tuple<int, string>(p.Id, p.Name))
				.ToListAsync();


			// build profile from results

			profile.WinPercent = (int)(100 * ((double)profile.Wins / (double)(profile.Wins + profile.Losses)));
			profile.Rating = allPlayerRatings[player.Id]; // temp
			profile.MostLossesAgainstPlayer = idNames.Single(i => i.Item1 == la);
			profile.MostLossesWithPlayer = idNames.Single(i => i.Item1 == lw);
			profile.MostWinsAgainstPlayer = idNames.Single(i => i.Item1 == wa);
			profile.MostWinsWithPlayer = idNames.Single(i => i.Item1 == ww);


			// Done

			return profile;
		}
	}
}
