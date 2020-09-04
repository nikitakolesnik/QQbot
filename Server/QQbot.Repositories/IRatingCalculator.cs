using QQbot.DataAccess.Entities;
using QQbot.Enums;
using System.Collections.Generic;

namespace QQbot.Repositories
{
	public interface IRatingCalculator
	{
		public int TeamRating(IEnumerable<Player> players);
		public int PlayerRating(int playerRating, int opponentRating, int maxRatingDiff, MatchResult matchResult);
	}
}
