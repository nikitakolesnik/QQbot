using QQbot.DataAccessLayer.Entities;
using System.Collections.Generic;

namespace QQbot.DataAccessLayer.Models
{
	public class PlayerProfile
	{
		public int    Rank { get; set; }
		public string Name { get; set; }
		
		public int       Rating         { get; set; }
		public int       PeakRating     { get; set; }
		public List<int> RatingOverTime { get; set; }
		
		public int    Wins             { get; set; }
		public int    Losses           { get; set; }
		public double WinRate          { get; set; }
		public int    CurrentWinStreak { get; set; }
		public int    HighestWinStreak { get; set; }

		public Player MostWinsWith      { get; set; }
		public Player MostLossesWith    { get; set; }
		public Player MostWinsAgainst   { get; set; }
		public Player MostLossesAgainst { get; set; }
	}
}
