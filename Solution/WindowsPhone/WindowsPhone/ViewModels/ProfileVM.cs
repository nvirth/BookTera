using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WindowsPhone.Common;
using CommonModels.Models;
using WinPhoneClientProxy.WcfProxy;
using WinPhoneCommon;
using WinPhoneCommon.Models;

namespace WindowsPhone.ViewModels
{
	public class ProfileVM : NotifyPropertyChanged
	{
		#region UserData

		private string _actualUserName;

		private bool _isUserDataLoaded;
		public bool IsUserDataLoaded
		{
			get { return _isUserDataLoaded && _actualUserName == StaticData.UserData.UserName; }
		}

		private UserProfileEditVmObservable _userProfile;
		public UserProfileEditVmObservable UserProfile
		{
			get { return _userProfile; }
			set
			{
				if(Equals(value, _userProfile))
					return;
				_userProfile = value;
				OnPropertyChanged();
			}
		}

		#endregion

		public ProfileVM()
		{
			LoadData();
		}

		public void LoadData()
		{
			if(!IsUserDataLoaded)
				LoadUserData();
		}

		public void LoadUserData()
		{
			Action<UserProfileEditVM> todoWithResult =
				upeVm => Deployment.Current.Dispatcher.BeginInvoke(() => UserProfile = new UserProfileEditVmObservable(upeVm));

			Services.UserProfileManagerClient.GetForEdit(todoWithResult);
			_isUserDataLoaded = true;
			_actualUserName = StaticData.UserData.UserName;
		}
	}
}
