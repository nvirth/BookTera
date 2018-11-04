/**
 * CategoryBasicStub.java
 *
 * This file was auto-generated from WSDL
 * by the Apache Axis 1.4 Apr 22, 2006 (06:55:48 PDT) WSDL2Java emitter.
 */

package com.booktera.services.EntityManagers.CategoryManager;

public class CategoryBasicStub extends org.apache.axis.client.Stub implements com.booktera.services.EntityManagers.CategoryManager.ICategoryManager {
    private java.util.Vector cachedSerClasses = new java.util.Vector();
    private java.util.Vector cachedSerQNames = new java.util.Vector();
    private java.util.Vector cachedSerFactories = new java.util.Vector();
    private java.util.Vector cachedDeserFactories = new java.util.Vector();

    static org.apache.axis.description.OperationDesc [] _operations;

    static {
        _operations = new org.apache.axis.description.OperationDesc[3];
        _initOperationDesc1();
    }

    private static void _initOperationDesc1(){
        org.apache.axis.description.OperationDesc oper;
        org.apache.axis.description.ParameterDesc param;
        oper = new org.apache.axis.description.OperationDesc();
        oper.setName("GetAllForMenu");
        param = new org.apache.axis.description.ParameterDesc(new javax.xml.namespace.QName("http://tempuri.org/", "selected"), org.apache.axis.description.ParameterDesc.IN, new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "string"), java.lang.String.class, false, false);
        param.setOmittable(true);
        param.setNillable(true);
        oper.addParameter(param);
        param = new org.apache.axis.description.ParameterDesc(new javax.xml.namespace.QName("http://tempuri.org/", "openedIds"), org.apache.axis.description.ParameterDesc.IN, new javax.xml.namespace.QName("http://schemas.microsoft.com/2003/10/Serialization/Arrays", "ArrayOfstring"), java.lang.String[].class, false, false);
        param.setItemQName(new javax.xml.namespace.QName("http://schemas.microsoft.com/2003/10/Serialization/Arrays", "string"));
        param.setOmittable(true);
        param.setNillable(true);
        oper.addParameter(param);
        oper.setReturnType(new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "string"));
        oper.setReturnClass(java.lang.String.class);
        oper.setReturnQName(new javax.xml.namespace.QName("http://tempuri.org/", "GetAllForMenuResult"));
        oper.setStyle(org.apache.axis.constants.Style.WRAPPED);
        oper.setUse(org.apache.axis.constants.Use.LITERAL);
        _operations[0] = oper;

        oper = new org.apache.axis.description.OperationDesc();
        oper.setName("GetAllSortedJson");
        param = new org.apache.axis.description.ParameterDesc(new javax.xml.namespace.QName("http://tempuri.org/", "selectedCategoryId"), org.apache.axis.description.ParameterDesc.IN, new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "int"), java.lang.Integer.class, false, false);
        param.setOmittable(true);
        param.setNillable(true);
        oper.addParameter(param);
        oper.setReturnType(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/UtilsShared", "ArrayOfSelectListItemWithClass"));
        oper.setReturnClass(com.booktera.data.UtilsShared.SelectListItemWithClass[].class);
        oper.setReturnQName(new javax.xml.namespace.QName("http://tempuri.org/", "GetAllSortedJsonResult"));
        param = oper.getReturnParamDesc();
        param.setItemQName(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/UtilsShared", "SelectListItemWithClass"));
        oper.setStyle(org.apache.axis.constants.Style.WRAPPED);
        oper.setUse(org.apache.axis.constants.Use.LITERAL);
        _operations[1] = oper;

        oper = new org.apache.axis.description.OperationDesc();
        oper.setName("GetCategoriesWithProductsInCategory");
        param = new org.apache.axis.description.ParameterDesc(new javax.xml.namespace.QName("http://tempuri.org/", "pageNumber"), org.apache.axis.description.ParameterDesc.IN, new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "int"), java.lang.Integer.class, false, false);
        param.setOmittable(true);
        oper.addParameter(param);
        param = new org.apache.axis.description.ParameterDesc(new javax.xml.namespace.QName("http://tempuri.org/", "productsPerPage"), org.apache.axis.description.ParameterDesc.IN, new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "int"), java.lang.Integer.class, false, false);
        param.setOmittable(true);
        oper.addParameter(param);
        param = new org.apache.axis.description.ParameterDesc(new javax.xml.namespace.QName("http://tempuri.org/", "baseCategoryFu"), org.apache.axis.description.ParameterDesc.IN, new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "string"), java.lang.String.class, false, false);
        param.setOmittable(true);
        param.setNillable(true);
        oper.addParameter(param);
        oper.setReturnType(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonPortable.Models.ProductModels", "InCategoryCWPLVM"));
        oper.setReturnClass(com.booktera.data.CommonPortable_Models_ProductModels.InCategoryCWPLVM.class);
        oper.setReturnQName(new javax.xml.namespace.QName("http://tempuri.org/", "GetCategoriesWithProductsInCategoryResult"));
        oper.setStyle(org.apache.axis.constants.Style.WRAPPED);
        oper.setUse(org.apache.axis.constants.Use.LITERAL);
        _operations[2] = oper;

    }

    public CategoryBasicStub() throws org.apache.axis.AxisFault {
         this(null);
    }

    public CategoryBasicStub(java.net.URL endpointURL, javax.xml.rpc.Service service) throws org.apache.axis.AxisFault {
         this(service);
         super.cachedEndpoint = endpointURL;
    }

    public CategoryBasicStub(javax.xml.rpc.Service service) throws org.apache.axis.AxisFault {
        if (service == null) {
            super.service = new org.apache.axis.client.Service();
        } else {
            super.service = service;
        }
        ((org.apache.axis.client.Service)super.service).setTypeMappingVersion("1.2");
            java.lang.Class cls;
            javax.xml.namespace.QName qName;
            javax.xml.namespace.QName qName2;
            java.lang.Class beansf = org.apache.axis.encoding.ser.BeanSerializerFactory.class;
            java.lang.Class beandf = org.apache.axis.encoding.ser.BeanDeserializerFactory.class;
            java.lang.Class enumsf = org.apache.axis.encoding.ser.EnumSerializerFactory.class;
            java.lang.Class enumdf = org.apache.axis.encoding.ser.EnumDeserializerFactory.class;
            java.lang.Class arraysf = org.apache.axis.encoding.ser.ArraySerializerFactory.class;
            java.lang.Class arraydf = org.apache.axis.encoding.ser.ArrayDeserializerFactory.class;
            java.lang.Class simplesf = org.apache.axis.encoding.ser.SimpleSerializerFactory.class;
            java.lang.Class simpledf = org.apache.axis.encoding.ser.SimpleDeserializerFactory.class;
            java.lang.Class simplelistsf = org.apache.axis.encoding.ser.SimpleListSerializerFactory.class;
            java.lang.Class simplelistdf = org.apache.axis.encoding.ser.SimpleListDeserializerFactory.class;
            qName = new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "ArrayOfAuthor");
            cachedSerQNames.add(qName);
            cls = com.booktera.data.CommonModels_Models_EntityFramework.Author[].class;
            cachedSerClasses.add(cls);
            qName = new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "Author");
            qName2 = new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "Author");
            cachedSerFactories.add(new org.apache.axis.encoding.ser.ArraySerializerFactory(qName, qName2));
            cachedDeserFactories.add(new org.apache.axis.encoding.ser.ArrayDeserializerFactory());

            qName = new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "ArrayOfCategory");
            cachedSerQNames.add(qName);
            cls = com.booktera.data.CommonModels_Models_EntityFramework.Category[].class;
            cachedSerClasses.add(cls);
            qName = new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "Category");
            qName2 = new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "Category");
            cachedSerFactories.add(new org.apache.axis.encoding.ser.ArraySerializerFactory(qName, qName2));
            cachedDeserFactories.add(new org.apache.axis.encoding.ser.ArrayDeserializerFactory());

            qName = new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "ArrayOfComment");
            cachedSerQNames.add(qName);
            cls = com.booktera.data.CommonModels_Models_EntityFramework.Comment[].class;
            cachedSerClasses.add(cls);
            qName = new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "Comment");
            qName2 = new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "Comment");
            cachedSerFactories.add(new org.apache.axis.encoding.ser.ArraySerializerFactory(qName, qName2));
            cachedDeserFactories.add(new org.apache.axis.encoding.ser.ArrayDeserializerFactory());

            qName = new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "ArrayOfFeedback");
            cachedSerQNames.add(qName);
            cls = com.booktera.data.CommonModels_Models_EntityFramework.Feedback[].class;
            cachedSerClasses.add(cls);
            qName = new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "Feedback");
            qName2 = new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "Feedback");
            cachedSerFactories.add(new org.apache.axis.encoding.ser.ArraySerializerFactory(qName, qName2));
            cachedDeserFactories.add(new org.apache.axis.encoding.ser.ArrayDeserializerFactory());

            qName = new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "ArrayOfHighlightedProduct");
            cachedSerQNames.add(qName);
            cls = com.booktera.data.CommonModels_Models_EntityFramework.HighlightedProduct[].class;
            cachedSerClasses.add(cls);
            qName = new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "HighlightedProduct");
            qName2 = new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "HighlightedProduct");
            cachedSerFactories.add(new org.apache.axis.encoding.ser.ArraySerializerFactory(qName, qName2));
            cachedDeserFactories.add(new org.apache.axis.encoding.ser.ArrayDeserializerFactory());

            qName = new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "ArrayOfImage");
            cachedSerQNames.add(qName);
            cls = com.booktera.data.CommonModels_Models_EntityFramework.Image[].class;
            cachedSerClasses.add(cls);
            qName = new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "Image");
            qName2 = new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "Image");
            cachedSerFactories.add(new org.apache.axis.encoding.ser.ArraySerializerFactory(qName, qName2));
            cachedDeserFactories.add(new org.apache.axis.encoding.ser.ArrayDeserializerFactory());

            qName = new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "ArrayOfProduct");
            cachedSerQNames.add(qName);
            cls = com.booktera.data.CommonModels_Models_EntityFramework.Product[].class;
            cachedSerClasses.add(cls);
            qName = new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "Product");
            qName2 = new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "Product");
            cachedSerFactories.add(new org.apache.axis.encoding.ser.ArraySerializerFactory(qName, qName2));
            cachedDeserFactories.add(new org.apache.axis.encoding.ser.ArrayDeserializerFactory());

            qName = new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "ArrayOfProductGroup");
            cachedSerQNames.add(qName);
            cls = com.booktera.data.CommonModels_Models_EntityFramework.ProductGroup[].class;
            cachedSerClasses.add(cls);
            qName = new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "ProductGroup");
            qName2 = new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "ProductGroup");
            cachedSerFactories.add(new org.apache.axis.encoding.ser.ArraySerializerFactory(qName, qName2));
            cachedDeserFactories.add(new org.apache.axis.encoding.ser.ArrayDeserializerFactory());

            qName = new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "ArrayOfProductInOrder");
            cachedSerQNames.add(qName);
            cls = com.booktera.data.CommonModels_Models_EntityFramework.ProductInOrder[].class;
            cachedSerClasses.add(cls);
            qName = new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "ProductInOrder");
            qName2 = new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "ProductInOrder");
            cachedSerFactories.add(new org.apache.axis.encoding.ser.ArraySerializerFactory(qName, qName2));
            cachedDeserFactories.add(new org.apache.axis.encoding.ser.ArrayDeserializerFactory());

            qName = new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "ArrayOfRating");
            cachedSerQNames.add(qName);
            cls = com.booktera.data.CommonModels_Models_EntityFramework.Rating[].class;
            cachedSerClasses.add(cls);
            qName = new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "Rating");
            qName2 = new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "Rating");
            cachedSerFactories.add(new org.apache.axis.encoding.ser.ArraySerializerFactory(qName, qName2));
            cachedDeserFactories.add(new org.apache.axis.encoding.ser.ArrayDeserializerFactory());

            qName = new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "ArrayOfUserAddress");
            cachedSerQNames.add(qName);
            cls = com.booktera.data.CommonModels_Models_EntityFramework.UserAddress[].class;
            cachedSerClasses.add(cls);
            qName = new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "UserAddress");
            qName2 = new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "UserAddress");
            cachedSerFactories.add(new org.apache.axis.encoding.ser.ArraySerializerFactory(qName, qName2));
            cachedDeserFactories.add(new org.apache.axis.encoding.ser.ArrayDeserializerFactory());

            qName = new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "ArrayOfUserOrder");
            cachedSerQNames.add(qName);
            cls = com.booktera.data.CommonModels_Models_EntityFramework.UserOrder[].class;
            cachedSerClasses.add(cls);
            qName = new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "UserOrder");
            qName2 = new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "UserOrder");
            cachedSerFactories.add(new org.apache.axis.encoding.ser.ArraySerializerFactory(qName, qName2));
            cachedDeserFactories.add(new org.apache.axis.encoding.ser.ArrayDeserializerFactory());

            qName = new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "ArrayOfUserProfile");
            cachedSerQNames.add(qName);
            cls = com.booktera.data.CommonModels_Models_EntityFramework.UserProfile[].class;
            cachedSerClasses.add(cls);
            qName = new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "UserProfile");
            qName2 = new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "UserProfile");
            cachedSerFactories.add(new org.apache.axis.encoding.ser.ArraySerializerFactory(qName, qName2));
            cachedDeserFactories.add(new org.apache.axis.encoding.ser.ArrayDeserializerFactory());

            qName = new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "ArrayOfUserView");
            cachedSerQNames.add(qName);
            cls = com.booktera.data.CommonModels_Models_EntityFramework.UserView[].class;
            cachedSerClasses.add(cls);
            qName = new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "UserView");
            qName2 = new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "UserView");
            cachedSerFactories.add(new org.apache.axis.encoding.ser.ArraySerializerFactory(qName, qName2));
            cachedDeserFactories.add(new org.apache.axis.encoding.ser.ArrayDeserializerFactory());

            qName = new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "ArrayOfwebpages_Roles");
            cachedSerQNames.add(qName);
            cls = com.booktera.data.CommonModels_Models_EntityFramework.Webpages_Roles[].class;
            cachedSerClasses.add(cls);
            qName = new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "webpages_Roles");
            qName2 = new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "webpages_Roles");
            cachedSerFactories.add(new org.apache.axis.encoding.ser.ArraySerializerFactory(qName, qName2));
            cachedDeserFactories.add(new org.apache.axis.encoding.ser.ArrayDeserializerFactory());

            qName = new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "Author");
            cachedSerQNames.add(qName);
            cls = com.booktera.data.CommonModels_Models_EntityFramework.Author.class;
            cachedSerClasses.add(cls);
            cachedSerFactories.add(beansf);
            cachedDeserFactories.add(beandf);

            qName = new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "Category");
            cachedSerQNames.add(qName);
            cls = com.booktera.data.CommonModels_Models_EntityFramework.Category.class;
            cachedSerClasses.add(cls);
            cachedSerFactories.add(beansf);
            cachedDeserFactories.add(beandf);

            qName = new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "Comment");
            cachedSerQNames.add(qName);
            cls = com.booktera.data.CommonModels_Models_EntityFramework.Comment.class;
            cachedSerClasses.add(cls);
            cachedSerFactories.add(beansf);
            cachedDeserFactories.add(beandf);

            qName = new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "Feedback");
            cachedSerQNames.add(qName);
            cls = com.booktera.data.CommonModels_Models_EntityFramework.Feedback.class;
            cachedSerClasses.add(cls);
            cachedSerFactories.add(beansf);
            cachedDeserFactories.add(beandf);

            qName = new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "HighlightedProduct");
            cachedSerQNames.add(qName);
            cls = com.booktera.data.CommonModels_Models_EntityFramework.HighlightedProduct.class;
            cachedSerClasses.add(cls);
            cachedSerFactories.add(beansf);
            cachedDeserFactories.add(beandf);

            qName = new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "HighlightType");
            cachedSerQNames.add(qName);
            cls = com.booktera.data.CommonModels_Models_EntityFramework.HighlightType.class;
            cachedSerClasses.add(cls);
            cachedSerFactories.add(beansf);
            cachedDeserFactories.add(beandf);

            qName = new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "Image");
            cachedSerQNames.add(qName);
            cls = com.booktera.data.CommonModels_Models_EntityFramework.Image.class;
            cachedSerClasses.add(cls);
            cachedSerFactories.add(beansf);
            cachedDeserFactories.add(beandf);

            qName = new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "Product");
            cachedSerQNames.add(qName);
            cls = com.booktera.data.CommonModels_Models_EntityFramework.Product.class;
            cachedSerClasses.add(cls);
            cachedSerFactories.add(beansf);
            cachedDeserFactories.add(beandf);

            qName = new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "ProductGroup");
            cachedSerQNames.add(qName);
            cls = com.booktera.data.CommonModels_Models_EntityFramework.ProductGroup.class;
            cachedSerClasses.add(cls);
            cachedSerFactories.add(beansf);
            cachedDeserFactories.add(beandf);

            qName = new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "ProductInOrder");
            cachedSerQNames.add(qName);
            cls = com.booktera.data.CommonModels_Models_EntityFramework.ProductInOrder.class;
            cachedSerClasses.add(cls);
            cachedSerFactories.add(beansf);
            cachedDeserFactories.add(beandf);

            qName = new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "Publisher");
            cachedSerQNames.add(qName);
            cls = com.booktera.data.CommonModels_Models_EntityFramework.Publisher.class;
            cachedSerClasses.add(cls);
            cachedSerFactories.add(beansf);
            cachedDeserFactories.add(beandf);

            qName = new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "Rating");
            cachedSerQNames.add(qName);
            cls = com.booktera.data.CommonModels_Models_EntityFramework.Rating.class;
            cachedSerClasses.add(cls);
            cachedSerFactories.add(beansf);
            cachedDeserFactories.add(beandf);

            qName = new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "UserAddress");
            cachedSerQNames.add(qName);
            cls = com.booktera.data.CommonModels_Models_EntityFramework.UserAddress.class;
            cachedSerClasses.add(cls);
            cachedSerFactories.add(beansf);
            cachedDeserFactories.add(beandf);

            qName = new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "UserGroup");
            cachedSerQNames.add(qName);
            cls = com.booktera.data.CommonModels_Models_EntityFramework.UserGroup.class;
            cachedSerClasses.add(cls);
            cachedSerFactories.add(beansf);
            cachedDeserFactories.add(beandf);

            qName = new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "UserOrder");
            cachedSerQNames.add(qName);
            cls = com.booktera.data.CommonModels_Models_EntityFramework.UserOrder.class;
            cachedSerClasses.add(cls);
            cachedSerFactories.add(beansf);
            cachedDeserFactories.add(beandf);

            qName = new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "UserProfile");
            cachedSerQNames.add(qName);
            cls = com.booktera.data.CommonModels_Models_EntityFramework.UserProfile.class;
            cachedSerClasses.add(cls);
            cachedSerFactories.add(beansf);
            cachedDeserFactories.add(beandf);

            qName = new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "UserView");
            cachedSerQNames.add(qName);
            cls = com.booktera.data.CommonModels_Models_EntityFramework.UserView.class;
            cachedSerClasses.add(cls);
            cachedSerFactories.add(beansf);
            cachedDeserFactories.add(beandf);

            qName = new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "webpages_Roles");
            cachedSerQNames.add(qName);
            cls = com.booktera.data.CommonModels_Models_EntityFramework.Webpages_Roles.class;
            cachedSerClasses.add(cls);
            cachedSerFactories.add(beansf);
            cachedDeserFactories.add(beandf);

            qName = new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonPortable.Enums", "BookBlockType");
            cachedSerQNames.add(qName);
            cls = com.booktera.data.CommonPortable_Enums.BookBlockType.class;
            cachedSerClasses.add(cls);
            cachedSerFactories.add(enumsf);
            cachedDeserFactories.add(enumdf);

            qName = new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonPortable.Models.ProductModels", "ArrayOfInBookBlockPVM");
            cachedSerQNames.add(qName);
            cls = com.booktera.data.CommonPortable_Models_ProductModels.InBookBlockPVM[].class;
            cachedSerClasses.add(cls);
            qName = new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonPortable.Models.ProductModels", "InBookBlockPVM");
            qName2 = new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonPortable.Models.ProductModels", "InBookBlockPVM");
            cachedSerFactories.add(new org.apache.axis.encoding.ser.ArraySerializerFactory(qName, qName2));
            cachedDeserFactories.add(new org.apache.axis.encoding.ser.ArrayDeserializerFactory());

            qName = new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonPortable.Models.ProductModels", "ArrayOfInCategoryPLVM");
            cachedSerQNames.add(qName);
            cls = com.booktera.data.CommonPortable_Models_ProductModels.InCategoryPLVM[].class;
            cachedSerClasses.add(cls);
            qName = new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonPortable.Models.ProductModels", "InCategoryPLVM");
            qName2 = new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonPortable.Models.ProductModels", "InCategoryPLVM");
            cachedSerFactories.add(new org.apache.axis.encoding.ser.ArraySerializerFactory(qName, qName2));
            cachedDeserFactories.add(new org.apache.axis.encoding.ser.ArrayDeserializerFactory());

            qName = new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonPortable.Models.ProductModels", "BookBlockPLVM");
            cachedSerQNames.add(qName);
            cls = com.booktera.data.CommonPortable_Models_ProductModels.BookBlockPLVM.class;
            cachedSerClasses.add(cls);
            cachedSerFactories.add(beansf);
            cachedDeserFactories.add(beandf);

            qName = new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonPortable.Models.ProductModels", "InBookBlockPVM");
            cachedSerQNames.add(qName);
            cls = com.booktera.data.CommonPortable_Models_ProductModels.InBookBlockPVM.class;
            cachedSerClasses.add(cls);
            cachedSerFactories.add(beansf);
            cachedDeserFactories.add(beandf);

            qName = new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonPortable.Models.ProductModels", "InBookBlockPVM.ProductGroupVM");
            cachedSerQNames.add(qName);
            cls = com.booktera.data.CommonPortable_Models_ProductModels.InBookBlockPVMProductGroupVM.class;
            cachedSerClasses.add(cls);
            cachedSerFactories.add(beansf);
            cachedDeserFactories.add(beandf);

            qName = new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonPortable.Models.ProductModels", "InBookBlockPVM.ProductVM");
            cachedSerQNames.add(qName);
            cls = com.booktera.data.CommonPortable_Models_ProductModels.InBookBlockPVMProductVM.class;
            cachedSerClasses.add(cls);
            cachedSerFactories.add(beansf);
            cachedDeserFactories.add(beandf);

            qName = new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonPortable.Models.ProductModels", "InCategoryCWPLVM");
            cachedSerQNames.add(qName);
            cls = com.booktera.data.CommonPortable_Models_ProductModels.InCategoryCWPLVM.class;
            cachedSerClasses.add(cls);
            cachedSerFactories.add(beansf);
            cachedDeserFactories.add(beandf);

            qName = new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonPortable.Models.ProductModels", "InCategoryPLVM");
            cachedSerQNames.add(qName);
            cls = com.booktera.data.CommonPortable_Models_ProductModels.InCategoryPLVM.class;
            cachedSerClasses.add(cls);
            cachedSerFactories.add(beansf);
            cachedDeserFactories.add(beandf);

            qName = new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonPortable.Models.ProductModels", "InCategoryPLVM.CategoryVM");
            cachedSerQNames.add(qName);
            cls = com.booktera.data.CommonPortable_Models_ProductModels.InCategoryPLVMCategoryVM.class;
            cachedSerClasses.add(cls);
            cachedSerFactories.add(beansf);
            cachedDeserFactories.add(beandf);

            qName = new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonPortable.Models", "Paging");
            cachedSerQNames.add(qName);
            cls = com.booktera.data.CommonPortable_Models.Paging.class;
            cachedSerClasses.add(cls);
            cachedSerFactories.add(beansf);
            cachedDeserFactories.add(beandf);

            qName = new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/System.Web.Mvc", "SelectListItem");
            cachedSerQNames.add(qName);
            cls = com.booktera.data.System_Web_Mvc.SelectListItem.class;
            cachedSerClasses.add(cls);
            cachedSerFactories.add(beansf);
            cachedDeserFactories.add(beandf);

            qName = new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/UtilsShared", "ArrayOfSelectListItemWithClass");
            cachedSerQNames.add(qName);
            cls = com.booktera.data.UtilsShared.SelectListItemWithClass[].class;
            cachedSerClasses.add(cls);
            qName = new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/UtilsShared", "SelectListItemWithClass");
            qName2 = new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/UtilsShared", "SelectListItemWithClass");
            cachedSerFactories.add(new org.apache.axis.encoding.ser.ArraySerializerFactory(qName, qName2));
            cachedDeserFactories.add(new org.apache.axis.encoding.ser.ArrayDeserializerFactory());

            qName = new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/UtilsShared", "SelectListItemWithClass");
            cachedSerQNames.add(qName);
            cls = com.booktera.data.UtilsShared.SelectListItemWithClass.class;
            cachedSerClasses.add(cls);
            cachedSerFactories.add(beansf);
            cachedDeserFactories.add(beandf);

            qName = new javax.xml.namespace.QName("http://schemas.microsoft.com/2003/10/Serialization/Arrays", "ArrayOfstring");
            cachedSerQNames.add(qName);
            cls = java.lang.String[].class;
            cachedSerClasses.add(cls);
            qName = new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "string");
            qName2 = new javax.xml.namespace.QName("http://schemas.microsoft.com/2003/10/Serialization/Arrays", "string");
            cachedSerFactories.add(new org.apache.axis.encoding.ser.ArraySerializerFactory(qName, qName2));
            cachedDeserFactories.add(new org.apache.axis.encoding.ser.ArrayDeserializerFactory());

    }

    protected org.apache.axis.client.Call createCall() throws java.rmi.RemoteException {
        try {
            org.apache.axis.client.Call _call = super._createCall();
            if (super.maintainSessionSet) {
                _call.setMaintainSession(super.maintainSession);
            }
            if (super.cachedUsername != null) {
                _call.setUsername(super.cachedUsername);
            }
            if (super.cachedPassword != null) {
                _call.setPassword(super.cachedPassword);
            }
            if (super.cachedEndpoint != null) {
                _call.setTargetEndpointAddress(super.cachedEndpoint);
            }
            if (super.cachedTimeout != null) {
                _call.setTimeout(super.cachedTimeout);
            }
            if (super.cachedPortName != null) {
                _call.setPortName(super.cachedPortName);
            }
            java.util.Enumeration keys = super.cachedProperties.keys();
            while (keys.hasMoreElements()) {
                java.lang.String key = (java.lang.String) keys.nextElement();
                _call.setProperty(key, super.cachedProperties.get(key));
            }
            // All the type mapping information is registered
            // when the first call is made.
            // The type mapping information is actually registered in
            // the TypeMappingRegistry of the service, which
            // is the reason why registration is only needed for the first call.
            synchronized (this) {
                if (firstCall()) {
                    // must set encoding style before registering serializers
                    _call.setEncodingStyle(null);
                    for (int i = 0; i < cachedSerFactories.size(); ++i) {
                        java.lang.Class cls = (java.lang.Class) cachedSerClasses.get(i);
                        javax.xml.namespace.QName qName =
                                (javax.xml.namespace.QName) cachedSerQNames.get(i);
                        java.lang.Object x = cachedSerFactories.get(i);
                        if (x instanceof Class) {
                            java.lang.Class sf = (java.lang.Class)
                                 cachedSerFactories.get(i);
                            java.lang.Class df = (java.lang.Class)
                                 cachedDeserFactories.get(i);
                            _call.registerTypeMapping(cls, qName, sf, df, false);
                        }
                        else if (x instanceof javax.xml.rpc.encoding.SerializerFactory) {
                            org.apache.axis.encoding.SerializerFactory sf = (org.apache.axis.encoding.SerializerFactory)
                                 cachedSerFactories.get(i);
                            org.apache.axis.encoding.DeserializerFactory df = (org.apache.axis.encoding.DeserializerFactory)
                                 cachedDeserFactories.get(i);
                            _call.registerTypeMapping(cls, qName, sf, df, false);
                        }
                    }
                }
            }
            return _call;
        }
        catch (java.lang.Throwable _t) {
            throw new org.apache.axis.AxisFault("Failure trying to get the Call object", _t);
        }
    }

    public java.lang.String getAllForMenu(java.lang.String selected, java.lang.String[] openedIds) throws java.rmi.RemoteException {
        if (super.cachedEndpoint == null) {
            throw new org.apache.axis.NoEndPointException();
        }
        org.apache.axis.client.Call _call = createCall();
        _call.setOperation(_operations[0]);
        _call.setUseSOAPAction(true);
        _call.setSOAPActionURI("http://tempuri.org/ICategoryManager/GetAllForMenu");
        _call.setEncodingStyle(null);
        _call.setProperty(org.apache.axis.client.Call.SEND_TYPE_ATTR, Boolean.FALSE);
        _call.setProperty(org.apache.axis.AxisEngine.PROP_DOMULTIREFS, Boolean.FALSE);
        _call.setSOAPVersion(org.apache.axis.soap.SOAPConstants.SOAP11_CONSTANTS);
        _call.setOperationName(new javax.xml.namespace.QName("http://tempuri.org/", "GetAllForMenu"));

        setRequestHeaders(_call);
        setAttachments(_call);
 try {        java.lang.Object _resp = _call.invoke(new java.lang.Object[] {selected, openedIds});

        if (_resp instanceof java.rmi.RemoteException) {
            throw (java.rmi.RemoteException)_resp;
        }
        else {
            extractAttachments(_call);
            try {
                return (java.lang.String) _resp;
            } catch (java.lang.Exception _exception) {
                return (java.lang.String) org.apache.axis.utils.JavaUtils.convert(_resp, java.lang.String.class);
            }
        }
  } catch (org.apache.axis.AxisFault axisFaultException) {
  throw axisFaultException;
}
    }

    public com.booktera.data.UtilsShared.SelectListItemWithClass[] getAllSortedJson(java.lang.Integer selectedCategoryId) throws java.rmi.RemoteException {
        if (super.cachedEndpoint == null) {
            throw new org.apache.axis.NoEndPointException();
        }
        org.apache.axis.client.Call _call = createCall();
        _call.setOperation(_operations[1]);
        _call.setUseSOAPAction(true);
        _call.setSOAPActionURI("http://tempuri.org/ICategoryManager/GetAllSortedJson");
        _call.setEncodingStyle(null);
        _call.setProperty(org.apache.axis.client.Call.SEND_TYPE_ATTR, Boolean.FALSE);
        _call.setProperty(org.apache.axis.AxisEngine.PROP_DOMULTIREFS, Boolean.FALSE);
        _call.setSOAPVersion(org.apache.axis.soap.SOAPConstants.SOAP11_CONSTANTS);
        _call.setOperationName(new javax.xml.namespace.QName("http://tempuri.org/", "GetAllSortedJson"));

        setRequestHeaders(_call);
        setAttachments(_call);
 try {        java.lang.Object _resp = _call.invoke(new java.lang.Object[] {selectedCategoryId});

        if (_resp instanceof java.rmi.RemoteException) {
            throw (java.rmi.RemoteException)_resp;
        }
        else {
            extractAttachments(_call);
            try {
                return (com.booktera.data.UtilsShared.SelectListItemWithClass[]) _resp;
            } catch (java.lang.Exception _exception) {
                return (com.booktera.data.UtilsShared.SelectListItemWithClass[]) org.apache.axis.utils.JavaUtils.convert(_resp, com.booktera.data.UtilsShared.SelectListItemWithClass[].class);
            }
        }
  } catch (org.apache.axis.AxisFault axisFaultException) {
  throw axisFaultException;
}
    }

    public com.booktera.data.CommonPortable_Models_ProductModels.InCategoryCWPLVM getCategoriesWithProductsInCategory(java.lang.Integer pageNumber, java.lang.Integer productsPerPage, java.lang.String baseCategoryFu) throws java.rmi.RemoteException {
        if (super.cachedEndpoint == null) {
            throw new org.apache.axis.NoEndPointException();
        }
        org.apache.axis.client.Call _call = createCall();
        _call.setOperation(_operations[2]);
        _call.setUseSOAPAction(true);
        _call.setSOAPActionURI("http://tempuri.org/ICategoryManager/GetCategoriesWithProductsInCategory");
        _call.setEncodingStyle(null);
        _call.setProperty(org.apache.axis.client.Call.SEND_TYPE_ATTR, Boolean.FALSE);
        _call.setProperty(org.apache.axis.AxisEngine.PROP_DOMULTIREFS, Boolean.FALSE);
        _call.setSOAPVersion(org.apache.axis.soap.SOAPConstants.SOAP11_CONSTANTS);
        _call.setOperationName(new javax.xml.namespace.QName("http://tempuri.org/", "GetCategoriesWithProductsInCategory"));

        setRequestHeaders(_call);
        setAttachments(_call);
 try {        java.lang.Object _resp = _call.invoke(new java.lang.Object[] {pageNumber, productsPerPage, baseCategoryFu});

        if (_resp instanceof java.rmi.RemoteException) {
            throw (java.rmi.RemoteException)_resp;
        }
        else {
            extractAttachments(_call);
            try {
                return (com.booktera.data.CommonPortable_Models_ProductModels.InCategoryCWPLVM) _resp;
            } catch (java.lang.Exception _exception) {
                return (com.booktera.data.CommonPortable_Models_ProductModels.InCategoryCWPLVM) org.apache.axis.utils.JavaUtils.convert(_resp, com.booktera.data.CommonPortable_Models_ProductModels.InCategoryCWPLVM.class);
            }
        }
  } catch (org.apache.axis.AxisFault axisFaultException) {
  throw axisFaultException;
}
    }

}
