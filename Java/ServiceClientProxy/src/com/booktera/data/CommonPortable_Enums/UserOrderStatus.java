/**
 * UserOrderStatus.java
 *
 * This file was auto-generated from WSDL
 * by the Apache Axis 1.4 Apr 22, 2006 (06:55:48 PDT) WSDL2Java emitter.
 */

package com.booktera.data.CommonPortable_Enums;

public class UserOrderStatus implements java.io.Serializable {
    private java.lang.String _value_;
    private static java.util.HashMap _table_ = new java.util.HashMap();

    // Constructor
    protected UserOrderStatus(java.lang.String value) {
        _value_ = value;
        _table_.put(_value_,this);
    }

    public static final java.lang.String _Nincs = "Nincs";
    public static final java.lang.String _Cart = "Cart";
    public static final java.lang.String _BuyedWaiting = "BuyedWaiting";
    public static final java.lang.String _BuyedExchangeOffered = "BuyedExchangeOffered";
    public static final java.lang.String _FinalizedExchange = "FinalizedExchange";
    public static final java.lang.String _FinalizedCash = "FinalizedCash";
    public static final java.lang.String _Finished = "Finished";
    public static final java.lang.String _CartDeleting = "CartDeleting";
    public static final UserOrderStatus Nincs = new UserOrderStatus(_Nincs);
    public static final UserOrderStatus Cart = new UserOrderStatus(_Cart);
    public static final UserOrderStatus BuyedWaiting = new UserOrderStatus(_BuyedWaiting);
    public static final UserOrderStatus BuyedExchangeOffered = new UserOrderStatus(_BuyedExchangeOffered);
    public static final UserOrderStatus FinalizedExchange = new UserOrderStatus(_FinalizedExchange);
    public static final UserOrderStatus FinalizedCash = new UserOrderStatus(_FinalizedCash);
    public static final UserOrderStatus Finished = new UserOrderStatus(_Finished);
    public static final UserOrderStatus CartDeleting = new UserOrderStatus(_CartDeleting);
    public java.lang.String getValue() { return _value_;}
    public static UserOrderStatus fromValue(java.lang.String value)
          throws java.lang.IllegalArgumentException {
        UserOrderStatus enumeration = (UserOrderStatus)
            _table_.get(value);
        if (enumeration==null) throw new java.lang.IllegalArgumentException();
        return enumeration;
    }
    public static UserOrderStatus fromString(java.lang.String value)
          throws java.lang.IllegalArgumentException {
        return fromValue(value);
    }
    public boolean equals(java.lang.Object obj) {return (obj == this);}
    public int hashCode() { return toString().hashCode();}
    public java.lang.String toString() { return _value_;}
    public java.lang.Object readResolve() throws java.io.ObjectStreamException { return fromValue(_value_);}
    public static org.apache.axis.encoding.Serializer getSerializer(
           java.lang.String mechType, 
           java.lang.Class _javaType,  
           javax.xml.namespace.QName _xmlType) {
        return 
          new org.apache.axis.encoding.ser.EnumSerializer(
            _javaType, _xmlType);
    }
    public static org.apache.axis.encoding.Deserializer getDeserializer(
           java.lang.String mechType, 
           java.lang.Class _javaType,  
           javax.xml.namespace.QName _xmlType) {
        return 
          new org.apache.axis.encoding.ser.EnumDeserializer(
            _javaType, _xmlType);
    }
    // Type metadata
    private static org.apache.axis.description.TypeDesc typeDesc =
        new org.apache.axis.description.TypeDesc(UserOrderStatus.class);

    static {
        typeDesc.setXmlType(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonPortable.Enums", "UserOrderStatus"));
    }
    /**
     * Return type metadata object
     */
    public static org.apache.axis.description.TypeDesc getTypeDesc() {
        return typeDesc;
    }

}
