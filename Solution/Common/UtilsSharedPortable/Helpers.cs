using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace UtilsSharedPortable
{
	public static class Helpers
	{
		#region Action

		public static void ExecuteWithTimeMeasuring(this Action action, string text)
		{
			var stopwatch = ExecuteWithTimeMeasuring_Start();

			action(); // Itt hajtódik végre a valódi munka!

			ExecuteWithTimeMeasuring_Stop(text, stopwatch);
		}
		public static T ExecuteWithTimeMeasuring<T>(this Func<T> task, string text)
		{
			var stopwatch = ExecuteWithTimeMeasuring_Start();

			T result = task(); // Itt hajtódik végre a valódi munka!

			ExecuteWithTimeMeasuring_Stop(text, stopwatch);

			return result;
		}
		public static async Task ExecuteWithTimeMeasuringAsync(this Task task, string text)
		{
			var stopwatch = ExecuteWithTimeMeasuring_Start();

			await task; // Itt hajtódik végre a valódi munka!

			ExecuteWithTimeMeasuring_Stop(text, stopwatch);
		}
		public static async Task<T> ExecuteWithTimeMeasuringAsync<T>(this Task<T> task, string text)
		{
			var stopwatch = ExecuteWithTimeMeasuring_Start();

			T result = await task; // Itt hajtódik végre a valódi munka!

			ExecuteWithTimeMeasuring_Stop(text, stopwatch);

			return result;
		}

		private static void ExecuteWithTimeMeasuring_Stop(string text, Stopwatch stopwatch)
		{
			stopwatch.Stop();

			var min = stopwatch.Elapsed.Minutes;
			var s = stopwatch.Elapsed.Seconds;
			var ms = stopwatch.Elapsed.Milliseconds;
			var totalUs = (stopwatch.Elapsed.Ticks / 10); // There is 10 ticks in a microSec
			//var us = totalUs - (ms * 1000 + s * 1000000 + min * 60000000);
			var us = totalUs % 1000;
			MessagePresenter.WriteLine(string.Format("{0} {1,3}min {2,3}s {3,3}ms {4,3}us", (text + ":").PadRight(30), min, s, ms, us));
		}
		private static Stopwatch ExecuteWithTimeMeasuring_Start()
		{
			var stopwatch = new Stopwatch();
			stopwatch.Start();
			return stopwatch;
		}

		#endregion

		#region Array

		public static void AllToFalse(this bool[] array)
		{
			for(int i = 0; i < array.Length; i++)
			{
				array[i] = false;
			}
		}

		#endregion

		#region DateTime

		public static string DayIn2Digits(this DateTime dateTime)
		{
			return dateTime.Day.ToString().PadLeft(2, '0');
			//return dateTime.Day < 10 ? "0" + dateTime.Day : dateTime.Day.ToString();
		}

		public static string MonthIn2Digits(this DateTime dateTime)
		{
			return dateTime.Month < 10 ? "0" + dateTime.Month : dateTime.Month.ToString();
		}

		#endregion

		#region ICollection

		/// <summary>
		/// Compares 2 ICollection, with 2x foreach{foreach}. Do not use this, if not necessary. 
		/// (SequenceEqual can faster compare 2 IList [or in LinQ: IEnumerable, but it's slower], 
		///  if those are sorted the same way)
		/// </summary>
		public static bool ContainsSameData<T>(this ICollection<T> left, ICollection<T> right, IEqualityComparer<T> equalityComparer)
		{
			equalityComparer = equalityComparer ?? EqualityComparer<T>.Default;

			foreach(var item in left)
				if(!right.Contains(item, equalityComparer))
					return false;

			foreach(var item in right)
				if(!left.Contains(item, equalityComparer))
					return false;

			return true;
		}

		public static bool Contains(this ICollection iCollection, object value)
		{
			return iCollection.Cast<object>().Contains(value);
		}

		#endregion

		#region IDictionary

		public static void RenameKeyIfExist<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey fromKey, TKey toKey)
		{
			if(dictionary.ContainsKey(fromKey))
				dictionary.RenameKey(fromKey, toKey);
		}

		public static void RenameKey<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey fromKey, TKey toKey)
		{
			TValue value = dictionary[fromKey];
			dictionary.Remove(fromKey);
			dictionary[toKey] = value;
		}

		public static void PlusEqual<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key, TValue value)
		{
			if(dictionary.ContainsKey(key))
			{
				dynamic d1 = dictionary[key];
				dynamic d2 = value;
				dictionary[key] = d1 + d2;
			}
			else
			{
				dictionary[key] = value;
			}
		}

		#endregion

		#region IEnumerable

		public static XElement ToXmlShallow<T>(this IEnumerable<T> listToConvert, Func<T, bool> filter = null, string rootName = "root")
		{
			var list = (filter == null) ? listToConvert : listToConvert.Where(filter);
			return new XElement(rootName,
								(from node in list
								 select new XElement(typeof(T).Name,
													 from subnode in node.GetType().GetRuntimeProperties()
													 select new XElement(subnode.Name, subnode.GetValue(node, null)))));

		}

		public static void ForEach<T>(this IEnumerable<T> source, Action<T> action)
		{
			foreach(T element in source)
				action(element);
		}

		public static void ForEach<T>(this IEnumerable<T> source, Action<T, int> action)
		{
			var i = 0;
			foreach(T element in source)
			{
				action(element, i);
				i++;
			}
		}

		#endregion

		#region IList

		/// <summary>
		/// Insert sorted into already sorted list
		/// </summary>
		public static void InsertIntoSorted<T>(this IList<T> list, T newItem) where T : IComparable<T>
		{
			int i;
			for(i = 0; i < list.Count; i++)
			{
				if(!(list[i].CompareTo(newItem) > 0))
					break;
			}
			list.Insert(i, newItem);
		}

		public static bool SequenceEqual<T>(this IList<T> left, IList<T> right, IEqualityComparer<T> equalityComparer)
			where T : class
		{
			if(ReferenceEquals(left, right))
				return true;

			if(left == null || right == null)
				return false;

			if(left.Count != right.Count)
				return false;

			equalityComparer = equalityComparer ?? EqualityComparer<T>.Default;
			for(int i = 0; i < left.Count; i++)
			{
				if(!equalityComparer.Equals(left[i], right[i]))
					return false;
			}
			return true;
		}

		#endregion

		#region Int

		public static string ToControlledString(this int value, int padTo, string padStr = "0", string separateStr = " ", int groupSize = 3, string endString = "")
		{
			var numberFormatInfo = new NumberFormatInfo
			{
				NumberGroupSeparator = separateStr,
				NumberGroupSizes = new[] { groupSize },
			};

			var numberStr = value.ToString("N0", numberFormatInfo);
			var xxx = new string('x', groupSize);
			var baseStr = ((xxx + " ").Repeat(padTo / groupSize) + xxx).Substring(groupSize - padTo % groupSize);

			var result = numberStr;
			if(numberStr.Length < baseStr.Length)
			{
				var baseStart = baseStr.Substring(0, baseStr.Length - numberStr.Length);
				result = (baseStart + numberStr).Trim().Replace("x", padStr);
			}

			return result + endString;
		}

		public static string ToHuCurrency(this int value)
		{
			var numberFormatInfo = new NumberFormatInfo
			{
				NumberGroupSeparator = ((char)160).ToString(), // &nbsp;
				NumberGroupSizes = new[] { 3 },
			};

			return value.ToString("n0", numberFormatInfo) + ",-";

			//return value.ToString("c0", Constants.CultureInfoHu).Replace(' ', (char)160); // char 160 <-- &nbsp;
		}

		#endregion

		#region Object

		/// <summary>
		/// Don't use this; there is a better version in UtilsShared
		/// </summary>
		public static XElement ToShallowXml(this object obj)
		{
			IEnumerable<XElement> xElements =
				from property in obj.GetType().GetRuntimeProperties()
				select new XElement(property.Name, property.GetValue(obj));

			return new XElement(obj.GetType().Name, xElements);
		}

		#endregion

		#region Property

		/// <summary>
		///  Visszaadja a beadott property nevét string-ben (így erősen típusosan lehet leírni)
		/// </summary>
		public static string Property<TClass, TProperty>(this TClass tClass, Expression<Func<TClass, TProperty>> property)
		{
			var memberExpression = property.Body as MemberExpression;
			if(memberExpression == null)
				throw new Exception("TProperty must be a member of a class");

			return memberExpression.Member.Name;
		}

		#endregion

		#region String

		public static string Repeat(this string stringToRepeat, int repeat)
		{
			var stringBuilder = new StringBuilder(repeat * stringToRepeat.Length);
			stringBuilder.AppendRepeat(stringToRepeat, repeat);
			return stringBuilder.ToString();
		}

		public static string Truncate(this string text, int maxLetters)
		{
			if(text.Length > maxLetters)
				return new StringBuilder(text, 0, maxLetters, maxLetters + 3).Append("...").ToString();
			else
				return text;
		}

		public static int ParseFormatted(this string str)
		{
			// Get out all non-numeric characters, then parse it
			return int.Parse(Regex.Replace(str, @"\D", ""));
		}

		#endregion

		#region StringBuilder

		public static StringBuilder AppendRepeat(this StringBuilder stringBuilder, string stringToRepeat, int repeat)
		{
			if(repeat == 0 || string.IsNullOrEmpty(stringToRepeat))
				return stringBuilder;

			for(int i = 0; i < repeat; i++)
			{
				stringBuilder.Append(stringToRepeat);
			}
			return stringBuilder;
		}

		public static StringBuilder AppendDateToQuery(this StringBuilder stringBuilder, DateTime date)
		{
			stringBuilder.Append("'");
			stringBuilder.Append(date.ToString("yyyy.MM.dd"));
			stringBuilder.Append("'");
			return stringBuilder;
		}
		public static StringBuilder AppendBoolToQuery(this StringBuilder stringBuilder, bool boolean)
		{
			stringBuilder.Append(boolean ? "1" : "0");
			return stringBuilder;
		}

		#endregion
	}
}
