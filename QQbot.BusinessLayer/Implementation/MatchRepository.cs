using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QQbot.DataAccessLayer;
using QQbot.DataAccessLayer.Contexts;
using QQbot.DataAccessLayer.Enums;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QQbot.BusinessLayer
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

		// Consider caching this result? idk how long
		[ResponseCache(Duration = 1)]
		public async Task<int> GetMaxRatingDifferenceAsync()
		{
			int min = await _context.Players.MinAsync(p => p.Rating);
			int max = await _context.Players.MaxAsync(p => p.Rating);
			
			return Math.Abs(max - min);
		}

		public async Task<int> RecordMatchAsync(IEnumerable<Player> playersWin, IEnumerable<Player> playersLose)
		{
			// Create & Insert new teams

			Team teamWin  = new Team();
			Team teamLose = new Team();

			await _context.Teams.AddAsync(teamWin);
			await _context.Teams.AddAsync(teamLose);
			await _context.SaveChangesAsync();


			// Create & Insert the match

			await _context.Matches.AddAsync(new Match { WinningTeam = teamWin, LosingTeam = teamLose });


			// Create TeamPlayer rows, calculate rating change, save rating before & after, Insert rows

			int winTeamRating  = _calc.TeamRating(playersWin);
			int loseTeamRating = _calc.TeamRating(playersLose);
			int maxRatingDiff  = await this.GetMaxRatingDifferenceAsync();

			foreach (Player player in playersWin)
			{
				TeamPlayer teamPlayer = new TeamPlayer { Player = player, RatingBefore = player.Rating, Team = teamWin };

				player.Wins++;
				player.Rating = _calc.PlayerRating(player.Rating, loseTeamRating, maxRatingDiff, MatchResult.Win);
				teamPlayer.RatingAfter = player.Rating;
				await _context.AddAsync(teamPlayer);
			}
			foreach (Player player in playersLose)
			{
				TeamPlayer teamPlayer = new TeamPlayer { Player = player, RatingBefore = player.Rating, Team = teamLose };

				player.Losses++;
				player.Rating = _calc.PlayerRating(player.Rating, winTeamRating, maxRatingDiff, MatchResult.Lose);
				teamPlayer.RatingAfter = player.Rating;
				await _context.AddAsync(teamPlayer);
			}


			// Done

			return await _context.SaveChangesAsync();
		}
	}
}
