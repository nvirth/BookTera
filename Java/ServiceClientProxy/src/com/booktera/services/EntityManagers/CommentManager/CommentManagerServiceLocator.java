/**
 * CommentManagerServiceLocator.java
 *
 * This file was auto-generated from WSDL
 * by the Apache Axis 1.4 Apr 22, 2006 (06:55:48 PDT) WSDL2Java emitter.
 */

package com.booktera.services.EntityManagers.CommentManager;

public class CommentManagerServiceLocator extends org.apache.axis.client.Service implements com.booktera.services.EntityManagers.CommentManager.CommentManagerService {

    public CommentManagerServiceLocator() {
    }


    public CommentManagerServiceLocator(org.apache.axis.EngineConfiguration config) {
        super(config);
    }

    public CommentManagerServiceLocator(java.lang.String wsdlLoc, javax.xml.namespace.QName sName) throws javax.xml.rpc.ServiceException {
        super(wsdlLoc, sName);
    }

    // Use to get a proxy class for CommentBasic
    private java.lang.String CommentBasic_address = "http://localhost:50135/EntityManagers/CommentManagerService.svc/basic";

    public java.lang.String getCommentBasicAddress() {
        return CommentBasic_address;
    }

    // The WSDD service name defaults to the port name.
    private java.lang.String CommentBasicWSDDServiceName = "CommentBasic";

    public java.lang.String getCommentBasicWSDDServiceName() {
        return CommentBasicWSDDServiceName;
    }

    public void setCommentBasicWSDDServiceName(java.lang.String name) {
        CommentBasicWSDDServiceName = name;
    }

    public com.booktera.services.EntityManagers.CommentManager.ICommentManager getCommentBasic() throws javax.xml.rpc.ServiceException {
       java.net.URL endpoint;
        try {
            endpoint = new java.net.URL(CommentBasic_address);
        }
        catch (java.net.MalformedURLException e) {
            throw new javax.xml.rpc.ServiceException(e);
        }
        return getCommentBasic(endpoint);
    }

    public com.booktera.services.EntityManagers.CommentManager.ICommentManager getCommentBasic(java.net.URL portAddress) throws javax.xml.rpc.ServiceException {
        try {
            com.booktera.services.EntityManagers.CommentManager.CommentBasicStub _stub = new com.booktera.services.EntityManagers.CommentManager.CommentBasicStub(portAddress, this);
            _stub.setPortName(getCommentBasicWSDDServiceName());
            return _stub;
        }
        catch (org.apache.axis.AxisFault e) {
            return null;
        }
    }

    public void setCommentBasicEndpointAddress(java.lang.String address) {
        CommentBasic_address = address;
    }

    /**
     * For the given interface, get the stub implementation.
     * If this service has no port for the given interface,
     * then ServiceException is thrown.
     */
    public java.rmi.Remote getPort(Class serviceEndpointInterface) throws javax.xml.rpc.ServiceException {
        try {
            if (com.booktera.services.EntityManagers.CommentManager.ICommentManager.class.isAssignableFrom(serviceEndpointInterface)) {
                com.booktera.services.EntityManagers.CommentManager.CommentBasicStub _stub = new com.booktera.services.EntityManagers.CommentManager.CommentBasicStub(new java.net.URL(CommentBasic_address), this);
                _stub.setPortName(getCommentBasicWSDDServiceName());
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
        if ("CommentBasic".equals(inputPortName)) {
            return getCommentBasic();
        }
        else  {
            java.rmi.Remote _stub = getPort(serviceEndpointInterface);
            ((org.apache.axis.client.Stub) _stub).setPortName(portName);
            return _stub;
        }
    }

    public javax.xml.namespace.QName getServiceName() {
        return new javax.xml.namespace.QName("http://tempuri.org/", "CommentManagerService");
    }

    private java.util.HashSet ports = null;

    public java.util.Iterator getPorts() {
        if (ports == null) {
            ports = new java.util.HashSet();
            ports.add(new javax.xml.namespace.QName("http://tempuri.org/", "CommentBasic"));
        }
        return ports.iterator();
    }

    /**
    * Set the endpoint address for the specified port name.
    */
    public void setEndpointAddress(java.lang.String portName, java.lang.String address) throws javax.xml.rpc.ServiceException {
        
if ("CommentBasic".equals(portName)) {
            setCommentBasicEndpointAddress(address);
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
