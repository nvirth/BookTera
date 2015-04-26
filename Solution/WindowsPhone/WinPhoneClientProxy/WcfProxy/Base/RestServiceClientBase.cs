using System;
using System.IO;
using System.Net;
using System.Windows;
using Microsoft.Phone.Controls;
using Newtonsoft.Json;
using WinPhoneCommon;

namespace WinPhoneClientProxy.WcfProxy.Base
{
	public abstract class RestServiceClientBase
	{
		public static readonly CookieContainer CookieContainer = new CookieContainer();
		public CookieCollection GetCookies
		{
			get
			{
				if(CookieContainer != null)
					return CookieContainer.GetCookies(BaseAddressUri);

				return null;
			}
		}


		protected readonly string BaseAddress;
		protected readonly Uri BaseAddressUri;
		private const string ActualIp = "192.168.1.100";

		protected RestServiceClientBase(string baseAddress)
		{
			BaseAddress = baseAddress.Replace("localhost", ActualIp);
			BaseAddressUri = new Uri(BaseAddress);
		}

		protected void GetAsync(Request request)
		{
			GetAsyncDoWork<object>(
				request.RequestUrl,
				request.PostData,
				request.HttpPostVerb,
				/*todoWithResponse*/ null,
				request.HandleWebException,
				request.TodoAfterResponseReceived,
				existT: false);
		}

		protected void GetAsync<T>(Request<T> request)
		{
			GetAsyncDoWork(
				request.RequestUrl,
				request.PostData,
				request.HttpPostVerb,
				request.TodoWithResponse,
				request.HandleWebException,
				todoAfterResponseReceived: null,
				existT: true);
		}

		/// <typeparam name="T">A visszatérési érték típusa</typeparam>
		/// <param name="todoWithResponse">A meghívott fv visszatérési értékét kapja paraméterül</param>
		/// <param name="todoWithWebException">Ha WebException keletkezik, ebben lekezelhető</param>
		/// <param name="todoAfterResponseReceived">Visszatérési érték nélküli fv-hívásoknál ez hívódik meg a Response megkérkezését követően (ha nincs WebException)</param>
		/// <param name="existT">Van-e visszatérési érték</param>
		private void GetAsyncDoWork<T>(string requestUrl, string postData, HttpPostVerb postVerb,
			Action<T> todoWithResponse, Action<WebException> todoWithWebException,
			Action todoAfterResponseReceived, bool existT)
		{
			var webRequest = WebRequest.CreateHttp(requestUrl);
			webRequest.Headers[HttpRequestHeader.CacheControl] = "no-cache";
			webRequest.Headers[HttpRequestHeader.IfModifiedSince] = DateTime.UtcNow.ToString();
			SetRequestCookies(webRequest);
			PreparePostIfNecessary(postData, postVerb, webRequest);

			webRequest.BeginGetResponse(
				ar =>
				{
					try
					{
						using(var response = (HttpWebResponse)webRequest.EndGetResponse(ar))
						{
							GetResponseCookies(response);

							if(existT)
							{
								string responseObjectText;
								using(var streamReader = new StreamReader(response.GetResponseStream()))
								{
									responseObjectText = streamReader.ReadToEnd();
								}

								var result = JsonConvert.DeserializeObject<T>(responseObjectText);
								if(todoWithResponse != null)
									todoWithResponse(result);
							}
							if(todoAfterResponseReceived != null)
								todoAfterResponseReceived();
						}
					}
					catch(WebException we)
					{
						bool handled = false;

						var httpWebResponse = we.Response as HttpWebResponse;
						if(httpWebResponse != null)
						{
							var isForbidden = httpWebResponse.StatusCode == HttpStatusCode.Forbidden;
							var isUnauthorized = httpWebResponse.StatusCode == HttpStatusCode.Unauthorized;

							//if(!UserData.IsAuthenticated && (isForbidden || isUnauthorized))
							if(isForbidden || isUnauthorized)
							{
								Deployment.Current.Dispatcher.BeginInvoke(
									() =>
									{
										var frame = (PhoneApplicationFrame)Application.Current.RootVisual;
										frame.Navigate(new Uri("/Login.xaml", UriKind.Relative));
									});
								handled = true;
							}
						}

						//TODO this way there will be a 'no connection' error msg even if we are just redircted to the login page
						//(if changing, do sync with the Android version)
						if (todoWithWebException != null && !handled)
							todoWithWebException(we);
						else
							ShowDefaultErrorMsg();
					}
					catch(Exception e)
					{
						//todo error handling
					}
				}, null);
		}

		public static void ShowDefaultErrorMsg()
		{
			Deployment.Current.Dispatcher.BeginInvoke(() => MessageBox.Show("Hiba a kapcsolatban. "));
		}

		private void PreparePostIfNecessary(string postData, HttpPostVerb postVerb, HttpWebRequest webRequest)
		{
			//if(!string.IsNullOrWhiteSpace(postData))
			if(postVerb != HttpPostVerb.NON_POST__GET)
			{
				webRequest.Method = postVerb.ToString();
				webRequest.ContentType = "application/json; charset=utf-8";

				var ar = webRequest.BeginGetRequestStream(result => { }, null);
				using(var writer = new StreamWriter(webRequest.EndGetRequestStream(ar)))
				{
					writer.Write(postData);
				}
			}
		}

		private void SetRequestCookies(HttpWebRequest webRequest)
		{
			webRequest.CookieContainer = CookieContainer;
		}

		private void GetResponseCookies(HttpWebResponse response)
		{
			var replyMessagesCookies = response.Headers["Set-Cookie"];

			if(!string.IsNullOrEmpty(replyMessagesCookies))
			{
				var currentUrl = BaseAddressUri;
				CookieContainer.SetCookies(currentUrl, replyMessagesCookies);
			}
		}
	}
}