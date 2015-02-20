using System;
using System.Globalization;
using System.Windows.Data;

namespace WindowsPhone.Common.Converters
{
	public sealed class FeedbackBoolConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			switch(value as bool?)
			{
				case null:
					return "-";
				case true:
					return "Sikeres";
				case false:
					return "Sikertelen";
				default:
					throw new Exception();
			}
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
