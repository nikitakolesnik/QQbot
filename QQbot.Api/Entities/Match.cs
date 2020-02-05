using QQbot.Api.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace QQbot.Api.Entities
{
	[Table("Matches")]
	public class Match
	{
		[Key]
		public ushort Id { get; set; }

		public DateTime When { get; set; } = DateTime.UtcNow;

		public Player[] Team1 { get; set; }

		public Player[] Team2 { get; set; }

		public MatchWinner Winner { get; set; }

		[MaxLength(1000)]
		public string Notes { get; set; } = string.Empty;

		public bool Disabled { get; set; } = false;
	}
}
