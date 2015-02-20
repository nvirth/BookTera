using System.Collections.Generic;
using System.ServiceModel;
using CommonModels.Models;
using CommonModels.Models.ProductModels;
using CommonPortable.Models;
using CommonPortable.Models.ProductModels;
using UtilsShared;
using System.ServiceModel.Web;

namespace WcfInterfaces.EntityManagers
{
	[ServiceContract]
	public interface IProductGroupManager
	{
		[OperationContract]
		[WebGet]
		BookRowPLVM GetFullDetailed(string friendlyUrl, int pageNumber, int productsPerPage);

		[OperationContract]
		[WebGet]
		List<SelectListItemWithClass> GetAllSortedJson(int? selectedId = null);

		[OperationContract]
		[WebGet]
		BookBlockPLVM Search(string searchText, int pageNumber, int productsPerPage, bool needCategory = false);

		[OperationContract]
		[WebGet]
		InCategoryCWPLVM SearchWithGroupedByCategory(string searchText, int pageNumber, int productsPerPage);

		[OperationContract]
		[WebGet]
		LabelValuePair[] SearchAutoComplete(string searchText, int howMany);

		[OperationContract]
		[WebGet]
		SearchPgAcVm[] SearchAutoCompletePg(string searchText, int howMany);

		[OperationContract]
		[WebGet]
		string SearchAutoCompleteJson(string searchText, int howMany);

		[OperationContract]
		[WebInvoke(BodyStyle = WebMessageBodyStyle.WrappedRequest)]
		BookBlockPLVM SearchDetailed(DetailedSearchVM.DetailedSearchInputs dsi, int pageNumber, int productsPerPage);
	}
}