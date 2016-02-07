using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Flip.DomainModel {
	public class ApplicationDbInitializer : DropCreateDatabaseAlways<ApplicationDbContext> {
		protected override void Seed(ApplicationDbContext context) {
			// Create some test users

			// Create them via the user manager rather than adding them directly to handle
			// the security stamp and hashing
			var manager = HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();

			var user1 = new ApplicationUser {
				UserName = "test1@user.com",
				Email = "test1@user.com"
			};

			var user2 = new ApplicationUser {
				UserName = "test2@user.com",
				Email = "test2@user.com"
			};

			manager.Create(user1, "Password@123");
			manager.Create(user2, "Password@345");

			// Create a reading log for user1

			var user1Books = new List<Book> {
				new Book() {
					Author = "John Somnez",
					Title = "Soft Skills",
					DateCompleted = null,
					Media = BookMedia.Paper,
					Status = BookStatus.Future
				},
				new Book() {
					Author = "James Joyce",
					Title = "Ulysses",
					DateCompleted = new DateTime(2016, 7, 2),
					Status = BookStatus.Abandoned,
					Media = BookMedia.Audio
				},
				new Book() {
					Author = "Charles Dickens",
					Title = "The Old Curiosity Shop",
					DateCompleted = new DateTime(2016, 2, 2),
					Status = BookStatus.Finished,
					Media = BookMedia.Ebook
				}
			};

			var user1Log = new ReadingLog() {
				User = user1,
				Name = "User 1's reading log",
				Books = user1Books
			};

			context.ReadingLogs.Add(user1Log);
		}
	}
}