using Microsoft.EntityFrameworkCore;
using QQbot.Api.Contexts;
using QQbot.Api.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QQbot.Api.Entities;
using QQbot.Api.Enums;
using Microsoft.AspNetCore.Mvc;

namespace QQbot.Api.Services
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

		public async Task<IEnumerable<Player>> GetPlayerInfoAsync(string[] names)
		{
			return await _context.Players
				.Where(p => names.Contains(p.Name, StringComparer.CurrentCultureIgnoreCase))
				.ToListAsync();
		}

		public async Task<IEnumerable<Player>> GetPlayerInfoAsync(string names)
		{
			string[] nameList = names.ToLower().Split(',');

			return await _context.Players
				.Where(p => nameList.Contains(p.Name))
				.ToListAsync();
		}

		public async Task<IEnumerable<Player>> GetPlayerInfoAsync(int[] ids)
		{
			return await _context.Players
				.Where(p => ids.Contains(p.Id))
				.ToListAsync();
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

			double winTeamRating       = _calc.TeamRating(playersWin);
			double loseTeamRating      = _calc.TeamRating(playersLose);
			int    maxRatingDifference = await this.GetMaxRatingDifferenceAsync();

			foreach (Player player in playersWin)
			{
				TeamPlayer teamPlayer = new TeamPlayer { Player = player, RatingBefore = player.Rating, Team = teamWin };

				player.Wins++;
				player.Rating = _calc.PlayerRating(player.Rating, loseTeamRating, maxRatingDifference, MatchResult.Win);
				teamPlayer.RatingAfter = player.Rating;
				await _context.AddAsync(teamPlayer);
			}
			foreach (Player player in playersLose)
			{
				TeamPlayer teamPlayer = new TeamPlayer { Player = player, RatingBefore = player.Rating, Team = teamLose };

				player.Losses++;
				player.Rating = _calc.PlayerRating(player.Rating, winTeamRating, maxRatingDifference, MatchResult.Lose);
				teamPlayer.RatingAfter = player.Rating;
				await _context.AddAsync(teamPlayer);
			}


			// Done

			return await _context.SaveChangesAsync();
		}
	}
}
