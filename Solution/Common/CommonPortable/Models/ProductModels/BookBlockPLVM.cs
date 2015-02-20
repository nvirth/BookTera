using System.Collections.Generic;
using CommonPortable.Enums;

namespace CommonPortable.Models.ProductModels
{
	public class BookBlockPLVM
	{
		public BookBlockType BookBlockType { get; set; }

		public List<InBookBlockPVM> Products { get; set; }
		public Paging Paging { get; set; }
	}
}
