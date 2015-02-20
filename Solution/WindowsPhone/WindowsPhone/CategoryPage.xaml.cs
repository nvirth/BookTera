using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using WinPhoneClientProxy.CategoryManagerService;
using WindowsPhone.Common;
using WindowsPhone.Common.PageBase;
using WindowsPhone.ViewModels;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using WinPhoneCommon;

namespace WindowsPhone
{
	public partial class CategoryPage : BookteraPageBase
	{
		public CategoryPageVM ViewModel { get; private set; }

		public CategoryPage()
		{
			ViewModel = new CategoryPageVM(CategoryPagePivot);
			InitializeComponent();
		}

		protected override void OnNavigatedTo(NavigationEventArgs e)
		{
			base.OnNavigatedTo(e);

			string fu = null;
			if(NavigationContext.QueryString.ContainsKey("FriendlyUrl"))
				fu = NavigationContext.QueryString["FriendlyUrl"];

			ViewModel.LoadCategories(fu);
		}

		private void LongListSelector_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			var longListSelector = (LongListSelector)sender;
			var selectedItem = (InCategoryPLVM)longListSelector.SelectedItem;
			var uri = new Uri(string.Format("/CategoryPage.xaml?FriendlyUrl={0}", selectedItem.Category.FriendlyUrl), UriKind.Relative);
			NavigationService.Navigate(uri);
		}

		private void Pivot_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			var pivot = (Pivot)sender;
			if(pivot.SelectedIndex == (int)CategoryPagePivotItem.ProductsInCategory)
			{
				if(ViewModel.Categories.BaseCategory != null)
					ViewModel.LoadProducts(ViewModel.Categories.BaseCategory.FriendlyUrl);
				else
				{
					LblEmptyProducts.Visibility = Visibility.Collapsed;
					LblRootCategory.Visibility = Visibility.Visible;
				}
			}
		}
	}
}