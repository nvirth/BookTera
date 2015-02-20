using BLL.EntityManagers;
using CommonModels.Models;
using CommonModels.Models.EntityFramework;
using CommonPortable.Enums;
using UtilsLocal;
using UtilsLocal.WCF;
using WcfInterfaces.EntityManagers;
using WebMatrix.WebData;

namespace WcfHost.EntityManagers
{
	public class UserProfileManagerService : IUserProfileManager 
	{
		[AuthorizeWcf]
		UserProfileEditVM IUserProfileManager.GetForEdit()
		{
			return UserProfileManager.GetForEdit(WebSecurity.CurrentUserId);
		}

		[AuthorizeWcf]
		void IUserProfileManager.Update(UserProfileEditVM userProfileEdit)
		{
			UserProfileManager.Update(userProfileEdit, WebSecurity.CurrentUserId);
		}

		[AuthorizeWcf]
		bool IUserProfileManager.LevelUpUser(UserGroupEnum toUserGroup, bool saveChanges)
		{
			return UserProfileManager.LevelUpUser(WebSecurity.CurrentUserId, toUserGroup, saveChanges);
		}

		[AuthorizeWcf]
		void IUserProfileManager.UpdateDefaultAddress(int? newDefaultAddressId)
		{
			UserProfileManager.UpdateDefaultAddress(newDefaultAddressId, WebSecurity.CurrentUserId);
		}

		bool IUserProfileManager.CheckUserNameUnique(string userName)
		{
			return UserProfileManager.CheckUserNameUnique(userName);
		}

		bool IUserProfileManager.CheckEmailUnique(string email)
		{
			return UserProfileManager.CheckEmailUnique(email);
		}

		[AuthorizeWcf]
		bool IUserProfileManager.CheckNewEmailUnique(string email)
		{
			return UserProfileManager.CheckEmailUnique(email, WebSecurity.CurrentUserId);
		}
	}

}