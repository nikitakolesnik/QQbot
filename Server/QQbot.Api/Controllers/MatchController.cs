using Microsoft.AspNetCore.Mvc;
using QQbot.BusinessLayer;
using System;
using System.Threading.Tasks;

namespace QQbot.Api.Controllers
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
		 * Who played in match 45                          - api/match/45             GET
		 * Get 10 last active matches                      - api/match/history/10     GET
		 * Get 10 last active matches involving player 123 - api/match/history/10/123 GET
		 * Submit match                                    - api/match                POST
		 * Edit match 45                                   - api/match/45             PUT
		 * Activate/disable match 45                       - api/match/45/action/1    PUT
		 */ 

		[HttpGet]
		[Route("playerId")]
		public async Task<IActionResult> RecordMatch([FromBody] int[] winningIds, [FromBody] int[] losingIds)
		{
			await _matchRepository.RecordMatchAsync(
				await _playerRepository.GetPlayersByIdsAsync(winningIds),
				await _playerRepository.GetPlayersByIdsAsync(losingIds)
			);

			return Ok();
		}

		//[HttpGet]
		//[Route("discordId")]
		//public async Task<IActionResult> RecordMatch([FromBody] long[] winningDiscordIds, [FromBody] long[] losingDiscordIds)
		//{
		//	await _matchRepository.RecordMatchAsync(
		//		await _playerRepository.GetPlayersByDiscordIdsAsync(winningDiscordIds),
		//		await _playerRepository.GetPlayersByDiscordIdsAsync(losingDiscordIds)
		//	);

		//	return Ok();
		//}
	}
}
