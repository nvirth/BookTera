/**
 * AuthorManagerService.java
 *
 * This file was auto-generated from WSDL
 * by the Apache Axis 1.4 Apr 22, 2006 (06:55:48 PDT) WSDL2Java emitter.
 */

package com.booktera.services.EntityManagers.AuthorManager;

public interface AuthorManagerService extends javax.xml.rpc.Service {
    public java.lang.String getAuthorBasicAddress();

    public com.booktera.services.EntityManagers.AuthorManager.IAuthorManager getAuthorBasic() throws javax.xml.rpc.ServiceException;

    public com.booktera.services.EntityManagers.AuthorManager.IAuthorManager getAuthorBasic(java.net.URL portAddress) throws javax.xml.rpc.ServiceException;
}
