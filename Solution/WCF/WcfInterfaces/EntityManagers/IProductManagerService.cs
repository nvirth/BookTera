using System.ServiceModel;
using System.ServiceModel.Web;
using CommonModels.Models.EntityFramework;
using CommonModels.Models.ProductModels;
using System.ServiceModel.Web;
using CommonPortable.Models.ProductModels;

namespace WcfInterfaces.EntityManagers
{
	[ServiceContract]
	public interface IProductManager
	{
		[OperationContract]
		[WebGet]
		InCategoryPLVM GetProductsInCategory(string categoryFriendlyUrl, int pageNumber, int productsPerPage);

		[OperationContract]
		[WebGet]
		BookBlockPLVM GetMainHighlighteds(int pageNumber, int productsPerPage);

		[OperationContract]
		[WebGet]
		BookBlockPLVM GetNewests(int pageNumber, int productsPerPage, int numOfProducts);

		[OperationContract]
		[WebGet(BodyStyle = WebMessageBodyStyle.WrappedResponse)]
		BookBlockPLVM GetUsersProductsByFriendlyUrl(string friendlyUrl, int pageNumber, int productsPerPage, out string userName, bool forExchange = false);

		[OperationContract]
		[WebGet]
		BookBlockPLVM GetUsersProducts(int userID, int pageNumber, int productsPerPage, bool forExchange = false);
	}
}