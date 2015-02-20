using System.ServiceModel;
using System.ServiceModel.Web;

namespace WcfInterfaces.Authentication
{
	[ServiceContract]
	public interface IBookteraAuthenticationService
	{
		[OperationContract]
		[WebGet]
		bool Login(string userName, string password, bool persistent = false);

		[OperationContract]
		[WebGet(BodyStyle = WebMessageBodyStyle.WrappedResponse)]
		void LoginAndGetId(string userName, string password, bool persistent, out bool wasSuccessful, out int userId);

		[OperationContract]
		[WebGet]
		void Logout();
	}
}