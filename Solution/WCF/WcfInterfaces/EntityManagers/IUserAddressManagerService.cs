using System.Collections.Generic;
using System.ServiceModel;
using CommonModels.Models;
using CommonModels.Models.EntityFramework;
using System.ServiceModel.Web;

namespace WcfInterfaces.EntityManagers
{
	[ServiceContract]
	public interface IUserAddressManager
	{
		[OperationContract]
		[WebInvoke(BodyStyle = WebMessageBodyStyle.WrappedRequest)]
		int AddViaViewModel(UserAddressVM userAddressVm);

		[OperationContract]
		[WebGet]
		List<UserAddressVM> GetUsersAddresses();

		[OperationContract]
		[WebInvoke(Method = "PUT", BodyStyle = WebMessageBodyStyle.WrappedRequest)]
		void UpdateViaViewModel(UserAddressVM userAddressVm);

		[OperationContract]
		[WebInvoke(Method = "*", BodyStyle = WebMessageBodyStyle.WrappedRequest)]
		//[WebInvoke(Method = "DELETE", BodyStyle = WebMessageBodyStyle.WrappedRequest)]
		void Delete(int userAddressId, bool isDefault);
	}
}