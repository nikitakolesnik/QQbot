using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QQbot.DataAccessLayer.Entities
{
	[Table("Teams")]
	public class Team
	{
		[Key]
		public int Id { get; set; }
	}
}
