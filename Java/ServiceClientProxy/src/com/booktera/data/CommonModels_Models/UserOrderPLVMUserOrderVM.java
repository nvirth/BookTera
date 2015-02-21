/**
 * UserOrderPLVMUserOrderVM.java
 *
 * This file was auto-generated from WSDL
 * by the Apache Axis 1.4 Apr 22, 2006 (06:55:48 PDT) WSDL2Java emitter.
 */

package com.booktera.data.CommonModels_Models;

public class UserOrderPLVMUserOrderVM  implements java.io.Serializable {
    private java.lang.String customerAddress;

    private java.lang.Integer customerAddressId;

    private java.lang.Boolean customerFeedbackedSuccessful;

    private java.lang.String customerFriendlyUrl;

    private java.lang.String customerName;

    private java.lang.Integer customersFeePercent;

    private java.util.Calendar date;

    private java.lang.Integer ID;

    private com.booktera.data.CommonPortable_Enums.UserOrderStatus status;

    private java.lang.Integer sumBookPrice;

    private java.lang.String vendorAddress;

    private java.lang.Integer vendorAddressId;

    private java.lang.Boolean vendorFeedbackedSuccessful;

    private java.lang.String vendorFriendlyUrl;

    private java.lang.String vendorName;

    private java.lang.Integer vendorsFeePercent;

    public UserOrderPLVMUserOrderVM() {
    }

    public UserOrderPLVMUserOrderVM(
           java.lang.String customerAddress,
           java.lang.Integer customerAddressId,
           java.lang.Boolean customerFeedbackedSuccessful,
           java.lang.String customerFriendlyUrl,
           java.lang.String customerName,
           java.lang.Integer customersFeePercent,
           java.util.Calendar date,
           java.lang.Integer ID,
           com.booktera.data.CommonPortable_Enums.UserOrderStatus status,
           java.lang.Integer sumBookPrice,
           java.lang.String vendorAddress,
           java.lang.Integer vendorAddressId,
           java.lang.Boolean vendorFeedbackedSuccessful,
           java.lang.String vendorFriendlyUrl,
           java.lang.String vendorName,
           java.lang.Integer vendorsFeePercent) {
           this.customerAddress = customerAddress;
           this.customerAddressId = customerAddressId;
           this.customerFeedbackedSuccessful = customerFeedbackedSuccessful;
           this.customerFriendlyUrl = customerFriendlyUrl;
           this.customerName = customerName;
           this.customersFeePercent = customersFeePercent;
           this.date = date;
           this.ID = ID;
           this.status = status;
           this.sumBookPrice = sumBookPrice;
           this.vendorAddress = vendorAddress;
           this.vendorAddressId = vendorAddressId;
           this.vendorFeedbackedSuccessful = vendorFeedbackedSuccessful;
           this.vendorFriendlyUrl = vendorFriendlyUrl;
           this.vendorName = vendorName;
           this.vendorsFeePercent = vendorsFeePercent;
    }


    /**
     * Gets the customerAddress value for this UserOrderPLVMUserOrderVM.
     * 
     * @return customerAddress
     */
    public java.lang.String getCustomerAddress() {
        return customerAddress;
    }


    /**
     * Sets the customerAddress value for this UserOrderPLVMUserOrderVM.
     * 
     * @param customerAddress
     */
    public void setCustomerAddress(java.lang.String customerAddress) {
        this.customerAddress = customerAddress;
    }


    /**
     * Gets the customerAddressId value for this UserOrderPLVMUserOrderVM.
     * 
     * @return customerAddressId
     */
    public java.lang.Integer getCustomerAddressId() {
        return customerAddressId;
    }


    /**
     * Sets the customerAddressId value for this UserOrderPLVMUserOrderVM.
     * 
     * @param customerAddressId
     */
    public void setCustomerAddressId(java.lang.Integer customerAddressId) {
        this.customerAddressId = customerAddressId;
    }


    /**
     * Gets the customerFeedbackedSuccessful value for this UserOrderPLVMUserOrderVM.
     * 
     * @return customerFeedbackedSuccessful
     */
    public java.lang.Boolean getCustomerFeedbackedSuccessful() {
        return customerFeedbackedSuccessful;
    }


    /**
     * Sets the customerFeedbackedSuccessful value for this UserOrderPLVMUserOrderVM.
     * 
     * @param customerFeedbackedSuccessful
     */
    public void setCustomerFeedbackedSuccessful(java.lang.Boolean customerFeedbackedSuccessful) {
        this.customerFeedbackedSuccessful = customerFeedbackedSuccessful;
    }


    /**
     * Gets the customerFriendlyUrl value for this UserOrderPLVMUserOrderVM.
     * 
     * @return customerFriendlyUrl
     */
    public java.lang.String getCustomerFriendlyUrl() {
        return customerFriendlyUrl;
    }


    /**
     * Sets the customerFriendlyUrl value for this UserOrderPLVMUserOrderVM.
     * 
     * @param customerFriendlyUrl
     */
    public void setCustomerFriendlyUrl(java.lang.String customerFriendlyUrl) {
        this.customerFriendlyUrl = customerFriendlyUrl;
    }


    /**
     * Gets the customerName value for this UserOrderPLVMUserOrderVM.
     * 
     * @return customerName
     */
    public java.lang.String getCustomerName() {
        return customerName;
    }


    /**
     * Sets the customerName value for this UserOrderPLVMUserOrderVM.
     * 
     * @param customerName
     */
    public void setCustomerName(java.lang.String customerName) {
        this.customerName = customerName;
    }


    /**
     * Gets the customersFeePercent value for this UserOrderPLVMUserOrderVM.
     * 
     * @return customersFeePercent
     */
    public java.lang.Integer getCustomersFeePercent() {
        return customersFeePercent;
    }


    /**
     * Sets the customersFeePercent value for this UserOrderPLVMUserOrderVM.
     * 
     * @param customersFeePercent
     */
    public void setCustomersFeePercent(java.lang.Integer customersFeePercent) {
        this.customersFeePercent = customersFeePercent;
    }


    /**
     * Gets the date value for this UserOrderPLVMUserOrderVM.
     * 
     * @return date
     */
    public java.util.Calendar getDate() {
        return date;
    }


    /**
     * Sets the date value for this UserOrderPLVMUserOrderVM.
     * 
     * @param date
     */
    public void setDate(java.util.Calendar date) {
        this.date = date;
    }


    /**
     * Gets the ID value for this UserOrderPLVMUserOrderVM.
     * 
     * @return ID
     */
    public java.lang.Integer getID() {
        return ID;
    }


    /**
     * Sets the ID value for this UserOrderPLVMUserOrderVM.
     * 
     * @param ID
     */
    public void setID(java.lang.Integer ID) {
        this.ID = ID;
    }


    /**
     * Gets the status value for this UserOrderPLVMUserOrderVM.
     * 
     * @return status
     */
    public com.booktera.data.CommonPortable_Enums.UserOrderStatus getStatus() {
        return status;
    }


    /**
     * Sets the status value for this UserOrderPLVMUserOrderVM.
     * 
     * @param status
     */
    public void setStatus(com.booktera.data.CommonPortable_Enums.UserOrderStatus status) {
        this.status = status;
    }


    /**
     * Gets the sumBookPrice value for this UserOrderPLVMUserOrderVM.
     * 
     * @return sumBookPrice
     */
    public java.lang.Integer getSumBookPrice() {
        return sumBookPrice;
    }


    /**
     * Sets the sumBookPrice value for this UserOrderPLVMUserOrderVM.
     * 
     * @param sumBookPrice
     */
    public void setSumBookPrice(java.lang.Integer sumBookPrice) {
        this.sumBookPrice = sumBookPrice;
    }


    /**
     * Gets the vendorAddress value for this UserOrderPLVMUserOrderVM.
     * 
     * @return vendorAddress
     */
    public java.lang.String getVendorAddress() {
        return vendorAddress;
    }


    /**
     * Sets the vendorAddress value for this UserOrderPLVMUserOrderVM.
     * 
     * @param vendorAddress
     */
    public void setVendorAddress(java.lang.String vendorAddress) {
        this.vendorAddress = vendorAddress;
    }


    /**
     * Gets the vendorAddressId value for this UserOrderPLVMUserOrderVM.
     * 
     * @return vendorAddressId
     */
    public java.lang.Integer getVendorAddressId() {
        return vendorAddressId;
    }


    /**
     * Sets the vendorAddressId value for this UserOrderPLVMUserOrderVM.
     * 
     * @param vendorAddressId
     */
    public void setVendorAddressId(java.lang.Integer vendorAddressId) {
        this.vendorAddressId = vendorAddressId;
    }


    /**
     * Gets the vendorFeedbackedSuccessful value for this UserOrderPLVMUserOrderVM.
     * 
     * @return vendorFeedbackedSuccessful
     */
    public java.lang.Boolean getVendorFeedbackedSuccessful() {
        return vendorFeedbackedSuccessful;
    }


    /**
     * Sets the vendorFeedbackedSuccessful value for this UserOrderPLVMUserOrderVM.
     * 
     * @param vendorFeedbackedSuccessful
     */
    public void setVendorFeedbackedSuccessful(java.lang.Boolean vendorFeedbackedSuccessful) {
        this.vendorFeedbackedSuccessful = vendorFeedbackedSuccessful;
    }


    /**
     * Gets the vendorFriendlyUrl value for this UserOrderPLVMUserOrderVM.
     * 
     * @return vendorFriendlyUrl
     */
    public java.lang.String getVendorFriendlyUrl() {
        return vendorFriendlyUrl;
    }


    /**
     * Sets the vendorFriendlyUrl value for this UserOrderPLVMUserOrderVM.
     * 
     * @param vendorFriendlyUrl
     */
    public void setVendorFriendlyUrl(java.lang.String vendorFriendlyUrl) {
        this.vendorFriendlyUrl = vendorFriendlyUrl;
    }


    /**
     * Gets the vendorName value for this UserOrderPLVMUserOrderVM.
     * 
     * @return vendorName
     */
    public java.lang.String getVendorName() {
        return vendorName;
    }


    /**
     * Sets the vendorName value for this UserOrderPLVMUserOrderVM.
     * 
     * @param vendorName
     */
    public void setVendorName(java.lang.String vendorName) {
        this.vendorName = vendorName;
    }


    /**
     * Gets the vendorsFeePercent value for this UserOrderPLVMUserOrderVM.
     * 
     * @return vendorsFeePercent
     */
    public java.lang.Integer getVendorsFeePercent() {
        return vendorsFeePercent;
    }


    /**
     * Sets the vendorsFeePercent value for this UserOrderPLVMUserOrderVM.
     * 
     * @param vendorsFeePercent
     */
    public void setVendorsFeePercent(java.lang.Integer vendorsFeePercent) {
        this.vendorsFeePercent = vendorsFeePercent;
    }

    private java.lang.Object __equalsCalc = null;
    public synchronized boolean equals(java.lang.Object obj) {
        if (!(obj instanceof UserOrderPLVMUserOrderVM)) return false;
        UserOrderPLVMUserOrderVM other = (UserOrderPLVMUserOrderVM) obj;
        if (obj == null) return false;
        if (this == obj) return true;
        if (__equalsCalc != null) {
            return (__equalsCalc == obj);
        }
        __equalsCalc = obj;
        boolean _equals;
        _equals = true && 
            ((this.customerAddress==null && other.getCustomerAddress()==null) || 
             (this.customerAddress!=null &&
              this.customerAddress.equals(other.getCustomerAddress()))) &&
            ((this.customerAddressId==null && other.getCustomerAddressId()==null) || 
             (this.customerAddressId!=null &&
              this.customerAddressId.equals(other.getCustomerAddressId()))) &&
            ((this.customerFeedbackedSuccessful==null && other.getCustomerFeedbackedSuccessful()==null) || 
             (this.customerFeedbackedSuccessful!=null &&
              this.customerFeedbackedSuccessful.equals(other.getCustomerFeedbackedSuccessful()))) &&
            ((this.customerFriendlyUrl==null && other.getCustomerFriendlyUrl()==null) || 
             (this.customerFriendlyUrl!=null &&
              this.customerFriendlyUrl.equals(other.getCustomerFriendlyUrl()))) &&
            ((this.customerName==null && other.getCustomerName()==null) || 
             (this.customerName!=null &&
              this.customerName.equals(other.getCustomerName()))) &&
            ((this.customersFeePercent==null && other.getCustomersFeePercent()==null) || 
             (this.customersFeePercent!=null &&
              this.customersFeePercent.equals(other.getCustomersFeePercent()))) &&
            ((this.date==null && other.getDate()==null) || 
             (this.date!=null &&
              this.date.equals(other.getDate()))) &&
            ((this.ID==null && other.getID()==null) || 
             (this.ID!=null &&
              this.ID.equals(other.getID()))) &&
            ((this.status==null && other.getStatus()==null) || 
             (this.status!=null &&
              this.status.equals(other.getStatus()))) &&
            ((this.sumBookPrice==null && other.getSumBookPrice()==null) || 
             (this.sumBookPrice!=null &&
              this.sumBookPrice.equals(other.getSumBookPrice()))) &&
            ((this.vendorAddress==null && other.getVendorAddress()==null) || 
             (this.vendorAddress!=null &&
              this.vendorAddress.equals(other.getVendorAddress()))) &&
            ((this.vendorAddressId==null && other.getVendorAddressId()==null) || 
             (this.vendorAddressId!=null &&
              this.vendorAddressId.equals(other.getVendorAddressId()))) &&
            ((this.vendorFeedbackedSuccessful==null && other.getVendorFeedbackedSuccessful()==null) || 
             (this.vendorFeedbackedSuccessful!=null &&
              this.vendorFeedbackedSuccessful.equals(other.getVendorFeedbackedSuccessful()))) &&
            ((this.vendorFriendlyUrl==null && other.getVendorFriendlyUrl()==null) || 
             (this.vendorFriendlyUrl!=null &&
              this.vendorFriendlyUrl.equals(other.getVendorFriendlyUrl()))) &&
            ((this.vendorName==null && other.getVendorName()==null) || 
             (this.vendorName!=null &&
              this.vendorName.equals(other.getVendorName()))) &&
            ((this.vendorsFeePercent==null && other.getVendorsFeePercent()==null) || 
             (this.vendorsFeePercent!=null &&
              this.vendorsFeePercent.equals(other.getVendorsFeePercent())));
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
        if (getCustomerAddress() != null) {
            _hashCode += getCustomerAddress().hashCode();
        }
        if (getCustomerAddressId() != null) {
            _hashCode += getCustomerAddressId().hashCode();
        }
        if (getCustomerFeedbackedSuccessful() != null) {
            _hashCode += getCustomerFeedbackedSuccessful().hashCode();
        }
        if (getCustomerFriendlyUrl() != null) {
            _hashCode += getCustomerFriendlyUrl().hashCode();
        }
        if (getCustomerName() != null) {
            _hashCode += getCustomerName().hashCode();
        }
        if (getCustomersFeePercent() != null) {
            _hashCode += getCustomersFeePercent().hashCode();
        }
        if (getDate() != null) {
            _hashCode += getDate().hashCode();
        }
        if (getID() != null) {
            _hashCode += getID().hashCode();
        }
        if (getStatus() != null) {
            _hashCode += getStatus().hashCode();
        }
        if (getSumBookPrice() != null) {
            _hashCode += getSumBookPrice().hashCode();
        }
        if (getVendorAddress() != null) {
            _hashCode += getVendorAddress().hashCode();
        }
        if (getVendorAddressId() != null) {
            _hashCode += getVendorAddressId().hashCode();
        }
        if (getVendorFeedbackedSuccessful() != null) {
            _hashCode += getVendorFeedbackedSuccessful().hashCode();
        }
        if (getVendorFriendlyUrl() != null) {
            _hashCode += getVendorFriendlyUrl().hashCode();
        }
        if (getVendorName() != null) {
            _hashCode += getVendorName().hashCode();
        }
        if (getVendorsFeePercent() != null) {
            _hashCode += getVendorsFeePercent().hashCode();
        }
        __hashCodeCalc = false;
        return _hashCode;
    }

    // Type metadata
    private static org.apache.axis.description.TypeDesc typeDesc =
        new org.apache.axis.description.TypeDesc(UserOrderPLVMUserOrderVM.class, true);

    static {
        typeDesc.setXmlType(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models", "UserOrderPLVM.UserOrderVM"));
        org.apache.axis.description.ElementDesc elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("customerAddress");
        elemField.setXmlName(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models", "CustomerAddress"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "string"));
        elemField.setMinOccurs(0);
        elemField.setNillable(true);
        typeDesc.addFieldDesc(elemField);
        elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("customerAddressId");
        elemField.setXmlName(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models", "CustomerAddressId"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "int"));
        elemField.setMinOccurs(0);
        elemField.setNillable(true);
        typeDesc.addFieldDesc(elemField);
        elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("customerFeedbackedSuccessful");
        elemField.setXmlName(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models", "CustomerFeedbackedSuccessful"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "boolean"));
        elemField.setMinOccurs(0);
        elemField.setNillable(true);
        typeDesc.addFieldDesc(elemField);
        elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("customerFriendlyUrl");
        elemField.setXmlName(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models", "CustomerFriendlyUrl"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "string"));
        elemField.setMinOccurs(0);
        elemField.setNillable(true);
        typeDesc.addFieldDesc(elemField);
        elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("customerName");
        elemField.setXmlName(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models", "CustomerName"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "string"));
        elemField.setMinOccurs(0);
        elemField.setNillable(true);
        typeDesc.addFieldDesc(elemField);
        elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("customersFeePercent");
        elemField.setXmlName(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models", "CustomersFeePercent"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "int"));
        elemField.setMinOccurs(0);
        elemField.setNillable(false);
        typeDesc.addFieldDesc(elemField);
        elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("date");
        elemField.setXmlName(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models", "Date"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "dateTime"));
        elemField.setMinOccurs(0);
        elemField.setNillable(false);
        typeDesc.addFieldDesc(elemField);
        elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("ID");
        elemField.setXmlName(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models", "ID"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "int"));
        elemField.setMinOccurs(0);
        elemField.setNillable(false);
        typeDesc.addFieldDesc(elemField);
        elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("status");
        elemField.setXmlName(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models", "Status"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonPortable.Enums", "UserOrderStatus"));
        elemField.setMinOccurs(0);
        elemField.setNillable(false);
        typeDesc.addFieldDesc(elemField);
        elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("sumBookPrice");
        elemField.setXmlName(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models", "SumBookPrice"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "int"));
        elemField.setMinOccurs(0);
        elemField.setNillable(false);
        typeDesc.addFieldDesc(elemField);
        elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("vendorAddress");
        elemField.setXmlName(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models", "VendorAddress"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "string"));
        elemField.setMinOccurs(0);
        elemField.setNillable(true);
        typeDesc.addFieldDesc(elemField);
        elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("vendorAddressId");
        elemField.setXmlName(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models", "VendorAddressId"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "int"));
        elemField.setMinOccurs(0);
        elemField.setNillable(true);
        typeDesc.addFieldDesc(elemField);
        elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("vendorFeedbackedSuccessful");
        elemField.setXmlName(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models", "VendorFeedbackedSuccessful"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "boolean"));
        elemField.setMinOccurs(0);
        elemField.setNillable(true);
        typeDesc.addFieldDesc(elemField);
        elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("vendorFriendlyUrl");
        elemField.setXmlName(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models", "VendorFriendlyUrl"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "string"));
        elemField.setMinOccurs(0);
        elemField.setNillable(true);
        typeDesc.addFieldDesc(elemField);
        elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("vendorName");
        elemField.setXmlName(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models", "VendorName"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "string"));
        elemField.setMinOccurs(0);
        elemField.setNillable(true);
        typeDesc.addFieldDesc(elemField);
        elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("vendorsFeePercent");
        elemField.setXmlName(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models", "VendorsFeePercent"));
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
