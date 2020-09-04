using slambot.DataAccess.Entities;
using System.Collections.Generic;

namespace slambot.Repositories.Models
{
	public class PlayerProfile
	{
		public int       Rank                      { get; set; }
		public string    Name                      { get; set; }
		public int       Rating                    { get; set; }
		public int       PeakRating                { get; set; }
		public List<int> RatingOverTime            { get; set; }
		public int       Wins                      { get; set; }
		public int       Losses                    { get; set; }
		public double    WinRate                   { get; set; }
		public int       CurrentWinStreak          { get; set; }
		public int       HighestWinStreak          { get; set; }
		public int       MostWinsWithPlayerId      { get; set; }
		public int       MostLossesWithPlayerId    { get; set; }
		public int       MostWinsAgainstPlayerId   { get; set; }
		public int       MostLossesAgainstPlayerId { get; set; }
		
		public Player    MostWinsWithPlayer        { get; set; }
		public Player    MostLossesWithPlayer      { get; set; }
		public Player    MostWinsAgainstPlayer     { get; set; }
		public Player    MostLossesAgainstPlayer   { get; set; }
	}
}
