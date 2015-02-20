using System;
using System.Configuration;
using CommonPortable.Enums;

namespace UtilsLocal.Log
{
	public class Config
	{
		public const string BOOKTERA_EXCEPTION_CODE_FIELD_NAME = "Code";

		public static BookteraLogDataModeEnum BookteraLogDataMode =
			(BookteraLogDataModeEnum)Enum.Parse(
				typeof(BookteraLogDataModeEnum),
				ConfigurationManager.AppSettings["BookteraLogDataMode"] ?? "Json",
			/*ignoreCase*/ true);
	}
}
