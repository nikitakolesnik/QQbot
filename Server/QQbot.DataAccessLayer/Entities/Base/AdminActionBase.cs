using QQbot.DataAccessLayer.Enums;
using System;

namespace QQbot.DataAccessLayer.Entities.Base
{
	public abstract class AdminActionBase
	{
		public DateTime Submitted { get; set; } = DateTime.UtcNow;
		public Status Status { get; set; }
	}
}
