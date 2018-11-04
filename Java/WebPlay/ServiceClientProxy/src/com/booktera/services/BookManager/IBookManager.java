/**
 * IBookManager.java
 *
 * This file was auto-generated from WSDL
 * by the Apache Axis 1.4 Apr 22, 2006 (06:55:48 PDT) WSDL2Java emitter.
 */

package com.booktera.services.BookManager;

public interface IBookManager extends java.rmi.Remote {
    public com.booktera.data.CommonModels_Models_EntityFramework.Product uploadProduct(com.booktera.data.CommonModels_Models_ProductModels.CreatePVM model) throws java.rmi.RemoteException;
    public void uploadProductNr(com.booktera.data.CommonModels_Models_ProductModels.CreatePVM model) throws java.rmi.RemoteException;
    public com.booktera.data.CommonModels_Models_ProductModels.CreatePVMProductGroupVMWithValidation createProductGroupWithValidation(com.booktera.data.CommonModels_Models_ProductModels.CreatePVMProductGroupVM nonValidatedProductGroup) throws java.rmi.RemoteException;
}
