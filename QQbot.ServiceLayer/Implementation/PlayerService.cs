using QQbot.BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QQbot.ServiceLayer
{
	public class PlayerService : IPlayerService
	{
		private readonly IPlayerRepository _repository;

		public PlayerService(IPlayerRepository repository)
		{
			_repository = repository ?? throw new ArgumentNullException(nameof(repository));
		}
	}
}
