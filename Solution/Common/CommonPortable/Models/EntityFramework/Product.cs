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
    
    public partial class Product
    {
        public Product()
        {
            this.ProductsHighlights = new HashSet<HighlightedProduct>();
            this.Images = new HashSet<Image>();
            this.ProductByOrder = new HashSet<ProductInOrder>();
            this.UserViews = new HashSet<UserView>();
        }
    
        public int ID { get; set; }
        public int ProductGroupID { get; set; }
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string Language { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
        public System.DateTime UploadedDate { get; set; }
        public string ChangeHistory { get; set; }
        public int PublishYear { get; set; }
        public int PageNumber { get; set; }
        public int Price { get; set; }
        public int SumOfViews { get; set; }
        public int HowMany { get; set; }
        public int Edition { get; set; }
        public bool IsDownloadable { get; set; }
        public bool IsBook { get; set; }
        public bool IsAudio { get; set; }
        public bool IsVideo { get; set; }
        public bool IsUsed { get; set; }
        public bool IsCheckedByAdmin { get; set; }
        public bool ContainsOther { get; set; }
    
        public virtual ICollection<HighlightedProduct> ProductsHighlights { get; set; }
        public virtual ICollection<Image> Images { get; set; }
        public virtual ProductGroup ProductGroup { get; set; }
        public virtual UserProfile UserProfile { get; set; }
        public virtual ICollection<ProductInOrder> ProductByOrder { get; set; }
        public virtual ICollection<UserView> UserViews { get; set; }
    }
}
