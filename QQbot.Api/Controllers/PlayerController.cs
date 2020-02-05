using Microsoft.AspNetCore.Mvc;
using QQbot.Api.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QQbot.Api.Controllers
{
	[ApiController]
	[Route("/api/players")]
	public class PlayerController : ControllerBase
	{
		private ApplicationDbContext _context;

		public PlayerController(ApplicationDbContext context)
		{
			_context = context ?? throw new ArgumentNullException(nameof(context));
		}

		[HttpGet]
		public async Task<IActionResult> Get()
		{
			return Ok("thing");
		}
	}
}
