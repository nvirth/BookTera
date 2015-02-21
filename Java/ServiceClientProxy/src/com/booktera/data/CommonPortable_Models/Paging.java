/**
 * Paging.java
 *
 * This file was auto-generated from WSDL
 * by the Apache Axis 1.4 Apr 22, 2006 (06:55:48 PDT) WSDL2Java emitter.
 */

package com.booktera.data.CommonPortable_Models;

public class Paging  implements java.io.Serializable {
    private java.lang.Integer actualPageNumber;

    private java.lang.Integer numberOfPages;

    private java.lang.Integer numberOfProducts;

    private java.lang.Integer productsPerPage;

    public Paging() {
    }

    public Paging(
           java.lang.Integer actualPageNumber,
           java.lang.Integer numberOfPages,
           java.lang.Integer numberOfProducts,
           java.lang.Integer productsPerPage) {
           this.actualPageNumber = actualPageNumber;
           this.numberOfPages = numberOfPages;
           this.numberOfProducts = numberOfProducts;
           this.productsPerPage = productsPerPage;
    }


    /**
     * Gets the actualPageNumber value for this Paging.
     * 
     * @return actualPageNumber
     */
    public java.lang.Integer getActualPageNumber() {
        return actualPageNumber;
    }


    /**
     * Sets the actualPageNumber value for this Paging.
     * 
     * @param actualPageNumber
     */
    public void setActualPageNumber(java.lang.Integer actualPageNumber) {
        this.actualPageNumber = actualPageNumber;
    }


    /**
     * Gets the numberOfPages value for this Paging.
     * 
     * @return numberOfPages
     */
    public java.lang.Integer getNumberOfPages() {
        return numberOfPages;
    }


    /**
     * Sets the numberOfPages value for this Paging.
     * 
     * @param numberOfPages
     */
    public void setNumberOfPages(java.lang.Integer numberOfPages) {
        this.numberOfPages = numberOfPages;
    }


    /**
     * Gets the numberOfProducts value for this Paging.
     * 
     * @return numberOfProducts
     */
    public java.lang.Integer getNumberOfProducts() {
        return numberOfProducts;
    }


    /**
     * Sets the numberOfProducts value for this Paging.
     * 
     * @param numberOfProducts
     */
    public void setNumberOfProducts(java.lang.Integer numberOfProducts) {
        this.numberOfProducts = numberOfProducts;
    }


    /**
     * Gets the productsPerPage value for this Paging.
     * 
     * @return productsPerPage
     */
    public java.lang.Integer getProductsPerPage() {
        return productsPerPage;
    }


    /**
     * Sets the productsPerPage value for this Paging.
     * 
     * @param productsPerPage
     */
    public void setProductsPerPage(java.lang.Integer productsPerPage) {
        this.productsPerPage = productsPerPage;
    }

    private java.lang.Object __equalsCalc = null;
    public synchronized boolean equals(java.lang.Object obj) {
        if (!(obj instanceof Paging)) return false;
        Paging other = (Paging) obj;
        if (obj == null) return false;
        if (this == obj) return true;
        if (__equalsCalc != null) {
            return (__equalsCalc == obj);
        }
        __equalsCalc = obj;
        boolean _equals;
        _equals = true && 
            ((this.actualPageNumber==null && other.getActualPageNumber()==null) || 
             (this.actualPageNumber!=null &&
              this.actualPageNumber.equals(other.getActualPageNumber()))) &&
            ((this.numberOfPages==null && other.getNumberOfPages()==null) || 
             (this.numberOfPages!=null &&
              this.numberOfPages.equals(other.getNumberOfPages()))) &&
            ((this.numberOfProducts==null && other.getNumberOfProducts()==null) || 
             (this.numberOfProducts!=null &&
              this.numberOfProducts.equals(other.getNumberOfProducts()))) &&
            ((this.productsPerPage==null && other.getProductsPerPage()==null) || 
             (this.productsPerPage!=null &&
              this.productsPerPage.equals(other.getProductsPerPage())));
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
        if (getActualPageNumber() != null) {
            _hashCode += getActualPageNumber().hashCode();
        }
        if (getNumberOfPages() != null) {
            _hashCode += getNumberOfPages().hashCode();
        }
        if (getNumberOfProducts() != null) {
            _hashCode += getNumberOfProducts().hashCode();
        }
        if (getProductsPerPage() != null) {
            _hashCode += getProductsPerPage().hashCode();
        }
        __hashCodeCalc = false;
        return _hashCode;
    }

    // Type metadata
    private static org.apache.axis.description.TypeDesc typeDesc =
        new org.apache.axis.description.TypeDesc(Paging.class, true);

    static {
        typeDesc.setXmlType(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonPortable.Models", "Paging"));
        org.apache.axis.description.ElementDesc elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("actualPageNumber");
        elemField.setXmlName(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonPortable.Models", "ActualPageNumber"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "int"));
        elemField.setMinOccurs(0);
        elemField.setNillable(false);
        typeDesc.addFieldDesc(elemField);
        elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("numberOfPages");
        elemField.setXmlName(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonPortable.Models", "NumberOfPages"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "int"));
        elemField.setMinOccurs(0);
        elemField.setNillable(false);
        typeDesc.addFieldDesc(elemField);
        elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("numberOfProducts");
        elemField.setXmlName(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonPortable.Models", "NumberOfProducts"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "int"));
        elemField.setMinOccurs(0);
        elemField.setNillable(false);
        typeDesc.addFieldDesc(elemField);
        elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("productsPerPage");
        elemField.setXmlName(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonPortable.Models", "ProductsPerPage"));
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
