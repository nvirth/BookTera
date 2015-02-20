using System;
using System.ComponentModel.DataAnnotations;


namespace CommonModels.Models.EntityFramework
{
	[MetadataType(typeof(CategoryValidation))]
	public partial class Category{}

	public class CategoryValidation
	{
		#region Visible

		[Required(ErrorMessage = "{0} megadása kötelezõ")]
		[Display(Name = "Név")]
		public string DisplayName { get; set; }

		[Display(Name = "Szülõ kategória")]
		public int? ParentCategoryID { get; set; }

		#endregion
		#region Not visible

		public int ID { get; set; }
		public string FriendlyUrl { get; set; }
		public string Sort { get; set; }
		public string FullPath { get; set; }
		public bool IsParent { get; set; }

		#endregion
	}
}