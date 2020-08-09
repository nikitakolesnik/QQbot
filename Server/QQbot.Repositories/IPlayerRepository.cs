using QQbot.DataAccess.Entities;
using QQbot.DataAccess.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QQbot.Repositories
{
	public interface IPlayerRepository
	{
		//Task<Player> ActionPlayerAsync(int id, Status action);
		Task<Player> AddPlayerAsync(SubmittedPlayer player);
		Task<Player> ChangeDiscordAsync(int id, long newDiscord);
		Task<Player> ChangeNameAsync(int id, string newName);
		Task<IEnumerable<LeaderboardPlayer>> GetLeaderboardAsync();
		//Task<PlayerProfile> GetProfileByIdAsync(int id);
	}
}
