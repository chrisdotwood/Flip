using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Flip.DomainModel {
	public class ApplicationDbContext : IdentityDbContext<ApplicationUser> {
		public ApplicationDbContext()
			: base("DefaultConnection", throwIfV1Schema: false) {
		}

		protected override void OnModelCreating(DbModelBuilder modelBuilder) {
			// We need to call the base method to configure the Asp.net authentication
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<Book>()
				.HasKey(s => s.Id);

			modelBuilder.Entity<ReadingLog>()
				.HasKey(s => s.Id);
		}

		public static ApplicationDbContext Create() {
			return new ApplicationDbContext();
		}

		public DbSet<Book> Books { get; set; }

		public DbSet<ReadingLog> ReadingLogs { get; set; }
	}
}