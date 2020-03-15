using System.Threading.Tasks;

namespace Sample.CQRS
{
	public interface ICommandDispatcher
    {
        Task DispatchAsync<T>(T command) where T : ICommand;
    }
}
