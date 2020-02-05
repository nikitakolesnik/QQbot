using QQbot.Api.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QQbot.Api.Services
{
	public interface IPlayerRepository
	{
		Task<Player> GetPlayerAsync(int id);
		Task<IEnumerable<Player>> GetPlayersAsync();
	}
}
