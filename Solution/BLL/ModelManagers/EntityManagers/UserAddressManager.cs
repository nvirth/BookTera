using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Transactions;
using AutoMapper;
using BLL.ModelManagers;
using CommonModels.Methods;
using CommonModels.Methods.ManagerRelief;
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
	public static class UserAddressManager
	{
		#region CREATE

		#region Add

		public static void Add(UserAddress userAddress, bool isDefault = false, UserProfile userProfile = null)
		{
			using(var ctx = new DBEntities())
			{
				if(isDefault)
				{
					using(var transactionScope = new TransactionScope())
					{
						Add(ctx, userAddress, /*isDefault*/ true, userProfile);
						transactionScope.Complete();
					}
				}
				// Nem nyitunk transaction scope-ot, ha nem default; mert akkor csak 1 táblát érintünk
				else
				{
					Add(ctx, userAddress, /*isDefault*/ false, userProfile);
				}
			}
		}
		public static void Add(DBEntities ctx, UserAddress userAddress, bool isDefault = false, UserProfile userProfile = null)
		{
			try
			{
				ctx.UserAddress.Add(userAddress);
				ctx.SaveChanges();
			}
			catch(Exception e)
			{
				ctx.Entry(userAddress).State = EntityState.Detached;
				const string msg = "Nem sikerült beszúrni a UserAddress rekordot. ";
				throw new BookteraException(msg, e, BookteraExceptionCode.AddUserAddress_InsertFailed);
			}

			if(isDefault)
			{
				// Navigation propertyn keresztül még nem megy
				userProfile = userProfile ?? UserProfileManager.Get(ctx, userAddress.UserID);

				try
				{
					userProfile.DefaultAddressID = userAddress.ID;
					ctx.SaveChanges();
				}
				catch(Exception e)
				{
					var msg = string.Format("Nem sikerült alapértelmezetté tenni a felhasználó címét, de sikerült beszúrni a UserAddress táblába. UserName: {0}", userProfile.UserName);
					throw new BookteraException(msg, e, BookteraExceptionCode.AddUserAddress_MakeItDefaultFailed);
				}
			}
		}

		#endregion

		#region AddByViewModel

		public static int Add(UserAddressVM userAddressVm, int userId)
		{
			var userAddress = CreateViaViewModel(userAddressVm, userId, true);
			Add(userAddress, userAddressVm.IsDefault);
			return userAddress.ID;
		}

		#endregion

		#endregion

		#region READ

		#region GetByID

		public static UserAddress Get(int id)
		{
			using(var ctx = new DBEntities())
			{
				return Get(ctx, id);
			}
		}
		public static UserAddress Get(DBEntities ctx, int id)
		{
			try
			{
				return ctx.UserAddress.Single(ua => ua.ID == id);
			}
			catch(Exception e)
			{
				var msg = String.Format("Nem található a UserAddress rekord az adatbázisban. ID: {0}. ", id);
				throw new BookteraException(msg, e, BookteraExceptionCode.GetUserAddressById);
			}
		}

		#endregion

		#region GetUsersAddresses

		public static List<UserAddressVM> GetUsersAddresses(int userId)
		{
			using(var ctx = new DBEntities())
			{
				var userProfile = UserProfileManager.Get(ctx, userId);
				int defaultAddressId = userProfile.DefaultAddressID.HasValue ? userProfile.DefaultAddressID.Value : -1;

				var result = new List<UserAddressVM>();
				foreach(var userAddress in ctx.UserAddress.Where(ua => ua.UserID == userId))
				{
					bool isDefault = defaultAddressId == userAddress.ID;
					result.Add(new UserAddressVM().DoConsturctorWork(userAddress, isDefault));
				}
				return result;
			}
		}

		#endregion

		#endregion

		#region UPDATE

		#region Update

		public static void Update(UserAddress userAddress)
		{
			using(var ctx = new DBEntities())
			{
				Update(ctx, userAddress);
			}
		}
		public static void Update(DBEntities ctx, UserAddress userAddress)
		{
			try
			{
				ctx.SaveChanges();
			}
			catch(Exception e)
			{
				ctx.Entry(userAddress).State = EntityState.Unchanged;
				string msg = String.Format("Nem sikerült a frissíteni a UserAddress rekordot! ID: {0}. ", userAddress.ID);
				throw new BookteraException(msg, e, BookteraExceptionCode.UpdateUserAddress);
			}
		}

		#endregion

		#region UpdateByViewModel

		public static void Update(UserAddressVM userAddressVm, int userId)
		{
			using(var ctx = new DBEntities())
			{
				var userAddress = Get(ctx, userAddressVm.Id);
				if(userAddress.UserID != userId)
				{
					var msg = string.Format("A felhasználó nem a saját címét módosítaná! Támadó UserId: {0}, áldozat: {1}. ", userId, userAddress.UserID);
					throw new BookteraException(msg, code: BookteraExceptionCode.UpdateUserAddress_NotOwnAddress);
				}

				userAddress.SetProperties(userAddressVm);
				Update(ctx, userAddress);
			}
		}

		#endregion

		#endregion

		#region DELETE

		#region Delete

		public static void Delete(UserAddress userAddress)
		{
			using(var ctx = new DBEntities())
			{
				Delete(ctx, userAddress);
			}
		}
		public static void Delete(int userAddressId, int currentUserId, bool isDefault)
		{
			using(var ctx = new DBEntities())
			{
				var userAddress = Get(ctx, userAddressId);
				if(userAddress.UserID != currentUserId)
				{
					var msg = string.Format("A felhasználó nem a saját címét törölné! Támadó UserId: {0}, áldozat: {1}. ", currentUserId, userAddress.UserID);
					throw new BookteraException(msg, code: BookteraExceptionCode.DeleteUserAddress_NotOwnAddress);
				}

				if (isDefault)
				{
					using (var transactionScope = new TransactionScope())
					{
						UserProfileManager.UpdateDefaultAddress(ctx, null, currentUserId);
						Delete(ctx, userAddress);
						transactionScope.Complete();
					}
				}
				else
				{
					Delete(ctx, userAddress);
				}
			}
		}
		public static void Delete(DBEntities ctx, UserAddress userAddress)
		{
			try
			{
				ctx.UserAddress.Remove(userAddress);
				ctx.SaveChanges();
			}
			catch(Exception e)
			{
				ctx.Entry(userAddress).State = EntityState.Unchanged;
				string msg = String.Format("Nem sikerült a UserAddress rekord törlése. ID: {0}. ", userAddress.ID);
				throw new BookteraException(msg, e, BookteraExceptionCode.DeleteUserAddress);
			}
		}

		#endregion

		#endregion


		#region OTHERS

		#region ToString

		public static string ToString(UserAddress userAddress)
		{
			return UserAddressManagerRelief.ToString(userAddress);
		}

		#endregion

		#region CopyFromProxy

		public static UserAddress CopyFromProxy(UserAddress userAddress)
		{
			bool wasNew;
			AutoMapperInitializer<UserAddress, UserAddress>
				.InitializeIfNeeded(out wasNew, sourceProxy: userAddress)
				.ForMemberIfNeeded(wasNew, userAddress.Property(ua => ua.UserProfile), imce => imce.Ignore());
			return Mapper.Map<UserAddress>(userAddress);
		}

		#endregion

		#region CreateByViewModel

		public static UserAddress CreateViaViewModel(UserAddressVM userAddressVm, int userId, bool withDefaults)
		{
			var userAddress = new UserAddress();
			userAddress.SetProperties(userAddressVm, userId);

			return userAddress;
		}

		#endregion

		#region SetProperties

		public static void SetProperties(this UserAddress instance, UserAddressVM userAddressVm, int userId = -1)
		{
			instance.ZipCode = userAddressVm.ZipCode;
			instance.City = userAddressVm.City;
			instance.StreetAndHouseNumber = userAddressVm.StreetAndHouseNumber;
			instance.Country = userAddressVm.Country;

			if (userId != -1)
				instance.UserID = userId;
		}

		#endregion

		#endregion
	}
}
