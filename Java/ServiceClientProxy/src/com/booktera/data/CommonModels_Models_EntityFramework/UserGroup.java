/**
 * UserGroup.java
 *
 * This file was auto-generated from WSDL
 * by the Apache Axis 1.4 Apr 22, 2006 (06:55:48 PDT) WSDL2Java emitter.
 */

package com.booktera.data.CommonModels_Models_EntityFramework;

public class UserGroup  implements java.io.Serializable {
    private org.apache.axis.types.UnsignedByte buyFeePercent;

    private java.lang.String groupName;

    private java.lang.Integer ID;

    private org.apache.axis.types.UnsignedByte monthsToKeepBooks;

    private java.lang.Integer price;

    private org.apache.axis.types.UnsignedByte sellFeePercent;

    private com.booktera.data.CommonModels_Models_EntityFramework.UserProfile[] userProfiles;

    public UserGroup() {
    }

    public UserGroup(
           org.apache.axis.types.UnsignedByte buyFeePercent,
           java.lang.String groupName,
           java.lang.Integer ID,
           org.apache.axis.types.UnsignedByte monthsToKeepBooks,
           java.lang.Integer price,
           org.apache.axis.types.UnsignedByte sellFeePercent,
           com.booktera.data.CommonModels_Models_EntityFramework.UserProfile[] userProfiles) {
           this.buyFeePercent = buyFeePercent;
           this.groupName = groupName;
           this.ID = ID;
           this.monthsToKeepBooks = monthsToKeepBooks;
           this.price = price;
           this.sellFeePercent = sellFeePercent;
           this.userProfiles = userProfiles;
    }


    /**
     * Gets the buyFeePercent value for this UserGroup.
     * 
     * @return buyFeePercent
     */
    public org.apache.axis.types.UnsignedByte getBuyFeePercent() {
        return buyFeePercent;
    }


    /**
     * Sets the buyFeePercent value for this UserGroup.
     * 
     * @param buyFeePercent
     */
    public void setBuyFeePercent(org.apache.axis.types.UnsignedByte buyFeePercent) {
        this.buyFeePercent = buyFeePercent;
    }


    /**
     * Gets the groupName value for this UserGroup.
     * 
     * @return groupName
     */
    public java.lang.String getGroupName() {
        return groupName;
    }


    /**
     * Sets the groupName value for this UserGroup.
     * 
     * @param groupName
     */
    public void setGroupName(java.lang.String groupName) {
        this.groupName = groupName;
    }


    /**
     * Gets the ID value for this UserGroup.
     * 
     * @return ID
     */
    public java.lang.Integer getID() {
        return ID;
    }


    /**
     * Sets the ID value for this UserGroup.
     * 
     * @param ID
     */
    public void setID(java.lang.Integer ID) {
        this.ID = ID;
    }


    /**
     * Gets the monthsToKeepBooks value for this UserGroup.
     * 
     * @return monthsToKeepBooks
     */
    public org.apache.axis.types.UnsignedByte getMonthsToKeepBooks() {
        return monthsToKeepBooks;
    }


    /**
     * Sets the monthsToKeepBooks value for this UserGroup.
     * 
     * @param monthsToKeepBooks
     */
    public void setMonthsToKeepBooks(org.apache.axis.types.UnsignedByte monthsToKeepBooks) {
        this.monthsToKeepBooks = monthsToKeepBooks;
    }


    /**
     * Gets the price value for this UserGroup.
     * 
     * @return price
     */
    public java.lang.Integer getPrice() {
        return price;
    }


    /**
     * Sets the price value for this UserGroup.
     * 
     * @param price
     */
    public void setPrice(java.lang.Integer price) {
        this.price = price;
    }


    /**
     * Gets the sellFeePercent value for this UserGroup.
     * 
     * @return sellFeePercent
     */
    public org.apache.axis.types.UnsignedByte getSellFeePercent() {
        return sellFeePercent;
    }


    /**
     * Sets the sellFeePercent value for this UserGroup.
     * 
     * @param sellFeePercent
     */
    public void setSellFeePercent(org.apache.axis.types.UnsignedByte sellFeePercent) {
        this.sellFeePercent = sellFeePercent;
    }


    /**
     * Gets the userProfiles value for this UserGroup.
     * 
     * @return userProfiles
     */
    public com.booktera.data.CommonModels_Models_EntityFramework.UserProfile[] getUserProfiles() {
        return userProfiles;
    }


    /**
     * Sets the userProfiles value for this UserGroup.
     * 
     * @param userProfiles
     */
    public void setUserProfiles(com.booktera.data.CommonModels_Models_EntityFramework.UserProfile[] userProfiles) {
        this.userProfiles = userProfiles;
    }

    private java.lang.Object __equalsCalc = null;
    public synchronized boolean equals(java.lang.Object obj) {
        if (!(obj instanceof UserGroup)) return false;
        UserGroup other = (UserGroup) obj;
        if (obj == null) return false;
        if (this == obj) return true;
        if (__equalsCalc != null) {
            return (__equalsCalc == obj);
        }
        __equalsCalc = obj;
        boolean _equals;
        _equals = true && 
            ((this.buyFeePercent==null && other.getBuyFeePercent()==null) || 
             (this.buyFeePercent!=null &&
              this.buyFeePercent.equals(other.getBuyFeePercent()))) &&
            ((this.groupName==null && other.getGroupName()==null) || 
             (this.groupName!=null &&
              this.groupName.equals(other.getGroupName()))) &&
            ((this.ID==null && other.getID()==null) || 
             (this.ID!=null &&
              this.ID.equals(other.getID()))) &&
            ((this.monthsToKeepBooks==null && other.getMonthsToKeepBooks()==null) || 
             (this.monthsToKeepBooks!=null &&
              this.monthsToKeepBooks.equals(other.getMonthsToKeepBooks()))) &&
            ((this.price==null && other.getPrice()==null) || 
             (this.price!=null &&
              this.price.equals(other.getPrice()))) &&
            ((this.sellFeePercent==null && other.getSellFeePercent()==null) || 
             (this.sellFeePercent!=null &&
              this.sellFeePercent.equals(other.getSellFeePercent()))) &&
            ((this.userProfiles==null && other.getUserProfiles()==null) || 
             (this.userProfiles!=null &&
              java.util.Arrays.equals(this.userProfiles, other.getUserProfiles())));
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
        if (getBuyFeePercent() != null) {
            _hashCode += getBuyFeePercent().hashCode();
        }
        if (getGroupName() != null) {
            _hashCode += getGroupName().hashCode();
        }
        if (getID() != null) {
            _hashCode += getID().hashCode();
        }
        if (getMonthsToKeepBooks() != null) {
            _hashCode += getMonthsToKeepBooks().hashCode();
        }
        if (getPrice() != null) {
            _hashCode += getPrice().hashCode();
        }
        if (getSellFeePercent() != null) {
            _hashCode += getSellFeePercent().hashCode();
        }
        if (getUserProfiles() != null) {
            for (int i=0;
                 i<java.lang.reflect.Array.getLength(getUserProfiles());
                 i++) {
                java.lang.Object obj = java.lang.reflect.Array.get(getUserProfiles(), i);
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
        new org.apache.axis.description.TypeDesc(UserGroup.class, true);

    static {
        typeDesc.setXmlType(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "UserGroup"));
        org.apache.axis.description.ElementDesc elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("buyFeePercent");
        elemField.setXmlName(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "BuyFeePercent"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "unsignedByte"));
        elemField.setMinOccurs(0);
        elemField.setNillable(false);
        typeDesc.addFieldDesc(elemField);
        elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("groupName");
        elemField.setXmlName(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "GroupName"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "string"));
        elemField.setMinOccurs(0);
        elemField.setNillable(true);
        typeDesc.addFieldDesc(elemField);
        elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("ID");
        elemField.setXmlName(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "ID"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "int"));
        elemField.setMinOccurs(0);
        elemField.setNillable(false);
        typeDesc.addFieldDesc(elemField);
        elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("monthsToKeepBooks");
        elemField.setXmlName(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "MonthsToKeepBooks"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "unsignedByte"));
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
        elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("sellFeePercent");
        elemField.setXmlName(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "SellFeePercent"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "unsignedByte"));
        elemField.setMinOccurs(0);
        elemField.setNillable(false);
        typeDesc.addFieldDesc(elemField);
        elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("userProfiles");
        elemField.setXmlName(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "UserProfiles"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "UserProfile"));
        elemField.setMinOccurs(0);
        elemField.setNillable(true);
        elemField.setItemQName(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "UserProfile"));
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
