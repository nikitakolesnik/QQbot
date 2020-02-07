using Microsoft.AspNetCore.Mvc;
using QQbot.Api.Entities;
using QQbot.Api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QQbot.Api.Services.Interfaces
{
	public interface IMatchRepository
	{
		Task<IEnumerable<Player>> GetPlayerInfoAsync(string[] names);
		Task<IEnumerable<Player>> GetPlayerInfoAsync(string names);
		Task<IEnumerable<Player>> GetPlayerInfoAsync(int[] ids);
		Task<int> RecordMatchAsync(IEnumerable<Player> winningTeam, IEnumerable<Player> losingTeam);
	}
}
