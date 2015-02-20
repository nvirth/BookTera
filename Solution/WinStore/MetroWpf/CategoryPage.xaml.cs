using System.Collections.ObjectModel;
using System.Net;
using System.Threading.Tasks;
using Windows.ApplicationModel.Search;
using Windows.Storage;
using Windows.Storage.Streams;
using Windows.System;
using Windows.UI.Xaml.Automation.Peers;
using CommonPortable.Models;
using CommonPortable.Models.ProductModels;
using MetroWpf.Common;
using MetroWpf.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
// The Grouped Items Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234231
using WinStoreClientProxy;
using WinStoreClientProxy.ModelsObservable.ProductModelsObservable;

namespace MetroWpf
{
	public sealed partial class CategoryPage : Page
	{
		/// <summary>
		/// NavigationHelper is used on each page to aid in navigation and 
		/// process lifetime management
		/// </summary>
		public NavigationHelper NavigationHelper { get; private set; }
		public InCategoryCwplvmObservable CategoryViewModel { get; private set; }
		private readonly SearchPaneManager _searchPaneManager;

		public CategoryPage()
		{
			this.InitializeComponent();
			this.NavigationHelper = new NavigationHelper(this);
			this.NavigationHelper.LoadState += NavigationHelperLoadState;
			_searchPaneManager = new SearchPaneManager(NavigateToSearchPage, NavigateToProductGroupPage);
		}

		#region Load the Page

		/// <summary>
		/// Populates the page with content passed during navigation.  Any saved state is also
		/// provided when recreating a page from a prior session.
		/// </summary>
		/// <param name="sender">
		/// The source of the event; typically <see cref="NavigationHelper"/>
		/// </param>
		/// <param name="e">Event data that provides both the navigation parameter passed to
		/// <see cref="Frame.Navigate(Type, Object)"/> when this page was initially requested and
		/// a dictionary of state preserved by this page during an earlier
		/// session.  The state will be null the first time a page is visited.</param>
		private void NavigationHelperLoadState(object sender, LoadStateEventArgs e)
		{
			var parameter = e.NavigationParameter as CategoryPageNavigationParameter;

			// First load, list the top level categories
			if(parameter == null)
				LoadCategoryListPage();

				// Clicked on category on header, list the child categories
			else if(parameter.Type == CategoryPageNavigationParameterEnum.CategoryFu)
				LoadCategoryListPage( /*baseCategoryFu*/ parameter.Value);

			else if(parameter.Type == CategoryPageNavigationParameterEnum.SearchText)
				LoadSearchResultsPage( /*searchText*/ parameter.Value);
		}

		private async void LoadSearchResultsPage(string searchText)
		{
			var data = await ProductGroupManager.SearchWithGroupedByCategoryAsync(searchText, 1, 100);

			CategoryViewModel = data;
			pageRoot.DataContext = CategoryViewModel;
			pageTitle.Text = "Keresés: " + searchText;

			IfEmptyOperations();
		}

		private async void LoadCategoryListPage(string baseCategoryFu = null)
		{
			var data = await CategoryManager.GetCategoriesWithProductsInCategoryAsync(1, 4, baseCategoryFu);

			CategoryViewModel = data;
			pageRoot.DataContext = CategoryViewModel;
			pageTitle.Text = data.BaseCategory != null
				? data.BaseCategory.FullPath
				: (string)Application.Current.Resources["AppName"];

			IfEmptyOperations();
		}
		
		private void IfEmptyOperations()
		{
			if(CategoryViewModel.ChildCategoriesWithProducts.Count == 0)
			{
				NoResultTextBlock.Visibility = Visibility.Visible;
				semanticZoom.CanChangeViews = false;
			}
		}

		#endregion

		#region Click Handlers

		/// <summary>
		/// Invoked when a group header is clicked.
		/// </summary>
		/// <param name="sender">The Button used as a group header for the selected group.</param>
		/// <param name="e">Event data that describes how the click was initiated.</param>
		private void Header_Click(object sender, RoutedEventArgs e)
		{
			// Determine what group the Button instance represents
			var dataContext = (sender as FrameworkElement).DataContext;
			string categoryFu = null;

			var observable = dataContext as InCategoryPlvmObservable;
			if(observable != null)
			{
				categoryFu = observable.Category.FriendlyUrl;
			}
			else
			{
				var normal = dataContext as InCategoryPLVM;
				if(normal != null)
					categoryFu = normal.Category.FriendlyUrl;
			}

			NavigateToCategoryPage(categoryFu);
		}

		/// <summary>
		/// Invoked when an item within a group is clicked.
		/// </summary>
		/// <param name="sender">The GridView (or ListView when the application is snapped)
		/// displaying the item clicked.</param>
		/// <param name="e">Event data that describes the item clicked.</param>
		private void ItemView_ItemClick(object sender, ItemClickEventArgs e)
		{
			var productGroupFu = ((InBookBlockPVM)e.ClickedItem).ProductGroup.FriendlyUrl;

			NavigateToProductGroupPage(productGroupFu);
		}

		#endregion

		#region NavigationHelper registration

		/// The methods provided in this section are simply used to allow
		/// NavigationHelper to respond to the page's navigation methods.
		/// 
		/// Page specific logic should be placed in event handlers for the  
		/// <see cref="GridCS.Common.NavigationHelper.LoadState"/>
		/// and <see cref="GridCS.Common.NavigationHelper.SaveState"/>.
		/// The navigation parameter is available in the LoadState method 
		/// in addition to page state preserved during an earlier session.

		protected override void OnNavigatedTo(NavigationEventArgs e)
		{
			NavigationHelper.OnNavigatedTo(e);
		}

		protected override void OnNavigatedFrom(NavigationEventArgs e)
		{
			NavigationHelper.OnNavigatedFrom(e);
		}

		#endregion

		#region NavigateTo...

		private void NavigateToProductGroupPage(string productGroupFu)
		{
			this.Frame.Navigate(typeof(ProductGroupPage), productGroupFu);
		}

		private void NavigateToCategoryPage(string categoryFu)
		{
			// Navigate to self to list the categories
			var navigationParameter = new CategoryPageNavigationParameter
			{
				Type = CategoryPageNavigationParameterEnum.CategoryFu,
				Value = categoryFu,
			};

			// Navigate to the appropriate destination page, configuring the new page
			// by passing required information as a navigation parameter
			this.Frame.Navigate(typeof(CategoryPage), navigationParameter);
		}

		private void NavigateToSearchPage(string searchText)
		{
			var navigationParameter = new CategoryPageNavigationParameter
			{
				Type = CategoryPageNavigationParameterEnum.SearchText,
				Value = searchText,
			};

			this.Frame.Navigate(typeof(CategoryPage), navigationParameter);
		}

		#endregion

		#region Search

		private void SearchButton_Click(object sender, RoutedEventArgs e)
		{
			NavigateToSearchPage(SearchBox.Text);
		}

		private async void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
		{
			LabelValuePair[] labelValuePairs = null;

			// Search ProductGroup AutoComplete
			if(SearchBox.Text.Length >= 2)
				labelValuePairs = await ProductGroupManager.SearchAutoCompleteAsync(SearchBox.Text, 10);

			if(labelValuePairs != null && labelValuePairs.Length > 0)
			{
				searchAutoCompleteLb.ItemsSource = labelValuePairs;
				searchAutoCompleteLb.Visibility = Visibility.Visible;
			}
			else
			{
				searchAutoCompleteLb.ItemsSource = null;
				searchAutoCompleteLb.Visibility = Visibility.Collapsed;
			}

		}

		private void SearchBox_KeyDown(object sender, KeyRoutedEventArgs e)
		{
			if(e.Key == VirtualKey.Enter)
			{
				NavigateToSearchPage(SearchBox.Text);
			}

			else if((e.Key == VirtualKey.Down || e.Key == VirtualKey.Tab) && searchAutoCompleteLb.Items.Count != 0)
			{
				if(searchAutoCompleteLb.SelectedIndex == -1)
					searchAutoCompleteLb.SelectedIndex = 0;

				if(e.Key != VirtualKey.Tab)
					searchAutoCompleteLb.Focus(FocusState.Programmatic);
			}
		}

		private void searchAutoCompleteLb_KeyUp(object sender, KeyRoutedEventArgs e)
		{
			//if(e.Key == VirtualKey.Down || e.Key == VirtualKey.Tab)
			//{
			//	searchAutoCompleteLb.SelectedIndex =
			//		searchAutoCompleteLb.SelectedIndex == searchAutoCompleteLb.Items.Count -1
			//			? 0
			//			: searchAutoCompleteLb.SelectedIndex + 1;
			//}
			//else 
			//if(e.Key == VirtualKey.Up)
			//{
			//	if(searchAutoCompleteLb.SelectedIndex == 0)
			//		SearchBox.Focus(FocusState.Programmatic);
			//}
			//else 
			if (e.Key == VirtualKey.Enter)
			{
				searchAcItemSelected();
			}
		}

		private void searchAutoCompleteLb_DoubleTapped(object sender, DoubleTappedRoutedEventArgs e)
		{
			searchAcItemSelected();
		}

		private void searchAcItemSelected()
		{
			var selected = searchAutoCompleteLb.SelectedItem as LabelValuePair;
			if(selected != null)
				NavigateToProductGroupPage(selected.value);
		}

		private void searchAutoCompleteLb_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
		//	//if(searchAutoCompleteLb.ItemsSource != null)
		//	//	if (searchAutoCompleteLb.SelectedIndex != -1)

		//	var selected = searchAutoCompleteLb.SelectedItem as LabelValuePair;
		//	if(selected != null)
		//		NavigateToProductGroupPage(selected.value);
		}

		#endregion

		private void pageRoot_KeyUp(object sender, KeyRoutedEventArgs e)
		{
			e.ApplyKeyStrokes(NavigationHelper);
		}

		private void searchAutoCompleteLb_LostFocus(object sender, RoutedEventArgs e)
		{
			//todo balázsnál ez ki van szedve
			if(SearchBox.FocusState == FocusState.Unfocused)
				searchAutoCompleteLb.Visibility = Visibility.Collapsed;
		}

		private void SearchBox_LostFocus(object sender, RoutedEventArgs e)
		{
			//if(searchAutoCompleteLb.FocusState == FocusState.Unfocused)
			//	searchAutoCompleteLb.Visibility = Visibility.Collapsed;
		}

		private void pageTitle_PointerPressed(object sender, PointerRoutedEventArgs e)
		{
			semanticZoom.ToggleActiveView();
		}

		private void HomeButton_Click(object sender, RoutedEventArgs e)
		{
			this.Frame.Navigate(typeof(CategoryPage));
		}

	}
}