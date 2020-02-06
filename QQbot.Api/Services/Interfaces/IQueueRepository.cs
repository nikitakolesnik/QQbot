using System.Threading.Tasks;

namespace QQbot.Api.Services
{
	public interface IQueueRepository
	{
		Task<int> ClearAsync();
	}
}
