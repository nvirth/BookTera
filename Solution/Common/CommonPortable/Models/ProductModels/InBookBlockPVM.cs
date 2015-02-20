namespace CommonPortable.Models.ProductModels
{
	public class InBookBlockPVM
	{
		public ProductVM Product { get; set; }
		public ProductGroupVM ProductGroup { get; set; }

		public class ProductVM
		{
			public virtual int ID { get; set; }
			public virtual string ImageUrl { get; set; }
			public virtual string PriceString { get; set; }

			public virtual int HowMany { get; set; }
			public virtual string UserName { get; set; }
			public virtual string UserFriendlyUrl { get; set; }
			public virtual string Description { get; set; }
			public virtual bool IsDownloadable { get; set; }

			public virtual int ProductInOrderId { get; set; }
		}

		public class ProductGroupVM
		{
			public string Title { get; set; }
			public string SubTitle { get; set; }
			public string FriendlyUrl { get; set; }
			public string ImageUrl { get; set; }

			public int SumOfRatings { get; set; }
			public int RatingPoints { get; set; }

			public string AuthorNames { get; set; }
			public string PublisherName { get; set; }

			public string Description { get; set; }
			public bool IsCheckedByAdmin { get; set; }

			public string CategoryFullPath { get; set; }
			public string CategoryFriendlyUrl { get; set; }
		}
	}
}
