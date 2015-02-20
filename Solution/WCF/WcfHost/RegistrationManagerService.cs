using System;
using BLL;
using CommonModels.Models.AccountModels;
using WcfInterfaces;

namespace WcfHost
{
	public class RegistrationManagerService : IRegistrationManager
	{
		void IRegistrationManager.RegisterUser(RegisterVM registerVm)
		{
			var validator = new Validator();
			var isValid = validator.TryValidateModel(registerVm);
			if (isValid)
				RegistrationManager.RegisterUser(registerVm, isTest: false);
			else
				throw new Exception("Invalid registration data");
		}
	}
}
