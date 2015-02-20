using System;

namespace CommonModels.Models.EntityFramework
{
	public partial class HighlightedProduct
	{
		public HighlightedProduct(bool withDefaults)
			: this()
		{
			if(withDefaults)
			{
				FromDate = DateTime.Now;
			}
		}

		public HighlightedProduct()
		{

		}
	}
}
