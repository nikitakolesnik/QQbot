using slambot.Common.Configuration;
using slambot.Common.Enums;
using slambot.DataAccess.Entities;
using slambot.Services.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace slambot.Services
{
    public interface IMatchRepository
	{
		Task<Match> ActionAsync(int matchId, Status action);
		Task<MatchDisplay> DetailsAsync(int id);
		Task<Match> EditAsync(int id, TeamNumber winningTeam, string team1, string team2);
		Task<int> MaxRatingDiffAsync();
		Task<List<MatchDisplay>> HistoryAsync(int resultCount = MatchConfiguration.DefaultMatchesToShow, int playerId = -1);
		Task<Match> RecordAsync(TeamNumber winningTeam);
	}
}
