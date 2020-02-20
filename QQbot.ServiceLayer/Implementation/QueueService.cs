using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QQbot.ServiceLayer.Implementation
{
	public class QueueService : IQueueService
	{
		private readonly IQueueRepository _repository;

		public QueueService(IQueueRepository repository)
		{
			_repository = repository ?? throw new ArgumentNullException(nameof(repository));
		}
	}
}
