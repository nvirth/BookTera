/**
 * TransactionManagerService.java
 *
 * This file was auto-generated from WSDL
 * by the Apache Axis 1.4 Apr 22, 2006 (06:55:48 PDT) WSDL2Java emitter.
 */

package com.booktera.services.TransactionManager;

public interface TransactionManagerService extends javax.xml.rpc.Service {
    public java.lang.String getTransactionManagerBasicAddress();

    public com.booktera.services.TransactionManager.ITransactionManager getTransactionManagerBasic() throws javax.xml.rpc.ServiceException;

    public com.booktera.services.TransactionManager.ITransactionManager getTransactionManagerBasic(java.net.URL portAddress) throws javax.xml.rpc.ServiceException;
}
