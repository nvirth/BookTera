using System;
using System.Collections.Generic;
using System.Linq;
using BLL.EntityManagers;
using CommonModels.Models.EntityFramework;
using DAL.EntityFramework;
using UtilsShared;

namespace ebookTestData.Inserts
{
	internal class InsertUserAddress : Insert
	{

		private List<UserAddress> userAddresses;

		protected override sealed void Start()
		{
			using(var ctx = new DBEntities())
			{
				userAddresses = new List<UserAddress>();

				int[] userIDs = ctx.UserProfile.Select(up => up.ID).ToArray();

				string[,] citiesAndZips = Get.GetResources.GetHungarianCitiesWithZip(); // [*,0]:Zip, [*,1]:City
				string[] streets = Get.GetResources.GetStreets();

				foreach(int userID in userIDs)
				{
					// A felhasználóknak csak 45%-a adott meg címet
					if(Random.Next(100) < 45)
					{
						// A felhasználók 10% -a akár 4 címet is megadhat
						int max = Random.Next(100) < 10 ? Random.Next(2, 4) : 1;
						for(int j = 0; j < max; j++)
						{
							int idx = Random.Next(citiesAndZips.GetLength(0));
							userAddresses.Add(new UserAddress(withDefaults: true)
							{
								ZipCode = citiesAndZips[idx, 0],
								City = citiesAndZips[idx, 1],
								StreetAndHouseNumber = streets[Random.Next(streets.Length)] + " " + Random.Next(1, 200),
								UserID = userID,
							});
						}
					}
				}
			}
		}

		protected void ExecuteInDB()
		{
			foreach(var userAddress in userAddresses)
			{
				try
				{
					UserAddressManager.Add(userAddress);
				}
				catch(Exception e)
				{
					//throw;
					e.WriteWithInnerMessagesColorful(ConsoleColor.Red);
				}
			}
		}
	}
}