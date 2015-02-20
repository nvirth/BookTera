using System;
using System.Collections.Generic;
using System.Configuration;
using CommonPortable.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using UtilsShared;
using UtilsSharedPortable;

namespace UtilsLocal.Log
{
	public static class ExceptionHelpers
	{
		#region AddBookteraExceptionCode

		public static void AddBookteraExceptionCode(this Exception e, BookteraExceptionCode bookteraExceptionCode, string message)
		{
			e.AddBookteraExceptionCode(bookteraExceptionCode);

			var messageKey = string.Format("-- {0} message: ", bookteraExceptionCode);
			e.AddData(messageKey, message);
		}

		public static void AddBookteraExceptionCode(this Exception e, BookteraExceptionCode bookteraExceptionCode)
		{
			List<BookteraExceptionCode> codes;
			if(e.Data.Keys.Contains(Config.BOOKTERA_EXCEPTION_CODE_FIELD_NAME))
			{
				codes = (List<BookteraExceptionCode>)e.Data[Config.BOOKTERA_EXCEPTION_CODE_FIELD_NAME];
			}
			else
			{
				codes = new List<BookteraExceptionCode>();
				e.Data[Config.BOOKTERA_EXCEPTION_CODE_FIELD_NAME] = codes;
			}

			codes.Insert(0, bookteraExceptionCode);

		}

		#endregion

		#region AddData

		/// <summary>
		/// Adds data to the Exception's Data (IDictionary) property.
		/// The key will be the name of the object value's type.
		/// </summary>
		public static void AddData(this Exception e, object value)
		{
			e.AddData(value.GetType().Name, value);
		}

		public static void AddData(this Exception e, string key, object value)
		{
			// Serializing the object value
			var stringValue = value.SerializeToLog();

			// If the key already exist in the exception's data dictionary, rename it
			if(e.Data.Keys.Contains(key))
			{
				if(e.Data[key].Equals(stringValue))
				{
					return;
				}
				else
				{
					var randomInt = new Random(DateTime.Now.Millisecond).Next(99999);
					e.AddData(key + "-multipleKey-" + randomInt, stringValue);
					return;
				}
			}
			else // If the key not existed yet, we can add it
			{
				e.Data.Add(key, stringValue);
			}
		}

		#endregion

		#region SerializeToLog

		/// <summary>
		/// Use this to convert enums to string (instead of int) while json serializing
		/// </summary>
		private static readonly StringEnumConverter _stringEnumConverter =
			new StringEnumConverter
			{
				CamelCaseText = true
			};

		public static string SerializeToLog(this object value)
		{
			string stringValue = null;

			// If the object value is a simple type, "serialize" it with a .ToString call
			if(value.GetType().IsValueType || (value is string))
			{
				stringValue = value.ToString();
			}
			else // If the object value is a complex type, serialize it (normally)
			{
				switch(Config.BookteraLogDataMode)
				{
					case BookteraLogDataModeEnum.Json:
						stringValue = JsonConvert.SerializeObject(value, Formatting.Indented, _stringEnumConverter);
						break;

					case BookteraLogDataModeEnum.Xml:
						stringValue = value.ToXml().ToString();
						break;

					default:
						throw new NotImplementedException("The SerializeToLog is not implemented to this log mode: " + Config.BookteraLogDataMode);
				}
			}

			return stringValue;
		}

		#endregion
	}
}
