/**
 * BookRowPLVM.java
 *
 * This file was auto-generated from WSDL
 * by the Apache Axis 1.4 Apr 22, 2006 (06:55:48 PDT) WSDL2Java emitter.
 */

package com.booktera.data.CommonPortable_Models_ProductModels;

public class BookRowPLVM  implements java.io.Serializable {
    private com.booktera.data.CommonPortable_Models.Paging paging;

    private com.booktera.data.CommonPortable_Models_ProductModels.BookRowPLVMProductGroupVM productGroup;

    private com.booktera.data.CommonPortable_Models_ProductModels.BookRowPLVMProductVM[] productsInGroup;

    public BookRowPLVM() {
    }

    public BookRowPLVM(
           com.booktera.data.CommonPortable_Models.Paging paging,
           com.booktera.data.CommonPortable_Models_ProductModels.BookRowPLVMProductGroupVM productGroup,
           com.booktera.data.CommonPortable_Models_ProductModels.BookRowPLVMProductVM[] productsInGroup) {
           this.paging = paging;
           this.productGroup = productGroup;
           this.productsInGroup = productsInGroup;
    }


    /**
     * Gets the paging value for this BookRowPLVM.
     * 
     * @return paging
     */
    public com.booktera.data.CommonPortable_Models.Paging getPaging() {
        return paging;
    }


    /**
     * Sets the paging value for this BookRowPLVM.
     * 
     * @param paging
     */
    public void setPaging(com.booktera.data.CommonPortable_Models.Paging paging) {
        this.paging = paging;
    }


    /**
     * Gets the productGroup value for this BookRowPLVM.
     * 
     * @return productGroup
     */
    public com.booktera.data.CommonPortable_Models_ProductModels.BookRowPLVMProductGroupVM getProductGroup() {
        return productGroup;
    }


    /**
     * Sets the productGroup value for this BookRowPLVM.
     * 
     * @param productGroup
     */
    public void setProductGroup(com.booktera.data.CommonPortable_Models_ProductModels.BookRowPLVMProductGroupVM productGroup) {
        this.productGroup = productGroup;
    }


    /**
     * Gets the productsInGroup value for this BookRowPLVM.
     * 
     * @return productsInGroup
     */
    public com.booktera.data.CommonPortable_Models_ProductModels.BookRowPLVMProductVM[] getProductsInGroup() {
        return productsInGroup;
    }


    /**
     * Sets the productsInGroup value for this BookRowPLVM.
     * 
     * @param productsInGroup
     */
    public void setProductsInGroup(com.booktera.data.CommonPortable_Models_ProductModels.BookRowPLVMProductVM[] productsInGroup) {
        this.productsInGroup = productsInGroup;
    }

    private java.lang.Object __equalsCalc = null;
    public synchronized boolean equals(java.lang.Object obj) {
        if (!(obj instanceof BookRowPLVM)) return false;
        BookRowPLVM other = (BookRowPLVM) obj;
        if (obj == null) return false;
        if (this == obj) return true;
        if (__equalsCalc != null) {
            return (__equalsCalc == obj);
        }
        __equalsCalc = obj;
        boolean _equals;
        _equals = true && 
            ((this.paging==null && other.getPaging()==null) || 
             (this.paging!=null &&
              this.paging.equals(other.getPaging()))) &&
            ((this.productGroup==null && other.getProductGroup()==null) || 
             (this.productGroup!=null &&
              this.productGroup.equals(other.getProductGroup()))) &&
            ((this.productsInGroup==null && other.getProductsInGroup()==null) || 
             (this.productsInGroup!=null &&
              java.util.Arrays.equals(this.productsInGroup, other.getProductsInGroup())));
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
        if (getPaging() != null) {
            _hashCode += getPaging().hashCode();
        }
        if (getProductGroup() != null) {
            _hashCode += getProductGroup().hashCode();
        }
        if (getProductsInGroup() != null) {
            for (int i=0;
                 i<java.lang.reflect.Array.getLength(getProductsInGroup());
                 i++) {
                java.lang.Object obj = java.lang.reflect.Array.get(getProductsInGroup(), i);
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
        new org.apache.axis.description.TypeDesc(BookRowPLVM.class, true);

    static {
        typeDesc.setXmlType(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonPortable.Models.ProductModels", "BookRowPLVM"));
        org.apache.axis.description.ElementDesc elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("paging");
        elemField.setXmlName(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonPortable.Models.ProductModels", "Paging"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonPortable.Models", "Paging"));
        elemField.setMinOccurs(0);
        elemField.setNillable(true);
        typeDesc.addFieldDesc(elemField);
        elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("productGroup");
        elemField.setXmlName(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonPortable.Models.ProductModels", "ProductGroup"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonPortable.Models.ProductModels", "BookRowPLVM.ProductGroupVM"));
        elemField.setMinOccurs(0);
        elemField.setNillable(true);
        typeDesc.addFieldDesc(elemField);
        elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("productsInGroup");
        elemField.setXmlName(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonPortable.Models.ProductModels", "ProductsInGroup"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonPortable.Models.ProductModels", "BookRowPLVM.ProductVM"));
        elemField.setMinOccurs(0);
        elemField.setNillable(true);
        elemField.setItemQName(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonPortable.Models.ProductModels", "BookRowPLVM.ProductVM"));
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
