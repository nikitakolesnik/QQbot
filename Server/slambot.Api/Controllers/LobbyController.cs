using Microsoft.AspNetCore.Mvc;
using slambot.Services;
using System;
using System.Threading.Tasks;

namespace slambot.Api.Controllers
{
	[ApiController]
	[Route("api/lobby")]
	public class LobbyController : ControllerBase
	{
		private readonly ILobbyRepository _lobbyRepository;

		public LobbyController(ILobbyRepository repository)
		{
			_lobbyRepository = repository ?? throw new ArgumentNullException(nameof(repository));
		}

		/*
		 * Add player 123 to lobby      - POST api/lobby/id/123        
		 * Set player 123 to team 2     - PUT  api/lobby/id/123/team/2 
		 * Remove player 123 from lobby - DEL  api/lobby/id/123        
		 * Clear team 2                 - DEL  api/lobby/team/2        
		 * Clear lobby                  - DEL  api/lobby               
		 */

		[HttpGet]
		public async Task<IActionResult> GetLobby()
		{
			try
			{
				return Ok(await _lobbyRepository.GetLobby());
			}
			catch (Exception ex)
			{
				return BadRequest(ex.ToString());
			}
		}

		[HttpPost]
		[Route("id/{id:int}")]
		public async Task<IActionResult> AddPlayer(int id)
		{
			try
			{
				await _lobbyRepository.AddPlayerAsync(id);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.ToString());
			}

			return Ok(await _lobbyRepository.GetLobby());
		}

		[HttpPut]
		[Route("id/{id:int}/team/{team:int}")]
		public async Task<IActionResult> SetTeam(int id, int team)
		{
			try
			{
				await _lobbyRepository.SetTeamAsync(id, team);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.ToString());
			}

			return Ok(await _lobbyRepository.GetLobby());
		}

		[HttpDelete]
		[Route("id/{id:int}")]
		public async Task<IActionResult> Kick(int id)
		{
			try
			{
				await _lobbyRepository.KickPlayerAsync(id);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.ToString());
			}

			return Ok(await _lobbyRepository.GetLobby());
		}

		[HttpDelete]
		[Route("team/{team:int}")]
		public async Task<IActionResult> ClearTeam(int team)
		{
			try
			{
				await _lobbyRepository.ClearTeamAsync(team);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.ToString());
			}

			return Ok(await _lobbyRepository.GetLobby());
		}

		[HttpDelete]
		public async Task<IActionResult> ClearLobby()
		{
			try
			{
				await _lobbyRepository.ClearLobbyAsync();
			}
			catch (Exception ex)
			{
				return StatusCode(500, ex.Message);
			}

			return Ok(await _lobbyRepository.GetLobby());
		}
	}
}
