using slambot.Common.Configuration;
using slambot.DataAccess.Entities.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace slambot.DataAccess.Entities
{
	[Table("Players")]
	public class Player : EntryBase
	{
		[Key]
		public int Id { get; set; }
		public string Name { get; set; }
		[Required]
		[MaxLength(20)]
		public long Discord { get; set; } // example: 240413827718578177
		public int Rating { get; set; } = PlayerConfiguration.DefaultRating;
	}
}
