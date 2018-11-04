/**
 * ICategoryManager.java
 *
 * This file was auto-generated from WSDL
 * by the Apache Axis 1.4 Apr 22, 2006 (06:55:48 PDT) WSDL2Java emitter.
 */

package com.booktera.services.EntityManagers.CategoryManager;

public interface ICategoryManager extends java.rmi.Remote {
    public java.lang.String getAllForMenu(java.lang.String selected, java.lang.String[] openedIds) throws java.rmi.RemoteException;
    public com.booktera.data.UtilsShared.SelectListItemWithClass[] getAllSortedJson(java.lang.Integer selectedCategoryId) throws java.rmi.RemoteException;
    public com.booktera.data.CommonPortable_Models_ProductModels.InCategoryCWPLVM getCategoriesWithProductsInCategory(java.lang.Integer pageNumber, java.lang.Integer productsPerPage, java.lang.String baseCategoryFu) throws java.rmi.RemoteException;
}
