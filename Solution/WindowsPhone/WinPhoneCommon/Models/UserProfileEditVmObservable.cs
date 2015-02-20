using CommonModels.Models;

namespace WinPhoneCommon.Models
{
	public class UserProfileEditVmObservable : NotifyPropertyChanged
	{
		public readonly UserProfileEditVM Core;

		public UserProfileEditVmObservable(UserProfileEditVM core)
		{
			Core = core;
		}

		#region Observable Members (public)

		public string PhoneNumber
		{
			get { return phoneNumber; }
			set
			{
				if (value == phoneNumber)
					return;
				phoneNumber = value;
				OnPropertyChanged();
			}
		}

		public string EMail
		{
			get { return eMail; }
			set
			{
				if (value == eMail)
					return;
				eMail = value;
				OnPropertyChanged();
			}
		}

		public string ImageUrl
		{
			get { return imageUrl; }
			set
			{
				if (value == imageUrl)
					return;
				imageUrl = value;
				OnPropertyChanged();
			}
		}

		public string FullName
		{
			get { return fullName; }
			set
			{
				if (value == fullName)
					return;
				fullName = value;
				OnPropertyChanged();
			}
		}

		#endregion

		#region Delegating Members (private)

		private string phoneNumber
		{
			get { return Core.PhoneNumber; }
			set { Core.PhoneNumber = value; }
		}

		private string eMail
		{
			get { return Core.EMail; }
			set { Core.EMail = value; }
		}

		private string imageUrl
		{
			get { return Core.ImageUrl; }
			set { Core.ImageUrl = value; }
		}

		private string fullName
		{
			get { return Core.FullName; }
			set { Core.FullName = value; }
		}

		#endregion

	}
}