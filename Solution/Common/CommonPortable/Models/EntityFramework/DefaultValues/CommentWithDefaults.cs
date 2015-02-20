using System;

namespace CommonModels.Models.EntityFramework
{
	public partial class Comment
	{
		public Comment(bool withDefaults)
			: this()
		{
			if(withDefaults)
			{
				CreatedDate = DateTime.Now;
			}
		}
	}
}


