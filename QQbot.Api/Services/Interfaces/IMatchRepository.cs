using QQbot.Api.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QQbot.Api.Services.Interfaces
{
	public interface IMatchRepository
	{
		Task<IEnumerable<Player>> GetPlayerAsync(string[] names);           // ["slam", "yoko", "candy", ...]
		Task<IEnumerable<Player>> GetPlayerAsync(string   nameCommaString); // "slam,yoko,candy,..."
		Task<IEnumerable<Player>> GetPlayerAsync(int[]    playerIds);       // [1, 2, 3, ...]
		Task<IEnumerable<Player>> GetPlayerAsync(long[]   discordIds);      // [240413827718578177, 175325337196953600, 287275232236929026, ...]
		Task<int> GetMaxRatingDifferenceAsync();
		Task<int> RecordMatchAsync(IEnumerable<Player> winningTeam, IEnumerable<Player> losingTeam);
	}
}
