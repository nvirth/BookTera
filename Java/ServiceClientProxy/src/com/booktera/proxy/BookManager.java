package com.booktera.proxy;

import java.rmi.RemoteException;

import javax.xml.rpc.ServiceException;

import org.apache.axis.client.Stub;
import com.booktera.data.CommonModels_Models_EntityFramework.Product;
import com.booktera.data.CommonModels_Models_ProductModels.CreatePVM;
import com.booktera.data.CommonModels_Models_ProductModels.CreatePVMProductGroupVM;
import com.booktera.data.CommonModels_Models_ProductModels.CreatePVMProductGroupVMWithValidation;

import com.booktera.services.BookManager.BookManagerServiceLocator;
import com.booktera.services.BookManager.IBookManager;
import com.booktera.proxy.Cookie.ManagerStatic;

public class BookManager
{
	// -- Init

	private static IBookManager initService()
	{
		try
		{
			BookManagerServiceLocator locator = new BookManagerServiceLocator();
			IBookManager service = locator.getBookManagerBasic();

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

	public static Product uploadProduct(CreatePVM model) throws RemoteException
	{
		IBookManager service = initService();
		Product result = service.uploadProduct(model);
		afterServiceCall((Stub) service);
		
		return result;
	}

	public static void uploadProductNr(CreatePVM model) throws RemoteException
	{
		IBookManager service = initService();
		service.uploadProductNr(model);
		afterServiceCall((Stub) service);
	}

	public static CreatePVMProductGroupVMWithValidation createProductGroupWithValidation(CreatePVMProductGroupVM nonValidatedProductGroup) throws RemoteException
	{
		IBookManager service = initService();
		CreatePVMProductGroupVMWithValidation result = service.createProductGroupWithValidation(nonValidatedProductGroup);
		afterServiceCall((Stub) service);
		
		return result;
	}
}
