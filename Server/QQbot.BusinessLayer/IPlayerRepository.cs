﻿using QQbot.DataAccessLayer.Entities;
using QQbot.DataAccessLayer.Enums;
using QQbot.DataAccessLayer.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QQbot.BusinessLayer
{
	public interface IPlayerRepository
	{
		//Task<Player> ActionPlayerAsync(int id, Status action);
		Task AddPlayerAsync(Player player);
		Task<Player> ChangeDiscordAsync(int id, long newDiscord);
		Task<Player> ChangeNameAsync(int id, string newName);
		Task<IEnumerable<LeaderboardPlayer>> GetLeaderboardAsync();
		//Task<PlayerProfile> GetProfileByIdAsync(int id);
	}
}
