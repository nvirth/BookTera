/**
 * RatingWithProductGroupVM.java
 *
 * This file was auto-generated from WSDL
 * by the Apache Axis 1.4 Apr 22, 2006 (06:55:48 PDT) WSDL2Java emitter.
 */

package com.booktera.data.CommonModels_Models;

public class RatingWithProductGroupVM  implements java.io.Serializable {
    private com.booktera.data.CommonPortable_Models_ProductModels.InBookBlockPVM product;

    private com.booktera.data.CommonModels_Models.RatingWithProductGroupVMRatingVM rating;

    public RatingWithProductGroupVM() {
    }

    public RatingWithProductGroupVM(
           com.booktera.data.CommonPortable_Models_ProductModels.InBookBlockPVM product,
           com.booktera.data.CommonModels_Models.RatingWithProductGroupVMRatingVM rating) {
           this.product = product;
           this.rating = rating;
    }


    /**
     * Gets the product value for this RatingWithProductGroupVM.
     * 
     * @return product
     */
    public com.booktera.data.CommonPortable_Models_ProductModels.InBookBlockPVM getProduct() {
        return product;
    }


    /**
     * Sets the product value for this RatingWithProductGroupVM.
     * 
     * @param product
     */
    public void setProduct(com.booktera.data.CommonPortable_Models_ProductModels.InBookBlockPVM product) {
        this.product = product;
    }


    /**
     * Gets the rating value for this RatingWithProductGroupVM.
     * 
     * @return rating
     */
    public com.booktera.data.CommonModels_Models.RatingWithProductGroupVMRatingVM getRating() {
        return rating;
    }


    /**
     * Sets the rating value for this RatingWithProductGroupVM.
     * 
     * @param rating
     */
    public void setRating(com.booktera.data.CommonModels_Models.RatingWithProductGroupVMRatingVM rating) {
        this.rating = rating;
    }

    private java.lang.Object __equalsCalc = null;
    public synchronized boolean equals(java.lang.Object obj) {
        if (!(obj instanceof RatingWithProductGroupVM)) return false;
        RatingWithProductGroupVM other = (RatingWithProductGroupVM) obj;
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
            ((this.rating==null && other.getRating()==null) || 
             (this.rating!=null &&
              this.rating.equals(other.getRating())));
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
        if (getRating() != null) {
            _hashCode += getRating().hashCode();
        }
        __hashCodeCalc = false;
        return _hashCode;
    }

    // Type metadata
    private static org.apache.axis.description.TypeDesc typeDesc =
        new org.apache.axis.description.TypeDesc(RatingWithProductGroupVM.class, true);

    static {
        typeDesc.setXmlType(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models", "RatingWithProductGroupVM"));
        org.apache.axis.description.ElementDesc elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("product");
        elemField.setXmlName(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models", "Product"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonPortable.Models.ProductModels", "InBookBlockPVM"));
        elemField.setMinOccurs(0);
        elemField.setNillable(true);
        typeDesc.addFieldDesc(elemField);
        elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("rating");
        elemField.setXmlName(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models", "Rating"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models", "RatingWithProductGroupVM.RatingVM"));
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
