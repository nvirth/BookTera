using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using UtilsLocal;

namespace CommonModels.Models.AccountModels
{
	[MetadataType(typeof(RegisterVMValidation))]
	public partial class RegisterVM{}

	class RegisterVMValidation : UserProfileVMValidation
	{
		#region Required

		[Display(Name = "Felhasználó név")]
		[Required(ErrorMessage = ValidationConstants.RequiredErrorMessageFormat)]
		[StringLength(100, ErrorMessage = ValidationConstants.StringLengthMaxErrorMessageFormat)]
		[RegularExpression(ValidationConstants.RegEx_START_EnChar_EnCharOrDigit_0Ti_END, ErrorMessage = ValidationConstants.RegExErrMsg_START_EnChar_EnCharOrDigit_0Ti_END)]
		[Remote("CheckUserNameUnique", "Account", ErrorMessage = "Foglalt felhasználó név", HttpMethod = "POST")]
		public string UserName { get; set; }

		[Display(Name = "E-mail cím")]
		[Required(ErrorMessage = ValidationConstants.RequiredErrorMessageFormat)]
		[StringLength(100, ErrorMessage = ValidationConstants.StringLengthMaxErrorMessageFormat)]
		[EmailAddress(ErrorMessage = "Nem megfelelő e-mail cím")]
		[Remote("CheckEmailUnique", "Account", ErrorMessage = "Foglalt email-cím", HttpMethod = "POST")]
		public string EMail { get; set; }

		[Display(Name = "Jelszó")]
		[Required(ErrorMessage = ValidationConstants.RequiredErrorMessageFormat)]
		[StringLength(128, ErrorMessage = ValidationConstants.StringLengthMinMaxErrorMessageFormat, MinimumLength = 6)]
		[DataType(DataType.Password)]
		public string Password { get; set; }

		[Display(Name = "Jelszó megerősítése")]
		[Required(ErrorMessage = ValidationConstants.RequiredErrorMessageFormat)]
		[DataType(DataType.Password)]
		[System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = "A jelszó és a megerősített jelszó nem egyezik meg!")]
		public string ConfirmPassword { get; set; }

		#endregion

		#region Not required

		[RegularExpression(ValidationConstants.RegEx_START_HuChar_HuCharOrSpace_0Ti_END, ErrorMessage = ValidationConstants.RegExErrMsg_START_HuChar_HuCharOrSpace_0Ti_END)]
		// Only for RegExErrMsg
		[Display(Name = "Szerző")]
		[StringLength(100, ErrorMessage = ValidationConstants.StringLengthMaxErrorMessageFormat)]
		public string AuthorName { get; set; }

		[RegularExpression(ValidationConstants.RegEx_START_HuChar_HuCharOrSpace_0Ti_END, ErrorMessage = ValidationConstants.RegExErrMsg_START_HuChar_HuCharOrSpace_0Ti_END)]
		// Only for RegExErrMsg
		[Display(Name = "Kiadó")]
		[StringLength(100, ErrorMessage = ValidationConstants.StringLengthMaxErrorMessageFormat)]
		public string PublisherName { get; set; }

		// Validation in UserProfileEditVMValidation:
		//
		// public string FullName { get; set; }
		// public string PhoneNumber { get; set; }
		// public string ImageUrl { get; set; }

		#endregion

	}
}
