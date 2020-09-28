using Microsoft.EntityFrameworkCore;
using slambot.DataAccess.Contexts;
using slambot.DataAccess.Entities;
using slambot.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace slambot.Services.Implementation
{
	public class AdminRepository : IAdminRepository
	{
		private readonly ApplicationDbContext _context;

		public AdminRepository(ApplicationDbContext context)
		{
			_context = context ?? throw new ArgumentNullException(nameof(context));
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
