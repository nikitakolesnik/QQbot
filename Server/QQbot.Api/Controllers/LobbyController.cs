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
		 * Set player 123 to team 2                         - api/lobby/id/123/team/2        PUT
		 * Remove player 123 from lobby                     - api/lobby/id/123               DEL
		 * Remove player with discord 2222222222 from lobby - api/lobby/discord/2222222222   DEL
		 * Clear team 2                                     - api/lobby/team/2               DEL
		 * Clear lobby                                      - api/lobby                      DEL
		 */

		[HttpGet]
		public async Task<object> GetLobby()
        {
			try
            {
				return Ok(await _repository.GetLobby());
            }
			catch(Exception ex)
			{
				return BadRequest(ex.ToString());
			}
        }

		[HttpPost]
		[Route("id/{id:int}")]
		public async Task<IActionResult> AddPlayerById(int id)
		{
			try
			{
				await _repository.AddPlayerByIdAsync(id);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.ToString());
			}

			return Ok(await _repository.GetLobby());
		}

		[HttpPost]
		[Route("discord/{discordId:long}")]
		public async Task<IActionResult> AddPlayerByDiscordId(long discordId)
		{
            try
			{
				await _repository.AddPlayerByDiscordIdAsync(discordId);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.ToString());
			}

			return Ok(await _repository.GetLobby());
		}

		[HttpPut]
		[Route("id/{id:int}/team/{team:int}")]
		public async Task<IActionResult> SetTeam(int id, int team)
		{
			try
			{
				await _repository.SetTeamByIdAsync(id, team);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.ToString());
			}

			return Ok(await _repository.GetLobby());
		}

		[HttpDelete]
		[Route("id/{id:int}")]
		public async Task<IActionResult> KickPlayerByIdAsync(int id)
		{
			try
			{
				await _repository.KickPlayerByIdAsync(id);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.ToString());
			}

			return Ok(await _repository.GetLobby());
		}

		[HttpDelete]
		[Route("discord/{discordId:long}")]
		public async Task<IActionResult> KickPlayerByDiscordIdAsync(long discordId)
		{
			try
			{
				await _repository.KickPlayerByDiscordIdAsync(discordId);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.ToString());
			}

			return Ok(await _repository.GetLobby());
		}

		[HttpDelete]
		[Route("team/{team:int}")]
		public async Task<IActionResult> ClearTeam(int team)
		{
			try
			{
				await _repository.ClearTeamAsync(team);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.ToString());
			}

			return Ok(await _repository.GetLobby());
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

			return Ok(await _repository.GetLobby());
		}
	}
}
