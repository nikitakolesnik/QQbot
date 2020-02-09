using QQbot.Api.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QQbot.Api.Services.Interfaces
{
	public interface IMatchRepository
	{
		Task<IEnumerable<Player>> GetPlayerInfoAsync(string[] names);           // ["slam", "yoko", "candy", ...]
		Task<IEnumerable<Player>> GetPlayerInfoAsync(string   nameCommaString); // "slam,yoko,candy,..."
		Task<IEnumerable<Player>> GetPlayerInfoAsync(int[]    playerIds);       // [1, 2, 3, ...]
		Task<IEnumerable<Player>> GetPlayerInfoAsync(long[]   discordIds);      // [240413827718578177, 175325337196953600, 287275232236929026, ...]
		Task<int> GetMaxRatingDifferenceAsync();
		Task<int> RecordMatchAsync(IEnumerable<Player> winningTeam, IEnumerable<Player> losingTeam);
	}
}
