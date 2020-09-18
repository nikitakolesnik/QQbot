using slambot.Common.Enums;
using slambot.DataAccess.Entities;
using slambot.Services.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace slambot.Services
{
	public interface IPlayerRepository
	{
		Task<Player> ActionPlayerAsync(int id, Status action);
		Task<Player> AddPlayerAsync(SubmittedPlayer player);
		Task<Player> UpdatePlayerAsync(int id, SubmittedPlayer playerData);
		Task<SubmittedPlayer> PlayerNameDiscordAsync(int id);
		Task<IEnumerable<LeaderboardPlayer>> LeaderboardAsync();
		Task<PlayerProfile> ProfileAsync(int id);
	}
}
