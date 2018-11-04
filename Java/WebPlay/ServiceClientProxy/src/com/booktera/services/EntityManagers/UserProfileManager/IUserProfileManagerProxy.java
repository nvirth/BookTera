package com.booktera.services.EntityManagers.UserProfileManager;

public class IUserProfileManagerProxy implements com.booktera.services.EntityManagers.UserProfileManager.IUserProfileManager {
  private String _endpoint = null;
  private com.booktera.services.EntityManagers.UserProfileManager.IUserProfileManager iUserProfileManager = null;
  
  public IUserProfileManagerProxy() {
    _initIUserProfileManagerProxy();
  }
  
  public IUserProfileManagerProxy(String endpoint) {
    _endpoint = endpoint;
    _initIUserProfileManagerProxy();
  }
  
  private void _initIUserProfileManagerProxy() {
    try {
      iUserProfileManager = (new com.booktera.services.EntityManagers.UserProfileManager.UserProfileManagerServiceLocator()).getUserProfileBasic();
      if (iUserProfileManager != null) {
        if (_endpoint != null)
          ((javax.xml.rpc.Stub)iUserProfileManager)._setProperty("javax.xml.rpc.service.endpoint.address", _endpoint);
        else
          _endpoint = (String)((javax.xml.rpc.Stub)iUserProfileManager)._getProperty("javax.xml.rpc.service.endpoint.address");
      }
      
    }
    catch (javax.xml.rpc.ServiceException serviceException) {}
  }
  
  public String getEndpoint() {
    return _endpoint;
  }
  
  public void setEndpoint(String endpoint) {
    _endpoint = endpoint;
    if (iUserProfileManager != null)
      ((javax.xml.rpc.Stub)iUserProfileManager)._setProperty("javax.xml.rpc.service.endpoint.address", _endpoint);
    
  }
  
  public com.booktera.services.EntityManagers.UserProfileManager.IUserProfileManager getIUserProfileManager() {
    if (iUserProfileManager == null)
      _initIUserProfileManagerProxy();
    return iUserProfileManager;
  }
  
  public com.booktera.data.CommonModels_Models.UserProfileEditVM getForEdit() throws java.rmi.RemoteException{
    if (iUserProfileManager == null)
      _initIUserProfileManagerProxy();
    return iUserProfileManager.getForEdit();
  }
  
  public void update(com.booktera.data.CommonModels_Models.UserProfileEditVM userProfileEdit) throws java.rmi.RemoteException{
    if (iUserProfileManager == null)
      _initIUserProfileManagerProxy();
    iUserProfileManager.update(userProfileEdit);
  }
  
  public java.lang.Boolean levelUpUser(com.booktera.data.CommonPortable_Enums.UserGroupEnum toUserGroup, java.lang.Boolean saveChanges) throws java.rmi.RemoteException{
    if (iUserProfileManager == null)
      _initIUserProfileManagerProxy();
    return iUserProfileManager.levelUpUser(toUserGroup, saveChanges);
  }
  
  public void updateDefaultAddress(java.lang.Integer newDefaultAddressId) throws java.rmi.RemoteException{
    if (iUserProfileManager == null)
      _initIUserProfileManagerProxy();
    iUserProfileManager.updateDefaultAddress(newDefaultAddressId);
  }
  
  public java.lang.Boolean checkUserNameUnique(java.lang.String userName) throws java.rmi.RemoteException{
    if (iUserProfileManager == null)
      _initIUserProfileManagerProxy();
    return iUserProfileManager.checkUserNameUnique(userName);
  }
  
  public java.lang.Boolean checkNewEmailUnique(java.lang.String email) throws java.rmi.RemoteException{
    if (iUserProfileManager == null)
      _initIUserProfileManagerProxy();
    return iUserProfileManager.checkNewEmailUnique(email);
  }
  
  public java.lang.Boolean checkEmailUnique(java.lang.String email) throws java.rmi.RemoteException{
    if (iUserProfileManager == null)
      _initIUserProfileManagerProxy();
    return iUserProfileManager.checkEmailUnique(email);
  }
  
  
}