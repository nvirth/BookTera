using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;

namespace UtilsLocal.WCF.ThreadPrincipal
{
	public class ThreadPrincipalBehavior : IEndpointBehavior
	{
		public void AddBindingParameters(ServiceEndpoint serviceEndpoint, BindingParameterCollection bindingParameters) { }
		public void ApplyDispatchBehavior(ServiceEndpoint serviceEndpoint, EndpointDispatcher endpointDispatcher)
		{
			endpointDispatcher.DispatchRuntime.MessageInspectors.Add(new ThreadPrincipalMessageInspector());
		}
		public void Validate(ServiceEndpoint serviceEndpoint) { }
		public void ApplyClientBehavior(ServiceEndpoint serviceEndpoint, ClientRuntime behavior){}
	}
}