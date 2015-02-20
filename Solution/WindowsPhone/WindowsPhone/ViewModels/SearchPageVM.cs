using System;
using System.Windows;
using WinPhoneClientProxy.CategoryManagerService;
using WinPhoneClientProxy.ProductManagerService;
using Microsoft.Phone.Controls;
using WinPhoneClientProxy.WcfProxy;
using WinPhoneCommon;

namespace WindowsPhone.ViewModels
{
	public class SearchPageVM : NotifyPropertyChanged
	{
		public SearchPageVM()
		{
			// This must not be null
			UsersProducts = new WinPhoneClientProxy.ProductManagerService.BookBlockPLVM();
		}

		#region SearchProducts

		private WinPhoneClientProxy.ProductGroupManagerService.BookBlockPLVM _searchProducts;
		public WinPhoneClientProxy.ProductGroupManagerService.BookBlockPLVM SearchProducts
		{
			get { return _searchProducts; }
			set
			{
				if(Equals(value, _searchProducts))
					return;
				_searchProducts = value;
				OnPropertyChanged();
			}
		}

		#endregion

		#region UsersProducts

		private WinPhoneClientProxy.ProductManagerService.BookBlockPLVM _usersProducts;
		public WinPhoneClientProxy.ProductManagerService.BookBlockPLVM UsersProducts
		{
			get { return _usersProducts; }
			set
			{
				if(Equals(value, _usersProducts))
					return;
				_usersProducts = value;
				OnPropertyChanged();
			}
		}

		#endregion

		public void Search(string searchText)
		{
			if(string.IsNullOrWhiteSpace(searchText) || searchText.Length < 3)
				return;

			AsyncCallback callback = ar => Deployment.Current.Dispatcher.BeginInvoke(
				() =>
				{
						SearchProducts = Services.ProductGroupManager.EndSearch(ar);
				});

				Services.ProductGroupManager.BeginSearch(searchText, 1, 100, /*needCategory*/false, callback, null);
		}

		public void LoadUsersBooks(string userFu)
		{
			if(string.IsNullOrWhiteSpace(userFu))
				return;

			AsyncCallback callback = ar => Deployment.Current.Dispatcher.BeginInvoke(
				() =>
				{
					string userName;
					var products = Services.ProductManager.EndGetUsersProductsByFriendlyUrl(out userName, ar);
					
					// Clear the UserName like properties, not to show them in ContextMenu
					foreach(var pvm in products.Products)
					{
						pvm.Product.UserFriendlyUrl = null;
						pvm.Product.UserName = null;
					}

					UsersProducts = products;
				});

			Services.ProductManager.BeginGetUsersProductsByFriendlyUrl(userFu, 1, 100, /*forExchange*/false, callback, null);
		}
	}
}
