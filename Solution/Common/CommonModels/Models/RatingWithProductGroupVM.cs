using System;
using CommonModels.Models.ProductModels;
using CommonPortable.Models.ProductModels;

namespace CommonModels.Models
{
	public class RatingWithProductGroupVM
	{
		public RatingVM Rating { get; set; }
		public InBookBlockPVM Product { get; set; }

		public class RatingVM
		{
			public byte Value { get; set; }
			public DateTime Date { get; set; }
		}
	}
}
