using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using WindowsPhone.Common;
using WindowsPhone.Common.PageBase;
using Coding4Fun.Toolkit.Controls;
using DAL.PushNotification;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using WinPhoneClientProxy.WcfProxy;
using WinPhoneCommon;

namespace WindowsPhone
{
	public partial class Login : BookteraPageBase
	{
		public readonly List<Control> OnOffControls;

		public Login()
		{
			InitializeComponent();

			OnOffControls = new List<Control>()
			{
				btnLogin,
				btnRegister,
				TbPassword,
				TbUserName,
			};

			ActivateTestDataIfDebug();
		}

		private void ActivateTestDataIfDebug()
		{
#if DEBUG
			TbUserName.Text = "ZomiDudu";
			TbPassword.Password = "asdqwe123";
#endif
		}

		private void Login_Click(object sender, RoutedEventArgs e)
		{
			DoLogin(TbUserName.Text, TbPassword.Password);
		}

		private void DoLogin(string userName, string password)
		{
			if(string.IsNullOrWhiteSpace(userName) || string.IsNullOrWhiteSpace(password))
			{
				MessageBox.Show("Felhasználó név és/vagy jelszó nem lehet üres.");
				return;
			}

			OnOffControls.TurnOff();

			Services.AuthenticationClient.Login(userName, password, false,
				response =>
				{
					if(response.wasSuccessful)
					{
						Dispatcher.BeginInvoke(
							() =>
							{
								// These are bound in other pages too, they can be called only by Dispatcher
								StaticData.UserData.IsAuthenticated = true;
								StaticData.UserData.UserName = userName;
								StaticData.UserData.UserId = response.userId;

								AppBarMenu.SetAppBarToLoggedIn(); // Refresh the AppBar items

								if(NavigationService.CanGoBack)
									NavigationService.GoBack();
							});

						new TaskFactory().StartNew(
							async () =>
							{
								// Subscribe to push notifications
								try
								{
									await PushNotification.AcquirePushChannel();
								}
								catch(Exception e)
								{
									//Dispatcher.BeginInvoke(() =>
									//	MessageBox.Show("Nem sikerült aktiválni az értesítő szolgáltatást. Próbálj meg kijelentkezni, majd újra bejelentkezni."));
								}
								try
								{
									PushNotification.ResetTile();
								}
								catch(Exception e)
								{
								}
							});

						// Wait a bit before starting the prompt, otherwise it will not take any effect
						Thread.Sleep(500);

						// Show feedback from successful login
						Dispatcher.BeginInvoke(
							() => new ToastPrompt()
							{
								Message = "Sikeres bejelentkezés",
							}.Show());
					}
					else // un-successful login
					{
						Dispatcher.BeginInvoke(
							() =>
							{
								MessageBox.Show("Hibás felhasználó név és/vagy jelszó");
								OnOffControls.TurnOn();
							});
					}
				});
		}

		private void Register_Click(object sender, RoutedEventArgs e)
		{
			var url = string.Format("/Register.xaml?username={0}&password={1}&fromLogin={2}", TbUserName.Text, TbPassword.Password, true);
			NavigationService.Navigate(new Uri(url, UriKind.Relative));
		}

		protected override void OnNavigatedTo(NavigationEventArgs e)
		{
			base.OnNavigatedTo(e);

			// -- Navigated from Register page by code

			if(NavigationContext.QueryString.ContainsKey("username"))
				TbUserName.Text = NavigationContext.QueryString["username"];
			else
				return; // if not from reg.page back, no need to proceed nexts

			if(NavigationContext.QueryString.ContainsKey("password"))
				TbPassword.Password = NavigationContext.QueryString["password"];

			if(NavigationContext.QueryString.ContainsKey("backFromRegister"))
			{
				// Remove the Register page before
				if(NavigationService.CanGoBack)
					NavigationService.RemoveBackEntry();

				DoLogin(TbUserName.Text, TbPassword.Password);
			}

		}
	}
}