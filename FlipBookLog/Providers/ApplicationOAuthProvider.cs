using System;
using System.Threading.Tasks;
using Microsoft.Owin.Security.OAuth;
using Flip.Repository;
using System.Security.Claims;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Flip.Providers {
	public class ApplicationOAuthProvider : OAuthAuthorizationServerProvider {
		//private readonly string _publicClientId;
		private readonly ApplicationDbContext _repository;

		// TODO Make this into an interface resolved via DI
		public ApplicationOAuthProvider() {
			_repository = new ApplicationDbContext();
		}

		//public override Task ValidateClientRedirectUri(OAuthValidateClientRedirectUriContext context) {
		//	if (context.ClientId == _publicClientId) {
		//		Uri expectedRootUri = new Uri(context.Request.Uri, "/");

		//		if (expectedRootUri.AbsoluteUri == context.RedirectUri) {
		//			context.Validated();
		//		} else if (context.ClientId == "web") {
		//			var expectedUri = new Uri(context.Request.Uri, "/");
		//			context.Validated(expectedUri.AbsoluteUri);
		//		}
		//	}

		//	return Task.FromResult<object>(null);
		//}

		public override Task ValidateAuthorizeRequest(OAuthValidateAuthorizeRequestContext context) {
			return base.ValidateAuthorizeRequest(context);
		}

		public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context) {
			context.Validated();

			return Task.FromResult<object>(null);
		}

		public async override Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context) {

			context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });

			// TODO Check username and password against database. Investigate possible async repo. Step 6 from http://bitoftech.net/2014/06/01/token-based-authentication-asp-net-web-api-2-owin-asp-net-identity/

			using (AuthRepository _repo = new AuthRepository()) {
				IdentityUser user = await _repo.FindUser(context.UserName, context.Password);

				if (user == null) {
					context.SetError("invalid_grant", "The user name or password is incorrect.");
					return;
				}
			}

			var identity = new ClaimsIdentity(context.Options.AuthenticationType);
			identity.AddClaim(new Claim("sub", context.UserName));
			identity.AddClaim(new Claim("role", "user"));

			context.Validated(identity);
			
			return;
		}
	}
}