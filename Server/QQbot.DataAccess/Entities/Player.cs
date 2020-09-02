using QQbot.DataAccess.Entities.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QQbot.DataAccess.Entities
{
	[Table("Players")]
	public class Player : EntryBase
	{
		private const int _defaultRating = 1000;

		[Key]
		public int    Id      { get; set; }
		public string Name    { get; set; }
		[Required]
		[MaxLength(20)]
		public long   Discord { get; set; } // example: 240413827718578177
		public int    Rating  { get; set; } = _defaultRating;
	}
}
