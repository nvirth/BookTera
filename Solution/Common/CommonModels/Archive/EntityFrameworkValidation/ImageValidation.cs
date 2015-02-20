using System;
using System.ComponentModel.DataAnnotations;


namespace CommonModels.Models.EntityFramework
{
	[MetadataType(typeof(ImageValidation))]
	public partial class Image{}

	public class ImageValidation
	{
		#region Visible

		[Required(ErrorMessage = "{0} megadása kötelezõ")]
		[Display(Name = "Kép")]
		public string Url { get; set; }

		#endregion
		#region Not visible

		public int ID { get; set; }
		public Nullable<int> UserID { get; set; }
		public Nullable<int> ProductID { get; set; }
		public Nullable<int> ProductGroupID { get; set; }
		public bool IsDefault { get; set; }

		#endregion
	}
}
