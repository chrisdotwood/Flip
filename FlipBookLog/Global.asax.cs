using Flip.DomainModel;
using Ninject;
using Ninject.Modules;
using System.Data.Entity;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System;
using Flip.Controllers;

namespace Flip {
	public class MvcApplication : HttpApplication {
		protected void Application_Start() {

			

			Database.SetInitializer(new ApplicationDbInitializer());

			AreaRegistration.RegisterAllAreas();
			GlobalConfiguration.Configure(WebApiConfig.Register);
			FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
			RouteConfig.RegisterRoutes(RouteTable.Routes);
			BundleConfig.RegisterBundles(BundleTable.Bundles);

			var kernel = new StandardKernel(new FlipNinjectModule());

			ControllerBuilder.Current.SetControllerFactory(new ControllerFactory(kernel));
		}
	}

	public class FlipNinjectModule : NinjectModule {
		public override void Load() {
		}
	}
}
