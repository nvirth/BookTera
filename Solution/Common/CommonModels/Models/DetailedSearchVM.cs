using CommonModels.Models.ProductModels;
using CommonPortable.Models.ProductModels;

namespace CommonModels.Models
{
	public partial class DetailedSearchVM
	{
		public DetailedSearchInputs SearchInputs { get; set; }
		public BookBlockPLVM SearchResults { get; set; }

		public partial class DetailedSearchInputs
		{
			public string SearchingText { get; set; }
			public string Author { get; set; }
			public string Publisher { get; set; }
			public string Title { get; set; }
			public string Subtitle { get; set; }
			public string Description { get; set; }

			public int? PublishYearFrom { get; set; }
			public int? PublishYearTo { get; set; }
			public int? PageNumberFrom { get; set; }
			public int? PageNumberTo { get; set; }
			public int? PriceFrom { get; set; }
			public int? PriceTo { get; set; }

			public bool? IsDownloadable { get; set; }
			public bool? IsUsed { get; set; }
			public bool IsBook { get; set; }
			public bool IsAudio { get; set; }
			public bool IsVideo { get; set; }

			public int? CategoryId { get; set; }
		}
	}
}