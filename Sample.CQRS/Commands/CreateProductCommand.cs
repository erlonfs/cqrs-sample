using System;

namespace Sample.CQRS
{
	public class CreateProductCommand : ICommandWithResult<int>
	{
		public string Name { get; }
		public string Password { get; }

		public CreateProductCommand(string name, string password)
		{
			if (string.IsNullOrWhiteSpace(name)) throw new ArgumentNullException(nameof(name));
			if (string.IsNullOrWhiteSpace(password)) throw new ArgumentNullException(nameof(password));

			Name = name;
			Password = password;
		}
	}
}
