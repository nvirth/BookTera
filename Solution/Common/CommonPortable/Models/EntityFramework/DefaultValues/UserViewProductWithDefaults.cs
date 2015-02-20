using System;

namespace CommonModels.Models.EntityFramework
{
	public partial class UserView
	{
		public UserView(bool withDefaults)
			:this()
		{
			if(withDefaults)
			{
				LastDate = DateTime.Now;
			}
		}

		public UserView()
		{
			
		}
	}
}
