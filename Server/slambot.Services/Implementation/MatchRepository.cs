using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using slambot.DataAccess.Contexts;
using slambot.DataAccess.Entities;
using slambot.Common.Enums;
using slambot.Common.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
		public async Task<int> GetMaxRatingDifferenceAsync()
		{
			int min = await _context.Players.MinAsync(p => p.Rating);
			int max = await _context.Players.MaxAsync(p => p.Rating);

			return Math.Abs(max - min);
		}

		public async Task RecordMatchAsync(TeamNumber winningTeam, int? ratingDiffOverride = null)
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
					throw new Exception(ExceptionMessage.InvalidMatchSize);
                }
            }


			// Record the match

			await _context.Matches.AddAsync(new Match() { 
				WinningTeam = winningTeam, 
				Team1 = string.Join(',', team1),
				Team2 = string.Join(',', team2)
			});


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
		}
	}
}
