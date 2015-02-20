using System;
using System.Globalization;
using System.Windows.Data;
using WinPhoneClientProxy.ProductGroupManagerService;

namespace WindowsPhone.Common.Converters
{
	public sealed class PgDetailsConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			var vm = value as BookRowPLVM.ProductGroupVM;
			if (vm == null)
				return null;

			return new
			{
				Product = new
				{
					PriceString = vm.PriceString,
					UserName = "",
				},
				ProductGroup = new
				{
					Title = vm.Title,
					SubTitle = vm.SubTitle,
					AuthorNames = vm.AuthorNames,
					ImageUrl = vm.ImageUrl,
				},

			};
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
