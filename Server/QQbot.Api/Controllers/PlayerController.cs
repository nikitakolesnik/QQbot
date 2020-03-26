using Microsoft.AspNetCore.Mvc;
using QQbot.BusinessLayer;
using QQbot.DataAccessLayer.Entities;
using QQbot.DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QQbot.Api.Controllers
{
	[ApiController]
	[Route("/api/players")]
	public class PlayerController : ControllerBase
	{
		private readonly IPlayerRepository _repository;

		public PlayerController(IPlayerRepository repository)
		{
			_repository = repository ?? throw new ArgumentNullException(nameof(repository));
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
				var players = await _repository.GetLeaderboardAsync();
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
				return BadRequest("Invalid input!");

			try
			{
				Player newPlayer = await _repository.AddPlayerAsync(playerInfo);
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
