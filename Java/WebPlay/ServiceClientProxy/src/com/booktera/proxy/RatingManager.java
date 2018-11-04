package com.booktera.proxy;

import java.rmi.RemoteException;

import javax.xml.rpc.ServiceException;

import org.apache.axis.client.Stub;
import com.booktera.data.CommonModels_Models.RatingWithProductGroupVM;

import com.booktera.services.EntityManagers.RatingManager.IRatingManager;
import com.booktera.services.EntityManagers.RatingManager.RatingManagerServiceLocator;
import com.booktera.proxy.Cookie.ManagerStatic;

public class RatingManager
{
	// -- Init

	private static IRatingManager initService()
	{
		try
		{
			RatingManagerServiceLocator locator = new RatingManagerServiceLocator();
			IRatingManager service = locator.getRatingBasic();

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
	
	public static RatingWithProductGroupVM[] getUsersRatings() throws RemoteException
	{
		IRatingManager service = initService();
		RatingWithProductGroupVM[] result = service.getUsersRatings();
		afterServiceCall((Stub) service);
		
		return result;
	}

}
