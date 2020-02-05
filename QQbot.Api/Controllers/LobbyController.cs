using Microsoft.AspNetCore.Mvc;
using QQbot.Api.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QQbot.Api.Controllers
{
	[ApiController]
	[Route("api/lobby")]
	public class LobbyController : ControllerBase
	{
		private ApplicationDbContext _context;

		public LobbyController(ApplicationDbContext context)
		{
			_context = context ?? throw new ArgumentNullException(nameof(context));
		}

		/*
		 Get lobby status

		 Initialize a lobby (inactive to forming)


		 */
	}
}
