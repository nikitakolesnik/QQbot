using QQbot.Api.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QQbot.Api.Services.Interfaces
{
	public interface IPlayerRepository
	{
		Task<Player> GetPlayerByIdAsync(int id);
		Task<Player> GetPlayerByNameAsync(string name);
		Task<Player> GetPlayerByDiscordIdAsync(long discordId);
		Task<IEnumerable<Player>> GetPlayersAsync();
	}
}
