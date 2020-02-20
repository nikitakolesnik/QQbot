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
		private readonly IMatchRepository _repository;

		public MatchController(IMatchRepository repository)
		{
			_repository = repository ?? throw new ArgumentNullException(nameof(repository));
		}

		[HttpGet]
		[Route("?win={winningNames:string[]}&lose={losingNames:string[]}")]
		public async Task<IActionResult> RecordMatch(string[] winningNames, string[] losingNames) // ["slam", "yoko", "candy", ...]
		{
			await _repository.RecordMatchAsync(
				await _repository.GetPlayersAsync(winningNames),
				await _repository.GetPlayersAsync(losingNames)
			);

			return Ok();
		}

		[HttpGet]
		[Route("?win={winningNameList:string}&lose={losingNameList:string}")]
		public async Task<IActionResult> RecordMatch(string winningNameCommaString, string losingNameCommaString) // "slam,yoko,candy,..."
		{
			await _repository.RecordMatchAsync(
				await _repository.GetPlayersAsync(winningNameCommaString),
				await _repository.GetPlayersAsync(losingNameCommaString)
			);

			return Ok();
		}

		[HttpGet]
		[Route("?win={winningIds:int[]}&lose={losingIds:int[]}")]
		public async Task<IActionResult> RecordMatch(int[] winningIds, int[] losingIds) // [1,2,3,...]
		{
			await _repository.RecordMatchAsync(
				await _repository.GetPlayersAsync(winningIds),
				await _repository.GetPlayersAsync(losingIds)
			);

			return Ok();
		}

		[HttpGet]
		[Route("?win={winningIds:int[]}&lose={losingIds:int[]}")]
		public async Task<IActionResult> RecordMatch(long[] winningDiscords, long[] losingDiscords) // [240413827718578177,175325337196953600,287275232236929026,...]
		{
			await _repository.RecordMatchAsync(
				await _repository.GetPlayersAsync(winningDiscords),
				await _repository.GetPlayersAsync(losingDiscords)
			);

			return Ok();
		}
	}
}
