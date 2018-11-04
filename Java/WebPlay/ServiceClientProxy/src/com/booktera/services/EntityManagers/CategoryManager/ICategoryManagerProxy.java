package com.booktera.services.EntityManagers.CategoryManager;

public class ICategoryManagerProxy implements com.booktera.services.EntityManagers.CategoryManager.ICategoryManager {
  private String _endpoint = null;
  private com.booktera.services.EntityManagers.CategoryManager.ICategoryManager iCategoryManager = null;
  
  public ICategoryManagerProxy() {
    _initICategoryManagerProxy();
  }
  
  public ICategoryManagerProxy(String endpoint) {
    _endpoint = endpoint;
    _initICategoryManagerProxy();
  }
  
  private void _initICategoryManagerProxy() {
    try {
      iCategoryManager = (new com.booktera.services.EntityManagers.CategoryManager.CategoryManagerServiceLocator()).getCategoryBasic();
      if (iCategoryManager != null) {
        if (_endpoint != null)
          ((javax.xml.rpc.Stub)iCategoryManager)._setProperty("javax.xml.rpc.service.endpoint.address", _endpoint);
        else
          _endpoint = (String)((javax.xml.rpc.Stub)iCategoryManager)._getProperty("javax.xml.rpc.service.endpoint.address");
      }
      
    }
    catch (javax.xml.rpc.ServiceException serviceException) {}
  }
  
  public String getEndpoint() {
    return _endpoint;
  }
  
  public void setEndpoint(String endpoint) {
    _endpoint = endpoint;
    if (iCategoryManager != null)
      ((javax.xml.rpc.Stub)iCategoryManager)._setProperty("javax.xml.rpc.service.endpoint.address", _endpoint);
    
  }
  
  public com.booktera.services.EntityManagers.CategoryManager.ICategoryManager getICategoryManager() {
    if (iCategoryManager == null)
      _initICategoryManagerProxy();
    return iCategoryManager;
  }
  
  public java.lang.String getAllForMenu(java.lang.String selected, java.lang.String[] openedIds) throws java.rmi.RemoteException{
    if (iCategoryManager == null)
      _initICategoryManagerProxy();
    return iCategoryManager.getAllForMenu(selected, openedIds);
  }
  
  public com.booktera.data.UtilsShared.SelectListItemWithClass[] getAllSortedJson(java.lang.Integer selectedCategoryId) throws java.rmi.RemoteException{
    if (iCategoryManager == null)
      _initICategoryManagerProxy();
    return iCategoryManager.getAllSortedJson(selectedCategoryId);
  }
  
  public com.booktera.data.CommonPortable_Models_ProductModels.InCategoryCWPLVM getCategoriesWithProductsInCategory(java.lang.Integer pageNumber, java.lang.Integer productsPerPage, java.lang.String baseCategoryFu) throws java.rmi.RemoteException{
    if (iCategoryManager == null)
      _initICategoryManagerProxy();
    return iCategoryManager.getCategoriesWithProductsInCategory(pageNumber, productsPerPage, baseCategoryFu);
  }
  
  
}