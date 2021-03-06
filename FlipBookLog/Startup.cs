﻿using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Owin;
using Owin;
using System.Web.Http;
using Microsoft.Owin.Security.OAuth;
using Flip.Providers;

[assembly: OwinStartup(typeof(Flip.Startup))]

namespace Flip {
	public partial class Startup {
		public void Configuration(IAppBuilder app) {
			ConfigureOAuth(app);

			HttpConfiguration config = new HttpConfiguration();

			WebApiConfig.Register(config);
			app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
			app.UseWebApi(config);

		}

		public void ConfigureOAuth(IAppBuilder app) {
			OAuthAuthorizationServerOptions OAuthServerOptions = new OAuthAuthorizationServerOptions() {
				AllowInsecureHttp = true,
				TokenEndpointPath = new PathString("/token"),
				AccessTokenExpireTimeSpan = TimeSpan.FromDays(1),
				Provider = new ApplicationOAuthProvider()
			};

			// Token Generation
			app.UseOAuthAuthorizationServer(OAuthServerOptions);
			app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());

		}
	}
}
