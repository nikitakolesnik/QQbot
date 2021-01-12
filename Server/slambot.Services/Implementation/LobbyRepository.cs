using Microsoft.EntityFrameworkCore;
using slambot.Common.Configuration;
using slambot.Common.Enums;
using slambot.DataAccess.Contexts;
using slambot.DataAccess.Entities;
using slambot.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace slambot.Services.Implementation
{
	public class LobbyRepository : ILobbyRepository
	{
		private readonly ApplicationDbContext _context;

		public LobbyRepository(ApplicationDbContext context)
		{
			_context = context ?? throw new ArgumentNullException(nameof(context));
		}

		public async Task<IEnumerable<LobbyPlayerDisplay>> GetLobby()
		{
			IEnumerable<LobbyPlayer> lobby = await _context.LobbyPlayers.Include("Player").ToListAsync();
			List<LobbyPlayerDisplay> lobbyDisplay = new();

			// Map to display model
			foreach (LobbyPlayer lobbyPlayer in lobby)
			{
				lobbyDisplay.Add(new LobbyPlayerDisplay
				{
					Id = lobbyPlayer.Player.Id,
					Name = lobbyPlayer.Player.Name,
					Rating = lobbyPlayer.Player.Rating,
					TeamNumber = lobbyPlayer.TeamNumber,
					Joined = lobbyPlayer.Joined
				});
			}

			return lobbyDisplay.AsEnumerable();
		}

		public async Task<LobbyPlayer> AddPlayerAsync(int id)
		{
			Player player = await _context.Players.Where(p => p.Id == id).SingleAsync();

			if (player.Status != Status.Approved)
			{
				throw new Exception(ExceptionMessage.PlayerIneligibleForLobby);
			}

			LobbyPlayer lobbyPlayer = new() { Player = player };

			await _context.LobbyPlayers.AddAsync(lobbyPlayer);
			await _context.SaveChangesAsync();

			return lobbyPlayer;
		}

		public async Task<LobbyPlayer> SetTeamAsync(int id, int team)
		{
			if (team < 0 || team > 2)
			{
				throw new ArgumentException(null, nameof(team));
			}

			LobbyPlayer lobbyPlayer = await _context.LobbyPlayers.SingleAsync(p => p.PlayerId == id);
			lobbyPlayer.TeamNumber = (TeamNumber)team;

			await _context.SaveChangesAsync();

			return lobbyPlayer;
		}

		public async Task KickPlayerAsync(int id)
		{
			LobbyPlayer lobbyPlayer = await _context.LobbyPlayers.SingleAsync(p => p.PlayerId == id);

			_context.LobbyPlayers.Remove(lobbyPlayer);

			await _context.SaveChangesAsync();
		}

		public async Task ClearTeamAsync(int team)
		{
			if (team < 0 && team > 2)
			{
				throw new ArgumentException(null, nameof(team));
			}

			IEnumerable<LobbyPlayer> lobby = await _context.LobbyPlayers.ToListAsync();

			foreach (LobbyPlayer lobbyPlayer in lobby)
			{
				if (lobbyPlayer.TeamNumber == (TeamNumber)team)
				{
					lobbyPlayer.TeamNumber = TeamNumber.None;
				}
			}

			await _context.SaveChangesAsync();
		}

		public async Task ClearLobbyAsync()
		{
			await _context.Database.ExecuteSqlRawAsync("DELETE FROM Lobby");
		}
	}
}
