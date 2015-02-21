/**
 * ProductInOrder.java
 *
 * This file was auto-generated from WSDL
 * by the Apache Axis 1.4 Apr 22, 2006 (06:55:48 PDT) WSDL2Java emitter.
 */

package com.booktera.data.CommonModels_Models_EntityFramework;

public class ProductInOrder  implements java.io.Serializable {
    private java.lang.Integer howMany;

    private java.lang.Integer ID;

    private java.lang.Boolean isForExchange;

    private com.booktera.data.CommonModels_Models_EntityFramework.Product product;

    private java.lang.Integer productID;

    private java.lang.Integer unitPrice;

    private com.booktera.data.CommonModels_Models_EntityFramework.UserOrder userOrder;

    private java.lang.Integer userOrderID;

    public ProductInOrder() {
    }

    public ProductInOrder(
           java.lang.Integer howMany,
           java.lang.Integer ID,
           java.lang.Boolean isForExchange,
           com.booktera.data.CommonModels_Models_EntityFramework.Product product,
           java.lang.Integer productID,
           java.lang.Integer unitPrice,
           com.booktera.data.CommonModels_Models_EntityFramework.UserOrder userOrder,
           java.lang.Integer userOrderID) {
           this.howMany = howMany;
           this.ID = ID;
           this.isForExchange = isForExchange;
           this.product = product;
           this.productID = productID;
           this.unitPrice = unitPrice;
           this.userOrder = userOrder;
           this.userOrderID = userOrderID;
    }


    /**
     * Gets the howMany value for this ProductInOrder.
     * 
     * @return howMany
     */
    public java.lang.Integer getHowMany() {
        return howMany;
    }


    /**
     * Sets the howMany value for this ProductInOrder.
     * 
     * @param howMany
     */
    public void setHowMany(java.lang.Integer howMany) {
        this.howMany = howMany;
    }


    /**
     * Gets the ID value for this ProductInOrder.
     * 
     * @return ID
     */
    public java.lang.Integer getID() {
        return ID;
    }


    /**
     * Sets the ID value for this ProductInOrder.
     * 
     * @param ID
     */
    public void setID(java.lang.Integer ID) {
        this.ID = ID;
    }


    /**
     * Gets the isForExchange value for this ProductInOrder.
     * 
     * @return isForExchange
     */
    public java.lang.Boolean getIsForExchange() {
        return isForExchange;
    }


    /**
     * Sets the isForExchange value for this ProductInOrder.
     * 
     * @param isForExchange
     */
    public void setIsForExchange(java.lang.Boolean isForExchange) {
        this.isForExchange = isForExchange;
    }


    /**
     * Gets the product value for this ProductInOrder.
     * 
     * @return product
     */
    public com.booktera.data.CommonModels_Models_EntityFramework.Product getProduct() {
        return product;
    }


    /**
     * Sets the product value for this ProductInOrder.
     * 
     * @param product
     */
    public void setProduct(com.booktera.data.CommonModels_Models_EntityFramework.Product product) {
        this.product = product;
    }


    /**
     * Gets the productID value for this ProductInOrder.
     * 
     * @return productID
     */
    public java.lang.Integer getProductID() {
        return productID;
    }


    /**
     * Sets the productID value for this ProductInOrder.
     * 
     * @param productID
     */
    public void setProductID(java.lang.Integer productID) {
        this.productID = productID;
    }


    /**
     * Gets the unitPrice value for this ProductInOrder.
     * 
     * @return unitPrice
     */
    public java.lang.Integer getUnitPrice() {
        return unitPrice;
    }


    /**
     * Sets the unitPrice value for this ProductInOrder.
     * 
     * @param unitPrice
     */
    public void setUnitPrice(java.lang.Integer unitPrice) {
        this.unitPrice = unitPrice;
    }


    /**
     * Gets the userOrder value for this ProductInOrder.
     * 
     * @return userOrder
     */
    public com.booktera.data.CommonModels_Models_EntityFramework.UserOrder getUserOrder() {
        return userOrder;
    }


    /**
     * Sets the userOrder value for this ProductInOrder.
     * 
     * @param userOrder
     */
    public void setUserOrder(com.booktera.data.CommonModels_Models_EntityFramework.UserOrder userOrder) {
        this.userOrder = userOrder;
    }


    /**
     * Gets the userOrderID value for this ProductInOrder.
     * 
     * @return userOrderID
     */
    public java.lang.Integer getUserOrderID() {
        return userOrderID;
    }


    /**
     * Sets the userOrderID value for this ProductInOrder.
     * 
     * @param userOrderID
     */
    public void setUserOrderID(java.lang.Integer userOrderID) {
        this.userOrderID = userOrderID;
    }

    private java.lang.Object __equalsCalc = null;
    public synchronized boolean equals(java.lang.Object obj) {
        if (!(obj instanceof ProductInOrder)) return false;
        ProductInOrder other = (ProductInOrder) obj;
        if (obj == null) return false;
        if (this == obj) return true;
        if (__equalsCalc != null) {
            return (__equalsCalc == obj);
        }
        __equalsCalc = obj;
        boolean _equals;
        _equals = true && 
            ((this.howMany==null && other.getHowMany()==null) || 
             (this.howMany!=null &&
              this.howMany.equals(other.getHowMany()))) &&
            ((this.ID==null && other.getID()==null) || 
             (this.ID!=null &&
              this.ID.equals(other.getID()))) &&
            ((this.isForExchange==null && other.getIsForExchange()==null) || 
             (this.isForExchange!=null &&
              this.isForExchange.equals(other.getIsForExchange()))) &&
            ((this.product==null && other.getProduct()==null) || 
             (this.product!=null &&
              this.product.equals(other.getProduct()))) &&
            ((this.productID==null && other.getProductID()==null) || 
             (this.productID!=null &&
              this.productID.equals(other.getProductID()))) &&
            ((this.unitPrice==null && other.getUnitPrice()==null) || 
             (this.unitPrice!=null &&
              this.unitPrice.equals(other.getUnitPrice()))) &&
            ((this.userOrder==null && other.getUserOrder()==null) || 
             (this.userOrder!=null &&
              this.userOrder.equals(other.getUserOrder()))) &&
            ((this.userOrderID==null && other.getUserOrderID()==null) || 
             (this.userOrderID!=null &&
              this.userOrderID.equals(other.getUserOrderID())));
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
        if (getHowMany() != null) {
            _hashCode += getHowMany().hashCode();
        }
        if (getID() != null) {
            _hashCode += getID().hashCode();
        }
        if (getIsForExchange() != null) {
            _hashCode += getIsForExchange().hashCode();
        }
        if (getProduct() != null) {
            _hashCode += getProduct().hashCode();
        }
        if (getProductID() != null) {
            _hashCode += getProductID().hashCode();
        }
        if (getUnitPrice() != null) {
            _hashCode += getUnitPrice().hashCode();
        }
        if (getUserOrder() != null) {
            _hashCode += getUserOrder().hashCode();
        }
        if (getUserOrderID() != null) {
            _hashCode += getUserOrderID().hashCode();
        }
        __hashCodeCalc = false;
        return _hashCode;
    }

    // Type metadata
    private static org.apache.axis.description.TypeDesc typeDesc =
        new org.apache.axis.description.TypeDesc(ProductInOrder.class, true);

    static {
        typeDesc.setXmlType(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "ProductInOrder"));
        org.apache.axis.description.ElementDesc elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("howMany");
        elemField.setXmlName(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "HowMany"));
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
        elemField.setFieldName("isForExchange");
        elemField.setXmlName(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "IsForExchange"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "boolean"));
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
        elemField.setFieldName("unitPrice");
        elemField.setXmlName(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "UnitPrice"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "int"));
        elemField.setMinOccurs(0);
        elemField.setNillable(false);
        typeDesc.addFieldDesc(elemField);
        elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("userOrder");
        elemField.setXmlName(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "UserOrder"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "UserOrder"));
        elemField.setMinOccurs(0);
        elemField.setNillable(true);
        typeDesc.addFieldDesc(elemField);
        elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("userOrderID");
        elemField.setXmlName(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "UserOrderID"));
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
