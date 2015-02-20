using System;
using System.Net;
using WinPhoneCommon;

namespace WinPhoneClientProxy.WcfProxy.Base
{
	public class Request
	{
		public string RequestUrl;
		public string PostData;
		public HttpPostVerb HttpPostVerb = HttpPostVerb.NON_POST__GET;
		public Action TodoAfterResponseReceived;
		public Action<WebException> HandleWebException;
	}

	public class Request<T>
	{
		public string RequestUrl;
		public string PostData;
		public HttpPostVerb HttpPostVerb = HttpPostVerb.NON_POST__GET;
		public Action<T> TodoWithResponse;
		public Action<WebException> HandleWebException;
	}
}