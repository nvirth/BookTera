/**
 * UserOrder.java
 *
 * This file was auto-generated from WSDL
 * by the Apache Axis 1.4 Apr 22, 2006 (06:55:48 PDT) WSDL2Java emitter.
 */

package com.booktera.data.CommonModels_Models_EntityFramework;

public class UserOrder  implements java.io.Serializable {
    private com.booktera.data.CommonModels_Models_EntityFramework.UserAddress customerAddress;

    private java.lang.Integer customerAddressID;

    private com.booktera.data.CommonModels_Models_EntityFramework.UserProfile customerUserProfile;

    private java.lang.Integer customerUserProfileID;

    private java.lang.Integer customersBuyFeePercent;

    private java.util.Calendar date;

    private com.booktera.data.CommonModels_Models_EntityFramework.Feedback[] feedbacks;

    private java.lang.Integer ID;

    private com.booktera.data.CommonModels_Models_EntityFramework.ProductInOrder[] productsInOrder;

    private org.apache.axis.types.UnsignedByte ratingState;

    private org.apache.axis.types.UnsignedByte status;

    private java.lang.Integer sumBookPrice;

    private java.lang.String sumOtherPrices;

    private com.booktera.data.CommonModels_Models_EntityFramework.UserAddress vendorAddress;

    private java.lang.Integer vendorAddressID;

    private com.booktera.data.CommonModels_Models_EntityFramework.UserProfile vendorUserProfile;

    private java.lang.Integer vendorUserProfileID;

    private java.lang.Integer vendorsSellFeePercent;

    public UserOrder() {
    }

    public UserOrder(
           com.booktera.data.CommonModels_Models_EntityFramework.UserAddress customerAddress,
           java.lang.Integer customerAddressID,
           com.booktera.data.CommonModels_Models_EntityFramework.UserProfile customerUserProfile,
           java.lang.Integer customerUserProfileID,
           java.lang.Integer customersBuyFeePercent,
           java.util.Calendar date,
           com.booktera.data.CommonModels_Models_EntityFramework.Feedback[] feedbacks,
           java.lang.Integer ID,
           com.booktera.data.CommonModels_Models_EntityFramework.ProductInOrder[] productsInOrder,
           org.apache.axis.types.UnsignedByte ratingState,
           org.apache.axis.types.UnsignedByte status,
           java.lang.Integer sumBookPrice,
           java.lang.String sumOtherPrices,
           com.booktera.data.CommonModels_Models_EntityFramework.UserAddress vendorAddress,
           java.lang.Integer vendorAddressID,
           com.booktera.data.CommonModels_Models_EntityFramework.UserProfile vendorUserProfile,
           java.lang.Integer vendorUserProfileID,
           java.lang.Integer vendorsSellFeePercent) {
           this.customerAddress = customerAddress;
           this.customerAddressID = customerAddressID;
           this.customerUserProfile = customerUserProfile;
           this.customerUserProfileID = customerUserProfileID;
           this.customersBuyFeePercent = customersBuyFeePercent;
           this.date = date;
           this.feedbacks = feedbacks;
           this.ID = ID;
           this.productsInOrder = productsInOrder;
           this.ratingState = ratingState;
           this.status = status;
           this.sumBookPrice = sumBookPrice;
           this.sumOtherPrices = sumOtherPrices;
           this.vendorAddress = vendorAddress;
           this.vendorAddressID = vendorAddressID;
           this.vendorUserProfile = vendorUserProfile;
           this.vendorUserProfileID = vendorUserProfileID;
           this.vendorsSellFeePercent = vendorsSellFeePercent;
    }


    /**
     * Gets the customerAddress value for this UserOrder.
     * 
     * @return customerAddress
     */
    public com.booktera.data.CommonModels_Models_EntityFramework.UserAddress getCustomerAddress() {
        return customerAddress;
    }


    /**
     * Sets the customerAddress value for this UserOrder.
     * 
     * @param customerAddress
     */
    public void setCustomerAddress(com.booktera.data.CommonModels_Models_EntityFramework.UserAddress customerAddress) {
        this.customerAddress = customerAddress;
    }


    /**
     * Gets the customerAddressID value for this UserOrder.
     * 
     * @return customerAddressID
     */
    public java.lang.Integer getCustomerAddressID() {
        return customerAddressID;
    }


    /**
     * Sets the customerAddressID value for this UserOrder.
     * 
     * @param customerAddressID
     */
    public void setCustomerAddressID(java.lang.Integer customerAddressID) {
        this.customerAddressID = customerAddressID;
    }


    /**
     * Gets the customerUserProfile value for this UserOrder.
     * 
     * @return customerUserProfile
     */
    public com.booktera.data.CommonModels_Models_EntityFramework.UserProfile getCustomerUserProfile() {
        return customerUserProfile;
    }


    /**
     * Sets the customerUserProfile value for this UserOrder.
     * 
     * @param customerUserProfile
     */
    public void setCustomerUserProfile(com.booktera.data.CommonModels_Models_EntityFramework.UserProfile customerUserProfile) {
        this.customerUserProfile = customerUserProfile;
    }


    /**
     * Gets the customerUserProfileID value for this UserOrder.
     * 
     * @return customerUserProfileID
     */
    public java.lang.Integer getCustomerUserProfileID() {
        return customerUserProfileID;
    }


    /**
     * Sets the customerUserProfileID value for this UserOrder.
     * 
     * @param customerUserProfileID
     */
    public void setCustomerUserProfileID(java.lang.Integer customerUserProfileID) {
        this.customerUserProfileID = customerUserProfileID;
    }


    /**
     * Gets the customersBuyFeePercent value for this UserOrder.
     * 
     * @return customersBuyFeePercent
     */
    public java.lang.Integer getCustomersBuyFeePercent() {
        return customersBuyFeePercent;
    }


    /**
     * Sets the customersBuyFeePercent value for this UserOrder.
     * 
     * @param customersBuyFeePercent
     */
    public void setCustomersBuyFeePercent(java.lang.Integer customersBuyFeePercent) {
        this.customersBuyFeePercent = customersBuyFeePercent;
    }


    /**
     * Gets the date value for this UserOrder.
     * 
     * @return date
     */
    public java.util.Calendar getDate() {
        return date;
    }


    /**
     * Sets the date value for this UserOrder.
     * 
     * @param date
     */
    public void setDate(java.util.Calendar date) {
        this.date = date;
    }


    /**
     * Gets the feedbacks value for this UserOrder.
     * 
     * @return feedbacks
     */
    public com.booktera.data.CommonModels_Models_EntityFramework.Feedback[] getFeedbacks() {
        return feedbacks;
    }


    /**
     * Sets the feedbacks value for this UserOrder.
     * 
     * @param feedbacks
     */
    public void setFeedbacks(com.booktera.data.CommonModels_Models_EntityFramework.Feedback[] feedbacks) {
        this.feedbacks = feedbacks;
    }


    /**
     * Gets the ID value for this UserOrder.
     * 
     * @return ID
     */
    public java.lang.Integer getID() {
        return ID;
    }


    /**
     * Sets the ID value for this UserOrder.
     * 
     * @param ID
     */
    public void setID(java.lang.Integer ID) {
        this.ID = ID;
    }


    /**
     * Gets the productsInOrder value for this UserOrder.
     * 
     * @return productsInOrder
     */
    public com.booktera.data.CommonModels_Models_EntityFramework.ProductInOrder[] getProductsInOrder() {
        return productsInOrder;
    }


    /**
     * Sets the productsInOrder value for this UserOrder.
     * 
     * @param productsInOrder
     */
    public void setProductsInOrder(com.booktera.data.CommonModels_Models_EntityFramework.ProductInOrder[] productsInOrder) {
        this.productsInOrder = productsInOrder;
    }


    /**
     * Gets the ratingState value for this UserOrder.
     * 
     * @return ratingState
     */
    public org.apache.axis.types.UnsignedByte getRatingState() {
        return ratingState;
    }


    /**
     * Sets the ratingState value for this UserOrder.
     * 
     * @param ratingState
     */
    public void setRatingState(org.apache.axis.types.UnsignedByte ratingState) {
        this.ratingState = ratingState;
    }


    /**
     * Gets the status value for this UserOrder.
     * 
     * @return status
     */
    public org.apache.axis.types.UnsignedByte getStatus() {
        return status;
    }


    /**
     * Sets the status value for this UserOrder.
     * 
     * @param status
     */
    public void setStatus(org.apache.axis.types.UnsignedByte status) {
        this.status = status;
    }


    /**
     * Gets the sumBookPrice value for this UserOrder.
     * 
     * @return sumBookPrice
     */
    public java.lang.Integer getSumBookPrice() {
        return sumBookPrice;
    }


    /**
     * Sets the sumBookPrice value for this UserOrder.
     * 
     * @param sumBookPrice
     */
    public void setSumBookPrice(java.lang.Integer sumBookPrice) {
        this.sumBookPrice = sumBookPrice;
    }


    /**
     * Gets the sumOtherPrices value for this UserOrder.
     * 
     * @return sumOtherPrices
     */
    public java.lang.String getSumOtherPrices() {
        return sumOtherPrices;
    }


    /**
     * Sets the sumOtherPrices value for this UserOrder.
     * 
     * @param sumOtherPrices
     */
    public void setSumOtherPrices(java.lang.String sumOtherPrices) {
        this.sumOtherPrices = sumOtherPrices;
    }


    /**
     * Gets the vendorAddress value for this UserOrder.
     * 
     * @return vendorAddress
     */
    public com.booktera.data.CommonModels_Models_EntityFramework.UserAddress getVendorAddress() {
        return vendorAddress;
    }


    /**
     * Sets the vendorAddress value for this UserOrder.
     * 
     * @param vendorAddress
     */
    public void setVendorAddress(com.booktera.data.CommonModels_Models_EntityFramework.UserAddress vendorAddress) {
        this.vendorAddress = vendorAddress;
    }


    /**
     * Gets the vendorAddressID value for this UserOrder.
     * 
     * @return vendorAddressID
     */
    public java.lang.Integer getVendorAddressID() {
        return vendorAddressID;
    }


    /**
     * Sets the vendorAddressID value for this UserOrder.
     * 
     * @param vendorAddressID
     */
    public void setVendorAddressID(java.lang.Integer vendorAddressID) {
        this.vendorAddressID = vendorAddressID;
    }


    /**
     * Gets the vendorUserProfile value for this UserOrder.
     * 
     * @return vendorUserProfile
     */
    public com.booktera.data.CommonModels_Models_EntityFramework.UserProfile getVendorUserProfile() {
        return vendorUserProfile;
    }


    /**
     * Sets the vendorUserProfile value for this UserOrder.
     * 
     * @param vendorUserProfile
     */
    public void setVendorUserProfile(com.booktera.data.CommonModels_Models_EntityFramework.UserProfile vendorUserProfile) {
        this.vendorUserProfile = vendorUserProfile;
    }


    /**
     * Gets the vendorUserProfileID value for this UserOrder.
     * 
     * @return vendorUserProfileID
     */
    public java.lang.Integer getVendorUserProfileID() {
        return vendorUserProfileID;
    }


    /**
     * Sets the vendorUserProfileID value for this UserOrder.
     * 
     * @param vendorUserProfileID
     */
    public void setVendorUserProfileID(java.lang.Integer vendorUserProfileID) {
        this.vendorUserProfileID = vendorUserProfileID;
    }


    /**
     * Gets the vendorsSellFeePercent value for this UserOrder.
     * 
     * @return vendorsSellFeePercent
     */
    public java.lang.Integer getVendorsSellFeePercent() {
        return vendorsSellFeePercent;
    }


    /**
     * Sets the vendorsSellFeePercent value for this UserOrder.
     * 
     * @param vendorsSellFeePercent
     */
    public void setVendorsSellFeePercent(java.lang.Integer vendorsSellFeePercent) {
        this.vendorsSellFeePercent = vendorsSellFeePercent;
    }

    private java.lang.Object __equalsCalc = null;
    public synchronized boolean equals(java.lang.Object obj) {
        if (!(obj instanceof UserOrder)) return false;
        UserOrder other = (UserOrder) obj;
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
            ((this.customerAddressID==null && other.getCustomerAddressID()==null) || 
             (this.customerAddressID!=null &&
              this.customerAddressID.equals(other.getCustomerAddressID()))) &&
            ((this.customerUserProfile==null && other.getCustomerUserProfile()==null) || 
             (this.customerUserProfile!=null &&
              this.customerUserProfile.equals(other.getCustomerUserProfile()))) &&
            ((this.customerUserProfileID==null && other.getCustomerUserProfileID()==null) || 
             (this.customerUserProfileID!=null &&
              this.customerUserProfileID.equals(other.getCustomerUserProfileID()))) &&
            ((this.customersBuyFeePercent==null && other.getCustomersBuyFeePercent()==null) || 
             (this.customersBuyFeePercent!=null &&
              this.customersBuyFeePercent.equals(other.getCustomersBuyFeePercent()))) &&
            ((this.date==null && other.getDate()==null) || 
             (this.date!=null &&
              this.date.equals(other.getDate()))) &&
            ((this.feedbacks==null && other.getFeedbacks()==null) || 
             (this.feedbacks!=null &&
              java.util.Arrays.equals(this.feedbacks, other.getFeedbacks()))) &&
            ((this.ID==null && other.getID()==null) || 
             (this.ID!=null &&
              this.ID.equals(other.getID()))) &&
            ((this.productsInOrder==null && other.getProductsInOrder()==null) || 
             (this.productsInOrder!=null &&
              java.util.Arrays.equals(this.productsInOrder, other.getProductsInOrder()))) &&
            ((this.ratingState==null && other.getRatingState()==null) || 
             (this.ratingState!=null &&
              this.ratingState.equals(other.getRatingState()))) &&
            ((this.status==null && other.getStatus()==null) || 
             (this.status!=null &&
              this.status.equals(other.getStatus()))) &&
            ((this.sumBookPrice==null && other.getSumBookPrice()==null) || 
             (this.sumBookPrice!=null &&
              this.sumBookPrice.equals(other.getSumBookPrice()))) &&
            ((this.sumOtherPrices==null && other.getSumOtherPrices()==null) || 
             (this.sumOtherPrices!=null &&
              this.sumOtherPrices.equals(other.getSumOtherPrices()))) &&
            ((this.vendorAddress==null && other.getVendorAddress()==null) || 
             (this.vendorAddress!=null &&
              this.vendorAddress.equals(other.getVendorAddress()))) &&
            ((this.vendorAddressID==null && other.getVendorAddressID()==null) || 
             (this.vendorAddressID!=null &&
              this.vendorAddressID.equals(other.getVendorAddressID()))) &&
            ((this.vendorUserProfile==null && other.getVendorUserProfile()==null) || 
             (this.vendorUserProfile!=null &&
              this.vendorUserProfile.equals(other.getVendorUserProfile()))) &&
            ((this.vendorUserProfileID==null && other.getVendorUserProfileID()==null) || 
             (this.vendorUserProfileID!=null &&
              this.vendorUserProfileID.equals(other.getVendorUserProfileID()))) &&
            ((this.vendorsSellFeePercent==null && other.getVendorsSellFeePercent()==null) || 
             (this.vendorsSellFeePercent!=null &&
              this.vendorsSellFeePercent.equals(other.getVendorsSellFeePercent())));
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
        if (getCustomerAddressID() != null) {
            _hashCode += getCustomerAddressID().hashCode();
        }
        if (getCustomerUserProfile() != null) {
            _hashCode += getCustomerUserProfile().hashCode();
        }
        if (getCustomerUserProfileID() != null) {
            _hashCode += getCustomerUserProfileID().hashCode();
        }
        if (getCustomersBuyFeePercent() != null) {
            _hashCode += getCustomersBuyFeePercent().hashCode();
        }
        if (getDate() != null) {
            _hashCode += getDate().hashCode();
        }
        if (getFeedbacks() != null) {
            for (int i=0;
                 i<java.lang.reflect.Array.getLength(getFeedbacks());
                 i++) {
                java.lang.Object obj = java.lang.reflect.Array.get(getFeedbacks(), i);
                if (obj != null &&
                    !obj.getClass().isArray()) {
                    _hashCode += obj.hashCode();
                }
            }
        }
        if (getID() != null) {
            _hashCode += getID().hashCode();
        }
        if (getProductsInOrder() != null) {
            for (int i=0;
                 i<java.lang.reflect.Array.getLength(getProductsInOrder());
                 i++) {
                java.lang.Object obj = java.lang.reflect.Array.get(getProductsInOrder(), i);
                if (obj != null &&
                    !obj.getClass().isArray()) {
                    _hashCode += obj.hashCode();
                }
            }
        }
        if (getRatingState() != null) {
            _hashCode += getRatingState().hashCode();
        }
        if (getStatus() != null) {
            _hashCode += getStatus().hashCode();
        }
        if (getSumBookPrice() != null) {
            _hashCode += getSumBookPrice().hashCode();
        }
        if (getSumOtherPrices() != null) {
            _hashCode += getSumOtherPrices().hashCode();
        }
        if (getVendorAddress() != null) {
            _hashCode += getVendorAddress().hashCode();
        }
        if (getVendorAddressID() != null) {
            _hashCode += getVendorAddressID().hashCode();
        }
        if (getVendorUserProfile() != null) {
            _hashCode += getVendorUserProfile().hashCode();
        }
        if (getVendorUserProfileID() != null) {
            _hashCode += getVendorUserProfileID().hashCode();
        }
        if (getVendorsSellFeePercent() != null) {
            _hashCode += getVendorsSellFeePercent().hashCode();
        }
        __hashCodeCalc = false;
        return _hashCode;
    }

    // Type metadata
    private static org.apache.axis.description.TypeDesc typeDesc =
        new org.apache.axis.description.TypeDesc(UserOrder.class, true);

    static {
        typeDesc.setXmlType(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "UserOrder"));
        org.apache.axis.description.ElementDesc elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("customerAddress");
        elemField.setXmlName(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "CustomerAddress"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "UserAddress"));
        elemField.setMinOccurs(0);
        elemField.setNillable(true);
        typeDesc.addFieldDesc(elemField);
        elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("customerAddressID");
        elemField.setXmlName(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "CustomerAddressID"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "int"));
        elemField.setMinOccurs(0);
        elemField.setNillable(true);
        typeDesc.addFieldDesc(elemField);
        elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("customerUserProfile");
        elemField.setXmlName(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "CustomerUserProfile"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "UserProfile"));
        elemField.setMinOccurs(0);
        elemField.setNillable(true);
        typeDesc.addFieldDesc(elemField);
        elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("customerUserProfileID");
        elemField.setXmlName(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "CustomerUserProfileID"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "int"));
        elemField.setMinOccurs(0);
        elemField.setNillable(false);
        typeDesc.addFieldDesc(elemField);
        elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("customersBuyFeePercent");
        elemField.setXmlName(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "CustomersBuyFeePercent"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "int"));
        elemField.setMinOccurs(0);
        elemField.setNillable(false);
        typeDesc.addFieldDesc(elemField);
        elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("date");
        elemField.setXmlName(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "Date"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "dateTime"));
        elemField.setMinOccurs(0);
        elemField.setNillable(false);
        typeDesc.addFieldDesc(elemField);
        elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("feedbacks");
        elemField.setXmlName(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "Feedbacks"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "Feedback"));
        elemField.setMinOccurs(0);
        elemField.setNillable(true);
        elemField.setItemQName(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "Feedback"));
        typeDesc.addFieldDesc(elemField);
        elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("ID");
        elemField.setXmlName(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "ID"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "int"));
        elemField.setMinOccurs(0);
        elemField.setNillable(false);
        typeDesc.addFieldDesc(elemField);
        elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("productsInOrder");
        elemField.setXmlName(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "ProductsInOrder"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "ProductInOrder"));
        elemField.setMinOccurs(0);
        elemField.setNillable(true);
        elemField.setItemQName(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "ProductInOrder"));
        typeDesc.addFieldDesc(elemField);
        elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("ratingState");
        elemField.setXmlName(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "RatingState"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "unsignedByte"));
        elemField.setMinOccurs(0);
        elemField.setNillable(false);
        typeDesc.addFieldDesc(elemField);
        elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("status");
        elemField.setXmlName(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "Status"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "unsignedByte"));
        elemField.setMinOccurs(0);
        elemField.setNillable(false);
        typeDesc.addFieldDesc(elemField);
        elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("sumBookPrice");
        elemField.setXmlName(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "SumBookPrice"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "int"));
        elemField.setMinOccurs(0);
        elemField.setNillable(false);
        typeDesc.addFieldDesc(elemField);
        elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("sumOtherPrices");
        elemField.setXmlName(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "SumOtherPrices"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "string"));
        elemField.setMinOccurs(0);
        elemField.setNillable(true);
        typeDesc.addFieldDesc(elemField);
        elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("vendorAddress");
        elemField.setXmlName(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "VendorAddress"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "UserAddress"));
        elemField.setMinOccurs(0);
        elemField.setNillable(true);
        typeDesc.addFieldDesc(elemField);
        elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("vendorAddressID");
        elemField.setXmlName(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "VendorAddressID"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "int"));
        elemField.setMinOccurs(0);
        elemField.setNillable(true);
        typeDesc.addFieldDesc(elemField);
        elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("vendorUserProfile");
        elemField.setXmlName(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "VendorUserProfile"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "UserProfile"));
        elemField.setMinOccurs(0);
        elemField.setNillable(true);
        typeDesc.addFieldDesc(elemField);
        elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("vendorUserProfileID");
        elemField.setXmlName(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "VendorUserProfileID"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "int"));
        elemField.setMinOccurs(0);
        elemField.setNillable(false);
        typeDesc.addFieldDesc(elemField);
        elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("vendorsSellFeePercent");
        elemField.setXmlName(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "VendorsSellFeePercent"));
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
