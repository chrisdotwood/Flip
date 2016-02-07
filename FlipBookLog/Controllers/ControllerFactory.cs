using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Ninject;

namespace Flip.Controllers {
	/// <summary>
	/// Subclass of the DefaultControllerFactory that resolves the controller with Ninject
	/// </summary>
	public class ControllerFactory : DefaultControllerFactory {
		private StandardKernel _kernel;

		public ControllerFactory(StandardKernel kernel) {
			this._kernel = kernel;
		}

		protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType) {
			if(controllerType == null) {
				return base.GetControllerInstance(requestContext, controllerType);
			}

			return _kernel.Get(controllerType) as IController;
		}
	}
}