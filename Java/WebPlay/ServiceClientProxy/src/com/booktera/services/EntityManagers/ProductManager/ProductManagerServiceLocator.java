/**
 * ProductManagerServiceLocator.java
 *
 * This file was auto-generated from WSDL
 * by the Apache Axis 1.4 Apr 22, 2006 (06:55:48 PDT) WSDL2Java emitter.
 */

package com.booktera.services.EntityManagers.ProductManager;

public class ProductManagerServiceLocator extends org.apache.axis.client.Service implements com.booktera.services.EntityManagers.ProductManager.ProductManagerService {

    public ProductManagerServiceLocator() {
    }


    public ProductManagerServiceLocator(org.apache.axis.EngineConfiguration config) {
        super(config);
    }

    public ProductManagerServiceLocator(java.lang.String wsdlLoc, javax.xml.namespace.QName sName) throws javax.xml.rpc.ServiceException {
        super(wsdlLoc, sName);
    }

    // Use to get a proxy class for ProductBasic
    private java.lang.String ProductBasic_address = "http://localhost:50135/EntityManagers/ProductManagerService.svc/basic";

    public java.lang.String getProductBasicAddress() {
        return ProductBasic_address;
    }

    // The WSDD service name defaults to the port name.
    private java.lang.String ProductBasicWSDDServiceName = "ProductBasic";

    public java.lang.String getProductBasicWSDDServiceName() {
        return ProductBasicWSDDServiceName;
    }

    public void setProductBasicWSDDServiceName(java.lang.String name) {
        ProductBasicWSDDServiceName = name;
    }

    public com.booktera.services.EntityManagers.ProductManager.IProductManager getProductBasic() throws javax.xml.rpc.ServiceException {
       java.net.URL endpoint;
        try {
            endpoint = new java.net.URL(ProductBasic_address);
        }
        catch (java.net.MalformedURLException e) {
            throw new javax.xml.rpc.ServiceException(e);
        }
        return getProductBasic(endpoint);
    }

    public com.booktera.services.EntityManagers.ProductManager.IProductManager getProductBasic(java.net.URL portAddress) throws javax.xml.rpc.ServiceException {
        try {
            com.booktera.services.EntityManagers.ProductManager.ProductBasicStub _stub = new com.booktera.services.EntityManagers.ProductManager.ProductBasicStub(portAddress, this);
            _stub.setPortName(getProductBasicWSDDServiceName());
            return _stub;
        }
        catch (org.apache.axis.AxisFault e) {
            return null;
        }
    }

    public void setProductBasicEndpointAddress(java.lang.String address) {
        ProductBasic_address = address;
    }

    /**
     * For the given interface, get the stub implementation.
     * If this service has no port for the given interface,
     * then ServiceException is thrown.
     */
    public java.rmi.Remote getPort(Class serviceEndpointInterface) throws javax.xml.rpc.ServiceException {
        try {
            if (com.booktera.services.EntityManagers.ProductManager.IProductManager.class.isAssignableFrom(serviceEndpointInterface)) {
                com.booktera.services.EntityManagers.ProductManager.ProductBasicStub _stub = new com.booktera.services.EntityManagers.ProductManager.ProductBasicStub(new java.net.URL(ProductBasic_address), this);
                _stub.setPortName(getProductBasicWSDDServiceName());
                return _stub;
            }
        }
        catch (java.lang.Throwable t) {
            throw new javax.xml.rpc.ServiceException(t);
        }
        throw new javax.xml.rpc.ServiceException("There is no stub implementation for the interface:  " + (serviceEndpointInterface == null ? "null" : serviceEndpointInterface.getName()));
    }

    /**
     * For the given interface, get the stub implementation.
     * If this service has no port for the given interface,
     * then ServiceException is thrown.
     */
    public java.rmi.Remote getPort(javax.xml.namespace.QName portName, Class serviceEndpointInterface) throws javax.xml.rpc.ServiceException {
        if (portName == null) {
            return getPort(serviceEndpointInterface);
        }
        java.lang.String inputPortName = portName.getLocalPart();
        if ("ProductBasic".equals(inputPortName)) {
            return getProductBasic();
        }
        else  {
            java.rmi.Remote _stub = getPort(serviceEndpointInterface);
            ((org.apache.axis.client.Stub) _stub).setPortName(portName);
            return _stub;
        }
    }

    public javax.xml.namespace.QName getServiceName() {
        return new javax.xml.namespace.QName("http://tempuri.org/", "ProductManagerService");
    }

    private java.util.HashSet ports = null;

    public java.util.Iterator getPorts() {
        if (ports == null) {
            ports = new java.util.HashSet();
            ports.add(new javax.xml.namespace.QName("http://tempuri.org/", "ProductBasic"));
        }
        return ports.iterator();
    }

    /**
    * Set the endpoint address for the specified port name.
    */
    public void setEndpointAddress(java.lang.String portName, java.lang.String address) throws javax.xml.rpc.ServiceException {
        
if ("ProductBasic".equals(portName)) {
            setProductBasicEndpointAddress(address);
        }
        else 
{ // Unknown Port Name
            throw new javax.xml.rpc.ServiceException(" Cannot set Endpoint Address for Unknown Port" + portName);
        }
    }

    /**
    * Set the endpoint address for the specified port name.
    */
    public void setEndpointAddress(javax.xml.namespace.QName portName, java.lang.String address) throws javax.xml.rpc.ServiceException {
        setEndpointAddress(portName.getLocalPart(), address);
    }

}
