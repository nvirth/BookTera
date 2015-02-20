using System.ServiceModel;
using CommonModels.Models;
using CommonModels.Models.EntityFramework;
using CommonPortable.Enums;
using UtilsLocal;
using System.ServiceModel.Web;

namespace WcfInterfaces.EntityManagers
{
	[ServiceContract]
	public interface IUserProfileManager
	{
		[OperationContract]
		[WebGet]
		UserProfileEditVM GetForEdit();

		[OperationContract]
		[WebInvoke(Method = "PUT", BodyStyle = WebMessageBodyStyle.WrappedRequest)]
		void Update(UserProfileEditVM userProfileEdit);

		[OperationContract]
		[WebInvoke(Method = "PUT", BodyStyle = WebMessageBodyStyle.WrappedRequest)]
		bool LevelUpUser(UserGroupEnum toUserGroup, bool saveChanges = true);

		[OperationContract]
		[WebInvoke(Method = "PUT", BodyStyle = WebMessageBodyStyle.WrappedRequest)]
		void UpdateDefaultAddress(int? newDefaultAddressId);

		[OperationContract]
		[WebGet]
		bool CheckUserNameUnique(string userName);

		[OperationContract]
		[WebGet]
		bool CheckNewEmailUnique(string email);

		[OperationContract]
		[WebGet]
		bool CheckEmailUnique(string email);
	}
}