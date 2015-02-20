using System;
using System.Globalization;
using System.Windows.Data;

namespace WindowsPhone.Common.Converters
{
	public sealed class BooleanAndConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			var boolValue = value as bool?;
			if(!boolValue.HasValue)
				return false;

			var boolParam = parameter as bool?;
			if(boolParam.HasValue)
				return boolValue.Value && boolParam.Value;

			var dependencyBooleanParam = parameter as DependencyBoolean;
			if (dependencyBooleanParam != null)
				return dependencyBooleanParam.Value && boolValue.Value;

			return false;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
