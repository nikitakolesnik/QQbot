using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace QQbot.Api.Entities
{
	[Table("Matches")]
	public class Match
	{
		[Key]
		public Guid Id { get; set; }

		public DateTime When { get; set; }


	}
}
