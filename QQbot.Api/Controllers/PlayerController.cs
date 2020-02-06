using Microsoft.AspNetCore.Mvc;
using QQbot.Api.Entities;
using QQbot.Api.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QQbot.Api.Controllers
{
	[ApiController]
	[Route("/api/players")]
	public class PlayerController : ControllerBase
	{
		private readonly IPlayerRepository _playerRepository;

		public PlayerController(IPlayerRepository playerRepository)
		{
			_playerRepository = playerRepository ?? throw new ArgumentNullException(nameof(playerRepository));
		}

		[HttpGet]
		public async Task<ActionResult<IEnumerable<Player>>> GetPlayers()
		{
			var players = await _playerRepository.GetPlayersAsync();

			return Ok(players);
		}

		[HttpGet]
		[Route("{id:int}")]
		public async Task<ActionResult<Player>> GetPlayer(int id)
		{
			var player = await _playerRepository.GetPlayerAsync(id);

			if (player == null)
				return BadRequest($"Player with ID#{id} not found.");

			return Ok(player);
		}
	}
}
