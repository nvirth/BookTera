using System;
using System.Data;
using System.Linq;
using AutoMapper;
using CommonModels.Models.EntityFramework;
using CommonPortable.Enums;
using CommonPortable.Exceptions;
using DAL.EntityFramework;
using UtilsLocal;
using UtilsShared;
using UtilsSharedPortable;

namespace BLL.EntityManagers
{
	public static class UserOrderManager
	{
		#region CREATE

		#region Add

		public static void Add(UserOrder userOrder)
		{
			using(var ctx = new DBEntities())
			{
				Add(ctx, userOrder);
			}
		}
		public static void Add(DBEntities ctx, UserOrder userOrder)
		{
			try
			{
				ctx.UserOrder.Add(userOrder);
				ctx.SaveChanges();
			}
			catch(Exception e)
			{
				ctx.Entry(userOrder).State = EntityState.Detached;
				const string msg = "Nem siker�lt besz�rni a UserOrder rekordot. ";
				throw new BookteraException(msg, e, BookteraExceptionCode.AddUserOrder_InsertFailed);
			}
		}

		#endregion

		#endregion

		#region READ

		#region GetByID

		public static UserOrder Get(int id)
		{
			using(var ctx = new DBEntities())
			{
				return Get(ctx, id);
			}
		}
		public static UserOrder Get(DBEntities ctx, int id)
		{
			try
			{
				return ctx.UserOrder.Single(p => p.ID == id);
			}
			catch(Exception e)
			{
				var msg = String.Format("Nem tal�lhat� a UserOrder rekord az adatb�zisban. ID: {0}. ", id);
				throw new BookteraException(msg, e, BookteraExceptionCode.GetUserOrderById);
			}
		}

		#endregion

		#endregion

		#region UPDATE

		#region Update

		public static void Update(UserOrder userOrder)
		{
			using(var ctx = new DBEntities())
			{
				Update(ctx, userOrder);
			}
		}
		public static void Update(DBEntities ctx, UserOrder userOrder)
		{
			try
			{
				ctx.SaveChanges();
			}
			catch(Exception e)
			{
				ctx.Entry(userOrder).State = EntityState.Unchanged;
				string msg = String.Format("Nem siker�lt a friss�teni a UserOrder rekordot! ID: {0}. ", userOrder.ID);
				throw new BookteraException(msg, e, BookteraExceptionCode.UpdateUserOrder);
			}
		}

		#endregion

		#region UpdateFeeCache

		public static void UpdateUsersOrdersFeeCache(DBEntities ctx, UserProfile userProfile, UserGroup usersGroup, bool saveChanges = true)
		{
			try
			{
				var usersOrders =
					ctx.UserOrder
						.Where(uo => uo.CustomerUserProfileID == userProfile.ID || uo.VendorUserProfileID == userProfile.ID)
						.Where(uo => uo.Status == (byte)UserOrderStatus.Cart || uo.Status == (byte)UserOrderStatus.BuyedWaiting || uo.Status == (byte)UserOrderStatus.BuyedExchangeOffered);

				foreach(var usersOrder in usersOrders)
				{
					if(usersOrder.CustomerUserProfileID == userProfile.ID)
						// The user is the customer of the order
						usersOrder.CustomersBuyFeePercent = usersGroup.BuyFeePercent;
					else
						// The user is the vendor of the order
						usersOrder.VendorsSellFeePercent = usersGroup.SellFeePercent;
				}
				if(saveChanges)
					ctx.SaveChanges();
			}
			catch(Exception e)
			{
				var msg = String.Format("Nem siker�lt friss�teni a felhaszn�l�hoz ({0}) tartoz� rendel�sek fee cache-�t. ", userProfile.UserName);
				throw new BookteraException(msg, e, BookteraExceptionCode.UpdateUsersOrdersFeeCache);
			}
		}

		#endregion

		#region SynchronizeToPio

		///  <summary>
		///  Szinkroniz�lja a UserOrder t�bl�t a ProductInOrder t�bl�ban t�rt�nt m�dos�t�sokhoz.
		/// 
		/// Sz�mol�s p�ld�k:
		/// r�gi mennyis�g - �j mennyis�g - �j_m�nusz_r�gi
		///        0               1              +1          (Add)
		///        1               2              +1          (Update +)
		///        2               1              -1          (Update -)
		///        4               0              -4          (Delete)
		///  </summary>
		public static void SynchronizeToPio(DBEntities ctx, ProductInOrder oldPio, UserOrder userOrder, ProductInOrder newPio, bool saveChanges = true)
		{
			// Ha most tett�k a kos�rba az els� term�ket, be�ll�tjuk a FeePercent cache-eket is
			if(userOrder.CustomersBuyFeePercent == 0 || userOrder.VendorsSellFeePercent == 0)
			{
				var customersUserGroup = userOrder.CustomerUserProfile.UserGroup;
				userOrder.CustomersBuyFeePercent = customersUserGroup.BuyFeePercent;

				var vendorsUserGroup = userOrder.VendorUserProfile.UserGroup;
				userOrder.VendorsSellFeePercent = vendorsUserGroup.SellFeePercent;
			}

			int minusOld = (oldPio.UnitPrice * oldPio.HowMany) * (-1);
			int plusNew = (newPio.UnitPrice * newPio.HowMany) * (+1);
			userOrder.SumBookPrice += minusOld + plusNew;

			if(saveChanges)
				Update(ctx, userOrder);
		}

		#endregion

		public static void UpdateUserOrdersAddress(int userAddressId, int userOrderId, int currentUserId)
		{
			using(var ctx = new DBEntities())
			{
				try
				{
					var userOrder = TransactionManager.GetUserOrderItem(ctx, currentUserId, userOrderId, statusesToCheck: new[] { UserOrderStatus.Cart, UserOrderStatus.BuyedWaiting });
					if(userOrder.Status == (byte)UserOrderStatus.Cart
					   && userOrder.CustomerUserProfileID == currentUserId)
					{
						userOrder.CustomerAddressID = userAddressId;
					}
					else if(userOrder.Status == (byte)UserOrderStatus.BuyedWaiting
					        && userOrder.VendorUserProfileID == currentUserId)
					{
						userOrder.VendorAddressID = userAddressId;
					}
					else
					{
						var msg = string.Format("A megadott tranzakci� (ID: {0}) c�m�t a megadott felhaszn�l� (ID: {1}) nem m�dos�thatja. Tranzakci� t�pusa: {2}", userOrderId, currentUserId, (UserOrderStatus)userOrder.Status);
						throw new BookteraException(msg, code: BookteraExceptionCode.UpdateUserOrdersAddress_NoRights);
					}

					ctx.SaveChanges();
				}
				catch (Exception e)
				{
					var msg = string.Format("Nem siker�lt friss�teni a tranzakci� (ID: {0}) c�m�t", userOrderId);
					throw new BookteraException(msg, e, BookteraExceptionCode.UpdateUserOrdersAddress);
				}
			}
		}

		#endregion

		#region DELETE

		#region Delete

		public static void Delete(UserOrder userOrder)
		{
			using(var ctx = new DBEntities())
			{
				Delete(ctx, userOrder);
			}
		}
		public static void Delete(int id)
		{
			using(var ctx = new DBEntities())
			{
				var userOrder = Get(ctx, id);
				Delete(ctx, userOrder);
			}
		}
		public static void Delete(DBEntities ctx, UserOrder userOrder)
		{
			try
			{
				ctx.UserOrder.Remove(userOrder);
				ctx.SaveChanges();
			}
			catch(Exception e)
			{
				ctx.Entry(userOrder).State = EntityState.Unchanged;
				string msg = String.Format("Nem siker�lt a UserOrder rekord t�rl�se. ID: {0}. ", userOrder.ID);
				throw new BookteraException(msg, e, BookteraExceptionCode.DeleteUserOrder);
			}
		}

		#endregion

		#endregion


		#region OTHERS

		#region CopyFromProxy

		public static UserOrder CopyFromProxy(UserOrder userOrder)
		{
			bool wasNew;
			AutoMapperInitializer<UserOrder, UserOrder>
				.InitializeIfNeeded(out wasNew, sourceProxy: userOrder)
				.ForMemberIfNeeded(wasNew, userOrder.Property(uo => uo.Feedbacks), imce => imce.Ignore())
				.ForMemberIfNeeded(wasNew, userOrder.Property(uo => uo.ProductsInOrder), imce => imce.Ignore())
				.ForMemberIfNeeded(wasNew, userOrder.Property(uo => uo.CustomerAddress), imce => imce.Ignore())
				.ForMemberIfNeeded(wasNew, userOrder.Property(uo => uo.CustomerUserProfile), imce => imce.Ignore())
				.ForMemberIfNeeded(wasNew, userOrder.Property(uo => uo.VendorUserProfile), imce => imce.Ignore())
				.ForMemberIfNeeded(wasNew, userOrder.Property(uo => uo.VendorAddress), imce => imce.Ignore());
			return Mapper.Map<UserOrder>(userOrder);
		}

		#endregion
		
		#endregion
	}
}
