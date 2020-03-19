using QQbot.BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QQbot.ServiceLayer
{
	public class QueueService : IQueueService
	{
		private readonly ILobbyRepository _repository;

		public QueueService(ILobbyRepository repository)
		{
			_repository = repository ?? throw new ArgumentNullException(nameof(repository));
		}
	}
}
