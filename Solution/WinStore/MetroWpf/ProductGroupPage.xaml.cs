using System.Threading.Tasks;
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
// The Group Detail Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234229
using WinStoreClientProxy;

namespace MetroWpf
{
	public sealed partial class ProductGroupPage : Page
	{
		public NavigationHelper NavigationHelper { get; set; }

		public BookRowPLVM BookRowPlvm { get; set; }

		public ProductGroupPage()
		{
			this.InitializeComponent();
			this.NavigationHelper = new NavigationHelper(this);
			this.NavigationHelper.LoadState += navigationHelper_LoadState;
		}

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
		private async void navigationHelper_LoadState(object sender, LoadStateEventArgs e)
		{
			var fullDetailedProductGroups = await ProductGroupManager.GetFullDetailedAsync((String)e.NavigationParameter, 1, 100);
			BookRowPlvm = fullDetailedProductGroups;
			pageRoot.DataContext = BookRowPlvm;
		}

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

		private void pageRoot_KeyUp(object sender, KeyRoutedEventArgs e)
		{
			e.ApplyKeyStrokes(NavigationHelper);
		}

		private void HomeButton_Click(object sender, RoutedEventArgs e)
		{
			this.Frame.Navigate(typeof(CategoryPage));
		}
	}
}