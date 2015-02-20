using System;
using System.ComponentModel.DataAnnotations;


namespace CommonModels.Models.EntityFramework
{
	[MetadataType(typeof(ProductValidation))]
	public partial class Product{}

	public class ProductValidation
	{
		#region Visible

		[Required(ErrorMessage = "{0} megad�sa k�telez�")]
		[Display(Name = "C�m")]
		public string Title { get; set; }

		[Display(Name = "Alc�m")]
		public string SubTitle { get; set; }

		[Required(ErrorMessage = "{0} megad�sa k�telez�")]
		[Display(Name = "Szerz�(k)")]
		public string Author { get; set; }

		[Required(ErrorMessage = "{0} megad�sa k�telez�")]
		[Display(Name = "R�vid �sszefoglal�")]
		public string Description { get; set; }

		[Required(ErrorMessage = "{0} megad�sa k�telez�")]
		[Display(Name = "Kiad�s �ve")]
		public int PublishYear { get; set; }

		[Required(ErrorMessage = "{0} megad�sa k�telez�")]
		[Display(Name = "Oldalsz�m")]
		public int PageNumber { get; set; }

		[Required(ErrorMessage = "{0} megad�sa k�telez�")]
		[Display(Name = "�r")]
		public int Price { get; set; }

		[Display(Name = "Akci�s �r")]
		public int? DiscountPrice { get; set; }

		[Required(ErrorMessage = "{0} megad�sa k�telez�")]
		[Display(Name = "Mennyis�g")]
		public int HowMany { get; set; }

		public bool IsPhysical { get; set; }
		public bool IsElectronic { get; set; }
		public bool IsBook { get; set; }
		public bool IsAudio { get; set; }
		public bool IsVideo { get; set; }
		public bool IsUsed { get; set; }

		[Display(Name = "Tartalmaz m�st is")]
		public bool ContainsOther { get; set; }

		#endregion
		#region Not visible

		public int ID { get; set; }
		public int PublisherID { get; set; }
		public int UserID { get; set; }
		public int CategoryID { get; set; }
		public string FriendlyUrl { get; set; }
		public DateTime UploadedDate { get; set; }
		public int SumOfViews { get; set; }
		public int SumOfBuys { get; set; }
		public int SumOfRating { get; set; }
		public int SumOfRatingsValue { get; set; }
		public int SumOfComment { get; set; }
		public int SumOfDedicatory { get; set; }

		#endregion

	}
}
