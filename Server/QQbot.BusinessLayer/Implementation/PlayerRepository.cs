using Microsoft.EntityFrameworkCore;
using QQbot.DataAccessLayer.Entities;
using QQbot.DataAccessLayer.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QQbot.DataAccessLayer.Enums;
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

		//public async Task<Player> ActionPlayerAsync(int id, Status action)
		//{
		//	throw new NotImplementedException();
		//}

		public async Task<Player> AddPlayerAsync(SubmittedPlayer playerInfo)
		{
			Player newPlayer = new Player { Name = playerInfo.Name, DiscordId = playerInfo.Discord, Status = Status.PendingReview };
			await _context.Players.AddAsync(newPlayer);
			await _context.SaveChangesAsync();
			return newPlayer;
		}

		public async Task<Player> ChangeDiscordAsync(int id, long newDiscord)
		{
			Player player = await _context.Players.Where(p => p.Id == id).SingleAsync();
			player.DiscordId = newDiscord;
			await _context.SaveChangesAsync();
			return player;
		}

		public async Task<Player> ChangeNameAsync(int id, string newName)
		{
			Player player = await _context.Players.Where(p => p.Id == id).SingleAsync();
			player.Name = newName;
			await _context.SaveChangesAsync();
			return player;
		}

		public async Task<IEnumerable<LeaderboardPlayer>> GetLeaderboardAsync()
		{
			List<Player> players = await _context.Players.OrderByDescending(x => x.Rating).ToListAsync();
			
			List<LeaderboardPlayer> leaderboard = new List<LeaderboardPlayer>();
			int rank = 1;
			foreach (var player in players)
			{
				leaderboard.Add(new LeaderboardPlayer { Rank = rank++, Name = player.Name, Rating = player.Rating });
			}

			return leaderboard;
		}

		//public async Task<PlayerProfile> GetProfileByIdAsync(int id)
		//{
		//	throw new NotImplementedException();
		//}
	}
}
