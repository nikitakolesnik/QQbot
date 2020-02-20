using QQbot.DataAccessLayer;
using QQbot.DataAccessLayer.Enums;
using System.Collections.Generic;

namespace QQbot.BusinessLayer
{
	public interface IRatingCalculator
	{
		public int TeamRating(IEnumerable<Player> players);
		public int PlayerRating(int playerRating, int opponentRating, int maxRatingDiff, MatchResult matchResult);
	}
}
