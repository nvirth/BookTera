/**
 * IUserAddressManager.java
 *
 * This file was auto-generated from WSDL
 * by the Apache Axis 1.4 Apr 22, 2006 (06:55:48 PDT) WSDL2Java emitter.
 */

package com.booktera.services.EntityManagers.UserAddressManager;

public interface IUserAddressManager extends java.rmi.Remote {
    public java.lang.Integer addViaViewModel(com.booktera.data.CommonModels_Models.UserAddressVM userAddressVm) throws java.rmi.RemoteException;
    public com.booktera.data.CommonModels_Models.UserAddressVM[] getUsersAddresses() throws java.rmi.RemoteException;
    public void updateViaViewModel(com.booktera.data.CommonModels_Models.UserAddressVM userAddressVm) throws java.rmi.RemoteException;
    public void delete(java.lang.Integer userAddressId, java.lang.Boolean isDefault) throws java.rmi.RemoteException;
}
