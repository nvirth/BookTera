using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace UtilsLocal.WCF
{
	public class ThreadPrincipalMessageInspector : IDispatchMessageInspector
	{
		public object AfterReceiveRequest(ref Message request, IClientChannel channel, InstanceContext instanceContext)
		{
			Thread.CurrentPrincipal = HttpContext.Current.User;
			return null;
		}

		public void BeforeSendReply(ref Message reply, object correlationState) { }
	}
}
