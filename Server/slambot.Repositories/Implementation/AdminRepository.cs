using Microsoft.EntityFrameworkCore;
using slambot.DataAccess.Contexts;
using slambot.DataAccess.Entities;
using slambot.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace slambot.Repositories.Implementation
{
	public class AdminRepository : IAdminRepository
	{
		private readonly ApplicationDbContext _context;

		public AdminRepository(ApplicationDbContext context)
		{
			_context = context ?? throw new ArgumentNullException(nameof(context));
		}

		public async Task<Match> ActionMatch(int id, Status newStatus)
		{
			Match match = await _context.Matches.Where(m => m.Id == id).SingleAsync();
			match.Status = newStatus;
			await _context.AdminActions.AddAsync(new AdminAction { AdminId = 1, SubjectMatchId = id, Type = AdminActionType.ActionMatch });
			await _context.SaveChangesAsync();
			return match;
		}

		public async Task<Player> ActionPlayer(int id, Status newStatus)
		{
			Player player = await _context.Players.Where(p => p.Id == id).SingleAsync();
			player.Status = newStatus;
			await _context.AdminActions.AddAsync(new AdminAction { AdminId = 1, SubjectPlayerId = id, Type = AdminActionType.ActionPlayer });
			await _context.SaveChangesAsync();
			return player;
		}

		public async Task<Player> EditPlayer(int id, long discord = -1, string name = null)
		{
			Player player = await _context.Players.Where(p => p.Id == id).SingleAsync();
			if (discord != -1)
				player.Discord = discord;
			if (name != null)
				player.Name = name;
			await _context.AdminActions.AddAsync(new AdminAction { AdminId = 1, SubjectPlayerId = id, Type = AdminActionType.EditPlayer });
			await _context.SaveChangesAsync();
			return player;
		}

		public async Task<IEnumerable<AdminAction>> History(int numberResults = int.MaxValue)
		{
			return await _context.AdminActions.TakeLast(numberResults).ToListAsync();
		}

		public async Task<IEnumerable<AdminAction>> MatchHistory(int numberResults = int.MaxValue, int matchId = -1)
		{
			if (matchId == -1)
				return await _context.AdminActions
					.Where(a => a.Type == AdminActionType.ActionMatch)
					.TakeLast(numberResults)
					.ToListAsync();
			else
				return await _context.AdminActions
					.Where(a => a.Type == AdminActionType.ActionMatch && a.SubjectMatchId == matchId)
					.TakeLast(numberResults)
					.ToListAsync();
		}

		public async Task<IEnumerable<AdminAction>> PlayerHistory(int numberResults = int.MaxValue, int playerId = -1)
		{
			if (playerId == -1)
				return await _context.AdminActions
					.Where(a => a.Type == AdminActionType.ActionMatch)
					.TakeLast(numberResults)
					.ToListAsync();
			else 
				return await _context.AdminActions
					.Where(a => (a.Type == AdminActionType.ActionPlayer || a.Type == AdminActionType.EditPlayer) && a.SubjectPlayerId == playerId)
					.TakeLast(numberResults)
					.ToListAsync();
		}
	}
}
