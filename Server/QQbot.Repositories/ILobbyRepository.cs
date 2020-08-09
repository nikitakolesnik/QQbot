using QQbot.DataAccess.Entities;
using System.Threading.Tasks;

namespace QQbot.Repositories
{
	public interface ILobbyRepository
	{
		Task<LobbyPlayer> AddPlayerByIdAsync(int id);
		Task<LobbyPlayer> AddPlayerByDiscordIdAsync(long discordId);

		Task<LobbyPlayer> SetTeamByIdAsync(int id, int team);
		Task<LobbyPlayer> SetTeamByDiscordIdAsync(long discordId, int team);

		Task KickPlayerByIdAsync(int id);
		Task KickPlayerByDiscordIdAsync(long discordId);

		Task ClearTeamAsync(int team);
		Task ClearAllAsync();
	}
}
