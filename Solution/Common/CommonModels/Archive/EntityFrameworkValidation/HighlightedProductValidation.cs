using System;
using System.ComponentModel.DataAnnotations;


namespace CommonModels.Models.EntityFramework
{
	[MetadataType(typeof(HighlightedProductValidation))]
	public partial class HighlightedProduct{}

	public class HighlightedProductValidation
	{
		#region Visible

		[Required(ErrorMessage = "{0} megad�sa k�telez�")]
		[Display(Name = "T�pus")]
		public int HighlightTypeID { get; set; }

		#endregion
		#region Not visible

		public int ID { get; set; }
		public int ProductID { get; set; }
		public DateTime FromDate { get; set; }
		public DateTime ToDate { get; set; }

		#endregion
	}
}
