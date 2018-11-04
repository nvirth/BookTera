package com.booktera.services.TransactionManager;

public class ITransactionManagerProxy implements com.booktera.services.TransactionManager.ITransactionManager {
  private String _endpoint = null;
  private com.booktera.services.TransactionManager.ITransactionManager iTransactionManager = null;
  
  public ITransactionManagerProxy() {
    _initITransactionManagerProxy();
  }
  
  public ITransactionManagerProxy(String endpoint) {
    _endpoint = endpoint;
    _initITransactionManagerProxy();
  }
  
  private void _initITransactionManagerProxy() {
    try {
      iTransactionManager = (new com.booktera.services.TransactionManager.TransactionManagerServiceLocator()).getTransactionManagerBasic();
      if (iTransactionManager != null) {
        if (_endpoint != null)
          ((javax.xml.rpc.Stub)iTransactionManager)._setProperty("javax.xml.rpc.service.endpoint.address", _endpoint);
        else
          _endpoint = (String)((javax.xml.rpc.Stub)iTransactionManager)._getProperty("javax.xml.rpc.service.endpoint.address");
      }
      
    }
    catch (javax.xml.rpc.ServiceException serviceException) {}
  }
  
  public String getEndpoint() {
    return _endpoint;
  }
  
  public void setEndpoint(String endpoint) {
    _endpoint = endpoint;
    if (iTransactionManager != null)
      ((javax.xml.rpc.Stub)iTransactionManager)._setProperty("javax.xml.rpc.service.endpoint.address", _endpoint);
    
  }
  
  public com.booktera.services.TransactionManager.ITransactionManager getITransactionManager() {
    if (iTransactionManager == null)
      _initITransactionManagerProxy();
    return iTransactionManager;
  }
  
  public void addProductToCart(java.lang.Integer productId) throws java.rmi.RemoteException{
    if (iTransactionManager == null)
      _initITransactionManagerProxy();
    iTransactionManager.addProductToCart(productId);
  }
  
  public void updateProductInCart(java.lang.Integer productInOrderId, java.lang.Integer newHowMany) throws java.rmi.RemoteException{
    if (iTransactionManager == null)
      _initITransactionManagerProxy();
    iTransactionManager.updateProductInCart(productInOrderId, newHowMany);
  }
  
  public void removeUsersCart(java.lang.Integer userOrderId) throws java.rmi.RemoteException{
    if (iTransactionManager == null)
      _initITransactionManagerProxy();
    iTransactionManager.removeUsersCart(userOrderId);
  }
  
  public void removeUsersAllCarts() throws java.rmi.RemoteException{
    if (iTransactionManager == null)
      _initITransactionManagerProxy();
    iTransactionManager.removeUsersAllCarts();
  }
  
  public void removeProductFromCart(java.lang.Integer productInOrderId) throws java.rmi.RemoteException{
    if (iTransactionManager == null)
      _initITransactionManagerProxy();
    iTransactionManager.removeProductFromCart(productInOrderId);
  }
  
  public void sendOrder(java.lang.Integer userOrderId) throws java.rmi.RemoteException{
    if (iTransactionManager == null)
      _initITransactionManagerProxy();
    iTransactionManager.sendOrder(userOrderId);
  }
  
  public void addExchangeProduct(java.lang.Integer productId, java.lang.Integer userOrderId) throws java.rmi.RemoteException{
    if (iTransactionManager == null)
      _initITransactionManagerProxy();
    iTransactionManager.addExchangeProduct(productId, userOrderId);
  }
  
  public void updateExchangeProduct(java.lang.Integer productInOrderId, java.lang.Integer newHowMany) throws java.rmi.RemoteException{
    if (iTransactionManager == null)
      _initITransactionManagerProxy();
    iTransactionManager.updateExchangeProduct(productInOrderId, newHowMany);
  }
  
  public void removeExchangeProduct(java.lang.Integer productInOrderId) throws java.rmi.RemoteException{
    if (iTransactionManager == null)
      _initITransactionManagerProxy();
    iTransactionManager.removeExchangeProduct(productInOrderId);
  }
  
  public void removeExchangeCart(java.lang.Integer userOrderId) throws java.rmi.RemoteException{
    if (iTransactionManager == null)
      _initITransactionManagerProxy();
    iTransactionManager.removeExchangeCart(userOrderId);
  }
  
  public void sendExchangeOffer(java.lang.Integer userOrderId) throws java.rmi.RemoteException{
    if (iTransactionManager == null)
      _initITransactionManagerProxy();
    iTransactionManager.sendExchangeOffer(userOrderId);
  }
  
  public void finalizeOrderWithoutExchange(java.lang.Integer userOrderId) throws java.rmi.RemoteException{
    if (iTransactionManager == null)
      _initITransactionManagerProxy();
    iTransactionManager.finalizeOrderWithoutExchange(userOrderId);
  }
  
  public void finalizeOrderAcceptExchange(java.lang.Integer userOrderId) throws java.rmi.RemoteException{
    if (iTransactionManager == null)
      _initITransactionManagerProxy();
    iTransactionManager.finalizeOrderAcceptExchange(userOrderId);
  }
  
  public void finalizeOrderDenyExchange(java.lang.Integer userOrderId) throws java.rmi.RemoteException{
    if (iTransactionManager == null)
      _initITransactionManagerProxy();
    iTransactionManager.finalizeOrderDenyExchange(userOrderId);
  }
  
  public void closeOrderSuccessful(java.lang.Integer userOrderId) throws java.rmi.RemoteException{
    if (iTransactionManager == null)
      _initITransactionManagerProxy();
    iTransactionManager.closeOrderSuccessful(userOrderId);
  }
  
  public void closeOrderUnsuccessful(java.lang.Integer userOrderId) throws java.rmi.RemoteException{
    if (iTransactionManager == null)
      _initITransactionManagerProxy();
    iTransactionManager.closeOrderUnsuccessful(userOrderId);
  }
  
  public com.booktera.data.CommonModels_Models.UserOrderPLVM[] getUsersCartsVM(java.lang.Integer customerId, java.lang.Integer vendorId) throws java.rmi.RemoteException{
    if (iTransactionManager == null)
      _initITransactionManagerProxy();
    return iTransactionManager.getUsersCartsVM(customerId, vendorId);
  }
  
  public com.booktera.data.CommonModels_Models.UserOrderPLVM[] getUsersInProgressOrdersVM(java.lang.Integer customerId, java.lang.Integer vendorId) throws java.rmi.RemoteException{
    if (iTransactionManager == null)
      _initITransactionManagerProxy();
    return iTransactionManager.getUsersInProgressOrdersVM(customerId, vendorId);
  }
  
  public com.booktera.data.CommonModels_Models.UserOrderPLVM[] getUsersFinishedTransactionsVM(java.lang.Integer customerId, java.lang.Integer vendorId) throws java.rmi.RemoteException{
    if (iTransactionManager == null)
      _initITransactionManagerProxy();
    return iTransactionManager.getUsersFinishedTransactionsVM(customerId, vendorId);
  }
  
  
}