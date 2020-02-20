using QQbot.Api.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QQbot.DataAccessLayer
{
	[Table("Teams")]
	public class Team
	{
		[Key]
		public int Id { get; set; }

		//public TeamNumber TeamNumber { get; set; }
	}
}
