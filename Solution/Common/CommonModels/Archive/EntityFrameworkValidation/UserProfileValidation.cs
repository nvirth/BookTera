using System.ComponentModel.DataAnnotations;


namespace CommonModels.Models.EntityFramework
{
	//[Bind(Exclude = "ID, UserGroupID, DefaultAddressID, LastLoginDate, RegistrationDate,UserName")]
	public class UserProfileValidation
	{
		#region Visible

		[Required(ErrorMessage = "{0} megadása kötelezõ")]
		[StringLength(30, ErrorMessage = "A {0} legalább {2}, legfeljebb {1} karakter hosszú kell legyen.", MinimumLength = 4)]
		[RegularExpression(@"^\w*$", ErrorMessage = "A {0} csak kis és nagybetüket, illetve számokat tartalmazhat!")]
		[Display(Name = "Felhasználó név")]
		public string UserName { get; set; }

		[Required(ErrorMessage = "{0} megadása kötelezõ")]
		[Display(Name = "E-mail cím")]
		[RegularExpression(@"^[\w@.]*$", ErrorMessage = "A(z) {0} csak kis és nagybetüket, számokat, \"@\" és \".\" karaktereket tartalmazhat!")]
		[StringLength(50, ErrorMessage = "A(z) {0} legalább {2}, legfeljebb {1} karakter hosszú kell legyen.", MinimumLength = 6)]
		public string EMail { get; set; }

		[Required(ErrorMessage = "{0} megadása kötelezõ")]
		[Display(Name = "Teljes név")]
		[RegularExpression(@"^\w*$", ErrorMessage = "A {0} csak kis és nagybetüket, illetve számokat tartalmazhat!")]
		[StringLength(50, ErrorMessage = "A(z) {0} legalább {2}, legfeljebb {1} karakter hosszú kell legyen.", MinimumLength = 3)]
		public string FullName { get; set; }

		[Display(Name = "Telefonszám")]
		[StringLength(12, ErrorMessage = "A(z) {0} legalább {2}, legfeljebb {1} karakter hosszú kell legyen.", MinimumLength = 6)]
		[RegularExpression(@"^[0-9]*$", ErrorMessage = "A {0} megadásában elválasztók nem használhatók, formátuma: 06551234567")]
		public string PhoneNumber { get; set; }

		[Display(Name = "Kép")]
		public string ImageUrl { get; set; }

		#endregion
		#region Not visible

		//public int ID { get; set; }
		//public int UserGroupID { get; set; }
		//public int? DefaultAddressID { get; set; }
		//public DateTime LastLoginDate { get; set; }
		//public DateTime RegistrationDate { get; set; }

		#endregion
	}

	[MetadataType(typeof(UserProfileValidation))]
	public partial class UserProfile{}
}
