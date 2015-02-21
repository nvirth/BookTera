/**
 * ProductGroup.java
 *
 * This file was auto-generated from WSDL
 * by the Apache Axis 1.4 Apr 22, 2006 (06:55:48 PDT) WSDL2Java emitter.
 */

package com.booktera.data.CommonModels_Models_EntityFramework;

public class ProductGroup  implements java.io.Serializable {
    private java.lang.String authorNames;

    private com.booktera.data.CommonModels_Models_EntityFramework.Author[] authors;

    private com.booktera.data.CommonModels_Models_EntityFramework.Category category;

    private java.lang.Integer categoryID;

    private java.lang.String changeHistory;

    private com.booktera.data.CommonModels_Models_EntityFramework.Comment[] comments;

    private java.lang.String description;

    private java.lang.String friendlyUrl;

    private java.lang.Integer ID;

    private java.lang.String imageUrl;

    private com.booktera.data.CommonModels_Models_EntityFramework.Image[] images;

    private java.lang.Boolean isCheckedByAdmin;

    private java.lang.Integer maxPrice;

    private java.lang.Integer minPrice;

    private com.booktera.data.CommonModels_Models_EntityFramework.Product[] productsInGroup;

    private com.booktera.data.CommonModels_Models_EntityFramework.Publisher publisher;

    private java.lang.Integer publisherID;

    private java.lang.String publisherName;

    private com.booktera.data.CommonModels_Models_EntityFramework.Rating[] ratings;

    private java.lang.String subTitle;

    private java.lang.Integer sumOfActiveProductsInGroup;

    private java.lang.Integer sumOfBuys;

    private java.lang.Integer sumOfComments;

    private java.lang.Integer sumOfPassiveProductsInGroup;

    private java.lang.Integer sumOfRatings;

    private java.lang.Integer sumOfRatingsValue;

    private java.lang.Integer sumOfViews;

    private java.lang.String title;

    private java.util.Calendar uploadedDate;

    private com.booktera.data.CommonModels_Models_EntityFramework.UserView[] userViews;

    public ProductGroup() {
    }

    public ProductGroup(
           java.lang.String authorNames,
           com.booktera.data.CommonModels_Models_EntityFramework.Author[] authors,
           com.booktera.data.CommonModels_Models_EntityFramework.Category category,
           java.lang.Integer categoryID,
           java.lang.String changeHistory,
           com.booktera.data.CommonModels_Models_EntityFramework.Comment[] comments,
           java.lang.String description,
           java.lang.String friendlyUrl,
           java.lang.Integer ID,
           java.lang.String imageUrl,
           com.booktera.data.CommonModels_Models_EntityFramework.Image[] images,
           java.lang.Boolean isCheckedByAdmin,
           java.lang.Integer maxPrice,
           java.lang.Integer minPrice,
           com.booktera.data.CommonModels_Models_EntityFramework.Product[] productsInGroup,
           com.booktera.data.CommonModels_Models_EntityFramework.Publisher publisher,
           java.lang.Integer publisherID,
           java.lang.String publisherName,
           com.booktera.data.CommonModels_Models_EntityFramework.Rating[] ratings,
           java.lang.String subTitle,
           java.lang.Integer sumOfActiveProductsInGroup,
           java.lang.Integer sumOfBuys,
           java.lang.Integer sumOfComments,
           java.lang.Integer sumOfPassiveProductsInGroup,
           java.lang.Integer sumOfRatings,
           java.lang.Integer sumOfRatingsValue,
           java.lang.Integer sumOfViews,
           java.lang.String title,
           java.util.Calendar uploadedDate,
           com.booktera.data.CommonModels_Models_EntityFramework.UserView[] userViews) {
           this.authorNames = authorNames;
           this.authors = authors;
           this.category = category;
           this.categoryID = categoryID;
           this.changeHistory = changeHistory;
           this.comments = comments;
           this.description = description;
           this.friendlyUrl = friendlyUrl;
           this.ID = ID;
           this.imageUrl = imageUrl;
           this.images = images;
           this.isCheckedByAdmin = isCheckedByAdmin;
           this.maxPrice = maxPrice;
           this.minPrice = minPrice;
           this.productsInGroup = productsInGroup;
           this.publisher = publisher;
           this.publisherID = publisherID;
           this.publisherName = publisherName;
           this.ratings = ratings;
           this.subTitle = subTitle;
           this.sumOfActiveProductsInGroup = sumOfActiveProductsInGroup;
           this.sumOfBuys = sumOfBuys;
           this.sumOfComments = sumOfComments;
           this.sumOfPassiveProductsInGroup = sumOfPassiveProductsInGroup;
           this.sumOfRatings = sumOfRatings;
           this.sumOfRatingsValue = sumOfRatingsValue;
           this.sumOfViews = sumOfViews;
           this.title = title;
           this.uploadedDate = uploadedDate;
           this.userViews = userViews;
    }


    /**
     * Gets the authorNames value for this ProductGroup.
     * 
     * @return authorNames
     */
    public java.lang.String getAuthorNames() {
        return authorNames;
    }


    /**
     * Sets the authorNames value for this ProductGroup.
     * 
     * @param authorNames
     */
    public void setAuthorNames(java.lang.String authorNames) {
        this.authorNames = authorNames;
    }


    /**
     * Gets the authors value for this ProductGroup.
     * 
     * @return authors
     */
    public com.booktera.data.CommonModels_Models_EntityFramework.Author[] getAuthors() {
        return authors;
    }


    /**
     * Sets the authors value for this ProductGroup.
     * 
     * @param authors
     */
    public void setAuthors(com.booktera.data.CommonModels_Models_EntityFramework.Author[] authors) {
        this.authors = authors;
    }


    /**
     * Gets the category value for this ProductGroup.
     * 
     * @return category
     */
    public com.booktera.data.CommonModels_Models_EntityFramework.Category getCategory() {
        return category;
    }


    /**
     * Sets the category value for this ProductGroup.
     * 
     * @param category
     */
    public void setCategory(com.booktera.data.CommonModels_Models_EntityFramework.Category category) {
        this.category = category;
    }


    /**
     * Gets the categoryID value for this ProductGroup.
     * 
     * @return categoryID
     */
    public java.lang.Integer getCategoryID() {
        return categoryID;
    }


    /**
     * Sets the categoryID value for this ProductGroup.
     * 
     * @param categoryID
     */
    public void setCategoryID(java.lang.Integer categoryID) {
        this.categoryID = categoryID;
    }


    /**
     * Gets the changeHistory value for this ProductGroup.
     * 
     * @return changeHistory
     */
    public java.lang.String getChangeHistory() {
        return changeHistory;
    }


    /**
     * Sets the changeHistory value for this ProductGroup.
     * 
     * @param changeHistory
     */
    public void setChangeHistory(java.lang.String changeHistory) {
        this.changeHistory = changeHistory;
    }


    /**
     * Gets the comments value for this ProductGroup.
     * 
     * @return comments
     */
    public com.booktera.data.CommonModels_Models_EntityFramework.Comment[] getComments() {
        return comments;
    }


    /**
     * Sets the comments value for this ProductGroup.
     * 
     * @param comments
     */
    public void setComments(com.booktera.data.CommonModels_Models_EntityFramework.Comment[] comments) {
        this.comments = comments;
    }


    /**
     * Gets the description value for this ProductGroup.
     * 
     * @return description
     */
    public java.lang.String getDescription() {
        return description;
    }


    /**
     * Sets the description value for this ProductGroup.
     * 
     * @param description
     */
    public void setDescription(java.lang.String description) {
        this.description = description;
    }


    /**
     * Gets the friendlyUrl value for this ProductGroup.
     * 
     * @return friendlyUrl
     */
    public java.lang.String getFriendlyUrl() {
        return friendlyUrl;
    }


    /**
     * Sets the friendlyUrl value for this ProductGroup.
     * 
     * @param friendlyUrl
     */
    public void setFriendlyUrl(java.lang.String friendlyUrl) {
        this.friendlyUrl = friendlyUrl;
    }


    /**
     * Gets the ID value for this ProductGroup.
     * 
     * @return ID
     */
    public java.lang.Integer getID() {
        return ID;
    }


    /**
     * Sets the ID value for this ProductGroup.
     * 
     * @param ID
     */
    public void setID(java.lang.Integer ID) {
        this.ID = ID;
    }


    /**
     * Gets the imageUrl value for this ProductGroup.
     * 
     * @return imageUrl
     */
    public java.lang.String getImageUrl() {
        return imageUrl;
    }


    /**
     * Sets the imageUrl value for this ProductGroup.
     * 
     * @param imageUrl
     */
    public void setImageUrl(java.lang.String imageUrl) {
        this.imageUrl = imageUrl;
    }


    /**
     * Gets the images value for this ProductGroup.
     * 
     * @return images
     */
    public com.booktera.data.CommonModels_Models_EntityFramework.Image[] getImages() {
        return images;
    }


    /**
     * Sets the images value for this ProductGroup.
     * 
     * @param images
     */
    public void setImages(com.booktera.data.CommonModels_Models_EntityFramework.Image[] images) {
        this.images = images;
    }


    /**
     * Gets the isCheckedByAdmin value for this ProductGroup.
     * 
     * @return isCheckedByAdmin
     */
    public java.lang.Boolean getIsCheckedByAdmin() {
        return isCheckedByAdmin;
    }


    /**
     * Sets the isCheckedByAdmin value for this ProductGroup.
     * 
     * @param isCheckedByAdmin
     */
    public void setIsCheckedByAdmin(java.lang.Boolean isCheckedByAdmin) {
        this.isCheckedByAdmin = isCheckedByAdmin;
    }


    /**
     * Gets the maxPrice value for this ProductGroup.
     * 
     * @return maxPrice
     */
    public java.lang.Integer getMaxPrice() {
        return maxPrice;
    }


    /**
     * Sets the maxPrice value for this ProductGroup.
     * 
     * @param maxPrice
     */
    public void setMaxPrice(java.lang.Integer maxPrice) {
        this.maxPrice = maxPrice;
    }


    /**
     * Gets the minPrice value for this ProductGroup.
     * 
     * @return minPrice
     */
    public java.lang.Integer getMinPrice() {
        return minPrice;
    }


    /**
     * Sets the minPrice value for this ProductGroup.
     * 
     * @param minPrice
     */
    public void setMinPrice(java.lang.Integer minPrice) {
        this.minPrice = minPrice;
    }


    /**
     * Gets the productsInGroup value for this ProductGroup.
     * 
     * @return productsInGroup
     */
    public com.booktera.data.CommonModels_Models_EntityFramework.Product[] getProductsInGroup() {
        return productsInGroup;
    }


    /**
     * Sets the productsInGroup value for this ProductGroup.
     * 
     * @param productsInGroup
     */
    public void setProductsInGroup(com.booktera.data.CommonModels_Models_EntityFramework.Product[] productsInGroup) {
        this.productsInGroup = productsInGroup;
    }


    /**
     * Gets the publisher value for this ProductGroup.
     * 
     * @return publisher
     */
    public com.booktera.data.CommonModels_Models_EntityFramework.Publisher getPublisher() {
        return publisher;
    }


    /**
     * Sets the publisher value for this ProductGroup.
     * 
     * @param publisher
     */
    public void setPublisher(com.booktera.data.CommonModels_Models_EntityFramework.Publisher publisher) {
        this.publisher = publisher;
    }


    /**
     * Gets the publisherID value for this ProductGroup.
     * 
     * @return publisherID
     */
    public java.lang.Integer getPublisherID() {
        return publisherID;
    }


    /**
     * Sets the publisherID value for this ProductGroup.
     * 
     * @param publisherID
     */
    public void setPublisherID(java.lang.Integer publisherID) {
        this.publisherID = publisherID;
    }


    /**
     * Gets the publisherName value for this ProductGroup.
     * 
     * @return publisherName
     */
    public java.lang.String getPublisherName() {
        return publisherName;
    }


    /**
     * Sets the publisherName value for this ProductGroup.
     * 
     * @param publisherName
     */
    public void setPublisherName(java.lang.String publisherName) {
        this.publisherName = publisherName;
    }


    /**
     * Gets the ratings value for this ProductGroup.
     * 
     * @return ratings
     */
    public com.booktera.data.CommonModels_Models_EntityFramework.Rating[] getRatings() {
        return ratings;
    }


    /**
     * Sets the ratings value for this ProductGroup.
     * 
     * @param ratings
     */
    public void setRatings(com.booktera.data.CommonModels_Models_EntityFramework.Rating[] ratings) {
        this.ratings = ratings;
    }


    /**
     * Gets the subTitle value for this ProductGroup.
     * 
     * @return subTitle
     */
    public java.lang.String getSubTitle() {
        return subTitle;
    }


    /**
     * Sets the subTitle value for this ProductGroup.
     * 
     * @param subTitle
     */
    public void setSubTitle(java.lang.String subTitle) {
        this.subTitle = subTitle;
    }


    /**
     * Gets the sumOfActiveProductsInGroup value for this ProductGroup.
     * 
     * @return sumOfActiveProductsInGroup
     */
    public java.lang.Integer getSumOfActiveProductsInGroup() {
        return sumOfActiveProductsInGroup;
    }


    /**
     * Sets the sumOfActiveProductsInGroup value for this ProductGroup.
     * 
     * @param sumOfActiveProductsInGroup
     */
    public void setSumOfActiveProductsInGroup(java.lang.Integer sumOfActiveProductsInGroup) {
        this.sumOfActiveProductsInGroup = sumOfActiveProductsInGroup;
    }


    /**
     * Gets the sumOfBuys value for this ProductGroup.
     * 
     * @return sumOfBuys
     */
    public java.lang.Integer getSumOfBuys() {
        return sumOfBuys;
    }


    /**
     * Sets the sumOfBuys value for this ProductGroup.
     * 
     * @param sumOfBuys
     */
    public void setSumOfBuys(java.lang.Integer sumOfBuys) {
        this.sumOfBuys = sumOfBuys;
    }


    /**
     * Gets the sumOfComments value for this ProductGroup.
     * 
     * @return sumOfComments
     */
    public java.lang.Integer getSumOfComments() {
        return sumOfComments;
    }


    /**
     * Sets the sumOfComments value for this ProductGroup.
     * 
     * @param sumOfComments
     */
    public void setSumOfComments(java.lang.Integer sumOfComments) {
        this.sumOfComments = sumOfComments;
    }


    /**
     * Gets the sumOfPassiveProductsInGroup value for this ProductGroup.
     * 
     * @return sumOfPassiveProductsInGroup
     */
    public java.lang.Integer getSumOfPassiveProductsInGroup() {
        return sumOfPassiveProductsInGroup;
    }


    /**
     * Sets the sumOfPassiveProductsInGroup value for this ProductGroup.
     * 
     * @param sumOfPassiveProductsInGroup
     */
    public void setSumOfPassiveProductsInGroup(java.lang.Integer sumOfPassiveProductsInGroup) {
        this.sumOfPassiveProductsInGroup = sumOfPassiveProductsInGroup;
    }


    /**
     * Gets the sumOfRatings value for this ProductGroup.
     * 
     * @return sumOfRatings
     */
    public java.lang.Integer getSumOfRatings() {
        return sumOfRatings;
    }


    /**
     * Sets the sumOfRatings value for this ProductGroup.
     * 
     * @param sumOfRatings
     */
    public void setSumOfRatings(java.lang.Integer sumOfRatings) {
        this.sumOfRatings = sumOfRatings;
    }


    /**
     * Gets the sumOfRatingsValue value for this ProductGroup.
     * 
     * @return sumOfRatingsValue
     */
    public java.lang.Integer getSumOfRatingsValue() {
        return sumOfRatingsValue;
    }


    /**
     * Sets the sumOfRatingsValue value for this ProductGroup.
     * 
     * @param sumOfRatingsValue
     */
    public void setSumOfRatingsValue(java.lang.Integer sumOfRatingsValue) {
        this.sumOfRatingsValue = sumOfRatingsValue;
    }


    /**
     * Gets the sumOfViews value for this ProductGroup.
     * 
     * @return sumOfViews
     */
    public java.lang.Integer getSumOfViews() {
        return sumOfViews;
    }


    /**
     * Sets the sumOfViews value for this ProductGroup.
     * 
     * @param sumOfViews
     */
    public void setSumOfViews(java.lang.Integer sumOfViews) {
        this.sumOfViews = sumOfViews;
    }


    /**
     * Gets the title value for this ProductGroup.
     * 
     * @return title
     */
    public java.lang.String getTitle() {
        return title;
    }


    /**
     * Sets the title value for this ProductGroup.
     * 
     * @param title
     */
    public void setTitle(java.lang.String title) {
        this.title = title;
    }


    /**
     * Gets the uploadedDate value for this ProductGroup.
     * 
     * @return uploadedDate
     */
    public java.util.Calendar getUploadedDate() {
        return uploadedDate;
    }


    /**
     * Sets the uploadedDate value for this ProductGroup.
     * 
     * @param uploadedDate
     */
    public void setUploadedDate(java.util.Calendar uploadedDate) {
        this.uploadedDate = uploadedDate;
    }


    /**
     * Gets the userViews value for this ProductGroup.
     * 
     * @return userViews
     */
    public com.booktera.data.CommonModels_Models_EntityFramework.UserView[] getUserViews() {
        return userViews;
    }


    /**
     * Sets the userViews value for this ProductGroup.
     * 
     * @param userViews
     */
    public void setUserViews(com.booktera.data.CommonModels_Models_EntityFramework.UserView[] userViews) {
        this.userViews = userViews;
    }

    private java.lang.Object __equalsCalc = null;
    public synchronized boolean equals(java.lang.Object obj) {
        if (!(obj instanceof ProductGroup)) return false;
        ProductGroup other = (ProductGroup) obj;
        if (obj == null) return false;
        if (this == obj) return true;
        if (__equalsCalc != null) {
            return (__equalsCalc == obj);
        }
        __equalsCalc = obj;
        boolean _equals;
        _equals = true && 
            ((this.authorNames==null && other.getAuthorNames()==null) || 
             (this.authorNames!=null &&
              this.authorNames.equals(other.getAuthorNames()))) &&
            ((this.authors==null && other.getAuthors()==null) || 
             (this.authors!=null &&
              java.util.Arrays.equals(this.authors, other.getAuthors()))) &&
            ((this.category==null && other.getCategory()==null) || 
             (this.category!=null &&
              this.category.equals(other.getCategory()))) &&
            ((this.categoryID==null && other.getCategoryID()==null) || 
             (this.categoryID!=null &&
              this.categoryID.equals(other.getCategoryID()))) &&
            ((this.changeHistory==null && other.getChangeHistory()==null) || 
             (this.changeHistory!=null &&
              this.changeHistory.equals(other.getChangeHistory()))) &&
            ((this.comments==null && other.getComments()==null) || 
             (this.comments!=null &&
              java.util.Arrays.equals(this.comments, other.getComments()))) &&
            ((this.description==null && other.getDescription()==null) || 
             (this.description!=null &&
              this.description.equals(other.getDescription()))) &&
            ((this.friendlyUrl==null && other.getFriendlyUrl()==null) || 
             (this.friendlyUrl!=null &&
              this.friendlyUrl.equals(other.getFriendlyUrl()))) &&
            ((this.ID==null && other.getID()==null) || 
             (this.ID!=null &&
              this.ID.equals(other.getID()))) &&
            ((this.imageUrl==null && other.getImageUrl()==null) || 
             (this.imageUrl!=null &&
              this.imageUrl.equals(other.getImageUrl()))) &&
            ((this.images==null && other.getImages()==null) || 
             (this.images!=null &&
              java.util.Arrays.equals(this.images, other.getImages()))) &&
            ((this.isCheckedByAdmin==null && other.getIsCheckedByAdmin()==null) || 
             (this.isCheckedByAdmin!=null &&
              this.isCheckedByAdmin.equals(other.getIsCheckedByAdmin()))) &&
            ((this.maxPrice==null && other.getMaxPrice()==null) || 
             (this.maxPrice!=null &&
              this.maxPrice.equals(other.getMaxPrice()))) &&
            ((this.minPrice==null && other.getMinPrice()==null) || 
             (this.minPrice!=null &&
              this.minPrice.equals(other.getMinPrice()))) &&
            ((this.productsInGroup==null && other.getProductsInGroup()==null) || 
             (this.productsInGroup!=null &&
              java.util.Arrays.equals(this.productsInGroup, other.getProductsInGroup()))) &&
            ((this.publisher==null && other.getPublisher()==null) || 
             (this.publisher!=null &&
              this.publisher.equals(other.getPublisher()))) &&
            ((this.publisherID==null && other.getPublisherID()==null) || 
             (this.publisherID!=null &&
              this.publisherID.equals(other.getPublisherID()))) &&
            ((this.publisherName==null && other.getPublisherName()==null) || 
             (this.publisherName!=null &&
              this.publisherName.equals(other.getPublisherName()))) &&
            ((this.ratings==null && other.getRatings()==null) || 
             (this.ratings!=null &&
              java.util.Arrays.equals(this.ratings, other.getRatings()))) &&
            ((this.subTitle==null && other.getSubTitle()==null) || 
             (this.subTitle!=null &&
              this.subTitle.equals(other.getSubTitle()))) &&
            ((this.sumOfActiveProductsInGroup==null && other.getSumOfActiveProductsInGroup()==null) || 
             (this.sumOfActiveProductsInGroup!=null &&
              this.sumOfActiveProductsInGroup.equals(other.getSumOfActiveProductsInGroup()))) &&
            ((this.sumOfBuys==null && other.getSumOfBuys()==null) || 
             (this.sumOfBuys!=null &&
              this.sumOfBuys.equals(other.getSumOfBuys()))) &&
            ((this.sumOfComments==null && other.getSumOfComments()==null) || 
             (this.sumOfComments!=null &&
              this.sumOfComments.equals(other.getSumOfComments()))) &&
            ((this.sumOfPassiveProductsInGroup==null && other.getSumOfPassiveProductsInGroup()==null) || 
             (this.sumOfPassiveProductsInGroup!=null &&
              this.sumOfPassiveProductsInGroup.equals(other.getSumOfPassiveProductsInGroup()))) &&
            ((this.sumOfRatings==null && other.getSumOfRatings()==null) || 
             (this.sumOfRatings!=null &&
              this.sumOfRatings.equals(other.getSumOfRatings()))) &&
            ((this.sumOfRatingsValue==null && other.getSumOfRatingsValue()==null) || 
             (this.sumOfRatingsValue!=null &&
              this.sumOfRatingsValue.equals(other.getSumOfRatingsValue()))) &&
            ((this.sumOfViews==null && other.getSumOfViews()==null) || 
             (this.sumOfViews!=null &&
              this.sumOfViews.equals(other.getSumOfViews()))) &&
            ((this.title==null && other.getTitle()==null) || 
             (this.title!=null &&
              this.title.equals(other.getTitle()))) &&
            ((this.uploadedDate==null && other.getUploadedDate()==null) || 
             (this.uploadedDate!=null &&
              this.uploadedDate.equals(other.getUploadedDate()))) &&
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
        if (getAuthorNames() != null) {
            _hashCode += getAuthorNames().hashCode();
        }
        if (getAuthors() != null) {
            for (int i=0;
                 i<java.lang.reflect.Array.getLength(getAuthors());
                 i++) {
                java.lang.Object obj = java.lang.reflect.Array.get(getAuthors(), i);
                if (obj != null &&
                    !obj.getClass().isArray()) {
                    _hashCode += obj.hashCode();
                }
            }
        }
        if (getCategory() != null) {
            _hashCode += getCategory().hashCode();
        }
        if (getCategoryID() != null) {
            _hashCode += getCategoryID().hashCode();
        }
        if (getChangeHistory() != null) {
            _hashCode += getChangeHistory().hashCode();
        }
        if (getComments() != null) {
            for (int i=0;
                 i<java.lang.reflect.Array.getLength(getComments());
                 i++) {
                java.lang.Object obj = java.lang.reflect.Array.get(getComments(), i);
                if (obj != null &&
                    !obj.getClass().isArray()) {
                    _hashCode += obj.hashCode();
                }
            }
        }
        if (getDescription() != null) {
            _hashCode += getDescription().hashCode();
        }
        if (getFriendlyUrl() != null) {
            _hashCode += getFriendlyUrl().hashCode();
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
        if (getIsCheckedByAdmin() != null) {
            _hashCode += getIsCheckedByAdmin().hashCode();
        }
        if (getMaxPrice() != null) {
            _hashCode += getMaxPrice().hashCode();
        }
        if (getMinPrice() != null) {
            _hashCode += getMinPrice().hashCode();
        }
        if (getProductsInGroup() != null) {
            for (int i=0;
                 i<java.lang.reflect.Array.getLength(getProductsInGroup());
                 i++) {
                java.lang.Object obj = java.lang.reflect.Array.get(getProductsInGroup(), i);
                if (obj != null &&
                    !obj.getClass().isArray()) {
                    _hashCode += obj.hashCode();
                }
            }
        }
        if (getPublisher() != null) {
            _hashCode += getPublisher().hashCode();
        }
        if (getPublisherID() != null) {
            _hashCode += getPublisherID().hashCode();
        }
        if (getPublisherName() != null) {
            _hashCode += getPublisherName().hashCode();
        }
        if (getRatings() != null) {
            for (int i=0;
                 i<java.lang.reflect.Array.getLength(getRatings());
                 i++) {
                java.lang.Object obj = java.lang.reflect.Array.get(getRatings(), i);
                if (obj != null &&
                    !obj.getClass().isArray()) {
                    _hashCode += obj.hashCode();
                }
            }
        }
        if (getSubTitle() != null) {
            _hashCode += getSubTitle().hashCode();
        }
        if (getSumOfActiveProductsInGroup() != null) {
            _hashCode += getSumOfActiveProductsInGroup().hashCode();
        }
        if (getSumOfBuys() != null) {
            _hashCode += getSumOfBuys().hashCode();
        }
        if (getSumOfComments() != null) {
            _hashCode += getSumOfComments().hashCode();
        }
        if (getSumOfPassiveProductsInGroup() != null) {
            _hashCode += getSumOfPassiveProductsInGroup().hashCode();
        }
        if (getSumOfRatings() != null) {
            _hashCode += getSumOfRatings().hashCode();
        }
        if (getSumOfRatingsValue() != null) {
            _hashCode += getSumOfRatingsValue().hashCode();
        }
        if (getSumOfViews() != null) {
            _hashCode += getSumOfViews().hashCode();
        }
        if (getTitle() != null) {
            _hashCode += getTitle().hashCode();
        }
        if (getUploadedDate() != null) {
            _hashCode += getUploadedDate().hashCode();
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
        new org.apache.axis.description.TypeDesc(ProductGroup.class, true);

    static {
        typeDesc.setXmlType(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "ProductGroup"));
        org.apache.axis.description.ElementDesc elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("authorNames");
        elemField.setXmlName(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "AuthorNames"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "string"));
        elemField.setMinOccurs(0);
        elemField.setNillable(true);
        typeDesc.addFieldDesc(elemField);
        elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("authors");
        elemField.setXmlName(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "Authors"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "Author"));
        elemField.setMinOccurs(0);
        elemField.setNillable(true);
        elemField.setItemQName(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "Author"));
        typeDesc.addFieldDesc(elemField);
        elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("category");
        elemField.setXmlName(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "Category"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "Category"));
        elemField.setMinOccurs(0);
        elemField.setNillable(true);
        typeDesc.addFieldDesc(elemField);
        elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("categoryID");
        elemField.setXmlName(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "CategoryID"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "int"));
        elemField.setMinOccurs(0);
        elemField.setNillable(false);
        typeDesc.addFieldDesc(elemField);
        elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("changeHistory");
        elemField.setXmlName(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "ChangeHistory"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "string"));
        elemField.setMinOccurs(0);
        elemField.setNillable(true);
        typeDesc.addFieldDesc(elemField);
        elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("comments");
        elemField.setXmlName(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "Comments"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "Comment"));
        elemField.setMinOccurs(0);
        elemField.setNillable(true);
        elemField.setItemQName(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "Comment"));
        typeDesc.addFieldDesc(elemField);
        elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("description");
        elemField.setXmlName(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "Description"));
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
        elemField.setFieldName("isCheckedByAdmin");
        elemField.setXmlName(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "IsCheckedByAdmin"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "boolean"));
        elemField.setMinOccurs(0);
        elemField.setNillable(false);
        typeDesc.addFieldDesc(elemField);
        elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("maxPrice");
        elemField.setXmlName(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "MaxPrice"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "int"));
        elemField.setMinOccurs(0);
        elemField.setNillable(false);
        typeDesc.addFieldDesc(elemField);
        elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("minPrice");
        elemField.setXmlName(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "MinPrice"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "int"));
        elemField.setMinOccurs(0);
        elemField.setNillable(false);
        typeDesc.addFieldDesc(elemField);
        elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("productsInGroup");
        elemField.setXmlName(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "ProductsInGroup"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "Product"));
        elemField.setMinOccurs(0);
        elemField.setNillable(true);
        elemField.setItemQName(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "Product"));
        typeDesc.addFieldDesc(elemField);
        elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("publisher");
        elemField.setXmlName(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "Publisher"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "Publisher"));
        elemField.setMinOccurs(0);
        elemField.setNillable(true);
        typeDesc.addFieldDesc(elemField);
        elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("publisherID");
        elemField.setXmlName(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "PublisherID"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "int"));
        elemField.setMinOccurs(0);
        elemField.setNillable(false);
        typeDesc.addFieldDesc(elemField);
        elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("publisherName");
        elemField.setXmlName(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "PublisherName"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "string"));
        elemField.setMinOccurs(0);
        elemField.setNillable(true);
        typeDesc.addFieldDesc(elemField);
        elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("ratings");
        elemField.setXmlName(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "Ratings"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "Rating"));
        elemField.setMinOccurs(0);
        elemField.setNillable(true);
        elemField.setItemQName(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "Rating"));
        typeDesc.addFieldDesc(elemField);
        elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("subTitle");
        elemField.setXmlName(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "SubTitle"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "string"));
        elemField.setMinOccurs(0);
        elemField.setNillable(true);
        typeDesc.addFieldDesc(elemField);
        elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("sumOfActiveProductsInGroup");
        elemField.setXmlName(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "SumOfActiveProductsInGroup"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "int"));
        elemField.setMinOccurs(0);
        elemField.setNillable(false);
        typeDesc.addFieldDesc(elemField);
        elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("sumOfBuys");
        elemField.setXmlName(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "SumOfBuys"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "int"));
        elemField.setMinOccurs(0);
        elemField.setNillable(false);
        typeDesc.addFieldDesc(elemField);
        elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("sumOfComments");
        elemField.setXmlName(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "SumOfComments"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "int"));
        elemField.setMinOccurs(0);
        elemField.setNillable(false);
        typeDesc.addFieldDesc(elemField);
        elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("sumOfPassiveProductsInGroup");
        elemField.setXmlName(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "SumOfPassiveProductsInGroup"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "int"));
        elemField.setMinOccurs(0);
        elemField.setNillable(false);
        typeDesc.addFieldDesc(elemField);
        elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("sumOfRatings");
        elemField.setXmlName(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "SumOfRatings"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "int"));
        elemField.setMinOccurs(0);
        elemField.setNillable(false);
        typeDesc.addFieldDesc(elemField);
        elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("sumOfRatingsValue");
        elemField.setXmlName(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "SumOfRatingsValue"));
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
        elemField.setFieldName("title");
        elemField.setXmlName(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "Title"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "string"));
        elemField.setMinOccurs(0);
        elemField.setNillable(true);
        typeDesc.addFieldDesc(elemField);
        elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("uploadedDate");
        elemField.setXmlName(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "UploadedDate"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "dateTime"));
        elemField.setMinOccurs(0);
        elemField.setNillable(false);
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
