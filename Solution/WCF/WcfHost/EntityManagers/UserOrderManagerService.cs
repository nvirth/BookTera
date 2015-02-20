using BLL.EntityManagers;
using UtilsLocal;
using UtilsLocal.WCF;
using WcfInterfaces.EntityManagers;
using WebMatrix.WebData;

namespace WcfHost.EntityManagers
{
	[AuthorizeWcf]
	public class UserOrderManagerService : IUserOrderManager 
	{
		void IUserOrderManager.UpdateUserOrdersAddress(int userAddressId, int userOrderId)
		{
			UserOrderManager.UpdateUserOrdersAddress(userAddressId, userOrderId, WebSecurity.CurrentUserId);
		}
	}
}