using System;

namespace CommonModels.Models.EntityFramework
{
	public partial class UserProfile
	{
		public UserProfile(bool withDefaults)
			:this()
		{
			if(withDefaults)
			{
				LastLoginDate = DateTime.Now;
				RegistrationDate = DateTime.Now;
				PreviousLoginDate = DateTime.Now;
				SumOfBuys = 0;
				SumOfBuysInProgress = 0;
				SumOfNeededFeedbacks = 0;
				SumOfSells = 0;
				SumOfSellsInProgress = 0;
				SumOfFeedbacks = 0;
				SumOfFeedbacksValue = 0;
				IsAuthor = false;
				IsPublisher = false;
				Balance = 0;
				SumOfActiveProducts = 0;
				SumOfPassiveProducts = 0;
			}
		}
	}
}
