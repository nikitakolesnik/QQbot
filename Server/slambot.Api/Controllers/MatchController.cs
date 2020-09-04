using Microsoft.AspNetCore.Mvc;
using slambot.Repositories;
using System;
using System.Threading.Tasks;

namespace slambot.Api.Controllers
{
	[ApiController]
	[Route("api/match")]
	public class MatchController : ControllerBase
	{
		private readonly IMatchRepository _matchRepository;
		private readonly IPlayerRepository _playerRepository;

		public MatchController(IMatchRepository matchRepository, IPlayerRepository playerRepository)
		{
			_matchRepository = matchRepository ?? throw new ArgumentNullException(nameof(matchRepository));
			_playerRepository = playerRepository ?? throw new ArgumentNullException(nameof(playerRepository));
		}

		/*
		 * Who played in match 45                          - api/match/45                GET
		 * Edit match 45                                   - api/match/45                PUT
		 * Activate/disable match 45                       - api/match/45/action/1       PUT
		 * Get 10 last active matches                      - api/match/history/10        GET
		 * Get 10 last active matches involving player 123 - api/match/history/10/id/123 GET
		 * Submit match                                    - api/match                   POST (with body)
		 */

	}
}
