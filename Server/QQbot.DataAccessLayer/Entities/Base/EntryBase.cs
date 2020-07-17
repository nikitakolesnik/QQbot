using QQbot.DataAccessLayer.Enums;
using System;

namespace QQbot.DataAccessLayer.Entities.Base
{
	public abstract class EntryBase
	{
		public DateTime Submitted { get; set; } = DateTime.UtcNow;
		public Status Status { get; set; }
	}
}
