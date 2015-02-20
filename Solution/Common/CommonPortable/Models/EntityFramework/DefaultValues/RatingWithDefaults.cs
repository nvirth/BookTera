using System;

namespace CommonModels.Models.EntityFramework
{
	public partial class Rating
	{
		public Rating(bool withDefaults)
			: this()
		{
			if(withDefaults)
			{
				Date = DateTime.Now;
			}
		}

		public Rating()
		{
			
		}
	}
}
