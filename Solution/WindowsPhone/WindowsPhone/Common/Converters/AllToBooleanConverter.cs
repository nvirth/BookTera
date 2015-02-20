using System;
using System.Globalization;
using System.Windows.Data;

namespace WindowsPhone.Common.Converters
{
	/// <summary>
	/// Converts to bool:
	/// - (null)
	/// - (Bool)
	/// - String
	/// - Int (-2, -1, 0: false; Greater: true)
	/// 
	/// else: true
	/// 
	/// It can be extended if needed :)
	/// </summary>
	public sealed class AllToBooleanConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (value == null)
				return false;

			if (value is bool)
				return (bool) value;

			if (value is string)
				return !string.IsNullOrWhiteSpace(value as string);

			if (value is int)
				return ((int) value) > 0;

			return true;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
