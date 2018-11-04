/**
 * BookBlockPLVM.java
 *
 * This file was auto-generated from WSDL
 * by the Apache Axis 1.4 Apr 22, 2006 (06:55:48 PDT) WSDL2Java emitter.
 */

package com.booktera.data.CommonPortable_Models_ProductModels;

public class BookBlockPLVM  implements java.io.Serializable {
    private com.booktera.data.CommonPortable_Enums.BookBlockType bookBlockType;

    private com.booktera.data.CommonPortable_Models.Paging paging;

    private com.booktera.data.CommonPortable_Models_ProductModels.InBookBlockPVM[] products;

    public BookBlockPLVM() {
    }

    public BookBlockPLVM(
           com.booktera.data.CommonPortable_Enums.BookBlockType bookBlockType,
           com.booktera.data.CommonPortable_Models.Paging paging,
           com.booktera.data.CommonPortable_Models_ProductModels.InBookBlockPVM[] products) {
           this.bookBlockType = bookBlockType;
           this.paging = paging;
           this.products = products;
    }


    /**
     * Gets the bookBlockType value for this BookBlockPLVM.
     * 
     * @return bookBlockType
     */
    public com.booktera.data.CommonPortable_Enums.BookBlockType getBookBlockType() {
        return bookBlockType;
    }


    /**
     * Sets the bookBlockType value for this BookBlockPLVM.
     * 
     * @param bookBlockType
     */
    public void setBookBlockType(com.booktera.data.CommonPortable_Enums.BookBlockType bookBlockType) {
        this.bookBlockType = bookBlockType;
    }


    /**
     * Gets the paging value for this BookBlockPLVM.
     * 
     * @return paging
     */
    public com.booktera.data.CommonPortable_Models.Paging getPaging() {
        return paging;
    }


    /**
     * Sets the paging value for this BookBlockPLVM.
     * 
     * @param paging
     */
    public void setPaging(com.booktera.data.CommonPortable_Models.Paging paging) {
        this.paging = paging;
    }


    /**
     * Gets the products value for this BookBlockPLVM.
     * 
     * @return products
     */
    public com.booktera.data.CommonPortable_Models_ProductModels.InBookBlockPVM[] getProducts() {
        return products;
    }


    /**
     * Sets the products value for this BookBlockPLVM.
     * 
     * @param products
     */
    public void setProducts(com.booktera.data.CommonPortable_Models_ProductModels.InBookBlockPVM[] products) {
        this.products = products;
    }

    private java.lang.Object __equalsCalc = null;
    public synchronized boolean equals(java.lang.Object obj) {
        if (!(obj instanceof BookBlockPLVM)) return false;
        BookBlockPLVM other = (BookBlockPLVM) obj;
        if (obj == null) return false;
        if (this == obj) return true;
        if (__equalsCalc != null) {
            return (__equalsCalc == obj);
        }
        __equalsCalc = obj;
        boolean _equals;
        _equals = true && 
            ((this.bookBlockType==null && other.getBookBlockType()==null) || 
             (this.bookBlockType!=null &&
              this.bookBlockType.equals(other.getBookBlockType()))) &&
            ((this.paging==null && other.getPaging()==null) || 
             (this.paging!=null &&
              this.paging.equals(other.getPaging()))) &&
            ((this.products==null && other.getProducts()==null) || 
             (this.products!=null &&
              java.util.Arrays.equals(this.products, other.getProducts())));
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
        if (getBookBlockType() != null) {
            _hashCode += getBookBlockType().hashCode();
        }
        if (getPaging() != null) {
            _hashCode += getPaging().hashCode();
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
        __hashCodeCalc = false;
        return _hashCode;
    }

    // Type metadata
    private static org.apache.axis.description.TypeDesc typeDesc =
        new org.apache.axis.description.TypeDesc(BookBlockPLVM.class, true);

    static {
        typeDesc.setXmlType(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonPortable.Models.ProductModels", "BookBlockPLVM"));
        org.apache.axis.description.ElementDesc elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("bookBlockType");
        elemField.setXmlName(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonPortable.Models.ProductModels", "BookBlockType"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonPortable.Enums", "BookBlockType"));
        elemField.setMinOccurs(0);
        elemField.setNillable(false);
        typeDesc.addFieldDesc(elemField);
        elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("paging");
        elemField.setXmlName(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonPortable.Models.ProductModels", "Paging"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonPortable.Models", "Paging"));
        elemField.setMinOccurs(0);
        elemField.setNillable(true);
        typeDesc.addFieldDesc(elemField);
        elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("products");
        elemField.setXmlName(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonPortable.Models.ProductModels", "Products"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonPortable.Models.ProductModels", "InBookBlockPVM"));
        elemField.setMinOccurs(0);
        elemField.setNillable(true);
        elemField.setItemQName(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonPortable.Models.ProductModels", "InBookBlockPVM"));
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
