/**
 * BookManagerService.java
 *
 * This file was auto-generated from WSDL
 * by the Apache Axis 1.4 Apr 22, 2006 (06:55:48 PDT) WSDL2Java emitter.
 */

package com.booktera.services.BookManager;

public interface BookManagerService extends javax.xml.rpc.Service {
    public java.lang.String getBookManagerBasicAddress();

    public com.booktera.services.BookManager.IBookManager getBookManagerBasic() throws javax.xml.rpc.ServiceException;

    public com.booktera.services.BookManager.IBookManager getBookManagerBasic(java.net.URL portAddress) throws javax.xml.rpc.ServiceException;
}
