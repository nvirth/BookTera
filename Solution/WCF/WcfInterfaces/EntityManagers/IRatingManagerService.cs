using System.Collections.Generic;
using System.ServiceModel;
using CommonModels.Models;
using System.ServiceModel.Web;

namespace WcfInterfaces.EntityManagers
{
	[ServiceContract]
	public interface IRatingManager
	{
		[OperationContract]
		[WebGet]
		List<RatingWithProductGroupVM> GetUsersRatings();
	}
}