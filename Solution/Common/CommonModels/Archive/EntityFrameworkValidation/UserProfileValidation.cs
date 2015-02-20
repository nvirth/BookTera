using System.ComponentModel.DataAnnotations;


namespace CommonModels.Models.EntityFramework
{
	//[Bind(Exclude = "ID, UserGroupID, DefaultAddressID, LastLoginDate, RegistrationDate,UserName")]
	public class UserProfileValidation
	{
		#region Visible

		[Required(ErrorMessage = "{0} megad�sa k�telez�")]
		[StringLength(30, ErrorMessage = "A {0} legal�bb {2}, legfeljebb {1} karakter hossz� kell legyen.", MinimumLength = 4)]
		[RegularExpression(@"^\w*$", ErrorMessage = "A {0} csak kis �s nagybet�ket, illetve sz�mokat tartalmazhat!")]
		[Display(Name = "Felhaszn�l� n�v")]
		public string UserName { get; set; }

		[Required(ErrorMessage = "{0} megad�sa k�telez�")]
		[Display(Name = "E-mail c�m")]
		[RegularExpression(@"^[\w@.]*$", ErrorMessage = "A(z) {0} csak kis �s nagybet�ket, sz�mokat, \"@\" �s \".\" karaktereket tartalmazhat!")]
		[StringLength(50, ErrorMessage = "A(z) {0} legal�bb {2}, legfeljebb {1} karakter hossz� kell legyen.", MinimumLength = 6)]
		public string EMail { get; set; }

		[Required(ErrorMessage = "{0} megad�sa k�telez�")]
		[Display(Name = "Teljes n�v")]
		[RegularExpression(@"^\w*$", ErrorMessage = "A {0} csak kis �s nagybet�ket, illetve sz�mokat tartalmazhat!")]
		[StringLength(50, ErrorMessage = "A(z) {0} legal�bb {2}, legfeljebb {1} karakter hossz� kell legyen.", MinimumLength = 3)]
		public string FullName { get; set; }

		[Display(Name = "Telefonsz�m")]
		[StringLength(12, ErrorMessage = "A(z) {0} legal�bb {2}, legfeljebb {1} karakter hossz� kell legyen.", MinimumLength = 6)]
		[RegularExpression(@"^[0-9]*$", ErrorMessage = "A {0} megad�s�ban elv�laszt�k nem haszn�lhat�k, form�tuma: 06551234567")]
		public string PhoneNumber { get; set; }

		[Display(Name = "K�p")]
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
