using QQbot.DataAccess.Enums;
using System;

namespace QQbot.DataAccess.Entities.Base
{
	public abstract class EntryBase
	{
		public DateTime Submitted { get; set; } = DateTime.UtcNow;
		public Status   Status    { get; set; }
    }
}
