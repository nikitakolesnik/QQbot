using slambot.DataAccess.Entities;
using slambot.Services.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace slambot.Services
{
	public interface ILobbyRepository
	{
		Task<IEnumerable<LobbyPlayerDisplay>> GetLobby();
		Task<LobbyPlayer> AddPlayerAsync(int id);
		Task<LobbyPlayer> SetTeamAsync(int id, int team);
		Task KickPlayerAsync(int id);
		Task ClearTeamAsync(int team);
		Task ClearLobbyAsync();
	}
}
