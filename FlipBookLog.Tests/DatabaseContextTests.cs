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

		[Fact]
		public void DeleteOfReadingLogCascades() {
			int readingLogCount = _databaseFixture.Context.ReadingLogs.Count();
			int bookCount = _databaseFixture.Context.Books.Count();

            Assert.True(readingLogCount > 0, "No reading logs in database");
			Assert.True(bookCount > 0, "No books in database");

			// Check that the first log actually has some books associated with it
			Assert.True(_databaseFixture.Context.ReadingLogs.First().Books.Count() > 0);

			// Remove the reading log. This should remove the record of the books that are associated with it too.
			_databaseFixture.Context.ReadingLogs.Remove(_databaseFixture.Context.ReadingLogs.First());

			// Persist the changes to the database
			_databaseFixture.Context.SaveChanges();

			// Check that the log and associated books are now gone
			Assert.Equal(readingLogCount - 1, _databaseFixture.Context.ReadingLogs.Count());
			Assert.True(_databaseFixture.Context.Books.Count() < bookCount);
		}

		[Fact]
		public void CanDetermineReadingLogFromBook() {
			Assert.NotNull(_databaseFixture.Context.Books.First().ReadingLog);
		}
	}
}
