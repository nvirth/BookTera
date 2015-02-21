/**
 * InBookBlockPVM.java
 *
 * This file was auto-generated from WSDL
 * by the Apache Axis 1.4 Apr 22, 2006 (06:55:48 PDT) WSDL2Java emitter.
 */

package com.booktera.data.CommonPortable_Models_ProductModels;

public class InBookBlockPVM  implements java.io.Serializable {
    private com.booktera.data.CommonPortable_Models_ProductModels.InBookBlockPVMProductVM product;

    private com.booktera.data.CommonPortable_Models_ProductModels.InBookBlockPVMProductGroupVM productGroup;

    public InBookBlockPVM() {
    }

    public InBookBlockPVM(
           com.booktera.data.CommonPortable_Models_ProductModels.InBookBlockPVMProductVM product,
           com.booktera.data.CommonPortable_Models_ProductModels.InBookBlockPVMProductGroupVM productGroup) {
           this.product = product;
           this.productGroup = productGroup;
    }


    /**
     * Gets the product value for this InBookBlockPVM.
     * 
     * @return product
     */
    public com.booktera.data.CommonPortable_Models_ProductModels.InBookBlockPVMProductVM getProduct() {
        return product;
    }


    /**
     * Sets the product value for this InBookBlockPVM.
     * 
     * @param product
     */
    public void setProduct(com.booktera.data.CommonPortable_Models_ProductModels.InBookBlockPVMProductVM product) {
        this.product = product;
    }


    /**
     * Gets the productGroup value for this InBookBlockPVM.
     * 
     * @return productGroup
     */
    public com.booktera.data.CommonPortable_Models_ProductModels.InBookBlockPVMProductGroupVM getProductGroup() {
        return productGroup;
    }


    /**
     * Sets the productGroup value for this InBookBlockPVM.
     * 
     * @param productGroup
     */
    public void setProductGroup(com.booktera.data.CommonPortable_Models_ProductModels.InBookBlockPVMProductGroupVM productGroup) {
        this.productGroup = productGroup;
    }

    private java.lang.Object __equalsCalc = null;
    public synchronized boolean equals(java.lang.Object obj) {
        if (!(obj instanceof InBookBlockPVM)) return false;
        InBookBlockPVM other = (InBookBlockPVM) obj;
        if (obj == null) return false;
        if (this == obj) return true;
        if (__equalsCalc != null) {
            return (__equalsCalc == obj);
        }
        __equalsCalc = obj;
        boolean _equals;
        _equals = true && 
            ((this.product==null && other.getProduct()==null) || 
             (this.product!=null &&
              this.product.equals(other.getProduct()))) &&
            ((this.productGroup==null && other.getProductGroup()==null) || 
             (this.productGroup!=null &&
              this.productGroup.equals(other.getProductGroup())));
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
        if (getProduct() != null) {
            _hashCode += getProduct().hashCode();
        }
        if (getProductGroup() != null) {
            _hashCode += getProductGroup().hashCode();
        }
        __hashCodeCalc = false;
        return _hashCode;
    }

    // Type metadata
    private static org.apache.axis.description.TypeDesc typeDesc =
        new org.apache.axis.description.TypeDesc(InBookBlockPVM.class, true);

    static {
        typeDesc.setXmlType(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonPortable.Models.ProductModels", "InBookBlockPVM"));
        org.apache.axis.description.ElementDesc elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("product");
        elemField.setXmlName(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonPortable.Models.ProductModels", "Product"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonPortable.Models.ProductModels", "InBookBlockPVM.ProductVM"));
        elemField.setMinOccurs(0);
        elemField.setNillable(true);
        typeDesc.addFieldDesc(elemField);
        elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("productGroup");
        elemField.setXmlName(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonPortable.Models.ProductModels", "ProductGroup"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonPortable.Models.ProductModels", "InBookBlockPVM.ProductGroupVM"));
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
