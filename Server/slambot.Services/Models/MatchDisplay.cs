using slambot.Common.Enums;
using System;
using System.Collections.Generic;

namespace slambot.Services.Models
{
	public class MatchDisplay
	{
		//public int Id { get; set; }
		public TeamNumber WinningTeam { get; set; }
		public List<Tuple<int, string>> Team1 { get; set; }
		public List<Tuple<int, string>> Team2 { get; set; }
		public DateTime When { get; set; }
	}
}
