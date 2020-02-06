using System.ComponentModel.DataAnnotations;

namespace QQbot.Api.Entities
{
	public class TeamPlayer
	{
		[Key]
		public int Id { get; set; }

		public Player Player { get; set; }

		public Team Team { get; set; }

		public int RatingBefore { get; set; }

		public int RatingAfter { get; set; }
	}
}
