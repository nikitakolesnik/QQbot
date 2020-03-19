using QQbot.DataAccessLayer.Entities.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QQbot.DataAccessLayer.Entities
{
	[Table("Matches")]
	public class Match : AdminActionBase
	{
		[Key]
		public int Id { get; set; }

		public DateTime When { get; set; } = DateTime.UtcNow;

		public Team WinningTeam { get; set; }

		public Team LosingTeam { get; set; }
	}
}
