using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QQbot.DataAccessLayer.Entities
{
	[Table("TeamPlayers")]
	public class TeamPlayer
	{
		[Key]
		public int Id { get; set; }

		public Team Team { get; set; }

		public Player Player { get; set; }

		public int PlayerId { get; set; }
	}
}
