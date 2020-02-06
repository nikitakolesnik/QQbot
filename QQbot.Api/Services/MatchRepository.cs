using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QQbot.Api.Contexts;
using QQbot.Api.Entities;
using QQbot.Api.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QQbot.Api.Services
{
	public class MatchRepository : IMatchRepository
	{
		private ApplicationDbContext _context;

		public MatchRepository(ApplicationDbContext context)
		{
			_context = context ?? throw new ArgumentNullException(nameof(context));
		}

		public async Task<IEnumerable<Player>> GetPlayersAsync(string[] names)
		{
			//var allPlayers = await _context.Players.ToListAsync();

			//allPlayers.Contains(names, StringComparer.CurrentCultureIgnoreCase);

			throw new NotImplementedException();
		}

		public async Task<IActionResult> RecordMatchAsync(List<Player> winningTeam, List<Player> losingTeam)
		{
			throw new NotImplementedException();
		}
	}
}
