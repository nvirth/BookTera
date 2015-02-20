using System;
using System.ServiceModel.Dispatcher;

namespace UtilsLocal.WCF.QueryStringConverterExtension.Steps
{
	/// <summary>
	/// A Custom QueryString Converter osztályokat leszármazási láncba szervezni szükséges.
	/// Nullable --> Standard
	/// </summary>
	public class NullableQueryStringConverter : QueryStringConverter
	{
		public override bool CanConvert(Type type)
		{
			var underlyingType = Nullable.GetUnderlyingType(type);

			return (underlyingType != null && base.CanConvert(underlyingType)) || base.CanConvert(type);
		}

		public override object ConvertStringToValue(string parameter, Type parameterType)
		{
			var underlyingType = Nullable.GetUnderlyingType(parameterType);

			// Handle nullable types
			if(underlyingType != null)
			{
				// Define a null value as being an empty or missing (null) string passed as the query parameter value
				return String.IsNullOrEmpty(parameter) ? null : base.ConvertStringToValue(parameter, underlyingType);
			}

			return base.ConvertStringToValue(parameter, parameterType);
		}

		public override string ConvertValueToString(object parameter, Type parameterType)
		{
			var underlyingType = Nullable.GetUnderlyingType(parameterType);

			// Handle nullable types
			if(underlyingType != null)
			{
				// Define a null value as being an empty or missing (null) string passed as the query parameter value
				return parameter == null ? "" : base.ConvertValueToString(parameter, underlyingType);
			}

			return base.ConvertValueToString(parameter, parameterType);
		}
	}
}
