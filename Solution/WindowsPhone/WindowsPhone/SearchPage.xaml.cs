using System;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Navigation;
using WindowsPhone.Common.PageBase;
using WindowsPhone.ViewModels;
using Microsoft.Phone.Controls;
using UtilsSharedPortable;

namespace WindowsPhone
{
	public partial class SearchPage : BookteraPageBase
	{
		public SearchPageVM ViewModel { get; private set; }

		public bool IsForAddingToExchangeCart { get; set; }

		/// <summary>
		/// This is for App.xaml, for AddToExchange
		/// </summary>
		public static int ExchangeCartUserOrderId { get; set; }

		public SearchPage()
		{
			ViewModel = new SearchPageVM();
			InitializeComponent();
		}

		private void SearchBox_KeyDown(object sender, KeyEventArgs e)
		{
			if(e.Key == Key.Enter)
				ViewModel.Search(((PhoneTextBox)sender).Text);
		}

		private void SearchBox_OnActionIconTapped(object sender, EventArgs e)
		{
			ViewModel.Search(((PhoneTextBox)sender).Text);
		}

		protected override void OnNavigatedTo(NavigationEventArgs e)
		{
			base.OnNavigatedTo(e);
			if(NavigationContext.QueryString.ContainsKey("userFu"))
			{
				if (NavigationContext.QueryString.ContainsKey("forExchange"))
				{
					IsForAddingToExchangeCart = bool.Parse(NavigationContext.QueryString["forExchange"]);
					ExchangeCartUserOrderId = int.Parse(NavigationContext.QueryString["userOrderId"]);
				}

				var userFu = NavigationContext.QueryString["userFu"];
				var userName = NavigationContext.QueryString["userName"];
				InitPageForUsersProducts(userFu, userName);
			}
		}

		/// <summary>
		/// Transforms the page from SearchPage to UserProductsPage. 
		/// This 2 are very similar :)
		/// </summary>
		private void InitPageForUsersProducts(string userFu, string userName)
		{
			SearchBox.Visibility = Visibility.Collapsed;
			PageTitle.Text = string.Format("{0} KÖNYVEI", userName.ToUpper());

			BindingOperations.SetBinding(Page, DataContextProperty, new Binding("UsersProducts.Products")
			{
				Source = ViewModel,
			});

			ViewModel.LoadUsersBooks(userFu);
		}
	}
}