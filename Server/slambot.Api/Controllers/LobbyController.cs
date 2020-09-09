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
		private readonly ILobbyRepository _repository;

		public LobbyController(ILobbyRepository repository)
		{
			_repository = repository ?? throw new ArgumentNullException(nameof(repository));
		}

		/*
		 * Add player 123 to lobby      - POST api/lobby/id/123        
		 * Set player 123 to team 2     - PUT  api/lobby/id/123/team/2 
		 * Remove player 123 from lobby - DEL  api/lobby/id/123        
		 * Clear team 2                 - DEL  api/lobby/team/2        
		 * Clear lobby                  - DEL  api/lobby               
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
				await _repository.AddPlayerAsync(id);
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
				await _repository.SetTeamAsync(id, team);
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
				await _repository.KickPlayerAsync(id);
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
				await _repository.ClearLobbyAsync();
			}
			catch (Exception ex)
			{
				return StatusCode(500, ex.Message);
			}

			return Ok(await _repository.GetLobby());
		}
	}
}
