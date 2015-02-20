using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinStoreClientProxy;
using WinStoreClientProxy.ModelsObservable.ProductModelsObservable;

namespace MetroWpf.SampleData
{
	public class CategoryPageSampleData
	{
		private static readonly string BaseCategoryFu = null;

		public InCategoryCwplvmObservable CategoryViewModel { get; set; }

		public CategoryPageSampleData()
		{
			Task.Run(
				async () =>
				{
					CategoryViewModel = await CategoryManager.GetCategoriesWithProductsInCategoryAsync(1, 4, BaseCategoryFu);
				}).Wait();

			//CategoryManager.GetCategoriesWithProductsInCategoryAsync(1, 4, BaseCategoryFu).Wait();

		}
	}
}
