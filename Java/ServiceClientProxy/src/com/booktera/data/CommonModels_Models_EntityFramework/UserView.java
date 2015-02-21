/**
 * UserView.java
 *
 * This file was auto-generated from WSDL
 * by the Apache Axis 1.4 Apr 22, 2006 (06:55:48 PDT) WSDL2Java emitter.
 */

package com.booktera.data.CommonModels_Models_EntityFramework;

public class UserView  implements java.io.Serializable {
    private java.lang.Integer howMany;

    private java.lang.Integer ID;

    private java.util.Calendar lastDate;

    private com.booktera.data.CommonModels_Models_EntityFramework.Product product;

    private com.booktera.data.CommonModels_Models_EntityFramework.ProductGroup productGroup;

    private java.lang.Integer productGroupID;

    private java.lang.Integer productID;

    private java.lang.Integer userID;

    private com.booktera.data.CommonModels_Models_EntityFramework.UserProfile userProfile;

    public UserView() {
    }

    public UserView(
           java.lang.Integer howMany,
           java.lang.Integer ID,
           java.util.Calendar lastDate,
           com.booktera.data.CommonModels_Models_EntityFramework.Product product,
           com.booktera.data.CommonModels_Models_EntityFramework.ProductGroup productGroup,
           java.lang.Integer productGroupID,
           java.lang.Integer productID,
           java.lang.Integer userID,
           com.booktera.data.CommonModels_Models_EntityFramework.UserProfile userProfile) {
           this.howMany = howMany;
           this.ID = ID;
           this.lastDate = lastDate;
           this.product = product;
           this.productGroup = productGroup;
           this.productGroupID = productGroupID;
           this.productID = productID;
           this.userID = userID;
           this.userProfile = userProfile;
    }


    /**
     * Gets the howMany value for this UserView.
     * 
     * @return howMany
     */
    public java.lang.Integer getHowMany() {
        return howMany;
    }


    /**
     * Sets the howMany value for this UserView.
     * 
     * @param howMany
     */
    public void setHowMany(java.lang.Integer howMany) {
        this.howMany = howMany;
    }


    /**
     * Gets the ID value for this UserView.
     * 
     * @return ID
     */
    public java.lang.Integer getID() {
        return ID;
    }


    /**
     * Sets the ID value for this UserView.
     * 
     * @param ID
     */
    public void setID(java.lang.Integer ID) {
        this.ID = ID;
    }


    /**
     * Gets the lastDate value for this UserView.
     * 
     * @return lastDate
     */
    public java.util.Calendar getLastDate() {
        return lastDate;
    }


    /**
     * Sets the lastDate value for this UserView.
     * 
     * @param lastDate
     */
    public void setLastDate(java.util.Calendar lastDate) {
        this.lastDate = lastDate;
    }


    /**
     * Gets the product value for this UserView.
     * 
     * @return product
     */
    public com.booktera.data.CommonModels_Models_EntityFramework.Product getProduct() {
        return product;
    }


    /**
     * Sets the product value for this UserView.
     * 
     * @param product
     */
    public void setProduct(com.booktera.data.CommonModels_Models_EntityFramework.Product product) {
        this.product = product;
    }


    /**
     * Gets the productGroup value for this UserView.
     * 
     * @return productGroup
     */
    public com.booktera.data.CommonModels_Models_EntityFramework.ProductGroup getProductGroup() {
        return productGroup;
    }


    /**
     * Sets the productGroup value for this UserView.
     * 
     * @param productGroup
     */
    public void setProductGroup(com.booktera.data.CommonModels_Models_EntityFramework.ProductGroup productGroup) {
        this.productGroup = productGroup;
    }


    /**
     * Gets the productGroupID value for this UserView.
     * 
     * @return productGroupID
     */
    public java.lang.Integer getProductGroupID() {
        return productGroupID;
    }


    /**
     * Sets the productGroupID value for this UserView.
     * 
     * @param productGroupID
     */
    public void setProductGroupID(java.lang.Integer productGroupID) {
        this.productGroupID = productGroupID;
    }


    /**
     * Gets the productID value for this UserView.
     * 
     * @return productID
     */
    public java.lang.Integer getProductID() {
        return productID;
    }


    /**
     * Sets the productID value for this UserView.
     * 
     * @param productID
     */
    public void setProductID(java.lang.Integer productID) {
        this.productID = productID;
    }


    /**
     * Gets the userID value for this UserView.
     * 
     * @return userID
     */
    public java.lang.Integer getUserID() {
        return userID;
    }


    /**
     * Sets the userID value for this UserView.
     * 
     * @param userID
     */
    public void setUserID(java.lang.Integer userID) {
        this.userID = userID;
    }


    /**
     * Gets the userProfile value for this UserView.
     * 
     * @return userProfile
     */
    public com.booktera.data.CommonModels_Models_EntityFramework.UserProfile getUserProfile() {
        return userProfile;
    }


    /**
     * Sets the userProfile value for this UserView.
     * 
     * @param userProfile
     */
    public void setUserProfile(com.booktera.data.CommonModels_Models_EntityFramework.UserProfile userProfile) {
        this.userProfile = userProfile;
    }

    private java.lang.Object __equalsCalc = null;
    public synchronized boolean equals(java.lang.Object obj) {
        if (!(obj instanceof UserView)) return false;
        UserView other = (UserView) obj;
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
            ((this.lastDate==null && other.getLastDate()==null) || 
             (this.lastDate!=null &&
              this.lastDate.equals(other.getLastDate()))) &&
            ((this.product==null && other.getProduct()==null) || 
             (this.product!=null &&
              this.product.equals(other.getProduct()))) &&
            ((this.productGroup==null && other.getProductGroup()==null) || 
             (this.productGroup!=null &&
              this.productGroup.equals(other.getProductGroup()))) &&
            ((this.productGroupID==null && other.getProductGroupID()==null) || 
             (this.productGroupID!=null &&
              this.productGroupID.equals(other.getProductGroupID()))) &&
            ((this.productID==null && other.getProductID()==null) || 
             (this.productID!=null &&
              this.productID.equals(other.getProductID()))) &&
            ((this.userID==null && other.getUserID()==null) || 
             (this.userID!=null &&
              this.userID.equals(other.getUserID()))) &&
            ((this.userProfile==null && other.getUserProfile()==null) || 
             (this.userProfile!=null &&
              this.userProfile.equals(other.getUserProfile())));
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
        if (getLastDate() != null) {
            _hashCode += getLastDate().hashCode();
        }
        if (getProduct() != null) {
            _hashCode += getProduct().hashCode();
        }
        if (getProductGroup() != null) {
            _hashCode += getProductGroup().hashCode();
        }
        if (getProductGroupID() != null) {
            _hashCode += getProductGroupID().hashCode();
        }
        if (getProductID() != null) {
            _hashCode += getProductID().hashCode();
        }
        if (getUserID() != null) {
            _hashCode += getUserID().hashCode();
        }
        if (getUserProfile() != null) {
            _hashCode += getUserProfile().hashCode();
        }
        __hashCodeCalc = false;
        return _hashCode;
    }

    // Type metadata
    private static org.apache.axis.description.TypeDesc typeDesc =
        new org.apache.axis.description.TypeDesc(UserView.class, true);

    static {
        typeDesc.setXmlType(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "UserView"));
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
        elemField.setFieldName("lastDate");
        elemField.setXmlName(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "LastDate"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "dateTime"));
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
        elemField.setFieldName("productGroup");
        elemField.setXmlName(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "ProductGroup"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "ProductGroup"));
        elemField.setMinOccurs(0);
        elemField.setNillable(true);
        typeDesc.addFieldDesc(elemField);
        elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("productGroupID");
        elemField.setXmlName(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "ProductGroupID"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "int"));
        elemField.setMinOccurs(0);
        elemField.setNillable(true);
        typeDesc.addFieldDesc(elemField);
        elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("productID");
        elemField.setXmlName(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "ProductID"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "int"));
        elemField.setMinOccurs(0);
        elemField.setNillable(true);
        typeDesc.addFieldDesc(elemField);
        elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("userID");
        elemField.setXmlName(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "UserID"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "int"));
        elemField.setMinOccurs(0);
        elemField.setNillable(true);
        typeDesc.addFieldDesc(elemField);
        elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("userProfile");
        elemField.setXmlName(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "UserProfile"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "UserProfile"));
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
