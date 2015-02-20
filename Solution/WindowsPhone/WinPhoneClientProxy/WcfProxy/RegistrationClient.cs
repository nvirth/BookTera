using System;
using System.Net;
using CommonModels.Models;
using CommonModels.Models.AccountModels;
using Newtonsoft.Json;
using WinPhoneClientProxy.WcfProxy.Base;
using WinPhoneCommon;

namespace WinPhoneClientProxy.WcfProxy
{
	public class RegistrationClient : RestServiceClientBase
	{
		public RegistrationClient()
			: base("http://localhost:50135/RegistrationManagerService.svc")
		{
		}

		#region Register

		public void Register(string userName, string email, string password, string passwordRepeat, 
			Action todoAfterReceiveReply, Action<WebException> todoWithWebException)
		{
			GetAsync(new Request()
			{
				RequestUrl = BaseAddress + "/RegisterUser",
				PostData = Register_BuildPostData(userName, email, password, passwordRepeat),
				HttpPostVerb = HttpPostVerb.POST,
				TodoAfterResponseReceived = todoAfterReceiveReply,
				HandleWebException = todoWithWebException,
			});
		}

		private string Register_BuildPostData(string userName, string email, string password, string passwordRepeat)
		{
			var registerVm = new RegisterVM()
			{
				UserName = userName,
				EMail = email,
				Password = password,
				ConfirmPassword = passwordRepeat,

				// cheat
				UserAddress = new UserAddressVM()
				{
					City = "MyCity",
					Country = "MyCountry",
					IsDefault = true,
					StreetAndHouseNumber = "MyStreet 1",
					ZipCode = "1010",
				}
			};

			return JsonConvert.SerializeObject(registerVm);
		}

		#endregion

	}
}
