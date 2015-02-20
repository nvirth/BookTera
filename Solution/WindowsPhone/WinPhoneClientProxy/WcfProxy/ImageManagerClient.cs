using System;
using System.Text;
using WinPhoneClientProxy.WcfProxy.Base;

namespace WinPhoneClientProxy.WcfProxy
{
	public class ImageManagerClient : RestServiceClientBase
	{
		public ImageManagerClient()
			: base("http://localhost:50135/EntityManagers/ImageManagerService.svc")
		{
		}

		#region GetUsersAvatar

		public void GetUsersAvatar(Action<string> todoWithResult)
		{
			GetAsync(new Request<string>()
			{
				RequestUrl = GetUsersAvatar_BuildRequest(),
				TodoWithResponse = todoWithResult,
			});
		}

		private string GetUsersAvatar_BuildRequest()
		{
			var stringBuilder = new StringBuilder();
			stringBuilder
				.Append(BaseAddress)
				.Append("/GetUsersAvatar");
			return stringBuilder.ToString();
		}

		#endregion
	}
}
