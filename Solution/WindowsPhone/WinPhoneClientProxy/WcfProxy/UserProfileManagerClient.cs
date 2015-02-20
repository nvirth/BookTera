using System;
using System.Net;
using System.Text;
using CommonModels.Models;
using Newtonsoft.Json;
using WinPhoneClientProxy.WcfProxy.Base;
using WinPhoneCommon;

namespace WinPhoneClientProxy.WcfProxy
{
	public class UserProfileManagerClient : RestServiceClientBase
	{
		public UserProfileManagerClient()
			: base("http://localhost:50135/EntityManagers/UserProfileManagerService.svc")
		{
		}

		#region GetForEdit

		public void GetForEdit(Action<UserProfileEditVM> todoWithResult)
		{
			GetAsync(new Request<UserProfileEditVM>()
			{
				RequestUrl = GetForEdit_BuildRequest(),
				TodoWithResponse = todoWithResult,
			});
		}

		private string GetForEdit_BuildRequest()
		{
			var stringBuilder = new StringBuilder();
			stringBuilder
				.Append(BaseAddress)
				.Append("/GetForEdit");
			return stringBuilder.ToString();
		}

		#endregion

		#region Update

		public void Update(UserProfileEditVM data, Action todoAfterResponseReceived, Action<WebException> todoWithWebException)
		{
			GetAsync(new Request()
			{
				RequestUrl = BaseAddress + "/Update",
				PostData = JsonConvert.SerializeObject(new { userProfileEdit = data }),
				HttpPostVerb = HttpPostVerb.PUT,
				TodoAfterResponseReceived = todoAfterResponseReceived,
				HandleWebException = todoWithWebException,
			});
		}

		#endregion
	}
}
