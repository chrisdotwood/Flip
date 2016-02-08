using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Flip.DomainModel;
using System.Data.Entity;

namespace Flip.Repository {
	public class BookRepository : IBookRepository {
		private readonly ApplicationDbContext _context;
		private readonly ApplicationUser _user;

		public BookRepository(ApplicationDbContext context, ApplicationUser user) {
			if (context == null) throw new ArgumentException(nameof(context));
			if (user == null) throw new ArgumentException(nameof(user));

			_context = context;
			_user = user;
		}

		public IEnumerable<Book> GetAllBooks() {
			return _context.Books
				.Include(s => s.ReadingLog)
				.Where(s => s.ReadingLog.User.Id == _user.Id)
				.ToList();
		}
	}
}