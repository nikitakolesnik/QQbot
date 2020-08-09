using Microsoft.AspNetCore.Mvc;
using QQbot.Repositories;
using System;
using System.Threading.Tasks;

namespace QQbot.Api.Controllers
{
	[ApiController]
	[Route("api/lobby")]
	public class LobbyController : ControllerBase
	{
		private readonly ILobbyRepository _repository;

		public LobbyController(ILobbyRepository repository)
		{
			_repository = repository ?? throw new ArgumentNullException(nameof(repository));
		}

		/*
		 * Add player 123 to lobby                          - api/lobby/id/123               POST
		 * Add player with discord 2222222222 to lobby      - api/lobby/discord/2222222222   POST
		 * Set player 123 to team 2                         - api/lobby/123/2                PUT
		 * Remove player 123 from lobby                     - api/lobby/id/123               DEL
		 * Remove player with discord 2222222222 from lobby - api/lobby/discord/2222222222   DEL
		 * Clear team 2                                     - api/lobby/2                    DEL
		 * Clear lobby                                      - api/lobby                      DEL
		 */

		[HttpPost]
		[Route("id/{id:int}")]
		public async Task<IActionResult> AddPlayerById(int id)
		{
			try
			{
				await _repository.AddPlayerByIdAsync(id);
			}
			catch (InvalidOperationException ex)
			{
				return BadRequest("Player with ID " + id + " not found | " + ex.Message);
			}
			catch (ArgumentNullException ex)
			{
				return BadRequest(ex.Message);
			}

			return Ok();
		}

		[HttpPost]
		[Route("discord/{discordId:long}")]
		public async Task<IActionResult> AddPlayerByDiscordId(long discordId)
		{
			try
			{
				await _repository.AddPlayerByDiscordIdAsync(discordId);
			}
			catch (InvalidOperationException ex)
			{
				return BadRequest("Player with Discord ID " + discordId + " not found | " + ex.Message);
			}
			catch (ArgumentNullException ex)
			{
				return BadRequest(ex.Message);
			}

			return Ok();
		}

		[HttpPut]
		[Route("{id:int}/{team:int}")]
		public async Task<IActionResult> SetTeam(int id, int team)
		{
			try
			{
				await _repository.SetTeamByIdAsync(id, team);
			}
			catch (InvalidOperationException ex)
			{
				return BadRequest("Player with ID " + id + " not found | " + ex.Message);
			}
			catch (ArgumentNullException ex)
			{
				return BadRequest(ex.Message);
			}
			catch (ArgumentException ex)
			{
				return BadRequest("Team argument must be 0, 1, or 2 | " + ex.Message);
			}

			return Ok();
		}

		[HttpDelete]
		[Route("id/{id:int}")]
		public async Task<IActionResult> KickPlayerByIdAsync(int id)
		{
			try
			{
				await _repository.KickPlayerByIdAsync(id);
			}
			catch (InvalidOperationException ex)
			{
				return BadRequest("Player with ID " + id + " not found | " + ex.Message);
			}
			catch (ArgumentNullException ex)
			{
				return BadRequest(ex.Message);
			}

			return Ok();
		}

		[HttpDelete]
		[Route("discord/{discordId:long}")]
		public async Task<IActionResult> KickPlayerByDiscordIdAsync(long discordId)
		{
			try
			{
				await _repository.KickPlayerByDiscordIdAsync(discordId);
			}
			catch (InvalidOperationException ex)
			{
				return BadRequest("Player with Discord ID " + discordId + " not found | " + ex.Message);
			}
			catch (ArgumentNullException ex)
			{
				return BadRequest(ex.Message);
			}

			return Ok();
		}

		[HttpDelete]
		[Route("{team:int}")]
		public async Task<IActionResult> ClearTeam(int team)
		{
			try
			{
				await _repository.ClearTeamAsync(team);
			}
			catch (ArgumentNullException ex)
			{
				return BadRequest(ex.Message);
			}
			catch (ArgumentException ex)
			{
				return BadRequest("Team argument must be 0, 1, or 2 | " + ex.Message);
			}

			return Ok();
		}

		[HttpDelete]
		public async Task<IActionResult> ClearLobby()
		{
			try
			{
				await _repository.ClearAllAsync();
			}
			catch (Exception ex)
			{
				return StatusCode(500, ex.Message);
			}

			return Ok();
		}
	}
}
