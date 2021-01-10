using System.Threading;

namespace Sample.CQRS
{
	public class GetUserQueryHandler : IQueryHandler<GetUserQuery, UserDto>
	{
		public UserDto ExecuteAsync(GetUserQuery query)
		{
			Thread.Sleep(1000);

			return new UserDto { Name = query.Name, Password = query.Password };
		}
	}
}
