using System;
using CommonPortable.Enums;

namespace CommonModels.Models.EntityFramework
{
	public partial class UserOrder
	{
		public UserOrder(bool withDefaults)
			: this()
		{
			if(withDefaults)
			{
				Date = DateTime.Now;
				RatingState = (byte)UserOrderRatingState.DontNeed;
				Status = (byte)UserOrderStatus.Cart;
				SumBookPrice = 0;
			}
		}
	}
}
