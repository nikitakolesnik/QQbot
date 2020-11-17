using System;
using System.Collections.Generic;

namespace slambot.Services.Models
{
	public class PlayerProfile
	{
		public int       Rank                      { get; set; }
		public string    Name                      { get; set; }
		public int       Rating                    { get; set; }
		public int       PeakRating                { get; set; }
        public List<int> RatingOverTime            { get; set; } = new List<int>();
		//public int       PeakRank                  { get; set; }
		//public List<int> RankOverTime              { get; set; }
		public int       Wins                      { get; set; }
		public int       Losses                    { get; set; }
		public int       WinPercent                { get; set; }
		public int       CurrentWinStreak          { get; set; }
		public int       HighestWinStreak          { get; set; }
		public int       MostWinsWithPlayerId      { get; set; }
		public int       MostLossesWithPlayerId    { get; set; }
		public int       MostWinsAgainstPlayerId   { get; set; }
		public int       MostLossesAgainstPlayerId { get; set; }

		//public Tuple<int,string> MostWinsWithPlayer      { get; set; }
		//public Tuple<int,string> MostLossesWithPlayer    { get; set; }
		//public Tuple<int,string> MostWinsAgainstPlayer   { get; set; }
		//public Tuple<int,string> MostLossesAgainstPlayer { get; set; }
	}
}
