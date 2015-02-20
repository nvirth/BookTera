using System;
using System.Collections.ObjectModel;
using System.Net;
using System.Text;
using Newtonsoft.Json;
using WinPhoneClientProxy.WcfProxy.Base;
using WinPhoneCommon;
using WinPhoneCommon.Models;

namespace WinPhoneClientProxy.WcfProxy
{
	public class TransactionManagerClient : RestServiceClientBase
	{
		public TransactionManagerClient()
			: base("http://localhost:50135/TransactionManagerService.svc")
		{
		}

		#region AddProductToCart

		public void AddProductToCart(int productId, Action todoAfterResponseReceived, Action<WebException> todoWithWebException)
		{
			GetAsync(new Request()
			{
				RequestUrl = BaseAddress + "/AddProductToCart",
				PostData = JsonConvert.SerializeObject(new { productId }),
				HttpPostVerb = HttpPostVerb.POST,
				TodoAfterResponseReceived = todoAfterResponseReceived,
				HandleWebException = todoWithWebException,
			});
		}

		#endregion

		#region UpdateProductInCart

		public void UpdateProductInCart(int productInOrderId, int newHowMany, Action todoAfterResponseReceived, Action<WebException> todoWithWebException)
		{
			GetAsync(new Request()
			{
				RequestUrl = BaseAddress + "/UpdateProductInCart",
				PostData = JsonConvert.SerializeObject(new { productInOrderId, newHowMany }),
				HttpPostVerb = HttpPostVerb.PUT,
				TodoAfterResponseReceived = todoAfterResponseReceived,
				HandleWebException = todoWithWebException,
			});
		}

		#endregion

		#region RemoveUsersCart

		public void RemoveUsersCart(int userOrderId, Action todoAfterResponseReceived, Action<WebException> todoWithWebException)
		{
			GetAsync(new Request()
			{
				RequestUrl = BaseAddress + "/RemoveUsersCart",
				PostData = JsonConvert.SerializeObject(new { userOrderId }),
				HttpPostVerb = HttpPostVerb.DELETE,
				TodoAfterResponseReceived = todoAfterResponseReceived,
				HandleWebException = todoWithWebException,
			});
		}

		#endregion

		#region RemoveUsersAllCarts

		public void RemoveUsersAllCarts(Action todoAfterResponseReceived, Action<WebException> todoWithWebException)
		{
			GetAsync(new Request()
			{
				RequestUrl = BaseAddress + "/RemoveUsersAllCarts",
				HttpPostVerb = HttpPostVerb.DELETE,
				TodoAfterResponseReceived = todoAfterResponseReceived,
				HandleWebException = todoWithWebException,
			});
		}

		#endregion

		#region RemoveProductFromCart

		public void RemoveProductFromCart(int productInOrderId, Action todoAfterResponseReceived, Action<WebException> todoWithWebException)
		{
			GetAsync(new Request()
			{
				RequestUrl = BaseAddress + "/RemoveProductFromCart",
				PostData = JsonConvert.SerializeObject(new { productInOrderId }),
				HttpPostVerb = HttpPostVerb.DELETE,
				TodoAfterResponseReceived = todoAfterResponseReceived,
				HandleWebException = todoWithWebException,
			});
		}

		#endregion

		#region SendOrder

		public void SendOrder(int userOrderId, Action todoAfterResponseReceived, Action<WebException> todoWithWebException)
		{
			GetAsync(new Request()
			{
				RequestUrl = BaseAddress + "/SendOrder",
				PostData = JsonConvert.SerializeObject(new { userOrderId }),
				HttpPostVerb = HttpPostVerb.PUT,
				TodoAfterResponseReceived = todoAfterResponseReceived,
				HandleWebException = todoWithWebException,
			});
		}

		#endregion

		#region AddExchangeProduct

		public void AddExchangeProduct(int productId, int userOrderId, Action todoAfterResponseReceived, Action<WebException> todoWithWebException)
		{
			GetAsync(new Request()
			{
				RequestUrl = BaseAddress + "/AddExchangeProduct",
				PostData = JsonConvert.SerializeObject(new { productId, userOrderId }),
				HttpPostVerb = HttpPostVerb.POST,
				TodoAfterResponseReceived = todoAfterResponseReceived,
				HandleWebException = todoWithWebException,
			});
		}

		#endregion

		#region UpdateExchangeProduct
		
		public void UpdateExchangeProduct(int productInOrderId, int newHowMany, Action todoAfterResponseReceived, Action<WebException> todoWithWebException)
		{
			GetAsync(new Request()
			{
				RequestUrl = BaseAddress + "/UpdateExchangeProduct",
				PostData = JsonConvert.SerializeObject(new { productInOrderId, newHowMany }),
				HttpPostVerb = HttpPostVerb.PUT,
				TodoAfterResponseReceived = todoAfterResponseReceived,
				HandleWebException = todoWithWebException,
			});
		}

		#endregion

		#region RemoveExchangeProduct

		public void RemoveExchangeProduct(int productInOrderId, Action todoAfterResponseReceived, Action<WebException> todoWithWebException)
		{
			GetAsync(new Request()
			{
				RequestUrl = BaseAddress + "/RemoveExchangeProduct",
				PostData = JsonConvert.SerializeObject(new { productInOrderId, }),
				HttpPostVerb = HttpPostVerb.DELETE,
				TodoAfterResponseReceived = todoAfterResponseReceived,
				HandleWebException = todoWithWebException,
			});
		}

		#endregion

		#region RemoveExchangeCart

		public void RemoveExchangeCart(int userOrderId, Action todoAfterResponseReceived, Action<WebException> todoWithWebException)
		{
			GetAsync(new Request()
			{
				RequestUrl = BaseAddress + "/RemoveExchangeCart",
				PostData = JsonConvert.SerializeObject(new { userOrderId, }),
				HttpPostVerb = HttpPostVerb.DELETE,
				TodoAfterResponseReceived = todoAfterResponseReceived,
				HandleWebException = todoWithWebException,
			});
		}

		#endregion

		#region SendExchangeOffer

		public void SendExchangeOffer(int userOrderId, Action todoAfterResponseReceived, Action<WebException> todoWithWebException)
		{
			GetAsync(new Request()
			{
				RequestUrl = BaseAddress + "/SendExchangeOffer",
				PostData = JsonConvert.SerializeObject(new { userOrderId, }),
				HttpPostVerb = HttpPostVerb.PUT,
				TodoAfterResponseReceived = todoAfterResponseReceived,
				HandleWebException = todoWithWebException,
			});
		}

		#endregion

		#region FinalizeOrderWithoutExchange

		public void FinalizeOrderWithoutExchange(int userOrderId, Action todoAfterResponseReceived, Action<WebException> todoWithWebException)
		{
			GetAsync(new Request()
			{
				RequestUrl = BaseAddress + "/FinalizeOrderWithoutExchange",
				PostData = JsonConvert.SerializeObject(new { userOrderId, }),
				HttpPostVerb = HttpPostVerb.PUT,
				TodoAfterResponseReceived = todoAfterResponseReceived,
				HandleWebException = todoWithWebException,
			});
		}

		#endregion

		#region FinalizeOrderAcceptExchange

		public void FinalizeOrderAcceptExchange(int userOrderId, Action todoAfterResponseReceived, Action<WebException> todoWithWebException)
		{
			GetAsync(new Request()
			{
				RequestUrl = BaseAddress + "/FinalizeOrderAcceptExchange",
				PostData = JsonConvert.SerializeObject(new { userOrderId, }),
				HttpPostVerb = HttpPostVerb.PUT,
				TodoAfterResponseReceived = todoAfterResponseReceived,
				HandleWebException = todoWithWebException,
			});
		}

		#endregion

		#region FinalizeOrderDenyExchange

		public void FinalizeOrderDenyExchange(int userOrderId, Action todoAfterResponseReceived, Action<WebException> todoWithWebException)
		{
			GetAsync(new Request()
			{
				RequestUrl = BaseAddress + "/FinalizeOrderDenyExchange",
				PostData = JsonConvert.SerializeObject(new { userOrderId, }),
				HttpPostVerb = HttpPostVerb.PUT,
				TodoAfterResponseReceived = todoAfterResponseReceived,
				HandleWebException = todoWithWebException,
			});
		}

		#endregion

		#region CloseOrderSuccessful

		public void CloseOrderSuccessful(int userOrderId, Action todoAfterResponseReceived, Action<WebException> todoWithWebException)
		{
			GetAsync(new Request()
			{
				RequestUrl = BaseAddress + "/CloseOrderSuccessful",
				PostData = JsonConvert.SerializeObject(new { userOrderId, }),
				HttpPostVerb = HttpPostVerb.PUT,
				TodoAfterResponseReceived = todoAfterResponseReceived,
				HandleWebException = todoWithWebException,
			});
		}

		#endregion

		#region CloseOrderUnsuccessful

		public void CloseOrderUnsuccessful(int userOrderId, Action todoAfterResponseReceived, Action<WebException> todoWithWebException)
		{
			GetAsync(new Request()
			{
				RequestUrl = BaseAddress + "/CloseOrderUnsuccessful",
				PostData = JsonConvert.SerializeObject(new { userOrderId, }),
				HttpPostVerb = HttpPostVerb.PUT,
				TodoAfterResponseReceived = todoAfterResponseReceived,
				HandleWebException = todoWithWebException,
			});
		}

		#endregion

		#region GetUsersCartsVM

		public void GetUsersCartsVM(int? customerId, int? vendorId, Action<ObservableCollection<UserOrderPlvmWp>> todoWithResponse, Action<WebException> todoWithWebException)
		{
			GetAsync(new Request<ObservableCollection<UserOrderPlvmWp>>()
			{
				RequestUrl = GetUsersCartsVM_BuildRequest(customerId, vendorId),
				TodoWithResponse = todoWithResponse,
				HandleWebException = todoWithWebException,
			});
		}

		/// <summary>
		/// http://localhost:50135/TransactionManagerService.svc/GetUsersCartsVM?customerId=&vendorId=1
		/// </summary>
		private string GetUsersCartsVM_BuildRequest(int? customerId, int? vendorId)
		{
			var stringBuilder = new StringBuilder();
			stringBuilder
				.Append(BaseAddress)
				.Append("/GetUsersCartsVM")
				.Append("?customerId=")
				.Append(customerId)
				.Append("&vendorId=")
				.Append(vendorId);
			return stringBuilder.ToString();
		}

		#endregion

		#region GetUsersInProgressOrdersVM

		public void GetUsersInProgressOrdersVM(int? customerId, int? vendorId, Action<ObservableCollection<UserOrderPlvmWp>> todoWithResponse, Action<WebException> todoWithWebException)
		{
			GetAsync(new Request<ObservableCollection<UserOrderPlvmWp>>()
			{
				RequestUrl = GetUsersInProgressOrdersVM_BuildRequest(customerId, vendorId),
				TodoWithResponse = todoWithResponse,
				HandleWebException = todoWithWebException,
			});
		}

		/// <summary>
		/// http://localhost:50135/TransactionManagerService.svc/GetUsersInProgressOrdersVM?customerId=&vendorId=1
		/// </summary>
		private string GetUsersInProgressOrdersVM_BuildRequest(int? customerId, int? vendorId)
		{
			var stringBuilder = new StringBuilder();
			stringBuilder
				.Append(BaseAddress)
				.Append("/GetUsersInProgressOrdersVM")
				.Append("?customerId=")
				.Append(customerId)
				.Append("&vendorId=")
				.Append(vendorId);
			return stringBuilder.ToString();
		}

		#endregion

		#region GetUsersFinishedTransactionsVM

		public void GetUsersFinishedTransactionsVM(int? customerId, int? vendorId, Action<ObservableCollection<UserOrderPlvmWp>> todoWithResponse, Action<WebException> todoWithWebException)
		{
			GetAsync(new Request<ObservableCollection<UserOrderPlvmWp>>()
			{
				RequestUrl = GetUsersFinishedTransactionsVM_BuildRequest(customerId, vendorId),
				TodoWithResponse = todoWithResponse,
				HandleWebException = todoWithWebException,
			});
		}

		/// <summary>
		/// http://localhost:50135/TransactionManagerService.svc/GetUsersFinishedTransactionsVM?customerId=&vendorId=1
		/// </summary>
		private string GetUsersFinishedTransactionsVM_BuildRequest(int? customerId, int? vendorId)
		{
			var stringBuilder = new StringBuilder();
			stringBuilder
				.Append(BaseAddress)
				.Append("/GetUsersFinishedTransactionsVM")
				.Append("?customerId=")
				.Append(customerId)
				.Append("&vendorId=")
				.Append(vendorId);
			return stringBuilder.ToString();
		}

		#endregion
	}
}
