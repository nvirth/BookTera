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
			//		// V�letlenszer�nek l�tszik majd
			//		if(random.Next(100) < 70)
			//		{
			//			// Keres�nk egy usert, aki l�thatta m�r egy�ltal�n a term�ket
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

			//			// Ha tal�ltunk usert, aki l�thatta
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
			//				// Kivessz�k ezt a user-t a list�b�l, mert 1 user 1 term�ket csak egyszer �rt�kelhet
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
