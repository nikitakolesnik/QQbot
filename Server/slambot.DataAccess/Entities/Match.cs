using slambot.Common.Enums;
using slambot.DataAccess.Entities.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace slambot.DataAccess.Entities
{
	[Table("Matches")]
	public class Match : EntryBase
	{
		[Key]
		public int Id { get; set; }
		public TeamNumber WinningTeam { get; set; }
		public string Team1 { get; set; }
		public string Team2 { get; set; }
	}
}
