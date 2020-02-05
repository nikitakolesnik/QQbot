using QQbot.Api.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QQbot.Api.Entities
{
	public class Lobby
	{
		[Key]
		public ushort Id { get; set; }

		public Player[] Queue { get; set; }

		public Player Captain1 { get; set; }

		public Player Captain2 { get; set; }

		public Player[] Team1 { get; set; }

		public Player[] Team2 { get; set; }

		public LobbyStatus Status { get; set; }
	}
}
