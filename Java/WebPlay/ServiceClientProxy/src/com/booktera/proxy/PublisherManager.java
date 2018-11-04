package com.booktera.proxy;

import java.rmi.RemoteException;

import javax.xml.rpc.ServiceException;

import org.apache.axis.client.Stub;

import com.booktera.services.EntityManagers.PublisherManager.IPublisherManager;
import com.booktera.services.EntityManagers.PublisherManager.PublisherManagerServiceLocator;
import com.booktera.proxy.Cookie.ManagerStatic;

public class PublisherManager
{
	// -- Init

	private static IPublisherManager initService()
	{
		try
		{
			PublisherManagerServiceLocator locator = new PublisherManagerServiceLocator();
			IPublisherManager service = locator.getPublisherBasic();

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
	
	public static String getSearchAutoComplete(String publisherName, Integer howMany, Boolean isValuePlain) throws RemoteException
	{
		IPublisherManager service = initService();
		String result = service.getSearchAutoComplete(publisherName, howMany, isValuePlain);
		afterServiceCall((Stub) service);
		
		return result;
	}

}
