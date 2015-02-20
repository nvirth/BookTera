namespace CommonModels.Models.ProductModels
{
	public partial class CreatePVM
	{
		public ProductVM Product { get; set; }
		public ProductGroupVM ProductGroup { get; set; }

		public partial class ProductVM
		{
			public string Language { get; set; }
			public string Description { get; set; }
			public int PublishYear { get; set; }
			public int PageNumber { get; set; }
			public int Price { get; set; }
			public int HowMany { get; set; }
			public int Edition { get; set; }
			public string ImageUrl { get; set; }
			public bool ContainsOther { get; set; }
			public bool IsBook { get; set; }
			public bool IsAudio { get; set; }
			public bool IsVideo { get; set; }
			public bool IsUsed { get; set; }
			public bool IsDownloadable { get; set; }
		}

		/// <summary>
		/// Ha az (Id != null), akkor meglévő ProductGroup-ba töltöttek fel. 
		/// Ha az (Id == null), akkor új ProductGroup-ot töltöttek fel
		/// </summary>
		public partial class ProductGroupVM
		{
			public int? Id { get; set; }
			public string PublisherName { get; set; }
			public int? CategoryId { get; set; }
			public string Title { get; set; }
			public string SubTitle { get; set; }
			public string AuthorNames { get; set; }
			public string ImageUrl { get; set; }
			public string Description { get; set; }
		}
	}
}
