using System;
using System.Text;

namespace UtilsLocal.WCF.QueryStringConverterExtension.Steps
{
	//todo string[] --> array

	/// <summary>
	/// A Custom QueryString Converter osztályokat leszármazási láncba szervezni szükséges.
	/// Array --> Nullable --> Standard
	/// </summary>
	public class ArrayQueryStringConverter : NullableQueryStringConverter
	{
		public override bool CanConvert(Type type)
		{
			if(type.IsArray)
				return base.CanConvert(type.GetElementType());

			return base.CanConvert(type);
		}

		public override object ConvertStringToValue(string parameter, Type parameterType)
		{
			if(parameterType.IsArray)
			{
				Type elementType = parameterType.GetElementType();
				string[] parameterList = parameter.Split(',');
				Array result = Array.CreateInstance(elementType, parameterList.Length);
				for(int i = 0; i < parameterList.Length; i++)
				{
					result.SetValue(base.ConvertStringToValue(parameterList[i], elementType), i);
				}

				return result;
			}

			//if(parameterType == typeof(string[]))
			//{
			//	string[] parms = parameter.Split(',');
			//	return parms;
			//}

			return base.ConvertStringToValue(parameter, parameterType);
		}

		public override string ConvertValueToString(object parameter, Type parameterType)
		{
			if(parameterType.IsArray)
			{
				var stringBuilder = new StringBuilder();
				foreach(var item in parameter as Array)
				{
					stringBuilder.Append(item.ToString()).Append(',');
				}
				stringBuilder.Remove(stringBuilder.Length - 1, 1); // utolsó vessző

				return stringBuilder.ToString();
			}

			return base.ConvertValueToString(parameter, parameterType);
		}
	}
}
