//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CommonModels.Models.EntityFramework
{
    using System;
    using System.Collections.Generic;
    
    public partial class UserProfile
    {
        public UserProfile()
        {
            this.Comments = new HashSet<Comment>();
            this.FeedbacksByRateGiverUser = new HashSet<Feedback>();
            this.FeedbacksByRatedUser = new HashSet<Feedback>();
            this.Images = new HashSet<Image>();
            this.Products = new HashSet<Product>();
            this.Ratings = new HashSet<Rating>();
            this.UserAddresses = new HashSet<UserAddress>();
            this.UserOrderByCustomer = new HashSet<UserOrder>();
            this.UserOrderByVendor = new HashSet<UserOrder>();
            this.UserViews = new HashSet<UserView>();
            this.webpages_Roles = new HashSet<webpages_Roles>();
        }
    
        public int ID { get; set; }
        public int UserGroupID { get; set; }
        public Nullable<int> DefaultAddressID { get; set; }
        public string PhoneNumber { get; set; }
        public string EMail { get; set; }
        public string ImageUrl { get; set; }
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string FriendlyUrl { get; set; }
        public System.DateTime LastLoginDate { get; set; }
        public System.DateTime PreviousLoginDate { get; set; }
        public System.DateTime RegistrationDate { get; set; }
        public int SumOfSells { get; set; }
        public int SumOfSellsInProgress { get; set; }
        public int SumOfBuys { get; set; }
        public int SumOfBuysInProgress { get; set; }
        public int SumOfNeededFeedbacks { get; set; }
        public int SumOfFeedbacks { get; set; }
        public int SumOfFeedbacksValue { get; set; }
        public int SumOfActiveProducts { get; set; }
        public int SumOfPassiveProducts { get; set; }
        public bool IsAuthor { get; set; }
        public bool IsPublisher { get; set; }
        public int Balance { get; set; }
    
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Feedback> FeedbacksByRateGiverUser { get; set; }
        public virtual ICollection<Feedback> FeedbacksByRatedUser { get; set; }
        public virtual ICollection<Image> Images { get; set; }
        public virtual ICollection<Product> Products { get; set; }
        public virtual ICollection<Rating> Ratings { get; set; }
        public virtual UserAddress DefaultUserAddress { get; set; }
        public virtual ICollection<UserAddress> UserAddresses { get; set; }
        public virtual UserGroup UserGroup { get; set; }
        public virtual ICollection<UserOrder> UserOrderByCustomer { get; set; }
        public virtual ICollection<UserOrder> UserOrderByVendor { get; set; }
        public virtual ICollection<UserView> UserViews { get; set; }
        public virtual ICollection<webpages_Roles> webpages_Roles { get; set; }
    }
}
