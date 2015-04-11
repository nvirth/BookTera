using System;
using System.Collections.Generic;
using CommonModels.Models.EntityFramework;

namespace ebookTestData.Inserts
{
	class InsertUserViewProduct : Insert
	{
		private List<UserView> views;

		protected sealed override void Start()
		{
			//views = new List<UserViewProduct>();

			//foreach(Product product in ctx.Product)
			//{
			//	// A User-ek max 10%-a nézett meg egy könyvet összesen
			//	int max = random.Next(10);
			//	foreach(UserProfile userProfile in ctx.UserProfile)
			//	{
			//		if(random.Next(100) < max) // A User-ek max 10%-a nézte csak meg ezt a terméket
			//		{
			//			// Csak az a user nézhette meg a könyvet, akinek a LastLoginje korábban volt, minthogy a könyvet feltöltötték
			//			if(Get.GetResources.CanUserViewProduct(userProfile, product))
			//			{
			//				int howMany;
			//				howMany = random.Next(100) < 5 ? random.Next(10, 50) : random.Next(5, 10);
			//				howMany = random.Next(100) < 70 ? howMany : random.Next(1, 5);

			//				// 4 dátum van: Product.Upload, User.Reg, User.Last; illetve a view dátuma
			//				// A view dátumának korábban kell lenni, mint a User.Last, mert utolsó belépése után nem nézhettem meg
			//				// A view dátumának késõbb kell lennie a termék feltöltésénél és a user regisztrációjánál

			//				DateTime lastDate = Get.GetResources.GetRandomDateTimeBetween2mins1max(
			//					userProfile.RegistrationDate,
			//					product.UploadedDate,
			//					userProfile.LastLoginDate);

			//				var view = new UserViewProduct()
			//							   {
			//								   ProductID = product.ID,
			//								   UserID = userProfile.ID,
			//								   HowMany = howMany,
			//								   LastDate = lastDate
			//							   };
			//				views.Add(view);
			//			}
			//		}
			//	}
			//}
			//TODO IMPLEMENT
			throw new NotImplementedException();
		}

		protected void ExecuteInDB()
		{
			//foreach(var userViewProduct in views)
			//{
			//	ctx.AddView(userViewProduct.ProductID, userViewProduct.UserID, userViewProduct.HowMany, userViewProduct.LastDate);
			//}
			//ctx.SaveChanges();
			//TODO IMPLEMENT
			throw new NotImplementedException();
		}
	}
}
