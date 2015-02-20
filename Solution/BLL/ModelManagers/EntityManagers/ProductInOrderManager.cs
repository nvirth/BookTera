using System;
using System.Data;
using System.Linq;
using System.Transactions;
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
	public static class ProductInOrderManager
	{
		#region CREATE

		#region Add

		public static void Add(DBEntities ctx, ProductInOrder productInOrder)
		{
			try
			{
				ctx.ProductInOrder.Add(productInOrder);
				ctx.SaveChanges();
			}
			catch(Exception e)
			{
				ctx.Entry(productInOrder).State = EntityState.Detached;
				const string msg = "Nem sikerült beszúrni a ProductInOrder rekordot. ";
				throw new BookteraException(msg, e, BookteraExceptionCode.AddProductInOrder_InsertFailed);
			}
		}

		#endregion

		#region AddToCart

		public static void AddToCart(DBEntities ctx, ProductInOrder productInOrder, UserOrder userOrder)
		{
			try
			{
				ctx.ProductInOrder.Add(productInOrder);
				ctx.SaveChanges(); // Ez nem hagyható el opt. miatt!

				var oldPio = new ProductInOrder(false)
				{
					HowMany = 0,
					UnitPrice = 0
				};

				UserOrderManager.SynchronizeToPio(ctx, oldPio, userOrder, productInOrder);
			}
			catch(Exception e)
			{
				ctx.Entry(productInOrder).State = EntityState.Detached;
				const string msg = "Nem sikerült beszúrni a ProductInOrder rekordot. ";
				throw new BookteraException(msg, e, BookteraExceptionCode.AddProductInOrder_InsertFailed);
			}
		}

		#endregion

		#endregion

		#region READ

		#region GetByID - Normal - Exchange

		public static ProductInOrder GetNormal(int id)
		{
			using (var ctx = new DBEntities())
			{
				return GetNormal(ctx, id);
			}
		}
		public static ProductInOrder GetNormal(DBEntities ctx, int id)
		{
			try
			{
				return ctx.ProductInOrder.Single(p => p.ID == id && !p.IsForExchange);
			}
			catch (Exception e)
			{
				var msg = String.Format("Nem található a ProductInOrder rekord az adatbázisban. ID: {0}. ", id);
				throw new BookteraException(msg, e, BookteraExceptionCode.GetProductInOrderById);
			}
		}

		public static ProductInOrder GetExchange(int id)
		{
			using(var ctx = new DBEntities())
			{
				return GetExchange(ctx, id);
			}
		}
		public static ProductInOrder GetExchange(DBEntities ctx, int id)
		{
			try
			{
				return ctx.ProductInOrder.Single(p => p.ID == id && p.IsForExchange);
			}
			catch(Exception e)
			{
				var msg = String.Format("Nem található a ProductInOrder rekord az adatbázisban. ID: {0}. ", id);
				throw new BookteraException(msg, e, BookteraExceptionCode.GetProductInOrderById);
			}
		}
		
		#endregion

		#region Get by ProductId && UserOrderId

		public static ProductInOrder GetNormal(DBEntities ctx, int productId, int userOrderId)
		{
			try
			{
				return ctx.ProductInOrder.Single(pio => pio.ProductID == productId && pio.UserOrderID == userOrderId);
			}
			catch(Exception e)
			{
				var msg = String.Format("Nem található a ProductInOrder rekord. ProductID: {0}, UserOrderID: {1}.", productId, userOrderId);
				throw new BookteraException(msg, e, BookteraExceptionCode.GetProductInOrderItem);
			}
		}

		#endregion
		
		#endregion

		#region UPDATE

		#region UpdateInCart

		public static void UpdateInCart(DBEntities ctx, ProductInOrder oldPio, UserOrder userOrder, ProductInOrder newPio)
		{
			try
			{
				ctx.Entry(oldPio).State = EntityState.Detached;
				ctx.Entry(newPio).State = EntityState.Modified; // TODO: Nem-e elég csak propterty szinten

				ctx.SaveChanges();

				UserOrderManager.SynchronizeToPio(ctx, oldPio, userOrder, newPio);
			}
			catch(Exception e)
			{
				ctx.Entry(newPio).State = EntityState.Unchanged;
				var msg = string.Format("Nem sikerült a ProductInOrder rekord frissítése. ID: {0}. ", oldPio.ID);
				throw new BookteraException(msg, e, BookteraExceptionCode.UpdateProductInOrder);
			}
		}
		
		#endregion
		
		#region Update

		public static void Update(DBEntities ctx, ProductInOrder productInOrder)
		{
			try
			{
				ctx.SaveChanges();
			}
			catch(Exception e)
			{
				ctx.Entry(productInOrder).State = EntityState.Unchanged;
				var msg = string.Format("Nem sikerült a ProductInOrder rekord frissítése. ID: {0}. ", productInOrder.ID);
				throw new BookteraException(msg, e, BookteraExceptionCode.UpdateProductInOrder);
			}
		}
		
		#endregion
	
		#region ManageProductByUpdate

		public static void ManageProductByUpdate(DBEntities ctx, TransactionScope transactionScope, ProductInOrder productInOrder, int newHowMany)
		{
			int howManyNeededMore = newHowMany - productInOrder.HowMany;

			if(howManyNeededMore == 0)
			{
				transactionScope.Complete();
				const string msg = "Nem változott a mennyiség. ";
				throw new BookteraException(msg, code: BookteraExceptionCode.ManageProductByUpdate_NoUpdateNeeded);
			}

			var product = productInOrder.Product;

			if(product.IsDownloadable)
			{
				transactionScope.Complete();
				const string msg = "Elektronikus termékbõl nem lehet többet venni. ";
				throw new BookteraException(msg, code: BookteraExceptionCode.ManageProductByUpdate_NoUpdateNeeded);
			}

			if(howManyNeededMore > 0)
				ProductManager.CheckExistEnoughToBuy(product, howManyNeededMore);

			ProductManager.UpdateQuantity(ctx, product, -howManyNeededMore);
		}
		
		#endregion

		#endregion

		#region DELETE

		#region Delete

		public static void Delete(DBEntities ctx, ProductInOrder productInOrder)
		{
			try
			{
				ctx.ProductInOrder.Remove(productInOrder);
				ctx.SaveChanges();
			}
			catch(Exception e)
			{
				ctx.Entry(productInOrder).State = EntityState.Unchanged;
				string msg = String.Format("Nem sikerült a ProductInOrder rekord törlése. ID: {0}. ", productInOrder.ID);
				throw new BookteraException(msg, e, BookteraExceptionCode.DeleteProductInOrder);
			}
		}

		#endregion

		#region DeleteFromCart

		public static void DeleteFromCart(DBEntities ctx, ProductInOrder productInOrder, UserOrder userOrder, UserProfile customerUserProfile, UserProfile vendorUserProfile)
		{
			try
			{
				var newPio = new ProductInOrder(false)
				{
					HowMany = 0,
					UnitPrice = 0,
				};

				UserOrderManager.SynchronizeToPio(ctx, productInOrder, userOrder, newPio, saveChanges: false);

				ctx.ProductInOrder.Remove(productInOrder);

				if(userOrder.SumBookPrice == 0) // Ha kiürült a kosár
				{
					ctx.UserOrder.Remove(userOrder);
					UserProfileManager.UpdateSellBuyCache(ctx, customerUserProfile, vendorUserProfile, UserOrderStatus.CartDeleting);
				}

				ctx.SaveChanges();
			}
			catch(Exception e)
			{
				ctx.Entry(productInOrder).State = EntityState.Unchanged;
				string msg = String.Format("Nem sikerült a ProductInOrder rekord törlése. ID: {0}. ", productInOrder.ID);
				throw new BookteraException(msg, e, BookteraExceptionCode.DeleteProductInOrder);
			}
		}

		#endregion

		#endregion
		
		
		#region OTHERS

		#region CopyFromProxy

		public static ProductInOrder CopyFromProxy(ProductInOrder productInOrder)
		{
			bool wasNew;
			AutoMapperInitializer<ProductInOrder, ProductInOrder>
				.InitializeIfNeeded(out wasNew, sourceProxy: productInOrder)
				.ForMemberIfNeeded(wasNew, productInOrder.Property(pi => pi.Product), imce => imce.Ignore())
				.ForMemberIfNeeded(wasNew, productInOrder.Property(pi => pi.UserOrder), imce => imce.Ignore());
			return Mapper.Map<ProductInOrder>(productInOrder);
		}

		#endregion

		#endregion
	}
}
