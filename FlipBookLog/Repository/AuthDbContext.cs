using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Flip.Repository {
	public class AuthDbContext : IdentityDbContext<IdentityUser> {
		public AuthDbContext()
			: base("AuthDbContext") {

		}
	}
}