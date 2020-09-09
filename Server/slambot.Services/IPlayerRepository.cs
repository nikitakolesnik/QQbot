using slambot.DataAccess.Entities;
using slambot.Services.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace slambot.Services
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
