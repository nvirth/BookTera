using System.ComponentModel.DataAnnotations;
using UtilsLocal;

namespace CommonModels.Models.ProductModels
{
	public partial class CreatePVM
	{
		[MetadataType(typeof(Validation))]
		public partial class ProductVM
		{
			class Validation
			{
				#region String

				[Display(Name = "Nyelv")]
				[Required(ErrorMessage = ValidationConstants.RequiredErrorMessageFormat)]
				[RegularExpression(ValidationConstants.RegEx_START_HuChar_HuCharOrSpace_0Ti_END, ErrorMessage = ValidationConstants.RegExErrMsg_START_HuChar_HuCharOrSpace_0Ti_END)]
				[StringLength(50, ErrorMessage = ValidationConstants.StringLengthMaxErrorMessageFormat)]
				public string Language { get; set; }

				[Display(Name = "Leírás")]
				[Required(ErrorMessage = ValidationConstants.RequiredErrorMessageFormat)]
				public string Description { get; set; }

				[Display(Name = "Kép feltöltése")]
				// Validation in Controller and Manager
				public string ImageUrl { get; set; }

				#endregion

				#region Number

				[Display(Name = "Kiadás éve")]
				[Required(ErrorMessage = ValidationConstants.RequiredErrorMessageFormat)]
				[RegularExpression(ValidationConstants.RegEx_Number, ErrorMessage = ValidationConstants.RegExErrMsg_Number)]
				[Range(1, int.MaxValue, ErrorMessage = ValidationConstants.RangeMinErrorMessageFormat)]
				public int PublishYear { get; set; }

				[Display(Name = "Oldalszám")]
				[Required(ErrorMessage = ValidationConstants.RequiredErrorMessageFormat)]
				[RegularExpression(ValidationConstants.RegEx_Number, ErrorMessage = ValidationConstants.RegExErrMsg_Number)]
				[Range(1, int.MaxValue, ErrorMessage = ValidationConstants.RangeMinErrorMessageFormat)]
				public int PageNumber { get; set; }

				[Display(Name = "Ár")]
				[Required(ErrorMessage = ValidationConstants.RequiredErrorMessageFormat)]
				[RegularExpression(ValidationConstants.RegEx_Number, ErrorMessage = ValidationConstants.RegExErrMsg_Number)]
				[Range(1, int.MaxValue, ErrorMessage = ValidationConstants.RangeMinErrorMessageFormat)]
				public int Price { get; set; }

				[Display(Name = "Mennyiség")]
				[Required(ErrorMessage = ValidationConstants.RequiredErrorMessageFormat)]
				[RegularExpression(ValidationConstants.RegEx_Number, ErrorMessage = ValidationConstants.RegExErrMsg_Number)]
				[Range(1, int.MaxValue, ErrorMessage = ValidationConstants.RangeMinErrorMessageFormat)]
				public int HowMany { get; set; }

				[Display(Name = "Kiadás száma")]
				[Required(ErrorMessage = ValidationConstants.RequiredErrorMessageFormat)]
				[RegularExpression(ValidationConstants.RegEx_Number, ErrorMessage = ValidationConstants.RegExErrMsg_Number)]
				[Range(1, int.MaxValue, ErrorMessage = ValidationConstants.RangeMinErrorMessageFormat)]
				public int Edition { get; set; }

				#endregion

				#region Flag - Validation in Controller and Manager

				[Display(Name = "Könyv")]
				public bool IsBook { get; set; }

				[Display(Name = "Hangoskönyv")]
				public bool IsAudio { get; set; }

				[Display(Name = "Videó")]
				public bool IsVideo { get; set; }

				[Display(Name = "Használt")]
				public bool IsUsed { get; set; }

				[Display(Name = "Elektronikus")]
				public bool IsDownloadable { get; set; }

				#endregion
			}
		}

		[MetadataType(typeof(DisplayNames))]
		public partial class ProductGroupVM
		{
			class DisplayNames
			{
				[Display(Name = "Melyik könyv?")]
				public int? Id { get; set; }

				[Display(Name = "Kiadó")]
				public string PublisherName { get; set; }

				[Display(Name = "Kategória")]
				public int? CategoryId { get; set; }

				[Display(Name = "Cím")]
				public string Title { get; set; }

				[Display(Name = "Alcím")]
				public string SubTitle { get; set; }

				[Display(Name = "Szerző(k)")]
				public string AuthorNames { get; set; }

				[Display(Name = "Kép feltöltése")]
				public string ImageUrl { get; set; }

				[Display(Name = "Leírás")]
				public string Description { get; set; }
			}

			[MetadataType(typeof(Validation))]
			public class WithValidation : ProductGroupVM
			{
				class Validation
				{
					[Display(Name = "Melyik könyv?")]
					public int? Id { get; set; }

					[Display(Name = "Kategória")]
					[Required(ErrorMessage = ValidationConstants.RequiredErrorMessageFormat)]
					public int? CategoryId { get; set; }

					[Display(Name = "Kiadó")]
					[RegularExpression(ValidationConstants.RegEx_START_HuChar_HuCharOrSpace_0Ti_END, ErrorMessage = ValidationConstants.RegExErrMsg_START_HuChar_HuCharOrSpace_0Ti_END)]
					[StringLength(100, ErrorMessage = ValidationConstants.StringLengthMaxErrorMessageFormat)]
					[Required(ErrorMessage = ValidationConstants.RequiredErrorMessageFormat)]
					public string PublisherName { get; set; }

					[Display(Name = "Szerző(k)")]
					[RegularExpression(ValidationConstants.RegEx_START_HuChar_HuCharOrSpaceOrComma_0Ti_END, ErrorMessage = ValidationConstants.RegExErrMsg_START_HuChar_HuCharOrSpaceOrComma_0Ti_END)]
					[StringLength(100, ErrorMessage = ValidationConstants.StringLengthMaxErrorMessageFormat)]
					[Required(ErrorMessage = ValidationConstants.RequiredErrorMessageFormat)]
					public string AuthorNames { get; set; }

					[Display(Name = "Cím")]
					[StringLength(100, ErrorMessage = ValidationConstants.StringLengthMaxErrorMessageFormat)]
					[Required(ErrorMessage = ValidationConstants.RequiredErrorMessageFormat)]
					public string Title { get; set; }

					[Display(Name = "Alcím")]
					[StringLength(100, ErrorMessage = ValidationConstants.StringLengthMaxErrorMessageFormat)]
					public string SubTitle { get; set; }

					[Display(Name = "Leírás")]
					[Required(ErrorMessage = ValidationConstants.RequiredErrorMessageFormat)]
					public string Description { get; set; }

					[Display(Name = "Kép feltöltése")]
					// Validation in Controller and Manager
					public string ImageUrl { get; set; }
				}

				public WithValidation(){} // Szerializáláshoz
				public WithValidation(ProductGroupVM nonValidatedProductGroup)
				{
					Id = nonValidatedProductGroup.Id;
					PublisherName = nonValidatedProductGroup.PublisherName;
					CategoryId = nonValidatedProductGroup.CategoryId;
					Title = nonValidatedProductGroup.Title;
					SubTitle = nonValidatedProductGroup.SubTitle;
					AuthorNames = nonValidatedProductGroup.AuthorNames;
					ImageUrl = nonValidatedProductGroup.ImageUrl;
					Description = nonValidatedProductGroup.Description;
				}
			}
		}
	}
}
