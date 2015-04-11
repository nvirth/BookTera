using System.Linq;
using CommonModels.Models.EntityFramework;
using DAL.EntityFramework;
using ebookTestData.Inserts;

namespace ebookTestData.Set
{
	/// <summary>
	/// A UserProfile táblába illeszt be defaultAddressID-ket, miután a UserAddress tábla létrejött
	/// </summary>
	internal class SetDefaultUserAddress : Insert
	{
		private int[,] usersAndOneAddress;

		protected override sealed void Start()
		{
			using(var ctx = new DBEntities())
			{
				// Itt még 1 usernek több address-je lehet
				var usersAndAddresses = (from up in ctx.UserProfile
										 join ua in ctx.UserAddress on up.ID equals ua.UserID
										 orderby up.ID
										 select new
										 {
											 userID = up.ID,
											 addressID = ua.ID
										 }).ToList();

				// Ezután már 1 usernek csak 1 address-je lesz
				var previous = usersAndAddresses.ElementAt(0);
				for(int i = 1; i < usersAndAddresses.Count(); i++)
				{
					var actually = usersAndAddresses[i];
					if(previous.userID == actually.userID)
					{
						usersAndAddresses.RemoveAt(i);
					}
					else
					{
						previous = actually;
					}
				}

				// Átrakjuk 2D int tömbbe, h átadhassuk
				usersAndOneAddress = new int[usersAndAddresses.Count, 2];
				for(int i = 0; i < usersAndOneAddress.GetLength(0); i++)
				{
					usersAndOneAddress[i, 0] = usersAndAddresses[i].userID;
					usersAndOneAddress[i, 1] = usersAndAddresses[i].addressID;
				}
			}
		}

		protected void ExecuteInDB()
		{
			using(var ctx = new DBEntities())
			{
				for (int i = 0; i < usersAndOneAddress.GetLength(0); i++)
				{
					int userID = usersAndOneAddress[i, 0];
					int addressID = usersAndOneAddress[i, 1];

					UserProfile userProfile = ctx.UserProfile.Single(p => p.ID == userID);
					userProfile.DefaultAddressID = addressID;
				}
				ctx.SaveChanges();
			}
		}
	}
}
