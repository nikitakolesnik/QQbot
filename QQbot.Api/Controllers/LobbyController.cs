using Microsoft.AspNetCore.Mvc;
using QQbot.Api.Services.Interfaces;
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

		//TODO: add player to queue by name/id/discord

		//TODO: remove player from queue by name/id/discord

		//TODO: set queued player's team by name/id/discord

		[HttpGet]
		[Route("clear")]
		public async Task<IActionResult> Clear()
		{
			await _repository.ClearAsync();
			return Ok();
		}
	}
}
