using System;
using System.Globalization;
using System.Windows.Data;

namespace WindowsPhone.Common.Converters
{
	public sealed class MultiplicationConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			int intValue = (value as int?) ?? 0;
			int intParameter = (parameter as int?) ?? 0;

			return intValue * intParameter;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
