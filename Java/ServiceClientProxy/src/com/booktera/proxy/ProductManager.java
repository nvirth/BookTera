package com.booktera.proxy;

import java.rmi.RemoteException;

import javax.xml.rpc.ServiceException;
import javax.xml.rpc.holders.StringHolder;

import org.apache.axis.client.Stub;
import com.booktera.data.CommonPortable_Models_ProductModels.BookBlockPLVM;
import com.booktera.data.CommonPortable_Models_ProductModels.InCategoryPLVM;
import com.booktera.data.CommonPortable_Models_ProductModels.holders.BookBlockPLVMHolder;

import com.booktera.services.EntityManagers.ProductManager.IProductManager;
import com.booktera.services.EntityManagers.ProductManager.ProductManagerServiceLocator;
import com.booktera.proxy.Cookie.ManagerStatic;

public class ProductManager
{
	// -- Init

	private static IProductManager initService()
	{
		try
		{
			ProductManagerServiceLocator locator = new ProductManagerServiceLocator();
			IProductManager service = locator.getProductBasic();

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
	
	public static InCategoryPLVM getProductsInCategory(String categoryFriendlyUrl, Integer pageNumber, Integer productsPerPage) throws RemoteException
	{
		IProductManager service = initService();
		InCategoryPLVM result = service.getProductsInCategory(categoryFriendlyUrl, pageNumber, productsPerPage);
		afterServiceCall((Stub) service);
		
		return result;
	}

	public static BookBlockPLVM getMainHighlighteds(Integer pageNumber, Integer productsPerPage) throws RemoteException
	{
		IProductManager service = initService();
		BookBlockPLVM result = service.getMainHighlighteds(pageNumber, productsPerPage);
		afterServiceCall((Stub) service);
		
		return result;
	}

	public static BookBlockPLVM getNewests(Integer pageNumber, Integer productsPerPage, Integer numOfProducts) throws RemoteException
	{
		IProductManager service = initService();
		BookBlockPLVM result = service.getNewests(pageNumber, productsPerPage, numOfProducts);
		afterServiceCall((Stub) service);
		
		return result;
	}

	public static void getUsersProductsByFriendlyUrl(String friendlyUrl, Integer pageNumber, Integer productsPerPage, Boolean forExchange,
			BookBlockPLVMHolder getUsersProductsByFriendlyUrlResult, StringHolder userName) throws RemoteException
	{
		IProductManager service = initService();
		service.getUsersProductsByFriendlyUrl(friendlyUrl, pageNumber, productsPerPage, forExchange, getUsersProductsByFriendlyUrlResult, userName);
		afterServiceCall((Stub) service);
	}

	public static BookBlockPLVM getUsersProducts(Integer userID, Integer pageNumber, Integer productsPerPage, Boolean forExchange) throws RemoteException
	{
		IProductManager service = initService();
		BookBlockPLVM result = service.getUsersProducts(userID, pageNumber, productsPerPage, forExchange);
		afterServiceCall((Stub) service);
		
		return result;
	}

}
