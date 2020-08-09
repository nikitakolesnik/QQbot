using Microsoft.EntityFrameworkCore;
using QQbot.DataAccess.Entities;
using QQbot.DataAccess.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QQbot.DataAccess.Enums;
using QQbot.DataAccess.Models;

namespace QQbot.Repositories.Implementation
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
			if (string.IsNullOrEmpty(playerInfo.Name))
			{
				throw new ArgumentException("Name cannot be empty.");
			}

			Player newPlayer = new Player { Name = playerInfo.Name, Discord = playerInfo.Discord, Status = Status.PendingReview };
			await _context.Players.AddAsync(newPlayer);
			await _context.SaveChangesAsync();
			return newPlayer;
		}

		public async Task<Player> ChangeDiscordAsync(int id, long newDiscord)
		{
			Player player = await _context.Players.Where(p => p.Id == id).SingleAsync();
			player.Discord = newDiscord;
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
