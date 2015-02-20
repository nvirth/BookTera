using System.Windows;

namespace WindowsPhone.Common
{
	public class DependencyBoolean : DependencyObject
	{
		public bool Value
		{
			get { return (bool)GetValue(ValueProperty); }
			set { SetValue(ValueProperty, value); }
		}

		// Using a DependencyProperty as the backing store for Values.  This enables animation, styling, binding, etc...
		public static readonly DependencyProperty ValueProperty =
			DependencyProperty.Register("Value", typeof(bool), typeof(DependencyBoolean), null);
	}
}
