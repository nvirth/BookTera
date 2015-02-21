/**
 * Publisher.java
 *
 * This file was auto-generated from WSDL
 * by the Apache Axis 1.4 Apr 22, 2006 (06:55:48 PDT) WSDL2Java emitter.
 */

package com.booktera.data.CommonModels_Models_EntityFramework;

public class Publisher  implements java.io.Serializable {
    private java.lang.String about;

    private java.lang.String displayName;

    private java.lang.String friendlyUrl;

    private java.lang.Integer ID;

    private java.lang.Boolean isCheckedByAdmin;

    private com.booktera.data.CommonModels_Models_EntityFramework.ProductGroup[] productGroups;

    private java.lang.Integer userID;

    private com.booktera.data.CommonModels_Models_EntityFramework.UserProfile userProfile;

    public Publisher() {
    }

    public Publisher(
           java.lang.String about,
           java.lang.String displayName,
           java.lang.String friendlyUrl,
           java.lang.Integer ID,
           java.lang.Boolean isCheckedByAdmin,
           com.booktera.data.CommonModels_Models_EntityFramework.ProductGroup[] productGroups,
           java.lang.Integer userID,
           com.booktera.data.CommonModels_Models_EntityFramework.UserProfile userProfile) {
           this.about = about;
           this.displayName = displayName;
           this.friendlyUrl = friendlyUrl;
           this.ID = ID;
           this.isCheckedByAdmin = isCheckedByAdmin;
           this.productGroups = productGroups;
           this.userID = userID;
           this.userProfile = userProfile;
    }


    /**
     * Gets the about value for this Publisher.
     * 
     * @return about
     */
    public java.lang.String getAbout() {
        return about;
    }


    /**
     * Sets the about value for this Publisher.
     * 
     * @param about
     */
    public void setAbout(java.lang.String about) {
        this.about = about;
    }


    /**
     * Gets the displayName value for this Publisher.
     * 
     * @return displayName
     */
    public java.lang.String getDisplayName() {
        return displayName;
    }


    /**
     * Sets the displayName value for this Publisher.
     * 
     * @param displayName
     */
    public void setDisplayName(java.lang.String displayName) {
        this.displayName = displayName;
    }


    /**
     * Gets the friendlyUrl value for this Publisher.
     * 
     * @return friendlyUrl
     */
    public java.lang.String getFriendlyUrl() {
        return friendlyUrl;
    }


    /**
     * Sets the friendlyUrl value for this Publisher.
     * 
     * @param friendlyUrl
     */
    public void setFriendlyUrl(java.lang.String friendlyUrl) {
        this.friendlyUrl = friendlyUrl;
    }


    /**
     * Gets the ID value for this Publisher.
     * 
     * @return ID
     */
    public java.lang.Integer getID() {
        return ID;
    }


    /**
     * Sets the ID value for this Publisher.
     * 
     * @param ID
     */
    public void setID(java.lang.Integer ID) {
        this.ID = ID;
    }


    /**
     * Gets the isCheckedByAdmin value for this Publisher.
     * 
     * @return isCheckedByAdmin
     */
    public java.lang.Boolean getIsCheckedByAdmin() {
        return isCheckedByAdmin;
    }


    /**
     * Sets the isCheckedByAdmin value for this Publisher.
     * 
     * @param isCheckedByAdmin
     */
    public void setIsCheckedByAdmin(java.lang.Boolean isCheckedByAdmin) {
        this.isCheckedByAdmin = isCheckedByAdmin;
    }


    /**
     * Gets the productGroups value for this Publisher.
     * 
     * @return productGroups
     */
    public com.booktera.data.CommonModels_Models_EntityFramework.ProductGroup[] getProductGroups() {
        return productGroups;
    }


    /**
     * Sets the productGroups value for this Publisher.
     * 
     * @param productGroups
     */
    public void setProductGroups(com.booktera.data.CommonModels_Models_EntityFramework.ProductGroup[] productGroups) {
        this.productGroups = productGroups;
    }


    /**
     * Gets the userID value for this Publisher.
     * 
     * @return userID
     */
    public java.lang.Integer getUserID() {
        return userID;
    }


    /**
     * Sets the userID value for this Publisher.
     * 
     * @param userID
     */
    public void setUserID(java.lang.Integer userID) {
        this.userID = userID;
    }


    /**
     * Gets the userProfile value for this Publisher.
     * 
     * @return userProfile
     */
    public com.booktera.data.CommonModels_Models_EntityFramework.UserProfile getUserProfile() {
        return userProfile;
    }


    /**
     * Sets the userProfile value for this Publisher.
     * 
     * @param userProfile
     */
    public void setUserProfile(com.booktera.data.CommonModels_Models_EntityFramework.UserProfile userProfile) {
        this.userProfile = userProfile;
    }

    private java.lang.Object __equalsCalc = null;
    public synchronized boolean equals(java.lang.Object obj) {
        if (!(obj instanceof Publisher)) return false;
        Publisher other = (Publisher) obj;
        if (obj == null) return false;
        if (this == obj) return true;
        if (__equalsCalc != null) {
            return (__equalsCalc == obj);
        }
        __equalsCalc = obj;
        boolean _equals;
        _equals = true && 
            ((this.about==null && other.getAbout()==null) || 
             (this.about!=null &&
              this.about.equals(other.getAbout()))) &&
            ((this.displayName==null && other.getDisplayName()==null) || 
             (this.displayName!=null &&
              this.displayName.equals(other.getDisplayName()))) &&
            ((this.friendlyUrl==null && other.getFriendlyUrl()==null) || 
             (this.friendlyUrl!=null &&
              this.friendlyUrl.equals(other.getFriendlyUrl()))) &&
            ((this.ID==null && other.getID()==null) || 
             (this.ID!=null &&
              this.ID.equals(other.getID()))) &&
            ((this.isCheckedByAdmin==null && other.getIsCheckedByAdmin()==null) || 
             (this.isCheckedByAdmin!=null &&
              this.isCheckedByAdmin.equals(other.getIsCheckedByAdmin()))) &&
            ((this.productGroups==null && other.getProductGroups()==null) || 
             (this.productGroups!=null &&
              java.util.Arrays.equals(this.productGroups, other.getProductGroups()))) &&
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
        if (getAbout() != null) {
            _hashCode += getAbout().hashCode();
        }
        if (getDisplayName() != null) {
            _hashCode += getDisplayName().hashCode();
        }
        if (getFriendlyUrl() != null) {
            _hashCode += getFriendlyUrl().hashCode();
        }
        if (getID() != null) {
            _hashCode += getID().hashCode();
        }
        if (getIsCheckedByAdmin() != null) {
            _hashCode += getIsCheckedByAdmin().hashCode();
        }
        if (getProductGroups() != null) {
            for (int i=0;
                 i<java.lang.reflect.Array.getLength(getProductGroups());
                 i++) {
                java.lang.Object obj = java.lang.reflect.Array.get(getProductGroups(), i);
                if (obj != null &&
                    !obj.getClass().isArray()) {
                    _hashCode += obj.hashCode();
                }
            }
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
        new org.apache.axis.description.TypeDesc(Publisher.class, true);

    static {
        typeDesc.setXmlType(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "Publisher"));
        org.apache.axis.description.ElementDesc elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("about");
        elemField.setXmlName(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "About"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "string"));
        elemField.setMinOccurs(0);
        elemField.setNillable(true);
        typeDesc.addFieldDesc(elemField);
        elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("displayName");
        elemField.setXmlName(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "DisplayName"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "string"));
        elemField.setMinOccurs(0);
        elemField.setNillable(true);
        typeDesc.addFieldDesc(elemField);
        elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("friendlyUrl");
        elemField.setXmlName(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "FriendlyUrl"));
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
        elemField.setFieldName("isCheckedByAdmin");
        elemField.setXmlName(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "IsCheckedByAdmin"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "boolean"));
        elemField.setMinOccurs(0);
        elemField.setNillable(false);
        typeDesc.addFieldDesc(elemField);
        elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("productGroups");
        elemField.setXmlName(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "ProductGroups"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "ProductGroup"));
        elemField.setMinOccurs(0);
        elemField.setNillable(true);
        elemField.setItemQName(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "ProductGroup"));
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
