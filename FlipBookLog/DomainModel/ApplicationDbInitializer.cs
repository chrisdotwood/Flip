using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Flip.DomainModel {
	public class ApplicationDbInitializer : DropCreateDatabaseAlways<ApplicationDbContext> {
		protected override void Seed(ApplicationDbContext context) {

		}


	}
}