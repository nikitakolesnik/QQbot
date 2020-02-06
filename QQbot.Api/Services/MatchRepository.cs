using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QQbot.Api.Contexts;
using QQbot.Api.Models;
using QQbot.Api.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using QQbot.Api.Entities;

namespace QQbot.Api.Services
{
	public class MatchRepository : IMatchRepository
	{
		private readonly ApplicationDbContext _context;
		private readonly IMapper _mapper;

		public MatchRepository(ApplicationDbContext context, IMapper mapper)
		{
			_context = context ?? throw new ArgumentNullException(nameof(context));
			_mapper  = mapper  ?? throw new ArgumentNullException(nameof(mapper));
		}

		private async Task<IEnumerable<PlayerCompact>> GetPlayerInfoAsync(string[] names)
		{
			var players = await _context.Players
				//.Select(p => new { p.Name, p.Id, p.Rating }) // TODO: see if doing this is actually faster
				.Where(p => names.Contains(p.Name, StringComparer.CurrentCultureIgnoreCase))
				.ToListAsync();

			return _mapper.Map<PlayerCompact[]>(players);
		}

		public async Task<IActionResult> RecordMatchAsync(string[] winningPlayers, string[] losingPlayers)
		{
			// Create player lists for both teams

			IEnumerable<PlayerCompact> playersWin  = await GetPlayerInfoAsync(winningPlayers);
			IEnumerable<PlayerCompact> playersLose = await GetPlayerInfoAsync(losingPlayers);
			//IEnumerable<PlayerCompact> players = Enumerable.Empty<PlayerCompact>()
			//	.Concat(await GetPlayerInfoAsync(winningPlayers))
			//	.Concat(await GetPlayerInfoAsync(losingPlayers));


			// Create new teams

			Team teamWin  = new Team();
			Team teamLose = new Team();

			await _context.Teams.AddAsync(teamWin);
			await _context.Teams.AddAsync(teamLose);


			//Create the match, with winning & losing teams

			Match match = new Match { WinningTeam = teamWin, LosingTeam = teamLose };
			
			await _context.Matches.AddAsync(match);


			//Create TeamPlayer rows

			foreach(var player in playersWin)
			{
				await _context.TeamPlayers.AddAsync(new TeamPlayer { });
			}



			throw new NotImplementedException();
		}
	}
}
