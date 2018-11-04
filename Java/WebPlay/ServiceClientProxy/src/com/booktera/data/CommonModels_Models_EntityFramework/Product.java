/**
 * Product.java
 *
 * This file was auto-generated from WSDL
 * by the Apache Axis 1.4 Apr 22, 2006 (06:55:48 PDT) WSDL2Java emitter.
 */

package com.booktera.data.CommonModels_Models_EntityFramework;

public class Product  implements java.io.Serializable {
    private java.lang.String changeHistory;

    private java.lang.Boolean containsOther;

    private java.lang.String description;

    private java.lang.Integer edition;

    private java.lang.Integer howMany;

    private java.lang.Integer ID;

    private java.lang.String imageUrl;

    private com.booktera.data.CommonModels_Models_EntityFramework.Image[] images;

    private java.lang.Boolean isAudio;

    private java.lang.Boolean isBook;

    private java.lang.Boolean isCheckedByAdmin;

    private java.lang.Boolean isDownloadable;

    private java.lang.Boolean isUsed;

    private java.lang.Boolean isVideo;

    private java.lang.String language;

    private java.lang.Integer pageNumber;

    private java.lang.Integer price;

    private com.booktera.data.CommonModels_Models_EntityFramework.ProductInOrder[] productByOrder;

    private com.booktera.data.CommonModels_Models_EntityFramework.ProductGroup productGroup;

    private java.lang.Integer productGroupID;

    private com.booktera.data.CommonModels_Models_EntityFramework.HighlightedProduct[] productsHighlights;

    private java.lang.Integer publishYear;

    private java.lang.Integer sumOfViews;

    private java.util.Calendar uploadedDate;

    private java.lang.Integer userID;

    private java.lang.String userName;

    private com.booktera.data.CommonModels_Models_EntityFramework.UserProfile userProfile;

    private com.booktera.data.CommonModels_Models_EntityFramework.UserView[] userViews;

    public Product() {
    }

    public Product(
           java.lang.String changeHistory,
           java.lang.Boolean containsOther,
           java.lang.String description,
           java.lang.Integer edition,
           java.lang.Integer howMany,
           java.lang.Integer ID,
           java.lang.String imageUrl,
           com.booktera.data.CommonModels_Models_EntityFramework.Image[] images,
           java.lang.Boolean isAudio,
           java.lang.Boolean isBook,
           java.lang.Boolean isCheckedByAdmin,
           java.lang.Boolean isDownloadable,
           java.lang.Boolean isUsed,
           java.lang.Boolean isVideo,
           java.lang.String language,
           java.lang.Integer pageNumber,
           java.lang.Integer price,
           com.booktera.data.CommonModels_Models_EntityFramework.ProductInOrder[] productByOrder,
           com.booktera.data.CommonModels_Models_EntityFramework.ProductGroup productGroup,
           java.lang.Integer productGroupID,
           com.booktera.data.CommonModels_Models_EntityFramework.HighlightedProduct[] productsHighlights,
           java.lang.Integer publishYear,
           java.lang.Integer sumOfViews,
           java.util.Calendar uploadedDate,
           java.lang.Integer userID,
           java.lang.String userName,
           com.booktera.data.CommonModels_Models_EntityFramework.UserProfile userProfile,
           com.booktera.data.CommonModels_Models_EntityFramework.UserView[] userViews) {
           this.changeHistory = changeHistory;
           this.containsOther = containsOther;
           this.description = description;
           this.edition = edition;
           this.howMany = howMany;
           this.ID = ID;
           this.imageUrl = imageUrl;
           this.images = images;
           this.isAudio = isAudio;
           this.isBook = isBook;
           this.isCheckedByAdmin = isCheckedByAdmin;
           this.isDownloadable = isDownloadable;
           this.isUsed = isUsed;
           this.isVideo = isVideo;
           this.language = language;
           this.pageNumber = pageNumber;
           this.price = price;
           this.productByOrder = productByOrder;
           this.productGroup = productGroup;
           this.productGroupID = productGroupID;
           this.productsHighlights = productsHighlights;
           this.publishYear = publishYear;
           this.sumOfViews = sumOfViews;
           this.uploadedDate = uploadedDate;
           this.userID = userID;
           this.userName = userName;
           this.userProfile = userProfile;
           this.userViews = userViews;
    }


    /**
     * Gets the changeHistory value for this Product.
     * 
     * @return changeHistory
     */
    public java.lang.String getChangeHistory() {
        return changeHistory;
    }


    /**
     * Sets the changeHistory value for this Product.
     * 
     * @param changeHistory
     */
    public void setChangeHistory(java.lang.String changeHistory) {
        this.changeHistory = changeHistory;
    }


    /**
     * Gets the containsOther value for this Product.
     * 
     * @return containsOther
     */
    public java.lang.Boolean getContainsOther() {
        return containsOther;
    }


    /**
     * Sets the containsOther value for this Product.
     * 
     * @param containsOther
     */
    public void setContainsOther(java.lang.Boolean containsOther) {
        this.containsOther = containsOther;
    }


    /**
     * Gets the description value for this Product.
     * 
     * @return description
     */
    public java.lang.String getDescription() {
        return description;
    }


    /**
     * Sets the description value for this Product.
     * 
     * @param description
     */
    public void setDescription(java.lang.String description) {
        this.description = description;
    }


    /**
     * Gets the edition value for this Product.
     * 
     * @return edition
     */
    public java.lang.Integer getEdition() {
        return edition;
    }


    /**
     * Sets the edition value for this Product.
     * 
     * @param edition
     */
    public void setEdition(java.lang.Integer edition) {
        this.edition = edition;
    }


    /**
     * Gets the howMany value for this Product.
     * 
     * @return howMany
     */
    public java.lang.Integer getHowMany() {
        return howMany;
    }


    /**
     * Sets the howMany value for this Product.
     * 
     * @param howMany
     */
    public void setHowMany(java.lang.Integer howMany) {
        this.howMany = howMany;
    }


    /**
     * Gets the ID value for this Product.
     * 
     * @return ID
     */
    public java.lang.Integer getID() {
        return ID;
    }


    /**
     * Sets the ID value for this Product.
     * 
     * @param ID
     */
    public void setID(java.lang.Integer ID) {
        this.ID = ID;
    }


    /**
     * Gets the imageUrl value for this Product.
     * 
     * @return imageUrl
     */
    public java.lang.String getImageUrl() {
        return imageUrl;
    }


    /**
     * Sets the imageUrl value for this Product.
     * 
     * @param imageUrl
     */
    public void setImageUrl(java.lang.String imageUrl) {
        this.imageUrl = imageUrl;
    }


    /**
     * Gets the images value for this Product.
     * 
     * @return images
     */
    public com.booktera.data.CommonModels_Models_EntityFramework.Image[] getImages() {
        return images;
    }


    /**
     * Sets the images value for this Product.
     * 
     * @param images
     */
    public void setImages(com.booktera.data.CommonModels_Models_EntityFramework.Image[] images) {
        this.images = images;
    }


    /**
     * Gets the isAudio value for this Product.
     * 
     * @return isAudio
     */
    public java.lang.Boolean getIsAudio() {
        return isAudio;
    }


    /**
     * Sets the isAudio value for this Product.
     * 
     * @param isAudio
     */
    public void setIsAudio(java.lang.Boolean isAudio) {
        this.isAudio = isAudio;
    }


    /**
     * Gets the isBook value for this Product.
     * 
     * @return isBook
     */
    public java.lang.Boolean getIsBook() {
        return isBook;
    }


    /**
     * Sets the isBook value for this Product.
     * 
     * @param isBook
     */
    public void setIsBook(java.lang.Boolean isBook) {
        this.isBook = isBook;
    }


    /**
     * Gets the isCheckedByAdmin value for this Product.
     * 
     * @return isCheckedByAdmin
     */
    public java.lang.Boolean getIsCheckedByAdmin() {
        return isCheckedByAdmin;
    }


    /**
     * Sets the isCheckedByAdmin value for this Product.
     * 
     * @param isCheckedByAdmin
     */
    public void setIsCheckedByAdmin(java.lang.Boolean isCheckedByAdmin) {
        this.isCheckedByAdmin = isCheckedByAdmin;
    }


    /**
     * Gets the isDownloadable value for this Product.
     * 
     * @return isDownloadable
     */
    public java.lang.Boolean getIsDownloadable() {
        return isDownloadable;
    }


    /**
     * Sets the isDownloadable value for this Product.
     * 
     * @param isDownloadable
     */
    public void setIsDownloadable(java.lang.Boolean isDownloadable) {
        this.isDownloadable = isDownloadable;
    }


    /**
     * Gets the isUsed value for this Product.
     * 
     * @return isUsed
     */
    public java.lang.Boolean getIsUsed() {
        return isUsed;
    }


    /**
     * Sets the isUsed value for this Product.
     * 
     * @param isUsed
     */
    public void setIsUsed(java.lang.Boolean isUsed) {
        this.isUsed = isUsed;
    }


    /**
     * Gets the isVideo value for this Product.
     * 
     * @return isVideo
     */
    public java.lang.Boolean getIsVideo() {
        return isVideo;
    }


    /**
     * Sets the isVideo value for this Product.
     * 
     * @param isVideo
     */
    public void setIsVideo(java.lang.Boolean isVideo) {
        this.isVideo = isVideo;
    }


    /**
     * Gets the language value for this Product.
     * 
     * @return language
     */
    public java.lang.String getLanguage() {
        return language;
    }


    /**
     * Sets the language value for this Product.
     * 
     * @param language
     */
    public void setLanguage(java.lang.String language) {
        this.language = language;
    }


    /**
     * Gets the pageNumber value for this Product.
     * 
     * @return pageNumber
     */
    public java.lang.Integer getPageNumber() {
        return pageNumber;
    }


    /**
     * Sets the pageNumber value for this Product.
     * 
     * @param pageNumber
     */
    public void setPageNumber(java.lang.Integer pageNumber) {
        this.pageNumber = pageNumber;
    }


    /**
     * Gets the price value for this Product.
     * 
     * @return price
     */
    public java.lang.Integer getPrice() {
        return price;
    }


    /**
     * Sets the price value for this Product.
     * 
     * @param price
     */
    public void setPrice(java.lang.Integer price) {
        this.price = price;
    }


    /**
     * Gets the productByOrder value for this Product.
     * 
     * @return productByOrder
     */
    public com.booktera.data.CommonModels_Models_EntityFramework.ProductInOrder[] getProductByOrder() {
        return productByOrder;
    }


    /**
     * Sets the productByOrder value for this Product.
     * 
     * @param productByOrder
     */
    public void setProductByOrder(com.booktera.data.CommonModels_Models_EntityFramework.ProductInOrder[] productByOrder) {
        this.productByOrder = productByOrder;
    }


    /**
     * Gets the productGroup value for this Product.
     * 
     * @return productGroup
     */
    public com.booktera.data.CommonModels_Models_EntityFramework.ProductGroup getProductGroup() {
        return productGroup;
    }


    /**
     * Sets the productGroup value for this Product.
     * 
     * @param productGroup
     */
    public void setProductGroup(com.booktera.data.CommonModels_Models_EntityFramework.ProductGroup productGroup) {
        this.productGroup = productGroup;
    }


    /**
     * Gets the productGroupID value for this Product.
     * 
     * @return productGroupID
     */
    public java.lang.Integer getProductGroupID() {
        return productGroupID;
    }


    /**
     * Sets the productGroupID value for this Product.
     * 
     * @param productGroupID
     */
    public void setProductGroupID(java.lang.Integer productGroupID) {
        this.productGroupID = productGroupID;
    }


    /**
     * Gets the productsHighlights value for this Product.
     * 
     * @return productsHighlights
     */
    public com.booktera.data.CommonModels_Models_EntityFramework.HighlightedProduct[] getProductsHighlights() {
        return productsHighlights;
    }


    /**
     * Sets the productsHighlights value for this Product.
     * 
     * @param productsHighlights
     */
    public void setProductsHighlights(com.booktera.data.CommonModels_Models_EntityFramework.HighlightedProduct[] productsHighlights) {
        this.productsHighlights = productsHighlights;
    }


    /**
     * Gets the publishYear value for this Product.
     * 
     * @return publishYear
     */
    public java.lang.Integer getPublishYear() {
        return publishYear;
    }


    /**
     * Sets the publishYear value for this Product.
     * 
     * @param publishYear
     */
    public void setPublishYear(java.lang.Integer publishYear) {
        this.publishYear = publishYear;
    }


    /**
     * Gets the sumOfViews value for this Product.
     * 
     * @return sumOfViews
     */
    public java.lang.Integer getSumOfViews() {
        return sumOfViews;
    }


    /**
     * Sets the sumOfViews value for this Product.
     * 
     * @param sumOfViews
     */
    public void setSumOfViews(java.lang.Integer sumOfViews) {
        this.sumOfViews = sumOfViews;
    }


    /**
     * Gets the uploadedDate value for this Product.
     * 
     * @return uploadedDate
     */
    public java.util.Calendar getUploadedDate() {
        return uploadedDate;
    }


    /**
     * Sets the uploadedDate value for this Product.
     * 
     * @param uploadedDate
     */
    public void setUploadedDate(java.util.Calendar uploadedDate) {
        this.uploadedDate = uploadedDate;
    }


    /**
     * Gets the userID value for this Product.
     * 
     * @return userID
     */
    public java.lang.Integer getUserID() {
        return userID;
    }


    /**
     * Sets the userID value for this Product.
     * 
     * @param userID
     */
    public void setUserID(java.lang.Integer userID) {
        this.userID = userID;
    }


    /**
     * Gets the userName value for this Product.
     * 
     * @return userName
     */
    public java.lang.String getUserName() {
        return userName;
    }


    /**
     * Sets the userName value for this Product.
     * 
     * @param userName
     */
    public void setUserName(java.lang.String userName) {
        this.userName = userName;
    }


    /**
     * Gets the userProfile value for this Product.
     * 
     * @return userProfile
     */
    public com.booktera.data.CommonModels_Models_EntityFramework.UserProfile getUserProfile() {
        return userProfile;
    }


    /**
     * Sets the userProfile value for this Product.
     * 
     * @param userProfile
     */
    public void setUserProfile(com.booktera.data.CommonModels_Models_EntityFramework.UserProfile userProfile) {
        this.userProfile = userProfile;
    }


    /**
     * Gets the userViews value for this Product.
     * 
     * @return userViews
     */
    public com.booktera.data.CommonModels_Models_EntityFramework.UserView[] getUserViews() {
        return userViews;
    }


    /**
     * Sets the userViews value for this Product.
     * 
     * @param userViews
     */
    public void setUserViews(com.booktera.data.CommonModels_Models_EntityFramework.UserView[] userViews) {
        this.userViews = userViews;
    }

    private java.lang.Object __equalsCalc = null;
    public synchronized boolean equals(java.lang.Object obj) {
        if (!(obj instanceof Product)) return false;
        Product other = (Product) obj;
        if (obj == null) return false;
        if (this == obj) return true;
        if (__equalsCalc != null) {
            return (__equalsCalc == obj);
        }
        __equalsCalc = obj;
        boolean _equals;
        _equals = true && 
            ((this.changeHistory==null && other.getChangeHistory()==null) || 
             (this.changeHistory!=null &&
              this.changeHistory.equals(other.getChangeHistory()))) &&
            ((this.containsOther==null && other.getContainsOther()==null) || 
             (this.containsOther!=null &&
              this.containsOther.equals(other.getContainsOther()))) &&
            ((this.description==null && other.getDescription()==null) || 
             (this.description!=null &&
              this.description.equals(other.getDescription()))) &&
            ((this.edition==null && other.getEdition()==null) || 
             (this.edition!=null &&
              this.edition.equals(other.getEdition()))) &&
            ((this.howMany==null && other.getHowMany()==null) || 
             (this.howMany!=null &&
              this.howMany.equals(other.getHowMany()))) &&
            ((this.ID==null && other.getID()==null) || 
             (this.ID!=null &&
              this.ID.equals(other.getID()))) &&
            ((this.imageUrl==null && other.getImageUrl()==null) || 
             (this.imageUrl!=null &&
              this.imageUrl.equals(other.getImageUrl()))) &&
            ((this.images==null && other.getImages()==null) || 
             (this.images!=null &&
              java.util.Arrays.equals(this.images, other.getImages()))) &&
            ((this.isAudio==null && other.getIsAudio()==null) || 
             (this.isAudio!=null &&
              this.isAudio.equals(other.getIsAudio()))) &&
            ((this.isBook==null && other.getIsBook()==null) || 
             (this.isBook!=null &&
              this.isBook.equals(other.getIsBook()))) &&
            ((this.isCheckedByAdmin==null && other.getIsCheckedByAdmin()==null) || 
             (this.isCheckedByAdmin!=null &&
              this.isCheckedByAdmin.equals(other.getIsCheckedByAdmin()))) &&
            ((this.isDownloadable==null && other.getIsDownloadable()==null) || 
             (this.isDownloadable!=null &&
              this.isDownloadable.equals(other.getIsDownloadable()))) &&
            ((this.isUsed==null && other.getIsUsed()==null) || 
             (this.isUsed!=null &&
              this.isUsed.equals(other.getIsUsed()))) &&
            ((this.isVideo==null && other.getIsVideo()==null) || 
             (this.isVideo!=null &&
              this.isVideo.equals(other.getIsVideo()))) &&
            ((this.language==null && other.getLanguage()==null) || 
             (this.language!=null &&
              this.language.equals(other.getLanguage()))) &&
            ((this.pageNumber==null && other.getPageNumber()==null) || 
             (this.pageNumber!=null &&
              this.pageNumber.equals(other.getPageNumber()))) &&
            ((this.price==null && other.getPrice()==null) || 
             (this.price!=null &&
              this.price.equals(other.getPrice()))) &&
            ((this.productByOrder==null && other.getProductByOrder()==null) || 
             (this.productByOrder!=null &&
              java.util.Arrays.equals(this.productByOrder, other.getProductByOrder()))) &&
            ((this.productGroup==null && other.getProductGroup()==null) || 
             (this.productGroup!=null &&
              this.productGroup.equals(other.getProductGroup()))) &&
            ((this.productGroupID==null && other.getProductGroupID()==null) || 
             (this.productGroupID!=null &&
              this.productGroupID.equals(other.getProductGroupID()))) &&
            ((this.productsHighlights==null && other.getProductsHighlights()==null) || 
             (this.productsHighlights!=null &&
              java.util.Arrays.equals(this.productsHighlights, other.getProductsHighlights()))) &&
            ((this.publishYear==null && other.getPublishYear()==null) || 
             (this.publishYear!=null &&
              this.publishYear.equals(other.getPublishYear()))) &&
            ((this.sumOfViews==null && other.getSumOfViews()==null) || 
             (this.sumOfViews!=null &&
              this.sumOfViews.equals(other.getSumOfViews()))) &&
            ((this.uploadedDate==null && other.getUploadedDate()==null) || 
             (this.uploadedDate!=null &&
              this.uploadedDate.equals(other.getUploadedDate()))) &&
            ((this.userID==null && other.getUserID()==null) || 
             (this.userID!=null &&
              this.userID.equals(other.getUserID()))) &&
            ((this.userName==null && other.getUserName()==null) || 
             (this.userName!=null &&
              this.userName.equals(other.getUserName()))) &&
            ((this.userProfile==null && other.getUserProfile()==null) || 
             (this.userProfile!=null &&
              this.userProfile.equals(other.getUserProfile()))) &&
            ((this.userViews==null && other.getUserViews()==null) || 
             (this.userViews!=null &&
              java.util.Arrays.equals(this.userViews, other.getUserViews())));
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
        if (getChangeHistory() != null) {
            _hashCode += getChangeHistory().hashCode();
        }
        if (getContainsOther() != null) {
            _hashCode += getContainsOther().hashCode();
        }
        if (getDescription() != null) {
            _hashCode += getDescription().hashCode();
        }
        if (getEdition() != null) {
            _hashCode += getEdition().hashCode();
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
        if (getImages() != null) {
            for (int i=0;
                 i<java.lang.reflect.Array.getLength(getImages());
                 i++) {
                java.lang.Object obj = java.lang.reflect.Array.get(getImages(), i);
                if (obj != null &&
                    !obj.getClass().isArray()) {
                    _hashCode += obj.hashCode();
                }
            }
        }
        if (getIsAudio() != null) {
            _hashCode += getIsAudio().hashCode();
        }
        if (getIsBook() != null) {
            _hashCode += getIsBook().hashCode();
        }
        if (getIsCheckedByAdmin() != null) {
            _hashCode += getIsCheckedByAdmin().hashCode();
        }
        if (getIsDownloadable() != null) {
            _hashCode += getIsDownloadable().hashCode();
        }
        if (getIsUsed() != null) {
            _hashCode += getIsUsed().hashCode();
        }
        if (getIsVideo() != null) {
            _hashCode += getIsVideo().hashCode();
        }
        if (getLanguage() != null) {
            _hashCode += getLanguage().hashCode();
        }
        if (getPageNumber() != null) {
            _hashCode += getPageNumber().hashCode();
        }
        if (getPrice() != null) {
            _hashCode += getPrice().hashCode();
        }
        if (getProductByOrder() != null) {
            for (int i=0;
                 i<java.lang.reflect.Array.getLength(getProductByOrder());
                 i++) {
                java.lang.Object obj = java.lang.reflect.Array.get(getProductByOrder(), i);
                if (obj != null &&
                    !obj.getClass().isArray()) {
                    _hashCode += obj.hashCode();
                }
            }
        }
        if (getProductGroup() != null) {
            _hashCode += getProductGroup().hashCode();
        }
        if (getProductGroupID() != null) {
            _hashCode += getProductGroupID().hashCode();
        }
        if (getProductsHighlights() != null) {
            for (int i=0;
                 i<java.lang.reflect.Array.getLength(getProductsHighlights());
                 i++) {
                java.lang.Object obj = java.lang.reflect.Array.get(getProductsHighlights(), i);
                if (obj != null &&
                    !obj.getClass().isArray()) {
                    _hashCode += obj.hashCode();
                }
            }
        }
        if (getPublishYear() != null) {
            _hashCode += getPublishYear().hashCode();
        }
        if (getSumOfViews() != null) {
            _hashCode += getSumOfViews().hashCode();
        }
        if (getUploadedDate() != null) {
            _hashCode += getUploadedDate().hashCode();
        }
        if (getUserID() != null) {
            _hashCode += getUserID().hashCode();
        }
        if (getUserName() != null) {
            _hashCode += getUserName().hashCode();
        }
        if (getUserProfile() != null) {
            _hashCode += getUserProfile().hashCode();
        }
        if (getUserViews() != null) {
            for (int i=0;
                 i<java.lang.reflect.Array.getLength(getUserViews());
                 i++) {
                java.lang.Object obj = java.lang.reflect.Array.get(getUserViews(), i);
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
        new org.apache.axis.description.TypeDesc(Product.class, true);

    static {
        typeDesc.setXmlType(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "Product"));
        org.apache.axis.description.ElementDesc elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("changeHistory");
        elemField.setXmlName(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "ChangeHistory"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "string"));
        elemField.setMinOccurs(0);
        elemField.setNillable(true);
        typeDesc.addFieldDesc(elemField);
        elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("containsOther");
        elemField.setXmlName(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "ContainsOther"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "boolean"));
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
        elemField.setFieldName("edition");
        elemField.setXmlName(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "Edition"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "int"));
        elemField.setMinOccurs(0);
        elemField.setNillable(false);
        typeDesc.addFieldDesc(elemField);
        elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("howMany");
        elemField.setXmlName(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "HowMany"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "int"));
        elemField.setMinOccurs(0);
        elemField.setNillable(false);
        typeDesc.addFieldDesc(elemField);
        elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("ID");
        elemField.setXmlName(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "ID"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "int"));
        elemField.setMinOccurs(0);
        elemField.setNillable(false);
        typeDesc.addFieldDesc(elemField);
        elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("imageUrl");
        elemField.setXmlName(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "ImageUrl"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "string"));
        elemField.setMinOccurs(0);
        elemField.setNillable(true);
        typeDesc.addFieldDesc(elemField);
        elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("images");
        elemField.setXmlName(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "Images"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "Image"));
        elemField.setMinOccurs(0);
        elemField.setNillable(true);
        elemField.setItemQName(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "Image"));
        typeDesc.addFieldDesc(elemField);
        elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("isAudio");
        elemField.setXmlName(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "IsAudio"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "boolean"));
        elemField.setMinOccurs(0);
        elemField.setNillable(false);
        typeDesc.addFieldDesc(elemField);
        elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("isBook");
        elemField.setXmlName(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "IsBook"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "boolean"));
        elemField.setMinOccurs(0);
        elemField.setNillable(false);
        typeDesc.addFieldDesc(elemField);
        elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("isCheckedByAdmin");
        elemField.setXmlName(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "IsCheckedByAdmin"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "boolean"));
        elemField.setMinOccurs(0);
        elemField.setNillable(false);
        typeDesc.addFieldDesc(elemField);
        elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("isDownloadable");
        elemField.setXmlName(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "IsDownloadable"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "boolean"));
        elemField.setMinOccurs(0);
        elemField.setNillable(false);
        typeDesc.addFieldDesc(elemField);
        elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("isUsed");
        elemField.setXmlName(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "IsUsed"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "boolean"));
        elemField.setMinOccurs(0);
        elemField.setNillable(false);
        typeDesc.addFieldDesc(elemField);
        elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("isVideo");
        elemField.setXmlName(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "IsVideo"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "boolean"));
        elemField.setMinOccurs(0);
        elemField.setNillable(false);
        typeDesc.addFieldDesc(elemField);
        elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("language");
        elemField.setXmlName(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "Language"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "string"));
        elemField.setMinOccurs(0);
        elemField.setNillable(true);
        typeDesc.addFieldDesc(elemField);
        elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("pageNumber");
        elemField.setXmlName(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "PageNumber"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "int"));
        elemField.setMinOccurs(0);
        elemField.setNillable(false);
        typeDesc.addFieldDesc(elemField);
        elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("price");
        elemField.setXmlName(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "Price"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "int"));
        elemField.setMinOccurs(0);
        elemField.setNillable(false);
        typeDesc.addFieldDesc(elemField);
        elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("productByOrder");
        elemField.setXmlName(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "ProductByOrder"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "ProductInOrder"));
        elemField.setMinOccurs(0);
        elemField.setNillable(true);
        elemField.setItemQName(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "ProductInOrder"));
        typeDesc.addFieldDesc(elemField);
        elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("productGroup");
        elemField.setXmlName(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "ProductGroup"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "ProductGroup"));
        elemField.setMinOccurs(0);
        elemField.setNillable(true);
        typeDesc.addFieldDesc(elemField);
        elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("productGroupID");
        elemField.setXmlName(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "ProductGroupID"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "int"));
        elemField.setMinOccurs(0);
        elemField.setNillable(false);
        typeDesc.addFieldDesc(elemField);
        elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("productsHighlights");
        elemField.setXmlName(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "ProductsHighlights"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "HighlightedProduct"));
        elemField.setMinOccurs(0);
        elemField.setNillable(true);
        elemField.setItemQName(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "HighlightedProduct"));
        typeDesc.addFieldDesc(elemField);
        elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("publishYear");
        elemField.setXmlName(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "PublishYear"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "int"));
        elemField.setMinOccurs(0);
        elemField.setNillable(false);
        typeDesc.addFieldDesc(elemField);
        elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("sumOfViews");
        elemField.setXmlName(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "SumOfViews"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "int"));
        elemField.setMinOccurs(0);
        elemField.setNillable(false);
        typeDesc.addFieldDesc(elemField);
        elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("uploadedDate");
        elemField.setXmlName(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "UploadedDate"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "dateTime"));
        elemField.setMinOccurs(0);
        elemField.setNillable(false);
        typeDesc.addFieldDesc(elemField);
        elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("userID");
        elemField.setXmlName(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "UserID"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "int"));
        elemField.setMinOccurs(0);
        elemField.setNillable(false);
        typeDesc.addFieldDesc(elemField);
        elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("userName");
        elemField.setXmlName(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "UserName"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "string"));
        elemField.setMinOccurs(0);
        elemField.setNillable(true);
        typeDesc.addFieldDesc(elemField);
        elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("userProfile");
        elemField.setXmlName(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "UserProfile"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "UserProfile"));
        elemField.setMinOccurs(0);
        elemField.setNillable(true);
        typeDesc.addFieldDesc(elemField);
        elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("userViews");
        elemField.setXmlName(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "UserViews"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "UserView"));
        elemField.setMinOccurs(0);
        elemField.setNillable(true);
        elemField.setItemQName(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "UserView"));
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
