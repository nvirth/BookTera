package com.booktera.services.EntityManagers.AuthorManager;

public class IAuthorManagerProxy implements com.booktera.services.EntityManagers.AuthorManager.IAuthorManager {
  private String _endpoint = null;
  private com.booktera.services.EntityManagers.AuthorManager.IAuthorManager iAuthorManager = null;
  
  public IAuthorManagerProxy() {
    _initIAuthorManagerProxy();
  }
  
  public IAuthorManagerProxy(String endpoint) {
    _endpoint = endpoint;
    _initIAuthorManagerProxy();
  }
  
  private void _initIAuthorManagerProxy() {
    try {
      iAuthorManager = (new com.booktera.services.EntityManagers.AuthorManager.AuthorManagerServiceLocator()).getAuthorBasic();
      if (iAuthorManager != null) {
        if (_endpoint != null)
          ((javax.xml.rpc.Stub)iAuthorManager)._setProperty("javax.xml.rpc.service.endpoint.address", _endpoint);
        else
          _endpoint = (String)((javax.xml.rpc.Stub)iAuthorManager)._getProperty("javax.xml.rpc.service.endpoint.address");
      }
      
    }
    catch (javax.xml.rpc.ServiceException serviceException) {}
  }
  
  public String getEndpoint() {
    return _endpoint;
  }
  
  public void setEndpoint(String endpoint) {
    _endpoint = endpoint;
    if (iAuthorManager != null)
      ((javax.xml.rpc.Stub)iAuthorManager)._setProperty("javax.xml.rpc.service.endpoint.address", _endpoint);
    
  }
  
  public com.booktera.services.EntityManagers.AuthorManager.IAuthorManager getIAuthorManager() {
    if (iAuthorManager == null)
      _initIAuthorManagerProxy();
    return iAuthorManager;
  }
  
  public java.lang.String getSearchAutoComplete(java.lang.String authorName, java.lang.Integer howMany, java.lang.Boolean isValuePlain) throws java.rmi.RemoteException{
    if (iAuthorManager == null)
      _initIAuthorManagerProxy();
    return iAuthorManager.getSearchAutoComplete(authorName, howMany, isValuePlain);
  }
  
  
}