using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Phone.Controls;
using WinPhoneCommon;

namespace WindowsPhone.Common
{
	public class StaticData
	{
		static StaticData()
		{
			ThemeSwitchData = ThemeSwitchDataCore.Instace;
			UserData = UserDataCore.Instace;
		}

		public static ThemeSwitchDataCore ThemeSwitchData { get; private set; }
		public static UserDataCore UserData { get; private set; }

		/// <summary>
		/// This is a helper for the global context menu in App.xaml. This indicates whenever
		/// the product can be added to an Exchange cart. This is possible only, if one is
		/// at the SearchPage, and went with the flag 'forExchange' true
		/// </summary>
		public static bool IsAddToExchangeCartPossible
		{
			get
			{
				var searchPage = ((PhoneApplicationFrame)Application.Current.RootVisual).Content as SearchPage;
				if(searchPage == null)
					return false;

				return searchPage.IsForAddingToExchangeCart;
			}
		}

		#region Inner classes

		public class ThemeSwitchDataCore : NotifyPropertyChanged
		{
			private ThemeSwitchDataCore()
			{
			}

			public static readonly ThemeSwitchDataCore Instace = new ThemeSwitchDataCore();

			#region PanoramaBackground

			private string _panoramaBackground = @"/WindowsPhone;component/Assets/background.png";

			public string PanoramaBackground
			{
				get { return _panoramaBackground; }
				private set
				{
					if(value == _panoramaBackground)
						return;
					_panoramaBackground = value;
					OnPropertyChanged();
				}
			}

			#endregion

			#region ContextMenuCart

			private string _contextMenuCart = @"Assets\cart.contextMenu.png";

			public string ContextMenuCart
			{
				get { return _contextMenuCart; }
				private set
				{
					if(value == _contextMenuCart)
						return;
					_contextMenuCart = value;
					OnPropertyChanged();
				}
			}

			#endregion

			public void SetDarkTheme()
			{
				ContextMenuCart = @"Assets\cart.contextMenu.png";
				PanoramaBackground = @"/WindowsPhone;component/Assets/background.png";
			}

			public void SetLightTheme()
			{
				ContextMenuCart = @"Assets\cart.contextMenu.light.png";
				PanoramaBackground = @"/WindowsPhone;component/Assets/background.light.png";
			}
		}

		public class UserDataCore : NotifyPropertyChanged
		{
			private UserDataCore()
			{
			}

			public static readonly UserDataCore Instace = new UserDataCore();

			#region IsUserAuthenticated/Anonim

			private bool isAuthenticated = false;

			public bool IsAuthenticated
			{
				get { return isAuthenticated; }
				set
				{
					if(value.Equals(isAuthenticated))
						return;
					isAuthenticated = value;
					OnPropertyChanged();
					OnPropertyChanged("IsUserAnonim");
				}
			}

			public bool IsUserAnonim
			{
				get { return !isAuthenticated; }
			}

			#endregion

			#region UserId

			private int _userId;

			public int UserId
			{
				get
				{
					return _userId;
				}
				set
				{
					if(value == _userId)
						return;
					_userId = value;
					OnPropertyChanged();
				}
			}

			#endregion

			#region UserName

			private string _userName;

			public string UserName
			{
				get
				{
					return _userName;
				}
				set
				{
					if(value == _userName)
						return;
					_userName = value;
					OnPropertyChanged();
				}
			}

			#endregion
		}

		#endregion
	}
}
