using System;
using System.Data;
using System.Linq;
using System.Transactions;
using AutoMapper;
using BLL.ModelManagers;
using CommonModels.Models;
using CommonModels.Models.EntityFramework;
using CommonPortable.Enums;
using CommonPortable.Exceptions;
using DAL.EntityFramework;
using UtilsLocal;
using UtilsShared;
using UtilsSharedPortable;

namespace BLL.EntityManagers
{
	public static class UserProfileManager
	{
		#region CREATE

		#region Add

		public static void Add(UserProfile userProfile)
		{
			using(var ctx = new DBEntities())
			{
				Add(ctx, userProfile);
			}
		}
		public static void Add(DBEntities ctx, UserProfile userProfile)
		{
			try
			{
				ctx.UserProfile.Add(userProfile);
				ctx.SaveChanges();
			}
			catch(Exception e)
			{
				ctx.Entry(userProfile).State = EntityState.Detached;
				const string msg = "Nem siker�lt besz�rni a UserProfile rekordot. ";
				throw new BookteraException(msg, e, BookteraExceptionCode.AddUserProfile_InsertFailed);
			}
		}

		#endregion

		#endregion

		#region READ

		#region GetByID

		public static UserProfile Get(int id)
		{
			using(var ctx = new DBEntities())
			{
				return Get(ctx, id);
			}
		}
		public static UserProfile Get(DBEntities ctx, int id)
		{
			try
			{
				return ctx.UserProfile.Single(p => p.ID == id);
			}
			catch(Exception e)
			{
				var msg = String.Format("Nem tal�lhat� a UserProfile rekord az adatb�zisban. ID: {0}. ", id);
				throw new BookteraException(msg, e, BookteraExceptionCode.GetUserProfileById);
			}
		}

		#endregion

		#region GetByFriendlyUrl

		public static UserProfile Get(string friendlyUrl)
		{
			using(var ctx = new DBEntities())
			{
				return Get(ctx, friendlyUrl);
			}
		}
		public static UserProfile Get(DBEntities ctx, string friendlyUrl)
		{
			try
			{
				return ctx.UserProfile.Single(up => up.FriendlyUrl == friendlyUrl);
			}
			catch(Exception e)
			{
				var msg = String.Format("Nem tal�lhat� a UserProfile rekord az adatb�zisban. FriendlyUrl: {0}. ", friendlyUrl);
				throw new BookteraException(msg, e, BookteraExceptionCode.GetUserProfileByFriendlyUrl);
			}
		}

		#endregion

		#region GetForEdit

		public static UserProfileEditVM GetForEdit(int id)
		{
			using(var ctx = new DBEntities())
			{
				return GetForEdit(ctx, id);
			}
		}
		public static UserProfileEditVM GetForEdit(DBEntities ctx, int id)
		{
			var userProfile = Get(ctx, id);
			return new UserProfileEditVM().DoConsturctorWork(userProfile);
		}

		#endregion

		#region GetUsersLevel

		public static int GetUsersLevel(int userId)
		{
			using(var ctx = new DBEntities())
			{
				return GetUsersLevel(ctx, userId);
			}
		}
		public static int GetUsersLevel(DBEntities ctx, int userId)
		{
			var userProfile = Get(ctx, userId);
			return userProfile.UserGroupID;
		}

		#endregion

		#endregion

		#region UPDATE

		#region Update

		public static void Update(UserProfile userProfile)
		{
			using(var ctx = new DBEntities())
			{
				Update(ctx, userProfile);
			}
		}
		public static void Update(DBEntities ctx, UserProfile userProfile)
		{
			try
			{
				ctx.SaveChanges();
			}
			catch(Exception e)
			{
				ctx.Entry(userProfile).State = EntityState.Unchanged;
				string msg = String.Format("Nem siker�lt a friss�teni a UserProfile rekordot! ID: {0}. ", userProfile.ID);
				throw new BookteraException(msg, e, BookteraExceptionCode.UpdateUserProfile);
			}
		}

		#endregion

		#region UpdateByViewModel

		public static void Update(UserProfileEditVM userProfileEdit, int userId)
		{
			using(var ctx = new DBEntities())
			{
				var userProfile = CreateViaViewModel(userProfileEdit, userId, false);

				// Csak azokat a property-ket update-elj�k, amiket t�nyleg update-elt�nk; nem mindet!
				var userProfileEntry = ctx.Entry(userProfile);
				userProfileEntry.State = EntityState.Unchanged;
				userProfileEntry.Property(up => up.EMail).IsModified = true;
				userProfileEntry.Property(up => up.FullName).IsModified = true;
				userProfileEntry.Property(up => up.PhoneNumber).IsModified = true;
				userProfileEntry.Property(up => up.ImageUrl).IsModified = true;

				Update(ctx, userProfile);
			}
		}

		#endregion

		#region LevelUpUser

		public static bool LevelUpUser(int userId, UserGroupEnum toUserGroup, bool saveChanges = true)
		{
			using(var ctx = new DBEntities())
			using(var transactionScope = new TransactionScope())
			{
				var userProfile = Get(ctx, userId);
				bool leveledUp = LevelUpUser(ctx, userProfile, toUserGroup, /*isFree*/ false, saveChanges);

				transactionScope.Complete();
				return leveledUp;
			}
		}

		/// <returns>True, ha m�dos�tva lett; False, ha nem volt v�ltoz�s</returns>
		public static bool LevelUpUser(DBEntities ctx, UserProfile userProfile, UserGroupEnum toUserGroup, bool isFree = false, bool saveChanges = true)
		{
			try
			{
				bool needUpdate;

				switch(toUserGroup)
				{
					case UserGroupEnum.Leech:
						needUpdate = false;
						break;
					case UserGroupEnum.Seed:
						needUpdate = userProfile.UserGroupID == (int)UserGroupEnum.Leech;
						break;
					case UserGroupEnum.SeedPlus:
						needUpdate = userProfile.UserGroupID == (int)UserGroupEnum.Leech
							|| userProfile.UserGroupID == (int)UserGroupEnum.Seed;
						break;
					case UserGroupEnum.Publisher:
					case UserGroupEnum.Author:
						needUpdate = userProfile.UserGroupID != (int)UserGroupEnum.Author
							&& userProfile.UserGroupID != (int)UserGroupEnum.Publisher;
						break;
					default:
						var msg = "A k�vetkez� UserGroup-hoz tartoz� szintl�ptet�s nincs implement�lva: " + toUserGroup;
						throw new NotImplementedException(msg);
				}
				if(needUpdate)
				{
					var oldUserGroup = userProfile.UserGroup;
					var newUserGroup = UserGroupManager.Get(ctx, (int)toUserGroup);
					UserOrderManager.UpdateUsersOrdersFeeCache(ctx, userProfile, newUserGroup, saveChanges);

					userProfile.UserGroupID = newUserGroup.ID;
					if(!isFree)
					{
						int Price = Math.Max(newUserGroup.Price - oldUserGroup.Price, 0);
						UpdateUsersBalance(ctx, userProfile, -Price, saveChanges: false);
						if(saveChanges)
							Update(ctx, userProfile);
					}
					return true;
				}
				return false;
			}
			catch(Exception e)
			{
				//ctx.Entry(userProfile).State = EntityState.Unchanged;
				var msg = string.Format("Nem siker�lt a felhaszn�l� ({0}) szintl�ptet�se. ", userProfile.UserName);
				throw new BookteraException(msg, e, BookteraExceptionCode.LevelUpUser);
			}
		}

		#endregion

		#region UpdateSellBuyCache

		public static void UpdateSellBuyCache(DBEntities ctx, UserProfile customer, UserProfile vendor, UserOrderStatus whatHappened, bool saveChanges = true)
		{
			try
			{
				switch(whatHappened)
				{
					case UserOrderStatus.Cart:
						customer.SumOfBuysInProgress++;
						vendor.SumOfSellsInProgress++;
						break;
					case UserOrderStatus.CartDeleting:
						customer.SumOfBuysInProgress--;
						vendor.SumOfSellsInProgress--;
						break;
					case UserOrderStatus.Finished:
						customer.SumOfBuysInProgress--;
						vendor.SumOfSellsInProgress--;
						customer.SumOfBuys++;
						vendor.SumOfSells++;
						break;
					default:
						var msg = String.Format("A k�vetkez�h�z m�g nincs meg�rva a \"UpdateSellBuyCache\" met�dus: {0}. ", whatHappened);
						throw new NotImplementedException(msg);
				}

				if(saveChanges)
					Update(ctx, customer);
			}
			catch(Exception e)
			{
				ctx.Entry(customer).State = EntityState.Unchanged;
				ctx.Entry(vendor).State = EntityState.Unchanged;
				const string msg = "Nem siker�lt friss�teni a vev� vagy elad� sell-buy cache-t az adatb�zisban. ";
				throw new BookteraException(msg, e, BookteraExceptionCode.UpdateSellBuyCache);
			}
		}

		#endregion

		#region UpdateUsersAmount

		public static void UpdateUsersBalance(DBEntities ctx, UserProfile userProfile, int plusMinusValue, bool saveChanges = true)
		{
			if(plusMinusValue == 0)
				return;

			try
			{
				userProfile.Balance += plusMinusValue;

				if(saveChanges)
					Update(ctx, userProfile);
			}
			catch(Exception e)
			{
				var msg = string.Format("Nem siker�lt friss�teni a User sz�ml�j�t. UserID: {0}. ", userProfile.ID);
				throw new BookteraException(msg, e, BookteraExceptionCode.UpdateUsersAmount);
			}
		}

		#endregion

		#region UpdateDefaultAddress

		public static void UpdateDefaultAddress(int? newDefaultAddressId, int currentUserId)
		{
			using(var ctx = new DBEntities())
			{
				UpdateDefaultAddress(ctx, newDefaultAddressId, currentUserId);
			}
		}
		public static void UpdateDefaultAddress(DBEntities ctx, int? newDefaultAddressId, int currentUserId)
		{
			var userProfile = CreateMockWithAddress(currentUserId, newDefaultAddressId, false);

			var userProfileEntry = ctx.Entry(userProfile);
			userProfileEntry.State = EntityState.Unchanged;
			userProfileEntry.Property(up => up.DefaultAddressID).IsModified = true;

			Update(ctx, userProfile);
		}

		#endregion

		#endregion

		#region DELETE

		#region Delete

		public static void Delete(UserProfile userProfile)
		{
			using(var ctx = new DBEntities())
			{
				Delete(ctx, userProfile);
			}
		}
		public static void Delete(int id)
		{
			using(var ctx = new DBEntities())
			{
				var userProfile = Get(ctx, id);
				Delete(ctx, userProfile);
			}
		}
		public static void Delete(DBEntities ctx, UserProfile userProfile)
		{
			try
			{
				ctx.UserProfile.Remove(userProfile);
				ctx.SaveChanges();
			}
			catch(Exception e)
			{
				ctx.Entry(userProfile).State = EntityState.Unchanged;
				string msg = String.Format("Nem siker�lt a UserProfile rekord t�rl�se. ID: {0}. ", userProfile.ID);
				throw new BookteraException(msg, e, BookteraExceptionCode.DeleteUserProfile);
			}
		}

		#endregion

		#endregion


		#region OTHERS

		#region CheckUserNameUnique

		public static bool CheckUserNameUnique(string userName)
		{
			using(var ctx = new DBEntities())
			{
				var friendlyUrl = userName.ToFriendlyUrl();
				return !ctx.UserProfile.Any(up => up.UserName == userName || up.FriendlyUrl == friendlyUrl);
			}
		}

		#endregion

		#region CheckEmailUnique

		public static bool CheckEmailUnique(string email, int exceptUserId = -1)
		{
			using(var ctx = new DBEntities())
			{
				var exceptEmail = exceptUserId == -1 ? "" : Get(ctx, exceptUserId).EMail;
				return !ctx.UserProfile.Any(up => up.EMail == email && up.EMail != exceptEmail);
			}
		}

		#endregion

		#region CopyFromProxy

		public static UserProfile CopyFromProxy(UserProfile userProfile)
		{
			bool wasNew;
			AutoMapperInitializer<UserProfile, UserProfile>
				.InitializeIfNeeded(out wasNew, sourceProxy: userProfile)
				.ForMemberIfNeeded(wasNew, userProfile.Property(up => up.Comments), imce => imce.Ignore())
				.ForMemberIfNeeded(wasNew, userProfile.Property(up => up.FeedbacksByRateGiverUser), imce => imce.Ignore())
				.ForMemberIfNeeded(wasNew, userProfile.Property(up => up.FeedbacksByRatedUser), imce => imce.Ignore())
				.ForMemberIfNeeded(wasNew, userProfile.Property(up => up.Images), imce => imce.Ignore())
				.ForMemberIfNeeded(wasNew, userProfile.Property(up => up.Products), imce => imce.Ignore())
				.ForMemberIfNeeded(wasNew, userProfile.Property(up => up.Ratings), imce => imce.Ignore())
				.ForMemberIfNeeded(wasNew, userProfile.Property(up => up.DefaultUserAddress), imce => imce.Ignore())
				.ForMemberIfNeeded(wasNew, userProfile.Property(up => up.UserAddresses), imce => imce.Ignore())
				.ForMemberIfNeeded(wasNew, userProfile.Property(up => up.UserGroup), imce => imce.Ignore())
				.ForMemberIfNeeded(wasNew, userProfile.Property(up => up.UserOrderByCustomer), imce => imce.Ignore())
				.ForMemberIfNeeded(wasNew, userProfile.Property(up => up.UserOrderByVendor), imce => imce.Ignore())
				.ForMemberIfNeeded(wasNew, userProfile.Property(up => up.UserViews), imce => imce.Ignore())
				.ForMemberIfNeeded(wasNew, userProfile.Property(up => up.webpages_Roles), imce => imce.Ignore());
			return Mapper.Map<UserProfile>(userProfile);
		}

		#endregion

		#region CreateViaViewModel

		public static UserProfile CreateViaViewModel(UserProfileEditVM userProfileEdit, int userId, bool withDefaults)
		{
			var userProfile = new UserProfile(withDefaults);

			userProfile.SetNonUpdatedProperties(userId);

			userProfile.EMail = userProfileEdit.EMail;
			userProfile.FullName = userProfileEdit.FullName;
			userProfile.PhoneNumber = userProfileEdit.PhoneNumber;
			userProfile.ImageUrl = userProfileEdit.ImageUrl;

			return userProfile;
		}

		#endregion

		#region CreateMockWithAddress

		public static UserProfile CreateMockWithAddress(int userId, int? defaultAddressId, bool withDefaults)
		{
			var userProfile = new UserProfile(withDefaults);

			userProfile.SetNonUpdatedProperties(userId);

			userProfile.DefaultAddressID = defaultAddressId;

			return userProfile;
		}

		#endregion

		#region SetNonUpdatedProperties

		/// <summary>
		/// - ID kell hozz�, hogy tudjuk, melyik rekordot friss�tj�k
		/// - UserName, FriendlyUrl regisztr�ci� ut�n t�bbet nem v�ltozhat meg; ezek itt
		///		kamu adatok az Entity Framework valid�ci�j�nak (mert nem nullable mez�k)
		/// - EMail friss�thet�; de pl DefaultAddress friss�t�skor nem friss�l
		/// </summary>
		public static void SetNonUpdatedProperties(this UserProfile instance, int userId)
		{
			instance.ID = userId;
			instance.UserName = "Mock for validation";
			instance.FriendlyUrl = "Mock for validation";
			instance.EMail = "Mock for validation";
		}

		#endregion

		#endregion
	}
}
