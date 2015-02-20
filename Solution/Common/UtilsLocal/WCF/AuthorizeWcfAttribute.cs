using System;
using System.Collections.ObjectModel;
using System.Net;
using System.Security.Authentication;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using System.ServiceModel.Web;
using System.Threading;

namespace UtilsLocal.WCF
{
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
	public class AuthorizeWcfAttribute : Attribute, IServiceBehavior, IOperationBehavior, IParameterInspector
	{
		#region IOperationBehavior Members
		
		void IOperationBehavior.ApplyDispatchBehavior(OperationDescription operationDescription, DispatchOperation dispatchOperation)
		{
			dispatchOperation.ParameterInspectors.Add(this);
		}
		void IOperationBehavior.AddBindingParameters(OperationDescription operationDescription, BindingParameterCollection bindingParameters){}
		void IOperationBehavior.ApplyClientBehavior(OperationDescription operationDescription, ClientOperation clientOperation){}
		void IOperationBehavior.Validate(OperationDescription operationDescription){}

		#endregion

		#region IServiceBehavior Members

		void IServiceBehavior.ApplyDispatchBehavior(ServiceDescription description, ServiceHostBase host)
		{
			foreach(ServiceEndpoint endpoint in host.Description.Endpoints)
			{
				foreach(var operation in endpoint.Contract.Operations)
				{
					if(!operation.Behaviors.Contains(this))
						operation.Behaviors.Add(this);
				}
			}
		}
		void IServiceBehavior.AddBindingParameters(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase, Collection<ServiceEndpoint> endpoints, BindingParameterCollection bindingParameters){}
		void IServiceBehavior.Validate(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase){}

		#endregion

		#region IParameterInspector Members

		void IParameterInspector.AfterCall(string operationName, object[] outputs, object returnValue, object correlationState){}
		object IParameterInspector.BeforeCall(string operationName, object[] inputs)
		{
			//if(!WebSecurity.IsAuthenticated)
			//if(!HttpContext.Current.User.Identity.IsAuthenticated)
			if(!Thread.CurrentPrincipal.Identity.IsAuthenticated)
			{
				// UnAuthorized would catch by FormsAuthenticationModule, and redirected to Login page (wich not exist in wcf)
				if(WebOperationContext.Current !=null)
					WebOperationContext.Current.OutgoingResponse.StatusCode = HttpStatusCode.Forbidden;
				
				//throw new FaultException("Access denied. ");
				throw new AuthenticationException("Access denied. ");
				//throw new HttpResponseException(HttpStatusCode.Forbidden);
			}

			return null;
		}

		#endregion
	}
}
