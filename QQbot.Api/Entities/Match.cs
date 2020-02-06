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

		public TeamPlayer WinningTeam { get; set; }

		public TeamPlayer LosingTeam { get; set; }

		public MatchStatus Status { get; set; } = MatchStatus.Active;
	}
}
