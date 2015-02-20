using System.ComponentModel.DataAnnotations;


namespace CommonModels.Models.EntityFramework
{
	[MetadataType(typeof(UserGroupValidation))]
	public partial class UserGroup{}

	public class UserGroupValidation
	{
		#region Visible

		[Required(ErrorMessage = "{0} megadása kötelezõ")]
		[Display(Name = "Név")]
		public string GroupName { get; set; }

		[Required(ErrorMessage = "{0} megadása kötelezõ")]
		[Display(Name = "Csoport engedménye")]
		public int Allowance { get; set; }

		[Display(Name = "Ár")]
		public int Price { get; set; }

		[Display(Name = "Hónap")]
		public byte MonthsToKeepBooks { get; set; }

		[Display(Name = "Vásárlási jutalék")]
		public byte BuyFeePercent { get; set; }

		[Display(Name = "Eladási jutalék")]
		public byte SellFeePercent { get; set; }

		#endregion
		#region Not visible

		public int ID { get; set; }

		#endregion
	}
}
