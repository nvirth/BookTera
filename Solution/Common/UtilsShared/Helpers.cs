using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.Routing;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Xml.Linq;
using UtilsSharedPortable;

namespace UtilsShared
{
	public static class Helpers
	{

		#region ComboBox

		/// <summary>
		/// Handle ComboBox's PreviewTextInput event to implement quick search among it's items. 
		/// </summary>
		/// <param name="stringSelector">
		/// It's input params are the items of the ComboBox (one by one, for each). 
		/// It's output must be the item's property, in which the (StartsWith) search will be called. 
		/// </param>
		public static void ComboBoxSearchKey(this ComboBox comboBox, object sender, TextCompositionEventArgs e, Func<object, string> stringSelector)
		{
			int i = 0;
			var indexes = new List<int?>();
			foreach(var comboBoxItem in comboBox.ItemsSource)
			{
				if(stringSelector(comboBoxItem).StartsWith(e.Text, StringComparison.InvariantCultureIgnoreCase))
					indexes.Add(i);

				i++;
			}
			if(indexes.Count != 0)
			{
				int? firstAfterCurrent = indexes.FirstOrDefault(index => comboBox.SelectedIndex < index);
				comboBox.SelectedIndex = firstAfterCurrent.HasValue ? firstAfterCurrent.Value : indexes[0].Value;
			}

			e.Handled = true;
		}


		#endregion

		#region Cookie

		public static HttpCookie ToHttpCookie(this Cookie cookie)
		{
			return new HttpCookie(cookie.Name, cookie.Value)
			{
				Domain = cookie.Domain,
				Expires = cookie.Expires,
				HttpOnly = cookie.HttpOnly,
				Path = cookie.Path,
				Secure = cookie.Secure
			};
		}

		#endregion

		#region Enum

		public static string ToDescriptionString(this Enum enumerationValue)
		{
			return enumerationValue.GetDescription();
		}

		public static string GetDescription(this Enum enumerationValue)
		{
			//Tries to find a DescriptionAttribute for a potential friendly name
			//for the enum
			MemberInfo[] memberInfo = enumerationValue.GetType().GetMember(enumerationValue.ToString());
			if(memberInfo != null && memberInfo.Length > 0)
			{
				object[] attrs = memberInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);

				if(attrs != null && attrs.Length > 0)
				{
					//Pull out the description value
					return ((DescriptionAttribute)attrs[0]).Description;
				}
			}

			//If we have no description attribute, just return the ToString of the enum
			return enumerationValue.ToString();
		}

		#endregion

		#region Exception

		public static void WriteWithInnerMessages(this Exception e)
		{
			//int i = 1;
			//while(e != null)
			//{
			//	var indention = string.Concat(Enumerable.Repeat(" - ", i));
			//	Console.WriteLine(indention + e.Message);
			//	e = e.InnerException;
			//	i++;
			//}
			e.WriteWithInnerMessagesRecursive();
		}

		private static void WriteWithInnerMessagesRecursive(this Exception e, int intend = 1)
		{
			// End of recursion
			if(e == null)
				return;

			// Write actual message
			Console.WriteLine(" - ".Repeat(intend) + e.Message);

			// Handle AggregateExceptions
			var ae = e as AggregateException;
			if(ae != null)
			{
				// Call recursive to all inner exceptions
				foreach(var aeInner in ae.InnerExceptions)
				{
					aeInner.WriteWithInnerMessagesRecursive(intend + 1);
				}
			}
			else
			{
				// Call recursive to inner exceptions
				e.InnerException.WriteWithInnerMessagesRecursive(intend + 1);
			}
		}

		public static void WriteWithInnerMessagesColorful(this Exception e, ConsoleColor color)
		{
			//var beforeColor = Console.ForegroundColor;
			//Console.ForegroundColor = color;
			//e.WriteWithInnerMessagesRecursive();
			//Console.ForegroundColor = beforeColor;
			GeneralFunctions.WithConsoleColor(color, () => e.WriteWithInnerMessagesRecursive());
		}

		public static void WriteWithInnerMessagesRed(this Exception e)
		{
			e.WriteWithInnerMessagesColorful(ConsoleColor.Red);
		}

		#endregion

		#region Html

		#region ActionLinkWithQuerySaving

		public static MvcHtmlString ActionLinkWithQuerySaving(this HtmlHelper htmlHelper, string linkText, object routeValues = null, object htmlAttributes = null, string actionName = null, string controllerName = null)
		{
			if(actionName == null)
				actionName = htmlHelper.ViewContext.RouteData.Values["Action"].ToString();

			if(controllerName == null)
				controllerName = htmlHelper.ViewContext.RouteData.Values["Controller"].ToString();

			var newRoute = new RouteValueDictionary(routeValues);
			var queryString = htmlHelper.ViewContext.HttpContext.Request.QueryString;

			foreach(string key in queryString.Keys)
				if(!newRoute.ContainsKey(key))
					newRoute.Add(key, queryString[key]);

			if(htmlAttributes == null)
				return htmlHelper.ActionLink(linkText, actionName, controllerName, newRoute, null);
			else
				return htmlHelper.ActionLink(linkText, actionName, controllerName, newRoute, htmlAttributes);
		}

		#endregion

		#region ClientIdFor

		public static MvcHtmlString ClientIdFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression)
		{
			return MvcHtmlString.Create(htmlHelper.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldId(ExpressionHelper.GetExpressionText(expression)));
		}

		#endregion

		#endregion

		#region ModelStateDictionary

		public static KeyValuePair<string, ModelState>[] CopyToArray(this ModelStateDictionary modelState)
		{
			var modelStates = new KeyValuePair<string, ModelState>[modelState.Count];
			modelState.CopyTo(modelStates, 0);
			return modelStates;
		}

		public static ModelError[] CopyModelErrors(this ModelStateDictionary modelState)
		{
			return modelState.Values.SelectMany(v => v.Errors).ToArray();
		}

		#endregion

		#region Object

		public static XElement ToXml(this object obj)
		{
			var type = obj.GetType();

			// If obj is value type or string, then return it wrapped
			if(type.IsValueType || (obj is string))
				return new XElement(type.Name.ToFriendlyUrl(), obj);

			// If obj is a class (but not string), iterate it's properties, and serialize them to xml format
			IEnumerable<XElement> xElements =
				type.GetRuntimeProperties()
					.Select(property =>
					{
						object propertyValue = property.GetValue(obj);
						if(propertyValue != null)
						{
							var propertyType = propertyValue.GetType();

							// If the property is not a value type or a string, call .ToXml to the property as well
							if(!propertyType.IsValueType && !(propertyValue is string))
							{
								var enumerablePropertyValue = propertyValue as IEnumerable<object>;
								if(enumerablePropertyValue != null)
								{
									// If an IEnumerable type is empty, don't attach it to the xml
									propertyValue = enumerablePropertyValue.Any()
										? (object)propertyValue.ToXml()
										: null; // enumerablePropertyValue.GetType().Name + " = null";
								}
								else // Non-IEnumberable types
								{
									propertyValue = propertyValue.ToXml();
								}
							}
						}

						return new XElement(property.Name.ToFriendlyUrl(), propertyValue);
					});

			return new XElement(type.Name.ToFriendlyUrl(), xElements);
		}

		/// <summary>
		/// Creates a deep clone from the given object
		/// </summary>
		/// <typeparam name="T">The param type must be marked with the [Serializable] attribute</typeparam>
		public static T DeepClone<T>(this T a)
		{
			using(MemoryStream stream = new MemoryStream())
			{
				BinaryFormatter formatter = new BinaryFormatter();
				formatter.Serialize(stream, a);
				stream.Position = 0;
				return (T)formatter.Deserialize(stream);
			}
		}

		#endregion

		#region String

		public static string ToFriendlyUrl(this string text)
		{
			// Normalize the text using full canonical decomposition.
			text = text.Normalize(NormalizationForm.FormD);

			// Remove non-number and non-letter characters.
			Regex nonspace = new Regex("[^0-9A-Za-z ]");
			text = nonspace.Replace(text, String.Empty);

			// Replace space characters with "-", following Google's recommendation.
			text = text.Replace(' ', '-');

			// Remove trailing and leading dashes.
			string replaced = text.Trim('-');

			// Encode the remaining special characters with standard URL encoding.
			string urlEncoded = HttpUtility.UrlEncode(replaced);

			// Return the normalized text or "1" if the normalized text is empty.
			return String.IsNullOrEmpty(urlEncoded) ? "1" : urlEncoded;
		}

		public static T ToEnum<T>(this string stringValue, T defaultValue, bool ignoreCase = false) where T : struct
		{
			try
			{
				return stringValue.ToEnum<T>(ignoreCase);
			}
			catch(Exception)
			{
				return defaultValue;
			}
		}

		public static T ToEnum<T>(this string stringValue, bool ignoreCase = false) where T : struct
		{
			var enumType = typeof(T);
			if(!enumType.IsEnum)
				throw new ArgumentException("T must be of Enum type. ");

			var stringValueLower = stringValue.ToLower();

			foreach(T enumValue in Enum.GetValues(enumType))
			{
				var friendlyEnumValue = ((Enum)(object)enumValue).GetDescription();

				if(ignoreCase)
				{
					if(friendlyEnumValue.ToLower() == stringValueLower)
						return enumValue;
				}
				else
				{
					if(friendlyEnumValue == stringValue)
						return enumValue;
				}
			}

			foreach(T enumValue in Enum.GetValues(enumType))
			{
				if(ignoreCase)
				{
					if(enumValue.ToString().ToLower() == stringValueLower)
						return enumValue;
				}
				else
				{
					if(enumValue.ToString() == stringValue)
						return enumValue;
				}
			}

			throw new Exception("The " + enumType.Name + " enumeration does not have any value for " + stringValue);
		}

		#endregion
	}
}
