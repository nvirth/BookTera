/**
 * IImageManager.java
 *
 * This file was auto-generated from WSDL
 * by the Apache Axis 1.4 Apr 22, 2006 (06:55:48 PDT) WSDL2Java emitter.
 */

package com.booktera.services.EntityManagers.ImageManager;

public interface IImageManager extends java.rmi.Remote {
    public java.lang.String getUsersAvatar() throws java.rmi.RemoteException;
    public java.lang.String takeImageToItsFolder(byte[] stream) throws java.rmi.RemoteException;
}
