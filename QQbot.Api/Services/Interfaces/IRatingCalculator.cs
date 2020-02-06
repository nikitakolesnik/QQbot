using QQbot.Api.Entities;
using QQbot.Api.Enums;
using System.Collections.Generic;

namespace QQbot.Api.Services.Interfaces
{
	public interface IRatingCalculator
	{
		public double TeamRating(IEnumerable<Player> players);
		public int PlayerRating(int playerRating, double opponentRating, MatchResult matchResult);
	}
}
