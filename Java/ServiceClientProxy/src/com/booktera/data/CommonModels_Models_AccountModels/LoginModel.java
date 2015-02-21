/**
 * LoginModel.java
 *
 * This file was auto-generated from WSDL
 * by the Apache Axis 1.4 Apr 22, 2006 (06:55:48 PDT) WSDL2Java emitter.
 */

package com.booktera.data.CommonModels_Models_AccountModels;

public class LoginModel  implements java.io.Serializable {
    private java.lang.String loginPassword;

    private java.lang.String loginUserName;

    private java.lang.Boolean rememberMe;

    public LoginModel() {
    }

    public LoginModel(
           java.lang.String loginPassword,
           java.lang.String loginUserName,
           java.lang.Boolean rememberMe) {
           this.loginPassword = loginPassword;
           this.loginUserName = loginUserName;
           this.rememberMe = rememberMe;
    }


    /**
     * Gets the loginPassword value for this LoginModel.
     * 
     * @return loginPassword
     */
    public java.lang.String getLoginPassword() {
        return loginPassword;
    }


    /**
     * Sets the loginPassword value for this LoginModel.
     * 
     * @param loginPassword
     */
    public void setLoginPassword(java.lang.String loginPassword) {
        this.loginPassword = loginPassword;
    }


    /**
     * Gets the loginUserName value for this LoginModel.
     * 
     * @return loginUserName
     */
    public java.lang.String getLoginUserName() {
        return loginUserName;
    }


    /**
     * Sets the loginUserName value for this LoginModel.
     * 
     * @param loginUserName
     */
    public void setLoginUserName(java.lang.String loginUserName) {
        this.loginUserName = loginUserName;
    }


    /**
     * Gets the rememberMe value for this LoginModel.
     * 
     * @return rememberMe
     */
    public java.lang.Boolean getRememberMe() {
        return rememberMe;
    }


    /**
     * Sets the rememberMe value for this LoginModel.
     * 
     * @param rememberMe
     */
    public void setRememberMe(java.lang.Boolean rememberMe) {
        this.rememberMe = rememberMe;
    }

    private java.lang.Object __equalsCalc = null;
    public synchronized boolean equals(java.lang.Object obj) {
        if (!(obj instanceof LoginModel)) return false;
        LoginModel other = (LoginModel) obj;
        if (obj == null) return false;
        if (this == obj) return true;
        if (__equalsCalc != null) {
            return (__equalsCalc == obj);
        }
        __equalsCalc = obj;
        boolean _equals;
        _equals = true && 
            ((this.loginPassword==null && other.getLoginPassword()==null) || 
             (this.loginPassword!=null &&
              this.loginPassword.equals(other.getLoginPassword()))) &&
            ((this.loginUserName==null && other.getLoginUserName()==null) || 
             (this.loginUserName!=null &&
              this.loginUserName.equals(other.getLoginUserName()))) &&
            ((this.rememberMe==null && other.getRememberMe()==null) || 
             (this.rememberMe!=null &&
              this.rememberMe.equals(other.getRememberMe())));
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
        if (getLoginPassword() != null) {
            _hashCode += getLoginPassword().hashCode();
        }
        if (getLoginUserName() != null) {
            _hashCode += getLoginUserName().hashCode();
        }
        if (getRememberMe() != null) {
            _hashCode += getRememberMe().hashCode();
        }
        __hashCodeCalc = false;
        return _hashCode;
    }

    // Type metadata
    private static org.apache.axis.description.TypeDesc typeDesc =
        new org.apache.axis.description.TypeDesc(LoginModel.class, true);

    static {
        typeDesc.setXmlType(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.AccountModels", "LoginModel"));
        org.apache.axis.description.ElementDesc elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("loginPassword");
        elemField.setXmlName(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.AccountModels", "LoginPassword"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "string"));
        elemField.setMinOccurs(0);
        elemField.setNillable(true);
        typeDesc.addFieldDesc(elemField);
        elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("loginUserName");
        elemField.setXmlName(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.AccountModels", "LoginUserName"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "string"));
        elemField.setMinOccurs(0);
        elemField.setNillable(true);
        typeDesc.addFieldDesc(elemField);
        elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("rememberMe");
        elemField.setXmlName(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.AccountModels", "RememberMe"));
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
