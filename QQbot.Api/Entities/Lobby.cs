using System;
using System.ComponentModel.DataAnnotations;

namespace QQbot.Api.Entities
{
	public class Lobby
	{
		[Key]
		public int Id { get; set; }

		public Player Player { get; set; }

		public DateTime Joined { get; set; } = DateTime.UtcNow;
	}
}
