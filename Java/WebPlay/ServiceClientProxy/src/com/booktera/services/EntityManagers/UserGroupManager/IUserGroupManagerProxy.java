package com.booktera.services.EntityManagers.UserGroupManager;

public class IUserGroupManagerProxy implements com.booktera.services.EntityManagers.UserGroupManager.IUserGroupManager {
  private String _endpoint = null;
  private com.booktera.services.EntityManagers.UserGroupManager.IUserGroupManager iUserGroupManager = null;
  
  public IUserGroupManagerProxy() {
    _initIUserGroupManagerProxy();
  }
  
  public IUserGroupManagerProxy(String endpoint) {
    _endpoint = endpoint;
    _initIUserGroupManagerProxy();
  }
  
  private void _initIUserGroupManagerProxy() {
    try {
      iUserGroupManager = (new com.booktera.services.EntityManagers.UserGroupManager.UserGroupManagerServiceLocator()).getUserGroupBasic();
      if (iUserGroupManager != null) {
        if (_endpoint != null)
          ((javax.xml.rpc.Stub)iUserGroupManager)._setProperty("javax.xml.rpc.service.endpoint.address", _endpoint);
        else
          _endpoint = (String)((javax.xml.rpc.Stub)iUserGroupManager)._getProperty("javax.xml.rpc.service.endpoint.address");
      }
      
    }
    catch (javax.xml.rpc.ServiceException serviceException) {}
  }
  
  public String getEndpoint() {
    return _endpoint;
  }
  
  public void setEndpoint(String endpoint) {
    _endpoint = endpoint;
    if (iUserGroupManager != null)
      ((javax.xml.rpc.Stub)iUserGroupManager)._setProperty("javax.xml.rpc.service.endpoint.address", _endpoint);
    
  }
  
  public com.booktera.services.EntityManagers.UserGroupManager.IUserGroupManager getIUserGroupManager() {
    if (iUserGroupManager == null)
      _initIUserGroupManagerProxy();
    return iUserGroupManager;
  }
  
  public void getAllWithUsers(java.lang.Integer currentUserId, com.booktera.data.CommonModels_Models_EntityFramework.holders.ArrayOfUserGroupHolder getAllWithUsersResult, javax.xml.rpc.holders.IntegerWrapperHolder usersGroupId) throws java.rmi.RemoteException{
    if (iUserGroupManager == null)
      _initIUserGroupManagerProxy();
    iUserGroupManager.getAllWithUsers(currentUserId, getAllWithUsersResult, usersGroupId);
  }
  
  
}