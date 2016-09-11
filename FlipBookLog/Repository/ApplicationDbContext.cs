using Flip.DomainModel;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace Flip.Repository {
	public class ApplicationDbContext : IdentityDbContext<ApplicationUser> {
		public ApplicationDbContext()
			: base("TestConnection", throwIfV1Schema: false) {

			Database.Log = message => Debug.WriteLine(message);
		}

		public ApplicationDbContext(string nameOrConnectionString)
			: base(nameOrConnectionString, throwIfV1Schema: false) {
		}

		public static ApplicationDbContext Create() {
			return new ApplicationDbContext();
		}

		protected override void OnModelCreating(DbModelBuilder modelBuilder) {
			// We need to call the base method to configure the Asp.net authentication related schema
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<Book>()
				.HasKey(s => s.Id);

			modelBuilder.Entity<ReadingLog>()
				.HasKey(s => s.Id)
				.HasMany(s => s.Books)
				.WithOptional(s => s.ReadingLog)
				.WillCascadeOnDelete(true);
		}

		public DbSet<Book> Books { get; set; }

		public DbSet<ReadingLog> ReadingLogs { get; set; }
	}
}