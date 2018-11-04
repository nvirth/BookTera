/**
 * InCategoryPLVMCategoryVM.java
 *
 * This file was auto-generated from WSDL
 * by the Apache Axis 1.4 Apr 22, 2006 (06:55:48 PDT) WSDL2Java emitter.
 */

package com.booktera.data.CommonPortable_Models_ProductModels;

public class InCategoryPLVMCategoryVM  implements java.io.Serializable {
    private java.lang.String displayName;

    private java.lang.String friendlyUrl;

    private java.lang.String fullPath;

    public InCategoryPLVMCategoryVM() {
    }

    public InCategoryPLVMCategoryVM(
           java.lang.String displayName,
           java.lang.String friendlyUrl,
           java.lang.String fullPath) {
           this.displayName = displayName;
           this.friendlyUrl = friendlyUrl;
           this.fullPath = fullPath;
    }


    /**
     * Gets the displayName value for this InCategoryPLVMCategoryVM.
     * 
     * @return displayName
     */
    public java.lang.String getDisplayName() {
        return displayName;
    }


    /**
     * Sets the displayName value for this InCategoryPLVMCategoryVM.
     * 
     * @param displayName
     */
    public void setDisplayName(java.lang.String displayName) {
        this.displayName = displayName;
    }


    /**
     * Gets the friendlyUrl value for this InCategoryPLVMCategoryVM.
     * 
     * @return friendlyUrl
     */
    public java.lang.String getFriendlyUrl() {
        return friendlyUrl;
    }


    /**
     * Sets the friendlyUrl value for this InCategoryPLVMCategoryVM.
     * 
     * @param friendlyUrl
     */
    public void setFriendlyUrl(java.lang.String friendlyUrl) {
        this.friendlyUrl = friendlyUrl;
    }


    /**
     * Gets the fullPath value for this InCategoryPLVMCategoryVM.
     * 
     * @return fullPath
     */
    public java.lang.String getFullPath() {
        return fullPath;
    }


    /**
     * Sets the fullPath value for this InCategoryPLVMCategoryVM.
     * 
     * @param fullPath
     */
    public void setFullPath(java.lang.String fullPath) {
        this.fullPath = fullPath;
    }

    private java.lang.Object __equalsCalc = null;
    public synchronized boolean equals(java.lang.Object obj) {
        if (!(obj instanceof InCategoryPLVMCategoryVM)) return false;
        InCategoryPLVMCategoryVM other = (InCategoryPLVMCategoryVM) obj;
        if (obj == null) return false;
        if (this == obj) return true;
        if (__equalsCalc != null) {
            return (__equalsCalc == obj);
        }
        __equalsCalc = obj;
        boolean _equals;
        _equals = true && 
            ((this.displayName==null && other.getDisplayName()==null) || 
             (this.displayName!=null &&
              this.displayName.equals(other.getDisplayName()))) &&
            ((this.friendlyUrl==null && other.getFriendlyUrl()==null) || 
             (this.friendlyUrl!=null &&
              this.friendlyUrl.equals(other.getFriendlyUrl()))) &&
            ((this.fullPath==null && other.getFullPath()==null) || 
             (this.fullPath!=null &&
              this.fullPath.equals(other.getFullPath())));
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
        if (getDisplayName() != null) {
            _hashCode += getDisplayName().hashCode();
        }
        if (getFriendlyUrl() != null) {
            _hashCode += getFriendlyUrl().hashCode();
        }
        if (getFullPath() != null) {
            _hashCode += getFullPath().hashCode();
        }
        __hashCodeCalc = false;
        return _hashCode;
    }

    // Type metadata
    private static org.apache.axis.description.TypeDesc typeDesc =
        new org.apache.axis.description.TypeDesc(InCategoryPLVMCategoryVM.class, true);

    static {
        typeDesc.setXmlType(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonPortable.Models.ProductModels", "InCategoryPLVM.CategoryVM"));
        org.apache.axis.description.ElementDesc elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("displayName");
        elemField.setXmlName(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonPortable.Models.ProductModels", "DisplayName"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "string"));
        elemField.setMinOccurs(0);
        elemField.setNillable(true);
        typeDesc.addFieldDesc(elemField);
        elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("friendlyUrl");
        elemField.setXmlName(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonPortable.Models.ProductModels", "FriendlyUrl"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "string"));
        elemField.setMinOccurs(0);
        elemField.setNillable(true);
        typeDesc.addFieldDesc(elemField);
        elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("fullPath");
        elemField.setXmlName(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonPortable.Models.ProductModels", "FullPath"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "string"));
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
