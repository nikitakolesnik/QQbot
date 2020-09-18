using slambot.Common.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace slambot.DataAccess.Entities
{
	[Table("AdminHistory")]
	public class AdminAction
	{
		[Key]
		public int Id { get; set; }
		public int AdminId { get; set; }
		public DateTime When { get; set; } = DateTime.UtcNow;
		public AdminActionType Type { get; set; }
		public int? SubjectPlayerId { get; set; }
		public int? SubjectMatchId { get; set; }
		public Status Action { get; set; }
		
		public Player Admin { get; set; }
		public Player SubjectPlayer { get; set; }
		public Match SubjectMatch { get; set; }
	}
}
