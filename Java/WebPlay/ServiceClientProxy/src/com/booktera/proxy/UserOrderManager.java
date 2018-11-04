package com.booktera.proxy;

import java.rmi.RemoteException;

import javax.xml.rpc.ServiceException;

import org.apache.axis.client.Stub;

import com.booktera.services.EntityManagers.UserOrderManager.IUserOrderManager;
import com.booktera.services.EntityManagers.UserOrderManager.UserOrderManagerServiceLocator;
import com.booktera.proxy.Cookie.ManagerStatic;

public class UserOrderManager
{
	// -- Init

	private static IUserOrderManager initService()
	{
		try
		{
			UserOrderManagerServiceLocator locator = new UserOrderManagerServiceLocator();
			IUserOrderManager service = locator.getUserOrderBasic();

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
	public static void updateUserOrdersAddress(Integer userAddressId, Integer userOrderId) throws RemoteException
	{
		IUserOrderManager service = initService();
		service.updateUserOrdersAddress(userAddressId, userOrderId);
		afterServiceCall((Stub) service);
	}

}
