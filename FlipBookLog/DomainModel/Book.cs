using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Flip.DomainModel {
	public class Book {
		public virtual int Id { get; set;}

		public virtual string Title { get; set; }

		public virtual string Author { get; set; }

		public virtual DateTime? DateCompleted { get; set; }

		public virtual BookStatus Status { get; set; }

		public virtual BookMedia? Media { get; set; }
	}
}