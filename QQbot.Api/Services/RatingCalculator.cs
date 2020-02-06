using QQbot.Api.Entities;
using QQbot.Api.Enums;
using QQbot.Api.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace QQbot.Api.Services
{
	public class RatingCalculator : IRatingCalculator
	{
		public double TeamRating(IEnumerable<Player> players)
		{
			return players.Sum(p => p.Rating) / players.Count();
		}

		public int PlayerRating(int playerRating, double opponentRating, MatchResult matchResult)
		{
			throw new NotImplementedException();
		}
	}
}
