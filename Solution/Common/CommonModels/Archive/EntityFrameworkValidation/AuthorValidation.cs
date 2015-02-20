using System;
using System.ComponentModel.DataAnnotations;


namespace CommonModels.Models.EntityFramework
{
	[MetadataType(typeof(AuthorValidation))]
	public partial class Author{}

	public class AuthorValidation
	{
		#region Visible

		[Display(Name = "Név")]
		[Required(ErrorMessage = "{0} megadása kötelezõ")]
		public string DisplayName { get; set; }

		[Display(Name = "Leírás")]
		public string About { get; set; }

		#endregion
		#region Not visible

		public int ID { get; set; }
		public string FriendlyUrl { get; set; }
		public int? UserID { get; set; }
		public bool IsCheckedByAdmin { get; set; }

		#endregion

	}
}
