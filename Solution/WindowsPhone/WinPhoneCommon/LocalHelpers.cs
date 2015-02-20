using System.Collections.Generic;
using System.Net;
using System.Windows.Controls;

namespace WinPhoneCommon
{
	public static class LocalHelpers
	{
		#region IEnumerable<Control>

		public static void TurnOff(this IEnumerable<Control> list)
		{
			foreach (var control in list)
			{
				control.IsEnabled = false;
			}
		}

		public static void TurnOn(this IEnumerable<Control> list)
		{
			foreach(var control in list)
			{
				control.IsEnabled = true;
			}
		}

		#endregion

		#region String

		public static string UrlEncode(this string text)
		{
			return HttpUtility.UrlEncode(text);
		}

		#endregion

	}
}
