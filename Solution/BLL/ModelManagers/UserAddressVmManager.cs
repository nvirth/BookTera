using CommonModels.Models;
using CommonModels.Models.EntityFramework;

namespace BLL.ModelManagers
{
	public static class UserAddressVmManager
	{
		public static UserAddressVM DoConsturctorWork(this UserAddressVM instance, UserAddress userAddress, bool isDefault)
		{
			if(instance == null)
				instance = new UserAddressVM();
				
			instance.ZipCode = userAddress.ZipCode;
			instance.City = userAddress.City;
			instance.StreetAndHouseNumber = userAddress.StreetAndHouseNumber;
			instance.Country = userAddress.Country;

			instance.Id = userAddress.ID;
			instance.IsDefault = isDefault;

			return instance;
		}
	}
}
