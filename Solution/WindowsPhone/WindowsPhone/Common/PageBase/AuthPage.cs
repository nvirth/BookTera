using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using WinPhoneCommon;

namespace WindowsPhone.Common.PageBase
{
	public class AuthPage : BookteraPageBase
	{
		public IEnumerable<Control> OnOffControls;

		protected override void OnNavigatedTo(NavigationEventArgs e)
		{
			base.OnNavigatedTo(e);

			// If the user logged out
			if(!StaticData.UserData.IsAuthenticated && NavigationService.CanGoBack)
			{
				if(OnOffControls != null)
					OnOffControls.TurnOff();

				NavigationService.GoBack();
			}
		}
	}
}
