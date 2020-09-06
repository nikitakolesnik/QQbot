using System.Threading.Tasks;

namespace slambot.Repositories
{
    public interface IMatchRepository
	{
		Task<int> GetMaxRatingDifferenceAsync();
		Task<int> RecordMatchAsync(string winningPlayerIds, string losingPlayerIds);
	}
}
