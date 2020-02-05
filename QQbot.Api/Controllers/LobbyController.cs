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

			Add player to queue by discord ID

			Add player to queue by name

			Remove player from queue

			Decide first pick

			Add captain

			Change captain

			Move player from queue to team

			Move player from team to queue

			Trade a player on each team for each other (potentially consumed by web client)
				- by name/id?

			start match

			end match ("match" entity would be created here)
		*/
	}
}
