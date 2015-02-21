/**
 * InCategoryCWPLVM.java
 *
 * This file was auto-generated from WSDL
 * by the Apache Axis 1.4 Apr 22, 2006 (06:55:48 PDT) WSDL2Java emitter.
 */

package com.booktera.data.CommonPortable_Models_ProductModels;

public class InCategoryCWPLVM  implements java.io.Serializable {
    private com.booktera.data.CommonModels_Models_EntityFramework.Category baseCategory;

    private com.booktera.data.CommonPortable_Models_ProductModels.InCategoryPLVM[] childCategoriesWithProducts;

    public InCategoryCWPLVM() {
    }

    public InCategoryCWPLVM(
           com.booktera.data.CommonModels_Models_EntityFramework.Category baseCategory,
           com.booktera.data.CommonPortable_Models_ProductModels.InCategoryPLVM[] childCategoriesWithProducts) {
           this.baseCategory = baseCategory;
           this.childCategoriesWithProducts = childCategoriesWithProducts;
    }


    /**
     * Gets the baseCategory value for this InCategoryCWPLVM.
     * 
     * @return baseCategory
     */
    public com.booktera.data.CommonModels_Models_EntityFramework.Category getBaseCategory() {
        return baseCategory;
    }


    /**
     * Sets the baseCategory value for this InCategoryCWPLVM.
     * 
     * @param baseCategory
     */
    public void setBaseCategory(com.booktera.data.CommonModels_Models_EntityFramework.Category baseCategory) {
        this.baseCategory = baseCategory;
    }


    /**
     * Gets the childCategoriesWithProducts value for this InCategoryCWPLVM.
     * 
     * @return childCategoriesWithProducts
     */
    public com.booktera.data.CommonPortable_Models_ProductModels.InCategoryPLVM[] getChildCategoriesWithProducts() {
        return childCategoriesWithProducts;
    }


    /**
     * Sets the childCategoriesWithProducts value for this InCategoryCWPLVM.
     * 
     * @param childCategoriesWithProducts
     */
    public void setChildCategoriesWithProducts(com.booktera.data.CommonPortable_Models_ProductModels.InCategoryPLVM[] childCategoriesWithProducts) {
        this.childCategoriesWithProducts = childCategoriesWithProducts;
    }

    private java.lang.Object __equalsCalc = null;
    public synchronized boolean equals(java.lang.Object obj) {
        if (!(obj instanceof InCategoryCWPLVM)) return false;
        InCategoryCWPLVM other = (InCategoryCWPLVM) obj;
        if (obj == null) return false;
        if (this == obj) return true;
        if (__equalsCalc != null) {
            return (__equalsCalc == obj);
        }
        __equalsCalc = obj;
        boolean _equals;
        _equals = true && 
            ((this.baseCategory==null && other.getBaseCategory()==null) || 
             (this.baseCategory!=null &&
              this.baseCategory.equals(other.getBaseCategory()))) &&
            ((this.childCategoriesWithProducts==null && other.getChildCategoriesWithProducts()==null) || 
             (this.childCategoriesWithProducts!=null &&
              java.util.Arrays.equals(this.childCategoriesWithProducts, other.getChildCategoriesWithProducts())));
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
        if (getBaseCategory() != null) {
            _hashCode += getBaseCategory().hashCode();
        }
        if (getChildCategoriesWithProducts() != null) {
            for (int i=0;
                 i<java.lang.reflect.Array.getLength(getChildCategoriesWithProducts());
                 i++) {
                java.lang.Object obj = java.lang.reflect.Array.get(getChildCategoriesWithProducts(), i);
                if (obj != null &&
                    !obj.getClass().isArray()) {
                    _hashCode += obj.hashCode();
                }
            }
        }
        __hashCodeCalc = false;
        return _hashCode;
    }

    // Type metadata
    private static org.apache.axis.description.TypeDesc typeDesc =
        new org.apache.axis.description.TypeDesc(InCategoryCWPLVM.class, true);

    static {
        typeDesc.setXmlType(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonPortable.Models.ProductModels", "InCategoryCWPLVM"));
        org.apache.axis.description.ElementDesc elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("baseCategory");
        elemField.setXmlName(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonPortable.Models.ProductModels", "BaseCategory"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "Category"));
        elemField.setMinOccurs(0);
        elemField.setNillable(true);
        typeDesc.addFieldDesc(elemField);
        elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("childCategoriesWithProducts");
        elemField.setXmlName(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonPortable.Models.ProductModels", "ChildCategoriesWithProducts"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonPortable.Models.ProductModels", "InCategoryPLVM"));
        elemField.setMinOccurs(0);
        elemField.setNillable(true);
        elemField.setItemQName(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonPortable.Models.ProductModels", "InCategoryPLVM"));
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
