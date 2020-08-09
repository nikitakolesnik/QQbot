using QQbot.DataAccess.Entities;
using QQbot.DataAccess.Enums;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QQbot.Repositories
{
	public interface IAdminRepository
	{
		Task<Match> ActionMatch(int id, Status newStatus);
		Task<Player> ActionPlayer(int id, Status newStatus);
		Task<Player> EditPlayer(int id, long discord, string name);
		Task<IEnumerable<AdminAction>> History(int numberResults);
		Task<IEnumerable<AdminAction>> PlayerHistory(int numberResults, int playerId);
		Task<IEnumerable<AdminAction>> MatchHistory(int numberResults, int matchId);
	}
}
