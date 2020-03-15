using Autofac;
using Autofac.Integration.Mvc;
using Sample.CQRS.MVC.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Sample.CQRS.MVC
{
	public class MvcApplication : System.Web.HttpApplication
	{
		protected void Application_Start()
		{
			var builder = new ContainerBuilder();

			builder.RegisterControllers(typeof(HomeController).Assembly);

			builder.RegisterType<CommandDispatcher>().As<ICommandDispatcher>();
			builder.RegisterType<QueryExecutor>().As<IQueryExecutor>();

			builder.RegisterAssemblyTypes(typeof(Tuc).Assembly)
										.AsClosedTypesOf(typeof(ICommandHandler<>))
										.AsImplementedInterfaces();

			builder.RegisterAssemblyTypes(typeof(Tuc).Assembly)
										.AsClosedTypesOf(typeof(IQueryHandler<,>))
										.AsImplementedInterfaces();

			var container = builder.Build();
			DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

			AreaRegistration.RegisterAllAreas();
			FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
			RouteConfig.RegisterRoutes(RouteTable.Routes);
			BundleConfig.RegisterBundles(BundleTable.Bundles);
		}
	}
}
