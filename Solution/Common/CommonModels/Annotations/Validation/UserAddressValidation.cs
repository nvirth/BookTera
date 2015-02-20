using System.ComponentModel.DataAnnotations;
using UtilsLocal;

namespace CommonModels.Models
{
	[MetadataType(typeof(DisplayNames))]
	public partial class UserAddressVM
	{
		class DisplayNames
		{
			[Display(Name = "Irányítószám")]
			public string ZipCode { get; set; }

			[Display(Name = "Település")]
			public string City { get; set; }

			[Display(Name = "Utca, házszám")]
			public string StreetAndHouseNumber { get; set; }

			[Display(Name = "Ország")]
			public string Country { get; set; }

			[Display(Name = "Alapértelmezett")]
			public bool IsDefault { get; set; }
		}

		[MetadataType(typeof(Validation))]
		public class WithValidation : UserAddressVM
		{
			class Validation
			{
				[Display(Name = "Irányítószám")]
				[Required(ErrorMessage = ValidationConstants.RequiredErrorMessageFormat)]
				[RegularExpression(ValidationConstants.RegEx_START_Digit_4T4_END, ErrorMessage = ValidationConstants.RegExErrMsg_START_Digit_4T4_END)]
				[StringLength(100, ErrorMessage = ValidationConstants.StringLengthMaxErrorMessageFormat)]
				public string ZipCode { get; set; }

				[Display(Name = "Település")]
				[Required(ErrorMessage = ValidationConstants.RequiredErrorMessageFormat)]
				[RegularExpression(ValidationConstants.RegEx_START_HuChar_HuCharOrSpace_0Ti_END, ErrorMessage = ValidationConstants.RegExErrMsg_START_HuChar_HuCharOrSpace_0Ti_END)]
				[StringLength(100, ErrorMessage = ValidationConstants.StringLengthMaxErrorMessageFormat)]
				public string City { get; set; }

				[Display(Name = "Utca, házszám")]
				[Required(ErrorMessage = ValidationConstants.RequiredErrorMessageFormat)]
				[RegularExpression(ValidationConstants.RegEx_START_HuChar_HuCharOrDigitOrSeparator_0Ti_END, ErrorMessage = ValidationConstants.RegExErrMsg_START_HuChar_HuCharOrDigitOrSeparator_0Ti_END)]
				[StringLength(100, ErrorMessage = ValidationConstants.StringLengthMaxErrorMessageFormat)]
				public string StreetAndHouseNumber { get; set; }

				[Display(Name = "Ország")]
				[Required(ErrorMessage = ValidationConstants.RequiredErrorMessageFormat)]
				[RegularExpression(ValidationConstants.RegEx_START_HuChar_HuCharOrSpace_0Ti_END, ErrorMessage = ValidationConstants.RegExErrMsg_START_HuChar_HuCharOrSpace_0Ti_END)]
				[StringLength(100, ErrorMessage = ValidationConstants.StringLengthMaxErrorMessageFormat)]
				public string Country { get; set; }

				[Display(Name = "Alapértelmezett")]
				public bool IsDefault { get; set; }
			}

			public WithValidation(UserAddressVM nonValidatedUserAddress)
			{
				ZipCode = nonValidatedUserAddress.ZipCode;
				City = nonValidatedUserAddress.City;
				StreetAndHouseNumber = nonValidatedUserAddress.StreetAndHouseNumber;
				Country = nonValidatedUserAddress.Country;
				Id = nonValidatedUserAddress.Id;
				IsDefault = nonValidatedUserAddress.IsDefault;
			}

			public WithValidation(){}
		}
	}
}
