/**
 * CommentWithProductGroupVM.java
 *
 * This file was auto-generated from WSDL
 * by the Apache Axis 1.4 Apr 22, 2006 (06:55:48 PDT) WSDL2Java emitter.
 */

package com.booktera.data.CommonModels_Models;

public class CommentWithProductGroupVM  implements java.io.Serializable {
    private com.booktera.data.CommonModels_Models.CommentWithProductGroupVMCommentVM comment;

    private com.booktera.data.CommonPortable_Models_ProductModels.InBookBlockPVM product;

    public CommentWithProductGroupVM() {
    }

    public CommentWithProductGroupVM(
           com.booktera.data.CommonModels_Models.CommentWithProductGroupVMCommentVM comment,
           com.booktera.data.CommonPortable_Models_ProductModels.InBookBlockPVM product) {
           this.comment = comment;
           this.product = product;
    }


    /**
     * Gets the comment value for this CommentWithProductGroupVM.
     * 
     * @return comment
     */
    public com.booktera.data.CommonModels_Models.CommentWithProductGroupVMCommentVM getComment() {
        return comment;
    }


    /**
     * Sets the comment value for this CommentWithProductGroupVM.
     * 
     * @param comment
     */
    public void setComment(com.booktera.data.CommonModels_Models.CommentWithProductGroupVMCommentVM comment) {
        this.comment = comment;
    }


    /**
     * Gets the product value for this CommentWithProductGroupVM.
     * 
     * @return product
     */
    public com.booktera.data.CommonPortable_Models_ProductModels.InBookBlockPVM getProduct() {
        return product;
    }


    /**
     * Sets the product value for this CommentWithProductGroupVM.
     * 
     * @param product
     */
    public void setProduct(com.booktera.data.CommonPortable_Models_ProductModels.InBookBlockPVM product) {
        this.product = product;
    }

    private java.lang.Object __equalsCalc = null;
    public synchronized boolean equals(java.lang.Object obj) {
        if (!(obj instanceof CommentWithProductGroupVM)) return false;
        CommentWithProductGroupVM other = (CommentWithProductGroupVM) obj;
        if (obj == null) return false;
        if (this == obj) return true;
        if (__equalsCalc != null) {
            return (__equalsCalc == obj);
        }
        __equalsCalc = obj;
        boolean _equals;
        _equals = true && 
            ((this.comment==null && other.getComment()==null) || 
             (this.comment!=null &&
              this.comment.equals(other.getComment()))) &&
            ((this.product==null && other.getProduct()==null) || 
             (this.product!=null &&
              this.product.equals(other.getProduct())));
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
        if (getComment() != null) {
            _hashCode += getComment().hashCode();
        }
        if (getProduct() != null) {
            _hashCode += getProduct().hashCode();
        }
        __hashCodeCalc = false;
        return _hashCode;
    }

    // Type metadata
    private static org.apache.axis.description.TypeDesc typeDesc =
        new org.apache.axis.description.TypeDesc(CommentWithProductGroupVM.class, true);

    static {
        typeDesc.setXmlType(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models", "CommentWithProductGroupVM"));
        org.apache.axis.description.ElementDesc elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("comment");
        elemField.setXmlName(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models", "Comment"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models", "CommentWithProductGroupVM.CommentVM"));
        elemField.setMinOccurs(0);
        elemField.setNillable(true);
        typeDesc.addFieldDesc(elemField);
        elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("product");
        elemField.setXmlName(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models", "Product"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonPortable.Models.ProductModels", "InBookBlockPVM"));
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
