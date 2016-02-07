using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Flip.DomainModel {
	public class ReadingLog {
		public IEnumerable<Book> Books { get; set; }

		public ApplicationUser User { get; set; }
	}
}