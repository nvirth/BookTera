using System.Collections.Generic;
using System.Collections.ObjectModel;
using CommonModels.Models.EntityFramework;

namespace CommonPortable.Models.ProductModels
{
	public class InCategoryCWPLVM
	{
		public Category BaseCategory { get; set; }
		public List<InCategoryPLVM> ChildCategoriesWithProducts { get; set; }
	}
}
