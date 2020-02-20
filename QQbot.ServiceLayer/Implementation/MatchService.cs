using QQbot.BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QQbot.ServiceLayer
{
	public class MatchService : IMatchService
	{
		private readonly IMatchRepository _repository;

		public MatchService(IMatchRepository repository)
		{
			_repository = repository ?? throw new ArgumentNullException(nameof(repository));
		}
	}
}
