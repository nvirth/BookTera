package com.booktera.services.EntityManagers.CommentManager;

public class ICommentManagerProxy implements com.booktera.services.EntityManagers.CommentManager.ICommentManager {
  private String _endpoint = null;
  private com.booktera.services.EntityManagers.CommentManager.ICommentManager iCommentManager = null;
  
  public ICommentManagerProxy() {
    _initICommentManagerProxy();
  }
  
  public ICommentManagerProxy(String endpoint) {
    _endpoint = endpoint;
    _initICommentManagerProxy();
  }
  
  private void _initICommentManagerProxy() {
    try {
      iCommentManager = (new com.booktera.services.EntityManagers.CommentManager.CommentManagerServiceLocator()).getCommentBasic();
      if (iCommentManager != null) {
        if (_endpoint != null)
          ((javax.xml.rpc.Stub)iCommentManager)._setProperty("javax.xml.rpc.service.endpoint.address", _endpoint);
        else
          _endpoint = (String)((javax.xml.rpc.Stub)iCommentManager)._getProperty("javax.xml.rpc.service.endpoint.address");
      }
      
    }
    catch (javax.xml.rpc.ServiceException serviceException) {}
  }
  
  public String getEndpoint() {
    return _endpoint;
  }
  
  public void setEndpoint(String endpoint) {
    _endpoint = endpoint;
    if (iCommentManager != null)
      ((javax.xml.rpc.Stub)iCommentManager)._setProperty("javax.xml.rpc.service.endpoint.address", _endpoint);
    
  }
  
  public com.booktera.services.EntityManagers.CommentManager.ICommentManager getICommentManager() {
    if (iCommentManager == null)
      _initICommentManagerProxy();
    return iCommentManager;
  }
  
  public com.booktera.data.CommonModels_Models.CommentWithProductGroupVM[] getUsersComments() throws java.rmi.RemoteException{
    if (iCommentManager == null)
      _initICommentManagerProxy();
    return iCommentManager.getUsersComments();
  }
  
  
}