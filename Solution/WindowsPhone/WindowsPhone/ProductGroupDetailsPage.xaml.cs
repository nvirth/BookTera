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
	public partial class ProductGroupDetailsPage : BookteraPageBase
	{
		public ProductGroupDetailsVM ViewModel { get; private set; }

		public ProductGroupDetailsPage()
		{
			ViewModel = new ProductGroupDetailsVM();
			InitializeComponent();
		}

		protected override void OnNavigatedTo(NavigationEventArgs e)
		{
			base.OnNavigatedTo(e);

			if(NavigationContext.QueryString.ContainsKey("friendlyUrl"))
			{
				var friendlyUrl = NavigationContext.QueryString["friendlyUrl"];
				ViewModel.LoadData(friendlyUrl);
			}
		}
	}
}