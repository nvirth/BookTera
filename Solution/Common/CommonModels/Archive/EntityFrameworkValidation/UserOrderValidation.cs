using System;
using System.ComponentModel.DataAnnotations;


namespace CommonModels.Models.EntityFramework
{
	[MetadataType(typeof(UserOrderValidation))]
	public partial class UserOrder{}

	public class UserOrderValidation
	{
		#region Not visible

		//public int ID { get; set; }
		//public int UserAddresID { get; set; }
		//public int UserID { get; set; }
		//public int Status { get; set; }
		//public DateTime Date { get; set; }

		#endregion

	}
}
