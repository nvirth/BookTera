/**
 * Feedback.java
 *
 * This file was auto-generated from WSDL
 * by the Apache Axis 1.4 Apr 22, 2006 (06:55:48 PDT) WSDL2Java emitter.
 */

package com.booktera.data.CommonModels_Models_EntityFramework;

public class Feedback  implements java.io.Serializable {
    private java.util.Calendar date;

    private java.lang.String description;

    private java.lang.Integer ID;

    private java.lang.Boolean isCustomers;

    private java.lang.Boolean isPositive;

    private org.apache.axis.types.UnsignedByte productsQuality;

    private com.booktera.data.CommonModels_Models_EntityFramework.UserProfile rateGiverUser;

    private java.lang.Integer rateGiverUserID;

    private com.booktera.data.CommonModels_Models_EntityFramework.UserProfile ratedUser;

    private java.lang.Integer ratedUserID;

    private org.apache.axis.types.UnsignedByte sellerContact;

    private org.apache.axis.types.UnsignedByte transactionQuality;

    private org.apache.axis.types.UnsignedByte transportAndBoxing;

    private com.booktera.data.CommonModels_Models_EntityFramework.UserOrder userOrder;

    private java.lang.Integer userOrderID;

    private java.lang.Boolean wasSuccessful;

    public Feedback() {
    }

    public Feedback(
           java.util.Calendar date,
           java.lang.String description,
           java.lang.Integer ID,
           java.lang.Boolean isCustomers,
           java.lang.Boolean isPositive,
           org.apache.axis.types.UnsignedByte productsQuality,
           com.booktera.data.CommonModels_Models_EntityFramework.UserProfile rateGiverUser,
           java.lang.Integer rateGiverUserID,
           com.booktera.data.CommonModels_Models_EntityFramework.UserProfile ratedUser,
           java.lang.Integer ratedUserID,
           org.apache.axis.types.UnsignedByte sellerContact,
           org.apache.axis.types.UnsignedByte transactionQuality,
           org.apache.axis.types.UnsignedByte transportAndBoxing,
           com.booktera.data.CommonModels_Models_EntityFramework.UserOrder userOrder,
           java.lang.Integer userOrderID,
           java.lang.Boolean wasSuccessful) {
           this.date = date;
           this.description = description;
           this.ID = ID;
           this.isCustomers = isCustomers;
           this.isPositive = isPositive;
           this.productsQuality = productsQuality;
           this.rateGiverUser = rateGiverUser;
           this.rateGiverUserID = rateGiverUserID;
           this.ratedUser = ratedUser;
           this.ratedUserID = ratedUserID;
           this.sellerContact = sellerContact;
           this.transactionQuality = transactionQuality;
           this.transportAndBoxing = transportAndBoxing;
           this.userOrder = userOrder;
           this.userOrderID = userOrderID;
           this.wasSuccessful = wasSuccessful;
    }


    /**
     * Gets the date value for this Feedback.
     * 
     * @return date
     */
    public java.util.Calendar getDate() {
        return date;
    }


    /**
     * Sets the date value for this Feedback.
     * 
     * @param date
     */
    public void setDate(java.util.Calendar date) {
        this.date = date;
    }


    /**
     * Gets the description value for this Feedback.
     * 
     * @return description
     */
    public java.lang.String getDescription() {
        return description;
    }


    /**
     * Sets the description value for this Feedback.
     * 
     * @param description
     */
    public void setDescription(java.lang.String description) {
        this.description = description;
    }


    /**
     * Gets the ID value for this Feedback.
     * 
     * @return ID
     */
    public java.lang.Integer getID() {
        return ID;
    }


    /**
     * Sets the ID value for this Feedback.
     * 
     * @param ID
     */
    public void setID(java.lang.Integer ID) {
        this.ID = ID;
    }


    /**
     * Gets the isCustomers value for this Feedback.
     * 
     * @return isCustomers
     */
    public java.lang.Boolean getIsCustomers() {
        return isCustomers;
    }


    /**
     * Sets the isCustomers value for this Feedback.
     * 
     * @param isCustomers
     */
    public void setIsCustomers(java.lang.Boolean isCustomers) {
        this.isCustomers = isCustomers;
    }


    /**
     * Gets the isPositive value for this Feedback.
     * 
     * @return isPositive
     */
    public java.lang.Boolean getIsPositive() {
        return isPositive;
    }


    /**
     * Sets the isPositive value for this Feedback.
     * 
     * @param isPositive
     */
    public void setIsPositive(java.lang.Boolean isPositive) {
        this.isPositive = isPositive;
    }


    /**
     * Gets the productsQuality value for this Feedback.
     * 
     * @return productsQuality
     */
    public org.apache.axis.types.UnsignedByte getProductsQuality() {
        return productsQuality;
    }


    /**
     * Sets the productsQuality value for this Feedback.
     * 
     * @param productsQuality
     */
    public void setProductsQuality(org.apache.axis.types.UnsignedByte productsQuality) {
        this.productsQuality = productsQuality;
    }


    /**
     * Gets the rateGiverUser value for this Feedback.
     * 
     * @return rateGiverUser
     */
    public com.booktera.data.CommonModels_Models_EntityFramework.UserProfile getRateGiverUser() {
        return rateGiverUser;
    }


    /**
     * Sets the rateGiverUser value for this Feedback.
     * 
     * @param rateGiverUser
     */
    public void setRateGiverUser(com.booktera.data.CommonModels_Models_EntityFramework.UserProfile rateGiverUser) {
        this.rateGiverUser = rateGiverUser;
    }


    /**
     * Gets the rateGiverUserID value for this Feedback.
     * 
     * @return rateGiverUserID
     */
    public java.lang.Integer getRateGiverUserID() {
        return rateGiverUserID;
    }


    /**
     * Sets the rateGiverUserID value for this Feedback.
     * 
     * @param rateGiverUserID
     */
    public void setRateGiverUserID(java.lang.Integer rateGiverUserID) {
        this.rateGiverUserID = rateGiverUserID;
    }


    /**
     * Gets the ratedUser value for this Feedback.
     * 
     * @return ratedUser
     */
    public com.booktera.data.CommonModels_Models_EntityFramework.UserProfile getRatedUser() {
        return ratedUser;
    }


    /**
     * Sets the ratedUser value for this Feedback.
     * 
     * @param ratedUser
     */
    public void setRatedUser(com.booktera.data.CommonModels_Models_EntityFramework.UserProfile ratedUser) {
        this.ratedUser = ratedUser;
    }


    /**
     * Gets the ratedUserID value for this Feedback.
     * 
     * @return ratedUserID
     */
    public java.lang.Integer getRatedUserID() {
        return ratedUserID;
    }


    /**
     * Sets the ratedUserID value for this Feedback.
     * 
     * @param ratedUserID
     */
    public void setRatedUserID(java.lang.Integer ratedUserID) {
        this.ratedUserID = ratedUserID;
    }


    /**
     * Gets the sellerContact value for this Feedback.
     * 
     * @return sellerContact
     */
    public org.apache.axis.types.UnsignedByte getSellerContact() {
        return sellerContact;
    }


    /**
     * Sets the sellerContact value for this Feedback.
     * 
     * @param sellerContact
     */
    public void setSellerContact(org.apache.axis.types.UnsignedByte sellerContact) {
        this.sellerContact = sellerContact;
    }


    /**
     * Gets the transactionQuality value for this Feedback.
     * 
     * @return transactionQuality
     */
    public org.apache.axis.types.UnsignedByte getTransactionQuality() {
        return transactionQuality;
    }


    /**
     * Sets the transactionQuality value for this Feedback.
     * 
     * @param transactionQuality
     */
    public void setTransactionQuality(org.apache.axis.types.UnsignedByte transactionQuality) {
        this.transactionQuality = transactionQuality;
    }


    /**
     * Gets the transportAndBoxing value for this Feedback.
     * 
     * @return transportAndBoxing
     */
    public org.apache.axis.types.UnsignedByte getTransportAndBoxing() {
        return transportAndBoxing;
    }


    /**
     * Sets the transportAndBoxing value for this Feedback.
     * 
     * @param transportAndBoxing
     */
    public void setTransportAndBoxing(org.apache.axis.types.UnsignedByte transportAndBoxing) {
        this.transportAndBoxing = transportAndBoxing;
    }


    /**
     * Gets the userOrder value for this Feedback.
     * 
     * @return userOrder
     */
    public com.booktera.data.CommonModels_Models_EntityFramework.UserOrder getUserOrder() {
        return userOrder;
    }


    /**
     * Sets the userOrder value for this Feedback.
     * 
     * @param userOrder
     */
    public void setUserOrder(com.booktera.data.CommonModels_Models_EntityFramework.UserOrder userOrder) {
        this.userOrder = userOrder;
    }


    /**
     * Gets the userOrderID value for this Feedback.
     * 
     * @return userOrderID
     */
    public java.lang.Integer getUserOrderID() {
        return userOrderID;
    }


    /**
     * Sets the userOrderID value for this Feedback.
     * 
     * @param userOrderID
     */
    public void setUserOrderID(java.lang.Integer userOrderID) {
        this.userOrderID = userOrderID;
    }


    /**
     * Gets the wasSuccessful value for this Feedback.
     * 
     * @return wasSuccessful
     */
    public java.lang.Boolean getWasSuccessful() {
        return wasSuccessful;
    }


    /**
     * Sets the wasSuccessful value for this Feedback.
     * 
     * @param wasSuccessful
     */
    public void setWasSuccessful(java.lang.Boolean wasSuccessful) {
        this.wasSuccessful = wasSuccessful;
    }

    private java.lang.Object __equalsCalc = null;
    public synchronized boolean equals(java.lang.Object obj) {
        if (!(obj instanceof Feedback)) return false;
        Feedback other = (Feedback) obj;
        if (obj == null) return false;
        if (this == obj) return true;
        if (__equalsCalc != null) {
            return (__equalsCalc == obj);
        }
        __equalsCalc = obj;
        boolean _equals;
        _equals = true && 
            ((this.date==null && other.getDate()==null) || 
             (this.date!=null &&
              this.date.equals(other.getDate()))) &&
            ((this.description==null && other.getDescription()==null) || 
             (this.description!=null &&
              this.description.equals(other.getDescription()))) &&
            ((this.ID==null && other.getID()==null) || 
             (this.ID!=null &&
              this.ID.equals(other.getID()))) &&
            ((this.isCustomers==null && other.getIsCustomers()==null) || 
             (this.isCustomers!=null &&
              this.isCustomers.equals(other.getIsCustomers()))) &&
            ((this.isPositive==null && other.getIsPositive()==null) || 
             (this.isPositive!=null &&
              this.isPositive.equals(other.getIsPositive()))) &&
            ((this.productsQuality==null && other.getProductsQuality()==null) || 
             (this.productsQuality!=null &&
              this.productsQuality.equals(other.getProductsQuality()))) &&
            ((this.rateGiverUser==null && other.getRateGiverUser()==null) || 
             (this.rateGiverUser!=null &&
              this.rateGiverUser.equals(other.getRateGiverUser()))) &&
            ((this.rateGiverUserID==null && other.getRateGiverUserID()==null) || 
             (this.rateGiverUserID!=null &&
              this.rateGiverUserID.equals(other.getRateGiverUserID()))) &&
            ((this.ratedUser==null && other.getRatedUser()==null) || 
             (this.ratedUser!=null &&
              this.ratedUser.equals(other.getRatedUser()))) &&
            ((this.ratedUserID==null && other.getRatedUserID()==null) || 
             (this.ratedUserID!=null &&
              this.ratedUserID.equals(other.getRatedUserID()))) &&
            ((this.sellerContact==null && other.getSellerContact()==null) || 
             (this.sellerContact!=null &&
              this.sellerContact.equals(other.getSellerContact()))) &&
            ((this.transactionQuality==null && other.getTransactionQuality()==null) || 
             (this.transactionQuality!=null &&
              this.transactionQuality.equals(other.getTransactionQuality()))) &&
            ((this.transportAndBoxing==null && other.getTransportAndBoxing()==null) || 
             (this.transportAndBoxing!=null &&
              this.transportAndBoxing.equals(other.getTransportAndBoxing()))) &&
            ((this.userOrder==null && other.getUserOrder()==null) || 
             (this.userOrder!=null &&
              this.userOrder.equals(other.getUserOrder()))) &&
            ((this.userOrderID==null && other.getUserOrderID()==null) || 
             (this.userOrderID!=null &&
              this.userOrderID.equals(other.getUserOrderID()))) &&
            ((this.wasSuccessful==null && other.getWasSuccessful()==null) || 
             (this.wasSuccessful!=null &&
              this.wasSuccessful.equals(other.getWasSuccessful())));
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
        if (getDate() != null) {
            _hashCode += getDate().hashCode();
        }
        if (getDescription() != null) {
            _hashCode += getDescription().hashCode();
        }
        if (getID() != null) {
            _hashCode += getID().hashCode();
        }
        if (getIsCustomers() != null) {
            _hashCode += getIsCustomers().hashCode();
        }
        if (getIsPositive() != null) {
            _hashCode += getIsPositive().hashCode();
        }
        if (getProductsQuality() != null) {
            _hashCode += getProductsQuality().hashCode();
        }
        if (getRateGiverUser() != null) {
            _hashCode += getRateGiverUser().hashCode();
        }
        if (getRateGiverUserID() != null) {
            _hashCode += getRateGiverUserID().hashCode();
        }
        if (getRatedUser() != null) {
            _hashCode += getRatedUser().hashCode();
        }
        if (getRatedUserID() != null) {
            _hashCode += getRatedUserID().hashCode();
        }
        if (getSellerContact() != null) {
            _hashCode += getSellerContact().hashCode();
        }
        if (getTransactionQuality() != null) {
            _hashCode += getTransactionQuality().hashCode();
        }
        if (getTransportAndBoxing() != null) {
            _hashCode += getTransportAndBoxing().hashCode();
        }
        if (getUserOrder() != null) {
            _hashCode += getUserOrder().hashCode();
        }
        if (getUserOrderID() != null) {
            _hashCode += getUserOrderID().hashCode();
        }
        if (getWasSuccessful() != null) {
            _hashCode += getWasSuccessful().hashCode();
        }
        __hashCodeCalc = false;
        return _hashCode;
    }

    // Type metadata
    private static org.apache.axis.description.TypeDesc typeDesc =
        new org.apache.axis.description.TypeDesc(Feedback.class, true);

    static {
        typeDesc.setXmlType(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "Feedback"));
        org.apache.axis.description.ElementDesc elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("date");
        elemField.setXmlName(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "Date"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "dateTime"));
        elemField.setMinOccurs(0);
        elemField.setNillable(false);
        typeDesc.addFieldDesc(elemField);
        elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("description");
        elemField.setXmlName(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "Description"));
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
        elemField.setFieldName("isCustomers");
        elemField.setXmlName(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "IsCustomers"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "boolean"));
        elemField.setMinOccurs(0);
        elemField.setNillable(false);
        typeDesc.addFieldDesc(elemField);
        elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("isPositive");
        elemField.setXmlName(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "IsPositive"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "boolean"));
        elemField.setMinOccurs(0);
        elemField.setNillable(true);
        typeDesc.addFieldDesc(elemField);
        elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("productsQuality");
        elemField.setXmlName(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "ProductsQuality"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "unsignedByte"));
        elemField.setMinOccurs(0);
        elemField.setNillable(false);
        typeDesc.addFieldDesc(elemField);
        elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("rateGiverUser");
        elemField.setXmlName(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "RateGiverUser"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "UserProfile"));
        elemField.setMinOccurs(0);
        elemField.setNillable(true);
        typeDesc.addFieldDesc(elemField);
        elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("rateGiverUserID");
        elemField.setXmlName(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "RateGiverUserID"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "int"));
        elemField.setMinOccurs(0);
        elemField.setNillable(false);
        typeDesc.addFieldDesc(elemField);
        elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("ratedUser");
        elemField.setXmlName(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "RatedUser"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "UserProfile"));
        elemField.setMinOccurs(0);
        elemField.setNillable(true);
        typeDesc.addFieldDesc(elemField);
        elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("ratedUserID");
        elemField.setXmlName(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "RatedUserID"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "int"));
        elemField.setMinOccurs(0);
        elemField.setNillable(false);
        typeDesc.addFieldDesc(elemField);
        elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("sellerContact");
        elemField.setXmlName(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "SellerContact"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "unsignedByte"));
        elemField.setMinOccurs(0);
        elemField.setNillable(false);
        typeDesc.addFieldDesc(elemField);
        elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("transactionQuality");
        elemField.setXmlName(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "TransactionQuality"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "unsignedByte"));
        elemField.setMinOccurs(0);
        elemField.setNillable(false);
        typeDesc.addFieldDesc(elemField);
        elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("transportAndBoxing");
        elemField.setXmlName(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "TransportAndBoxing"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "unsignedByte"));
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
        elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("wasSuccessful");
        elemField.setXmlName(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "WasSuccessful"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "boolean"));
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
