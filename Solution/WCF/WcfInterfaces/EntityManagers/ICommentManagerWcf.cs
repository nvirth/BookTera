using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;
using CommonModels.Models;

namespace WcfInterfaces.EntityManagers
{
	[ServiceContract]
	public interface ICommentManager
	{
		[OperationContract]
		[WebGet]
		List<CommentWithProductGroupVM> GetUsersComments();
	}
}