using System;
using System.ComponentModel.DataAnnotations;


namespace CommonModels.Models.EntityFramework
{
	[MetadataType(typeof(AuthorValidation))]
	public partial class Author{}

	public class AuthorValidation
	{
		#region Visible

		[Display(Name = "N�v")]
		[Required(ErrorMessage = "{0} megad�sa k�telez�")]
		public string DisplayName { get; set; }

		[Display(Name = "Le�r�s")]
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
