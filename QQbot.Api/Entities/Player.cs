using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QQbot.Api.Entities
{
	[Table("Players")]
	public class Player
	{
		[Key]
		public Guid Id { get; set; } = Guid.NewGuid();

		[Required]
		[MaxLength(20)]
		public string Name { get; set; }

		public bool PlaysFront { get; set; } = false;

		public bool PlaysMid { get; set; } = false;

		public bool PlaysBack { get; set; } = false;

		public int Shitlo { get; set; } = 1000;

		public int Wins { get; set; } = 0;

		public int Losses { get; set; } = 0;

		/* Achievements/badges/stats?
			- games played & winrate inferred
			- highest consecutive wins
			- rank? bronze/silver/gold/etc
			- 
		 */
	}
}
