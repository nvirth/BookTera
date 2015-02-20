using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;
using CommonModels.Models;

namespace WcfInterfaces
{
	[ServiceContract]
	public interface ITransactionManager
	{
		[OperationContract]
		[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.WrappedRequest)]
		void AddProductToCart(int productId);

		[OperationContract]
		[WebInvoke(Method = "PUT", BodyStyle = WebMessageBodyStyle.WrappedRequest)]
		void UpdateProductInCart(int productInOrderId, int newHowMany);

		[OperationContract]
		[WebInvoke(Method = "DELETE", BodyStyle = WebMessageBodyStyle.WrappedRequest)]
		void RemoveUsersCart(int userOrderId);

		[OperationContract]
		[WebInvoke(Method = "DELETE", BodyStyle = WebMessageBodyStyle.WrappedRequest)]
		void RemoveUsersAllCarts();

		[OperationContract]
		[WebInvoke(Method = "DELETE", BodyStyle = WebMessageBodyStyle.WrappedRequest)]
		void RemoveProductFromCart(int productInOrderId);

		[OperationContract]
		[WebInvoke(Method = "PUT", BodyStyle = WebMessageBodyStyle.WrappedRequest)]
		void SendOrder(int userOrderId);

		[OperationContract]
		[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.WrappedRequest)]
		void AddExchangeProduct(int productId, int userOrderId);

		[OperationContract]
		[WebInvoke(Method = "PUT", BodyStyle = WebMessageBodyStyle.WrappedRequest)]
		void UpdateExchangeProduct(int productInOrderId, int newHowMany);
		
		[OperationContract]
		[WebInvoke(Method = "DELETE", BodyStyle = WebMessageBodyStyle.WrappedRequest)]
		void RemoveExchangeProduct(int productInOrderId);

		[OperationContract]
		[WebInvoke(Method = "DELETE", BodyStyle = WebMessageBodyStyle.WrappedRequest)]
		void RemoveExchangeCart(int userOrderId);

		[OperationContract]
		[WebInvoke(Method = "PUT", BodyStyle = WebMessageBodyStyle.WrappedRequest)]
		void SendExchangeOffer(int userOrderId);

		[OperationContract]
		[WebInvoke(Method = "PUT", BodyStyle = WebMessageBodyStyle.WrappedRequest)]
		void FinalizeOrderWithoutExchange(int userOrderId);

		[OperationContract]
		[WebInvoke(Method = "PUT", BodyStyle = WebMessageBodyStyle.WrappedRequest)]
		void FinalizeOrderAcceptExchange(int userOrderId);

		[OperationContract]
		[WebInvoke(Method = "PUT", BodyStyle = WebMessageBodyStyle.WrappedRequest)]
		void FinalizeOrderDenyExchange(int userOrderId);

		[OperationContract]
		[WebInvoke(Method = "PUT", BodyStyle = WebMessageBodyStyle.WrappedRequest)]
		void CloseOrderSuccessful(int userOrderId);

		[OperationContract]
		[WebInvoke(Method = "PUT", BodyStyle = WebMessageBodyStyle.WrappedRequest)]
		void CloseOrderUnsuccessful(int userOrderId);

		[OperationContract]
		[WebGet]
		List<UserOrderPLVM> GetUsersCartsVM(int? customerId = null, int? vendorId = null);

		[OperationContract]
		[WebGet]
		List<UserOrderPLVM> GetUsersInProgressOrdersVM(int? customerId = null, int? vendorId = null);

		[OperationContract]
		[WebGet]
		List<UserOrderPLVM> GetUsersFinishedTransactionsVM(int? customerId = null, int? vendorId = null);
	}
}
