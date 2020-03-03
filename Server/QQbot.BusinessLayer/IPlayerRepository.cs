using QQbot.DataAccessLayer.Entities;
using QQbot.DataAccessLayer.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QQbot.BusinessLayer
{
	public interface IPlayerRepository
	{
		Task<Player> GetPlayerByIdAsync(int id);
		Task<Player> GetPlayerByDiscordIdAsync(long discordId);

		Task<IEnumerable<Player>> GetPlayersByIdsAsync(int[] playerIds);          // [1, 2, 3, ...]
		Task<IEnumerable<Player>> GetPlayersByDiscordIdsAsync(long[] discordIds); // [240413827718578177, 175325337196953600, 287275232236929026, ...]

		Task<IEnumerable<LeaderboardPlayer>> GetLeaderboardAsync();
	}
}
