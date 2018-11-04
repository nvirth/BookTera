package com.booktera.proxy;

import java.rmi.RemoteException;

import javax.xml.rpc.ServiceException;

import org.apache.axis.client.Stub;
import com.booktera.data.CommonModels_Models.UserOrderPLVM;

import com.booktera.services.TransactionManager.ITransactionManager;
import com.booktera.services.TransactionManager.TransactionManagerServiceLocator;
import com.booktera.proxy.Cookie.ManagerStatic;

public class TransactionManager
{
	// -- Init

	private static ITransactionManager initService()
	{
		try
		{
			TransactionManagerServiceLocator locator = new TransactionManagerServiceLocator();
			ITransactionManager service = locator.getTransactionManagerBasic();

			ManagerStatic.beforeRequest((Stub) service); 

			return service;
		} catch (ServiceException e)
		{
			throw new RuntimeException(e);
		}
	}

	private static void afterServiceCall(Stub service)
	{
		ManagerStatic.afterResponse(service);
	}

	// -- Overrides

	public static void addProductToCart(Integer productId) throws RemoteException
	{
		ITransactionManager service = initService();
		service.addProductToCart(productId);
		afterServiceCall((Stub) service);
	}

	public static void updateProductInCart(Integer productInOrderId, Integer newHowMany) throws RemoteException
	{
		ITransactionManager service = initService();
		service.updateProductInCart(productInOrderId, newHowMany);
		afterServiceCall((Stub) service);
	}

	public static void removeUsersCart(Integer userOrderId) throws RemoteException
	{
		ITransactionManager service = initService();
		service.removeUsersCart(userOrderId);
		afterServiceCall((Stub) service);
	}

	public static void removeUsersAllCarts() throws RemoteException
	{
		ITransactionManager service = initService();
		service.removeUsersAllCarts();
		afterServiceCall((Stub) service);

	}

	public static void removeProductFromCart(Integer productInOrderId) throws RemoteException
	{
		ITransactionManager service = initService();
		service.removeProductFromCart(productInOrderId);
		afterServiceCall((Stub) service);

	}

	public static void sendOrder(Integer userOrderId) throws RemoteException
	{
		ITransactionManager service = initService();
		service.sendOrder(userOrderId);
		afterServiceCall((Stub) service);
	}

	public static void addExchangeProduct(Integer productId, Integer userOrderId) throws RemoteException
	{
		ITransactionManager service = initService();
		service.addExchangeProduct(productId, userOrderId);
		afterServiceCall((Stub) service);
	}

	public static void updateExchangeProduct(Integer productInOrderId, Integer newHowMany) throws RemoteException
	{
		ITransactionManager service = initService();
		service.updateExchangeProduct(productInOrderId, newHowMany);
		afterServiceCall((Stub) service);
	}

	public static void removeExchangeProduct(Integer productInOrderId) throws RemoteException
	{
		ITransactionManager service = initService();
		service.removeExchangeProduct(productInOrderId);
		afterServiceCall((Stub) service);
	}

	public static void removeExchangeCart(Integer userOrderId) throws RemoteException
	{
		ITransactionManager service = initService();
		service.removeExchangeCart(userOrderId);
		afterServiceCall((Stub) service);
	}

	public static void sendExchangeOffer(Integer userOrderId) throws RemoteException
	{
		ITransactionManager service = initService();
		service.sendExchangeOffer(userOrderId);
		afterServiceCall((Stub) service);
	}

	public static void finalizeOrderWithoutExchange(Integer userOrderId) throws RemoteException
	{
		ITransactionManager service = initService();
		service.finalizeOrderWithoutExchange(userOrderId);
		afterServiceCall((Stub) service);
	}

	public static void finalizeOrderAcceptExchange(Integer userOrderId) throws RemoteException
	{
		ITransactionManager service = initService();
		service.finalizeOrderAcceptExchange(userOrderId);
		afterServiceCall((Stub) service);
	}

	public static void finalizeOrderDenyExchange(Integer userOrderId) throws RemoteException
	{
		ITransactionManager service = initService();
		service.finalizeOrderDenyExchange(userOrderId);
		afterServiceCall((Stub) service);
	}

	public static void closeOrderSuccessful(Integer userOrderId) throws RemoteException
	{
		ITransactionManager service = initService();
		service.closeOrderSuccessful(userOrderId);
		afterServiceCall((Stub) service);
	}

	public static void closeOrderUnsuccessful(Integer userOrderId) throws RemoteException
	{
		ITransactionManager service = initService();
		service.closeOrderUnsuccessful(userOrderId);
		afterServiceCall((Stub) service);
	}

	public static UserOrderPLVM[] getUsersCartsVM(Integer customerId, Integer vendorId) throws RemoteException
	{
		ITransactionManager service = initService();
		UserOrderPLVM[] result = service.getUsersCartsVM(customerId, vendorId);
		afterServiceCall((Stub) service);

		return result;
	}

	public static UserOrderPLVM[] getUsersInProgressOrdersVM(Integer customerId, Integer vendorId) throws RemoteException
	{
		ITransactionManager service = initService();
		UserOrderPLVM[] result = service.getUsersInProgressOrdersVM(customerId, vendorId);
		afterServiceCall((Stub) service);

		return result;
	}

	public static UserOrderPLVM[] getUsersFinishedTransactionsVM(Integer customerId, Integer vendorId) throws RemoteException
	{
		ITransactionManager service = initService();
		UserOrderPLVM[] result = service.getUsersFinishedTransactionsVM(customerId, vendorId);
		afterServiceCall((Stub) service);

		return result;
	}

}
