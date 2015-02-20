using System.Collections.Generic;
using BLL.EntityManagers;
using CommonModels.Models;
using CommonModels.Models.ProductModels;
using CommonPortable.Models;
using CommonPortable.Models.ProductModels;
using Newtonsoft.Json;
using UtilsShared;
using WcfInterfaces.EntityManagers;

namespace WcfHost.EntityManagers
{
	public class ProductGroupManagerService : IProductGroupManager
	{
		BookRowPLVM IProductGroupManager.GetFullDetailed(string friendlyUrl, int pageNumber, int productsPerPage)
		{
			return ProductGroupManager.GetFullDetailed(friendlyUrl, pageNumber, productsPerPage);
		}

		List<SelectListItemWithClass> IProductGroupManager.GetAllSortedJson(int? selectedId)
		{
			return ProductGroupManager.GetAllSortedJson(selectedId);
		}

		BookBlockPLVM IProductGroupManager.Search(string searchText, int pageNumber, int productsPerPage, bool needCategory = false)
		{
			return ProductGroupManager.Search(searchText, pageNumber, productsPerPage, needCategory);
		}

		InCategoryCWPLVM IProductGroupManager.SearchWithGroupedByCategory(string searchText, int pageNumber, int productsPerPage)
		{
			return ProductGroupManager.SearchWithGroupedByCategory(searchText, pageNumber, productsPerPage);
		}

		LabelValuePair[] IProductGroupManager.SearchAutoComplete(string searchText, int howMany)
		{
			return ProductGroupManager.SearchAutoComplete(searchText, howMany);
		}

		SearchPgAcVm[] IProductGroupManager.SearchAutoCompletePg(string searchText, int howMany)
		{
			return ProductGroupManager.SearchAutoCompletePg(searchText, howMany);
		}

		string IProductGroupManager.SearchAutoCompleteJson(string searchText, int howMany)
		{
			var result = ProductGroupManager.SearchAutoComplete(searchText, howMany);
			return JsonConvert.SerializeObject(result);
		}

		BookBlockPLVM IProductGroupManager.SearchDetailed(DetailedSearchVM.DetailedSearchInputs dsi, int pageNumber, int productsPerPage)
		{
			return ProductGroupManager.SearchDetailed(dsi, pageNumber, productsPerPage);
		}
	}

}