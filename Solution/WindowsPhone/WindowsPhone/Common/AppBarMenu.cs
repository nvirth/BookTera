using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using WindowsPhone.Common.PageBase;
using Coding4Fun.Toolkit.Controls;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using WinPhoneClientProxy.WcfProxy;
using WinPhoneCommon;

namespace WindowsPhone.Common
{
	public static class AppBarMenu
	{
		#region Members

		public static IApplicationBar ApplicationBar { get; private set; }
		private static List<ApplicationBarMenuItem> AnonimMenuItems { get; set; }
		private static List<ApplicationBarMenuItem> LoggedInMenuItems { get; set; }
		private static List<ApplicationBarIconButton> AnonimIcons { get; set; }
		private static List<ApplicationBarIconButton> LoggedInIcons { get; set; }

		#endregion

		#region Init

		public static void Init(IApplicationBar applicationBar)
		{
			ApplicationBar = applicationBar;

			InitMenuItems();
			InitIcons();

			SetAppBarToAnonim();
		}

		private static void InitIcons()
		{
			var categories = new ApplicationBarIconButton()
			{
				IconUri = new Uri("/Assets/folder.png", UriKind.Relative),
				Text = "kategóriák"
			};
			var search = new ApplicationBarIconButton()
			{
				IconUri = new Uri("/Assets/feature.search.png", UriKind.Relative),
				Text = "keresés"
			};
			var buy = new ApplicationBarIconButton()
			{
				IconUri = new Uri("/Assets/cart.png", UriKind.Relative),
				Text = "vásárlás"
			};
			var login = new ApplicationBarIconButton()
			{
				IconUri = new Uri("/Assets/login.png", UriKind.Relative),
				Text = "belépés"
			};

			categories.Click += CategoriesClick;
			search.Click += SearchClick;
			buy.Click += BuyClick;
			login.Click += Login_Click;

			AnonimIcons = new List<ApplicationBarIconButton>()
			{
				login,
				search,
				categories,
			};
			LoggedInIcons = new List<ApplicationBarIconButton>()
			{
				buy,
				search,
				categories,
			};

		}

		private static void InitMenuItems()
		{
			var profile = new ApplicationBarMenuItem("profilom");
			var logout = new ApplicationBarMenuItem("kijelentkezés");
			var registration = new ApplicationBarMenuItem("regisztráció");
			var sell = new ApplicationBarMenuItem("eladás");

			profile.Click += Settings_Click;
			logout.Click += Logout_Click;
			registration.Click += RegistrationClick;
			sell.Click += Sell_Click;

			AnonimMenuItems = new List<ApplicationBarMenuItem>()
			{
				registration,
			};
			LoggedInMenuItems = new List<ApplicationBarMenuItem>()
			{
				profile,
				sell,
				logout,
			};
		}

		#endregion

		#region SetAppBarTo...

		public static void SetAppBarToLoggedIn()
		{
			ApplicationBar.MenuItems.Clear();
			ApplicationBar.Buttons.Clear();

			LoggedInMenuItems.ForEach(menuItem => ApplicationBar.MenuItems.Add(menuItem));
			LoggedInIcons.ForEach(icon => ApplicationBar.Buttons.Add(icon));

		}

		public static void SetAppBarToAnonim()
		{
			ApplicationBar.MenuItems.Clear();
			ApplicationBar.Buttons.Clear();

			AnonimMenuItems.ForEach(menuItem => ApplicationBar.MenuItems.Add(menuItem));
			AnonimIcons.ForEach(icon => ApplicationBar.Buttons.Add(icon));
		}

		#endregion

		#region Click Handlers

		static void RegistrationClick(object sender, EventArgs e)
		{
			var frame = (PhoneApplicationFrame)Application.Current.RootVisual;
			frame.Navigate(new Uri("/Register.xaml", UriKind.Relative));
		}

		private static void Login_Click(object sender, EventArgs e)
		{
			var frame = (PhoneApplicationFrame)Application.Current.RootVisual;
			frame.Navigate(new Uri("/Login.xaml", UriKind.Relative));
		}

		private static void Settings_Click(object sender, EventArgs e)
		{
			var frame = (PhoneApplicationFrame)Application.Current.RootVisual;
			frame.Navigate(new Uri("/Profile.xaml", UriKind.Relative));
		}

		private static void Logout_Click(object sender, EventArgs e)
		{
			Action successfulAction =
				() =>
				{
					Deployment.Current.Dispatcher.BeginInvoke(
						() =>
						{
							SetAppBarToAnonim();

							StaticData.UserData.IsAuthenticated = false;
							StaticData.UserData.UserName = "";

							// Step back one, if it's an auth required page (this step will start a chain back-process)
							var frame = (PhoneApplicationFrame)Application.Current.RootVisual;
							var authPage = frame.Content as AuthPage;
							if(authPage!=null && frame.CanGoBack)
							{
								if(authPage.OnOffControls != null)
									authPage.OnOffControls.TurnOff();

								frame.GoBack();
							}
						});

					// Wait a bit before starting the prompt, otherwise it will not take any effect
					Thread.Sleep(500);

					// Show feedback from successful logout
					Deployment.Current.Dispatcher.BeginInvoke(
						() => new ToastPrompt()
						{
							Message = "Sikeresen kijelentkeztél.",
						}.Show());
				};

			Services.AuthenticationClient.Logout(successfulAction);
		}

		static void Sell_Click(object sender, EventArgs e)
		{
			var frame = (PhoneApplicationFrame)Application.Current.RootVisual;
			frame.Navigate(new Uri("/TransactionListPage.xaml?IsBuy=false", UriKind.Relative));
		}

		static void BuyClick(object sender, EventArgs e)
		{
			var frame = (PhoneApplicationFrame)Application.Current.RootVisual;
			frame.Navigate(new Uri("/TransactionListPage.xaml?IsBuy=true", UriKind.Relative));
		}

		static void SearchClick(object sender, EventArgs e)
		{
			var frame = (PhoneApplicationFrame)Application.Current.RootVisual;
			frame.Navigate(new Uri("/SearchPage.xaml", UriKind.Relative));
		}

		static void CategoriesClick(object sender, EventArgs e)
		{
			var frame = (PhoneApplicationFrame)Application.Current.RootVisual;
			frame.Navigate(new Uri("/CategoryPage.xaml", UriKind.Relative));
		}

		#endregion
	}
}
