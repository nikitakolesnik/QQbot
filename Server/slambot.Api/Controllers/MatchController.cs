using Microsoft.AspNetCore.Mvc;
using slambot.Common.Enums;
using slambot.Common.Configuration;
using slambot.Services;
using System;
using System.Threading.Tasks;
using slambot.Services.Models;

namespace slambot.Api.Controllers
{
	[ApiController]
	[Route("api/match")]
	public class MatchController : ControllerBase
	{
		private const int _defaultMatchesToShow = MatchConfiguration.DefaultMatchesToShow;
		private readonly IMatchRepository _matchRepository;
        private readonly IAdminRepository _adminRepository;

        public MatchController(IMatchRepository matchRepository, 
			//IPlayerRepository playerRepository, 
			IAdminRepository adminRepository)
		{
			_matchRepository = matchRepository ?? throw new ArgumentNullException(nameof(matchRepository));
            _adminRepository = adminRepository ?? throw new ArgumentNullException(nameof(adminRepository));
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
				return Ok(await _matchRepository.MatchDetailsAsync(id));
            }
			catch (Exception ex)
            {
				return BadRequest(ex.ToString());
            }
        }

		[HttpPut]
		[Route("{id:int}")]
		public async Task<IActionResult> Edit([FromRoute]int id, [FromBody]TeamRequestBody team)
        {
			try
            {
				return Ok(await _matchRepository.EditMatchAsync(id, team.WinningTeam, team.Team1, team.Team2));
            }
			catch (Exception ex)
            {
				return BadRequest(ex.ToString());
            }
        }

		[HttpPut]
		[Route("{id:int}/action/{actionId:int}")]
		public async Task<IActionResult> AdminAction([FromRoute]int id, [FromRoute]int actionId)
        {
			try
			{
				return Ok(await _matchRepository.ActionMatchAsync(id, (Status)actionId));
			}
			catch (Exception ex)
			{
				return BadRequest(ex.ToString());
			}
        }

		[HttpGet]
		[Route("history/{results:int=MatchConfiguration.DefaultMatchesToShow}")]
		public async Task<IActionResult> History([FromRoute]int results)
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
		[Route("id/{id:int}/history/{results:int=MatchConfiguration.DefaultMatchesToShow}")]
		public async Task<IActionResult> PlayerHistory([FromRoute]int id, [FromRoute] int results)
		{
			try
			{
				return Ok(await _matchRepository.PlayerHistoryAsync(id, results));
			}
			catch (Exception ex)
			{
				return BadRequest(ex.ToString());
			}
		}

		[HttpPost]
		[Route("{winningTeam:int}")]
		public async Task<IActionResult> Submit([FromRoute]int winningTeam)
        {
			try
			{
				return Ok(await _matchRepository.RecordMatchAsync((TeamNumber)winningTeam));
			}
			catch (Exception ex)
			{
				return BadRequest(ex.ToString());
			}
		}
	}
}
