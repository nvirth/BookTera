using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using WinPhoneClientProxy.CategoryManagerService;
using WindowsPhone.Common;
using Microsoft.Phone.Controls;
using WinPhoneClientProxy.WcfProxy;
using WinPhoneCommon;
using BookBlockPLVM = WinPhoneClientProxy.ProductManagerService.BookBlockPLVM;
using Ps = WinPhoneClientProxy.ProductManagerService;

namespace WindowsPhone.ViewModels
{
	public class CategoryPageVM : NotifyPropertyChanged
	{
		#region Members

		private Pivot _pivot;

		#region Categories

		public bool AreCategoriesLoaded { get; private set; }
		private InCategoryCWPLVM _categories;

		public InCategoryCWPLVM Categories
		{
			get { return _categories; }
			set
			{
				if(Equals(value, _categories))
					return;
				_categories = value;
				OnPropertyChanged();
			}
		}

		#endregion

		#region Products

		public bool AreProductsLoaded { get; private set; }
		private Ps.InCategoryPLVM _products;

		public Ps.InCategoryPLVM Products
		{
			get { return _products; }
			set
			{
				if(Equals(value, _products))
					return;
				_products = value;
				OnPropertyChanged();
			}
		}

		#endregion

		private bool _isDebug = false;

		#endregion

		public CategoryPageVM(Pivot pivot)
		{
			_pivot = pivot;
			SetDebugModeIf();

			// Can not call LoadCategories here, we do not know the Category.FriendlyUrl
			//
			//LoadCategories();
		}

		private void SetDebugModeIf()
		{
#if DEBUG
			_isDebug = true;
#endif
		}

		public void LoadCategories(string friendlyUrl)
		{
			if(AreCategoriesLoaded)
				return;

			AsyncCallback callback = ar => Deployment.Current.Dispatcher.BeginInvoke(
				() =>
				{
					try
					{
						var categories = Services.CategoryManager.EndGetCategoriesWithProductsInCategory(ar);

						// Fuck...
						// Here we get the leaf category's products, but can not use, because
						// their type is CategoryService.InCategoryCWPLVM, not ProductService.InCategoryCWPLVM 
						if(categories != null && categories.ChildCategoriesWithProducts.Count == 1)
							categories.ChildCategoriesWithProducts.Clear();

						Categories = categories;
					}
					catch(Exception e)
					{
						LoadCategories_Catch(e);
					}
				});

			try
			{
				Services.CategoryManager.BeginGetCategoriesWithProductsInCategory(1, 0, friendlyUrl, callback, null);
				AreCategoriesLoaded = true;
			}
			catch(Exception e)
			{
				LoadCategories_Catch(e);
			}
		}
		private void LoadCategories_Catch(Exception e)
		{
			AreCategoriesLoaded = false;

			if(!_isDebug)
				throw e;
			else
			{
				var sampleData = new SampleData.CategoryListSD().SubCategories;
				Categories = sampleData;
			}
		}

		public void LoadProducts(string friendlyUrl)
		{
			if(AreProductsLoaded)
				return;

			if(string.IsNullOrWhiteSpace(friendlyUrl))
				return;

			AsyncCallback callback = ar => Deployment.Current.Dispatcher.BeginInvoke(
				() =>
				{
					try
					{
						Products = Services.ProductManager.EndGetProductsInCategory(ar);
					}
					catch(Exception e)
					{
						LoadProducts_Catch(e);
					}
				});

			try
			{
				Services.ProductManager.BeginGetProductsInCategory(friendlyUrl, 1, 100, callback, null);
				AreProductsLoaded = true;
			}
			catch(Exception e)
			{
				LoadProducts_Catch(e);
			}
		}
		private void LoadProducts_Catch(Exception e)
		{
			AreProductsLoaded = false;

			if(!_isDebug)
				throw e;
			else
			{
				var sampleData = new SampleData.ProductsInCategorySD().Products;
				Products = sampleData;
			}
		}
	}
}
