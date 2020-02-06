using Microsoft.AspNetCore.Mvc;
using QQbot.Api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QQbot.Api.Services.Interfaces
{
	public interface IMatchRepository
	{
		//Task<IEnumerable<PlayerCompact>> GetPlayerInfoAsync(string[] names);
		Task<IActionResult> RecordMatchAsync(string[] winningTeam, string[] losingTeam);
	}
}
