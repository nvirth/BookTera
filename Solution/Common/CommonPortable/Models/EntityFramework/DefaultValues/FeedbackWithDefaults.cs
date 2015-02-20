using System;

namespace CommonModels.Models.EntityFramework
{
    public partial class Feedback
    {
		public Feedback(bool withDefaults)
			: this()
		{
			if(withDefaults)
			{
				Date = DateTime.Now;
			}
		}

		public Feedback()
		{

		}
    }
}
