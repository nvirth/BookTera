namespace WinStoreClientProxy.ModelsObservable.ProductModelsObservable
{
	public class InCategoryPlvmObservable: BookBlockPlvmObservable
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
