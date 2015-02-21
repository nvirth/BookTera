package com.booktera.services.EntityManagers.ProductManager;

public class IProductManagerProxy implements com.booktera.services.EntityManagers.ProductManager.IProductManager {
  private String _endpoint = null;
  private com.booktera.services.EntityManagers.ProductManager.IProductManager iProductManager = null;
  
  public IProductManagerProxy() {
    _initIProductManagerProxy();
  }
  
  public IProductManagerProxy(String endpoint) {
    _endpoint = endpoint;
    _initIProductManagerProxy();
  }
  
  private void _initIProductManagerProxy() {
    try {
      iProductManager = (new com.booktera.services.EntityManagers.ProductManager.ProductManagerServiceLocator()).getProductBasic();
      if (iProductManager != null) {
        if (_endpoint != null)
          ((javax.xml.rpc.Stub)iProductManager)._setProperty("javax.xml.rpc.service.endpoint.address", _endpoint);
        else
          _endpoint = (String)((javax.xml.rpc.Stub)iProductManager)._getProperty("javax.xml.rpc.service.endpoint.address");
      }
      
    }
    catch (javax.xml.rpc.ServiceException serviceException) {}
  }
  
  public String getEndpoint() {
    return _endpoint;
  }
  
  public void setEndpoint(String endpoint) {
    _endpoint = endpoint;
    if (iProductManager != null)
      ((javax.xml.rpc.Stub)iProductManager)._setProperty("javax.xml.rpc.service.endpoint.address", _endpoint);
    
  }
  
  public com.booktera.services.EntityManagers.ProductManager.IProductManager getIProductManager() {
    if (iProductManager == null)
      _initIProductManagerProxy();
    return iProductManager;
  }
  
  public com.booktera.data.CommonPortable_Models_ProductModels.InCategoryPLVM getProductsInCategory(java.lang.String categoryFriendlyUrl, java.lang.Integer pageNumber, java.lang.Integer productsPerPage) throws java.rmi.RemoteException{
    if (iProductManager == null)
      _initIProductManagerProxy();
    return iProductManager.getProductsInCategory(categoryFriendlyUrl, pageNumber, productsPerPage);
  }
  
  public com.booktera.data.CommonPortable_Models_ProductModels.BookBlockPLVM getMainHighlighteds(java.lang.Integer pageNumber, java.lang.Integer productsPerPage) throws java.rmi.RemoteException{
    if (iProductManager == null)
      _initIProductManagerProxy();
    return iProductManager.getMainHighlighteds(pageNumber, productsPerPage);
  }
  
  public com.booktera.data.CommonPortable_Models_ProductModels.BookBlockPLVM getNewests(java.lang.Integer pageNumber, java.lang.Integer productsPerPage, java.lang.Integer numOfProducts) throws java.rmi.RemoteException{
    if (iProductManager == null)
      _initIProductManagerProxy();
    return iProductManager.getNewests(pageNumber, productsPerPage, numOfProducts);
  }
  
  public void getUsersProductsByFriendlyUrl(java.lang.String friendlyUrl, java.lang.Integer pageNumber, java.lang.Integer productsPerPage, java.lang.Boolean forExchange, com.booktera.data.CommonPortable_Models_ProductModels.holders.BookBlockPLVMHolder getUsersProductsByFriendlyUrlResult, javax.xml.rpc.holders.StringHolder userName) throws java.rmi.RemoteException{
    if (iProductManager == null)
      _initIProductManagerProxy();
    iProductManager.getUsersProductsByFriendlyUrl(friendlyUrl, pageNumber, productsPerPage, forExchange, getUsersProductsByFriendlyUrlResult, userName);
  }
  
  public com.booktera.data.CommonPortable_Models_ProductModels.BookBlockPLVM getUsersProducts(java.lang.Integer userID, java.lang.Integer pageNumber, java.lang.Integer productsPerPage, java.lang.Boolean forExchange) throws java.rmi.RemoteException{
    if (iProductManager == null)
      _initIProductManagerProxy();
    return iProductManager.getUsersProducts(userID, pageNumber, productsPerPage, forExchange);
  }
  
  
}