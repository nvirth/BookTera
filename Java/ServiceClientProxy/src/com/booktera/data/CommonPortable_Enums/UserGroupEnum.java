/**
 * UserGroupEnum.java
 *
 * This file was auto-generated from WSDL
 * by the Apache Axis 1.4 Apr 22, 2006 (06:55:48 PDT) WSDL2Java emitter.
 */

package com.booktera.data.CommonPortable_Enums;

public class UserGroupEnum implements java.io.Serializable {
    private java.lang.String _value_;
    private static java.util.HashMap _table_ = new java.util.HashMap();

    // Constructor
    protected UserGroupEnum(java.lang.String value) {
        _value_ = value;
        _table_.put(_value_,this);
    }

    public static final java.lang.String _Nincs = "Nincs";
    public static final java.lang.String _Leech = "Leech";
    public static final java.lang.String _Seed = "Seed";
    public static final java.lang.String _SeedPlus = "SeedPlus";
    public static final java.lang.String _Author = "Author";
    public static final java.lang.String _Publisher = "Publisher";
    public static final UserGroupEnum Nincs = new UserGroupEnum(_Nincs);
    public static final UserGroupEnum Leech = new UserGroupEnum(_Leech);
    public static final UserGroupEnum Seed = new UserGroupEnum(_Seed);
    public static final UserGroupEnum SeedPlus = new UserGroupEnum(_SeedPlus);
    public static final UserGroupEnum Author = new UserGroupEnum(_Author);
    public static final UserGroupEnum Publisher = new UserGroupEnum(_Publisher);
    public java.lang.String getValue() { return _value_;}
    public static UserGroupEnum fromValue(java.lang.String value)
          throws java.lang.IllegalArgumentException {
        UserGroupEnum enumeration = (UserGroupEnum)
            _table_.get(value);
        if (enumeration==null) throw new java.lang.IllegalArgumentException();
        return enumeration;
    }
    public static UserGroupEnum fromString(java.lang.String value)
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
        new org.apache.axis.description.TypeDesc(UserGroupEnum.class);

    static {
        typeDesc.setXmlType(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonPortable.Enums", "UserGroupEnum"));
    }
    /**
     * Return type metadata object
     */
    public static org.apache.axis.description.TypeDesc getTypeDesc() {
        return typeDesc;
    }

}
