package com.booktera.proxy;

import java.rmi.RemoteException;

import javax.xml.rpc.ServiceException;

import org.apache.axis.client.Stub;
import com.booktera.data.CommonModels_Models.UserAddressVM;

import com.booktera.services.EntityManagers.UserAddressManager.IUserAddressManager;
import com.booktera.services.EntityManagers.UserAddressManager.UserAddressManagerServiceLocator;
import com.booktera.proxy.Cookie.ManagerStatic;

public class UserAddressManager
{
	// -- Init

	private static IUserAddressManager initService()
	{
		try
		{
			UserAddressManagerServiceLocator locator = new UserAddressManagerServiceLocator();
			IUserAddressManager service = locator.getUserAddressBasic();

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
	
	public static Integer addViaViewModel(UserAddressVM userAddressVm) throws RemoteException
	{
		IUserAddressManager service = initService();
		Integer result = service.addViaViewModel(userAddressVm);
		afterServiceCall((Stub) service);
		
		return result;
	}

	public static UserAddressVM[] getUsersAddresses() throws RemoteException
	{
		IUserAddressManager service = initService();
		UserAddressVM[] result = service.getUsersAddresses();
		afterServiceCall((Stub) service);
		
		return result;
	}

	public static void updateViaViewModel(UserAddressVM userAddressVm) throws RemoteException
	{
		IUserAddressManager service = initService();
		service.updateViaViewModel(userAddressVm);
		afterServiceCall((Stub) service);
	}

	public static void delete(Integer userAddressId, Boolean isDefault) throws RemoteException
	{
		IUserAddressManager service = initService();
		service.delete(userAddressId, isDefault);
		afterServiceCall((Stub) service);
	}

}
