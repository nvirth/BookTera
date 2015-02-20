using System;
using System.ServiceModel;
using System.ServiceModel.Web;
using UtilsLocal.WCF.Cookie;
using UtilsLocal.WCF.QueryStringConverterExtension;
using UtilsLocal.WCF.ThreadPrincipal;

namespace UtilsLocal.WCF
{
	/// <summary>
	/// Alapból hozzáadja a WebHttpBinding-os service endpoint-okhoz ezeket:
	/// 
	/// endpoint.Behaviors.Add(new QueryStringExtendedWebHttpBehavior());
	/// endpoint.Behaviors.Add(new ThreadPrincipalBehavior());
	/// 
	/// Így egyrészt nem kell a Web.Config-ban beállítani őket
	/// Másrészt a QueryStringConverter -es kiegészítés egy _bug miatt máshogy nem is működik 
	/// (itt nem a WebServiceHost-ból származunk, hanem a simából)
	/// </summary>
	public sealed class CustomWebServiceHost : ServiceHost
	{
		public CustomWebServiceHost() { }

		public CustomWebServiceHost(object singletonInstance, params Uri[] baseAddresses)
			: base(singletonInstance, baseAddresses) { }

		public CustomWebServiceHost(Type serviceType, params Uri[] baseAddresses)
			: base(serviceType, baseAddresses) { }

		protected override void OnOpening()
		{
			if(this.Description != null)
			{
				foreach(var endpoint in this.Description.Endpoints)
				{
					if(endpoint.Binding != null)
					{
						endpoint.Behaviors.Add(new ThreadPrincipalBehavior());

						if (endpoint.Binding is WebHttpBinding)
							endpoint.Behaviors.Add(new QueryStringExtendedWebHttpBehavior
							{
								DefaultOutgoingRequestFormat = WebMessageFormat.Json,
								DefaultOutgoingResponseFormat = WebMessageFormat.Json,
							});
					}
				}
			}

			base.OnOpening();
		}
	}
}