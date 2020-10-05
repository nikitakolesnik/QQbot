using slambot.DataAccess.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace slambot.Services
{
    public interface IAdminRepository
	{
		Task<IEnumerable<AdminAction>> HistoryAsync(int numberResults);
		Task<IEnumerable<AdminAction>> PlayerHistoryAsync(int numberResults, int playerId);
		Task<IEnumerable<AdminAction>> MatchHistoryAsync(int numberResults, int matchId);
	}
}
