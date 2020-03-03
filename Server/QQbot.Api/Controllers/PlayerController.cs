using Microsoft.AspNetCore.Mvc;
using QQbot.BusinessLayer;
using QQbot.DataAccessLayer;
using QQbot.DataAccessLayer.Entities;
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
		 * Get player 123 summary                               - api/players/123              GET
		 * Get full player 123 profile, with 10 past match data - api/players/123/profile(/10) GET
		 * Submit a player                                      - api/players                  POST
		 * Edit player 123                                      - api/players/123              PUT
		 * Activate/disable player 123                          - api/players/123/action/1     PUT
		 */

		[HttpGet]
		public async Task<ActionResult<IEnumerable<Player>>> GetPlayers()
		{
			var players = await _repository.GetLeaderboardAsync();

			return Ok(players);
		}

		[HttpGet]
		[Route("{id:int}")]
		public async Task<ActionResult<Player>> GetPlayer(int id)
		{
			var player = await _repository.GetPlayerByIdAsync(id);

			if (player == null)
				return BadRequest($"Player with ID#{id} not found.");

			return Ok(player);
		}
	}
}
