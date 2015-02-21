/**
 * IBookteraAuthenticationService.java
 *
 * This file was auto-generated from WSDL
 * by the Apache Axis 1.4 Apr 22, 2006 (06:55:48 PDT) WSDL2Java emitter.
 */

package com.booktera.services.Authentication;

public interface IBookteraAuthenticationService extends java.rmi.Remote {
    public java.lang.Boolean login(java.lang.String userName, java.lang.String password, java.lang.Boolean persistent) throws java.rmi.RemoteException;
    public void loginAndGetId(java.lang.String userName, java.lang.String password, java.lang.Boolean persistent, javax.xml.rpc.holders.BooleanWrapperHolder wasSuccessful, javax.xml.rpc.holders.IntegerWrapperHolder userId) throws java.rmi.RemoteException;
    public void logout() throws java.rmi.RemoteException;
}
