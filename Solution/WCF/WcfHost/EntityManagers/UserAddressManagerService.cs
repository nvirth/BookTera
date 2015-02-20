using System.Collections.Generic;
using BLL.EntityManagers;
using CommonModels.Models;
using CommonModels.Models.EntityFramework;
using UtilsLocal.WCF;
using WcfInterfaces.EntityManagers;
using WebMatrix.WebData;

namespace WcfHost.EntityManagers
{
	[AuthorizeWcf]
	public class UserAddressManagerService : IUserAddressManager 
	{
		int IUserAddressManager.AddViaViewModel(UserAddressVM userAddressVm)
		{
			return UserAddressManager.Add(userAddressVm, WebSecurity.CurrentUserId);
		}

		List<UserAddressVM> IUserAddressManager.GetUsersAddresses()
		{
			return UserAddressManager.GetUsersAddresses(WebSecurity.CurrentUserId);
		}

		void IUserAddressManager.UpdateViaViewModel(UserAddressVM userAddressVm)
		{
			UserAddressManager.Update(userAddressVm, WebSecurity.CurrentUserId);
		}

		void IUserAddressManager.Delete(int userAddressId, bool isDefault)
		{
			UserAddressManager.Delete(userAddressId, WebSecurity.CurrentUserId, isDefault);
		}
	}
}