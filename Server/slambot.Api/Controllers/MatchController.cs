using Microsoft.AspNetCore.Mvc;
using slambot.Common.Configuration;
using slambot.Common.Enums;
using slambot.Services;
using slambot.Services.Models;
using System;
using System.Threading.Tasks;

namespace slambot.Api.Controllers
{
	[ApiController]
	[Route("api/match")]
	public class MatchController : ControllerBase
	{
		private readonly IMatchRepository _matchRepository;

		public MatchController(IMatchRepository matchRepository)
		{
			_matchRepository = matchRepository ?? throw new ArgumentNullException(nameof(matchRepository));
		}

		/*
		 * Who played in match 45                          - GET  api/match/45
		 * Edit match 45                                   - PUT  api/match/45
		 * Activate/disable match 45                       - PUT  api/match/45/action/1
		 * Get 10 last active matches                      - GET  api/match/history/10 
		 * Get 10 last active matches involving player 123 - GET  api/match/id/123/history/10
		 * Submit win for Team 1                           - POST api/match/1
		 */

		[HttpGet]
		[Route("{id:int}")]
		public async Task<IActionResult> Details(int id)
		{
			try
			{
				return Ok(await _matchRepository.DetailsAsync(id));
			}
			catch (Exception ex)
			{
				return BadRequest(ex.ToString());
			}
		}

		[HttpPut]
		[Route("{id:int}")]
		public async Task<IActionResult> Edit([FromRoute] int id, [FromBody] TeamRequestBody team)
		{
			try
			{
				return Ok(await _matchRepository.EditAsync(id, team.WinningTeam, team.Team1, team.Team2));
			}
			catch (Exception ex)
			{
				return BadRequest(ex.ToString());
			}
		}

		[HttpPut]
		[Route("{id:int}/action/{actionId:int}")]
		public async Task<IActionResult> AdminAction([FromRoute] int id, [FromRoute] int actionId)
		{
			try
			{
				return Ok(await _matchRepository.ActionAsync(id, (Status)actionId));
			}
			catch (Exception ex)
			{
				return BadRequest(ex.ToString());
			}
		}

		[HttpGet]
		[Route("history/{results?}")]
		public async Task<IActionResult> History([FromRoute] int results = MatchConfiguration.DefaultMatchesToShow)
		{
			try
			{
				return Ok(await _matchRepository.HistoryAsync(results));
			}
			catch (Exception ex)
			{
				return BadRequest(ex.ToString());
			}
		}

		[HttpGet]
		[Route("id/{id:int}/history/{results?}")]
		public async Task<IActionResult> PlayerHistory([FromRoute] int id, [FromRoute] int results)
		{
			try
			{
				return Ok(await _matchRepository.HistoryAsync(results, id));
			}
			catch (Exception ex)
			{
				return BadRequest(ex.ToString());
			}
		}

		[HttpPost]
		[Route("{winningTeam:int}")]
		public async Task<IActionResult> Submit([FromRoute] int winningTeam)
		{
			try
			{
				return Ok(await _matchRepository.RecordAsync((TeamNumber)winningTeam));
			}
			catch (Exception ex)
			{
				return BadRequest(ex.ToString());
			}
		}
	}
}
