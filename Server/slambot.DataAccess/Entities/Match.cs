using slambot.Common.Enums;
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
		public int        Id          { get; set; }
		public DateTime   When        { get; set; } = DateTime.UtcNow;
		public TeamNumber WinningTeam { get; set; }
		public string     Team1       { get; set; }
		public string     Team2       { get; set; }
	}
}
