package com.booktera.services.RegistrationManager;

public class IRegistrationManagerProxy implements com.booktera.services.RegistrationManager.IRegistrationManager {
  private String _endpoint = null;
  private com.booktera.services.RegistrationManager.IRegistrationManager iRegistrationManager = null;
  
  public IRegistrationManagerProxy() {
    _initIRegistrationManagerProxy();
  }
  
  public IRegistrationManagerProxy(String endpoint) {
    _endpoint = endpoint;
    _initIRegistrationManagerProxy();
  }
  
  private void _initIRegistrationManagerProxy() {
    try {
      iRegistrationManager = (new com.booktera.services.RegistrationManager.RegistrationManagerServiceLocator()).getRegistrationManagerBasic();
      if (iRegistrationManager != null) {
        if (_endpoint != null)
          ((javax.xml.rpc.Stub)iRegistrationManager)._setProperty("javax.xml.rpc.service.endpoint.address", _endpoint);
        else
          _endpoint = (String)((javax.xml.rpc.Stub)iRegistrationManager)._getProperty("javax.xml.rpc.service.endpoint.address");
      }
      
    }
    catch (javax.xml.rpc.ServiceException serviceException) {}
  }
  
  public String getEndpoint() {
    return _endpoint;
  }
  
  public void setEndpoint(String endpoint) {
    _endpoint = endpoint;
    if (iRegistrationManager != null)
      ((javax.xml.rpc.Stub)iRegistrationManager)._setProperty("javax.xml.rpc.service.endpoint.address", _endpoint);
    
  }
  
  public com.booktera.services.RegistrationManager.IRegistrationManager getIRegistrationManager() {
    if (iRegistrationManager == null)
      _initIRegistrationManagerProxy();
    return iRegistrationManager;
  }
  
  public void registerUser(com.booktera.data.CommonModels_Models_AccountModels.RegisterVM registerVm) throws java.rmi.RemoteException{
    if (iRegistrationManager == null)
      _initIRegistrationManagerProxy();
    iRegistrationManager.registerUser(registerVm);
  }
  
  
}