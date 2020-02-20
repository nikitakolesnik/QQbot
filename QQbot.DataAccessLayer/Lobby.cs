using QQbot.Api.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QQbot.DataAccessLayer
{
	[Table("Lobby")]
	public class Lobby
	{
		[Key]
		public int Id { get; set; }

		public Player Player { get; set; }

		public TeamNumber TeamNumber { get; set; } = TeamNumber.NoTeam;

		public DateTime Joined { get; set; } = DateTime.UtcNow;
	}
}
