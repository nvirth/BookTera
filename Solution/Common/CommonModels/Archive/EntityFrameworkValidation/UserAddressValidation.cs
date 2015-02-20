using System.ComponentModel.DataAnnotations;


namespace CommonModels.Models.EntityFramework
{
	[MetadataType(typeof(UserAddressValidation))]
	public partial class UserAddress{}

	public class UserAddressValidation
	{
		#region Visible

		[Required(ErrorMessage = "{0} megadása kötelezõ")]
		[Display(Name = "Irányítószám")]
		public string ZipCode { get; set; }

		[Required(ErrorMessage = "{0} megadása kötelezõ")]
		[Display(Name = "Település")]
		public string City { get; set; }

		[Required(ErrorMessage = "{0} megadása kötelezõ")]
		[Display(Name = "Utca, házszám")]
		public string StreetAndHouseNumber { get; set; }

		[Required(ErrorMessage = "{0} megadása kötelezõ")]
		[Display(Name = "Ország")]
		public string Country { get; set; }

		#endregion
		#region Not visible

		//public int ID { get; set; }
		//public int UserID { get; set; }

		#endregion
	}
}
