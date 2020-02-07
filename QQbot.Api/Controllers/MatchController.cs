using Microsoft.AspNetCore.Mvc;
using QQbot.Api.Services.Interfaces;
using System;

using System.Threading.Tasks;

namespace QQbot.Api.Controllers
{
	[ApiController]
	[Route("api/match")]
	public class MatchController : ControllerBase
	{
		private IMatchRepository _matchRepository;

		public MatchController(IMatchRepository matchRepository)
		{
			_matchRepository = matchRepository ?? throw new ArgumentNullException(nameof(matchRepository));
		}

		[HttpGet]
		public async Task<IActionResult> RecordMatch(string[] winningNames, string[] losingNames)
		{
			await _matchRepository.RecordMatchAsync(
				await _matchRepository.GetPlayerInfoAsync(winningNames),
				await _matchRepository.GetPlayerInfoAsync(losingNames)
			);

			return Ok();
		}

		[HttpGet]
		public async Task<IActionResult> RecordMatch(string winningNameList, string losingNameList)
		{
			await _matchRepository.RecordMatchAsync(
				await _matchRepository.GetPlayerInfoAsync(winningNameList),
				await _matchRepository.GetPlayerInfoAsync(losingNameList)
			);

			return Ok();
		}

		[HttpGet]
		public async Task<IActionResult> RecordMatch(int[] winningIds, int[] losingIds)
		{
			await _matchRepository.RecordMatchAsync(
				await _matchRepository.GetPlayerInfoAsync(winningIds),
				await _matchRepository.GetPlayerInfoAsync(losingIds)
			);

			return Ok();
		}
	}
}
