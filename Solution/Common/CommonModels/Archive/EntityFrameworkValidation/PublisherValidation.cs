using System.ComponentModel.DataAnnotations;


namespace CommonModels.Models.EntityFramework
{
	[MetadataType(typeof(PublisherValidation))]
	public partial class Publisher{}

	public class PublisherValidation
	{
		#region Visible

		[Required(ErrorMessage = "{0} megadása kötelezõ")]
		[Display(Name = "Név")]
		public string DisplayName { get; set; }

		[Display(Name = "Szerzõrõl")]
		public string About { get; set; }

		#endregion
		#region Not visible

		public int ID { get; set; }
		public string FriendlyUrl { get; set; }
		public int? UserID { get; set; }

		#endregion

	}
}
