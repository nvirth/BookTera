using System;
using System.ComponentModel.DataAnnotations;

namespace CommonModels.Models.EntityFramework
{
	[MetadataType(typeof(UserViewProductValidation))]
	public partial class UserViewProduct{}

	public class UserViewProductValidation
	{
		#region Not visible

		public int ID { get; set; }
		public int? UserID { get; set; }
		public int ProductID { get; set; }
		public DateTime LastDate { get; set; }
		public int HowMany { get; set; }

		#endregion

	}
}
