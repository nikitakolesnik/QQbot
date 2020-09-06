using slambot.DataAccess.Entities.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace slambot.DataAccess.Entities
{
	[Table("Matches")]
	public class Match : EntryBase
	{
		[Key]
		public int      Id          { get; set; }
		public DateTime When        { get; set; } = DateTime.UtcNow;

		public string   WinningTeam { get; set; }
		public string   LosingTeam  { get; set; }
	}
}
