using System.Threading.Tasks;

namespace QQbot.BusinessLayer
{
	public interface IQueueRepository
	{
		Task<int> ClearAsync();
	}
}
