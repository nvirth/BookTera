using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using UtilsSharedPortable;

namespace UtilsShared
{
	public static class HelpersShared
	{
		#region DependencyObject

		public static T FindAncestor<T>(this DependencyObject dependencyObject)
			where T : class
		{
			T objectT = null;
			do
			{
				dependencyObject = VisualTreeHelper.GetParent(dependencyObject);
				objectT = dependencyObject as T;
			} while(objectT == null && dependencyObject != null);
			return objectT;
		}

		#endregion

		#region SetDefaultCultureTo...

		public static void SetDefaultCultureToEnglish()
		{
			Thread.CurrentThread.CurrentCulture = Constants.CultureInfoEn;
			Thread.CurrentThread.CurrentUICulture = Constants.CultureInfoEn;

			UtilsSharedPortable.GeneralFunctions.SetDefaultCultureToEnglish_OnlyCultureInfo();
		}

		public static void SetDefaultCultureToHungarian()
		{
			Thread.CurrentThread.CurrentCulture = Constants.CultureInfoHu;
			Thread.CurrentThread.CurrentUICulture = Constants.CultureInfoHu;

			UtilsSharedPortable.GeneralFunctions.SetDefaultCultureToHungarian_OnlyCultureInfo();
		}

		#endregion
	
	}
}
