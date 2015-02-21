package com.booktera.services.BookManager;

public class IBookManagerProxy implements com.booktera.services.BookManager.IBookManager {
  private String _endpoint = null;
  private com.booktera.services.BookManager.IBookManager iBookManager = null;
  
  public IBookManagerProxy() {
    _initIBookManagerProxy();
  }
  
  public IBookManagerProxy(String endpoint) {
    _endpoint = endpoint;
    _initIBookManagerProxy();
  }
  
  private void _initIBookManagerProxy() {
    try {
      iBookManager = (new com.booktera.services.BookManager.BookManagerServiceLocator()).getBookManagerBasic();
      if (iBookManager != null) {
        if (_endpoint != null)
          ((javax.xml.rpc.Stub)iBookManager)._setProperty("javax.xml.rpc.service.endpoint.address", _endpoint);
        else
          _endpoint = (String)((javax.xml.rpc.Stub)iBookManager)._getProperty("javax.xml.rpc.service.endpoint.address");
      }
      
    }
    catch (javax.xml.rpc.ServiceException serviceException) {}
  }
  
  public String getEndpoint() {
    return _endpoint;
  }
  
  public void setEndpoint(String endpoint) {
    _endpoint = endpoint;
    if (iBookManager != null)
      ((javax.xml.rpc.Stub)iBookManager)._setProperty("javax.xml.rpc.service.endpoint.address", _endpoint);
    
  }
  
  public com.booktera.services.BookManager.IBookManager getIBookManager() {
    if (iBookManager == null)
      _initIBookManagerProxy();
    return iBookManager;
  }
  
  public com.booktera.data.CommonModels_Models_EntityFramework.Product uploadProduct(com.booktera.data.CommonModels_Models_ProductModels.CreatePVM model) throws java.rmi.RemoteException{
    if (iBookManager == null)
      _initIBookManagerProxy();
    return iBookManager.uploadProduct(model);
  }
  
  public void uploadProductNr(com.booktera.data.CommonModels_Models_ProductModels.CreatePVM model) throws java.rmi.RemoteException{
    if (iBookManager == null)
      _initIBookManagerProxy();
    iBookManager.uploadProductNr(model);
  }
  
  public com.booktera.data.CommonModels_Models_ProductModels.CreatePVMProductGroupVMWithValidation createProductGroupWithValidation(com.booktera.data.CommonModels_Models_ProductModels.CreatePVMProductGroupVM nonValidatedProductGroup) throws java.rmi.RemoteException{
    if (iBookManager == null)
      _initIBookManagerProxy();
    return iBookManager.createProductGroupWithValidation(nonValidatedProductGroup);
  }
  
  
}