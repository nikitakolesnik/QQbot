using slambot.Common.Enums;
using System.Threading.Tasks;

namespace slambot.Services
{
    public interface IMatchRepository
	{
		Task<int> GetMaxRatingDifferenceAsync();
		Task RecordMatchAsync(TeamNumber winningTeam, int? ratingDiffOverride /* Prevent hitting the database while building local results from match data */);
	}
}
