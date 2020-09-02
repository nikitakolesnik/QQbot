using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QQbot.DataAccess.Entities
{
	[Table("TeamPlayers")]
	public class TeamPlayer
	{
		[Key]
		public int Id { get; set; }
		public int PlayerId { get; set; }
		public int TeamId { get; set; }

		public Player Player { get; set; }
		public Team Team { get; set; }
	}
}
