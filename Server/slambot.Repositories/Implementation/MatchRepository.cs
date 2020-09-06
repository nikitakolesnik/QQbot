using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using slambot.DataAccess.Contexts;
using slambot.DataAccess.Entities;
using slambot.Enums;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace slambot.Repositories.Implementation
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
		[ResponseCache(Duration = 5)]
		public async Task<int> GetMaxRatingDifferenceAsync()
		{
			int min = await _context.Players.MinAsync(p => p.Rating);
			int max = await _context.Players.MaxAsync(p => p.Rating);

			return Math.Abs(max - min);
		}

		public async Task<int> RecordMatchAsync(string winningPlayerIds, string losingPlayerIds)
		{
			throw new NotImplementedException();

			//// Create & Insert new teams

			//Team teamWin = new Team();
			//Team teamLose = new Team();

			//await _context.Teams.AddAsync(teamWin);
			//await _context.Teams.AddAsync(teamLose);
			//await _context.SaveChangesAsync();


			//// Create & Insert the match

			//await _context.Matches.AddAsync(new Match { WinningTeam = teamWin, LosingTeam = teamLose });


			//// Create TeamPlayer rows, calculate rating change, Insert rows

			//int winTeamRating = _calc.TeamRating(playersWin);
			//int loseTeamRating = _calc.TeamRating(playersLose);
			//int maxRatingDiff = await this.GetMaxRatingDifferenceAsync();

			//foreach (Player player in playersWin)
			//{
			//	player.Rating = _calc.PlayerRating(player.Rating, loseTeamRating, maxRatingDiff, MatchResult.Win);
			//	await _context.AddAsync(new TeamPlayer { Player = player, Team = teamWin });
			//}
			//foreach (Player player in playersLose)
			//{
			//	player.Rating = _calc.PlayerRating(player.Rating, winTeamRating, maxRatingDiff, MatchResult.Lose);
			//	await _context.AddAsync(new TeamPlayer { Player = player, Team = teamLose });
			//}


			//// Done

			//return await _context.SaveChangesAsync();
		}
	}
}
