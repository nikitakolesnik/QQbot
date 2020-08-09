using QQbot.DataAccess.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QQbot.Repositories
{
	public interface IMatchRepository
	{
		
		Task<int> GetMaxRatingDifferenceAsync();
		Task<int> RecordMatchAsync(IEnumerable<Player> winningTeam, IEnumerable<Player> losingTeam);
	}
}
