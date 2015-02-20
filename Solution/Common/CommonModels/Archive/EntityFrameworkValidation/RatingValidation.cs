using System;
using System.ComponentModel.DataAnnotations;


namespace CommonModels.Models.EntityFramework
{
	[MetadataType(typeof(RatingValidation))]
	public partial class Rating{}

	public class RatingValidation
	{
		#region Visible

		[Display(Name = "Értékelés")]
		public int Value { get; set; }

		#endregion
		#region Not visible

		public int ID { get; set; }
		public int ProductID { get; set; }
		public int UserID { get; set; }
		public DateTime Date { get; set; }

		#endregion

	}
}
