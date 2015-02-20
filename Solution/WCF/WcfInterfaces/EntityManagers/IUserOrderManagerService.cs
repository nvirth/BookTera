using System.ServiceModel;
using UtilsLocal;
using System.ServiceModel.Web;

namespace WcfInterfaces.EntityManagers
{
	[ServiceContract]
	public interface IUserOrderManager
	{
		[OperationContract]
		[WebInvoke(Method = "PUT", BodyStyle = WebMessageBodyStyle.WrappedRequest)]
		void UpdateUserOrdersAddress(int userAddressId, int userOrderId);
	}
}