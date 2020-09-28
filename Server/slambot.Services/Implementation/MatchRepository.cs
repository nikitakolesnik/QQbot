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

        /// <summary>
        /// Attaches player names to their IDs.
        /// </summary>
		private static List<Tuple<int, string>> StrToTuple(string team, ApplicationDbContext context)
		{
			List<int> teamList = Utilities.StrToList(team);
			List<Player> players = context.Players.Where(p => teamList.Contains(p.Id)).ToList();
			List<Tuple<int, string>> result = new List<Tuple<int, string>>();

			foreach (int id in teamList)
			{
				result.Add(new Tuple<int, string>(id, players.Single(p => p.Id == id).Name));
			}

			return result;
		}

        public async Task<Match> ActionMatchAsync(int id, Status action)
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

        public async Task<Match> EditMatchAsync(int id, TeamNumber winningTeam, string team1, string team2)
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

        public async Task<int> GetMaxRatingDifferenceAsync()
		{
			int min = await _context.Players.MinAsync(p => p.Rating);
			int max = await _context.Players.MaxAsync(p => p.Rating);

			return Math.Abs(max - min);
		}

        public async Task<IEnumerable<MatchDisplay>> HistoryAsync(int results = MatchConfiguration.DefaultMatchesToShow)
		{
			results = Utilities.Limit(results, 0, MatchConfiguration.MaxMatchesToShow);

			IEnumerable<Match> matches = await _context.Matches
				.Where(m => m.Status == Status.Approved)
				.TakeLast(results)
				//.Select(m => new MatchDisplay
				//{
				//	Id = m.Id,
				//	WinningTeam = m.WinningTeam,
				//	Team1 = StrToTuple(m.Team1, _context),
				//	Team2 = StrToTuple(m.Team2, _context),
				//	When = m.Submitted
				//})
				.ToListAsync();

			// Get all the player IDs involved in these matches

			Dictionary<int, string> players = new Dictionary<int, string>();
			IEnumerable<MatchDisplay> matchDisplays = Enumerable.Empty<MatchDisplay>();

			foreach (Match match in matches)
			{
				List<int> idList = Utilities.StrToList(match.Team1);
				idList.AddRange(Utilities.StrToList(match.Team2));

				foreach (int id in idList)
                {
					players.Add(id, "");
                }
			}

			// Get the player names of these IDs

		}

		public async Task<MatchDisplay> MatchDetailsAsync(int id)
		{
			Match match = await _context.Matches
				//.Select(m => new MatchDisplay
				//{
				//	Id = m.Id,
				//	WinningTeam = m.WinningTeam,
				//	//Team1 = StrToTuple(m.Team1, _context),
				//	//Team2 = StrToTuple(m.Team2, _context),
				//	When = m.Submitted
				//})
				.SingleAsync(m => m.Id == id);


		}

        public async Task<IEnumerable<MatchDisplay>> PlayerHistoryAsync(int playerId, int results = MatchConfiguration.DefaultMatchesToShow)
		{
			results = Utilities.Limit(results, 0, MatchConfiguration.MaxMatchesToShow);

			IEnumerable<Match> matches = await _context.Matches
				.Where(m => m.Status == Status.Approved && 
					(m.Team1.Contains(Utilities.Surround(playerId))
					|| m.Team2.Contains(Utilities.Surround(playerId))))
				.TakeLast(results)
				//.Select(m => new MatchDisplay
				//{
				//	Id = m.Id,
				//	WinningTeam = m.WinningTeam,
				//	//Team1 = StrToTuple(m.Team1, _context),
				//	//Team2 = StrToTuple(m.Team2, _context),
				//	When = m.Submitted
				//})
				.ToListAsync();
		}

        public async Task<Match> RecordMatchAsync(TeamNumber winningTeam)
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
			int maxRatingDiff  = await this.GetMaxRatingDifferenceAsync();

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
