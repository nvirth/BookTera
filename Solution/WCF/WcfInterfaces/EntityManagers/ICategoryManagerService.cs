using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;
using CommonModels.Models.EntityFramework;
using CommonModels.Models.ProductModels;
using CommonPortable.Models.ProductModels;
using UtilsShared;

namespace WcfInterfaces.EntityManagers
{
	[ServiceContract]
	public interface ICategoryManager
	{
		[OperationContract]
		[WebGet]
		string GetAllForMenu(string selected, string[] openedIds);

		[OperationContract]
		[WebGet]
		List<SelectListItemWithClass> GetAllSortedJson(int? selectedCategoryId = null);

		[OperationContract]
		[WebGet]
		InCategoryCWPLVM GetCategoriesWithProductsInCategory(int pageNumber, int productsPerPage, string baseCategoryFu = null);
	}
}
