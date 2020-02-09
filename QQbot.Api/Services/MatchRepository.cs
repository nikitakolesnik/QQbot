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

		//TODO: validate count of players

		public async Task<IEnumerable<Player>> GetPlayerInfoAsync(string[] names) // ["slam", "yoko", "candy", ...]
		{
			return await _context.Players
				.Where(p => names.Contains(p.Name, StringComparer.CurrentCultureIgnoreCase))
				.ToListAsync();
		}

		public async Task<IEnumerable<Player>> GetPlayerInfoAsync(string nameCommaString) // "slam,yoko,candy,..."
		{
			string[] nameList = nameCommaString.ToLower().Split(',');

			return await _context.Players
				.Where(p => nameList.Contains(p.Name))
				.ToListAsync();
		}

		public async Task<IEnumerable<Player>> GetPlayerInfoAsync(int[] playerIds) // [1, 2, 3, ...]
		{
			return await _context.Players
				.Where(p => playerIds.Contains(p.Id))
				.ToListAsync();
		}

		public async Task<IEnumerable<Player>> GetPlayerInfoAsync(long[] discordIds) // [240413827718578177, 175325337196953600, 287275232236929026, ...]
		{
			return await _context.Players
				.Where(p => discordIds.Contains(p.DiscordId))
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
