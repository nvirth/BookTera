package com.booktera.proxy;

import java.rmi.RemoteException;

import javax.xml.rpc.ServiceException;

import org.apache.axis.client.Stub;
import com.booktera.data.CommonPortable_Models_ProductModels.InCategoryCWPLVM;
import com.booktera.data.UtilsShared.SelectListItemWithClass;

import com.booktera.services.EntityManagers.CategoryManager.CategoryManagerServiceLocator;
import com.booktera.services.EntityManagers.CategoryManager.ICategoryManager;
import com.booktera.proxy.Cookie.ManagerStatic;

public class CategoryManager
{
    // -- Init

    private static ICategoryManager initService()
    {
        try
        {
            CategoryManagerServiceLocator locator = new CategoryManagerServiceLocator();
            ICategoryManager service = locator.getCategoryBasic();

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

    public static String getAllForMenu(String selected, String[] openedIds) throws RemoteException
    {
        ICategoryManager service = initService();
        String result = service.getAllForMenu(selected, openedIds);
        afterServiceCall((Stub) service);

        return result;
//                try
//        {
//            ICategoryManager service = initService();
//            String result = service.getAllForMenu(selected, openedIds);
//            afterResponse((Stub) service);
//
//            return result;
//        } catch (RemoteException e)
//        {
//            throw new RuntimeException(e);
//        }
    }

    public static SelectListItemWithClass[] getAllSortedJson(Integer selectedCategoryId) throws RemoteException
    {
        ICategoryManager service = initService();
        SelectListItemWithClass[] result = service.getAllSortedJson(selectedCategoryId);
        afterServiceCall((Stub) service);

        return result;
    }

    public static InCategoryCWPLVM getCategoriesWithProductsInCategory(Integer pageNumber, Integer productsPerPage, String baseCategoryFu) throws RemoteException
    {
        ICategoryManager service = initService();
        InCategoryCWPLVM result = service.getCategoriesWithProductsInCategory(pageNumber, productsPerPage, baseCategoryFu);
        afterServiceCall((Stub) service);

        return result;
    }

}
