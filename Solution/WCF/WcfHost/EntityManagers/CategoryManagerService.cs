using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using BLL.EntityManagers;
using CommonModels.Models.EntityFramework;
using CommonModels.Models.ProductModels;
using CommonPortable.Models.ProductModels;
using UtilsShared;
using WcfInterfaces.EntityManagers;

namespace WcfHost.EntityManagers
{
	public class CategoryManagerService : ICategoryManager
	{
		string ICategoryManager.GetAllForMenu(string selected, string[] openedIds)
		{
			return CategoryManager.GetAllForMenu(selected, openedIds);
		}

		List<SelectListItemWithClass> ICategoryManager.GetAllSortedJson(int? selectedCategoryId)
		{
			return CategoryManager.GetAllSortedJson(selectedCategoryId);
		}

		InCategoryCWPLVM ICategoryManager.GetCategoriesWithProductsInCategory(int pageNumber, int productsPerPage, string baseCategoryFu = null)
		{
			var inCategoryCwplvm = CategoryManager.GetCategoriesWithProductsInCategory(pageNumber, productsPerPage, baseCategoryFu);
			inCategoryCwplvm.BaseCategory = CategoryManager.CopyFromProxy(inCategoryCwplvm.BaseCategory);
			return inCategoryCwplvm;
		}
	}
}
