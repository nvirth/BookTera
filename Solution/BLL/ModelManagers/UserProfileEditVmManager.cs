using CommonModels.Models;
using CommonModels.Models.EntityFramework;

namespace BLL.ModelManagers
{
	public static class UserProfileEditVmManager
	{
		public static UserProfileEditVM DoConsturctorWork(this UserProfileEditVM instance, UserProfile userProfile)
		{
			if(instance == null)
				instance = new UserProfileEditVM();

			instance.PhoneNumber = userProfile.PhoneNumber;
			instance.EMail = userProfile.EMail;
			instance.ImageUrl = userProfile.ImageUrl;
			instance.FullName = userProfile.FullName;

			return instance;
		}
	}
}