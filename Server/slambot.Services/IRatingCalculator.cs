using slambot.Common.Enums;

namespace slambot.Services
{
    public interface IRatingCalculator
	{
		public int PlayerRating(int playerRating, int opponentRating, int maxRatingDiff, MatchResult matchResult);
	}
}
