/**
 * UserOrderPLVM.java
 *
 * This file was auto-generated from WSDL
 * by the Apache Axis 1.4 Apr 22, 2006 (06:55:48 PDT) WSDL2Java emitter.
 */

package com.booktera.data.CommonModels_Models;

public class UserOrderPLVM  implements java.io.Serializable {
    private com.booktera.data.CommonPortable_Models_ProductModels.InBookBlockPVM[] exchangeProducts;

    private com.booktera.data.CommonPortable_Models_ProductModels.InBookBlockPVM[] products;

    private com.booktera.data.CommonPortable_Enums.TransactionType transactionType;

    private com.booktera.data.CommonModels_Models.UserOrderPLVMUserOrderVM userOrder;

    public UserOrderPLVM() {
    }

    public UserOrderPLVM(
           com.booktera.data.CommonPortable_Models_ProductModels.InBookBlockPVM[] exchangeProducts,
           com.booktera.data.CommonPortable_Models_ProductModels.InBookBlockPVM[] products,
           com.booktera.data.CommonPortable_Enums.TransactionType transactionType,
           com.booktera.data.CommonModels_Models.UserOrderPLVMUserOrderVM userOrder) {
           this.exchangeProducts = exchangeProducts;
           this.products = products;
           this.transactionType = transactionType;
           this.userOrder = userOrder;
    }


    /**
     * Gets the exchangeProducts value for this UserOrderPLVM.
     * 
     * @return exchangeProducts
     */
    public com.booktera.data.CommonPortable_Models_ProductModels.InBookBlockPVM[] getExchangeProducts() {
        return exchangeProducts;
    }


    /**
     * Sets the exchangeProducts value for this UserOrderPLVM.
     * 
     * @param exchangeProducts
     */
    public void setExchangeProducts(com.booktera.data.CommonPortable_Models_ProductModels.InBookBlockPVM[] exchangeProducts) {
        this.exchangeProducts = exchangeProducts;
    }


    /**
     * Gets the products value for this UserOrderPLVM.
     * 
     * @return products
     */
    public com.booktera.data.CommonPortable_Models_ProductModels.InBookBlockPVM[] getProducts() {
        return products;
    }


    /**
     * Sets the products value for this UserOrderPLVM.
     * 
     * @param products
     */
    public void setProducts(com.booktera.data.CommonPortable_Models_ProductModels.InBookBlockPVM[] products) {
        this.products = products;
    }


    /**
     * Gets the transactionType value for this UserOrderPLVM.
     * 
     * @return transactionType
     */
    public com.booktera.data.CommonPortable_Enums.TransactionType getTransactionType() {
        return transactionType;
    }


    /**
     * Sets the transactionType value for this UserOrderPLVM.
     * 
     * @param transactionType
     */
    public void setTransactionType(com.booktera.data.CommonPortable_Enums.TransactionType transactionType) {
        this.transactionType = transactionType;
    }


    /**
     * Gets the userOrder value for this UserOrderPLVM.
     * 
     * @return userOrder
     */
    public com.booktera.data.CommonModels_Models.UserOrderPLVMUserOrderVM getUserOrder() {
        return userOrder;
    }


    /**
     * Sets the userOrder value for this UserOrderPLVM.
     * 
     * @param userOrder
     */
    public void setUserOrder(com.booktera.data.CommonModels_Models.UserOrderPLVMUserOrderVM userOrder) {
        this.userOrder = userOrder;
    }

    private java.lang.Object __equalsCalc = null;
    public synchronized boolean equals(java.lang.Object obj) {
        if (!(obj instanceof UserOrderPLVM)) return false;
        UserOrderPLVM other = (UserOrderPLVM) obj;
        if (obj == null) return false;
        if (this == obj) return true;
        if (__equalsCalc != null) {
            return (__equalsCalc == obj);
        }
        __equalsCalc = obj;
        boolean _equals;
        _equals = true && 
            ((this.exchangeProducts==null && other.getExchangeProducts()==null) || 
             (this.exchangeProducts!=null &&
              java.util.Arrays.equals(this.exchangeProducts, other.getExchangeProducts()))) &&
            ((this.products==null && other.getProducts()==null) || 
             (this.products!=null &&
              java.util.Arrays.equals(this.products, other.getProducts()))) &&
            ((this.transactionType==null && other.getTransactionType()==null) || 
             (this.transactionType!=null &&
              this.transactionType.equals(other.getTransactionType()))) &&
            ((this.userOrder==null && other.getUserOrder()==null) || 
             (this.userOrder!=null &&
              this.userOrder.equals(other.getUserOrder())));
        __equalsCalc = null;
        return _equals;
    }

    private boolean __hashCodeCalc = false;
    public synchronized int hashCode() {
        if (__hashCodeCalc) {
            return 0;
        }
        __hashCodeCalc = true;
        int _hashCode = 1;
        if (getExchangeProducts() != null) {
            for (int i=0;
                 i<java.lang.reflect.Array.getLength(getExchangeProducts());
                 i++) {
                java.lang.Object obj = java.lang.reflect.Array.get(getExchangeProducts(), i);
                if (obj != null &&
                    !obj.getClass().isArray()) {
                    _hashCode += obj.hashCode();
                }
            }
        }
        if (getProducts() != null) {
            for (int i=0;
                 i<java.lang.reflect.Array.getLength(getProducts());
                 i++) {
                java.lang.Object obj = java.lang.reflect.Array.get(getProducts(), i);
                if (obj != null &&
                    !obj.getClass().isArray()) {
                    _hashCode += obj.hashCode();
                }
            }
        }
        if (getTransactionType() != null) {
            _hashCode += getTransactionType().hashCode();
        }
        if (getUserOrder() != null) {
            _hashCode += getUserOrder().hashCode();
        }
        __hashCodeCalc = false;
        return _hashCode;
    }

    // Type metadata
    private static org.apache.axis.description.TypeDesc typeDesc =
        new org.apache.axis.description.TypeDesc(UserOrderPLVM.class, true);

    static {
        typeDesc.setXmlType(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models", "UserOrderPLVM"));
        org.apache.axis.description.ElementDesc elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("exchangeProducts");
        elemField.setXmlName(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models", "ExchangeProducts"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonPortable.Models.ProductModels", "InBookBlockPVM"));
        elemField.setMinOccurs(0);
        elemField.setNillable(true);
        elemField.setItemQName(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonPortable.Models.ProductModels", "InBookBlockPVM"));
        typeDesc.addFieldDesc(elemField);
        elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("products");
        elemField.setXmlName(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models", "Products"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonPortable.Models.ProductModels", "InBookBlockPVM"));
        elemField.setMinOccurs(0);
        elemField.setNillable(true);
        elemField.setItemQName(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonPortable.Models.ProductModels", "InBookBlockPVM"));
        typeDesc.addFieldDesc(elemField);
        elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("transactionType");
        elemField.setXmlName(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models", "TransactionType"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonPortable.Enums", "TransactionType"));
        elemField.setMinOccurs(0);
        elemField.setNillable(false);
        typeDesc.addFieldDesc(elemField);
        elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("userOrder");
        elemField.setXmlName(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models", "UserOrder"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models", "UserOrderPLVM.UserOrderVM"));
        elemField.setMinOccurs(0);
        elemField.setNillable(true);
        typeDesc.addFieldDesc(elemField);
    }

    /**
     * Return type metadata object
     */
    public static org.apache.axis.description.TypeDesc getTypeDesc() {
        return typeDesc;
    }

    /**
     * Get Custom Serializer
     */
    public static org.apache.axis.encoding.Serializer getSerializer(
           java.lang.String mechType, 
           java.lang.Class _javaType,  
           javax.xml.namespace.QName _xmlType) {
        return 
          new  org.apache.axis.encoding.ser.BeanSerializer(
            _javaType, _xmlType, typeDesc);
    }

    /**
     * Get Custom Deserializer
     */
    public static org.apache.axis.encoding.Deserializer getDeserializer(
           java.lang.String mechType, 
           java.lang.Class _javaType,  
           javax.xml.namespace.QName _xmlType) {
        return 
          new  org.apache.axis.encoding.ser.BeanDeserializer(
            _javaType, _xmlType, typeDesc);
    }

}
