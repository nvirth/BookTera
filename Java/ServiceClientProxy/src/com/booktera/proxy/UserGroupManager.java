package com.booktera.proxy;

import java.rmi.RemoteException;

import javax.xml.rpc.ServiceException;
import javax.xml.rpc.holders.IntegerWrapperHolder;

import org.apache.axis.client.Stub;
import com.booktera.data.CommonModels_Models_EntityFramework.holders.ArrayOfUserGroupHolder;

import com.booktera.services.EntityManagers.UserGroupManager.IUserGroupManager;
import com.booktera.services.EntityManagers.UserGroupManager.UserGroupManagerServiceLocator;
import com.booktera.proxy.Cookie.ManagerStatic;

public class UserGroupManager
{
	// -- Init

	private static IUserGroupManager initService()
	{
		try
		{
			UserGroupManagerServiceLocator locator = new UserGroupManagerServiceLocator();
			IUserGroupManager service = locator.getUserGroupBasic();

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

	public static void getAllWithUsers(Integer currentUserId, ArrayOfUserGroupHolder getAllWithUsersResult, IntegerWrapperHolder usersGroupId) throws RemoteException
	{
		IUserGroupManager service = initService();
		service.getAllWithUsers(currentUserId, getAllWithUsersResult, usersGroupId);
		afterServiceCall((Stub) service);
	}

}
