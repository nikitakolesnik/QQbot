using QQbot.DataAccessLayer.Enums;
using System;

namespace QQbot.DataAccessLayer.Entities.Base
{
	public abstract class AdminActionBase
	{
		public Status Status { get; set; }
		public Player ActionedBy { get; set; }
		public DateTime ActionDate { get; set; }
	}
}
