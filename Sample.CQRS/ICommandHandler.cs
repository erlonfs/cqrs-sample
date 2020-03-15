using System.Threading.Tasks;

namespace Sample.CQRS
{
	public interface ICommandHandler<in T> where T : ICommand
    {
        Task HandleAsync(T command);
    }
}
