using Microsoft.AspNetCore.Mvc;
using QQbot.Api.Services.Interfaces;
using System;
using System.Threading.Tasks;

namespace QQbot.Api.Controllers
{
	[ApiController]
	[Route("api/lobby")]
	public class QueueController : ControllerBase
	{
		private IQueueRepository _repository;

		public QueueController(IQueueRepository repository)
		{
			_repository = repository ?? throw new ArgumentNullException(nameof(repository));
		}

		[HttpGet]
		[Route("clear")]
		public async Task<IActionResult> Clear()
		{
			await _repository.ClearAsync();
			return Ok();
		}
	}
}
