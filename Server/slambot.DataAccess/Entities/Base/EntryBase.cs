using slambot.Common.Enums;
using System;

namespace slambot.DataAccess.Entities.Base
{
	public abstract class EntryBase
	{
		public DateTime Submitted { get; set; } = DateTime.UtcNow;
		public Status Status { get; set; }
	}
}
