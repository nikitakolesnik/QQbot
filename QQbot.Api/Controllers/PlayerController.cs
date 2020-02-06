using Microsoft.AspNetCore.Mvc;
using QQbot.Api.Models.Entities;
using QQbot.Api.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QQbot.Api.Controllers
{
	[ApiController]
	[Route("/api/players")]
	public class PlayerController : ControllerBase
	{
		private readonly PlayerRepository _playerRepository;

		public PlayerController(PlayerRepository playerRepository)
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
			Player player = await _playerRepository.GetPlayerAsync(id);

			if (player == null)
				return BadRequest($"Player with ID#{id} not found.");

			return Ok(player);
		}
	}
}
