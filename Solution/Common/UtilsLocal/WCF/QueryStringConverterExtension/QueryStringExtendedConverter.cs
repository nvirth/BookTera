using System;
using UtilsLocal.WCF.QueryStringConverterExtension.Steps;

namespace UtilsLocal.WCF.QueryStringConverterExtension
{
	/// <summary>
	/// Ha bővül a lánc, a legalsó elemeből kell leszármazni.
	/// Aktuális lánc:
	/// Array --> Nullable --> Standard (QueryStringConverter)
	/// </summary>
	public class QueryStringExtendedConverter: ArrayQueryStringConverter
	{
	}
}
