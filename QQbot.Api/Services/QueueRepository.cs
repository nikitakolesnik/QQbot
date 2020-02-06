using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using QQbot.Api.Contexts;

namespace QQbot.Api.Services
{
	public class QueueRepository : IQueueRepository
	{
		private ApplicationDbContext _context;

		public QueueRepository(ApplicationDbContext context)
		{
			_context = context ?? throw new ArgumentNullException(nameof(context));
		}

		public async Task<int> ClearAsync()
		{
			return await _context.Database.ExecuteSqlRawAsync("DELETE FROM Queue");
		}
	}
}
