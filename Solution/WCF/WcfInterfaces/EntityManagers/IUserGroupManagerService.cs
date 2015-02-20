using System.Collections.Generic;
using System.ServiceModel;
using CommonModels.Models.EntityFramework;
using System.ServiceModel.Web;

namespace WcfInterfaces.EntityManagers
{
	[ServiceContract]
	public interface IUserGroupManager
	{
		[OperationContract]
		[WebGet(BodyStyle = WebMessageBodyStyle.WrappedResponse)]
		List<UserGroup> GetAllWithUsers(int currentUserId, out int usersGroupId);
	}
}