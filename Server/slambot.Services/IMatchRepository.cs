using slambot.Common.Enums;
using slambot.DataAccess.Entities;
using slambot.Services.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace slambot.Services
{
    public interface IMatchRepository
	{
		Task<Match> ActionMatchAsync(int matchId, Status action);
		Task<Match> EditMatchAsync(int id, TeamNumber winningTeam, string team1, string team2);
		Task<int> GetMaxRatingDifferenceAsync();
		Task<IEnumerable<MatchDisplay>> HistoryAsync(int resultCount);
		Task<MatchDisplay> MatchDetailsAsync(int id);
		Task<IEnumerable<MatchDisplay>> PlayerHistoryAsync(int playerId, int resultCount);
		Task<Match> RecordMatchAsync(TeamNumber winningTeam);
	}
}
