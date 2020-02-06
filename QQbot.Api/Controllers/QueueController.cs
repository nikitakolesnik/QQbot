using Microsoft.AspNetCore.Mvc;
using QQbot.Api.Services;
using System;
using System.Threading.Tasks;

namespace QQbot.Api.Controllers
{
	[ApiController]
	[Route("api/lobby")]
	public class QueueController : ControllerBase
	{
		private QueueRepository _repository;

		public QueueController(QueueRepository repository)
		{
			_repository = repository ?? throw new ArgumentNullException(nameof(repository));
		}

		[HttpGet]
		[Route("clear")]
		public async Task<IActionResult> Clear()
		{
			await _repository.Clear();
			return Ok();
		}
	}
}
