using Microsoft.AspNetCore.Mvc;
using QQbot.Api.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QQbot.Api.Services.Interfaces
{
	public interface IMatchRepository
	{
		Task<IEnumerable<Player>> GetPlayersAsync(string[] names);
		Task<IActionResult> RecordMatchAsync(List<Player> winningTeam, List<Player> losingTeam);
	}
}
