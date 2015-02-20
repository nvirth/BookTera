using CommonModels.Models.AccountModels;

namespace CommonModels.Methods.ManagerRelief
{
	public static class RegistrationManagerRelief
	{
		public static void EmptyPasswords(RegisterVM registerVM)
		{
			registerVM.Password = string.Empty;
			registerVM.ConfirmPassword = string.Empty;
		}
	}
}
