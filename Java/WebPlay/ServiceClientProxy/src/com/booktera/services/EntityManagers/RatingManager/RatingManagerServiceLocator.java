/**
 * RatingManagerServiceLocator.java
 *
 * This file was auto-generated from WSDL
 * by the Apache Axis 1.4 Apr 22, 2006 (06:55:48 PDT) WSDL2Java emitter.
 */

package com.booktera.services.EntityManagers.RatingManager;

public class RatingManagerServiceLocator extends org.apache.axis.client.Service implements com.booktera.services.EntityManagers.RatingManager.RatingManagerService {

    public RatingManagerServiceLocator() {
    }


    public RatingManagerServiceLocator(org.apache.axis.EngineConfiguration config) {
        super(config);
    }

    public RatingManagerServiceLocator(java.lang.String wsdlLoc, javax.xml.namespace.QName sName) throws javax.xml.rpc.ServiceException {
        super(wsdlLoc, sName);
    }

    // Use to get a proxy class for RatingBasic
    private java.lang.String RatingBasic_address = "http://localhost:50135/EntityManagers/RatingManagerService.svc/basic";

    public java.lang.String getRatingBasicAddress() {
        return RatingBasic_address;
    }

    // The WSDD service name defaults to the port name.
    private java.lang.String RatingBasicWSDDServiceName = "RatingBasic";

    public java.lang.String getRatingBasicWSDDServiceName() {
        return RatingBasicWSDDServiceName;
    }

    public void setRatingBasicWSDDServiceName(java.lang.String name) {
        RatingBasicWSDDServiceName = name;
    }

    public com.booktera.services.EntityManagers.RatingManager.IRatingManager getRatingBasic() throws javax.xml.rpc.ServiceException {
       java.net.URL endpoint;
        try {
            endpoint = new java.net.URL(RatingBasic_address);
        }
        catch (java.net.MalformedURLException e) {
            throw new javax.xml.rpc.ServiceException(e);
        }
        return getRatingBasic(endpoint);
    }

    public com.booktera.services.EntityManagers.RatingManager.IRatingManager getRatingBasic(java.net.URL portAddress) throws javax.xml.rpc.ServiceException {
        try {
            com.booktera.services.EntityManagers.RatingManager.RatingBasicStub _stub = new com.booktera.services.EntityManagers.RatingManager.RatingBasicStub(portAddress, this);
            _stub.setPortName(getRatingBasicWSDDServiceName());
            return _stub;
        }
        catch (org.apache.axis.AxisFault e) {
            return null;
        }
    }

    public void setRatingBasicEndpointAddress(java.lang.String address) {
        RatingBasic_address = address;
    }

    /**
     * For the given interface, get the stub implementation.
     * If this service has no port for the given interface,
     * then ServiceException is thrown.
     */
    public java.rmi.Remote getPort(Class serviceEndpointInterface) throws javax.xml.rpc.ServiceException {
        try {
            if (com.booktera.services.EntityManagers.RatingManager.IRatingManager.class.isAssignableFrom(serviceEndpointInterface)) {
                com.booktera.services.EntityManagers.RatingManager.RatingBasicStub _stub = new com.booktera.services.EntityManagers.RatingManager.RatingBasicStub(new java.net.URL(RatingBasic_address), this);
                _stub.setPortName(getRatingBasicWSDDServiceName());
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
        if ("RatingBasic".equals(inputPortName)) {
            return getRatingBasic();
        }
        else  {
            java.rmi.Remote _stub = getPort(serviceEndpointInterface);
            ((org.apache.axis.client.Stub) _stub).setPortName(portName);
            return _stub;
        }
    }

    public javax.xml.namespace.QName getServiceName() {
        return new javax.xml.namespace.QName("http://tempuri.org/", "RatingManagerService");
    }

    private java.util.HashSet ports = null;

    public java.util.Iterator getPorts() {
        if (ports == null) {
            ports = new java.util.HashSet();
            ports.add(new javax.xml.namespace.QName("http://tempuri.org/", "RatingBasic"));
        }
        return ports.iterator();
    }

    /**
    * Set the endpoint address for the specified port name.
    */
    public void setEndpointAddress(java.lang.String portName, java.lang.String address) throws javax.xml.rpc.ServiceException {
        
if ("RatingBasic".equals(portName)) {
            setRatingBasicEndpointAddress(address);
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
