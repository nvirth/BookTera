using System.Collections.Generic;
using System.Collections.ObjectModel;
using CommonModels.Models.EntityFramework;

namespace WinStoreClientProxy.ModelsObservable.ProductModelsObservable
{
	public class InCategoryCwplvmObservable
	{
		public Category BaseCategory { get; set; }
		public ObservableCollection<InCategoryPlvmObservable> ChildCategoriesWithProducts { get; set; }
	}
}
