using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using WindowsPhone.Common;
using WindowsPhone.Common.PageBase;
using WindowsPhone.ViewModels;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace WindowsPhone
{
	public partial class Profile : AuthPage
	{
		public static ProfileVM ProfileVm { get; private set; }

		public Profile()
		{
			ProfileVm = ProfileVm ?? new ProfileVM();
			InitializeComponent();
			OnOffControls = new List<Control>() { BtnEditProfile };
		}

		protected override void OnNavigatedTo(NavigationEventArgs e)
		{
			base.OnNavigatedTo(e);
			ProfileVm.LoadData();
		}

		private void EditProfileButton_Click(object sender, RoutedEventArgs e)
		{
			NavigationService.Navigate(new Uri("/EditProfile.xaml", UriKind.Relative));
		}
	}
}