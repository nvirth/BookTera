/**
 * InBookBlockPVMProductVM.java
 *
 * This file was auto-generated from WSDL
 * by the Apache Axis 1.4 Apr 22, 2006 (06:55:48 PDT) WSDL2Java emitter.
 */

package com.booktera.data.CommonPortable_Models_ProductModels;

public class InBookBlockPVMProductVM  implements java.io.Serializable {
    private java.lang.String description;

    private java.lang.Integer howMany;

    private java.lang.Integer ID;

    private java.lang.String imageUrl;

    private java.lang.Boolean isDownloadable;

    private java.lang.String priceString;

    private java.lang.Integer productInOrderId;

    private java.lang.String userFriendlyUrl;

    private java.lang.String userName;

    public InBookBlockPVMProductVM() {
    }

    public InBookBlockPVMProductVM(
           java.lang.String description,
           java.lang.Integer howMany,
           java.lang.Integer ID,
           java.lang.String imageUrl,
           java.lang.Boolean isDownloadable,
           java.lang.String priceString,
           java.lang.Integer productInOrderId,
           java.lang.String userFriendlyUrl,
           java.lang.String userName) {
           this.description = description;
           this.howMany = howMany;
           this.ID = ID;
           this.imageUrl = imageUrl;
           this.isDownloadable = isDownloadable;
           this.priceString = priceString;
           this.productInOrderId = productInOrderId;
           this.userFriendlyUrl = userFriendlyUrl;
           this.userName = userName;
    }


    /**
     * Gets the description value for this InBookBlockPVMProductVM.
     * 
     * @return description
     */
    public java.lang.String getDescription() {
        return description;
    }


    /**
     * Sets the description value for this InBookBlockPVMProductVM.
     * 
     * @param description
     */
    public void setDescription(java.lang.String description) {
        this.description = description;
    }


    /**
     * Gets the howMany value for this InBookBlockPVMProductVM.
     * 
     * @return howMany
     */
    public java.lang.Integer getHowMany() {
        return howMany;
    }


    /**
     * Sets the howMany value for this InBookBlockPVMProductVM.
     * 
     * @param howMany
     */
    public void setHowMany(java.lang.Integer howMany) {
        this.howMany = howMany;
    }


    /**
     * Gets the ID value for this InBookBlockPVMProductVM.
     * 
     * @return ID
     */
    public java.lang.Integer getID() {
        return ID;
    }


    /**
     * Sets the ID value for this InBookBlockPVMProductVM.
     * 
     * @param ID
     */
    public void setID(java.lang.Integer ID) {
        this.ID = ID;
    }


    /**
     * Gets the imageUrl value for this InBookBlockPVMProductVM.
     * 
     * @return imageUrl
     */
    public java.lang.String getImageUrl() {
        return imageUrl;
    }


    /**
     * Sets the imageUrl value for this InBookBlockPVMProductVM.
     * 
     * @param imageUrl
     */
    public void setImageUrl(java.lang.String imageUrl) {
        this.imageUrl = imageUrl;
    }


    /**
     * Gets the isDownloadable value for this InBookBlockPVMProductVM.
     * 
     * @return isDownloadable
     */
    public java.lang.Boolean getIsDownloadable() {
        return isDownloadable;
    }


    /**
     * Sets the isDownloadable value for this InBookBlockPVMProductVM.
     * 
     * @param isDownloadable
     */
    public void setIsDownloadable(java.lang.Boolean isDownloadable) {
        this.isDownloadable = isDownloadable;
    }


    /**
     * Gets the priceString value for this InBookBlockPVMProductVM.
     * 
     * @return priceString
     */
    public java.lang.String getPriceString() {
        return priceString;
    }


    /**
     * Sets the priceString value for this InBookBlockPVMProductVM.
     * 
     * @param priceString
     */
    public void setPriceString(java.lang.String priceString) {
        this.priceString = priceString;
    }


    /**
     * Gets the productInOrderId value for this InBookBlockPVMProductVM.
     * 
     * @return productInOrderId
     */
    public java.lang.Integer getProductInOrderId() {
        return productInOrderId;
    }


    /**
     * Sets the productInOrderId value for this InBookBlockPVMProductVM.
     * 
     * @param productInOrderId
     */
    public void setProductInOrderId(java.lang.Integer productInOrderId) {
        this.productInOrderId = productInOrderId;
    }


    /**
     * Gets the userFriendlyUrl value for this InBookBlockPVMProductVM.
     * 
     * @return userFriendlyUrl
     */
    public java.lang.String getUserFriendlyUrl() {
        return userFriendlyUrl;
    }


    /**
     * Sets the userFriendlyUrl value for this InBookBlockPVMProductVM.
     * 
     * @param userFriendlyUrl
     */
    public void setUserFriendlyUrl(java.lang.String userFriendlyUrl) {
        this.userFriendlyUrl = userFriendlyUrl;
    }


    /**
     * Gets the userName value for this InBookBlockPVMProductVM.
     * 
     * @return userName
     */
    public java.lang.String getUserName() {
        return userName;
    }


    /**
     * Sets the userName value for this InBookBlockPVMProductVM.
     * 
     * @param userName
     */
    public void setUserName(java.lang.String userName) {
        this.userName = userName;
    }

    private java.lang.Object __equalsCalc = null;
    public synchronized boolean equals(java.lang.Object obj) {
        if (!(obj instanceof InBookBlockPVMProductVM)) return false;
        InBookBlockPVMProductVM other = (InBookBlockPVMProductVM) obj;
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
            ((this.howMany==null && other.getHowMany()==null) || 
             (this.howMany!=null &&
              this.howMany.equals(other.getHowMany()))) &&
            ((this.ID==null && other.getID()==null) || 
             (this.ID!=null &&
              this.ID.equals(other.getID()))) &&
            ((this.imageUrl==null && other.getImageUrl()==null) || 
             (this.imageUrl!=null &&
              this.imageUrl.equals(other.getImageUrl()))) &&
            ((this.isDownloadable==null && other.getIsDownloadable()==null) || 
             (this.isDownloadable!=null &&
              this.isDownloadable.equals(other.getIsDownloadable()))) &&
            ((this.priceString==null && other.getPriceString()==null) || 
             (this.priceString!=null &&
              this.priceString.equals(other.getPriceString()))) &&
            ((this.productInOrderId==null && other.getProductInOrderId()==null) || 
             (this.productInOrderId!=null &&
              this.productInOrderId.equals(other.getProductInOrderId()))) &&
            ((this.userFriendlyUrl==null && other.getUserFriendlyUrl()==null) || 
             (this.userFriendlyUrl!=null &&
              this.userFriendlyUrl.equals(other.getUserFriendlyUrl()))) &&
            ((this.userName==null && other.getUserName()==null) || 
             (this.userName!=null &&
              this.userName.equals(other.getUserName())));
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
        if (getHowMany() != null) {
            _hashCode += getHowMany().hashCode();
        }
        if (getID() != null) {
            _hashCode += getID().hashCode();
        }
        if (getImageUrl() != null) {
            _hashCode += getImageUrl().hashCode();
        }
        if (getIsDownloadable() != null) {
            _hashCode += getIsDownloadable().hashCode();
        }
        if (getPriceString() != null) {
            _hashCode += getPriceString().hashCode();
        }
        if (getProductInOrderId() != null) {
            _hashCode += getProductInOrderId().hashCode();
        }
        if (getUserFriendlyUrl() != null) {
            _hashCode += getUserFriendlyUrl().hashCode();
        }
        if (getUserName() != null) {
            _hashCode += getUserName().hashCode();
        }
        __hashCodeCalc = false;
        return _hashCode;
    }

    // Type metadata
    private static org.apache.axis.description.TypeDesc typeDesc =
        new org.apache.axis.description.TypeDesc(InBookBlockPVMProductVM.class, true);

    static {
        typeDesc.setXmlType(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonPortable.Models.ProductModels", "InBookBlockPVM.ProductVM"));
        org.apache.axis.description.ElementDesc elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("description");
        elemField.setXmlName(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonPortable.Models.ProductModels", "Description"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "string"));
        elemField.setMinOccurs(0);
        elemField.setNillable(true);
        typeDesc.addFieldDesc(elemField);
        elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("howMany");
        elemField.setXmlName(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonPortable.Models.ProductModels", "HowMany"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "int"));
        elemField.setMinOccurs(0);
        elemField.setNillable(false);
        typeDesc.addFieldDesc(elemField);
        elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("ID");
        elemField.setXmlName(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonPortable.Models.ProductModels", "ID"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "int"));
        elemField.setMinOccurs(0);
        elemField.setNillable(false);
        typeDesc.addFieldDesc(elemField);
        elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("imageUrl");
        elemField.setXmlName(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonPortable.Models.ProductModels", "ImageUrl"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "string"));
        elemField.setMinOccurs(0);
        elemField.setNillable(true);
        typeDesc.addFieldDesc(elemField);
        elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("isDownloadable");
        elemField.setXmlName(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonPortable.Models.ProductModels", "IsDownloadable"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "boolean"));
        elemField.setMinOccurs(0);
        elemField.setNillable(false);
        typeDesc.addFieldDesc(elemField);
        elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("priceString");
        elemField.setXmlName(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonPortable.Models.ProductModels", "PriceString"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "string"));
        elemField.setMinOccurs(0);
        elemField.setNillable(true);
        typeDesc.addFieldDesc(elemField);
        elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("productInOrderId");
        elemField.setXmlName(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonPortable.Models.ProductModels", "ProductInOrderId"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "int"));
        elemField.setMinOccurs(0);
        elemField.setNillable(false);
        typeDesc.addFieldDesc(elemField);
        elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("userFriendlyUrl");
        elemField.setXmlName(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonPortable.Models.ProductModels", "UserFriendlyUrl"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "string"));
        elemField.setMinOccurs(0);
        elemField.setNillable(true);
        typeDesc.addFieldDesc(elemField);
        elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("userName");
        elemField.setXmlName(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonPortable.Models.ProductModels", "UserName"));
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
