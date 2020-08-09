using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using QQbot.DataAccess.Contexts;
using QQbot.DataAccess.Entities;
using QQbot.DataAccess.Enums;

namespace QQbot.Repositories.Implementation
{
	public class LobbyRepository : ILobbyRepository
	{
		private readonly ApplicationDbContext _context;

		public LobbyRepository(ApplicationDbContext context)
		{
			_context = context ?? throw new ArgumentNullException(nameof(context));
		}

		public async Task<LobbyPlayer> AddPlayerByIdAsync(int id)
		{
			Player player = await _context.Players.Where(p => p.Id == id).SingleAsync();
			LobbyPlayer lobbyPlayer = new LobbyPlayer{ Player = player };

			await _context.LobbyPlayers.AddAsync(lobbyPlayer);
			await _context.SaveChangesAsync();

			return lobbyPlayer;
		}

		public async Task<LobbyPlayer> AddPlayerByDiscordIdAsync(long discordId)
		{
			Player player = await _context.Players.Where(p => p.Discord == discordId).SingleAsync();
			LobbyPlayer lobbyPlayer = new LobbyPlayer { Player = player };

			await _context.LobbyPlayers.AddAsync(lobbyPlayer);
			await _context.SaveChangesAsync();

			return lobbyPlayer;
		}

		public async Task<LobbyPlayer> SetTeamByIdAsync(int id, int team)
		{
			if (team < 0 && team > 2)
			{
				throw new ArgumentException();
			}

			Player player = await _context.Players.Where(p => p.Id == id).SingleAsync();
			LobbyPlayer lobbyPlayer = await _context.LobbyPlayers.Where(p => p.Player == player).SingleAsync();

			lobbyPlayer.TeamNumber = (TeamNumber)team;

			await _context.SaveChangesAsync();

			return lobbyPlayer;
		}

		public async Task<LobbyPlayer> SetTeamByDiscordIdAsync(long discordId, int team)
		{
			if (team < 0 && team > 2)
			{
				throw new ArgumentException();
			}

			Player player = await _context.Players.Where(p => p.Discord == discordId).SingleAsync();
			LobbyPlayer lobbyPlayer = await _context.LobbyPlayers.Where(p => p.Player == player).SingleAsync();

			lobbyPlayer.TeamNumber = (TeamNumber)team;

			await _context.SaveChangesAsync();

			return lobbyPlayer;
		}

		public async Task KickPlayerByIdAsync(int id)
		{
			Player player = await _context.Players.Where(p => p.Id == id).SingleAsync();
			LobbyPlayer lobbyPlayer = await _context.LobbyPlayers.Where(p => p.Player == player).SingleAsync();

			_context.LobbyPlayers.Remove(lobbyPlayer);
			await _context.SaveChangesAsync();
		}

		public async Task KickPlayerByDiscordIdAsync(long discordId)
		{
			Player player = await _context.Players.Where(p => p.Discord == discordId).SingleAsync();
			LobbyPlayer lobbyPlayer = new LobbyPlayer { Player = player };

			_context.LobbyPlayers.Remove(lobbyPlayer);
			await _context.SaveChangesAsync();
		}

		public async Task ClearTeamAsync(int team)
		{
			if (team < 0 && team > 2)
			{
				throw new ArgumentException();
			}

			await _context.Database.ExecuteSqlRawAsync("DELETE FROM Lobby WHERE TeamNumber = " + team);
		}

		public async Task ClearAllAsync()
		{
			await _context.Database.ExecuteSqlRawAsync("DELETE FROM Lobby");
		}
	}
}
