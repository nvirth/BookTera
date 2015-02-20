using System.ServiceModel;
using System.ServiceModel.Web;
using CommonModels.Models.AccountModels;

namespace WcfInterfaces
{
	[ServiceContract]
	public interface IRegistrationManager
	{
		[OperationContract]
		[WebInvoke(Method = "POST")]
		void RegisterUser(RegisterVM registerVm);
	}	
}
