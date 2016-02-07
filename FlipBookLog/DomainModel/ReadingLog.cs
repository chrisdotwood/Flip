using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Flip.DomainModel {
	/// <summary>
	/// A log of books associated with a user
	/// </summary>
	public class ReadingLog {
		public virtual int Id { get; set; }

		/// <summary>
		/// The name of the reading list
		/// </summary>
		public virtual string Name { get; set; }

		public virtual ICollection<Book> Books { get; set; }

		public virtual ApplicationUser User { get; set; }
	}
}