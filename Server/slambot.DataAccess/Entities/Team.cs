using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace slambot.DataAccess.Entities
{
	[Table("Teams")]
	public class Team
	{
		[Key]
		public int Id { get; set; }
	}
}
