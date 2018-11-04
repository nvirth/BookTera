package com.booktera.services.EntityManagers.PublisherManager;

public class IPublisherManagerProxy implements com.booktera.services.EntityManagers.PublisherManager.IPublisherManager {
  private String _endpoint = null;
  private com.booktera.services.EntityManagers.PublisherManager.IPublisherManager iPublisherManager = null;
  
  public IPublisherManagerProxy() {
    _initIPublisherManagerProxy();
  }
  
  public IPublisherManagerProxy(String endpoint) {
    _endpoint = endpoint;
    _initIPublisherManagerProxy();
  }
  
  private void _initIPublisherManagerProxy() {
    try {
      iPublisherManager = (new com.booktera.services.EntityManagers.PublisherManager.PublisherManagerServiceLocator()).getPublisherBasic();
      if (iPublisherManager != null) {
        if (_endpoint != null)
          ((javax.xml.rpc.Stub)iPublisherManager)._setProperty("javax.xml.rpc.service.endpoint.address", _endpoint);
        else
          _endpoint = (String)((javax.xml.rpc.Stub)iPublisherManager)._getProperty("javax.xml.rpc.service.endpoint.address");
      }
      
    }
    catch (javax.xml.rpc.ServiceException serviceException) {}
  }
  
  public String getEndpoint() {
    return _endpoint;
  }
  
  public void setEndpoint(String endpoint) {
    _endpoint = endpoint;
    if (iPublisherManager != null)
      ((javax.xml.rpc.Stub)iPublisherManager)._setProperty("javax.xml.rpc.service.endpoint.address", _endpoint);
    
  }
  
  public com.booktera.services.EntityManagers.PublisherManager.IPublisherManager getIPublisherManager() {
    if (iPublisherManager == null)
      _initIPublisherManagerProxy();
    return iPublisherManager;
  }
  
  public java.lang.String getSearchAutoComplete(java.lang.String publisherName, java.lang.Integer howMany, java.lang.Boolean isValuePlain) throws java.rmi.RemoteException{
    if (iPublisherManager == null)
      _initIPublisherManagerProxy();
    return iPublisherManager.getSearchAutoComplete(publisherName, howMany, isValuePlain);
  }
  
  
}