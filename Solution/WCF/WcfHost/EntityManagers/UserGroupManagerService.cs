using System.Collections.Generic;
using System.Linq;
using BLL.EntityManagers;
using CommonModels.Models.EntityFramework;
using WcfInterfaces.EntityManagers;

namespace WcfHost.EntityManagers
{
	public class UserGroupManagerService : IUserGroupManager
	{
		List<UserGroup> IUserGroupManager.GetAllWithUsers(int currentUserId, out int usersGroupId)
		{
			var userGroups = UserGroupManager.GetAllWithUsers(currentUserId, out usersGroupId);
			return userGroups.Select(UserGroupManager.CopyFromProxy).ToList();
		}
	}
}