using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using UtilsLocal;

namespace CommonModels.Models
{
	[MetadataType(typeof(UserProfileEditVMValidation))]
	public partial class UserProfileEditVM{}

	public class UserProfileEditVMValidation : UserProfileVMValidation
	{
		#region Required

		[Display(Name = "E-mail cím")]
		[Required(ErrorMessage = ValidationConstants.RequiredErrorMessageFormat)]
		[StringLength(100, ErrorMessage = ValidationConstants.StringLengthMaxErrorMessageFormat)]
		[EmailAddress(ErrorMessage = "Nem megfelelő e-mail cím")]
		[Remote("CheckEmailUnique", "Profile", ErrorMessage = "Foglalt email-cím", HttpMethod = "POST")]
		public string EMail { get; set; }

		#endregion
	}
}