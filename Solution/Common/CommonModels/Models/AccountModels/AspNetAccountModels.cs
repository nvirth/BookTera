using System.Data.Entity;

namespace CommonModels.Models.AccountModels
{
	public partial class UsersContext : DbContext
	{
		public UsersContext() : base("BookTeraDB") { }

		public DbSet<UserProfile> UserProfiles { get; set; }
	}

	public partial class UserProfile
	{
		public int UserId { get; set; }
		public string UserName { get; set; }
	}

	public partial class RegisterExternalLoginModel
	{
		public string UserName { get; set; }
		public string ExternalLoginData { get; set; }
	}

	public partial class LocalPasswordModel
	{
		public string OldPassword { get; set; }
		public string NewPassword { get; set; }
		public string ConfirmPassword { get; set; }
	}

	public partial class LoginModel
	{
		public string LoginUserName { get; set; }
		public string LoginPassword { get; set; }
		public bool RememberMe { get; set; }
	}

	public partial class ExternalLogin
	{
		public string Provider { get; set; }
		public string ProviderDisplayName { get; set; }
		public string ProviderUserId { get; set; }
	}
}
