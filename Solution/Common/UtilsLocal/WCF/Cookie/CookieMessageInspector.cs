using System;
using System.Net;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;
using System.Web;
using UtilsShared;

namespace UtilsLocal.WCF.Cookie
{
	public class CookieMessageInspector : IClientMessageInspector
	{
		/// <summary>
		/// A kliens egy wcf hívás után, a kapott válaszból kiveszi a sütiket (amik a WcfHost-ban keletkeztek),
		/// majd hozzáadja őket a HttpContext.Current.Response.Cookies -hoz
		/// </summary>
		public void AfterReceiveReply(ref Message reply, object correlationState)
		{
			HttpResponseMessageProperty httpResponseMessage;
			object httpResponseMessageObject;

			if(reply.Properties.TryGetValue(HttpResponseMessageProperty.Name, out httpResponseMessageObject))
			{
				httpResponseMessage = httpResponseMessageObject as HttpResponseMessageProperty;
				if(httpResponseMessage != null)
				{
					var replyMessagesCookies = httpResponseMessage.Headers[HttpResponseHeader.SetCookie];
					//var replyMessagesCookies = httpResponseMessage.Headers["Cookie"];
					if(!string.IsNullOrEmpty(replyMessagesCookies))
					{
						var currentUrl = HttpContext.Current.Request.Url;
						var cookieContainer = new CookieContainer();
						cookieContainer.SetCookies(currentUrl, replyMessagesCookies );
						var cookieCollection = cookieContainer.GetCookies(currentUrl);

						for (int i = 0; i < cookieCollection.Count; i++)
						{
							var httpCookie = cookieCollection[i].ToHttpCookie();
							HttpContext.Current.Response.Cookies.Add(httpCookie);
						}

						//HttpContext.Current.Response.Headers["Set-Cookie"] = replyMessagesCookies;
					}
				}
			}
		}

		/// <summary>
		/// A kliens wcf hívás előtt beírja a sütiket a Wcf-nek küldendő HttpRequest-be
		/// </summary>
		public object BeforeSendRequest(ref Message request, IClientChannel channel)
		{
			HttpRequestMessageProperty httpRequestMessage;
			object httpRequestMessageObject;

			var cookieString = HttpContext.Current.Request.Headers["Cookie"];

			if(request.Properties.TryGetValue(HttpRequestMessageProperty.Name, out httpRequestMessageObject))
			{
				httpRequestMessage = httpRequestMessageObject as HttpRequestMessageProperty;
				if(httpRequestMessage != null)
					//if(string.IsNullOrEmpty(httpRequestMessage.Headers["Cookie"]))
					httpRequestMessage.Headers["Cookie"] = cookieString;
			}
			else
			{
				httpRequestMessage = new HttpRequestMessageProperty();
				httpRequestMessage.Headers.Add("Cookie", cookieString);
				request.Properties.Add(HttpRequestMessageProperty.Name, httpRequestMessage);
			}

			return null;
		}
	}
}