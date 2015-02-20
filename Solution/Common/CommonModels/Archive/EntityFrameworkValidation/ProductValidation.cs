using System;
using System.ComponentModel.DataAnnotations;


namespace CommonModels.Models.EntityFramework
{
	[MetadataType(typeof(ProductValidation))]
	public partial class Product{}

	public class ProductValidation
	{
		#region Visible

		[Required(ErrorMessage = "{0} megadása kötelezõ")]
		[Display(Name = "Cím")]
		public string Title { get; set; }

		[Display(Name = "Alcím")]
		public string SubTitle { get; set; }

		[Required(ErrorMessage = "{0} megadása kötelezõ")]
		[Display(Name = "Szerzõ(k)")]
		public string Author { get; set; }

		[Required(ErrorMessage = "{0} megadása kötelezõ")]
		[Display(Name = "Rövid összefoglaló")]
		public string Description { get; set; }

		[Required(ErrorMessage = "{0} megadása kötelezõ")]
		[Display(Name = "Kiadás éve")]
		public int PublishYear { get; set; }

		[Required(ErrorMessage = "{0} megadása kötelezõ")]
		[Display(Name = "Oldalszám")]
		public int PageNumber { get; set; }

		[Required(ErrorMessage = "{0} megadása kötelezõ")]
		[Display(Name = "Ár")]
		public int Price { get; set; }

		[Display(Name = "Akciós ár")]
		public int? DiscountPrice { get; set; }

		[Required(ErrorMessage = "{0} megadása kötelezõ")]
		[Display(Name = "Mennyiség")]
		public int HowMany { get; set; }

		public bool IsPhysical { get; set; }
		public bool IsElectronic { get; set; }
		public bool IsBook { get; set; }
		public bool IsAudio { get; set; }
		public bool IsVideo { get; set; }
		public bool IsUsed { get; set; }

		[Display(Name = "Tartalmaz mást is")]
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
