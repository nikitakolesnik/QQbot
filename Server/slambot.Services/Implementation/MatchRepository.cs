using Microsoft.EntityFrameworkCore;
using slambot.DataAccess.Contexts;
using slambot.DataAccess.Entities;
using slambot.Common.Enums;
using slambot.Common.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using slambot.Services.Models;
using slambot.Common;

namespace slambot.Services.Implementation
{
    public class MatchRepository : IMatchRepository
	{
		private readonly ApplicationDbContext _context;
		private readonly IRatingCalculator _calc;

		public MatchRepository(ApplicationDbContext context, IRatingCalculator calc)
		{
			_context = context ?? throw new ArgumentNullException(nameof(context));
			_calc    = calc    ?? throw new ArgumentNullException(nameof(calc));
		}

        public async Task<Match> ActionAsync(int id, Status action)
        {
			Match match = await _context.Matches.SingleAsync(m => m.Id == id);
			match.Status = action;

			Player admin = await _context.Players.SingleAsync(p => p.Id == 1); // TEMP

			// Add this to admin action log

			await _context.AdminActions.AddAsync(new AdminAction()
			{
				Admin = admin, // todo
				Type = AdminActionType.ActionMatch,
				SubjectMatch = match,
				Action = action
			});

			// Done

			await _context.SaveChangesAsync();
			return match;
		}

        public async Task<Match> EditAsync(int id, TeamNumber winningTeam, string team1, string team2)
		{
			if (MatchConfiguration.ForceEightPlayerTeams)
            {
				if (team1.Count(c => c == ',') != 7
					|| team2.Count(c => c == ',') != 7)
                {
					throw new ArgumentException(ExceptionMessage.InvalidMatchSize);
                }
            }

			Match match = await _context.Matches.SingleAsync(m => m.Id == id);
			match.WinningTeam = winningTeam;
			match.Team1 = team1;
			match.Team2 = team2;
			await _context.SaveChangesAsync();
			return match;
        }

        public async Task<int> MaxRatingDiff()
		{
			int min = await _context.Players.MinAsync(p => p.Rating);
			int max = await _context.Players.MaxAsync(p => p.Rating);

			return Math.Abs(max - min);
		}

        public async Task<List<MatchDisplay>> HistoryAsync(int results, int playerId = -1)
		{
			results = Utilities.Limit(results, 0, MatchConfiguration.MaxMatchesToShow);

			IQueryable<Match> matchQuery = _context.Matches
				.Where(m => m.Status == Status.Approved);

			if (playerId != -1)
            {
				matchQuery = matchQuery.Where(m => m.Team1.Contains(Utilities.Surround(playerId)) 
												|| m.Team2.Contains(Utilities.Surround(playerId)));
            }

			IEnumerable<Match> matches = await matchQuery
				.OrderByDescending(p => p.Id)
				.Take(results)
				.ToListAsync();

			// Get all the player IDs involved in these matches

			HashSet<int> playerIds = new HashSet<int>();

			foreach (Match match in matches)
			{
				playerIds.UnionWith(Utilities.StrToList(match.Team1));
				playerIds.UnionWith(Utilities.StrToList(match.Team2));
			}

			// Get the names of all players that participated in these matches

			List<Tuple<int, string>> playerNames = await _context.Players
				.Where(p => playerIds.Contains(p.Id))
				.Select(p => new Tuple<int, string>(p.Id, p.Name))
				.ToListAsync();

			// Map names to IDs in matches

			List<MatchDisplay> matchDisplays = new List<MatchDisplay>();
			foreach (Match match in matches)
			{
				List<Tuple<int, string>> team1 = new List<Tuple<int, string>>();
				List<Tuple<int, string>> team2 = new List<Tuple<int, string>>();

				foreach (var player in playerNames)
                {
					string id = Utilities.Surround(player.Item1);
					
					if (match.Team1.Contains(id))
						team1.Add(player);
					else if (match.Team2.Contains(id))
						team2.Add(player);
				}

				matchDisplays.Add(new MatchDisplay
				{
					WinningTeam = match.WinningTeam,
					Team1 = team1,
					Team2 = team2,
					When = match.Submitted,
				});
			}

			return matchDisplays;
		}

		public async Task<MatchDisplay> DetailsAsync(int id)
		{
			Match match = await _context.Matches
				.SingleAsync(m => m.Id == id);

			List<Tuple<int, string>> team1Players = await _context.Players
				.Where(p => Utilities.StrToList(match.Team1).Contains(p.Id))
				.Select(p => new Tuple<int, string>(p.Id, p.Name))
				.ToListAsync();

			List<Tuple<int, string>> team2Players = await _context.Players
				.Where(p => Utilities.StrToList(match.Team2).Contains(p.Id))
				.Select(p => new Tuple<int, string>(p.Id, p.Name))
				.ToListAsync();

			return new MatchDisplay
			{
				//Id = match.Id,
				WinningTeam = match.WinningTeam,
				Team1 = team1Players,
				Team2 = team2Players,
				When = match.Submitted
			};
		}

        public async Task<Match> RecordAsync(TeamNumber winningTeam)
		{
			// Build teams 

			IEnumerable<LobbyPlayer> team1 = _context.LobbyPlayers
				.Where(p => p.TeamNumber == TeamNumber.Team1)
				.OrderBy(p => p.PlayerId); // ordering the IDs ensures that the resulting team string will always be the same for those players

			IEnumerable<LobbyPlayer> team2 = _context.LobbyPlayers
				.Where(p => p.TeamNumber == TeamNumber.Team2)
				.OrderBy(p => p.PlayerId);


			// Check if 8 vs 8

			if (MatchConfiguration.ForceEightPlayerTeams)
			{
				if (team1.Count() != 8 && team2.Count() != 8)
                {
					throw new ArgumentException(ExceptionMessage.InvalidMatchSize);
                }
            }


			// Record the match

			Match match = new Match()
			{
				WinningTeam = winningTeam,
				Team1 = string.Join(',', team1),
				Team2 = string.Join(',', team2)
			};
			await _context.Matches.AddAsync(match);


			// Calculate player rating change

			//int team1RatingAvg = _calc.TeamRating(team1.Select(p => p.Player.Rating).ToList());
			int team1RatingAvg = (int)team1.Select(p => p.Player.Rating).ToList().Average();
			int team2RatingAvg = (int)team2.Select(p => p.Player.Rating).ToList().Average();
			int maxRatingDiff  = await this.MaxRatingDiff();

			if (winningTeam == TeamNumber.Team1)
			{
				foreach(LobbyPlayer winningPlayer in team1)
                {
					winningPlayer.Player.Rating = _calc.PlayerRating(winningPlayer.Player.Rating, team2RatingAvg, maxRatingDiff, MatchResult.Win);
                }
				foreach(LobbyPlayer losingPlayer in team2)
                {
					losingPlayer.Player.Rating = _calc.PlayerRating(losingPlayer.Player.Rating, team1RatingAvg, maxRatingDiff, MatchResult.Lose);
                }
			}
			else if (winningTeam == TeamNumber.Team2)
			{
				foreach(LobbyPlayer losingPlayer in team1)
                {
					losingPlayer.Player.Rating = _calc.PlayerRating(losingPlayer.Player.Rating, team2RatingAvg, maxRatingDiff, MatchResult.Lose);
                }
				foreach (LobbyPlayer winningPlayer in team2)
				{
					winningPlayer.Player.Rating = _calc.PlayerRating(winningPlayer.Player.Rating, team1RatingAvg, maxRatingDiff, MatchResult.Win);
				}
			}
			else
            {
				// do nothing if draw
            }


			// Done

			await _context.SaveChangesAsync();
			return match;
		}
	}
}
