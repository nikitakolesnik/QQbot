using Microsoft.AspNetCore.Mvc;
using QQbot.BusinessLayer;
using QQbot.DataAccessLayer;
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

		[HttpGet]
		public async Task<ActionResult<IEnumerable<Player>>> GetPlayers()
		{
			var players = await _repository.GetAllPlayersAsync();

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
