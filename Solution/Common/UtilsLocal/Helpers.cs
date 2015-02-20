using System;
using System.Collections.Generic;
using System.Configuration;
using CommonPortable.Enums;
using CommonPortable.Exceptions;
using Newtonsoft.Json;
using UtilsShared;
using UtilsSharedPortable;

namespace UtilsLocal
{
	public static class Helpers
	{
		#region ExceptionHelpers

		#region WriteWithInnerMessagesColorful (Console)

		public static void WriteWithInnerMessagesColorful(this Exception e, IList<BookteraExceptionCode> goodExceptionsCodes, IList<BookteraExceptionCode> neutralExceptionsCodes)
		{
			var beforeColor = Console.ForegroundColor;
			e.WriteWithInnerMessagesColorfulRecursive(goodExceptionsCodes, neutralExceptionsCodes);
			Console.ForegroundColor = beforeColor;
		}

		private static void WriteWithInnerMessagesColorfulRecursive(this Exception e, IList<BookteraExceptionCode> goodExceptionsCodes, IList<BookteraExceptionCode> neutralExceptionsCodes, int intend = 1, bool isAlreadyGood = false)
		{
			// End of recursion
			if(e == null)
				return;

			bool needWrite = false;

			// Write actual message with color
			if(!isAlreadyGood)
			{
				var be = e as BookteraException;
				if(be == null)
				{
					Console.ForegroundColor = ConsoleColor.Red;
					needWrite = true;
				}
				else
				{
					if(goodExceptionsCodes.Contains(be.Code))
					{
						Console.ForegroundColor = ConsoleColor.DarkGreen;
						needWrite = true;
						isAlreadyGood = true;
					}
					else if(neutralExceptionsCodes.Contains(be.Code))
					{
						Console.ForegroundColor = ConsoleColor.DarkGray;
					}
					else
					{
						Console.ForegroundColor = ConsoleColor.Red;
						needWrite = true;
					}
				}
			}
			if(needWrite)
				Console.WriteLine(" - ".Repeat(intend) + e.Message);

			// Handle AggregateExceptions
			var ae = e as AggregateException;
			if(ae != null)
			{
				// Call recursive to all inner exceptions
				foreach(var aeInner in ae.InnerExceptions)
				{
					aeInner.WriteWithInnerMessagesColorfulRecursive(goodExceptionsCodes, neutralExceptionsCodes, intend + 1, isAlreadyGood);
				}
			}
			else
			{
				// Call recursive to inner exceptions
				e.InnerException.WriteWithInnerMessagesColorfulRecursive(goodExceptionsCodes, neutralExceptionsCodes, intend + 1, isAlreadyGood);
			}
		}

		#endregion

		#endregion
	}
}
