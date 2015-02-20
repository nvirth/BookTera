using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using WindowsPhone.Common;
using WindowsPhone.Common.PageBase;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using WinPhoneClientProxy.WcfProxy;
using WinPhoneCommon;

namespace WindowsPhone
{
	public partial class Register : BookteraPageBase
	{
		public readonly List<Control> OnOffControls;
		private bool fromLogin = false;

		public Register()
		{
			InitializeComponent();

			OnOffControls = new List<Control>()
			{
				btnRegister,
				TbPassword,
				TbUserName,
				TbEmail,
				TbPasswordRepeat,
			};
		}

		private void ActivateTestDataIfDebug()
		{
#if DEBUG
			var num = new Random((int)DateTime.Now.Ticks).Next(123456);

			TbPassword.Password = string.IsNullOrWhiteSpace(TbPassword.Password) ? "asdqwe123" : TbPassword.Password;
			TbPasswordRepeat.Password = TbPassword.Password;
			TbUserName.Text = string.IsNullOrWhiteSpace(TbUserName.Text) ? "test" : TbUserName.Text;
			TbUserName.Text += num;
			TbEmail.Text = TbUserName.Text + "@test.com";
#endif
		}

		protected override void OnNavigatedTo(NavigationEventArgs e)
		{
			base.OnNavigatedTo(e);

			if(NavigationContext.QueryString.ContainsKey("username"))
				TbUserName.Text = NavigationContext.QueryString["username"];
			if(NavigationContext.QueryString.ContainsKey("password"))
				TbPassword.Password = NavigationContext.QueryString["password"];
			if (NavigationContext.QueryString.ContainsKey("fromLogin"))
				fromLogin = true;

			ActivateTestDataIfDebug();
		}

		private void DoRegister(string userName, string email, string password, string passwordRepeat)
		{
			if(DoRegister_Validate(userName, email, password, passwordRepeat))
				return;

			OnOffControls.TurnOff();

			// After a successful registration, try to log in the user
			Action successfullyRegistration = () => Dispatcher.BeginInvoke(
				() =>
				{
					MessageBox.Show("Sikeres regisztráció! A rendszer most automatikusan be fog léptetni. ");

					// Remove the Login page before
					if(fromLogin && NavigationService.CanGoBack)
						NavigationService.RemoveBackEntry();

					var url = string.Format("/Login.xaml?username={0}&password={1}&backFromRegister=true", TbUserName.Text, TbPassword.Password);
					NavigationService.Navigate(new Uri(url, UriKind.Relative));
				});

			// If the registration was not successful
			Action<WebException> handleRegErrors = webException => Dispatcher.BeginInvoke(
				() =>
				{
					// todo
					MessageBox.Show("A regisztráció nem sikerült. Ellenőrizd, hogy érvényes e-mail címet adtál-e meg, esetleg próbálkozz más felhasználó névvel. ");
					OnOffControls.TurnOn();
				});

			Services.RegistrationClient.Register(userName, email, password, passwordRepeat,
				successfullyRegistration, handleRegErrors);
		}

		private static bool DoRegister_Validate(string userName, string email, string password, string passwordRepeat)
		{
			if(string.IsNullOrWhiteSpace(userName) || string.IsNullOrWhiteSpace(password)
				|| string.IsNullOrWhiteSpace(passwordRepeat) || string.IsNullOrWhiteSpace(email))
			{
				MessageBox.Show("Egyik beviteli mező sem lehet üres.");
				return true;
			}

			if(password != passwordRepeat)
			{
				MessageBox.Show("A jelszó és az ellenőrző jelszó nem egyeznek meg.");
				return true;
			}
			return false;
		}

		private void Register_Click(object sender, RoutedEventArgs e)
		{
			DoRegister(TbUserName.Text, TbEmail.Text, TbPassword.Password, TbPasswordRepeat.Password);
		}
	}
}