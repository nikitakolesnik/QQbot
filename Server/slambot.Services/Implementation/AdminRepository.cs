using Microsoft.EntityFrameworkCore;
using slambot.Common;
using slambot.Common.Configuration;
using slambot.Common.Enums;
using slambot.DataAccess.Contexts;
using slambot.DataAccess.Entities;
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

		public async Task<IEnumerable<AdminAction>> HistoryAsync(int results = int.MaxValue)
		{
			results = Utilities.Limit(results, 0, AdminConfiguration.MaxRecordsToShow);

			return await _context.AdminActions
				.OrderByDescending(a => a.Id)
					.Take(results)
				.ToListAsync();
		}

		public async Task<IEnumerable<AdminAction>> MatchHistoryAsync(int results = int.MaxValue, int matchId = -1)
		{
			results = Utilities.Limit(results, 0, AdminConfiguration.MaxRecordsToShow);

			if (matchId == -1)
				return await _context.AdminActions
					.Where(a => a.Type == AdminActionType.ActionMatch)
					.OrderByDescending(a => a.Id)
					.Take(results)
					.ToListAsync();
			else
				return await _context.AdminActions
					.Where(a => a.Type == AdminActionType.ActionMatch && a.SubjectMatchId == matchId)
					.OrderByDescending(a => a.Id)
					.Take(results)
					.ToListAsync();
		}

		public async Task<IEnumerable<AdminAction>> PlayerHistoryAsync(int results = int.MaxValue, int playerId = -1)
		{
			results = Utilities.Limit(results, 0, AdminConfiguration.MaxRecordsToShow);

			if (playerId == -1)
				return await _context.AdminActions
					.Where(a => a.Type == AdminActionType.ActionMatch)
					.OrderByDescending(a => a.Id)
					.Take(results)
					.ToListAsync();
			else
				return await _context.AdminActions
					.Where(a => (a.Type == AdminActionType.ActionPlayer || a.Type == AdminActionType.EditPlayer) && a.SubjectPlayerId == playerId)
					.OrderByDescending(a => a.Id)
					.Take(results)
					.ToListAsync();
		}
	}
}
