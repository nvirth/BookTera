using System.Collections.Generic;

namespace CommonPortable.Models.ProductModels
{
	public class BookRowPLVM
	{
		public List<ProductVM> ProductsInGroup { get; set; }
		public ProductGroupVM ProductGroup { get; set; }
		public Paging Paging { get; set; }

		public class ProductVM
		{
			public int ID { get; set; }
			public string Language { get; set; }
			public string Description { get; set; }
			public int PublishYear { get; set; }
			public int PageNumber { get; set; }
			public string PriceString { get; set; }
			public int HowMany { get; set; }
			public int Edition { get; set; }
			public bool IsBook { get; set; }
			public bool IsAudio { get; set; }
			public bool IsVideo { get; set; }
			public bool IsUsed { get; set; }
			public bool IsDownloadable { get; set; }

			public List<string> Images { get; set; }
			public string UserName { get; set; }
			public string UserFriendlyUrl { get; set; }
		}

		public class ProductGroupVM
		{
			public string Title { get; set; }
			public string SubTitle { get; set; }
			public string FriendlyUrl { get; set; }
			public string ImageUrl { get; set; }
			public string Description { get; set; }
			public string PriceString { get; set; }
			public int SumOfActiveProductsInGroup { get; set; }
			public int SumOfPassiveProductsInGroup { get; set; }
			public int SumOfBuys { get; set; }

			public int SumOfRatings { get; set; }
			public int RatingPoints { get; set; }

			public string AuthorNames { get; set; }
			public string PublisherName { get; set; }

			public string CategoryFullPath { get; set; }
			public string CategoryFriendlyUrl { get; set; }
		}
	}
}
