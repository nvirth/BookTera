using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;

namespace MetroWpf.Common
{
	public static class UtilsLocal
	{
		public static void ApplyKeyStrokes(this KeyRoutedEventArgs e, NavigationHelper navigationHelper)
		{
			var notFromTextBox = e.OriginalSource.GetType() != typeof(TextBox);

			if(e.Key == VirtualKey.Right && notFromTextBox)
			{
				navigationHelper.GoForward();
			}
			if(e.Key == VirtualKey.Left && notFromTextBox)
			{
				navigationHelper.GoBack();
			}
			if(e.Key == VirtualKey.Back && notFromTextBox)
			{
				navigationHelper.GoBack();
			}
			if(e.Key == VirtualKey.Escape && notFromTextBox)
			{
				Application.Current.Exit();
			}
		}
	}
}
