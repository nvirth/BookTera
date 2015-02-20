using System;

namespace CommonModels.Models.EntityFramework
{
	public partial class ProductGroup
	{
		public ProductGroup(bool withDefaults)
			: this()
		{
			if(withDefaults)
			{
				SumOfActiveProductsInGroup = 1;
				SumOfPassiveProductsInGroup = 0;
				SumOfViews = 0;
				SumOfBuys = 0;
				SumOfRatings = 0;
				SumOfRatingsValue = 0;
				SumOfComments = 0;
				IsCheckedByAdmin = false;
				UploadedDate = DateTime.Now;
			}
		}
	}
}
