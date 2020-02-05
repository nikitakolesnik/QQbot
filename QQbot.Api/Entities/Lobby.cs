using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QQbot.Api.Entities
{
	public class Lobby
	{
		[Key]
		public Guid Id { get; set; }
	}
}
