package com.booktera.services.EntityManagers.UserAddressManager;

public class IUserAddressManagerProxy implements com.booktera.services.EntityManagers.UserAddressManager.IUserAddressManager {
  private String _endpoint = null;
  private com.booktera.services.EntityManagers.UserAddressManager.IUserAddressManager iUserAddressManager = null;
  
  public IUserAddressManagerProxy() {
    _initIUserAddressManagerProxy();
  }
  
  public IUserAddressManagerProxy(String endpoint) {
    _endpoint = endpoint;
    _initIUserAddressManagerProxy();
  }
  
  private void _initIUserAddressManagerProxy() {
    try {
      iUserAddressManager = (new com.booktera.services.EntityManagers.UserAddressManager.UserAddressManagerServiceLocator()).getUserAddressBasic();
      if (iUserAddressManager != null) {
        if (_endpoint != null)
          ((javax.xml.rpc.Stub)iUserAddressManager)._setProperty("javax.xml.rpc.service.endpoint.address", _endpoint);
        else
          _endpoint = (String)((javax.xml.rpc.Stub)iUserAddressManager)._getProperty("javax.xml.rpc.service.endpoint.address");
      }
      
    }
    catch (javax.xml.rpc.ServiceException serviceException) {}
  }
  
  public String getEndpoint() {
    return _endpoint;
  }
  
  public void setEndpoint(String endpoint) {
    _endpoint = endpoint;
    if (iUserAddressManager != null)
      ((javax.xml.rpc.Stub)iUserAddressManager)._setProperty("javax.xml.rpc.service.endpoint.address", _endpoint);
    
  }
  
  public com.booktera.services.EntityManagers.UserAddressManager.IUserAddressManager getIUserAddressManager() {
    if (iUserAddressManager == null)
      _initIUserAddressManagerProxy();
    return iUserAddressManager;
  }
  
  public java.lang.Integer addViaViewModel(com.booktera.data.CommonModels_Models.UserAddressVM userAddressVm) throws java.rmi.RemoteException{
    if (iUserAddressManager == null)
      _initIUserAddressManagerProxy();
    return iUserAddressManager.addViaViewModel(userAddressVm);
  }
  
  public com.booktera.data.CommonModels_Models.UserAddressVM[] getUsersAddresses() throws java.rmi.RemoteException{
    if (iUserAddressManager == null)
      _initIUserAddressManagerProxy();
    return iUserAddressManager.getUsersAddresses();
  }
  
  public void updateViaViewModel(com.booktera.data.CommonModels_Models.UserAddressVM userAddressVm) throws java.rmi.RemoteException{
    if (iUserAddressManager == null)
      _initIUserAddressManagerProxy();
    iUserAddressManager.updateViaViewModel(userAddressVm);
  }
  
  public void delete(java.lang.Integer userAddressId, java.lang.Boolean isDefault) throws java.rmi.RemoteException{
    if (iUserAddressManager == null)
      _initIUserAddressManagerProxy();
    iUserAddressManager.delete(userAddressId, isDefault);
  }
  
  
}