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
			//	// A User-ek max 10%-a n�zett meg egy k�nyvet �sszesen
			//	int max = random.Next(10);
			//	foreach(UserProfile userProfile in ctx.UserProfile)
			//	{
			//		if(random.Next(100) < max) // A User-ek max 10%-a n�zte csak meg ezt a term�ket
			//		{
			//			// Csak az a user n�zhette meg a k�nyvet, akinek a LastLoginje kor�bban volt, minthogy a k�nyvet felt�lt�tt�k
			//			if(Get.GetResources.CanUserViewProduct(userProfile, product))
			//			{
			//				int howMany;
			//				howMany = random.Next(100) < 5 ? random.Next(10, 50) : random.Next(5, 10);
			//				howMany = random.Next(100) < 70 ? howMany : random.Next(1, 5);

			//				// 4 d�tum van: Product.Upload, User.Reg, User.Last; illetve a view d�tuma
			//				// A view d�tum�nak kor�bban kell lenni, mint a User.Last, mert utols� bel�p�se ut�n nem n�zhettem meg
			//				// A view d�tum�nak k�s�bb kell lennie a term�k felt�lt�s�n�l �s a user regisztr�ci�j�n�l

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
