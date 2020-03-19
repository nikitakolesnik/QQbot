using QQbot.DataAccessLayer.Entities.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QQbot.DataAccessLayer.Entities
{
	[Table("Players")]
	public class Player : AdminActionBase
	{
		[Key]
		public int Id { get; set; }

		public long DiscordId { get; set; } // example: 240413827718578177

		[Required]
		[MaxLength(20)]
		public string Name { get; set; }

		public int Rating { get; set; }
	}
}
