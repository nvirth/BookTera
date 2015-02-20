using System.ComponentModel.DataAnnotations;
using UtilsLocal;

namespace CommonModels.Models
{
	public class UserProfileVMValidation
	{	
		#region Not required

		[Display(Name = "Teljes név")]
		[RegularExpression(ValidationConstants.RegEx_START_HuChar_HuCharOrSpace_0Ti_END, ErrorMessage = ValidationConstants.RegExErrMsg_START_HuChar_HuCharOrSpace_0Ti_END)]
		[StringLength(100, ErrorMessage = ValidationConstants.StringLengthMaxErrorMessageFormat)]
		public string FullName { get; set; }

		[Display(Name = "Telefonszám")]
		[RegularExpression(ValidationConstants.RegEx_START_Digit_7T20_END, ErrorMessage = ValidationConstants.RegExErrMsg_START_Digit_7T20_END)]
		[StringLength(50, ErrorMessage = ValidationConstants.StringLengthMaxErrorMessageFormat)]
		public string PhoneNumber { get; set; }

		[Display(Name = "Avatar kép feltöltése")]
		// Validation in Controller and Manager
		public string ImageUrl { get; set; }

		#endregion
	}
}