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
    
    public partial class Comment
    {
        public Comment()
        {
            this.ChildComments = new HashSet<Comment>();
        }
    
        public int ID { get; set; }
        public int ProductGroupID { get; set; }
        public int UserID { get; set; }
        public Nullable<int> ParentCommentID { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public string Text { get; set; }
    
        public virtual ICollection<Comment> ChildComments { get; set; }
        public virtual Comment ParentComment { get; set; }
        public virtual ProductGroup ProductGroup { get; set; }
        public virtual UserProfile UserProfile { get; set; }
    }
}
