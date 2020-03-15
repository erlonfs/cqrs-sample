using System;

namespace Sample.CQRS
{
	public class CreateUserCommand : ICommand
	{
		public string Name { get; }
		public string  Password { get; }

		public CreateUserCommand(string	name, string password)
		{
			if (string.IsNullOrWhiteSpace(name)) throw new ArgumentNullException(nameof(name));
			if (string.IsNullOrWhiteSpace(password)) throw new ArgumentNullException(nameof(password));

			Name = name;
			Password = password;
		}
	}
}
