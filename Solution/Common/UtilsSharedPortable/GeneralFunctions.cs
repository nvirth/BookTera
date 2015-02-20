using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using UtilsSharedPortable;

namespace UtilsSharedPortable
{
	public static class GeneralFunctions
	{		
		// -- Properties, Fields

		public static readonly Random Random = new Random(DateTime.Now.Millisecond);

		// -- Methods

		#region DateTime

		public static DateTime GetRandomDateTimeBetween(DateTime dateTime1, DateTime dateTime2)
		{
			TimeSpan deltaTime = (dateTime2 - dateTime1).Duration();
			var plusRandomTime = new DateTime().AddDays(Random.Next(0, deltaTime.Days)).AddHours(Random.Next(0, deltaTime.Hours)).AddMinutes(Random.Next(0, deltaTime.Minutes)).AddSeconds(Random.Next(0, deltaTime.Seconds)) - new DateTime();

			if(dateTime1 < dateTime2)
				return dateTime1.Add(plusRandomTime);
			else
				return dateTime2.Add(plusRandomTime);
		}

		public static DateTime GetRandomDateTimeBetween2mins1max(DateTime earlier1, DateTime earlier2, DateTime later)
		{
			DateTime earlier = earlier1 > earlier2 ? earlier1 : earlier2;
			if(later < earlier)
				throw new ArgumentException("Az elvileg későbbi dátum korábbi, mint az elvileg korábbi dátum. ");

			return GetRandomDateTimeBetween(earlier, later);
		}

		public static bool CheckDateTimes_2earlier1later(DateTime earlier1, DateTime earlier2, DateTime later)
		{
			DateTime earlier = earlier1 > earlier2 ? earlier1 : earlier2;
			if(later < earlier)
				return false;

			return true;
		}

		#endregion

		#region CultureInfo

		public static void SetDefaultCultureToEnglish_OnlyCultureInfo()
		{
			CultureInfo.DefaultThreadCurrentCulture = Constants.CultureInfoEn;
			CultureInfo.DefaultThreadCurrentUICulture = Constants.CultureInfoEn;
		}

		public static void SetDefaultCultureToHungarian_OnlyCultureInfo()
		{
			CultureInfo.DefaultThreadCurrentCulture = Constants.CultureInfoHu;
			CultureInfo.DefaultThreadCurrentUICulture = Constants.CultureInfoHu;
		}

		#endregion

		#region GetNameOfThisMethod

		/// <summary>
		/// Returns the name of the caller method, if the input string is null. 
		/// (Othervise returns the input string)
		/// </summary>
		public static string GetNameOfThisMethod([CallerMemberName] string leaveThisNull = null)
		{
			return leaveThisNull;
		}

		#endregion
	}
}
