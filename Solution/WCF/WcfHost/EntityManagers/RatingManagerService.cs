using System.Collections.Generic;
using BLL.EntityManagers;
using CommonModels.Models;
using UtilsLocal.WCF;
using WcfInterfaces.EntityManagers;
using WebMatrix.WebData;

namespace WcfHost.EntityManagers
{
	[AuthorizeWcf]
	public class RatingManagerService : IRatingManager
	{
		List<RatingWithProductGroupVM> IRatingManager.GetUsersRatings()
		{
			return RatingManager.GetUsersRatings(WebSecurity.CurrentUserId);
		}
	}
}