package com.booktera.services.EntityManagers.RatingManager;

public class IRatingManagerProxy implements com.booktera.services.EntityManagers.RatingManager.IRatingManager {
  private String _endpoint = null;
  private com.booktera.services.EntityManagers.RatingManager.IRatingManager iRatingManager = null;
  
  public IRatingManagerProxy() {
    _initIRatingManagerProxy();
  }
  
  public IRatingManagerProxy(String endpoint) {
    _endpoint = endpoint;
    _initIRatingManagerProxy();
  }
  
  private void _initIRatingManagerProxy() {
    try {
      iRatingManager = (new com.booktera.services.EntityManagers.RatingManager.RatingManagerServiceLocator()).getRatingBasic();
      if (iRatingManager != null) {
        if (_endpoint != null)
          ((javax.xml.rpc.Stub)iRatingManager)._setProperty("javax.xml.rpc.service.endpoint.address", _endpoint);
        else
          _endpoint = (String)((javax.xml.rpc.Stub)iRatingManager)._getProperty("javax.xml.rpc.service.endpoint.address");
      }
      
    }
    catch (javax.xml.rpc.ServiceException serviceException) {}
  }
  
  public String getEndpoint() {
    return _endpoint;
  }
  
  public void setEndpoint(String endpoint) {
    _endpoint = endpoint;
    if (iRatingManager != null)
      ((javax.xml.rpc.Stub)iRatingManager)._setProperty("javax.xml.rpc.service.endpoint.address", _endpoint);
    
  }
  
  public com.booktera.services.EntityManagers.RatingManager.IRatingManager getIRatingManager() {
    if (iRatingManager == null)
      _initIRatingManagerProxy();
    return iRatingManager;
  }
  
  public com.booktera.data.CommonModels_Models.RatingWithProductGroupVM[] getUsersRatings() throws java.rmi.RemoteException{
    if (iRatingManager == null)
      _initIRatingManagerProxy();
    return iRatingManager.getUsersRatings();
  }
  
  
}