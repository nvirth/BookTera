/**
 * IUserGroupManager.java
 *
 * This file was auto-generated from WSDL
 * by the Apache Axis 1.4 Apr 22, 2006 (06:55:48 PDT) WSDL2Java emitter.
 */

package com.booktera.services.EntityManagers.UserGroupManager;

public interface IUserGroupManager extends java.rmi.Remote {
    public void getAllWithUsers(java.lang.Integer currentUserId, com.booktera.data.CommonModels_Models_EntityFramework.holders.ArrayOfUserGroupHolder getAllWithUsersResult, javax.xml.rpc.holders.IntegerWrapperHolder usersGroupId) throws java.rmi.RemoteException;
}
