using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QQbot.DataAccessLayer.Entities
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

		public int WarriorRating { get; set; }

		public int RangerRating { get; set; }

		public int MonkRating { get; set; }

		public int NecromancerRating { get; set; }

		public int MesmerRating { get; set; }

		public int ElementalistRating { get; set; }

		public int AssassinRating { get; set; }

		public int RitualistRating { get; set; }

		public int ParagonRating { get; set; }

		public int DervishRating { get; set; }

		/* Achievements/badges/stats?
			- win/loss count & winrate & winstreak counted from match table
			- rank? bronze/silver/gold/etc
		 */
	}
}
