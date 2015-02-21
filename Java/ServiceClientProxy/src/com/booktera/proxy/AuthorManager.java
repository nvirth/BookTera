package com.booktera.proxy;

import java.rmi.RemoteException;

import javax.xml.rpc.ServiceException;

import org.apache.axis.client.Stub;

import com.booktera.services.EntityManagers.AuthorManager.AuthorManagerServiceLocator;
import com.booktera.services.EntityManagers.AuthorManager.IAuthorManager;
import com.booktera.proxy.Cookie.ManagerStatic;

public class AuthorManager
{
	// -- Init

	private static IAuthorManager initService()
	{
		try
		{
			AuthorManagerServiceLocator locator = new AuthorManagerServiceLocator();
			IAuthorManager service = locator.getAuthorBasic();

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

	public static String getSearchAutoComplete(String authorName, Integer howMany, Boolean isValuePlain) throws RemoteException
	{
		IAuthorManager service = initService();
		String result = service.getSearchAutoComplete(authorName, howMany, isValuePlain);
		afterServiceCall((Stub) service);
		
		return result;
	}

}
