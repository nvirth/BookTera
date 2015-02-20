using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Graphics.Display;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;

namespace MetroWpf.Common
{
    /// <summary>
    /// Value converter that translates true to <see cref="Visibility.Visible"/> and false to
    /// <see cref="Visibility.Collapsed"/>.
    /// </summary>
    public sealed class BooleanToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
	        if (!(value is bool))
		        return Visibility.Collapsed;

	        var boolValue = (bool) value;
	        var needInverse = ((parameter as string) ?? "") == "!";
	        boolValue = needInverse ? !boolValue : boolValue;

	        return boolValue ? Visibility.Visible : Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
	        if (!(value is Visibility))
		        return false;

	        var boolValue = (Visibility) value == Visibility.Visible;
			var needInverse = ((parameter as string) ?? "") == "!";
			boolValue = needInverse ? !boolValue : boolValue;

	        return boolValue;
        }
    }
}
