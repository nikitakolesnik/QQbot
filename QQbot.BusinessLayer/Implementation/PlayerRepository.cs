using Microsoft.EntityFrameworkCore;
using QQbot.DataAccessLayer;
using QQbot.DataAccessLayer.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QQbot.BusinessLayer.Implementation
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

		public async Task<Player> GetPlayerByNameAsync(string name)
		{
			return await _context.Players.Where(p => p.Name == name).FirstAsync();
		}

		public async Task<Player> GetPlayerByDiscordIdAsync(long discordId)
		{
			return await _context.Players.Where(p => p.DiscordId == discordId).FirstAsync();
		}

		public async Task<IEnumerable<Player>> GetPlayersByNamesAsync(string[] names) // ["slam", "yoko", "candy", ...]
		{
			return await _context.Players
				.Where(p => names.Contains(p.Name, StringComparer.CurrentCultureIgnoreCase))
				.ToListAsync();
		}

		public async Task<IEnumerable<Player>> GetPlayersByNameStringAsync(string nameString) // "slam,yoko,candy,..."
		{
			string[] nameList = nameString.ToLower().Split(',');

			return await _context.Players
				.Where(p => nameList.Contains(p.Name))
				.ToListAsync();
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

		public async Task<IEnumerable<Player>> GetAllPlayersAsync()
		{
			return await _context.Players.ToListAsync();
		}
	}
}
