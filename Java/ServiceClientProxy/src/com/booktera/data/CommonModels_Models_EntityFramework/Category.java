/**
 * Category.java
 *
 * This file was auto-generated from WSDL
 * by the Apache Axis 1.4 Apr 22, 2006 (06:55:48 PDT) WSDL2Java emitter.
 */

package com.booktera.data.CommonModels_Models_EntityFramework;

public class Category  implements java.io.Serializable {
    private com.booktera.data.CommonModels_Models_EntityFramework.Category[] childCategories;

    private java.lang.String displayName;

    private java.lang.String friendlyUrl;

    private java.lang.String fullPath;

    private java.lang.Integer ID;

    private java.lang.Boolean isParent;

    private com.booktera.data.CommonModels_Models_EntityFramework.Category parentCategory;

    private java.lang.Integer parentCategoryID;

    private com.booktera.data.CommonModels_Models_EntityFramework.ProductGroup[] productGroupsInCategory;

    private java.lang.String sort;

    public Category() {
    }

    public Category(
           com.booktera.data.CommonModels_Models_EntityFramework.Category[] childCategories,
           java.lang.String displayName,
           java.lang.String friendlyUrl,
           java.lang.String fullPath,
           java.lang.Integer ID,
           java.lang.Boolean isParent,
           com.booktera.data.CommonModels_Models_EntityFramework.Category parentCategory,
           java.lang.Integer parentCategoryID,
           com.booktera.data.CommonModels_Models_EntityFramework.ProductGroup[] productGroupsInCategory,
           java.lang.String sort) {
           this.childCategories = childCategories;
           this.displayName = displayName;
           this.friendlyUrl = friendlyUrl;
           this.fullPath = fullPath;
           this.ID = ID;
           this.isParent = isParent;
           this.parentCategory = parentCategory;
           this.parentCategoryID = parentCategoryID;
           this.productGroupsInCategory = productGroupsInCategory;
           this.sort = sort;
    }


    /**
     * Gets the childCategories value for this Category.
     * 
     * @return childCategories
     */
    public com.booktera.data.CommonModels_Models_EntityFramework.Category[] getChildCategories() {
        return childCategories;
    }


    /**
     * Sets the childCategories value for this Category.
     * 
     * @param childCategories
     */
    public void setChildCategories(com.booktera.data.CommonModels_Models_EntityFramework.Category[] childCategories) {
        this.childCategories = childCategories;
    }


    /**
     * Gets the displayName value for this Category.
     * 
     * @return displayName
     */
    public java.lang.String getDisplayName() {
        return displayName;
    }


    /**
     * Sets the displayName value for this Category.
     * 
     * @param displayName
     */
    public void setDisplayName(java.lang.String displayName) {
        this.displayName = displayName;
    }


    /**
     * Gets the friendlyUrl value for this Category.
     * 
     * @return friendlyUrl
     */
    public java.lang.String getFriendlyUrl() {
        return friendlyUrl;
    }


    /**
     * Sets the friendlyUrl value for this Category.
     * 
     * @param friendlyUrl
     */
    public void setFriendlyUrl(java.lang.String friendlyUrl) {
        this.friendlyUrl = friendlyUrl;
    }


    /**
     * Gets the fullPath value for this Category.
     * 
     * @return fullPath
     */
    public java.lang.String getFullPath() {
        return fullPath;
    }


    /**
     * Sets the fullPath value for this Category.
     * 
     * @param fullPath
     */
    public void setFullPath(java.lang.String fullPath) {
        this.fullPath = fullPath;
    }


    /**
     * Gets the ID value for this Category.
     * 
     * @return ID
     */
    public java.lang.Integer getID() {
        return ID;
    }


    /**
     * Sets the ID value for this Category.
     * 
     * @param ID
     */
    public void setID(java.lang.Integer ID) {
        this.ID = ID;
    }


    /**
     * Gets the isParent value for this Category.
     * 
     * @return isParent
     */
    public java.lang.Boolean getIsParent() {
        return isParent;
    }


    /**
     * Sets the isParent value for this Category.
     * 
     * @param isParent
     */
    public void setIsParent(java.lang.Boolean isParent) {
        this.isParent = isParent;
    }


    /**
     * Gets the parentCategory value for this Category.
     * 
     * @return parentCategory
     */
    public com.booktera.data.CommonModels_Models_EntityFramework.Category getParentCategory() {
        return parentCategory;
    }


    /**
     * Sets the parentCategory value for this Category.
     * 
     * @param parentCategory
     */
    public void setParentCategory(com.booktera.data.CommonModels_Models_EntityFramework.Category parentCategory) {
        this.parentCategory = parentCategory;
    }


    /**
     * Gets the parentCategoryID value for this Category.
     * 
     * @return parentCategoryID
     */
    public java.lang.Integer getParentCategoryID() {
        return parentCategoryID;
    }


    /**
     * Sets the parentCategoryID value for this Category.
     * 
     * @param parentCategoryID
     */
    public void setParentCategoryID(java.lang.Integer parentCategoryID) {
        this.parentCategoryID = parentCategoryID;
    }


    /**
     * Gets the productGroupsInCategory value for this Category.
     * 
     * @return productGroupsInCategory
     */
    public com.booktera.data.CommonModels_Models_EntityFramework.ProductGroup[] getProductGroupsInCategory() {
        return productGroupsInCategory;
    }


    /**
     * Sets the productGroupsInCategory value for this Category.
     * 
     * @param productGroupsInCategory
     */
    public void setProductGroupsInCategory(com.booktera.data.CommonModels_Models_EntityFramework.ProductGroup[] productGroupsInCategory) {
        this.productGroupsInCategory = productGroupsInCategory;
    }


    /**
     * Gets the sort value for this Category.
     * 
     * @return sort
     */
    public java.lang.String getSort() {
        return sort;
    }


    /**
     * Sets the sort value for this Category.
     * 
     * @param sort
     */
    public void setSort(java.lang.String sort) {
        this.sort = sort;
    }

    private java.lang.Object __equalsCalc = null;
    public synchronized boolean equals(java.lang.Object obj) {
        if (!(obj instanceof Category)) return false;
        Category other = (Category) obj;
        if (obj == null) return false;
        if (this == obj) return true;
        if (__equalsCalc != null) {
            return (__equalsCalc == obj);
        }
        __equalsCalc = obj;
        boolean _equals;
        _equals = true && 
            ((this.childCategories==null && other.getChildCategories()==null) || 
             (this.childCategories!=null &&
              java.util.Arrays.equals(this.childCategories, other.getChildCategories()))) &&
            ((this.displayName==null && other.getDisplayName()==null) || 
             (this.displayName!=null &&
              this.displayName.equals(other.getDisplayName()))) &&
            ((this.friendlyUrl==null && other.getFriendlyUrl()==null) || 
             (this.friendlyUrl!=null &&
              this.friendlyUrl.equals(other.getFriendlyUrl()))) &&
            ((this.fullPath==null && other.getFullPath()==null) || 
             (this.fullPath!=null &&
              this.fullPath.equals(other.getFullPath()))) &&
            ((this.ID==null && other.getID()==null) || 
             (this.ID!=null &&
              this.ID.equals(other.getID()))) &&
            ((this.isParent==null && other.getIsParent()==null) || 
             (this.isParent!=null &&
              this.isParent.equals(other.getIsParent()))) &&
            ((this.parentCategory==null && other.getParentCategory()==null) || 
             (this.parentCategory!=null &&
              this.parentCategory.equals(other.getParentCategory()))) &&
            ((this.parentCategoryID==null && other.getParentCategoryID()==null) || 
             (this.parentCategoryID!=null &&
              this.parentCategoryID.equals(other.getParentCategoryID()))) &&
            ((this.productGroupsInCategory==null && other.getProductGroupsInCategory()==null) || 
             (this.productGroupsInCategory!=null &&
              java.util.Arrays.equals(this.productGroupsInCategory, other.getProductGroupsInCategory()))) &&
            ((this.sort==null && other.getSort()==null) || 
             (this.sort!=null &&
              this.sort.equals(other.getSort())));
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
        if (getChildCategories() != null) {
            for (int i=0;
                 i<java.lang.reflect.Array.getLength(getChildCategories());
                 i++) {
                java.lang.Object obj = java.lang.reflect.Array.get(getChildCategories(), i);
                if (obj != null &&
                    !obj.getClass().isArray()) {
                    _hashCode += obj.hashCode();
                }
            }
        }
        if (getDisplayName() != null) {
            _hashCode += getDisplayName().hashCode();
        }
        if (getFriendlyUrl() != null) {
            _hashCode += getFriendlyUrl().hashCode();
        }
        if (getFullPath() != null) {
            _hashCode += getFullPath().hashCode();
        }
        if (getID() != null) {
            _hashCode += getID().hashCode();
        }
        if (getIsParent() != null) {
            _hashCode += getIsParent().hashCode();
        }
        if (getParentCategory() != null) {
            _hashCode += getParentCategory().hashCode();
        }
        if (getParentCategoryID() != null) {
            _hashCode += getParentCategoryID().hashCode();
        }
        if (getProductGroupsInCategory() != null) {
            for (int i=0;
                 i<java.lang.reflect.Array.getLength(getProductGroupsInCategory());
                 i++) {
                java.lang.Object obj = java.lang.reflect.Array.get(getProductGroupsInCategory(), i);
                if (obj != null &&
                    !obj.getClass().isArray()) {
                    _hashCode += obj.hashCode();
                }
            }
        }
        if (getSort() != null) {
            _hashCode += getSort().hashCode();
        }
        __hashCodeCalc = false;
        return _hashCode;
    }

    // Type metadata
    private static org.apache.axis.description.TypeDesc typeDesc =
        new org.apache.axis.description.TypeDesc(Category.class, true);

    static {
        typeDesc.setXmlType(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "Category"));
        org.apache.axis.description.ElementDesc elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("childCategories");
        elemField.setXmlName(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "ChildCategories"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "Category"));
        elemField.setMinOccurs(0);
        elemField.setNillable(true);
        elemField.setItemQName(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "Category"));
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
        elemField.setFieldName("fullPath");
        elemField.setXmlName(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "FullPath"));
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
        elemField.setFieldName("isParent");
        elemField.setXmlName(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "IsParent"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "boolean"));
        elemField.setMinOccurs(0);
        elemField.setNillable(false);
        typeDesc.addFieldDesc(elemField);
        elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("parentCategory");
        elemField.setXmlName(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "ParentCategory"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "Category"));
        elemField.setMinOccurs(0);
        elemField.setNillable(true);
        typeDesc.addFieldDesc(elemField);
        elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("parentCategoryID");
        elemField.setXmlName(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "ParentCategoryID"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "int"));
        elemField.setMinOccurs(0);
        elemField.setNillable(true);
        typeDesc.addFieldDesc(elemField);
        elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("productGroupsInCategory");
        elemField.setXmlName(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "ProductGroupsInCategory"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "ProductGroup"));
        elemField.setMinOccurs(0);
        elemField.setNillable(true);
        elemField.setItemQName(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "ProductGroup"));
        typeDesc.addFieldDesc(elemField);
        elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("sort");
        elemField.setXmlName(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "Sort"));
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
