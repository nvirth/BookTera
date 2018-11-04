/**
 * HighlightedProduct.java
 *
 * This file was auto-generated from WSDL
 * by the Apache Axis 1.4 Apr 22, 2006 (06:55:48 PDT) WSDL2Java emitter.
 */

package com.booktera.data.CommonModels_Models_EntityFramework;

public class HighlightedProduct  implements java.io.Serializable {
    private java.util.Calendar fromDate;

    private com.booktera.data.CommonModels_Models_EntityFramework.HighlightType highlightType;

    private java.lang.Integer highlightTypeID;

    private java.lang.Integer ID;

    private com.booktera.data.CommonModels_Models_EntityFramework.Product product;

    private java.lang.Integer productID;

    private java.util.Calendar toDate;

    public HighlightedProduct() {
    }

    public HighlightedProduct(
           java.util.Calendar fromDate,
           com.booktera.data.CommonModels_Models_EntityFramework.HighlightType highlightType,
           java.lang.Integer highlightTypeID,
           java.lang.Integer ID,
           com.booktera.data.CommonModels_Models_EntityFramework.Product product,
           java.lang.Integer productID,
           java.util.Calendar toDate) {
           this.fromDate = fromDate;
           this.highlightType = highlightType;
           this.highlightTypeID = highlightTypeID;
           this.ID = ID;
           this.product = product;
           this.productID = productID;
           this.toDate = toDate;
    }


    /**
     * Gets the fromDate value for this HighlightedProduct.
     * 
     * @return fromDate
     */
    public java.util.Calendar getFromDate() {
        return fromDate;
    }


    /**
     * Sets the fromDate value for this HighlightedProduct.
     * 
     * @param fromDate
     */
    public void setFromDate(java.util.Calendar fromDate) {
        this.fromDate = fromDate;
    }


    /**
     * Gets the highlightType value for this HighlightedProduct.
     * 
     * @return highlightType
     */
    public com.booktera.data.CommonModels_Models_EntityFramework.HighlightType getHighlightType() {
        return highlightType;
    }


    /**
     * Sets the highlightType value for this HighlightedProduct.
     * 
     * @param highlightType
     */
    public void setHighlightType(com.booktera.data.CommonModels_Models_EntityFramework.HighlightType highlightType) {
        this.highlightType = highlightType;
    }


    /**
     * Gets the highlightTypeID value for this HighlightedProduct.
     * 
     * @return highlightTypeID
     */
    public java.lang.Integer getHighlightTypeID() {
        return highlightTypeID;
    }


    /**
     * Sets the highlightTypeID value for this HighlightedProduct.
     * 
     * @param highlightTypeID
     */
    public void setHighlightTypeID(java.lang.Integer highlightTypeID) {
        this.highlightTypeID = highlightTypeID;
    }


    /**
     * Gets the ID value for this HighlightedProduct.
     * 
     * @return ID
     */
    public java.lang.Integer getID() {
        return ID;
    }


    /**
     * Sets the ID value for this HighlightedProduct.
     * 
     * @param ID
     */
    public void setID(java.lang.Integer ID) {
        this.ID = ID;
    }


    /**
     * Gets the product value for this HighlightedProduct.
     * 
     * @return product
     */
    public com.booktera.data.CommonModels_Models_EntityFramework.Product getProduct() {
        return product;
    }


    /**
     * Sets the product value for this HighlightedProduct.
     * 
     * @param product
     */
    public void setProduct(com.booktera.data.CommonModels_Models_EntityFramework.Product product) {
        this.product = product;
    }


    /**
     * Gets the productID value for this HighlightedProduct.
     * 
     * @return productID
     */
    public java.lang.Integer getProductID() {
        return productID;
    }


    /**
     * Sets the productID value for this HighlightedProduct.
     * 
     * @param productID
     */
    public void setProductID(java.lang.Integer productID) {
        this.productID = productID;
    }


    /**
     * Gets the toDate value for this HighlightedProduct.
     * 
     * @return toDate
     */
    public java.util.Calendar getToDate() {
        return toDate;
    }


    /**
     * Sets the toDate value for this HighlightedProduct.
     * 
     * @param toDate
     */
    public void setToDate(java.util.Calendar toDate) {
        this.toDate = toDate;
    }

    private java.lang.Object __equalsCalc = null;
    public synchronized boolean equals(java.lang.Object obj) {
        if (!(obj instanceof HighlightedProduct)) return false;
        HighlightedProduct other = (HighlightedProduct) obj;
        if (obj == null) return false;
        if (this == obj) return true;
        if (__equalsCalc != null) {
            return (__equalsCalc == obj);
        }
        __equalsCalc = obj;
        boolean _equals;
        _equals = true && 
            ((this.fromDate==null && other.getFromDate()==null) || 
             (this.fromDate!=null &&
              this.fromDate.equals(other.getFromDate()))) &&
            ((this.highlightType==null && other.getHighlightType()==null) || 
             (this.highlightType!=null &&
              this.highlightType.equals(other.getHighlightType()))) &&
            ((this.highlightTypeID==null && other.getHighlightTypeID()==null) || 
             (this.highlightTypeID!=null &&
              this.highlightTypeID.equals(other.getHighlightTypeID()))) &&
            ((this.ID==null && other.getID()==null) || 
             (this.ID!=null &&
              this.ID.equals(other.getID()))) &&
            ((this.product==null && other.getProduct()==null) || 
             (this.product!=null &&
              this.product.equals(other.getProduct()))) &&
            ((this.productID==null && other.getProductID()==null) || 
             (this.productID!=null &&
              this.productID.equals(other.getProductID()))) &&
            ((this.toDate==null && other.getToDate()==null) || 
             (this.toDate!=null &&
              this.toDate.equals(other.getToDate())));
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
        if (getFromDate() != null) {
            _hashCode += getFromDate().hashCode();
        }
        if (getHighlightType() != null) {
            _hashCode += getHighlightType().hashCode();
        }
        if (getHighlightTypeID() != null) {
            _hashCode += getHighlightTypeID().hashCode();
        }
        if (getID() != null) {
            _hashCode += getID().hashCode();
        }
        if (getProduct() != null) {
            _hashCode += getProduct().hashCode();
        }
        if (getProductID() != null) {
            _hashCode += getProductID().hashCode();
        }
        if (getToDate() != null) {
            _hashCode += getToDate().hashCode();
        }
        __hashCodeCalc = false;
        return _hashCode;
    }

    // Type metadata
    private static org.apache.axis.description.TypeDesc typeDesc =
        new org.apache.axis.description.TypeDesc(HighlightedProduct.class, true);

    static {
        typeDesc.setXmlType(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "HighlightedProduct"));
        org.apache.axis.description.ElementDesc elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("fromDate");
        elemField.setXmlName(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "FromDate"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "dateTime"));
        elemField.setMinOccurs(0);
        elemField.setNillable(false);
        typeDesc.addFieldDesc(elemField);
        elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("highlightType");
        elemField.setXmlName(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "HighlightType"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "HighlightType"));
        elemField.setMinOccurs(0);
        elemField.setNillable(true);
        typeDesc.addFieldDesc(elemField);
        elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("highlightTypeID");
        elemField.setXmlName(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "HighlightTypeID"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "int"));
        elemField.setMinOccurs(0);
        elemField.setNillable(false);
        typeDesc.addFieldDesc(elemField);
        elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("ID");
        elemField.setXmlName(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "ID"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "int"));
        elemField.setMinOccurs(0);
        elemField.setNillable(false);
        typeDesc.addFieldDesc(elemField);
        elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("product");
        elemField.setXmlName(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "Product"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "Product"));
        elemField.setMinOccurs(0);
        elemField.setNillable(true);
        typeDesc.addFieldDesc(elemField);
        elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("productID");
        elemField.setXmlName(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "ProductID"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "int"));
        elemField.setMinOccurs(0);
        elemField.setNillable(false);
        typeDesc.addFieldDesc(elemField);
        elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("toDate");
        elemField.setXmlName(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "ToDate"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "dateTime"));
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
