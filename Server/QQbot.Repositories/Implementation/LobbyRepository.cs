using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using QQbot.DataAccess.Contexts;
using QQbot.DataAccess.Entities;
using QQbot.Enums;
using QQbot.Repositories.Models;

namespace QQbot.Repositories.Implementation
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
			List<LobbyPlayerDisplay> lobbyDisplay = new List<LobbyPlayerDisplay>();

			// Map to display model
			foreach (LobbyPlayer lobbyPlayer in lobby)
            {
				lobbyDisplay.Add(new LobbyPlayerDisplay {
					Id         = lobbyPlayer.Player.Id,
					Name       = lobbyPlayer.Player.Name,
					Rating     = lobbyPlayer.Player.Rating,
					TeamNumber = lobbyPlayer.TeamNumber,
					Joined     = lobbyPlayer.Joined
				});
            }

			return lobbyDisplay.AsEnumerable();
		}

		public async Task<LobbyPlayer> AddPlayerByIdAsync(int id)
		{
			Player player = await _context.Players.Where(p => p.Id == id).SingleAsync();

			if (player.Status != Status.Approved)
            {
				throw new Exception("Player cannot be added to lobby. They either need to have their registration approved by a moderator, or are banned.");
            }

			LobbyPlayer lobbyPlayer = new LobbyPlayer{ Player = player };

			await _context.LobbyPlayers.AddAsync(lobbyPlayer);
			await _context.SaveChangesAsync();

			return lobbyPlayer;
		}

		public async Task<LobbyPlayer> AddPlayerByDiscordIdAsync(long discordId)
		{
			Player player = await _context.Players.SingleAsync(p => p.Discord == discordId);
			LobbyPlayer lobbyPlayer = new LobbyPlayer { Player = player };

			await _context.LobbyPlayers.AddAsync(lobbyPlayer);
			await _context.SaveChangesAsync();

			return lobbyPlayer;
		}

		public async Task<LobbyPlayer> SetTeamByIdAsync(int id, int team)
		{
			if (team < 0 || team > 2)
			{
				throw new ArgumentException();
			}

			LobbyPlayer lobbyPlayer = await _context.LobbyPlayers.SingleAsync(p => p.PlayerId == id);
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

			Player player = await _context.Players.SingleAsync(p => p.Discord == discordId);
			LobbyPlayer lobbyPlayer = await _context.LobbyPlayers.SingleAsync(p => p.Player == player);
			lobbyPlayer.TeamNumber = (TeamNumber)team;

			await _context.SaveChangesAsync();

			return lobbyPlayer;
		}

		public async Task KickPlayerByIdAsync(int id)
		{
            LobbyPlayer lobbyPlayer = await _context.LobbyPlayers.SingleAsync(p => p.PlayerId == id);
            
			_context.LobbyPlayers.Remove(lobbyPlayer);

            await _context.SaveChangesAsync();
		}

		public async Task KickPlayerByDiscordIdAsync(long discordId)
		{
			Player player = await _context.Players.SingleAsync(p => p.Discord == discordId);
			LobbyPlayer lobbyPlayer = await _context.LobbyPlayers.SingleAsync(p => p.Player == player);

			_context.LobbyPlayers.Remove(lobbyPlayer);
			
			await _context.SaveChangesAsync();
		}

		public async Task ClearTeamAsync(int team)
		{
			if (team < 0 && team > 2)
			{
				throw new ArgumentException();
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

		public async Task ClearAllAsync()
		{
			await _context.Database.ExecuteSqlRawAsync("DELETE FROM Lobby");
		}
    }
}
