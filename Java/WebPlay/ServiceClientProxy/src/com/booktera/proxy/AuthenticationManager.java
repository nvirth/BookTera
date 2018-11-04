package com.booktera.proxy;

import java.rmi.RemoteException;

import javax.xml.rpc.ServiceException;
import javax.xml.rpc.holders.BooleanWrapperHolder;
import javax.xml.rpc.holders.IntegerWrapperHolder;

import org.apache.axis.client.Stub;

import com.booktera.services.Authentication.BookteraAuthenticationServiceLocator;
import com.booktera.services.Authentication.IBookteraAuthenticationService;
import com.booktera.proxy.Cookie.ManagerStatic;

public class AuthenticationManager
{
	// -- Init
	
	private static IBookteraAuthenticationService initService()
	{
		try
		{
			BookteraAuthenticationServiceLocator locator = new BookteraAuthenticationServiceLocator();
			IBookteraAuthenticationService service = locator.getBookteraAuthenticationBasic();

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

	public static Boolean login(String userName, String password, Boolean persistent) throws RemoteException
	{
		IBookteraAuthenticationService service = initService();
		Boolean result = service.login(userName, password, persistent);
		afterServiceCall((Stub) service);

		return result;
	}

	public static void loginAndGetId(String userName, String password, Boolean persistent, BooleanWrapperHolder wasSuccessful, IntegerWrapperHolder userId)
			throws RemoteException
	{
		IBookteraAuthenticationService service = initService();
		service.loginAndGetId(userName, password, persistent, wasSuccessful, userId);
		afterServiceCall((Stub) service);
	}

	public static void logout() throws RemoteException
	{
		IBookteraAuthenticationService service = initService();
		service.logout();
		afterServiceCall((Stub) service);
	}

}
