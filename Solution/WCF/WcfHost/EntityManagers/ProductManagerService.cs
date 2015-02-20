using System.Web;
using BLL.EntityManagers;
using CommonModels.Models.EntityFramework;
using CommonModels.Models.ProductModels;
using CommonPortable.Models.ProductModels;
using WcfInterfaces.EntityManagers;
using WebMatrix.WebData;

namespace WcfHost.EntityManagers
{
	public class ProductManagerService : IProductManager 
	{
		InCategoryPLVM IProductManager.GetProductsInCategory(string categoryFriendlyUrl, int pageNumber, int productsPerPage)
		{
			return ProductManager.GetProductsInCategory(categoryFriendlyUrl, pageNumber, productsPerPage);
		}

		BookBlockPLVM IProductManager.GetMainHighlighteds(int pageNumber, int productsPerPage)
		{
			return ProductManager.GetMainHighlighteds(pageNumber, productsPerPage);
		}

		BookBlockPLVM IProductManager.GetNewests(int pageNumber, int productsPerPage, int numOfProducts)
		{
			return ProductManager.GetNewests(pageNumber, productsPerPage, numOfProducts);
		}

		BookBlockPLVM IProductManager.GetUsersProductsByFriendlyUrl(string friendlyUrl, int pageNumber, int productsPerPage, out string userName, bool forExchange)
		{
			return ProductManager.GetUsersProducts(friendlyUrl, pageNumber, productsPerPage, out userName, forExchange);
		}

		BookBlockPLVM IProductManager.GetUsersProducts(int userID, int pageNumber, int productsPerPage, bool forExchange)
		{
			return ProductManager.GetUsersProducts(userID, pageNumber, productsPerPage, forExchange);
		}
	}
}