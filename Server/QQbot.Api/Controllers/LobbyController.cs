using Microsoft.AspNetCore.Mvc;
using QQbot.BusinessLayer;
using System;
using System.Threading.Tasks;

namespace QQbot.Api.Controllers
{
	[ApiController]
	[Route("api/lobby")]
	public class LobbyController : ControllerBase
	{
		private readonly IQueueRepository _repository;

		public LobbyController(IQueueRepository repository)
		{
			_repository = repository ?? throw new ArgumentNullException(nameof(repository));
		}
		/*
		 * Add player 123 to lobby      - api/lobby       POST
		 * Set player 123 to team 2     - api/lobby/123/2 PUT 
		 * Remove player 123 from lobby - api/lobby/123   DEL
		 * Clear lobby                  - api/lobby       DEL
		 */

		[HttpDelete]
		public async Task<IActionResult> Clear()
		{
			await _repository.ClearAsync();
			return Ok();
		}
	}
}
