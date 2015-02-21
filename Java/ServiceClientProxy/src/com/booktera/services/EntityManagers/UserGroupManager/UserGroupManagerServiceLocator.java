/**
 * UserGroupManagerServiceLocator.java
 *
 * This file was auto-generated from WSDL
 * by the Apache Axis 1.4 Apr 22, 2006 (06:55:48 PDT) WSDL2Java emitter.
 */

package com.booktera.services.EntityManagers.UserGroupManager;

public class UserGroupManagerServiceLocator extends org.apache.axis.client.Service implements com.booktera.services.EntityManagers.UserGroupManager.UserGroupManagerService {

    public UserGroupManagerServiceLocator() {
    }


    public UserGroupManagerServiceLocator(org.apache.axis.EngineConfiguration config) {
        super(config);
    }

    public UserGroupManagerServiceLocator(java.lang.String wsdlLoc, javax.xml.namespace.QName sName) throws javax.xml.rpc.ServiceException {
        super(wsdlLoc, sName);
    }

    // Use to get a proxy class for UserGroupBasic
    private java.lang.String UserGroupBasic_address = "http://localhost:50135/EntityManagers/UserGroupManagerService.svc/basic";

    public java.lang.String getUserGroupBasicAddress() {
        return UserGroupBasic_address;
    }

    // The WSDD service name defaults to the port name.
    private java.lang.String UserGroupBasicWSDDServiceName = "UserGroupBasic";

    public java.lang.String getUserGroupBasicWSDDServiceName() {
        return UserGroupBasicWSDDServiceName;
    }

    public void setUserGroupBasicWSDDServiceName(java.lang.String name) {
        UserGroupBasicWSDDServiceName = name;
    }

    public com.booktera.services.EntityManagers.UserGroupManager.IUserGroupManager getUserGroupBasic() throws javax.xml.rpc.ServiceException {
       java.net.URL endpoint;
        try {
            endpoint = new java.net.URL(UserGroupBasic_address);
        }
        catch (java.net.MalformedURLException e) {
            throw new javax.xml.rpc.ServiceException(e);
        }
        return getUserGroupBasic(endpoint);
    }

    public com.booktera.services.EntityManagers.UserGroupManager.IUserGroupManager getUserGroupBasic(java.net.URL portAddress) throws javax.xml.rpc.ServiceException {
        try {
            com.booktera.services.EntityManagers.UserGroupManager.UserGroupBasicStub _stub = new com.booktera.services.EntityManagers.UserGroupManager.UserGroupBasicStub(portAddress, this);
            _stub.setPortName(getUserGroupBasicWSDDServiceName());
            return _stub;
        }
        catch (org.apache.axis.AxisFault e) {
            return null;
        }
    }

    public void setUserGroupBasicEndpointAddress(java.lang.String address) {
        UserGroupBasic_address = address;
    }

    /**
     * For the given interface, get the stub implementation.
     * If this service has no port for the given interface,
     * then ServiceException is thrown.
     */
    public java.rmi.Remote getPort(Class serviceEndpointInterface) throws javax.xml.rpc.ServiceException {
        try {
            if (com.booktera.services.EntityManagers.UserGroupManager.IUserGroupManager.class.isAssignableFrom(serviceEndpointInterface)) {
                com.booktera.services.EntityManagers.UserGroupManager.UserGroupBasicStub _stub = new com.booktera.services.EntityManagers.UserGroupManager.UserGroupBasicStub(new java.net.URL(UserGroupBasic_address), this);
                _stub.setPortName(getUserGroupBasicWSDDServiceName());
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
        if ("UserGroupBasic".equals(inputPortName)) {
            return getUserGroupBasic();
        }
        else  {
            java.rmi.Remote _stub = getPort(serviceEndpointInterface);
            ((org.apache.axis.client.Stub) _stub).setPortName(portName);
            return _stub;
        }
    }

    public javax.xml.namespace.QName getServiceName() {
        return new javax.xml.namespace.QName("http://tempuri.org/", "UserGroupManagerService");
    }

    private java.util.HashSet ports = null;

    public java.util.Iterator getPorts() {
        if (ports == null) {
            ports = new java.util.HashSet();
            ports.add(new javax.xml.namespace.QName("http://tempuri.org/", "UserGroupBasic"));
        }
        return ports.iterator();
    }

    /**
    * Set the endpoint address for the specified port name.
    */
    public void setEndpointAddress(java.lang.String portName, java.lang.String address) throws javax.xml.rpc.ServiceException {
        
if ("UserGroupBasic".equals(portName)) {
            setUserGroupBasicEndpointAddress(address);
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
