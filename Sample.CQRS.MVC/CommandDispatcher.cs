using Autofac;
using System;
using System.Threading.Tasks;

namespace Sample.CQRS.MVC
{
	public class CommandDispatcher : ICommandDispatcher
	{
		private readonly IComponentContext _context;

		public CommandDispatcher(IComponentContext context)
		{
			_context = context;
		}

		public Task DispatchAsync<T>(T command) where T : ICommand
		{
			if (command == null)
			{
				throw new ArgumentNullException(nameof(command), "Command can not be null.");
			}

			var handler = _context.Resolve<ICommandHandler<T>>();

			handler.HandleAsync(command);

			return Task.FromResult<object>(null);
		}

		public Task<TResult> DispatchAsync<T, TResult>(T command) where T : ICommand
		{
			if (command == null)
			{
				throw new ArgumentNullException(nameof(command), "Command can not be null.");
			}

			var handler = _context.Resolve<ICommandHandler<T, TResult>>();

			var result = handler.HandleAsync(command);

			return Task.FromResult(result);

		}
	}
}