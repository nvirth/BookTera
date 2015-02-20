using System;

namespace CommonModels.Models.EntityFramework
{
	public partial class Product
	{
		public Product(bool withDefaults)
			: this()
		{
			if(withDefaults)
			{
				Language = "magyar";
				UploadedDate = DateTime.Now;
				SumOfViews = 0;
				IsCheckedByAdmin = false;
			}
		}
	}
}
