﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------


namespace DAL.EntityFramework
{
	using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using CommonModels.Models.EntityFramework;
    
    public partial class DBEntities : DbContext
    {
        public DBEntities()
            : base("name=DBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<Author> Author { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Comment> Comment { get; set; }
        public DbSet<Feedback> Feedback { get; set; }
        public DbSet<HighlightedProduct> HighlightedProduct { get; set; }
        public DbSet<HighlightType> HighlightType { get; set; }
        public DbSet<Image> Image { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<ProductGroup> ProductGroup { get; set; }
        public DbSet<ProductInOrder> ProductInOrder { get; set; }
        public DbSet<Publisher> Publisher { get; set; }
        public DbSet<Rating> Rating { get; set; }
        public DbSet<UserAddress> UserAddress { get; set; }
        public DbSet<UserGroup> UserGroup { get; set; }
        public DbSet<UserOrder> UserOrder { get; set; }
        public DbSet<UserProfile> UserProfile { get; set; }
        public DbSet<UserView> UserView { get; set; }
        public DbSet<webpages_Membership> webpages_Membership { get; set; }
        public DbSet<webpages_OAuthMembership> webpages_OAuthMembership { get; set; }
        public DbSet<webpages_Roles> webpages_Roles { get; set; }
    }
}
