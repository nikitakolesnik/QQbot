using Microsoft.AspNetCore.Mvc;
using slambot.Repositories;
using slambot.DataAccess.Entities;
using slambot.Repositories.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

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
		 * Get leaderboard                                      - api/players                  GET
		 * Get full player 123 profile, with 10 past match data - api/players/123/profile(/10) GET
		 * Register player                                      - api/players                  POST
		 * Edit player 123                                      - api/players/123              PUT
		 * Activate/disable player 123                          - api/players/123/action/1     PUT
		 */

		[HttpGet]
		public async Task<ActionResult<IEnumerable<Player>>> Leaderboard()
		{
			try
			{
				var players = await _playerRepository.GetLeaderboardAsync();
				return Ok(players);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		//[HttpGet]
		//[Route("{id:int}/profile/{results:int}")]
		//public async Task<ActionResult<PlayerProfile>> Profile(int id, int results)
		//{
		//	throw new NotImplementedException();
		//}

		[HttpPost]
		public async Task<ActionResult<Player>> RegisterPlayer([FromBody]SubmittedPlayer playerInfo)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest("Invalid input!");
			}

			try
			{
				Player newPlayer = await _playerRepository.AddPlayerAsync(playerInfo);
				return Ok(newPlayer);
			}	
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		//[HttpPut]
		//[Route("{id:int}")]
		//public async Task<ActionResult<Player>> EditPlayer(int id)
		//{
		//	throw new NotImplementedException();
		//}

		//[HttpPut]
		//[Route("{id:int}/action/{action:int}")]
		//public async Task<ActionResult<Player>> ActionPlayer(int id, int action)
		//{
		//	throw new NotImplementedException();
		//}
	}
}
