using System.Text;
using CommonModels.Models;
using CommonModels.Models.EntityFramework;

namespace CommonModels.Methods.ManagerRelief
{
	public static class UserAddressManagerRelief
	{
		public static string ToString(UserAddress userAddress)
		{
			var stringBuilder = new StringBuilder();
			stringBuilder.AppendFormat("{0}, {1}, {2}, {3}", userAddress.Country, userAddress.ZipCode, userAddress.City, userAddress.StreetAndHouseNumber);
			return stringBuilder.ToString();
		}

		public static bool CheckAllPropertiesNullOrEmpty(UserAddressVM userAddressVM)
		{
			return string.IsNullOrEmpty(userAddressVM.ZipCode)
				&& string.IsNullOrEmpty(userAddressVM.City)
				&& string.IsNullOrEmpty(userAddressVM.StreetAndHouseNumber)
				&& string.IsNullOrEmpty(userAddressVM.Country);
		}
	}
}
