/**
 * ProductManagerService.java
 *
 * This file was auto-generated from WSDL
 * by the Apache Axis 1.4 Apr 22, 2006 (06:55:48 PDT) WSDL2Java emitter.
 */

package com.booktera.services.EntityManagers.ProductManager;

public interface ProductManagerService extends javax.xml.rpc.Service {
    public java.lang.String getProductBasicAddress();

    public com.booktera.services.EntityManagers.ProductManager.IProductManager getProductBasic() throws javax.xml.rpc.ServiceException;

    public com.booktera.services.EntityManagers.ProductManager.IProductManager getProductBasic(java.net.URL portAddress) throws javax.xml.rpc.ServiceException;
}
