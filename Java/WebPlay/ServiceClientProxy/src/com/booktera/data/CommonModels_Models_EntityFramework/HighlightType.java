/**
 * HighlightType.java
 *
 * This file was auto-generated from WSDL
 * by the Apache Axis 1.4 Apr 22, 2006 (06:55:48 PDT) WSDL2Java emitter.
 */

package com.booktera.data.CommonModels_Models_EntityFramework;

public class HighlightType  implements java.io.Serializable {
    private java.lang.String description;

    private com.booktera.data.CommonModels_Models_EntityFramework.HighlightedProduct[] highlightedProductsInType;

    private java.lang.Integer ID;

    private java.lang.Integer price;

    public HighlightType() {
    }

    public HighlightType(
           java.lang.String description,
           com.booktera.data.CommonModels_Models_EntityFramework.HighlightedProduct[] highlightedProductsInType,
           java.lang.Integer ID,
           java.lang.Integer price) {
           this.description = description;
           this.highlightedProductsInType = highlightedProductsInType;
           this.ID = ID;
           this.price = price;
    }


    /**
     * Gets the description value for this HighlightType.
     * 
     * @return description
     */
    public java.lang.String getDescription() {
        return description;
    }


    /**
     * Sets the description value for this HighlightType.
     * 
     * @param description
     */
    public void setDescription(java.lang.String description) {
        this.description = description;
    }


    /**
     * Gets the highlightedProductsInType value for this HighlightType.
     * 
     * @return highlightedProductsInType
     */
    public com.booktera.data.CommonModels_Models_EntityFramework.HighlightedProduct[] getHighlightedProductsInType() {
        return highlightedProductsInType;
    }


    /**
     * Sets the highlightedProductsInType value for this HighlightType.
     * 
     * @param highlightedProductsInType
     */
    public void setHighlightedProductsInType(com.booktera.data.CommonModels_Models_EntityFramework.HighlightedProduct[] highlightedProductsInType) {
        this.highlightedProductsInType = highlightedProductsInType;
    }


    /**
     * Gets the ID value for this HighlightType.
     * 
     * @return ID
     */
    public java.lang.Integer getID() {
        return ID;
    }


    /**
     * Sets the ID value for this HighlightType.
     * 
     * @param ID
     */
    public void setID(java.lang.Integer ID) {
        this.ID = ID;
    }


    /**
     * Gets the price value for this HighlightType.
     * 
     * @return price
     */
    public java.lang.Integer getPrice() {
        return price;
    }


    /**
     * Sets the price value for this HighlightType.
     * 
     * @param price
     */
    public void setPrice(java.lang.Integer price) {
        this.price = price;
    }

    private java.lang.Object __equalsCalc = null;
    public synchronized boolean equals(java.lang.Object obj) {
        if (!(obj instanceof HighlightType)) return false;
        HighlightType other = (HighlightType) obj;
        if (obj == null) return false;
        if (this == obj) return true;
        if (__equalsCalc != null) {
            return (__equalsCalc == obj);
        }
        __equalsCalc = obj;
        boolean _equals;
        _equals = true && 
            ((this.description==null && other.getDescription()==null) || 
             (this.description!=null &&
              this.description.equals(other.getDescription()))) &&
            ((this.highlightedProductsInType==null && other.getHighlightedProductsInType()==null) || 
             (this.highlightedProductsInType!=null &&
              java.util.Arrays.equals(this.highlightedProductsInType, other.getHighlightedProductsInType()))) &&
            ((this.ID==null && other.getID()==null) || 
             (this.ID!=null &&
              this.ID.equals(other.getID()))) &&
            ((this.price==null && other.getPrice()==null) || 
             (this.price!=null &&
              this.price.equals(other.getPrice())));
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
        if (getDescription() != null) {
            _hashCode += getDescription().hashCode();
        }
        if (getHighlightedProductsInType() != null) {
            for (int i=0;
                 i<java.lang.reflect.Array.getLength(getHighlightedProductsInType());
                 i++) {
                java.lang.Object obj = java.lang.reflect.Array.get(getHighlightedProductsInType(), i);
                if (obj != null &&
                    !obj.getClass().isArray()) {
                    _hashCode += obj.hashCode();
                }
            }
        }
        if (getID() != null) {
            _hashCode += getID().hashCode();
        }
        if (getPrice() != null) {
            _hashCode += getPrice().hashCode();
        }
        __hashCodeCalc = false;
        return _hashCode;
    }

    // Type metadata
    private static org.apache.axis.description.TypeDesc typeDesc =
        new org.apache.axis.description.TypeDesc(HighlightType.class, true);

    static {
        typeDesc.setXmlType(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "HighlightType"));
        org.apache.axis.description.ElementDesc elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("description");
        elemField.setXmlName(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "Description"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "string"));
        elemField.setMinOccurs(0);
        elemField.setNillable(true);
        typeDesc.addFieldDesc(elemField);
        elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("highlightedProductsInType");
        elemField.setXmlName(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "HighlightedProductsInType"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "HighlightedProduct"));
        elemField.setMinOccurs(0);
        elemField.setNillable(true);
        elemField.setItemQName(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "HighlightedProduct"));
        typeDesc.addFieldDesc(elemField);
        elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("ID");
        elemField.setXmlName(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "ID"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "int"));
        elemField.setMinOccurs(0);
        elemField.setNillable(false);
        typeDesc.addFieldDesc(elemField);
        elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("price");
        elemField.setXmlName(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "Price"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "int"));
        elemField.setMinOccurs(0);
        elemField.setNillable(false);
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
