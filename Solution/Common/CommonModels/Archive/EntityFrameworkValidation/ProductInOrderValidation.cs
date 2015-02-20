using System.ComponentModel.DataAnnotations;


namespace CommonModels.Models.EntityFramework
{
	[MetadataType(typeof(ProductInOrderValidation))]
	public partial class ProductInOrder{}

	public class ProductInOrderValidation
	{
		#region Not visible

		public int ID { get; set; }
		public int ProductID { get; set; }
		public int UserOrderID { get; set; }
		public int HowMany { get; set; }
		public int UnitPrice { get; set; }
		public bool IsForExchange { get; set; }

		#endregion
	}
}
