/**
 * ITransactionManager.java
 *
 * This file was auto-generated from WSDL
 * by the Apache Axis 1.4 Apr 22, 2006 (06:55:48 PDT) WSDL2Java emitter.
 */

package com.booktera.services.TransactionManager;

public interface ITransactionManager extends java.rmi.Remote {
    public void addProductToCart(java.lang.Integer productId) throws java.rmi.RemoteException;
    public void updateProductInCart(java.lang.Integer productInOrderId, java.lang.Integer newHowMany) throws java.rmi.RemoteException;
    public void removeUsersCart(java.lang.Integer userOrderId) throws java.rmi.RemoteException;
    public void removeUsersAllCarts() throws java.rmi.RemoteException;
    public void removeProductFromCart(java.lang.Integer productInOrderId) throws java.rmi.RemoteException;
    public void sendOrder(java.lang.Integer userOrderId) throws java.rmi.RemoteException;
    public void addExchangeProduct(java.lang.Integer productId, java.lang.Integer userOrderId) throws java.rmi.RemoteException;
    public void updateExchangeProduct(java.lang.Integer productInOrderId, java.lang.Integer newHowMany) throws java.rmi.RemoteException;
    public void removeExchangeProduct(java.lang.Integer productInOrderId) throws java.rmi.RemoteException;
    public void removeExchangeCart(java.lang.Integer userOrderId) throws java.rmi.RemoteException;
    public void sendExchangeOffer(java.lang.Integer userOrderId) throws java.rmi.RemoteException;
    public void finalizeOrderWithoutExchange(java.lang.Integer userOrderId) throws java.rmi.RemoteException;
    public void finalizeOrderAcceptExchange(java.lang.Integer userOrderId) throws java.rmi.RemoteException;
    public void finalizeOrderDenyExchange(java.lang.Integer userOrderId) throws java.rmi.RemoteException;
    public void closeOrderSuccessful(java.lang.Integer userOrderId) throws java.rmi.RemoteException;
    public void closeOrderUnsuccessful(java.lang.Integer userOrderId) throws java.rmi.RemoteException;
    public com.booktera.data.CommonModels_Models.UserOrderPLVM[] getUsersCartsVM(java.lang.Integer customerId, java.lang.Integer vendorId) throws java.rmi.RemoteException;
    public com.booktera.data.CommonModels_Models.UserOrderPLVM[] getUsersInProgressOrdersVM(java.lang.Integer customerId, java.lang.Integer vendorId) throws java.rmi.RemoteException;
    public com.booktera.data.CommonModels_Models.UserOrderPLVM[] getUsersFinishedTransactionsVM(java.lang.Integer customerId, java.lang.Integer vendorId) throws java.rmi.RemoteException;
}
