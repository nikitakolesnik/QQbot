﻿using Microsoft.EntityFrameworkCore;
using QQbot.Api.Contexts;
using QQbot.Api.Entities;
using QQbot.Api.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QQbot.Api.Services
{
	public class PlayerRepository : IPlayerRepository
	{
		private readonly ApplicationDbContext _context;

		public PlayerRepository(ApplicationDbContext context)
		{
			_context = context ?? throw new ArgumentNullException(nameof(context));
		}

		public async Task<Player> GetPlayerAsync(int id)
		{
			return await _context.Players.Where(p => p.Id == id).FirstAsync();
		}

		public async Task<IEnumerable<Player>> GetPlayersAsync()
		{
			return await _context.Players.ToListAsync();
		}
	}
}
