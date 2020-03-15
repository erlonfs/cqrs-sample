namespace Sample.CQRS
{
	public class GetUserQuery : IQuery<UserDto>
	{
		public string Name { get; }
		public string Password { get; }

		public GetUserQuery(string name, string password)
		{
			Name = name;
			Password = password;
		}
	}

	public class UserDto
	{
		public string Name { get; set; }
		public string Password { get; set; }
	}
}
