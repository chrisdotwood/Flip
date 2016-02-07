using Flip.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Flip.Tests {
	public class DatabaseContextTests : IClassFixture<DatabaseFixture> {
		private DatabaseFixture _databaseFixture;

		public DatabaseContextTests(DatabaseFixture databaseFixture) {
			_databaseFixture = databaseFixture;
		}

		[Fact]
		public void ContextIsNotNull() {
			Assert.NotNull(_databaseFixture.Context);
		}

		[Fact]
		public void BooksArePresent() {
			Assert.True(_databaseFixture.Context.Books.Count() > 0, "No books in database");
		}

	}
}
