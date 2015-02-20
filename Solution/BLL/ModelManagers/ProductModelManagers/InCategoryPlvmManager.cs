using System.Linq;
using CommonModels.Models.EntityFramework;
using CommonModels.Models.ProductModels;
using CommonPortable.Models.ProductModels;

namespace BLL.ModelManagers.ProductModelManagers
{
	public static class InCategoryPlvmManager
	{
		public static InCategoryPLVM DoConsturctorWork(this InCategoryPLVM instance, int pageNumber, int productsPerPage, IQueryable<Product> productsOrProducts, Category category)
		{	
			if(instance == null)
				instance = new InCategoryPLVM();

			// base call in ctr
			(instance as BookBlockPLVM).DoConsturctorWork(pageNumber, productsPerPage, productsOrProducts);
				
			instance.Category = new InCategoryPLVM.CategoryVM().DoConsturctorWork(category);
		
			return instance;
		}

		public static InCategoryPLVM DoConsturctorWork(this InCategoryPLVM instance, int pageNumber, int productsPerPage, IQueryable<ProductGroup> productsOrProductGroups, Category category)
		{
			if(instance == null)
				instance = new InCategoryPLVM();

			// base call in ctr
			(instance as BookBlockPLVM).DoConsturctorWork(pageNumber, productsPerPage, productsOrProductGroups);

			instance.Category = new InCategoryPLVM.CategoryVM().DoConsturctorWork(category);

			return instance;
		}

		public static InCategoryPLVM.CategoryVM DoConsturctorWork(this InCategoryPLVM.CategoryVM instance, Category category)
		{
			if(instance == null)
				instance = new InCategoryPLVM.CategoryVM();
				
			instance.DisplayName = category.DisplayName;
			instance.FriendlyUrl = category.FriendlyUrl;
			instance.FullPath = category.FullPath;

			return instance;
		}
	}
}
