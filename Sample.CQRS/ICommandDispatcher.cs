using System.Threading.Tasks;

namespace Sample.CQRS
{
	public interface ICommandDispatcher
    {
        Task DispatchAsync<T>(T command) where T : ICommand;
        Task<TResult> DispatchAsync<T, TResult>(T command) where T : ICommand;
    }
}
