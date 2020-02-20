using QQbot.DataAccessLayer;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QQbot.BusinessLayer
{
	public interface IMatchRepository
	{
		
		Task<int> GetMaxRatingDifferenceAsync();
		Task<int> RecordMatchAsync(IEnumerable<Player> winningTeam, IEnumerable<Player> losingTeam);
	}
}
