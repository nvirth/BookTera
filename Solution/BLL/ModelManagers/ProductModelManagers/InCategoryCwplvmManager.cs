using System.Collections.Generic;
using BLL.EntityManagers;
using CommonModels.Models.EntityFramework;
using CommonModels.Models.ProductModels;
using CommonPortable.Models.ProductModels;
using DAL.EntityFramework;

namespace BLL.ModelManagers.ProductModelManagers
{
	public static class InCategoryCwplvmManager
	{
		/// <summary>
		/// Amikor a BaseCategory egy parent
		/// </summary>
		public static InCategoryCWPLVM DoConstructorDork(this InCategoryCWPLVM instance, DBEntities ctx, string[] childCategoryFus, int pageNumber, int productsPerPage, Category baseCategory = null)
		{
			if(instance==null)
				instance = new InCategoryCWPLVM();

			instance.BaseCategory = baseCategory;

			instance.ChildCategoriesWithProducts = new List<InCategoryPLVM>();
			foreach(var childCategoryFu in childCategoryFus)
			{
				var productsInCategory = ProductManager.GetProductsInCategory(ctx, childCategoryFu, pageNumber, productsPerPage);
				instance.ChildCategoriesWithProducts.Add(productsInCategory);
			}

			return instance;
		}

		/// <summary>
		/// Amikor a BaseCategory egy leaf
		/// </summary>
		public static InCategoryCWPLVM DoConstructorDork(this InCategoryCWPLVM instance, DBEntities ctx, int pageNumber, int productsPerPage, Category baseCategory)
		{
			if(instance == null)
				instance = new InCategoryCWPLVM();

			instance.BaseCategory = baseCategory;
			
			instance.ChildCategoriesWithProducts = new List<InCategoryPLVM>
			{
				ProductManager.GetProductsInCategory(ctx, baseCategory, pageNumber, productsPerPage)
			};

			return instance;
		}
	}
}
