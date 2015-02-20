using System;
using CommonPortable.Enums;

namespace CommonPortable.Exceptions
{
	public class BookteraException : Exception
	{
		public BookteraExceptionCode Code { get; private set; }

		public BookteraException(string message = null, Exception innerException = null, BookteraExceptionCode code = BookteraExceptionCode.None)
			: base(message, innerException)
		{
			Code = code;
		}
	}
}
