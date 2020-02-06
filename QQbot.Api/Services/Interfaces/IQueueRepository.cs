using System.Threading.Tasks;

namespace QQbot.Api.Services.Interfaces
{
	public interface IQueueRepository
	{
		Task<int> ClearAsync();
	}
}
