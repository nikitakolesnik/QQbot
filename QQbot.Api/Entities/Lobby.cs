using QQbot.Api.Enums;
using System.ComponentModel.DataAnnotations;

namespace QQbot.Api.Entities
{
	public class Lobby
	{
		[Key]
		public ushort Id { get; set; }

		public Status Status { get; set; }

		public Player[] Queue { get; set; }

		public Player Captain1 { get; set; }

		public Player Captain2 { get; set; }

		public Team FirstPick { get; set; }

		public Player[] Team1 { get; set; }

		public Player[] Team2 { get; set; }
	}
}
