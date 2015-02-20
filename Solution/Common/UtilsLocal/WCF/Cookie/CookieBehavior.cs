using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;

namespace UtilsLocal.WCF.Cookie
{
	public class CookieBehavior : IEndpointBehavior
	{
		public void AddBindingParameters(ServiceEndpoint serviceEndpoint, BindingParameterCollection bindingParameters) { }
		public void ApplyDispatchBehavior(ServiceEndpoint serviceEndpoint, EndpointDispatcher endpointDispatcher) { }
		public void Validate(ServiceEndpoint serviceEndpoint) { }
		public void ApplyClientBehavior(ServiceEndpoint serviceEndpoint, ClientRuntime behavior)
		{
			behavior.MessageInspectors.Add(new CookieMessageInspector());
		}
	}
}