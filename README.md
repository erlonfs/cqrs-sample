# Command Query Responsibility Segregation
Projeto de exemplo do pattern CQRS

```cs
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Sample.CQRS.MVC.Controllers
{
	public class HomeController : Controller
	{
		private readonly ICommandDispatcher _commandDispatcher;
		private readonly IQueryExecutor _queryExecutor;

		public HomeController(ICommandDispatcher commandDispatcher,
							  IQueryExecutor queryExecutor)
		{
			_commandDispatcher = commandDispatcher;
			_queryExecutor = queryExecutor;
		}

		public async Task<ActionResult> Index()
		{
			var command = new CreateUserCommand("erlon.souza", "MyStrong(!)Pass");
			await _commandDispatcher.DispatchAsync(command);

			var query = new GetUserQuery("erlon.souza", "yourStrong(!)PassWord");
			var result = await _queryExecutor.ExecuteAsync<GetUserQuery, UserDto>(query);

			return Json(result, JsonRequestBehavior.AllowGet);
		}
	}
}
```


Resultado

```js
// 20200315181542
// http://localhost:55860/
{
  "Name": "erlon.souza",
  "Password": "yourStrong(!)PassWord"
}
```
