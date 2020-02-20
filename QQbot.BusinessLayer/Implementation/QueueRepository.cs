using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using QQbot.DataAccessLayer.Contexts;

namespace QQbot.BusinessLayer.Implementation
{
	public class QueueRepository : IQueueRepository
	{
		private readonly ApplicationDbContext _context;

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
