package com.booktera.proxy;

import java.rmi.RemoteException;

import javax.xml.rpc.ServiceException;

import org.apache.axis.client.Stub;
import com.booktera.data.CommonModels_Models.UserProfileEditVM;
import com.booktera.data.CommonPortable_Enums.UserGroupEnum;

import com.booktera.services.EntityManagers.UserProfileManager.IUserProfileManager;
import com.booktera.services.EntityManagers.UserProfileManager.UserProfileManagerServiceLocator;
import com.booktera.proxy.Cookie.ManagerStatic;

public class UserProfileManager
{
	// -- Init

	private static IUserProfileManager initService()
	{
		try
		{
			UserProfileManagerServiceLocator locator = new UserProfileManagerServiceLocator();
			IUserProfileManager service = locator.getUserProfileBasic();

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

	public static UserProfileEditVM getForEdit() throws RemoteException
	{
		IUserProfileManager service = initService();
		UserProfileEditVM result = service.getForEdit();
		afterServiceCall((Stub) service);

		return result;
	}

	public static void update(UserProfileEditVM userProfileEdit) throws RemoteException
	{
		IUserProfileManager service = initService();
		service.update(userProfileEdit);
		afterServiceCall((Stub) service);
	}

	public static Boolean levelUpUser(UserGroupEnum toUserGroup, Boolean saveChanges) throws RemoteException
	{
		IUserProfileManager service = initService();
		Boolean result = service.levelUpUser(toUserGroup, saveChanges);
		afterServiceCall((Stub) service);

		return result;
	}

	public static void updateDefaultAddress(Integer newDefaultAddressId) throws RemoteException
	{
		IUserProfileManager service = initService();
		service.updateDefaultAddress(newDefaultAddressId);
		afterServiceCall((Stub) service);
	}

	public static Boolean checkUserNameUnique(String userName) throws RemoteException
	{
		IUserProfileManager service = initService();
		Boolean result = service.checkUserNameUnique(userName);
		afterServiceCall((Stub) service);

		return result;
	}

	public static Boolean checkNewEmailUnique(String email) throws RemoteException
	{
		IUserProfileManager service = initService();
		Boolean result = service.checkNewEmailUnique(email);
		afterServiceCall((Stub) service);

		return result;
	}

	public static Boolean checkEmailUnique(String email) throws RemoteException
	{
		IUserProfileManager service = initService();
		Boolean result = service.checkEmailUnique(email);
		afterServiceCall((Stub) service);

		return result;
	}

}
