using System.Collections.Generic;
using BLL.EntityManagers;
using CommonModels.Models;
using UtilsLocal.WCF;
using WcfInterfaces.EntityManagers;
using WebMatrix.WebData;

namespace WcfHost.EntityManagers
{
	[AuthorizeWcf]
	public class CommentManagerService : ICommentManager
	{
		List<CommentWithProductGroupVM> ICommentManager.GetUsersComments()
		{
			return CommentManager.GetUsersComments(WebSecurity.CurrentUserId);
		}
	}
}