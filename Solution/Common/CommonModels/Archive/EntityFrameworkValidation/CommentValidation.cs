using System;
using System.ComponentModel.DataAnnotations;


namespace CommonModels.Models.EntityFramework
{
	[MetadataType(typeof(CommentValidation))]
	public partial class Comment{}

	public class CommentValidation
	{
		#region Visible

		[Required(ErrorMessage = "{0} megad�sa k�telez�")]
		[Display(Name = "Hozz�sz�l�s sz�vege")]
		public string Text { get; set; }

		#endregion
		#region Not visible

		public int ID { get; set; }
		public int UserID { get; set; }
		public DateTime CreatedDate { get; set; }
		public int ProductGroupID { get; set; }
		public int? ParentCommentID { get; set; }

		#endregion

	}
}
