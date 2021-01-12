using slambot.Common.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace slambot.DataAccess.Entities
{
	[Table("Lobby")]
	public class LobbyPlayer
	{
		[Key]
		public int Id { get; set; }
		public int PlayerId { get; set; }
		public TeamNumber TeamNumber { get; set; } = TeamNumber.None;
		public DateTime Joined { get; set; } = DateTime.UtcNow;

		public Player Player { get; set; }
	}
}
