using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace WindowsPhone.Common.Converters
{
	/// <summary>
	/// Translates null-or-white-space strings to <see cref="Visibility.Collapsed"/>.
	/// Returns <see cref="Visibility.Collapsed"/> if the input is not string as well.
	/// Returns <see cref="Visibility.Visible"/> otherwise.
	/// </summary>
	public sealed class HideEmptyStringVisibilityConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			var str = value as string;
			if (string.IsNullOrWhiteSpace(str))
				return Visibility.Collapsed;

			return Visibility.Visible;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
