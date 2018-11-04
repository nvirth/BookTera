/**
 * UserProfile.java
 *
 * This file was auto-generated from WSDL
 * by the Apache Axis 1.4 Apr 22, 2006 (06:55:48 PDT) WSDL2Java emitter.
 */

package com.booktera.data.CommonModels_Models_EntityFramework;

public class UserProfile  implements java.io.Serializable {
    private java.lang.Integer balance;

    private com.booktera.data.CommonModels_Models_EntityFramework.Comment[] comments;

    private java.lang.Integer defaultAddressID;

    private com.booktera.data.CommonModels_Models_EntityFramework.UserAddress defaultUserAddress;

    private java.lang.String EMail;

    private com.booktera.data.CommonModels_Models_EntityFramework.Feedback[] feedbacksByRateGiverUser;

    private com.booktera.data.CommonModels_Models_EntityFramework.Feedback[] feedbacksByRatedUser;

    private java.lang.String friendlyUrl;

    private java.lang.String fullName;

    private java.lang.Integer ID;

    private java.lang.String imageUrl;

    private com.booktera.data.CommonModels_Models_EntityFramework.Image[] images;

    private java.lang.Boolean isAuthor;

    private java.lang.Boolean isPublisher;

    private java.util.Calendar lastLoginDate;

    private java.lang.String phoneNumber;

    private java.util.Calendar previousLoginDate;

    private com.booktera.data.CommonModels_Models_EntityFramework.Product[] products;

    private com.booktera.data.CommonModels_Models_EntityFramework.Rating[] ratings;

    private java.util.Calendar registrationDate;

    private java.lang.Integer sumOfActiveProducts;

    private java.lang.Integer sumOfBuys;

    private java.lang.Integer sumOfBuysInProgress;

    private java.lang.Integer sumOfFeedbacks;

    private java.lang.Integer sumOfFeedbacksValue;

    private java.lang.Integer sumOfNeededFeedbacks;

    private java.lang.Integer sumOfPassiveProducts;

    private java.lang.Integer sumOfSells;

    private java.lang.Integer sumOfSellsInProgress;

    private com.booktera.data.CommonModels_Models_EntityFramework.UserAddress[] userAddresses;

    private com.booktera.data.CommonModels_Models_EntityFramework.UserGroup userGroup;

    private java.lang.Integer userGroupID;

    private java.lang.String userName;

    private com.booktera.data.CommonModels_Models_EntityFramework.UserOrder[] userOrderByCustomer;

    private com.booktera.data.CommonModels_Models_EntityFramework.UserOrder[] userOrderByVendor;

    private com.booktera.data.CommonModels_Models_EntityFramework.UserView[] userViews;

    private com.booktera.data.CommonModels_Models_EntityFramework.Webpages_Roles[] webpages_Roles;

    public UserProfile() {
    }

    public UserProfile(
           java.lang.Integer balance,
           com.booktera.data.CommonModels_Models_EntityFramework.Comment[] comments,
           java.lang.Integer defaultAddressID,
           com.booktera.data.CommonModels_Models_EntityFramework.UserAddress defaultUserAddress,
           java.lang.String EMail,
           com.booktera.data.CommonModels_Models_EntityFramework.Feedback[] feedbacksByRateGiverUser,
           com.booktera.data.CommonModels_Models_EntityFramework.Feedback[] feedbacksByRatedUser,
           java.lang.String friendlyUrl,
           java.lang.String fullName,
           java.lang.Integer ID,
           java.lang.String imageUrl,
           com.booktera.data.CommonModels_Models_EntityFramework.Image[] images,
           java.lang.Boolean isAuthor,
           java.lang.Boolean isPublisher,
           java.util.Calendar lastLoginDate,
           java.lang.String phoneNumber,
           java.util.Calendar previousLoginDate,
           com.booktera.data.CommonModels_Models_EntityFramework.Product[] products,
           com.booktera.data.CommonModels_Models_EntityFramework.Rating[] ratings,
           java.util.Calendar registrationDate,
           java.lang.Integer sumOfActiveProducts,
           java.lang.Integer sumOfBuys,
           java.lang.Integer sumOfBuysInProgress,
           java.lang.Integer sumOfFeedbacks,
           java.lang.Integer sumOfFeedbacksValue,
           java.lang.Integer sumOfNeededFeedbacks,
           java.lang.Integer sumOfPassiveProducts,
           java.lang.Integer sumOfSells,
           java.lang.Integer sumOfSellsInProgress,
           com.booktera.data.CommonModels_Models_EntityFramework.UserAddress[] userAddresses,
           com.booktera.data.CommonModels_Models_EntityFramework.UserGroup userGroup,
           java.lang.Integer userGroupID,
           java.lang.String userName,
           com.booktera.data.CommonModels_Models_EntityFramework.UserOrder[] userOrderByCustomer,
           com.booktera.data.CommonModels_Models_EntityFramework.UserOrder[] userOrderByVendor,
           com.booktera.data.CommonModels_Models_EntityFramework.UserView[] userViews,
           com.booktera.data.CommonModels_Models_EntityFramework.Webpages_Roles[] webpages_Roles) {
           this.balance = balance;
           this.comments = comments;
           this.defaultAddressID = defaultAddressID;
           this.defaultUserAddress = defaultUserAddress;
           this.EMail = EMail;
           this.feedbacksByRateGiverUser = feedbacksByRateGiverUser;
           this.feedbacksByRatedUser = feedbacksByRatedUser;
           this.friendlyUrl = friendlyUrl;
           this.fullName = fullName;
           this.ID = ID;
           this.imageUrl = imageUrl;
           this.images = images;
           this.isAuthor = isAuthor;
           this.isPublisher = isPublisher;
           this.lastLoginDate = lastLoginDate;
           this.phoneNumber = phoneNumber;
           this.previousLoginDate = previousLoginDate;
           this.products = products;
           this.ratings = ratings;
           this.registrationDate = registrationDate;
           this.sumOfActiveProducts = sumOfActiveProducts;
           this.sumOfBuys = sumOfBuys;
           this.sumOfBuysInProgress = sumOfBuysInProgress;
           this.sumOfFeedbacks = sumOfFeedbacks;
           this.sumOfFeedbacksValue = sumOfFeedbacksValue;
           this.sumOfNeededFeedbacks = sumOfNeededFeedbacks;
           this.sumOfPassiveProducts = sumOfPassiveProducts;
           this.sumOfSells = sumOfSells;
           this.sumOfSellsInProgress = sumOfSellsInProgress;
           this.userAddresses = userAddresses;
           this.userGroup = userGroup;
           this.userGroupID = userGroupID;
           this.userName = userName;
           this.userOrderByCustomer = userOrderByCustomer;
           this.userOrderByVendor = userOrderByVendor;
           this.userViews = userViews;
           this.webpages_Roles = webpages_Roles;
    }


    /**
     * Gets the balance value for this UserProfile.
     * 
     * @return balance
     */
    public java.lang.Integer getBalance() {
        return balance;
    }


    /**
     * Sets the balance value for this UserProfile.
     * 
     * @param balance
     */
    public void setBalance(java.lang.Integer balance) {
        this.balance = balance;
    }


    /**
     * Gets the comments value for this UserProfile.
     * 
     * @return comments
     */
    public com.booktera.data.CommonModels_Models_EntityFramework.Comment[] getComments() {
        return comments;
    }


    /**
     * Sets the comments value for this UserProfile.
     * 
     * @param comments
     */
    public void setComments(com.booktera.data.CommonModels_Models_EntityFramework.Comment[] comments) {
        this.comments = comments;
    }


    /**
     * Gets the defaultAddressID value for this UserProfile.
     * 
     * @return defaultAddressID
     */
    public java.lang.Integer getDefaultAddressID() {
        return defaultAddressID;
    }


    /**
     * Sets the defaultAddressID value for this UserProfile.
     * 
     * @param defaultAddressID
     */
    public void setDefaultAddressID(java.lang.Integer defaultAddressID) {
        this.defaultAddressID = defaultAddressID;
    }


    /**
     * Gets the defaultUserAddress value for this UserProfile.
     * 
     * @return defaultUserAddress
     */
    public com.booktera.data.CommonModels_Models_EntityFramework.UserAddress getDefaultUserAddress() {
        return defaultUserAddress;
    }


    /**
     * Sets the defaultUserAddress value for this UserProfile.
     * 
     * @param defaultUserAddress
     */
    public void setDefaultUserAddress(com.booktera.data.CommonModels_Models_EntityFramework.UserAddress defaultUserAddress) {
        this.defaultUserAddress = defaultUserAddress;
    }


    /**
     * Gets the EMail value for this UserProfile.
     * 
     * @return EMail
     */
    public java.lang.String getEMail() {
        return EMail;
    }


    /**
     * Sets the EMail value for this UserProfile.
     * 
     * @param EMail
     */
    public void setEMail(java.lang.String EMail) {
        this.EMail = EMail;
    }


    /**
     * Gets the feedbacksByRateGiverUser value for this UserProfile.
     * 
     * @return feedbacksByRateGiverUser
     */
    public com.booktera.data.CommonModels_Models_EntityFramework.Feedback[] getFeedbacksByRateGiverUser() {
        return feedbacksByRateGiverUser;
    }


    /**
     * Sets the feedbacksByRateGiverUser value for this UserProfile.
     * 
     * @param feedbacksByRateGiverUser
     */
    public void setFeedbacksByRateGiverUser(com.booktera.data.CommonModels_Models_EntityFramework.Feedback[] feedbacksByRateGiverUser) {
        this.feedbacksByRateGiverUser = feedbacksByRateGiverUser;
    }


    /**
     * Gets the feedbacksByRatedUser value for this UserProfile.
     * 
     * @return feedbacksByRatedUser
     */
    public com.booktera.data.CommonModels_Models_EntityFramework.Feedback[] getFeedbacksByRatedUser() {
        return feedbacksByRatedUser;
    }


    /**
     * Sets the feedbacksByRatedUser value for this UserProfile.
     * 
     * @param feedbacksByRatedUser
     */
    public void setFeedbacksByRatedUser(com.booktera.data.CommonModels_Models_EntityFramework.Feedback[] feedbacksByRatedUser) {
        this.feedbacksByRatedUser = feedbacksByRatedUser;
    }


    /**
     * Gets the friendlyUrl value for this UserProfile.
     * 
     * @return friendlyUrl
     */
    public java.lang.String getFriendlyUrl() {
        return friendlyUrl;
    }


    /**
     * Sets the friendlyUrl value for this UserProfile.
     * 
     * @param friendlyUrl
     */
    public void setFriendlyUrl(java.lang.String friendlyUrl) {
        this.friendlyUrl = friendlyUrl;
    }


    /**
     * Gets the fullName value for this UserProfile.
     * 
     * @return fullName
     */
    public java.lang.String getFullName() {
        return fullName;
    }


    /**
     * Sets the fullName value for this UserProfile.
     * 
     * @param fullName
     */
    public void setFullName(java.lang.String fullName) {
        this.fullName = fullName;
    }


    /**
     * Gets the ID value for this UserProfile.
     * 
     * @return ID
     */
    public java.lang.Integer getID() {
        return ID;
    }


    /**
     * Sets the ID value for this UserProfile.
     * 
     * @param ID
     */
    public void setID(java.lang.Integer ID) {
        this.ID = ID;
    }


    /**
     * Gets the imageUrl value for this UserProfile.
     * 
     * @return imageUrl
     */
    public java.lang.String getImageUrl() {
        return imageUrl;
    }


    /**
     * Sets the imageUrl value for this UserProfile.
     * 
     * @param imageUrl
     */
    public void setImageUrl(java.lang.String imageUrl) {
        this.imageUrl = imageUrl;
    }


    /**
     * Gets the images value for this UserProfile.
     * 
     * @return images
     */
    public com.booktera.data.CommonModels_Models_EntityFramework.Image[] getImages() {
        return images;
    }


    /**
     * Sets the images value for this UserProfile.
     * 
     * @param images
     */
    public void setImages(com.booktera.data.CommonModels_Models_EntityFramework.Image[] images) {
        this.images = images;
    }


    /**
     * Gets the isAuthor value for this UserProfile.
     * 
     * @return isAuthor
     */
    public java.lang.Boolean getIsAuthor() {
        return isAuthor;
    }


    /**
     * Sets the isAuthor value for this UserProfile.
     * 
     * @param isAuthor
     */
    public void setIsAuthor(java.lang.Boolean isAuthor) {
        this.isAuthor = isAuthor;
    }


    /**
     * Gets the isPublisher value for this UserProfile.
     * 
     * @return isPublisher
     */
    public java.lang.Boolean getIsPublisher() {
        return isPublisher;
    }


    /**
     * Sets the isPublisher value for this UserProfile.
     * 
     * @param isPublisher
     */
    public void setIsPublisher(java.lang.Boolean isPublisher) {
        this.isPublisher = isPublisher;
    }


    /**
     * Gets the lastLoginDate value for this UserProfile.
     * 
     * @return lastLoginDate
     */
    public java.util.Calendar getLastLoginDate() {
        return lastLoginDate;
    }


    /**
     * Sets the lastLoginDate value for this UserProfile.
     * 
     * @param lastLoginDate
     */
    public void setLastLoginDate(java.util.Calendar lastLoginDate) {
        this.lastLoginDate = lastLoginDate;
    }


    /**
     * Gets the phoneNumber value for this UserProfile.
     * 
     * @return phoneNumber
     */
    public java.lang.String getPhoneNumber() {
        return phoneNumber;
    }


    /**
     * Sets the phoneNumber value for this UserProfile.
     * 
     * @param phoneNumber
     */
    public void setPhoneNumber(java.lang.String phoneNumber) {
        this.phoneNumber = phoneNumber;
    }


    /**
     * Gets the previousLoginDate value for this UserProfile.
     * 
     * @return previousLoginDate
     */
    public java.util.Calendar getPreviousLoginDate() {
        return previousLoginDate;
    }


    /**
     * Sets the previousLoginDate value for this UserProfile.
     * 
     * @param previousLoginDate
     */
    public void setPreviousLoginDate(java.util.Calendar previousLoginDate) {
        this.previousLoginDate = previousLoginDate;
    }


    /**
     * Gets the products value for this UserProfile.
     * 
     * @return products
     */
    public com.booktera.data.CommonModels_Models_EntityFramework.Product[] getProducts() {
        return products;
    }


    /**
     * Sets the products value for this UserProfile.
     * 
     * @param products
     */
    public void setProducts(com.booktera.data.CommonModels_Models_EntityFramework.Product[] products) {
        this.products = products;
    }


    /**
     * Gets the ratings value for this UserProfile.
     * 
     * @return ratings
     */
    public com.booktera.data.CommonModels_Models_EntityFramework.Rating[] getRatings() {
        return ratings;
    }


    /**
     * Sets the ratings value for this UserProfile.
     * 
     * @param ratings
     */
    public void setRatings(com.booktera.data.CommonModels_Models_EntityFramework.Rating[] ratings) {
        this.ratings = ratings;
    }


    /**
     * Gets the registrationDate value for this UserProfile.
     * 
     * @return registrationDate
     */
    public java.util.Calendar getRegistrationDate() {
        return registrationDate;
    }


    /**
     * Sets the registrationDate value for this UserProfile.
     * 
     * @param registrationDate
     */
    public void setRegistrationDate(java.util.Calendar registrationDate) {
        this.registrationDate = registrationDate;
    }


    /**
     * Gets the sumOfActiveProducts value for this UserProfile.
     * 
     * @return sumOfActiveProducts
     */
    public java.lang.Integer getSumOfActiveProducts() {
        return sumOfActiveProducts;
    }


    /**
     * Sets the sumOfActiveProducts value for this UserProfile.
     * 
     * @param sumOfActiveProducts
     */
    public void setSumOfActiveProducts(java.lang.Integer sumOfActiveProducts) {
        this.sumOfActiveProducts = sumOfActiveProducts;
    }


    /**
     * Gets the sumOfBuys value for this UserProfile.
     * 
     * @return sumOfBuys
     */
    public java.lang.Integer getSumOfBuys() {
        return sumOfBuys;
    }


    /**
     * Sets the sumOfBuys value for this UserProfile.
     * 
     * @param sumOfBuys
     */
    public void setSumOfBuys(java.lang.Integer sumOfBuys) {
        this.sumOfBuys = sumOfBuys;
    }


    /**
     * Gets the sumOfBuysInProgress value for this UserProfile.
     * 
     * @return sumOfBuysInProgress
     */
    public java.lang.Integer getSumOfBuysInProgress() {
        return sumOfBuysInProgress;
    }


    /**
     * Sets the sumOfBuysInProgress value for this UserProfile.
     * 
     * @param sumOfBuysInProgress
     */
    public void setSumOfBuysInProgress(java.lang.Integer sumOfBuysInProgress) {
        this.sumOfBuysInProgress = sumOfBuysInProgress;
    }


    /**
     * Gets the sumOfFeedbacks value for this UserProfile.
     * 
     * @return sumOfFeedbacks
     */
    public java.lang.Integer getSumOfFeedbacks() {
        return sumOfFeedbacks;
    }


    /**
     * Sets the sumOfFeedbacks value for this UserProfile.
     * 
     * @param sumOfFeedbacks
     */
    public void setSumOfFeedbacks(java.lang.Integer sumOfFeedbacks) {
        this.sumOfFeedbacks = sumOfFeedbacks;
    }


    /**
     * Gets the sumOfFeedbacksValue value for this UserProfile.
     * 
     * @return sumOfFeedbacksValue
     */
    public java.lang.Integer getSumOfFeedbacksValue() {
        return sumOfFeedbacksValue;
    }


    /**
     * Sets the sumOfFeedbacksValue value for this UserProfile.
     * 
     * @param sumOfFeedbacksValue
     */
    public void setSumOfFeedbacksValue(java.lang.Integer sumOfFeedbacksValue) {
        this.sumOfFeedbacksValue = sumOfFeedbacksValue;
    }


    /**
     * Gets the sumOfNeededFeedbacks value for this UserProfile.
     * 
     * @return sumOfNeededFeedbacks
     */
    public java.lang.Integer getSumOfNeededFeedbacks() {
        return sumOfNeededFeedbacks;
    }


    /**
     * Sets the sumOfNeededFeedbacks value for this UserProfile.
     * 
     * @param sumOfNeededFeedbacks
     */
    public void setSumOfNeededFeedbacks(java.lang.Integer sumOfNeededFeedbacks) {
        this.sumOfNeededFeedbacks = sumOfNeededFeedbacks;
    }


    /**
     * Gets the sumOfPassiveProducts value for this UserProfile.
     * 
     * @return sumOfPassiveProducts
     */
    public java.lang.Integer getSumOfPassiveProducts() {
        return sumOfPassiveProducts;
    }


    /**
     * Sets the sumOfPassiveProducts value for this UserProfile.
     * 
     * @param sumOfPassiveProducts
     */
    public void setSumOfPassiveProducts(java.lang.Integer sumOfPassiveProducts) {
        this.sumOfPassiveProducts = sumOfPassiveProducts;
    }


    /**
     * Gets the sumOfSells value for this UserProfile.
     * 
     * @return sumOfSells
     */
    public java.lang.Integer getSumOfSells() {
        return sumOfSells;
    }


    /**
     * Sets the sumOfSells value for this UserProfile.
     * 
     * @param sumOfSells
     */
    public void setSumOfSells(java.lang.Integer sumOfSells) {
        this.sumOfSells = sumOfSells;
    }


    /**
     * Gets the sumOfSellsInProgress value for this UserProfile.
     * 
     * @return sumOfSellsInProgress
     */
    public java.lang.Integer getSumOfSellsInProgress() {
        return sumOfSellsInProgress;
    }


    /**
     * Sets the sumOfSellsInProgress value for this UserProfile.
     * 
     * @param sumOfSellsInProgress
     */
    public void setSumOfSellsInProgress(java.lang.Integer sumOfSellsInProgress) {
        this.sumOfSellsInProgress = sumOfSellsInProgress;
    }


    /**
     * Gets the userAddresses value for this UserProfile.
     * 
     * @return userAddresses
     */
    public com.booktera.data.CommonModels_Models_EntityFramework.UserAddress[] getUserAddresses() {
        return userAddresses;
    }


    /**
     * Sets the userAddresses value for this UserProfile.
     * 
     * @param userAddresses
     */
    public void setUserAddresses(com.booktera.data.CommonModels_Models_EntityFramework.UserAddress[] userAddresses) {
        this.userAddresses = userAddresses;
    }


    /**
     * Gets the userGroup value for this UserProfile.
     * 
     * @return userGroup
     */
    public com.booktera.data.CommonModels_Models_EntityFramework.UserGroup getUserGroup() {
        return userGroup;
    }


    /**
     * Sets the userGroup value for this UserProfile.
     * 
     * @param userGroup
     */
    public void setUserGroup(com.booktera.data.CommonModels_Models_EntityFramework.UserGroup userGroup) {
        this.userGroup = userGroup;
    }


    /**
     * Gets the userGroupID value for this UserProfile.
     * 
     * @return userGroupID
     */
    public java.lang.Integer getUserGroupID() {
        return userGroupID;
    }


    /**
     * Sets the userGroupID value for this UserProfile.
     * 
     * @param userGroupID
     */
    public void setUserGroupID(java.lang.Integer userGroupID) {
        this.userGroupID = userGroupID;
    }


    /**
     * Gets the userName value for this UserProfile.
     * 
     * @return userName
     */
    public java.lang.String getUserName() {
        return userName;
    }


    /**
     * Sets the userName value for this UserProfile.
     * 
     * @param userName
     */
    public void setUserName(java.lang.String userName) {
        this.userName = userName;
    }


    /**
     * Gets the userOrderByCustomer value for this UserProfile.
     * 
     * @return userOrderByCustomer
     */
    public com.booktera.data.CommonModels_Models_EntityFramework.UserOrder[] getUserOrderByCustomer() {
        return userOrderByCustomer;
    }


    /**
     * Sets the userOrderByCustomer value for this UserProfile.
     * 
     * @param userOrderByCustomer
     */
    public void setUserOrderByCustomer(com.booktera.data.CommonModels_Models_EntityFramework.UserOrder[] userOrderByCustomer) {
        this.userOrderByCustomer = userOrderByCustomer;
    }


    /**
     * Gets the userOrderByVendor value for this UserProfile.
     * 
     * @return userOrderByVendor
     */
    public com.booktera.data.CommonModels_Models_EntityFramework.UserOrder[] getUserOrderByVendor() {
        return userOrderByVendor;
    }


    /**
     * Sets the userOrderByVendor value for this UserProfile.
     * 
     * @param userOrderByVendor
     */
    public void setUserOrderByVendor(com.booktera.data.CommonModels_Models_EntityFramework.UserOrder[] userOrderByVendor) {
        this.userOrderByVendor = userOrderByVendor;
    }


    /**
     * Gets the userViews value for this UserProfile.
     * 
     * @return userViews
     */
    public com.booktera.data.CommonModels_Models_EntityFramework.UserView[] getUserViews() {
        return userViews;
    }


    /**
     * Sets the userViews value for this UserProfile.
     * 
     * @param userViews
     */
    public void setUserViews(com.booktera.data.CommonModels_Models_EntityFramework.UserView[] userViews) {
        this.userViews = userViews;
    }


    /**
     * Gets the webpages_Roles value for this UserProfile.
     * 
     * @return webpages_Roles
     */
    public com.booktera.data.CommonModels_Models_EntityFramework.Webpages_Roles[] getWebpages_Roles() {
        return webpages_Roles;
    }


    /**
     * Sets the webpages_Roles value for this UserProfile.
     * 
     * @param webpages_Roles
     */
    public void setWebpages_Roles(com.booktera.data.CommonModels_Models_EntityFramework.Webpages_Roles[] webpages_Roles) {
        this.webpages_Roles = webpages_Roles;
    }

    private java.lang.Object __equalsCalc = null;
    public synchronized boolean equals(java.lang.Object obj) {
        if (!(obj instanceof UserProfile)) return false;
        UserProfile other = (UserProfile) obj;
        if (obj == null) return false;
        if (this == obj) return true;
        if (__equalsCalc != null) {
            return (__equalsCalc == obj);
        }
        __equalsCalc = obj;
        boolean _equals;
        _equals = true && 
            ((this.balance==null && other.getBalance()==null) || 
             (this.balance!=null &&
              this.balance.equals(other.getBalance()))) &&
            ((this.comments==null && other.getComments()==null) || 
             (this.comments!=null &&
              java.util.Arrays.equals(this.comments, other.getComments()))) &&
            ((this.defaultAddressID==null && other.getDefaultAddressID()==null) || 
             (this.defaultAddressID!=null &&
              this.defaultAddressID.equals(other.getDefaultAddressID()))) &&
            ((this.defaultUserAddress==null && other.getDefaultUserAddress()==null) || 
             (this.defaultUserAddress!=null &&
              this.defaultUserAddress.equals(other.getDefaultUserAddress()))) &&
            ((this.EMail==null && other.getEMail()==null) || 
             (this.EMail!=null &&
              this.EMail.equals(other.getEMail()))) &&
            ((this.feedbacksByRateGiverUser==null && other.getFeedbacksByRateGiverUser()==null) || 
             (this.feedbacksByRateGiverUser!=null &&
              java.util.Arrays.equals(this.feedbacksByRateGiverUser, other.getFeedbacksByRateGiverUser()))) &&
            ((this.feedbacksByRatedUser==null && other.getFeedbacksByRatedUser()==null) || 
             (this.feedbacksByRatedUser!=null &&
              java.util.Arrays.equals(this.feedbacksByRatedUser, other.getFeedbacksByRatedUser()))) &&
            ((this.friendlyUrl==null && other.getFriendlyUrl()==null) || 
             (this.friendlyUrl!=null &&
              this.friendlyUrl.equals(other.getFriendlyUrl()))) &&
            ((this.fullName==null && other.getFullName()==null) || 
             (this.fullName!=null &&
              this.fullName.equals(other.getFullName()))) &&
            ((this.ID==null && other.getID()==null) || 
             (this.ID!=null &&
              this.ID.equals(other.getID()))) &&
            ((this.imageUrl==null && other.getImageUrl()==null) || 
             (this.imageUrl!=null &&
              this.imageUrl.equals(other.getImageUrl()))) &&
            ((this.images==null && other.getImages()==null) || 
             (this.images!=null &&
              java.util.Arrays.equals(this.images, other.getImages()))) &&
            ((this.isAuthor==null && other.getIsAuthor()==null) || 
             (this.isAuthor!=null &&
              this.isAuthor.equals(other.getIsAuthor()))) &&
            ((this.isPublisher==null && other.getIsPublisher()==null) || 
             (this.isPublisher!=null &&
              this.isPublisher.equals(other.getIsPublisher()))) &&
            ((this.lastLoginDate==null && other.getLastLoginDate()==null) || 
             (this.lastLoginDate!=null &&
              this.lastLoginDate.equals(other.getLastLoginDate()))) &&
            ((this.phoneNumber==null && other.getPhoneNumber()==null) || 
             (this.phoneNumber!=null &&
              this.phoneNumber.equals(other.getPhoneNumber()))) &&
            ((this.previousLoginDate==null && other.getPreviousLoginDate()==null) || 
             (this.previousLoginDate!=null &&
              this.previousLoginDate.equals(other.getPreviousLoginDate()))) &&
            ((this.products==null && other.getProducts()==null) || 
             (this.products!=null &&
              java.util.Arrays.equals(this.products, other.getProducts()))) &&
            ((this.ratings==null && other.getRatings()==null) || 
             (this.ratings!=null &&
              java.util.Arrays.equals(this.ratings, other.getRatings()))) &&
            ((this.registrationDate==null && other.getRegistrationDate()==null) || 
             (this.registrationDate!=null &&
              this.registrationDate.equals(other.getRegistrationDate()))) &&
            ((this.sumOfActiveProducts==null && other.getSumOfActiveProducts()==null) || 
             (this.sumOfActiveProducts!=null &&
              this.sumOfActiveProducts.equals(other.getSumOfActiveProducts()))) &&
            ((this.sumOfBuys==null && other.getSumOfBuys()==null) || 
             (this.sumOfBuys!=null &&
              this.sumOfBuys.equals(other.getSumOfBuys()))) &&
            ((this.sumOfBuysInProgress==null && other.getSumOfBuysInProgress()==null) || 
             (this.sumOfBuysInProgress!=null &&
              this.sumOfBuysInProgress.equals(other.getSumOfBuysInProgress()))) &&
            ((this.sumOfFeedbacks==null && other.getSumOfFeedbacks()==null) || 
             (this.sumOfFeedbacks!=null &&
              this.sumOfFeedbacks.equals(other.getSumOfFeedbacks()))) &&
            ((this.sumOfFeedbacksValue==null && other.getSumOfFeedbacksValue()==null) || 
             (this.sumOfFeedbacksValue!=null &&
              this.sumOfFeedbacksValue.equals(other.getSumOfFeedbacksValue()))) &&
            ((this.sumOfNeededFeedbacks==null && other.getSumOfNeededFeedbacks()==null) || 
             (this.sumOfNeededFeedbacks!=null &&
              this.sumOfNeededFeedbacks.equals(other.getSumOfNeededFeedbacks()))) &&
            ((this.sumOfPassiveProducts==null && other.getSumOfPassiveProducts()==null) || 
             (this.sumOfPassiveProducts!=null &&
              this.sumOfPassiveProducts.equals(other.getSumOfPassiveProducts()))) &&
            ((this.sumOfSells==null && other.getSumOfSells()==null) || 
             (this.sumOfSells!=null &&
              this.sumOfSells.equals(other.getSumOfSells()))) &&
            ((this.sumOfSellsInProgress==null && other.getSumOfSellsInProgress()==null) || 
             (this.sumOfSellsInProgress!=null &&
              this.sumOfSellsInProgress.equals(other.getSumOfSellsInProgress()))) &&
            ((this.userAddresses==null && other.getUserAddresses()==null) || 
             (this.userAddresses!=null &&
              java.util.Arrays.equals(this.userAddresses, other.getUserAddresses()))) &&
            ((this.userGroup==null && other.getUserGroup()==null) || 
             (this.userGroup!=null &&
              this.userGroup.equals(other.getUserGroup()))) &&
            ((this.userGroupID==null && other.getUserGroupID()==null) || 
             (this.userGroupID!=null &&
              this.userGroupID.equals(other.getUserGroupID()))) &&
            ((this.userName==null && other.getUserName()==null) || 
             (this.userName!=null &&
              this.userName.equals(other.getUserName()))) &&
            ((this.userOrderByCustomer==null && other.getUserOrderByCustomer()==null) || 
             (this.userOrderByCustomer!=null &&
              java.util.Arrays.equals(this.userOrderByCustomer, other.getUserOrderByCustomer()))) &&
            ((this.userOrderByVendor==null && other.getUserOrderByVendor()==null) || 
             (this.userOrderByVendor!=null &&
              java.util.Arrays.equals(this.userOrderByVendor, other.getUserOrderByVendor()))) &&
            ((this.userViews==null && other.getUserViews()==null) || 
             (this.userViews!=null &&
              java.util.Arrays.equals(this.userViews, other.getUserViews()))) &&
            ((this.webpages_Roles==null && other.getWebpages_Roles()==null) || 
             (this.webpages_Roles!=null &&
              java.util.Arrays.equals(this.webpages_Roles, other.getWebpages_Roles())));
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
        if (getBalance() != null) {
            _hashCode += getBalance().hashCode();
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
        if (getDefaultAddressID() != null) {
            _hashCode += getDefaultAddressID().hashCode();
        }
        if (getDefaultUserAddress() != null) {
            _hashCode += getDefaultUserAddress().hashCode();
        }
        if (getEMail() != null) {
            _hashCode += getEMail().hashCode();
        }
        if (getFeedbacksByRateGiverUser() != null) {
            for (int i=0;
                 i<java.lang.reflect.Array.getLength(getFeedbacksByRateGiverUser());
                 i++) {
                java.lang.Object obj = java.lang.reflect.Array.get(getFeedbacksByRateGiverUser(), i);
                if (obj != null &&
                    !obj.getClass().isArray()) {
                    _hashCode += obj.hashCode();
                }
            }
        }
        if (getFeedbacksByRatedUser() != null) {
            for (int i=0;
                 i<java.lang.reflect.Array.getLength(getFeedbacksByRatedUser());
                 i++) {
                java.lang.Object obj = java.lang.reflect.Array.get(getFeedbacksByRatedUser(), i);
                if (obj != null &&
                    !obj.getClass().isArray()) {
                    _hashCode += obj.hashCode();
                }
            }
        }
        if (getFriendlyUrl() != null) {
            _hashCode += getFriendlyUrl().hashCode();
        }
        if (getFullName() != null) {
            _hashCode += getFullName().hashCode();
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
        if (getIsAuthor() != null) {
            _hashCode += getIsAuthor().hashCode();
        }
        if (getIsPublisher() != null) {
            _hashCode += getIsPublisher().hashCode();
        }
        if (getLastLoginDate() != null) {
            _hashCode += getLastLoginDate().hashCode();
        }
        if (getPhoneNumber() != null) {
            _hashCode += getPhoneNumber().hashCode();
        }
        if (getPreviousLoginDate() != null) {
            _hashCode += getPreviousLoginDate().hashCode();
        }
        if (getProducts() != null) {
            for (int i=0;
                 i<java.lang.reflect.Array.getLength(getProducts());
                 i++) {
                java.lang.Object obj = java.lang.reflect.Array.get(getProducts(), i);
                if (obj != null &&
                    !obj.getClass().isArray()) {
                    _hashCode += obj.hashCode();
                }
            }
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
        if (getRegistrationDate() != null) {
            _hashCode += getRegistrationDate().hashCode();
        }
        if (getSumOfActiveProducts() != null) {
            _hashCode += getSumOfActiveProducts().hashCode();
        }
        if (getSumOfBuys() != null) {
            _hashCode += getSumOfBuys().hashCode();
        }
        if (getSumOfBuysInProgress() != null) {
            _hashCode += getSumOfBuysInProgress().hashCode();
        }
        if (getSumOfFeedbacks() != null) {
            _hashCode += getSumOfFeedbacks().hashCode();
        }
        if (getSumOfFeedbacksValue() != null) {
            _hashCode += getSumOfFeedbacksValue().hashCode();
        }
        if (getSumOfNeededFeedbacks() != null) {
            _hashCode += getSumOfNeededFeedbacks().hashCode();
        }
        if (getSumOfPassiveProducts() != null) {
            _hashCode += getSumOfPassiveProducts().hashCode();
        }
        if (getSumOfSells() != null) {
            _hashCode += getSumOfSells().hashCode();
        }
        if (getSumOfSellsInProgress() != null) {
            _hashCode += getSumOfSellsInProgress().hashCode();
        }
        if (getUserAddresses() != null) {
            for (int i=0;
                 i<java.lang.reflect.Array.getLength(getUserAddresses());
                 i++) {
                java.lang.Object obj = java.lang.reflect.Array.get(getUserAddresses(), i);
                if (obj != null &&
                    !obj.getClass().isArray()) {
                    _hashCode += obj.hashCode();
                }
            }
        }
        if (getUserGroup() != null) {
            _hashCode += getUserGroup().hashCode();
        }
        if (getUserGroupID() != null) {
            _hashCode += getUserGroupID().hashCode();
        }
        if (getUserName() != null) {
            _hashCode += getUserName().hashCode();
        }
        if (getUserOrderByCustomer() != null) {
            for (int i=0;
                 i<java.lang.reflect.Array.getLength(getUserOrderByCustomer());
                 i++) {
                java.lang.Object obj = java.lang.reflect.Array.get(getUserOrderByCustomer(), i);
                if (obj != null &&
                    !obj.getClass().isArray()) {
                    _hashCode += obj.hashCode();
                }
            }
        }
        if (getUserOrderByVendor() != null) {
            for (int i=0;
                 i<java.lang.reflect.Array.getLength(getUserOrderByVendor());
                 i++) {
                java.lang.Object obj = java.lang.reflect.Array.get(getUserOrderByVendor(), i);
                if (obj != null &&
                    !obj.getClass().isArray()) {
                    _hashCode += obj.hashCode();
                }
            }
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
        if (getWebpages_Roles() != null) {
            for (int i=0;
                 i<java.lang.reflect.Array.getLength(getWebpages_Roles());
                 i++) {
                java.lang.Object obj = java.lang.reflect.Array.get(getWebpages_Roles(), i);
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
        new org.apache.axis.description.TypeDesc(UserProfile.class, true);

    static {
        typeDesc.setXmlType(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "UserProfile"));
        org.apache.axis.description.ElementDesc elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("balance");
        elemField.setXmlName(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "Balance"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "int"));
        elemField.setMinOccurs(0);
        elemField.setNillable(false);
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
        elemField.setFieldName("defaultAddressID");
        elemField.setXmlName(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "DefaultAddressID"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "int"));
        elemField.setMinOccurs(0);
        elemField.setNillable(true);
        typeDesc.addFieldDesc(elemField);
        elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("defaultUserAddress");
        elemField.setXmlName(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "DefaultUserAddress"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "UserAddress"));
        elemField.setMinOccurs(0);
        elemField.setNillable(true);
        typeDesc.addFieldDesc(elemField);
        elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("EMail");
        elemField.setXmlName(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "EMail"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "string"));
        elemField.setMinOccurs(0);
        elemField.setNillable(true);
        typeDesc.addFieldDesc(elemField);
        elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("feedbacksByRateGiverUser");
        elemField.setXmlName(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "FeedbacksByRateGiverUser"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "Feedback"));
        elemField.setMinOccurs(0);
        elemField.setNillable(true);
        elemField.setItemQName(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "Feedback"));
        typeDesc.addFieldDesc(elemField);
        elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("feedbacksByRatedUser");
        elemField.setXmlName(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "FeedbacksByRatedUser"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "Feedback"));
        elemField.setMinOccurs(0);
        elemField.setNillable(true);
        elemField.setItemQName(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "Feedback"));
        typeDesc.addFieldDesc(elemField);
        elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("friendlyUrl");
        elemField.setXmlName(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "FriendlyUrl"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "string"));
        elemField.setMinOccurs(0);
        elemField.setNillable(true);
        typeDesc.addFieldDesc(elemField);
        elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("fullName");
        elemField.setXmlName(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "FullName"));
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
        elemField.setFieldName("isAuthor");
        elemField.setXmlName(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "IsAuthor"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "boolean"));
        elemField.setMinOccurs(0);
        elemField.setNillable(false);
        typeDesc.addFieldDesc(elemField);
        elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("isPublisher");
        elemField.setXmlName(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "IsPublisher"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "boolean"));
        elemField.setMinOccurs(0);
        elemField.setNillable(false);
        typeDesc.addFieldDesc(elemField);
        elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("lastLoginDate");
        elemField.setXmlName(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "LastLoginDate"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "dateTime"));
        elemField.setMinOccurs(0);
        elemField.setNillable(false);
        typeDesc.addFieldDesc(elemField);
        elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("phoneNumber");
        elemField.setXmlName(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "PhoneNumber"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "string"));
        elemField.setMinOccurs(0);
        elemField.setNillable(true);
        typeDesc.addFieldDesc(elemField);
        elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("previousLoginDate");
        elemField.setXmlName(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "PreviousLoginDate"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "dateTime"));
        elemField.setMinOccurs(0);
        elemField.setNillable(false);
        typeDesc.addFieldDesc(elemField);
        elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("products");
        elemField.setXmlName(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "Products"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "Product"));
        elemField.setMinOccurs(0);
        elemField.setNillable(true);
        elemField.setItemQName(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "Product"));
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
        elemField.setFieldName("registrationDate");
        elemField.setXmlName(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "RegistrationDate"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "dateTime"));
        elemField.setMinOccurs(0);
        elemField.setNillable(false);
        typeDesc.addFieldDesc(elemField);
        elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("sumOfActiveProducts");
        elemField.setXmlName(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "SumOfActiveProducts"));
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
        elemField.setFieldName("sumOfBuysInProgress");
        elemField.setXmlName(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "SumOfBuysInProgress"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "int"));
        elemField.setMinOccurs(0);
        elemField.setNillable(false);
        typeDesc.addFieldDesc(elemField);
        elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("sumOfFeedbacks");
        elemField.setXmlName(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "SumOfFeedbacks"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "int"));
        elemField.setMinOccurs(0);
        elemField.setNillable(false);
        typeDesc.addFieldDesc(elemField);
        elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("sumOfFeedbacksValue");
        elemField.setXmlName(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "SumOfFeedbacksValue"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "int"));
        elemField.setMinOccurs(0);
        elemField.setNillable(false);
        typeDesc.addFieldDesc(elemField);
        elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("sumOfNeededFeedbacks");
        elemField.setXmlName(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "SumOfNeededFeedbacks"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "int"));
        elemField.setMinOccurs(0);
        elemField.setNillable(false);
        typeDesc.addFieldDesc(elemField);
        elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("sumOfPassiveProducts");
        elemField.setXmlName(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "SumOfPassiveProducts"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "int"));
        elemField.setMinOccurs(0);
        elemField.setNillable(false);
        typeDesc.addFieldDesc(elemField);
        elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("sumOfSells");
        elemField.setXmlName(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "SumOfSells"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "int"));
        elemField.setMinOccurs(0);
        elemField.setNillable(false);
        typeDesc.addFieldDesc(elemField);
        elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("sumOfSellsInProgress");
        elemField.setXmlName(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "SumOfSellsInProgress"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "int"));
        elemField.setMinOccurs(0);
        elemField.setNillable(false);
        typeDesc.addFieldDesc(elemField);
        elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("userAddresses");
        elemField.setXmlName(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "UserAddresses"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "UserAddress"));
        elemField.setMinOccurs(0);
        elemField.setNillable(true);
        elemField.setItemQName(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "UserAddress"));
        typeDesc.addFieldDesc(elemField);
        elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("userGroup");
        elemField.setXmlName(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "UserGroup"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "UserGroup"));
        elemField.setMinOccurs(0);
        elemField.setNillable(true);
        typeDesc.addFieldDesc(elemField);
        elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("userGroupID");
        elemField.setXmlName(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "UserGroupID"));
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
        elemField.setFieldName("userOrderByCustomer");
        elemField.setXmlName(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "UserOrderByCustomer"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "UserOrder"));
        elemField.setMinOccurs(0);
        elemField.setNillable(true);
        elemField.setItemQName(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "UserOrder"));
        typeDesc.addFieldDesc(elemField);
        elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("userOrderByVendor");
        elemField.setXmlName(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "UserOrderByVendor"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "UserOrder"));
        elemField.setMinOccurs(0);
        elemField.setNillable(true);
        elemField.setItemQName(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "UserOrder"));
        typeDesc.addFieldDesc(elemField);
        elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("userViews");
        elemField.setXmlName(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "UserViews"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "UserView"));
        elemField.setMinOccurs(0);
        elemField.setNillable(true);
        elemField.setItemQName(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "UserView"));
        typeDesc.addFieldDesc(elemField);
        elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("webpages_Roles");
        elemField.setXmlName(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "webpages_Roles"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "webpages_Roles"));
        elemField.setMinOccurs(0);
        elemField.setNillable(true);
        elemField.setItemQName(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/CommonModels.Models.EntityFramework", "webpages_Roles"));
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
