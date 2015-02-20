using System;
using System.Collections.Generic;
using System.Linq;
using BLL;
using CommonModels.Models.EntityFramework;
using CommonPortable.Exceptions;
using DAL.EntityFramework;
using UtilsLocal;
using GeneralFunctionsPortable = UtilsSharedPortable.GeneralFunctions;

namespace ebookTestData.Inserts
{
	internal class DoSomeBuys : Insert
	{
		private UserProfile[] users;
		private Product[] products;

		protected override sealed void Start()
		{
			SetProperties();
			Test_AddProductToCart();
			Test_UpdateProductInCart();
			CorrectTestData();
		}
		private void SetProperties()
		{
			using(var ctx = new DBEntities())
			{
				users = ctx.UserProfile.ToArray();
				products = ctx.Product.ToArray();
			}
		}

		/// <summary>
		/// Megjegyzés a dátumokhoz: Csak olyan rendelések születhetnek, amikre igaz, hogy:
		/// (user.RegDate || product.UploadDate) LOWER_THEN (PIO.Date) LOWER_THEN (user.LastLoginDate)
		/// </summary>
		private void Test_AddProductToCart()
		{
			var user = users[Random.Next(users.Length)];
			var product = products[Random.Next(products.Length)];

			for(int i = 0; i < Random.Next(200, 400); i++)
			{
				do
				{
					if(Random.Next(100) < 90)
					{
						if(Random.Next(100) < 70)
							user = users[Random.Next(users.Length)];

						product = products[Random.Next(products.Length)];
					}
				} while(!GeneralFunctionsPortable.CheckDateTimes_2earlier1later(product.UploadedDate, user.RegistrationDate, user.LastLoginDate));

				try
				{
					TransactionManager.AddProductToCart(user.ID, product.ID);
				}
				catch(BookteraException e)
				{
					e.WriteWithInnerMessagesColorful(goodExceptionCodes, neutralExceptionCodes);
				}
			}
		}
		private void Test_UpdateProductInCart()
		{
			var pio_userId_dictionary = new Dictionary<ProductInOrder, int>();
			using(var ctx = new DBEntities())
			{
				foreach(var productInOrder in ctx.ProductInOrder)
				{
					var pio = productInOrder;
					int validUserId = productInOrder.UserOrder.CustomerUserProfileID;
					pio_userId_dictionary.Add(pio, validUserId);
				}
			}

			foreach(var pio_userId in pio_userId_dictionary)
			{
				if(Random.Next(100) < 20)
				{
					int currentUserId = pio_userId.Value;
					var productInOrder = pio_userId.Key;
					int pioId = productInOrder.ID;
					int newHowMany = Random.Next(100) < 70 ? productInOrder.HowMany + Random.Next(3) : productInOrder.HowMany - Random.Next(2);

					try
					{
						TransactionManager.UpdateProductInCart(currentUserId, pioId, newHowMany);
					}
					catch(Exception e)
					{
						e.WriteWithInnerMessagesColorful(goodExceptionCodes, neutralExceptionCodes);
					}
				}
			}
		}
		private void CorrectTestData()
		{
			using(var ctx = new DBEntities())
			{
				foreach(var productInOrder in ctx.ProductInOrder)
				{
					var product = productInOrder.Product;
					var userOrder = productInOrder.UserOrder;
					var customerUserProfile = userOrder.CustomerUserProfile;

					var dateTime = GeneralFunctionsPortable.GetRandomDateTimeBetween2mins1max(product.UploadedDate, customerUserProfile.RegistrationDate, customerUserProfile.LastLoginDate);
					userOrder.Date = dateTime;
				}
				ctx.SaveChanges();
			}
		}
	}
}
