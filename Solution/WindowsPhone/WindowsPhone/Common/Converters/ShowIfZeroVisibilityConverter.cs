using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace WindowsPhone.Common.Converters
{
	/// <summary>
	/// Translates the 0 int value to <see cref="Visibility.Visible"/>.
	/// Returns <see cref="Visibility.Collapsed"/> otherwise.
	/// </summary>
	public sealed class ShowIfZeroVisibilityConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			var intValue = value as int?;
			if (intValue.HasValue && intValue.Value == 0)
				return Visibility.Visible;

			return Visibility.Collapsed;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
