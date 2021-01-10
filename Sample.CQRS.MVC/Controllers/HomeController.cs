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

			var commandWithResult = new CreateProductCommand("erlon.souza", "MyStrong(!)Pass");
			var commandResult = await _commandDispatcher.DispatchAsync<CreateProductCommand, string>(commandWithResult);

			return Json(new { result, commandResult }, JsonRequestBehavior.AllowGet);
		}
	}
}