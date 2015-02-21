package com.booktera.services.EntityManagers.UserOrderManager;

public class IUserOrderManagerProxy implements com.booktera.services.EntityManagers.UserOrderManager.IUserOrderManager {
  private String _endpoint = null;
  private com.booktera.services.EntityManagers.UserOrderManager.IUserOrderManager iUserOrderManager = null;
  
  public IUserOrderManagerProxy() {
    _initIUserOrderManagerProxy();
  }
  
  public IUserOrderManagerProxy(String endpoint) {
    _endpoint = endpoint;
    _initIUserOrderManagerProxy();
  }
  
  private void _initIUserOrderManagerProxy() {
    try {
      iUserOrderManager = (new com.booktera.services.EntityManagers.UserOrderManager.UserOrderManagerServiceLocator()).getUserOrderBasic();
      if (iUserOrderManager != null) {
        if (_endpoint != null)
          ((javax.xml.rpc.Stub)iUserOrderManager)._setProperty("javax.xml.rpc.service.endpoint.address", _endpoint);
        else
          _endpoint = (String)((javax.xml.rpc.Stub)iUserOrderManager)._getProperty("javax.xml.rpc.service.endpoint.address");
      }
      
    }
    catch (javax.xml.rpc.ServiceException serviceException) {}
  }
  
  public String getEndpoint() {
    return _endpoint;
  }
  
  public void setEndpoint(String endpoint) {
    _endpoint = endpoint;
    if (iUserOrderManager != null)
      ((javax.xml.rpc.Stub)iUserOrderManager)._setProperty("javax.xml.rpc.service.endpoint.address", _endpoint);
    
  }
  
  public com.booktera.services.EntityManagers.UserOrderManager.IUserOrderManager getIUserOrderManager() {
    if (iUserOrderManager == null)
      _initIUserOrderManagerProxy();
    return iUserOrderManager;
  }
  
  public void updateUserOrdersAddress(java.lang.Integer userAddressId, java.lang.Integer userOrderId) throws java.rmi.RemoteException{
    if (iUserOrderManager == null)
      _initIUserOrderManagerProxy();
    iUserOrderManager.updateUserOrdersAddress(userAddressId, userOrderId);
  }
  
  
}