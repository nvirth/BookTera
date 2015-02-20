using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Data;
using WinPhoneClientProxy.ProductGroupManagerService;
using InBookBlockPVM = WinPhoneClientProxy.CategoryManagerService.InBookBlockPVM;

namespace WindowsPhone.Common.Converters
{
	/// <summary>
	/// Converts an IEnumerable of type BookRowPLVM.ProductVM 
	/// for the ProductGroupDetail page's book list pivot
	/// </summary>
	public sealed class PgProductsConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			var productVms = value as IEnumerable<BookRowPLVM.ProductVM>;
			if (productVms == null)
				return null;

			var converteds = new List<object>();
			foreach (var productVm in productVms)
			{
				var image = productVm.Images[0];
				if (image.StartsWith("default"))
					image = "";

				converteds.Add(new WinPhoneClientProxy.CategoryManagerService.InBookBlockPVM
				{
					Product = new InBookBlockPVM.ProductVM()
					{
						ID = productVm.ID,
						PriceString = productVm.PriceString,
						UserName = productVm.UserName,
						UserFriendlyUrl = productVm.UserFriendlyUrl,
						HowMany = productVm.HowMany,
						Description = "MOCK non empty string",
					},
					ProductGroup = new InBookBlockPVM.ProductGroupVM()
					{
						Title = "",
						SubTitle = productVm.Description,
						AuthorNames = "",
						ImageUrl = image,
					},
				});
			}

			return converteds;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
