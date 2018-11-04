/**
 * InCategoryPLVM.java
 *
 * This file was auto-generated from WSDL
 * by the Apache Axis 1.4 Apr 22, 2006 (06:55:48 PDT) WSDL2Java emitter.
 */

package com.booktera.data.CommonPortable_Models_ProductModels;

public class InCategoryPLVM  extends com.booktera.data.CommonPortable_Models_ProductModels.BookBlockPLVM  implements java.io.Serializable {
    private com.booktera.data.CommonPortable_Models_ProductModels.InCategoryPLVMCategoryVM category;

    public InCategoryPLVM() {
    }

    public InCategoryPLVM(
           com.booktera.data.CommonPortable_Enums.BookBlockType bookBlockType,
           com.booktera.data.CommonPortable_Models.Paging paging,
           com.booktera.data.CommonPortable_Models_ProductModels.InBookBlockPVM[] products,
           com.booktera.data.CommonPortable_Models_ProductModels.InCategoryPLVMCategoryVM category) {
        super(
            bookBlockType,
            paging,
            products);
        this.category = category;
    }


    /**
     * Gets the category value for this InCategoryPLVM.
     * 
     * @return category
     */
    public com.booktera.data.CommonPortable_Models_ProductModels.InCategoryPLVMCategoryVM getCategory() {
        return category;
    }


    /**
     * Sets the category value for this InCategoryPLVM.
     * 
     * @param category
     */
    public void setCategory(com.booktera.data.CommonPortable_Models_ProductModels.InCategoryPLVMCategoryVM category) {
        this.category = category;
    }

    private java.lang.Object __equalsCalc = null;
    public synchronized boolean equals(java.lang.Object obj) {
        if (!(obj instanceof InCategoryPLVM)) return false;
        InCategoryPLVM other = (InCategoryPLVM) obj;
        if (obj == null) return false;
        if (this == obj) return true;
        if (__equalsCalc != null) {
            return (__equalsCalc == obj);
        }
        __equalsCalc = obj;
        boolean _equals;
        _equals = super.equals(obj) && 
            ((this.category==null && other.getCategory()==null) || 
             (this.category!=null &&
              this.category.equals(other.getCategory())));
        __equalsCalc = null;
        return _equals;
    }

    private boolean __hashCodeCalc = false;
    public synchronized int hashCode() {
        if (__hashCodeCalc) {
            return 0;
        }
        __hashCodeCalc = true;
        int _hashCode = super.hashCode();
        if (getCategory() != null) {
            _hashCode += getCategory().hashCode();
        }
        __hashCodeCalc = false;
        return _hashCode;
    }

    // Type metadata
    private static org.apache.axis.description.TypeDesc typeDesc =
        new org.apache.axis.description.TypeDesc(InCategoryPLVM.class, true);

    static {
        typeDesc.setXmlType(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonPortable.Models.ProductModels", "InCategoryPLVM"));
        org.apache.axis.description.ElementDesc elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("category");
        elemField.setXmlName(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonPortable.Models.ProductModels", "Category"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonPortable.Models.ProductModels", "InCategoryPLVM.CategoryVM"));
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
