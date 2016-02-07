using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Flip.DomainModel {
	public enum BookStatus : byte {
		/// <summary>
		/// The book has been read to the end
		/// </summary>
		Finished = 1,
		/// <summary>
		/// The book was started but not finished
		/// </summary>
		Abandoned = 2,
		/// <summary>
		/// The book has been recorded for future reference but hasn't yet been read
		/// </summary>
		Future = 3
	}
}