using QQbot.Api.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QQbot.Api.Entities
{
	[Table("Matches")]
	public class Match
	{
		[Key]
		public int Id { get; set; }

		public DateTime When { get; set; } = DateTime.UtcNow;

		public Team Team1 { get; set; }

		public Team Team2 { get; set; }

		public TeamNumber Winner { get; set; }

		//[MaxLength(1000)]
		//public string Notes { get; set; } = string.Empty;

		public MatchStatus Status { get; set; } = MatchStatus.Disabled;
	}
}
