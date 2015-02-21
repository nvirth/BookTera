package com.booktera.proxy;

import java.rmi.RemoteException;

import javax.xml.rpc.ServiceException;

import org.apache.axis.client.Stub;
import com.booktera.data.CommonModels_Models.DetailedSearchVMDetailedSearchInputs;
import com.booktera.data.CommonPortable_Models.LabelValuePair;
import com.booktera.data.CommonPortable_Models.SearchPgAcVm;
import com.booktera.data.CommonPortable_Models_ProductModels.BookBlockPLVM;
import com.booktera.data.CommonPortable_Models_ProductModels.BookRowPLVM;
import com.booktera.data.CommonPortable_Models_ProductModels.InCategoryCWPLVM;
import com.booktera.data.UtilsShared.SelectListItemWithClass;

import com.booktera.services.EntityManagers.ProductGroupManager.IProductGroupManager;
import com.booktera.services.EntityManagers.ProductGroupManager.ProductGroupManagerServiceLocator;
import com.booktera.proxy.Cookie.ManagerStatic;

public class ProductGroupManager
{
	// -- Init

	private static IProductGroupManager initService()
	{
		try
		{
			ProductGroupManagerServiceLocator locator = new ProductGroupManagerServiceLocator();
			IProductGroupManager service = locator.getProductGroupBasic();

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

	public static BookRowPLVM getFullDetailed(String friendlyUrl, Integer pageNumber, Integer productsPerPage) throws RemoteException
	{
		IProductGroupManager service = initService();
		BookRowPLVM result = service.getFullDetailed(friendlyUrl, pageNumber, productsPerPage);
		afterServiceCall((Stub) service);
		
		return result;
	}

	public static SelectListItemWithClass[] getAllSortedJson(Integer selectedId) throws RemoteException
	{
		IProductGroupManager service = initService();
		SelectListItemWithClass[] result = service.getAllSortedJson(selectedId);
		afterServiceCall((Stub) service);
		
		return result;
	}

	public static BookBlockPLVM search(String searchText, Integer pageNumber, Integer productsPerPage, Boolean needCategory) throws RemoteException
	{
		IProductGroupManager service = initService();
		BookBlockPLVM result = service.search(searchText, pageNumber, productsPerPage, needCategory);
		afterServiceCall((Stub) service);
		
		return result;
	}

	public static InCategoryCWPLVM searchWithGroupedByCategory(String searchText, Integer pageNumber, Integer productsPerPage) throws RemoteException
	{
		IProductGroupManager service = initService();
		InCategoryCWPLVM result = service.searchWithGroupedByCategory(searchText, pageNumber, productsPerPage);
		afterServiceCall((Stub) service);
		
		return result;
	}

	public static LabelValuePair[] searchAutoComplete(String searchText, Integer howMany) throws RemoteException
	{
		IProductGroupManager service = initService();
		LabelValuePair[] result = service.searchAutoComplete(searchText, howMany);
		afterServiceCall((Stub) service);
		
		return result;
	}

	public static SearchPgAcVm[] searchAutoCompletePg(String searchText, Integer howMany) throws RemoteException
	{
		IProductGroupManager service = initService();
		SearchPgAcVm[] result = service.searchAutoCompletePg(searchText, howMany);
		afterServiceCall((Stub) service);
		
		return result;
	}

	public static String searchAutoCompleteJson(String searchText, Integer howMany) throws RemoteException
	{
		IProductGroupManager service = initService();
		String result = service.searchAutoCompleteJson(searchText, howMany);
		afterServiceCall((Stub) service);
		
		return result;
	}

	public static BookBlockPLVM searchDetailed(DetailedSearchVMDetailedSearchInputs dsi, Integer pageNumber, Integer productsPerPage) throws RemoteException
	{
		IProductGroupManager service = initService();
		BookBlockPLVM result = service.searchDetailed(dsi, pageNumber, productsPerPage);
		afterServiceCall((Stub) service);
		
		return result;
	}
}
