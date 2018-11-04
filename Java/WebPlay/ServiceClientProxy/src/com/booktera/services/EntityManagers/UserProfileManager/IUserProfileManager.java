/**
 * IUserProfileManager.java
 *
 * This file was auto-generated from WSDL
 * by the Apache Axis 1.4 Apr 22, 2006 (06:55:48 PDT) WSDL2Java emitter.
 */

package com.booktera.services.EntityManagers.UserProfileManager;

public interface IUserProfileManager extends java.rmi.Remote {
    public com.booktera.data.CommonModels_Models.UserProfileEditVM getForEdit() throws java.rmi.RemoteException;
    public void update(com.booktera.data.CommonModels_Models.UserProfileEditVM userProfileEdit) throws java.rmi.RemoteException;
    public java.lang.Boolean levelUpUser(com.booktera.data.CommonPortable_Enums.UserGroupEnum toUserGroup, java.lang.Boolean saveChanges) throws java.rmi.RemoteException;
    public void updateDefaultAddress(java.lang.Integer newDefaultAddressId) throws java.rmi.RemoteException;
    public java.lang.Boolean checkUserNameUnique(java.lang.String userName) throws java.rmi.RemoteException;
    public java.lang.Boolean checkNewEmailUnique(java.lang.String email) throws java.rmi.RemoteException;
    public java.lang.Boolean checkEmailUnique(java.lang.String email) throws java.rmi.RemoteException;
}
