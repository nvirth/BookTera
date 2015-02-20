namespace CommonPortable.Models.ProductModels
{
	public class InCategoryPLVM: BookBlockPLVM
	{
		public CategoryVM Category { get; set; }

		public class CategoryVM
		{
			public string DisplayName { get; set; }
			public string FriendlyUrl { get; set; }
			public string FullPath { get; set; }
		}
	}
}
