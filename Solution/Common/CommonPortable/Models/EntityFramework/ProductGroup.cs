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
	using System.Collections.Generic;
    
    public partial class ProductGroup
    {
        public ProductGroup()
        {
            this.Comments = new HashSet<Comment>();
            this.Images = new HashSet<Image>();
            this.ProductsInGroup = new HashSet<Product>();
            this.Ratings = new HashSet<Rating>();
            this.UserViews = new HashSet<UserView>();
            this.Authors = new HashSet<Author>();
        }
    
        public int ID { get; set; }
        public int PublisherID { get; set; }
        public int CategoryID { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string FriendlyUrl { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
        public string AuthorNames { get; set; }
        public string PublisherName { get; set; }
        public string ChangeHistory { get; set; }
        public int MinPrice { get; set; }
        public int MaxPrice { get; set; }
        public int SumOfActiveProductsInGroup { get; set; }
        public int SumOfPassiveProductsInGroup { get; set; }
        public int SumOfViews { get; set; }
        public int SumOfBuys { get; set; }
        public int SumOfRatings { get; set; }
        public int SumOfRatingsValue { get; set; }
        public int SumOfComments { get; set; }
        public bool IsCheckedByAdmin { get; set; }
        public System.DateTime UploadedDate { get; set; }
    
        public virtual Category Category { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Image> Images { get; set; }
        public virtual ICollection<Product> ProductsInGroup { get; set; }
        public virtual Publisher Publisher { get; set; }
        public virtual ICollection<Rating> Ratings { get; set; }
        public virtual ICollection<UserView> UserViews { get; set; }
        public virtual ICollection<Author> Authors { get; set; }
    }
}
