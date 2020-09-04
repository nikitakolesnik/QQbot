using slambot.DataAccess.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace slambot.Repositories
{
	public interface IMatchRepository
	{
		
		Task<int> GetMaxRatingDifferenceAsync();
		Task<int> RecordMatchAsync(IEnumerable<Player> winningTeam, IEnumerable<Player> losingTeam);
	}
}
