using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QQbot.Api.Entities
{
	[Table("Players")]
	public class Player
	{
		[Key]
		public ushort Id { get; set; }

		public ulong DiscordId { get; set; } // 240413827718578177

		[Required]
		[MaxLength(20)]
		public string Name { get; set; }

		public bool PlaysFront { get; set; } = false;

		public bool PlaysMid { get; set; } = false;

		public bool PlaysBack { get; set; } = false;

		public short Shitlo { get; set; } = 1000;

		public ushort Wins { get; set; } = 0;

		public ushort Losses { get; set; } = 0;

		/* Achievements/badges/stats?
			- games played & winrate inferred
			- highest consecutive wins
			- rank? bronze/silver/gold/etc
			- 
		 */
	}
}
