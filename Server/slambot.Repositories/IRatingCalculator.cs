using slambot.DataAccess.Entities;
using slambot.Enums;
using System.Collections.Generic;

namespace slambot.Repositories
{
	public interface IRatingCalculator
	{
		public int TeamRating(IEnumerable<Player> players);
		public int PlayerRating(int playerRating, int opponentRating, int maxRatingDiff, MatchResult matchResult);
	}
}
