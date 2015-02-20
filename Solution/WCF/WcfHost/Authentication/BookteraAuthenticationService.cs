using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CommonModels.Models.AccountModels;
using WcfInterfaces.Authentication;
using WebMatrix.WebData;

namespace WcfHost.Authentication
{
	public class BookteraAuthenticationService : Controller, IBookteraAuthenticationService
	{
		bool IBookteraAuthenticationService.Login(string userName, string password, bool persistent = false)
		{
			return WebSecurity.Login(userName, password, persistent);
		}

		public void LoginAndGetId(string userName, string password, bool persistent, out bool wasSuccessful, out int userId)
		{
			var loginSucceeded = WebSecurity.Login(userName, password, persistent);

			//userId = WebSecurity.CurrentUserId;
			userId = WebSecurity.GetUserId(userName);
			wasSuccessful = loginSucceeded;
		}

		void IBookteraAuthenticationService.Logout()
		{
			WebSecurity.Logout();
		}
	}
}