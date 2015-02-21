package com.booktera.proxy;

import java.rmi.RemoteException;

import javax.xml.rpc.ServiceException;

import org.apache.axis.client.Stub;
import com.booktera.data.CommonModels_Models.CommentWithProductGroupVM;

import com.booktera.services.EntityManagers.CommentManager.CommentManagerServiceLocator;
import com.booktera.services.EntityManagers.CommentManager.ICommentManager;
import com.booktera.proxy.Cookie.ManagerStatic;

public class CommentManager
{
	// -- Init

	private static ICommentManager initService()
	{
		try
		{
			CommentManagerServiceLocator locator = new CommentManagerServiceLocator();
			ICommentManager service = locator.getCommentBasic();

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
	
	public static CommentWithProductGroupVM[] getUsersComments() throws RemoteException
	{
		ICommentManager service = initService();
		CommentWithProductGroupVM[] result = service.getUsersComments();
		afterServiceCall((Stub) service);
		
		return result;
	}

}
