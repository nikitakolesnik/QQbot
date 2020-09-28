using Microsoft.AspNetCore.Mvc;
using slambot.Services;
using slambot.DataAccess.Entities;
using slambot.Services.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using slambot.Common.Enums;

namespace slambot.Api.Controllers
{
	[ApiController]
	[Route("/api/players")]
	public class PlayerController : ControllerBase
	{
		private readonly IAdminRepository _adminRepository;
		private readonly IPlayerRepository _playerRepository;

		public PlayerController(IAdminRepository adminRepository, IPlayerRepository playerRepository)
		{
			_adminRepository = adminRepository ?? throw new ArgumentNullException(nameof(adminRepository));
			_playerRepository = playerRepository ?? throw new ArgumentNullException(nameof(playerRepository));
		}

        /*
		 * Get leaderboard               - GET  api/players
		 * Get player 123 profile        - GET  api/players/123
		 * Get player 123 name & discord - GET  api/players/123/short
		 * Register player               - POST api/players
		 * Edit player 123               - PUT  api/players/123
		 * Activate/disable player 123   - PUT  api/players/123/actionId/1
		 */

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Player>>> Leaderboard()
        {
            try
            {
                return Ok(await _playerRepository.LeaderboardAsync());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<PlayerProfile>> Profile(int id)
        {
            try
            {
                return Ok(await _playerRepository.ProfileAsync(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpGet]
        [Route("{id:int}/short")]
        public async Task<ActionResult<PlayerProfile>> PlayerNameDiscord(int id)
        {
            try
            {
                return Ok(await _playerRepository.PlayerNameDiscordAsync(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPost]
        public async Task<ActionResult<Player>> Register([FromBody] SubmittedPlayer playerData)
        {
            try
            {
                return Ok(await _playerRepository.AddPlayerAsync(playerData));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<ActionResult<Player>> Edit(int id, [FromBody]SubmittedPlayer playerData)
        {
            try
            {
                return Ok(await _playerRepository.EditPlayerAsync(id, playerData));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        // routing error below

        [HttpPut]
        [Route("{id:int}/action/{actionId:int}")]
        public async Task<ActionResult<Player>> AdminAction(int id, int actionId /* naming this "action" creates a routing error lol */)
        {
            try
            {
                //if (!Enum.IsDefined(typeof(Status), actionId)) { throw new ArgumentException(ExceptionMessage.InvalidActionId); }

                return Ok(await _playerRepository.ActionPlayerAsync(id, (Status)actionId));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}
