using System;
using System.Threading.Tasks;

namespace Sample.CQRS
{
	public class CreateUserCommandHandler : ICommandHandler<CreateUserCommand>
	{
		public void HandleAsync(CreateUserCommand command)
		{
			
		}
	}
}
