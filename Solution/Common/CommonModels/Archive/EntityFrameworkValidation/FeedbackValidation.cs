using System;
using System.ComponentModel.DataAnnotations;

namespace CommonModels.Models.EntityFramework
{
	[MetadataType(typeof(FeedbackValidation))]
	public partial class Feedback{}

	public class FeedbackValidation
    {
		#region Not visible

		public int ID { get; set; }
		public int UserOrderID { get; set; }
		public int RateGiverUserID { get; set; }
		public int RatedUserID { get; set; }
		public bool IsCustomers { get; set; }
		public bool? IsPositive { get; set; }
		public bool WasSuccessful { get; set; }
		public byte ProductsQuality { get; set; }
		public byte SellerContact { get; set; }
		public byte TransactionQuality { get; set; }
		public byte TransportAndBoxing { get; set; }
		public DateTime Date { get; set; }
		public string Description { get; set; }

		#endregion
    }
}
