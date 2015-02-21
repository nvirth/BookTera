package com.booktera.proxy;

import com.booktera.services.EntityManagers.ImageManager.IImageManager;
import com.booktera.services.EntityManagers.ImageManager.ImageManagerServiceLocator;
import org.apache.axis.client.Stub;
import com.booktera.proxy.Cookie.ManagerStatic;

import javax.xml.rpc.ServiceException;
import java.rmi.RemoteException;

public class ImageManager
{
    // -- Init

	private static IImageManager initService()
	{
		try
		{
			ImageManagerServiceLocator locator = new ImageManagerServiceLocator();
			IImageManager service = locator.getImageBasic();

			ManagerStatic.beforeRequest((Stub) service);

			return service;
		} catch (ServiceException e)
		{
			throw new RuntimeException(e);
		}
	}

	private static void afterResponse(Stub service)
	{
		ManagerStatic.afterResponse(service);
	}

    // -- Overrides

    public static String GetUsersAvatar() throws RemoteException
    {
		IImageManager service = initService();
		String result = service.getUsersAvatar();
		afterResponse((Stub) service);

		return result;
    }
}
