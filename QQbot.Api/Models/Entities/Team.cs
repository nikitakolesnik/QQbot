using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QQbot.Api.Models.Entities
{
	[Table("Teams")]
	public class Team
	{
		[Key]
		public int Id { get; set; }
	}
}
