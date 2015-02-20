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
using WinPhoneClientProxy.WcfProxy;
using WinPhoneCommon;

namespace WindowsPhone
{
	public partial class EditProfile : AuthPage
	{
		public ProfileVM ProfileVm { get; set; }

		public EditProfile()
		{
			ProfileVm = Profile.ProfileVm ?? new ProfileVM();
			InitializeComponent();
			OnOffControls = ContentPanel.Children.OfType<Control>();
		}

		protected override void OnNavigatedTo(NavigationEventArgs e)
		{
			base.OnNavigatedTo(e);

			ProfileVm.LoadData();
		}

		private void SaveChanges_Click(object sender, RoutedEventArgs e)
		{
			OnOffControls.TurnOff();

			Action successfulAction = () => Dispatcher.BeginInvoke(
				() =>
				{
					MessageBox.Show("Sikeres adatmódosítás!");
					if(NavigationService.CanGoBack)
						NavigationService.GoBack();
				});

			Action<WebException> handleErrors = wex => Dispatcher.BeginInvoke(
				() =>
				{
					MessageBox.Show("Nem sikerült módosítani az adataid. Ellenőrizd, hogy érvényes e-mail címet/telefon számot adtál-e meg. Ha így van, valószínűleg már foglalt az általad választott e-mail cím.");
					OnOffControls.TurnOn();
				});

			Services.UserProfileManagerClient.Update(ProfileVm.UserProfile.Core, successfulAction, handleErrors);
		}
	}
}