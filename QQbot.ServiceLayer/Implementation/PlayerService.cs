using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QQbot.ServiceLayer.Implementation
{
	public class PlayerService : IPlayerService
	{
		private readonly IMatchRepository _repository;

		public PlayerService(IMatchRepository repository)
		{
			_repository = repository ?? throw new ArgumentNullException(nameof(repository));
		}
	}
}
