/**
 * IProductGroupManager.java
 *
 * This file was auto-generated from WSDL
 * by the Apache Axis 1.4 Apr 22, 2006 (06:55:48 PDT) WSDL2Java emitter.
 */

package com.booktera.services.EntityManagers.ProductGroupManager;

public interface IProductGroupManager extends java.rmi.Remote {
    public com.booktera.data.CommonPortable_Models_ProductModels.BookRowPLVM getFullDetailed(java.lang.String friendlyUrl, java.lang.Integer pageNumber, java.lang.Integer productsPerPage) throws java.rmi.RemoteException;
    public com.booktera.data.UtilsShared.SelectListItemWithClass[] getAllSortedJson(java.lang.Integer selectedId) throws java.rmi.RemoteException;
    public com.booktera.data.CommonPortable_Models_ProductModels.BookBlockPLVM search(java.lang.String searchText, java.lang.Integer pageNumber, java.lang.Integer productsPerPage, java.lang.Boolean needCategory) throws java.rmi.RemoteException;
    public com.booktera.data.CommonPortable_Models_ProductModels.InCategoryCWPLVM searchWithGroupedByCategory(java.lang.String searchText, java.lang.Integer pageNumber, java.lang.Integer productsPerPage) throws java.rmi.RemoteException;
    public com.booktera.data.CommonPortable_Models.LabelValuePair[] searchAutoComplete(java.lang.String searchText, java.lang.Integer howMany) throws java.rmi.RemoteException;
    public com.booktera.data.CommonPortable_Models.SearchPgAcVm[] searchAutoCompletePg(java.lang.String searchText, java.lang.Integer howMany) throws java.rmi.RemoteException;
    public java.lang.String searchAutoCompleteJson(java.lang.String searchText, java.lang.Integer howMany) throws java.rmi.RemoteException;
    public com.booktera.data.CommonPortable_Models_ProductModels.BookBlockPLVM searchDetailed(com.booktera.data.CommonModels_Models.DetailedSearchVMDetailedSearchInputs dsi, java.lang.Integer pageNumber, java.lang.Integer productsPerPage) throws java.rmi.RemoteException;
}
