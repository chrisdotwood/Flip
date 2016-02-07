using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Flip.DomainModel {
	public class Book {
		public int Id { get; set;}

		public string Title { get; set; }

		public string Author { get; set; }

		public DateTime? DateCompleted { get; set; }

		public BookStatus Status { get; set; }

		public BookMedia? Media { get; set; }
	}
}