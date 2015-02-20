using System;
using System.Collections.Generic;
using CommonModels.Models.EntityFramework;

namespace ebookTestData.Inserts
{
	class InsertRating : Insert
	{
		private List<Rating> ratings;

		protected sealed override void Start()
		{
			//ratings = new List<Rating>();

			//List<UserProfile> userProfiles = ctx.UserProfile.ToList();

			//foreach(var product in ctx.Product)
			//{
			//	List<UserProfile> userProfilesTmp = new List<UserProfile>(userProfiles);
			//	int max = product.SumOfViews < 15 ? product.SumOfViews : 15;
			//	for(int j = 0; j < max; j++)
			//	{
			//		// Véletlenszerûnek látszik majd
			//		if(random.Next(100) < 70)
			//		{
			//			// Keresünk egy usert, aki láthatta már egyáltalán a terméket
			//			UserProfile user;
			//			int idx = random.Next(userProfilesTmp.Count);
			//			int countOfCycles = 0;
			//			bool nobodyCanViewIt = false;
			//			do
			//			{
			//				user = userProfilesTmp[idx % userProfilesTmp.Count];
			//				idx++;
			//				countOfCycles++;
			//				nobodyCanViewIt = (countOfCycles > userProfilesTmp.Count)
			//									|| userProfilesTmp.Count == 0;
			//			} while(!Get.GetResources.CanUserViewProduct(user, product)
			//					 && !nobodyCanViewIt);

			//			// Ha találtunk usert, aki láthatta
			//			if(!nobodyCanViewIt)
			//			{
			//				DateTime createdDate = Get.GetResources.GetRandomDateTimeBetween2mins1max(
			//					product.UploadedDate, user.RegistrationDate, user.LastLoginDate);

			//				ratings.Add(new Rating()
			//								{
			//									ProductID = product.ID,
			//									UserID = user.ID,
			//									Date = createdDate,
			//									Value = random.Next(1, 6)	// 1..5
			//								});
			//				// Kivesszük ezt a user-t a listából, mert 1 user 1 terméket csak egyszer értékelhet
			//				userProfilesTmp.Remove(user);
			//			}
			//		}
			//	}
			//}
			//TODO IMPLEMENT
			throw new NotImplementedException();
		}

		protected void ExecuteInDB()
		{
			//foreach(var rating in ratings)
			//{
			//	// Stored Procedure
			//	ctx.AddRating(rating.ProductID, rating.UserID, rating.Value, rating.Date);
			//}
			//ctx.SaveChanges();
			//TODO IMPLEMENT
			throw new NotImplementedException();
		}
	}
}
