using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using UtilsLocal;

namespace CommonModels.Models.AccountModels
{
	[MetadataType(typeof(Validation))]
	public partial class UserProfile
	{
		[Table("UserProfile")]
		class Validation
		{
			[Key]
			[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
			public int UserId { get; set; }

			public string UserName { get; set; }
		}
	}

	[MetadataType(typeof(Validation))]
	public partial class RegisterExternalLoginModel
	{
		class Validation
		{
			[Required]
			[Display(Name = "Felhasználó név")]
			public string UserName { get; set; }

			public string ExternalLoginData { get; set; }
		}
	}

	[MetadataType(typeof(Validation))]
	public partial class LocalPasswordModel
	{
		class Validation
		{
			[Required]
			[DataType(DataType.Password)]
			[Display(Name = "Aktuális jelszó")]
			public string OldPassword { get; set; }

			[Required]
			[StringLength(100, ErrorMessage = "A {0} legalább {2} karakter hosszú kell legyen.", MinimumLength = 6)]
			[DataType(DataType.Password)]
			[Display(Name = "Új jelszó")]
			public string NewPassword { get; set; }

			[DataType(DataType.Password)]
			[Display(Name = "Új jelszó megerősítése")]
			[Compare("NewPassword", ErrorMessage = "A jelszó és a megerősített jelszó nem egyezik meg!")]
			public string ConfirmPassword { get; set; }
		}
	}

	[MetadataType(typeof(Validation))]
	public partial class LoginModel
	{
		class Validation
		{
			[Required(ErrorMessage = ValidationConstants.RequiredErrorMessageFormat)]
			[Display(Name = "Felhasználó név")]
			public string LoginUserName { get; set; }

			[Required(ErrorMessage = ValidationConstants.RequiredErrorMessageFormat)]
			[DataType(DataType.Password)]
			[Display(Name = "Jelszó")]
			public string LoginPassword { get; set; }

			[Display(Name = "Emlékezz rám")]
			public bool RememberMe { get; set; }
		}
	}
}
