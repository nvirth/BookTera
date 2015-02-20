using System.ComponentModel.DataAnnotations;


namespace CommonModels.Models.EntityFramework
{
	[MetadataType(typeof(UserGroupValidation))]
	public partial class UserGroup{}

	public class UserGroupValidation
	{
		#region Visible

		[Required(ErrorMessage = "{0} megad�sa k�telez�")]
		[Display(Name = "N�v")]
		public string GroupName { get; set; }

		[Required(ErrorMessage = "{0} megad�sa k�telez�")]
		[Display(Name = "Csoport engedm�nye")]
		public int Allowance { get; set; }

		[Display(Name = "�r")]
		public int Price { get; set; }

		[Display(Name = "H�nap")]
		public byte MonthsToKeepBooks { get; set; }

		[Display(Name = "V�s�rl�si jutal�k")]
		public byte BuyFeePercent { get; set; }

		[Display(Name = "Elad�si jutal�k")]
		public byte SellFeePercent { get; set; }

		#endregion
		#region Not visible

		public int ID { get; set; }

		#endregion
	}
}
