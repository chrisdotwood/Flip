using Flip.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Flip.Repository {
	public interface IBookRepository {
		/// <summary>
		/// Get all of the books that are associated with the current user
		/// </summary>
		IEnumerable<Book> GetAllBooks();
	}
}