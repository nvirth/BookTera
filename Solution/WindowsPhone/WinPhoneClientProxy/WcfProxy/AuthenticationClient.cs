using System;
using System.Text;
using WinPhoneClientProxy.WcfProxy.Base;
using WinPhoneCommon;

namespace WinPhoneClientProxy.WcfProxy
{
	public class AuthenticationClient : RestServiceClientBase
	{
		public AuthenticationClient()
			: base("http://localhost:50135/Authentication/BookteraAuthenticationService.svc")
		{
		}

		#region Login

		public void Login(string userName, string password, bool persistent, Action<LoginAndGetIdResponse> todoWithResult)
		{
			GetAsync(new Request<LoginAndGetIdResponse>()
			{
				RequestUrl = Login_BuildRequest(userName, password, persistent),
				TodoWithResponse = todoWithResult,
			});
		}

		/// <summary>
		/// http://localhost:50135/Authentication/BookteraAuthenticationService.svc/LoginAndGetId?userName=zomidudu&password=asdqwe123&persistent=true
		/// </summary>
		private string Login_BuildRequest(string userName, string password, bool persistent)
		{
			var stringBuilder = new StringBuilder();
			stringBuilder
				.Append(BaseAddress)
				.Append("/LoginAndGetId")
				.Append("?userName=")
				.Append(userName.UrlEncode())
				.Append("&password=")
				.Append(password.UrlEncode())
				.Append("&persistent=")
				.Append(persistent);
			return stringBuilder.ToString();
		}

		public class LoginAndGetIdResponse
		{
			public bool wasSuccessful { get; set; }
			public int userId { get; set; }
		}

		#endregion

		#region LogOut

		public void Logout(Action todoAfterResponseReceived)
		{
			GetAsync(new Request()
			{
				RequestUrl = Logout_BuildRequest(),
				TodoAfterResponseReceived = todoAfterResponseReceived,
			});
		}

		private string Logout_BuildRequest()
		{
			var stringBuilder = new StringBuilder();
			stringBuilder
				.Append(BaseAddress)
				.Append("/Logout");
			return stringBuilder.ToString();
		}

		#endregion
	}
}
