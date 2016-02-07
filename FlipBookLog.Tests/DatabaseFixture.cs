using Flip.DomainModel;
using Flip.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flip.Tests {
	public class DatabaseFixture {
		private ApplicationDbContext _context;

		public DatabaseFixture() {
			_context = new ApplicationDbContext();

			Database.SetInitializer(new ApplicationDbInitializer());
		}

		public ApplicationDbContext Context {
			get {
				return _context;
			}
		}
	}
}
