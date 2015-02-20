using System;
using System.ServiceModel;
using System.ServiceModel.Activation;

namespace UtilsLocal.WCF
{
	public sealed class CustomWebServiceHostFactory : ServiceHostFactory
	{
		protected override ServiceHost CreateServiceHost(Type serviceType, Uri[] baseAddresses)
		{
			return new CustomWebServiceHost(serviceType, baseAddresses);
		}
	}
}