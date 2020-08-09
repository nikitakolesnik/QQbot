using QQbot.DataAccess.Entities.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QQbot.DataAccess.Entities
{
	[Table("Players")]
	public class Player : EntryBase
	{
		[Key]
		public int Id { get; set; }

		public long Discord { get; set; } // example: 240413827718578177

		[Required]
		[MaxLength(20)]
		public string Name { get; set; }

		public int Rating { get; set; } = 1000; // some default value
	}
}
