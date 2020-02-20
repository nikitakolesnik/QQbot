using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QQbot.DataAccessLayer
{
	[Table("Players")]
	public class Player
	{
		[Key]
		public int Id { get; set; }

		public long DiscordId { get; set; } // example: 240413827718578177

		[Required]
		[MaxLength(20)]
		public string Name { get; set; }

		public bool PlaysFront { get; set; } = false;

		public bool PlaysMid { get; set; } = false;

		public bool PlaysBack { get; set; } = false;

		public int Rating { get; set; } = 0;

		public int Wins { get; set; } = 0;

		public int Losses { get; set; } = 0;

		/* Achievements/badges/stats?
			- games played & winrate inferred
			- highest consecutive wins
			- rank? bronze/silver/gold/etc
		 */
	}
}
