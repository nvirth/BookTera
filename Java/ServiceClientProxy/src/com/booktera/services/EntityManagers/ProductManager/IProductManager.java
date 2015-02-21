/**
 * IProductManager.java
 *
 * This file was auto-generated from WSDL
 * by the Apache Axis 1.4 Apr 22, 2006 (06:55:48 PDT) WSDL2Java emitter.
 */

package com.booktera.services.EntityManagers.ProductManager;

public interface IProductManager extends java.rmi.Remote {
    public com.booktera.data.CommonPortable_Models_ProductModels.InCategoryPLVM getProductsInCategory(java.lang.String categoryFriendlyUrl, java.lang.Integer pageNumber, java.lang.Integer productsPerPage) throws java.rmi.RemoteException;
    public com.booktera.data.CommonPortable_Models_ProductModels.BookBlockPLVM getMainHighlighteds(java.lang.Integer pageNumber, java.lang.Integer productsPerPage) throws java.rmi.RemoteException;
    public com.booktera.data.CommonPortable_Models_ProductModels.BookBlockPLVM getNewests(java.lang.Integer pageNumber, java.lang.Integer productsPerPage, java.lang.Integer numOfProducts) throws java.rmi.RemoteException;
    public void getUsersProductsByFriendlyUrl(java.lang.String friendlyUrl, java.lang.Integer pageNumber, java.lang.Integer productsPerPage, java.lang.Boolean forExchange, com.booktera.data.CommonPortable_Models_ProductModels.holders.BookBlockPLVMHolder getUsersProductsByFriendlyUrlResult, javax.xml.rpc.holders.StringHolder userName) throws java.rmi.RemoteException;
    public com.booktera.data.CommonPortable_Models_ProductModels.BookBlockPLVM getUsersProducts(java.lang.Integer userID, java.lang.Integer pageNumber, java.lang.Integer productsPerPage, java.lang.Boolean forExchange) throws java.rmi.RemoteException;
}
