using QQbot.Api.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QQbot.Api.Services.Interfaces
{
	public interface IMatchRepository
	{
		Task<IEnumerable<Player>> GetPlayerInfoAsync(string[] names);
		Task<IEnumerable<Player>> GetPlayerInfoAsync(string   nameCommaString);
		Task<IEnumerable<Player>> GetPlayerInfoAsync(int[]    playerIds);
		Task<IEnumerable<Player>> GetPlayerInfoAsync(long[]   discordIds);
		Task<int> GetMaxRatingDifferenceAsync();
		Task<int> RecordMatchAsync(IEnumerable<Player> winningTeam, IEnumerable<Player> losingTeam);
	}
}
