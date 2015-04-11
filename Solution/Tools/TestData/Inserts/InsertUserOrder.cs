using System;
using System.Collections.Generic;
using System.Linq;
using CommonModels.Models.EntityFramework;
using DAL.EntityFramework;
using UtilsShared;
using GeneralFunctions = UtilsSharedPortable.GeneralFunctions;

namespace ebookTestData.Inserts
{
	internal class InsertUserOrder : Insert
	{
		private List<UserOrder> userOrders;

		protected override sealed void Start()
		{
			using(var ctx = new DBEntities())
			{
				userOrders = new List<UserOrder>();

				var usersWithAddresses =
					from up in ctx.UserProfile
					join ua in ctx.UserAddress on up.ID equals ua.UserID
					select new
					{
						addressID = ua.ID,
						userID = up.ID,
						minDate = up.RegistrationDate,
						maxDate = up.LastLoginDate
					};

				foreach(var userWithAddress in usersWithAddresses)
				{
					// A címmel rendelkezõ felhasználók 80%-nak min 1 rendelése van
					if(Random.Next(100) < 80)
					{
						// Ezen felhasználók 30% -a akár 4x is rendelt (2..4)
						int max = Random.Next(100) < 30 ? Random.Next(2, 5) : 1;
						for(int j = 0; j < max; j++)
						{
							DateTime date = GeneralFunctions.GetRandomDateTimeBetween(userWithAddress.minDate, userWithAddress.maxDate);

							//userOrders.Add(new UserOrder()
							//	{
							//		UserAddresID = userWithAddress.addressID,
							//		UserID = userWithAddress.userID,
							//		Status = (byte) random.Next(1,10),
							//		Date = date
							//	});
							throw new NotImplementedException();
						}
					}
				}
			}
		}

		protected void ExecuteInDB()
		{
			using(var ctx = new DBEntities())
			{
				foreach (var userOrder in userOrders)
				{
					ctx.UserOrder.Add(userOrder);
				}
				ctx.SaveChanges();
			}
		}
	}
}
