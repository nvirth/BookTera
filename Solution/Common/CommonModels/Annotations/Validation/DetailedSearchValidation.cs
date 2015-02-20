using System.ComponentModel.DataAnnotations;

namespace CommonModels.Models
{
	public partial class DetailedSearchVM
	{
		[MetadataType(typeof(DetailedSearchInputsValidation))]
		public partial class DetailedSearchInputs{}

		public class DetailedSearchInputsValidation
		{
			[Display(Name = "Keresőkifejezés")]
			public string SearchingText { get; set; }

			[Display(Name = "Szerző")]
			public string Author { get; set; }

			[Display(Name = "Kiadó")]
			public string Publisher { get; set; }

			[Display(Name = "Cím")]
			public string Title { get; set; }

			[Display(Name = "Alcím")]
			public string Subtitle { get; set; }

			[Display(Name = "Leírás")]
			public string Description { get; set; }

			[Display(Name = "Kiadás éve")]
			public int? PublishYearFrom { get; set; }
			public int? PublishYearTo { get; set; }

			[Display(Name = "Oldalszám")]
			public int? PageNumberFrom { get; set; }
			public int? PageNumberTo { get; set; }

			[Display(Name = "Ár")]
			public int? PriceFrom { get; set; }
			public int? PriceTo { get; set; }

			[Display(Name = "Csak letölthető")]
			public bool? IsDownloadable { get; set; }

			[Display(Name = "Csak nem letölthető")]
			public bool? IsUsed { get; set; }

			[Display(Name = "Szűrés könyvekre")]
			public bool IsBook { get; set; }

			[Display(Name = "Szűrés hangoskönyvekre")]
			public bool IsAudio { get; set; }

			[Display(Name = "Szűrés videókra")]
			public bool IsVideo { get; set; }

			[Display(Name = "Kategória")]
			public int? CategoryId { get; set; }
		}
	}
}