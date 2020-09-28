using slambot.DataAccess.Entities;
using slambot.Common.Enums;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace slambot.Services
{
	public interface IAdminRepository
	{
		Task<IEnumerable<AdminAction>> History(int numberResults);
		Task<IEnumerable<AdminAction>> PlayerHistory(int numberResults, int playerId);
		Task<IEnumerable<AdminAction>> MatchHistory(int numberResults, int matchId);
	}
}
