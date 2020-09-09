using slambot.Common.Enums;
using System.Collections.Generic;

namespace slambot.Services
{
    public interface IRatingCalculator
	{
		public int TeamRating(List<int> playerRatings);
		public int PlayerRating(int playerRating, int opponentRating, int maxRatingDiff, MatchResult matchResult);
	}
}
