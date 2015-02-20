using System.ComponentModel.DataAnnotations;


namespace CommonModels.Models.EntityFramework
{
	[MetadataType(typeof(UserAddressValidation))]
	public partial class UserAddress{}

	public class UserAddressValidation
	{
		#region Visible

		[Required(ErrorMessage = "{0} megad�sa k�telez�")]
		[Display(Name = "Ir�ny�t�sz�m")]
		public string ZipCode { get; set; }

		[Required(ErrorMessage = "{0} megad�sa k�telez�")]
		[Display(Name = "Telep�l�s")]
		public string City { get; set; }

		[Required(ErrorMessage = "{0} megad�sa k�telez�")]
		[Display(Name = "Utca, h�zsz�m")]
		public string StreetAndHouseNumber { get; set; }

		[Required(ErrorMessage = "{0} megad�sa k�telez�")]
		[Display(Name = "Orsz�g")]
		public string Country { get; set; }

		#endregion
		#region Not visible

		//public int ID { get; set; }
		//public int UserID { get; set; }

		#endregion
	}
}
