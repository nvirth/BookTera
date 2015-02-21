package com.booktera.services.EntityManagers.ProductGroupManager;

public class IProductGroupManagerProxy implements com.booktera.services.EntityManagers.ProductGroupManager.IProductGroupManager {
  private String _endpoint = null;
  private com.booktera.services.EntityManagers.ProductGroupManager.IProductGroupManager iProductGroupManager = null;
  
  public IProductGroupManagerProxy() {
    _initIProductGroupManagerProxy();
  }
  
  public IProductGroupManagerProxy(String endpoint) {
    _endpoint = endpoint;
    _initIProductGroupManagerProxy();
  }
  
  private void _initIProductGroupManagerProxy() {
    try {
      iProductGroupManager = (new com.booktera.services.EntityManagers.ProductGroupManager.ProductGroupManagerServiceLocator()).getProductGroupBasic();
      if (iProductGroupManager != null) {
        if (_endpoint != null)
          ((javax.xml.rpc.Stub)iProductGroupManager)._setProperty("javax.xml.rpc.service.endpoint.address", _endpoint);
        else
          _endpoint = (String)((javax.xml.rpc.Stub)iProductGroupManager)._getProperty("javax.xml.rpc.service.endpoint.address");
      }
      
    }
    catch (javax.xml.rpc.ServiceException serviceException) {}
  }
  
  public String getEndpoint() {
    return _endpoint;
  }
  
  public void setEndpoint(String endpoint) {
    _endpoint = endpoint;
    if (iProductGroupManager != null)
      ((javax.xml.rpc.Stub)iProductGroupManager)._setProperty("javax.xml.rpc.service.endpoint.address", _endpoint);
    
  }
  
  public com.booktera.services.EntityManagers.ProductGroupManager.IProductGroupManager getIProductGroupManager() {
    if (iProductGroupManager == null)
      _initIProductGroupManagerProxy();
    return iProductGroupManager;
  }
  
  public com.booktera.data.CommonPortable_Models_ProductModels.BookRowPLVM getFullDetailed(java.lang.String friendlyUrl, java.lang.Integer pageNumber, java.lang.Integer productsPerPage) throws java.rmi.RemoteException{
    if (iProductGroupManager == null)
      _initIProductGroupManagerProxy();
    return iProductGroupManager.getFullDetailed(friendlyUrl, pageNumber, productsPerPage);
  }
  
  public com.booktera.data.UtilsShared.SelectListItemWithClass[] getAllSortedJson(java.lang.Integer selectedId) throws java.rmi.RemoteException{
    if (iProductGroupManager == null)
      _initIProductGroupManagerProxy();
    return iProductGroupManager.getAllSortedJson(selectedId);
  }
  
  public com.booktera.data.CommonPortable_Models_ProductModels.BookBlockPLVM search(java.lang.String searchText, java.lang.Integer pageNumber, java.lang.Integer productsPerPage, java.lang.Boolean needCategory) throws java.rmi.RemoteException{
    if (iProductGroupManager == null)
      _initIProductGroupManagerProxy();
    return iProductGroupManager.search(searchText, pageNumber, productsPerPage, needCategory);
  }
  
  public com.booktera.data.CommonPortable_Models_ProductModels.InCategoryCWPLVM searchWithGroupedByCategory(java.lang.String searchText, java.lang.Integer pageNumber, java.lang.Integer productsPerPage) throws java.rmi.RemoteException{
    if (iProductGroupManager == null)
      _initIProductGroupManagerProxy();
    return iProductGroupManager.searchWithGroupedByCategory(searchText, pageNumber, productsPerPage);
  }
  
  public com.booktera.data.CommonPortable_Models.LabelValuePair[] searchAutoComplete(java.lang.String searchText, java.lang.Integer howMany) throws java.rmi.RemoteException{
    if (iProductGroupManager == null)
      _initIProductGroupManagerProxy();
    return iProductGroupManager.searchAutoComplete(searchText, howMany);
  }
  
  public com.booktera.data.CommonPortable_Models.SearchPgAcVm[] searchAutoCompletePg(java.lang.String searchText, java.lang.Integer howMany) throws java.rmi.RemoteException{
    if (iProductGroupManager == null)
      _initIProductGroupManagerProxy();
    return iProductGroupManager.searchAutoCompletePg(searchText, howMany);
  }
  
  public java.lang.String searchAutoCompleteJson(java.lang.String searchText, java.lang.Integer howMany) throws java.rmi.RemoteException{
    if (iProductGroupManager == null)
      _initIProductGroupManagerProxy();
    return iProductGroupManager.searchAutoCompleteJson(searchText, howMany);
  }
  
  public com.booktera.data.CommonPortable_Models_ProductModels.BookBlockPLVM searchDetailed(com.booktera.data.CommonModels_Models.DetailedSearchVMDetailedSearchInputs dsi, java.lang.Integer pageNumber, java.lang.Integer productsPerPage) throws java.rmi.RemoteException{
    if (iProductGroupManager == null)
      _initIProductGroupManagerProxy();
    return iProductGroupManager.searchDetailed(dsi, pageNumber, productsPerPage);
  }
  
  
}