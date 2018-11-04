package com.booktera.services.EntityManagers.ImageManager;

public class IImageManagerProxy implements IImageManager
{
  private String _endpoint = null;
  private IImageManager iImageManager = null;
  
  public IImageManagerProxy() {
    _initIImageManagerProxy();
  }
  
  public IImageManagerProxy(String endpoint) {
    _endpoint = endpoint;
    _initIImageManagerProxy();
  }
  
  private void _initIImageManagerProxy() {
    try {
      iImageManager = (new com.booktera.services.EntityManagers.ImageManager.ImageManagerServiceLocator()).getImageBasic();
      if (iImageManager != null) {
        if (_endpoint != null)
          ((javax.xml.rpc.Stub)iImageManager)._setProperty("javax.xml.rpc.service.endpoint.address", _endpoint);
        else
          _endpoint = (String)((javax.xml.rpc.Stub)iImageManager)._getProperty("javax.xml.rpc.service.endpoint.address");
      }
      
    }
    catch (javax.xml.rpc.ServiceException serviceException) {}
  }
  
  public String getEndpoint() {
    return _endpoint;
  }
  
  public void setEndpoint(String endpoint) {
    _endpoint = endpoint;
    if (iImageManager != null)
      ((javax.xml.rpc.Stub)iImageManager)._setProperty("javax.xml.rpc.service.endpoint.address", _endpoint);
    
  }
  
  public IImageManager getIImageManager() {
    if (iImageManager == null)
      _initIImageManagerProxy();
    return iImageManager;
  }
  
  public java.lang.String getUsersAvatar() throws java.rmi.RemoteException{
    if (iImageManager == null)
      _initIImageManagerProxy();
    return iImageManager.getUsersAvatar();
  }
  
  public java.lang.String takeImageToItsFolder(byte[] stream) throws java.rmi.RemoteException{
    if (iImageManager == null)
      _initIImageManagerProxy();
    return iImageManager.takeImageToItsFolder(stream);
  }
  
  
}