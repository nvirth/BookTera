package com.booktera.proxy;

import java.rmi.RemoteException;

import javax.xml.rpc.ServiceException;

import org.apache.axis.client.Stub;
import com.booktera.data.CommonModels_Models_AccountModels.RegisterVM;

import com.booktera.services.RegistrationManager.IRegistrationManager;
import com.booktera.services.RegistrationManager.RegistrationManagerServiceLocator;
import com.booktera.proxy.Cookie.ManagerStatic;

public class RegistrationManager
{
	// -- Init

	private static IRegistrationManager initService()
	{
		try
		{
			RegistrationManagerServiceLocator locator = new RegistrationManagerServiceLocator();
			IRegistrationManager service = locator.getRegistrationManagerBasic();

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

	public static void registerUser(RegisterVM registerVm) throws RemoteException
	{
		IRegistrationManager service = initService();
		service.registerUser(registerVm);
		afterServiceCall((Stub) service);
	}

}
