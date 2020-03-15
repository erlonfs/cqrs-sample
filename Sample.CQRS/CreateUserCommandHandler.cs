using System;
using System.Threading.Tasks;

namespace Sample.CQRS
{
	public class CreateUserCommandHandler : ICommandHandler<CreateUserCommand>
	{
		public Task HandleAsync(CreateUserCommand command)
		{
			return Task.CompletedTask;
		}
	}
}
