using System.Collections.Generic;
using BLL;
using CommonModels.Models;
using UtilsLocal.WCF;
using WcfInterfaces;
using WebMatrix.WebData;

namespace WcfHost
{
	[AuthorizeWcf]
	public class TransactionManagerService : ITransactionManager
	{
		List<UserOrderPLVM> ITransactionManager.GetUsersCartsVM(int? customerId, int? vendorId)
		{
			return TransactionManager.GetUsersCartsVM(customerId, vendorId);
		}

		List<UserOrderPLVM> ITransactionManager.GetUsersInProgressOrdersVM(int? customerId, int? vendorId)
		{
			return TransactionManager.GetUsersInProgressOrdersVM(customerId, vendorId);
		}

		List<UserOrderPLVM> ITransactionManager.GetUsersFinishedTransactionsVM(int? customerId, int? vendorId)
		{
			return TransactionManager.GetUsersFinishedTransactionsVM(customerId, vendorId);
		}

		void ITransactionManager.AddProductToCart(int productId)
		{
			TransactionManager.AddProductToCart(WebSecurity.CurrentUserId, productId);
		}

		void ITransactionManager.UpdateProductInCart(int productInOrderId, int newHowMany)
		{
			TransactionManager.UpdateProductInCart(WebSecurity.CurrentUserId, productInOrderId, newHowMany);
		}

		void ITransactionManager.RemoveProductFromCart(int productInOrderId)
		{
			TransactionManager.RemoveProductFromCart(productInOrderId, WebSecurity.CurrentUserId);
		}

		void ITransactionManager.RemoveUsersCart(int userOrderId)
		{
			TransactionManager.RemoveUsersCart(userOrderId, WebSecurity.CurrentUserId);
		}

		void ITransactionManager.RemoveUsersAllCarts()
		{
			TransactionManager.RemoveUsersAllCarts(WebSecurity.CurrentUserId);
		}

		void ITransactionManager.SendOrder(int userOrderId)
		{
			TransactionManager.SendOrder(userOrderId, WebSecurity.CurrentUserId);
		}

		void ITransactionManager.AddExchangeProduct(int productId, int userOrderId)
		{
			TransactionManager.AddExchangeProduct(productId, userOrderId, WebSecurity.CurrentUserId);
		}

		void ITransactionManager.UpdateExchangeProduct(int productInOrderId, int newHowMany)
		{
			TransactionManager.UpdateExchangeProduct(WebSecurity.CurrentUserId, productInOrderId, newHowMany);
		}

		void ITransactionManager.RemoveExchangeProduct(int productInOrderId)
		{
			TransactionManager.RemoveExchangeProduct(productInOrderId, WebSecurity.CurrentUserId);
		}

		void ITransactionManager.RemoveExchangeCart(int userOrderId)
		{
			TransactionManager.RemoveExchangeCart(userOrderId, WebSecurity.CurrentUserId);
		}

		void ITransactionManager.SendExchangeOffer(int userOrderId)
		{
			TransactionManager.SendExchangeOffer(userOrderId, WebSecurity.CurrentUserId);
		}

		void ITransactionManager.FinalizeOrderWithoutExchange(int userOrderId)
		{
			TransactionManager.FinalizeOrderWithoutExchange(userOrderId, WebSecurity.CurrentUserId);
		}

		void ITransactionManager.FinalizeOrderAcceptExchange(int userOrderId)
		{
			TransactionManager.FinalizeOrderAcceptExchange(userOrderId, WebSecurity.CurrentUserId);
		}

		void ITransactionManager.FinalizeOrderDenyExchange(int userOrderId)
		{
			TransactionManager.FinalizeOrderDenyExchange(userOrderId, WebSecurity.CurrentUserId);
		}

		void ITransactionManager.CloseOrderSuccessful(int userOrderId)
		{
			TransactionManager.CloseOrderSuccessful(userOrderId, WebSecurity.CurrentUserId);
		}

		void ITransactionManager.CloseOrderUnsuccessful(int userOrderId)
		{
			TransactionManager.CloseOrderUnsuccessful(userOrderId, WebSecurity.CurrentUserId);
		}
	}
}
