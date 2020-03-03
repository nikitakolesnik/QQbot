using Microsoft.EntityFrameworkCore;
using QQbot.DataAccessLayer.Entities;
using QQbot.DataAccessLayer.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QQbot.DataAccessLayer.Models;

namespace QQbot.BusinessLayer
{
	public class PlayerRepository : IPlayerRepository
	{
		private readonly ApplicationDbContext _context;

		public PlayerRepository(ApplicationDbContext context)
		{
			_context = context ?? throw new ArgumentNullException(nameof(context));
		}

		public async Task<Player> GetPlayerByIdAsync(int id)
		{
			return await _context.Players.Where(p => p.Id == id).FirstAsync();
		}

		public async Task<Player> GetPlayerByDiscordIdAsync(long discordId)
		{
			return await _context.Players.Where(p => p.DiscordId == discordId).FirstAsync();
		}

		public async Task<IEnumerable<Player>> GetPlayersByIdsAsync(int[] playerIds) // [1, 2, 3, ...]
		{
			return await _context.Players
				.Where(p => playerIds.Contains(p.Id))
				.ToListAsync();
		}

		public async Task<IEnumerable<Player>> GetPlayersByDiscordIdsAsync(long[] discordIds) // [240413827718578177, 175325337196953600, 287275232236929026, ...]
		{
			return await _context.Players
				.Where(p => discordIds.Contains(p.DiscordId))
				.ToListAsync();
		}

		public async Task<IEnumerable<LeaderboardPlayer>> GetLeaderboardAsync()
		{
			throw new NotImplementedException();
			//return await _context.Players.ToListAsync();
		}
	}
}
