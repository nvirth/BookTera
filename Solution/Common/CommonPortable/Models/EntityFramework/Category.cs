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
    
    public partial class Category
    {
        public Category()
        {
            this.ChildCategories = new HashSet<Category>();
            this.ProductGroupsInCategory = new HashSet<ProductGroup>();
        }
    
        public int ID { get; set; }
        public Nullable<int> ParentCategoryID { get; set; }
        public string DisplayName { get; set; }
        public string FullPath { get; set; }
        public string FriendlyUrl { get; set; }
        public string Sort { get; set; }
        public bool IsParent { get; set; }
    
        public virtual ICollection<Category> ChildCategories { get; set; }
        public virtual Category ParentCategory { get; set; }
        public virtual ICollection<ProductGroup> ProductGroupsInCategory { get; set; }
    }
}
