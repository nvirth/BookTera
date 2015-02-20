using System;
using System.Collections.ObjectModel;
using WinPhoneClientProxy.CategoryManagerService;
using WinPhoneClientProxy.ProductGroupManagerService;
using WinPhoneClientProxy.ProductManagerService;
using WinPhoneClientProxy.WcfProxy.Base;
using BookBlockPLVM = WinPhoneClientProxy.ProductManagerService.BookBlockPLVM;
using InCategoryCWPLVM = WinPhoneClientProxy.ProductGroupManagerService.InCategoryCWPLVM;
using InCategoryPLVM = WinPhoneClientProxy.ProductManagerService.InCategoryPLVM;
using SelectListItemWithClass = WinPhoneClientProxy.ProductGroupManagerService.SelectListItemWithClass;

namespace WinPhoneClientProxy.WcfProxy
{
	public class Services
	{
		// -- WCF
		public static readonly IProductManager ProductManager = new ProductManagerClientSafe();
		public static readonly IProductGroupManager ProductGroupManager = new ProductGroupManagerClientSafe();
		public static readonly ICategoryManager CategoryManager = new CategoryManagerClientSafe();

		// -- REST (manually)
		public static readonly UserProfileManagerClient UserProfileManagerClient = new UserProfileManagerClient();
		public static readonly AuthenticationClient AuthenticationClient = new AuthenticationClient();
		public static readonly RegistrationClient RegistrationClient = new RegistrationClient();
		public static readonly TransactionManagerClient TransactionManagerClient = new TransactionManagerClient();


		#region HandleCommunicationExceptions (archive)

		// This did not worked for CommunicationExceoptions
		//
		//private static IEnumerable<ICommunicationObject> GetWcfCommunicationObjects()
		//{
		//	yield return (ICommunicationObject)ProductManager;
		//	yield return (ICommunicationObject)ProductGroupManager;
		//	yield return (ICommunicationObject)CategoryManager;
		//}
		//
		//static Services()
		//{
		//	foreach(var communicationObject in GetWcfCommunicationObjects())
		//	{
		//		communicationObject.Faulted += (sender, args) => Deployment.Current.Dispatcher
		//			.BeginInvoke(() => MessageBox.Show("Hiba a kapcsolatban. Kérlek, próbáld újra. "));
		//	}
		//}

		#endregion

	}

	public class ProductGroupManagerClientSafe : IProductGroupManager
	{
		private ProductGroupManagerClient _core = new ProductGroupManagerClient();

		#region Begin...

		public IAsyncResult BeginGetFullDetailed(string friendlyUrl, int pageNumber, int productsPerPage, AsyncCallback callback, object asyncState)
		{
			return ((IProductGroupManager)_core).BeginGetFullDetailed(friendlyUrl, pageNumber, productsPerPage, callback, asyncState);
		}

		public IAsyncResult BeginGetAllSortedJson(int? selectedId, AsyncCallback callback, object asyncState)
		{
			return ((IProductGroupManager)_core).BeginGetAllSortedJson(selectedId, callback, asyncState);
		}

		public IAsyncResult BeginSearch(string searchText, int pageNumber, int productsPerPage, bool needCategory, AsyncCallback callback, object asyncState)
		{
			return ((IProductGroupManager)_core).BeginSearch(searchText, pageNumber, productsPerPage, needCategory, callback, asyncState);
		}

		public IAsyncResult BeginSearchWithGroupedByCategory(string searchText, int pageNumber, int productsPerPage, AsyncCallback callback, object asyncState)
		{
			return ((IProductGroupManager)_core).BeginSearchWithGroupedByCategory(searchText, pageNumber, productsPerPage, callback, asyncState);
		}

		public IAsyncResult BeginSearchAutoComplete(string searchText, int howMany, AsyncCallback callback, object asyncState)
		{
			return ((IProductGroupManager)_core).BeginSearchAutoComplete(searchText, howMany, callback, asyncState);
		}

		public IAsyncResult BeginSearchAutoCompletePg(string searchText, int howMany, AsyncCallback callback, object asyncState)
		{
			return ((IProductGroupManager)_core).BeginSearchAutoCompletePg(searchText, howMany, callback, asyncState);
		}

		public IAsyncResult BeginSearchAutoCompleteJson(string searchText, int howMany, AsyncCallback callback, object asyncState)
		{
			return ((IProductGroupManager)_core).BeginSearchAutoCompleteJson(searchText, howMany, callback, asyncState);
		}

		public IAsyncResult BeginSearchDetailed(DetailedSearchVMDetailedSearchInputs dsi, int pageNumber, int productsPerPage, AsyncCallback callback, object asyncState)
		{
			return ((IProductGroupManager)_core).BeginSearchDetailed(dsi, pageNumber, productsPerPage, callback, asyncState);
		}

		#endregion

		#region End...

		public WinPhoneClientProxy.ProductGroupManagerService.BookBlockPLVM EndSearchDetailed(IAsyncResult result)
		{
			try
			{
				return ((IProductGroupManager)_core).EndSearchDetailed(result);
			}
			catch(Exception e)
			{
				RestServiceClientBase.ShowDefaultErrorMsg();
			}
			return null;
		}

		public string EndSearchAutoCompleteJson(IAsyncResult result)
		{
			try
			{
				return ((IProductGroupManager)_core).EndSearchAutoCompleteJson(result);
			}
			catch(Exception e)
			{
				RestServiceClientBase.ShowDefaultErrorMsg();
			}
			return null;
		}

		public ObservableCollection<SearchPgAcVm> EndSearchAutoCompletePg(IAsyncResult result)
		{
			try
			{
				return ((IProductGroupManager)_core).EndSearchAutoCompletePg(result);
			}
			catch(Exception e)
			{
				RestServiceClientBase.ShowDefaultErrorMsg();
			}
			return null;
		}

		public ObservableCollection<LabelValuePair> EndSearchAutoComplete(IAsyncResult result)
		{
			try
			{
				return ((IProductGroupManager)_core).EndSearchAutoComplete(result);
			}
			catch(Exception e)
			{
				RestServiceClientBase.ShowDefaultErrorMsg();
			}
			return null;
		}

		public InCategoryCWPLVM EndSearchWithGroupedByCategory(IAsyncResult result)
		{
			try
			{
				return ((IProductGroupManager)_core).EndSearchWithGroupedByCategory(result);
			}
			catch(Exception e)
			{
				RestServiceClientBase.ShowDefaultErrorMsg();
			}
			return null;
		}

		public WinPhoneClientProxy.ProductGroupManagerService.BookBlockPLVM EndSearch(IAsyncResult result)
		{
			try
			{
				return ((IProductGroupManager)_core).EndSearch(result);
			}
			catch(Exception e)
			{
				RestServiceClientBase.ShowDefaultErrorMsg();
			}
			return null;
		}

		public ObservableCollection<SelectListItemWithClass> EndGetAllSortedJson(IAsyncResult result)
		{
			try
			{
				return ((IProductGroupManager)_core).EndGetAllSortedJson(result);
			}
			catch(Exception e)
			{
				RestServiceClientBase.ShowDefaultErrorMsg();
			}
			return null;
		}

		public BookRowPLVM EndGetFullDetailed(IAsyncResult result)
		{
			try
			{
				return ((IProductGroupManager)_core).EndGetFullDetailed(result);
			}
			catch(Exception e)
			{
				RestServiceClientBase.ShowDefaultErrorMsg();
			}
			return null;
		}

		#endregion
	}
	public class ProductManagerClientSafe : IProductManager
	{
		private ProductManagerClient _core = new ProductManagerClient();

		#region End...

		public InCategoryPLVM EndGetProductsInCategory(IAsyncResult result)
		{
			try
			{
				return ((IProductManager)_core).EndGetProductsInCategory(result);
			}
			catch(Exception e)
			{
				RestServiceClientBase.ShowDefaultErrorMsg();
			}
			return null;
		}

		public BookBlockPLVM EndGetMainHighlighteds(IAsyncResult result)
		{
			try
			{
				return ((IProductManager)_core).EndGetMainHighlighteds(result);
			}
			catch(Exception e)
			{
				RestServiceClientBase.ShowDefaultErrorMsg();
			}
			return null;
		}

		public BookBlockPLVM EndGetNewests(IAsyncResult result)
		{
			try
			{
				return ((IProductManager)_core).EndGetNewests(result);
			}
			catch(Exception e)
			{
				RestServiceClientBase.ShowDefaultErrorMsg();
			}
			return null;
		}

		public BookBlockPLVM EndGetUsersProductsByFriendlyUrl(out string userName, IAsyncResult result)
		{
			try
			{
				return ((IProductManager)_core).EndGetUsersProductsByFriendlyUrl(out userName, result);
			}
			catch(Exception e)
			{
				RestServiceClientBase.ShowDefaultErrorMsg();
			}
			userName = "";
			return null;
		}

		public BookBlockPLVM EndGetUsersProducts(IAsyncResult result)
		{
			try
			{
				return ((IProductManager)_core).EndGetUsersProducts(result);
			}
			catch(Exception e)
			{
				RestServiceClientBase.ShowDefaultErrorMsg();
			}
			return null;
		}

		#endregion

		#region Begin...

		public IAsyncResult BeginGetProductsInCategory(string categoryFriendlyUrl, int pageNumber, int productsPerPage, AsyncCallback callback, object asyncState)
		{
			return ((IProductManager)_core).BeginGetProductsInCategory(categoryFriendlyUrl, pageNumber, productsPerPage, callback, asyncState);
		}

		public IAsyncResult BeginGetMainHighlighteds(int pageNumber, int productsPerPage, AsyncCallback callback, object asyncState)
		{
			return ((IProductManager)_core).BeginGetMainHighlighteds(pageNumber, productsPerPage, callback, asyncState);
		}

		public IAsyncResult BeginGetNewests(int pageNumber, int productsPerPage, int numOfProducts, AsyncCallback callback, object asyncState)
		{
			return ((IProductManager)_core).BeginGetNewests(pageNumber, productsPerPage, numOfProducts, callback, asyncState);
		}

		public IAsyncResult BeginGetUsersProductsByFriendlyUrl(string friendlyUrl, int pageNumber, int productsPerPage, bool forExchange, AsyncCallback callback, object asyncState)
		{
			return ((IProductManager)_core).BeginGetUsersProductsByFriendlyUrl(friendlyUrl, pageNumber, productsPerPage, forExchange, callback, asyncState);
		}

		public IAsyncResult BeginGetUsersProducts(int userID, int pageNumber, int productsPerPage, bool forExchange, AsyncCallback callback, object asyncState)
		{
			return ((IProductManager)_core).BeginGetUsersProducts(userID, pageNumber, productsPerPage, forExchange, callback, asyncState);
		}

		#endregion
	}

	public class CategoryManagerClientSafe : ICategoryManager
	{
		private CategoryManagerClient _core = new CategoryManagerClient();

		#region End...

		public WinPhoneClientProxy.CategoryManagerService.InCategoryCWPLVM EndGetCategoriesWithProductsInCategory(IAsyncResult result)
		{
			try
			{
				return ((ICategoryManager)_core).EndGetCategoriesWithProductsInCategory(result);
			}
			catch(Exception e)
			{
				RestServiceClientBase.ShowDefaultErrorMsg();
			}
			return null;
		}

		public ObservableCollection<WinPhoneClientProxy.CategoryManagerService.SelectListItemWithClass> EndGetAllSortedJson(IAsyncResult result)
		{
			try
			{
				return ((ICategoryManager)_core).EndGetAllSortedJson(result);
			}
			catch(Exception e)
			{
				RestServiceClientBase.ShowDefaultErrorMsg();
			}
			return null;
		}

		public string EndGetAllForMenu(IAsyncResult result)
		{
			try
			{
				return ((ICategoryManager)_core).EndGetAllForMenu(result);
			}
			catch(Exception e)
			{
				RestServiceClientBase.ShowDefaultErrorMsg();
			}
			return null;
		}

		#endregion

		#region Begin...

		public IAsyncResult BeginGetCategoriesWithProductsInCategory(int pageNumber, int productsPerPage, string baseCategoryFu, AsyncCallback callback, object asyncState)
		{
			return ((ICategoryManager)_core).BeginGetCategoriesWithProductsInCategory(pageNumber, productsPerPage, baseCategoryFu, callback, asyncState);
		}

		public IAsyncResult BeginGetAllSortedJson(int? selectedCategoryId, AsyncCallback callback, object asyncState)
		{
			return ((ICategoryManager)_core).BeginGetAllSortedJson(selectedCategoryId, callback, asyncState);
		}

		public IAsyncResult BeginGetAllForMenu(string selected, ObservableCollection<string> openedIds, AsyncCallback callback, object asyncState)
		{
			return ((ICategoryManager)_core).BeginGetAllForMenu(selected, openedIds, callback, asyncState);
		}

		#endregion
	}

}
