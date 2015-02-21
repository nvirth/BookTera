package com.booktera.services.Authentication;

public class IBookteraAuthenticationServiceProxy implements com.booktera.services.Authentication.IBookteraAuthenticationService {
  private String _endpoint = null;
  private com.booktera.services.Authentication.IBookteraAuthenticationService iBookteraAuthenticationService = null;
  
  public IBookteraAuthenticationServiceProxy() {
    _initIBookteraAuthenticationServiceProxy();
  }
  
  public IBookteraAuthenticationServiceProxy(String endpoint) {
    _endpoint = endpoint;
    _initIBookteraAuthenticationServiceProxy();
  }
  
  private void _initIBookteraAuthenticationServiceProxy() {
    try {
      iBookteraAuthenticationService = (new com.booktera.services.Authentication.BookteraAuthenticationServiceLocator()).getBookteraAuthenticationBasic();
      if (iBookteraAuthenticationService != null) {
        if (_endpoint != null)
          ((javax.xml.rpc.Stub)iBookteraAuthenticationService)._setProperty("javax.xml.rpc.service.endpoint.address", _endpoint);
        else
          _endpoint = (String)((javax.xml.rpc.Stub)iBookteraAuthenticationService)._getProperty("javax.xml.rpc.service.endpoint.address");
      }
      
    }
    catch (javax.xml.rpc.ServiceException serviceException) {}
  }
  
  public String getEndpoint() {
    return _endpoint;
  }
  
  public void setEndpoint(String endpoint) {
    _endpoint = endpoint;
    if (iBookteraAuthenticationService != null)
      ((javax.xml.rpc.Stub)iBookteraAuthenticationService)._setProperty("javax.xml.rpc.service.endpoint.address", _endpoint);
    
  }
  
  public com.booktera.services.Authentication.IBookteraAuthenticationService getIBookteraAuthenticationService() {
    if (iBookteraAuthenticationService == null)
      _initIBookteraAuthenticationServiceProxy();
    return iBookteraAuthenticationService;
  }
  
  public java.lang.Boolean login(java.lang.String userName, java.lang.String password, java.lang.Boolean persistent) throws java.rmi.RemoteException{
    if (iBookteraAuthenticationService == null)
      _initIBookteraAuthenticationServiceProxy();
    return iBookteraAuthenticationService.login(userName, password, persistent);
  }
  
  public void loginAndGetId(java.lang.String userName, java.lang.String password, java.lang.Boolean persistent, javax.xml.rpc.holders.BooleanWrapperHolder wasSuccessful, javax.xml.rpc.holders.IntegerWrapperHolder userId) throws java.rmi.RemoteException{
    if (iBookteraAuthenticationService == null)
      _initIBookteraAuthenticationServiceProxy();
    iBookteraAuthenticationService.loginAndGetId(userName, password, persistent, wasSuccessful, userId);
  }
  
  public void logout() throws java.rmi.RemoteException{
    if (iBookteraAuthenticationService == null)
      _initIBookteraAuthenticationServiceProxy();
    iBookteraAuthenticationService.logout();
  }
  
  
}