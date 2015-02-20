using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Transactions;
using BLL.EntityManagers;
using BLL.ModelManagers;
using CommonModels.Models;
using CommonModels.Models.EntityFramework;
using CommonPortable.Enums;
using CommonPortable.Exceptions;
using DAL.EntityFramework;
using DAL.PushNotification;
using UtilsLocal;

namespace BLL
{
	public class TransactionManager
	{
		#region READ

		#region GetUserOrderItem - in many variations

		public static UserOrder GetCartUserOrderItem(DBEntities ctx, int currentUserId, ProductInOrder productInOrder = null, int userOrderId = -1, bool checkCustomerHasAddress = false)
		{
			if(!((productInOrder != null) ^ (userOrderId != -1)))
			{
				const string msg = "A GetCartUserOrderItem fv vagy egy ProductInOrder objektumot, vagy egy userOrderId-t vár bemenetként (pontosan egyet). ";
				throw new BookteraException(msg, code: BookteraExceptionCode.GetCartUserOrderItem_ArgumentWrong);
			}

			UserOrder userOrder;

			if(productInOrder != null)
				userOrder = GetUserOrderItem(ctx, currentUserId, userOrder: productInOrder.UserOrder, checkCustomer: true, statusesToCheck: new[] { UserOrderStatus.Cart }, checkCustomerHasAddress: checkCustomerHasAddress);
			else //if(userOrderId != -1)
				userOrder = GetUserOrderItem(ctx, currentUserId, userOrderId: userOrderId, checkCustomer: true, statusesToCheck: new[] { UserOrderStatus.Cart }, checkCustomerHasAddress: checkCustomerHasAddress);

			return userOrder;
		}

		public static UserOrder GetBuyedWaitingUserOrderItem(DBEntities ctx, int currentUserId, ProductInOrder productInOrder = null, int userOrderId = -1, bool checkHasExchange = false, bool checkVendorHasAddress = false)
		{
			if(!((productInOrder != null) ^ (userOrderId != -1)))
			{
				const string msg = "A GetBuyedWaitingUserOrderItem fv vagy egy ProductInOrder objektumot, vagy egy userOrderId-t vár bemenetként (pontosan egyet). ";
				throw new BookteraException(msg, code: BookteraExceptionCode.GetBuyedWaitingUserOrderItem_ArgumentWrong);
			}

			UserOrder userOrder;

			if(productInOrder != null)
				userOrder = GetUserOrderItem(ctx, currentUserId, userOrder: productInOrder.UserOrder, checkVendor: true, statusesToCheck: new[] { UserOrderStatus.BuyedWaiting }, checkHasExchange: checkHasExchange, checkVendorHasAddress: checkVendorHasAddress);
			else //if(userOrderId != -1)
				userOrder = GetUserOrderItem(ctx, currentUserId, userOrderId: userOrderId, checkVendor: true, statusesToCheck: new[] { UserOrderStatus.BuyedWaiting }, checkHasExchange: checkHasExchange, checkVendorHasAddress: checkVendorHasAddress);

			return userOrder;
		}
		public static UserOrder GetBuyedExchangeOfferedUserOrderItem(DBEntities ctx, int currentUserId, ProductInOrder productInOrder = null, int userOrderId = -1)
		{
			if(!((productInOrder != null) ^ (userOrderId != -1)))
			{
				const string msg = "A GetBuyedExchangeOfferedUserOrderItem fv vagy egy ProductInOrder objektumot, vagy egy userOrderId-t vár bemenetként (pontosan egyet). ";
				throw new BookteraException(msg, code: BookteraExceptionCode.GetBuyedExchangeOfferedUserOrderItem_ArgumentWrong);
			}

			UserOrder userOrder;

			if(productInOrder != null)
				userOrder = GetUserOrderItem(ctx, currentUserId, userOrder: productInOrder.UserOrder, checkCustomer: true, statusesToCheck: new[] { UserOrderStatus.BuyedExchangeOffered });
			else //if(userOrderId != -1)
				userOrder = GetUserOrderItem(ctx, currentUserId, userOrderId: userOrderId, checkCustomer: true, statusesToCheck: new[] { UserOrderStatus.BuyedExchangeOffered });

			return userOrder;
		}
		public static UserOrder GetExchangeCartForRemoveUserOrderItem(DBEntities ctx, int currentUserId, int userOrderId)
		{
			var userOrder = GetUserOrderItem(ctx, currentUserId, userOrderId, checkVendor: true, statusesToCheck: new[] { UserOrderStatus.BuyedWaiting });
			return userOrder;
		}
		public static UserOrder GetFinalizedOrFinishedUserOrderItem(DBEntities ctx, int currentUserId, ProductInOrder productInOrder = null, int userOrderId = -1)
		{
			if(!((productInOrder != null) ^ (userOrderId != -1)))
			{
				const string msg = "A GetFinalizedUserOrderItem fv vagy egy ProductInOrder objektumot, vagy egy userOrderId-t vár bemenetként (pontosan egyet). ";
				throw new BookteraException(msg, code: BookteraExceptionCode.GetFinalizedUserOrderItem_ArgumentWrong);
			}

			UserOrder userOrder;

			if(productInOrder != null)
				userOrder = GetUserOrderItem(ctx, currentUserId, userOrder: productInOrder.UserOrder, statusesToCheck: new[] { UserOrderStatus.FinalizedCash, UserOrderStatus.FinalizedExchange, UserOrderStatus.Finished }, checkCustomer: true, checkVendor: true);
			else //if(userOrderId != -1)
				userOrder = GetUserOrderItem(ctx, currentUserId, userOrderId: userOrderId, statusesToCheck: new[] { UserOrderStatus.FinalizedCash, UserOrderStatus.FinalizedExchange, UserOrderStatus.Finished }, checkCustomer: true, checkVendor: true);

			return userOrder;
		}

		public static UserOrder GetUserOrderItem(DBEntities ctx, int currentUserId, int userOrderId = -1, UserOrder userOrder = null, UserOrderStatus[] statusesToCheck = null, bool checkCustomer = false, bool checkVendor = false, bool checkHasExchange = false, bool checkCustomerHasAddress = false, bool checkVendorHasAddress = false)
		{
			userOrder = userOrder ?? UserOrderManager.Get(ctx, userOrderId);

			// Check the order's  status
			if((statusesToCheck != null) && (!statusesToCheck.Cast<byte>().Contains(userOrder.Status)))
			{
				var msg = string.Format("A megadott UserOrder rekord (ID: {0}) nem az elvárt típusú ({1}). ", userOrderId, string.Join(" | ", statusesToCheck));
				throw new BookteraException(msg, code: BookteraExceptionCode.GetUserOrderItem_WrongStatus);
			}

			// Check if the current user is the UserOrders vendor or customer
			if(checkVendor && checkCustomer)
			{
				if((userOrder.CustomerUserProfileID != currentUserId)
					&& (userOrder.VendorUserProfileID != currentUserId))
				{
					var msg = string.Format("A megadott UserOrder rekordban (ID: {0}) a felhasználó (ID: {1}) se nem eladó, se nem vevő. ", userOrderId, currentUserId);
					throw new BookteraException(msg, code: BookteraExceptionCode.GetUserOrder_WrongUser);
				}
			}
			// Check only for customer or vendor
			else
			{
				if((checkCustomer) && (userOrder.CustomerUserProfileID != currentUserId))
				{
					var msg = string.Format("A megadott UserOrder rekordban (ID: {0}) a felhasználó (ID: {1}) nem vevő. ", userOrderId, currentUserId);
					throw new BookteraException(msg, code: BookteraExceptionCode.GetUserOrder_WrongUser);
				}

				if((checkVendor) && (userOrder.VendorUserProfileID != currentUserId))
				{
					var msg = string.Format("A megadott UserOrder rekordban (ID: {0}) a felhasználó (ID: {1}) nem eladó. ", userOrderId, currentUserId);
					throw new BookteraException(msg, code: BookteraExceptionCode.GetUserOrder_WrongUser);
				}
			}

			// Check that the order has exchange products
			if((checkHasExchange) && (!userOrder.ProductsInOrder.Any(pio => pio.IsForExchange)))
			{
				var msg = string.Format("A megadott UserOrder rekordban (ID: {0}) nincsenek csere-termékek. ", userOrderId);
				throw new BookteraException(msg, code: BookteraExceptionCode.GetUserOrder_NoExchangeProducts);
			}

			// Check if customer has got an address in the order
			if((checkCustomerHasAddress) && (!userOrder.CustomerAddressID.HasValue))
			{
				var msg = string.Format("A megadott UserOrder rekordban (ID: {0}) a vevőnek (ID: {1}) nincs címe. ", userOrderId, userOrder.CustomerUserProfileID);
				throw new BookteraException(msg, code: BookteraExceptionCode.GetUserOrder_CustomerHasNoAddress);
			}

			// Check if vendor has got an address in the order
			if((checkVendorHasAddress) && (!userOrder.VendorAddressID.HasValue))
			{
				var msg = string.Format("A megadott UserOrder rekordban (ID: {0}) az eladónak (ID: {1}) nincs címe. ", userOrderId, userOrder.VendorUserProfileID);
				throw new BookteraException(msg, code: BookteraExceptionCode.GetUserOrder_VendorHasNoAddress);
			}

			return userOrder;
		}

		#endregion

		#region GetUsersCartByVendorId

		public static UserOrder GetUsersCartByVendorId(DBEntities ctx, int customerId, int vendorId)
		{
			var carts = GetUsersCartsOrOtherOrders(ctx, TransactionType.CartOwn, customerId);
			var cartByVendor = carts.Where(uo => uo.VendorUserProfileID == vendorId);
			UserOrder cart;

			try
			{
				cart = cartByVendor.SingleOrDefault();
			}
			catch(Exception)
			{
				// Lehetséges implementálási hiba javítása
				var msg = string.Format("A vevőnek több kosara is van ugyanahhoz az eladóhoz. VevőId: {0}, EladóId: {1}. ", customerId, vendorId);
				cart = cartByVendor.OrderByDescending(uo => uo.Date).First();
			}

			return cart;
		}

		#endregion

		#region GetUsersOrders (Cart|InProgress|Finished) InUserOrderViewModels

		public static List<UserOrderPLVM> GetUsersCartsVM(int? customerId = null, int? vendorId = null)
		{
			using(var ctx = new DBEntities())
			{
				var transactionType = customerId.HasValue ? TransactionType.CartOwn : TransactionType.CartOthers;
				return GetTransaction(ctx, transactionType, customerId, vendorId);
			}
		}
		public static List<UserOrderPLVM> GetUsersInProgressOrdersVM(int? customerId = null, int? vendorId = null)
		{
			using(var ctx = new DBEntities())
			{
				var transactionType = customerId.HasValue ? TransactionType.InProgressOrderOwn : TransactionType.InProgressOrderOthers;
				return GetTransaction(ctx, transactionType, customerId, vendorId);
			}
		}
		public static List<UserOrderPLVM> GetUsersFinishedTransactionsVM(int? customerId = null, int? vendorId = null)
		{
			using(var ctx = new DBEntities())
			{
				var transactionType = customerId.HasValue ? TransactionType.FinishedOrderOwn : TransactionType.FinishedOrderOthers;
				return GetTransaction(ctx, transactionType, customerId, vendorId);
			}
		}
		private static List<UserOrderPLVM> GetTransaction(DBEntities ctx, TransactionType transactionType, int? customerId = null, int? vendorId = null)
		{
			var userOrders = GetUsersCartsOrOtherOrders(ctx, transactionType, customerId, vendorId).OrderByDescending(uo => uo.Date);

			var result = new List<UserOrderPLVM>();
			foreach(var userOrder in userOrders)
			{
				result.Add(new UserOrderPLVM().DoConsturctorWork(userOrder, transactionType, isForCustomer: customerId.HasValue));
			}
			return result;
		}

		#endregion

		#region GetUsersCartsOrEarlierOrders (IQueryable)

		private static IQueryable<UserOrder> GetUsersCartsOrOtherOrders(DBEntities ctx, TransactionType transactionType, int? customerId = null, int? vendorId = null)
		{
			if(!((customerId != null) ^ (vendorId != null)))
			{
				const string msg = "A GetUsersCartsOrEarlierOrders függvény vagy customerId-t vár, vagy vendorId-t (pontosan egyet). ";
				throw new BookteraException(msg, code: BookteraExceptionCode.GetUsersCartsOrEarlierOrders_ArgumentWrong);
			}

			bool isCart = transactionType == TransactionType.CartOwn || transactionType == TransactionType.CartOthers;
			bool isInProgress = transactionType == TransactionType.InProgressOrderOwn || transactionType == TransactionType.InProgressOrderOthers;
			bool isFinished = transactionType == TransactionType.FinishedOrderOwn || transactionType == TransactionType.FinishedOrderOthers;

			return
				from uo in ctx.UserOrder
				// ID (Customer vagy Vendor)
				where (!customerId.HasValue || uo.CustomerUserProfileID == customerId)
				where (!vendorId.HasValue || uo.VendorUserProfileID == vendorId)
				// Status
				where (!isCart || uo.Status == (byte)UserOrderStatus.Cart)			// Kosár
				where (!isInProgress || uo.Status >= 10 && uo.Status < 30)			// Folyamatban (sáv)
				where (!isFinished || uo.Status == (byte)UserOrderStatus.Finished)	// Befejezett
				select uo;
		}

		#endregion

		#endregion

		#region TransactionSteps

		#region Step 1 - Cart

		#region CreateEmtyCartForUser

		private static UserOrder CreateEmtyCartForUser(DBEntities ctx, UserProfile customer, int vendorId)
		{
			try
			{
				var cart = new UserOrder(true)
				{
					CustomerUserProfileID = customer.ID,
					VendorUserProfileID = vendorId,
					Date = DateTime.Now,
					Status = (int)UserOrderStatus.Cart,
					CustomerAddressID = customer.DefaultAddressID,
				};

				UserOrderManager.Add(ctx, cart);
				return cart;
			}
			catch(Exception e)
			{
				const string msg = "Nem sikerült létrehozni az új, üres kosarat!";
				throw new BookteraException(msg, e, BookteraExceptionCode.CreateEmtyCartForUser);
			}
		}

		#endregion

		#region Get UsersCartByVendorId Or CreateEmpty

		public static UserOrder GetUsersCartByVendorIdOrCreateEmpty(DBEntities ctx, UserProfile customer, UserProfile vendor, out bool newCreated)
		{
			var existingCarts = GetUsersCartByVendorId(ctx, customer.ID, vendor.ID);
			if(existingCarts != null)
			{
				newCreated = false;
				return existingCarts;
			}
			else
			{
				newCreated = true;
				return CreateEmtyCartForUser(ctx, customer, vendor.ID);
			}
		}

		#endregion

		#region AddProductToCart

		public static void AddProductToCart(int currentUserId, int productId)
		{
			try
			{
				using(var ctx = new DBEntities())
				using(var transactionScope = new TransactionScope())
				{
					var product = ProductManager.Get(ctx, productId);
					ProductManager.CheckUser(product, currentUserId, checkCustomersOwnProduct: true);
					ProductManager.CheckExistEnoughToBuy(product, 1);

					var vendorUserProfile = product.UserProfile;
					var customerUserProfile = UserProfileManager.Get(ctx, currentUserId);

					bool newCreated;
					var userOrder = GetUsersCartByVendorIdOrCreateEmpty(ctx, customerUserProfile, vendorUserProfile, out newCreated);

					if(newCreated)
						UserProfileManager.UpdateSellBuyCache(ctx, customerUserProfile, vendorUserProfile, UserOrderStatus.Cart);

					AddProductToCart_CreateOrUpdatePio(ctx, product, userOrder);

					ProductManager.UpdateQuantity(ctx, product, -1, vendorUserProfile);

					transactionScope.Complete();
				}
			}
			catch(Exception e)
			{
				const string msg = "Nem sikerült kosárba tenni a terméket.";
				throw new BookteraException(msg, e, BookteraExceptionCode.AddProductToCart);
			}
		}
		private static void AddProductToCart_CreateOrUpdatePio(DBEntities ctx, Product product, UserOrder userOrder)
		{
			var productInOrder = new ProductInOrder(true)
			{
				HowMany = 1,
				ProductID = product.ID,
				UserOrderID = userOrder.ID,
				UnitPrice = product.Price
			};
			try
			{
				ProductInOrderManager.AddToCart(ctx, productInOrder, userOrder);
			}
			catch(BookteraException e)
			{
				// Ha nem sikerült a beszúrás a ProductInOrder táblába, hátha csak azért nem, mert már létezett a rekord
				// Ez akkor fordulhat elő, ha nem a kosarában módosította a vásárolni kívánt mennyiséget, hanem
				//  többedjére rakott kosárba egy terméket

				bool isNotUpdateUserOrderException = ((e.InnerException as BookteraException) ?? new BookteraException()).Code != BookteraExceptionCode.UpdateUserOrder;

				if((e.Code == BookteraExceptionCode.AddProductInOrder_InsertFailed) && (isNotUpdateUserOrderException))
				{
					// Ha a termék elektronikus, csak 1-t lehet venni belőle
					if(!product.IsDownloadable)
					{
						var oldPio = ProductInOrderManager.GetNormal(ctx, product.ID, userOrder.ID);
						var newPio = new ProductInOrder(false)
						{
							ID = oldPio.ID,
							UnitPrice = oldPio.UnitPrice,
							HowMany = oldPio.HowMany + 1,
							ProductID = oldPio.ProductID,
							UserOrderID = oldPio.UserOrderID,
						};
						ProductInOrderManager.UpdateInCart(ctx, oldPio, userOrder, newPio);
					}
					else
					{
						var msg = string.Format("Elektronikus termékből csak 1-t lehet venni. ProductID: {0}. ", product.ID);
						throw new BookteraException(msg, e, BookteraExceptionCode.AddProductToCart_CreateOrUpdatePio_DownloadableProduct);
					}
				}
				else
				{
					throw;
				}
			}
		}

		#endregion

		#region UpdateProductInCart

		public static void UpdateProductInCart(int currentUserId, int productInOrderId, int newHowMany)
		{
			try
			{
				UpdateProductInCart_CheckArguments(newHowMany, productInOrderId, currentUserId);

				using(var ctx = new DBEntities())
				using(var transactionScope = new TransactionScope())
				{
					var oldPio = ProductInOrderManager.GetNormal(ctx, productInOrderId);
					UpdateProductInCart_ManageProduct(ctx, transactionScope, oldPio, newHowMany);
					UpdateProductInCart_ManagePioAndCart(ctx, oldPio, newHowMany, currentUserId);

					transactionScope.Complete();
				}
			}
			catch(Exception e)
			{
				// Vannak olyan ágak, amik ide jutnak, de nem hibásak.
				var be = e as BookteraException;
				if(be != null && be.Code == BookteraExceptionCode.UpdateProductInCart_NoUpdateNeeded)
					return;

				const string msg = "Nem sikerült frissíteni a kosárban lévő termék mennyiségét. ";
				throw new BookteraException(msg, e, BookteraExceptionCode.UpdateProductInCart);
			}
		}
		private static void UpdateProductInCart_CheckArguments(int? newHowMany, int productInOrderId, int currentUserId)
		{
			if(newHowMany < 0)
			{
				var msg = string.Format("Negatív a megrendelt mennyiség ({0} db). ", newHowMany);
				throw new BookteraException(msg, code: BookteraExceptionCode.UpdateProductInCart_NewQuantityNegative);
			}
			if(newHowMany == 0)
			{
				RemoveProductFromCart(productInOrderId, currentUserId);
				const string msg = "Az új megrendelt mennyiség 0, ez nem Update, hanem Delete. ";
				throw new BookteraException(msg, code: BookteraExceptionCode.UpdateProductInCart_NoUpdateNeeded);
			}
		}
		private static void UpdateProductInCart_ManageProduct(DBEntities ctx, TransactionScope transactionScope, ProductInOrder productInOrder, int newHowMany)
		{
			int howManyNeededMore = newHowMany - productInOrder.HowMany;

			if(howManyNeededMore == 0)
			{
				transactionScope.Complete();
				const string msg = "Nem változott a mennyiség";
				throw new BookteraException(msg, code: BookteraExceptionCode.UpdateProductInCart_NoUpdateNeeded);
			}

			var product = productInOrder.Product;

			if(product.IsDownloadable)
			{
				transactionScope.Complete();
				const string msg = "Elektronikus termékből nem lehet többet venni. ";
				throw new BookteraException(msg, code: BookteraExceptionCode.UpdateProductInCart_NoUpdateNeeded);
			}

			if(howManyNeededMore > 0)
				ProductManager.CheckExistEnoughToBuy(product, howManyNeededMore);

			ProductManager.UpdateQuantity(ctx, product, -howManyNeededMore);
		}
		private static void UpdateProductInCart_ManagePioAndCart(DBEntities ctx, ProductInOrder oldPio, int newHowMany, int currentUserId)
		{
			var userOrder = GetCartUserOrderItem(ctx, currentUserId, oldPio);

			var newPio = new ProductInOrder(false)
			{
				ID = oldPio.ID,
				ProductID = oldPio.ProductID,
				UserOrderID = oldPio.UserOrderID,
				UnitPrice = oldPio.UnitPrice,
				HowMany = newHowMany,
			};
			ProductInOrderManager.UpdateInCart(ctx, oldPio, userOrder, newPio);
		}

		#endregion

		#region RemoveProductFromCart

		///  <summary>
		///  Kosárban lévő termék (1 db Product) törlése
		///  </summary>
		public static void RemoveProductFromCart(int productInOrderId, int currentUserId)
		{
			using(var ctx = new DBEntities())
			using(var transactionScope = new TransactionScope())
			{
				RemoveProductFromCart(ctx, productInOrderId, currentUserId);
				transactionScope.Complete();
			}
		}
		public static void RemoveProductFromCart(DBEntities ctx, int productInOrderId, int currentUserId)
		{
			try
			{
				var productInOrder = ProductInOrderManager.GetNormal(ctx, productInOrderId);
				var userOrder = GetCartUserOrderItem(ctx, currentUserId, productInOrder);

				var product = productInOrder.Product;
				var vendorUserProfile = userOrder.VendorUserProfile;
				var customerUserProfile = userOrder.CustomerUserProfile;

				ProductManager.UpdateQuantity(ctx, product, productInOrder.HowMany, vendorUserProfile);
				ProductInOrderManager.DeleteFromCart(ctx, productInOrder, userOrder, customerUserProfile, vendorUserProfile);
			}
			catch(Exception e)
			{
				const string msg = "Nem sikerült eltávolítani a terméket a kosárból. ";
				throw new BookteraException(msg, e, BookteraExceptionCode.RemoveProductFromCart);
			}
		}

		#endregion

		#region RemoveUsersCart

		/// <summary>
		///  Egy teljes kosár törlése.
		/// </summary>
		public static void RemoveUsersCart(int userOrderId, int currentUserId)
		{
			try
			{
				using(var ctx = new DBEntities())
				using(var transactionScope = new TransactionScope())
				{
					//var userOrder = GetUserOrderItem(ctx, currentUserId, userOrderId, checkCustomer: true, statusesToCheck: new[] { UserOrderStatus.Cart });
					var userOrder = GetCartUserOrderItem(ctx, currentUserId, userOrderId: userOrderId);

					DeleteUserOrderAndItsPios(ctx, userOrder);

					transactionScope.Complete();
				}
			}
			catch(Exception e)
			{
				const string msg = "Nem sikerült eltávolítani a kosarat!";
				throw new BookteraException(msg, e, BookteraExceptionCode.RemoveUsersCart);
			}
		}

		///  <summary>
		///  A megkapott UserOrder rekordra hivatkozó összes ProductInOrder rekordot törli, majd a UserOrder rekordot is
		///  </summary>
		private static void DeleteUserOrderAndItsPios(DBEntities ctx, UserOrder userOrder, bool saveChanges = true)
		{
			try
			{
				var productsInOrder = userOrder.ProductsInOrder;
				if(productsInOrder.Count == 0)
				{
					var msg = string.Format("Nincs egy termék sem a kosárban. Üres kosár nem létezhet, törölni kellett volna. UserOrderID: {0}. ", userOrder.ID);
					//throw new BookteraException(msg, code: BookteraExceptionCode.DeleteUserOrdersAllProducts_CartAlreadyEmpty);
				}

				for(int i = productsInOrder.Count - 1; i >= 0; i--)
				{
					var productInOrder = productsInOrder.ElementAt(i);
					var product = productInOrder.Product;
					ProductManager.UpdateQuantity(ctx, product, productInOrder.HowMany, saveChanges: false);

					ctx.ProductInOrder.Remove(productInOrder);
				}

				UserProfileManager.UpdateSellBuyCache(ctx, userOrder.CustomerUserProfile, userOrder.VendorUserProfile, UserOrderStatus.CartDeleting, saveChanges);

				// Ha minden kosarat törlünk
				if(!saveChanges)
				{
					ctx.UserOrder.Remove(userOrder);
					return;
				}

				// Minden PIO törlése, product-quantity update-ek
				try
				{
					ctx.SaveChanges();
				}
				catch(Exception)
				{
					var msg = string.Format("Nem sikerült a ProductInOrder rekordok törlése. UserOrderId: {0}. ", userOrder.ID);
					throw new BookteraException(msg, code: BookteraExceptionCode.DeleteUserOrdersAllProducts_CantDeletePios);
				}

				UserOrderManager.Delete(ctx, userOrder);
			}
			catch(Exception e)
			{
				const string msg = "Nem sikerült törölni a UserOrder rekordot, vagy a PIO-it. ";
				throw new BookteraException(msg, e, BookteraExceptionCode.DeleteUserOrdersAllProducts);
			}
		}

		#endregion

		#region RemoveUsersAllCarts

		/// <summary>
		/// Törli a felhasználó összes kosarát
		/// </summary>
		public static void RemoveUsersAllCarts(int currentUserId)
		{
			try
			{
				using(var ctx = new DBEntities())
				using(var transactionScope = new TransactionScope())
				{
					var carts = GetUsersCartsOrOtherOrders(ctx, TransactionType.CartOwn, currentUserId);

					foreach(var cart in carts)
						DeleteUserOrderAndItsPios(ctx, cart, saveChanges: false);

					ctx.SaveChanges();
					transactionScope.Complete();
				}
			}
			catch(Exception e)
			{
				var msg = string.Format("Nem sikerült eltávolítani a felhasználó kosarait (az összeset). UserId: {0}. ", currentUserId);
				throw new BookteraException(msg, e, BookteraExceptionCode.RemoveUsersAllCarts);
			}
		}

		#endregion

		#region SendOrder

		public static void SendOrder(int userOrderId, int currentUserId)
		{
			try
			{
				using(var ctx = new DBEntities())
				{
					var userOrder = GetCartUserOrderItem(ctx, currentUserId, userOrderId: userOrderId, checkCustomerHasAddress: true);
					var vendor = userOrder.VendorUserProfile;

					userOrder.Date = DateTime.Now;
					userOrder.Status = (byte)UserOrderStatus.BuyedWaiting;
					userOrder.VendorAddressID = vendor.DefaultAddressID;

					ctx.SaveChanges();

					Email.SendEmailByOrderSending(vendor.EMail, vendor.FullName ?? vendor.UserName);
					PushNotification.Send(vendor.ID, "Rendelésed érkezett. ");
				}
			}
			catch(Exception e)
			{
				var msg = string.Format("Nem sikerült elküldeni a rendelést. UserOrderId: {0}. ", userOrderId);
				throw new BookteraException(msg, e, BookteraExceptionCode.SendUserOrder);
			}
		}

		#endregion

		#endregion

		#region Step 2 - Exchange

		#region AddExchangeProduct

		public static void AddExchangeProduct(int productId, int userOrderId, int currentUserId)
		{
			try
			{
				using(var ctx = new DBEntities())
				using(var transactionScope = new TransactionScope())
				{
					//var userOrder = GetUserOrderItem(ctx, currentUserId, userOrderId, checkVendor: true, statusesToCheck: new[] { UserOrderStatus.BuyedWaiting });
					var userOrder = GetBuyedWaitingUserOrderItem(ctx, currentUserId, userOrderId: userOrderId);

					var product = ProductManager.Get(ctx, productId);
					ProductManager.CheckExistEnoughToBuy(product, 1);
					ProductManager.CheckUser(product, userOrder.CustomerUserProfileID, checkProductIsCustomers: true);
					ProductManager.UpdateQuantity(ctx, product, howManyDifference: -1);

					AddExchangeProduct_ManageProductInOrder(ctx, product, userOrder);

					transactionScope.Complete();
				}
			}
			catch(Exception)
			{
				var msg = string.Format("Nem sikerült csere-kosárba (ID: {0}) tenni a következő terméket: {1}. ", userOrderId, productId);
				throw new BookteraException(msg, code: BookteraExceptionCode.AddExchangeProduct);
			}
		}
		private static void AddExchangeProduct_ManageProductInOrder(DBEntities ctx, Product product, UserOrder userOrder)
		{
			var productInOrder = new ProductInOrder(true)
			{
				HowMany = 1,
				ProductID = product.ID,
				UserOrderID = userOrder.ID,
				UnitPrice = product.Price,
				IsForExchange = true,
			};
			ProductInOrderManager.Add(ctx, productInOrder);
		}

		#endregion

		#region UpdateExchangeProduct

		public static void UpdateExchangeProduct(int currentUserId, int productInOrderId, int newHowMany)
		{
			try
			{
				UpdateExchangeProduct_CheckArguments(newHowMany, productInOrderId, currentUserId);

				using(var ctx = new DBEntities())
				using(var transactionScope = new TransactionScope())
				{
					var productInOrder = ProductInOrderManager.GetExchange(ctx, productInOrderId);
					ProductInOrderManager.ManageProductByUpdate(ctx, transactionScope, productInOrder, newHowMany);
					productInOrder.HowMany = newHowMany;
					ProductInOrderManager.Update(ctx, productInOrder);

					transactionScope.Complete();
				}
			}
			catch(Exception e)
			{
				// Vannak olyan ágak, amik ide jutnak, de nem hibásak.
				var be = e as BookteraException;
				if(be != null && be.Code == BookteraExceptionCode.UpdateExchangeProduct_NoUpdateNeeded)
					return;

				const string msg = "Nem sikerült frissíteni a csere-kosárban lévő termék mennyiségét. ";
				throw new BookteraException(msg, e, BookteraExceptionCode.UpdateExchangeProduct);
			}
		}
		private static void UpdateExchangeProduct_CheckArguments(int? newHowMany, int productInOrderId, int currentUserId)
		{
			if(newHowMany < 0)
			{
				var msg = string.Format("Negatív a megrendelt mennyiség ({0} db). ", newHowMany);
				throw new BookteraException(msg, code: BookteraExceptionCode.UpdateExchangeProduct_NewQuantityNegative);
			}
			if(newHowMany == 0)
			{
				RemoveExchangeProduct(productInOrderId, currentUserId);
				const string msg = "Az új megrendelt mennyiség 0, ez nem Update, hanem Delete. ";
				throw new BookteraException(msg, code: BookteraExceptionCode.UpdateExchangeProduct_NoUpdateNeeded);
			}
		}

		#endregion

		#region RemoveExchangeProduct

		///  <summary>
		///  Vásárlásra válaszul ajánlott csere-termék (1 db) kivétele a rendelésből
		///  </summary>
		public static void RemoveExchangeProduct(int productInOrderId, int currentUserId)
		{
			using(var ctx = new DBEntities())
			using(var transactionScope = new TransactionScope())
			{
				RemoveExchangeProduct(ctx, productInOrderId, currentUserId);
				transactionScope.Complete();
			}
		}
		public static void RemoveExchangeProduct(DBEntities ctx, int productInOrderId, int currentUserId)
		{
			try
			{
				var productInOrder = ProductInOrderManager.GetExchange(ctx, productInOrderId);
				var userOrder = GetBuyedWaitingUserOrderItem(ctx, currentUserId, productInOrder);

				var product = productInOrder.Product;
				var customerUserProfile = userOrder.CustomerUserProfile;

				ProductManager.UpdateQuantity(ctx, product, productInOrder.HowMany, customerUserProfile);
				ProductInOrderManager.Delete(ctx, productInOrder);
			}
			catch(Exception e)
			{
				const string msg = "Nem sikerült eltávolítani a csere-terméket a kosárból. ";
				throw new BookteraException(msg, e, BookteraExceptionCode.RemoveExchangeProduct);
			}
		}

		#endregion

		#region RemoveExchangeCart

		/// <summary>
		///  A teljes csere-kosár törlése
		///  A megkapott UserOrder rekordra hivatkozó összes csere típusú ProductInOrder rekordot törli
		/// </summary>
		public static void RemoveExchangeCart(int userOrderId, int currentUserId)
		{
			try
			{
				using(var ctx = new DBEntities())
				using(var transactionScope = new TransactionScope())
				{
					var userOrder = GetExchangeCartForRemoveUserOrderItem(ctx, currentUserId, userOrderId);

					RemoveExchangeCart(ctx, userOrder);

					transactionScope.Complete();
				}
			}
			catch(Exception e)
			{
				const string msg = "Nem sikerült eltávolítani a csere-kosarat!";
				throw new BookteraException(msg, e, BookteraExceptionCode.RemoveExchangeCart);
			}
		}

		///  <summary>
		///  A teljes csere-kosár törlése
		///  A megkapott UserOrder rekordra hivatkozó összes csere típusú ProductInOrder rekordot törli
		///  </summary>
		private static void RemoveExchangeCart(DBEntities ctx, UserOrder userOrder)
		{
			try
			{
				var exchangePios = userOrder.ProductsInOrder.Where(pio => pio.IsForExchange).ToArray();

				for(int i = exchangePios.Length - 1; i >= 0; i--)
				{
					var productInOrder = exchangePios[i];
					var product = productInOrder.Product;
					ProductManager.UpdateQuantity(ctx, product, productInOrder.HowMany, saveChanges: false);

					ctx.ProductInOrder.Remove(productInOrder);
				}

				// Minden PIO törlése, product-quantity update-ek
				ctx.SaveChanges();
			}
			catch(Exception e)
			{
				const string msg = "Nem sikerült törölni a csere-termékeket. ";
				throw new BookteraException(msg, e, BookteraExceptionCode.DeleteExchangeProducts);
			}
		}

		#endregion

		#region SendExchangeOffer

		public static void SendExchangeOffer(int userOrderId, int currentUserId)
		{
			try
			{
				using(var ctx = new DBEntities())
				{
					var userOrder = GetBuyedWaitingUserOrderItem(ctx, currentUserId, userOrderId: userOrderId, checkHasExchange: true, checkVendorHasAddress: true);
					var customer = userOrder.CustomerUserProfile;

					userOrder.Date = DateTime.Now;
					userOrder.Status = (byte)UserOrderStatus.BuyedExchangeOffered;

					ctx.SaveChanges();

					Email.SendEmailByExchangeOffering(customer.EMail, customer.FullName ?? customer.UserName);
					PushNotification.Send(customer.ID, "Csere ajánlatot kaptál. ");
				}
			}
			catch(Exception e)
			{
				var msg = string.Format("Nem sikerült elküldeni a csere ajánlatot. UserOrderId: {0}. ", userOrderId);
				throw new BookteraException(msg, e, BookteraExceptionCode.SendExchangeOffer);
			}
		}

		#endregion

		#endregion

		#region Step 3 - Finalize

		#region FinalizeOrderWithoutExchange

		public static void FinalizeOrderWithoutExchange(int userOrderId, int currentUserId)
		{
			FinalizeOrder(userOrderId, currentUserId, OrderFinalizingType.WithoutExchange);
		}

		#endregion

		#region FinalizeOrderAcceptExchange

		public static void FinalizeOrderAcceptExchange(int userOrderId, int currentUserId)
		{
			FinalizeOrder(userOrderId, currentUserId, OrderFinalizingType.WithAccaptedExchange);
		}

		#endregion

		#region FinalizeOrderDenyExchange

		public static void FinalizeOrderDenyExchange(int userOrderId, int currentUserId)
		{
			FinalizeOrder(userOrderId, currentUserId, OrderFinalizingType.WithDeniedExchange);
		}

		#endregion

		#region FinalizeOrder (private)

		private static void FinalizeOrder(int userOrderId, int currentUserId, OrderFinalizingType orderFinalizingType)
		{
			try
			{
				using(var ctx = new DBEntities())
				using(var transactionScope = new TransactionScope())
				{
					var userOrder = FinalizeOrder_ManageUserOrder(ctx, userOrderId, currentUserId, orderFinalizingType);

					var customer = userOrder.CustomerUserProfile;
					var vendor = userOrder.VendorUserProfile;
					int customerFee = (int)(userOrder.SumBookPrice * userOrder.CustomersBuyFeePercent / 100.0);
					int vendorFee = (int)(userOrder.SumBookPrice * userOrder.VendorsSellFeePercent / 100.0);
					UserProfileManager.UpdateUsersBalance(ctx, customer, -customerFee, saveChanges: false);
					UserProfileManager.UpdateUsersBalance(ctx, vendor, -vendorFee, saveChanges: false);

					ctx.SaveChanges();
					transactionScope.Complete();

					var didCustomer = customer.ID == currentUserId;
					FinalizeOrder_NotifyUser(orderFinalizingType, customer, vendor, didCustomer);
				}
			}
			catch(Exception e)
			{
				var msg = string.Format("Nem sikerült véglegesíteni a tranzakciót. UserOrderId: {0}. ", userOrderId);
				throw new BookteraException(msg, e, BookteraExceptionCode.FinalizeOrder);
			}
		}
		private static UserOrder FinalizeOrder_ManageUserOrder(DBEntities ctx, int userOrderId, int currentUserId, OrderFinalizingType orderFinalizingType)
		{
			UserOrder userOrder;

			switch(orderFinalizingType)
			{
				case OrderFinalizingType.WithoutExchange:
					//userOrder = GetUserOrderItem(ctx, currentUserId, userOrderId, checkVendor: true, statusesToCheck: new[] { UserOrderStatus.BuyedWaiting });

					userOrder = GetBuyedWaitingUserOrderItem(ctx, currentUserId, userOrderId: userOrderId, checkVendorHasAddress: true);
					RemoveExchangeCart(ctx, userOrder);
					userOrder.Status = (byte)UserOrderStatus.FinalizedCash;
					break;
				case OrderFinalizingType.WithDeniedExchange:
					//userOrder = GetUserOrderItem(ctx, currentUserId, userOrderId, checkCustomer: true, statusesToCheck: new[] { UserOrderStatus.BuyedExchangeOffered });

					userOrder = GetBuyedExchangeOfferedUserOrderItem(ctx, currentUserId, userOrderId: userOrderId);
					RemoveExchangeCart(ctx, userOrder);
					userOrder.Status = (byte)UserOrderStatus.FinalizedCash;
					break;
				case OrderFinalizingType.WithAccaptedExchange:
					//userOrder = GetUserOrderItem(ctx, currentUserId, userOrderId, checkCustomer: true, statusesToCheck: new[] { UserOrderStatus.BuyedExchangeOffered });

					userOrder = GetBuyedExchangeOfferedUserOrderItem(ctx, currentUserId, userOrderId: userOrderId);
					userOrder.Status = (byte)UserOrderStatus.FinalizedExchange;
					break;
				default:
					var msg = string.Format("A FinalizeOrder_GetAndCheckUserOrder fv nem várt OrderFinalizingType-t kapott: {0}. ", orderFinalizingType);
					throw new BookteraException(msg, code: BookteraExceptionCode.None);
			}

			userOrder.Date = DateTime.Now;
			return userOrder;
		}
		private static void FinalizeOrder_NotifyUser(OrderFinalizingType orderFinalizingType, UserProfile customer, UserProfile vendor, bool didCustomer)
		{
			var customerName = customer.FullName ?? customer.UserName;
			var vendorName = vendor.FullName ?? vendor.UserName;
			var userToSendPushNotification = didCustomer ? vendor.ID : customer.ID; // If the customer did the action, notify the vendor; and vica versa

			switch(orderFinalizingType)
			{
				case OrderFinalizingType.WithoutExchange:
					Email.SendEmailsByOrderFinalizingWithoutExchange(customer.EMail, customerName, vendor.EMail, vendorName);
					PushNotification.Send(userToSendPushNotification, "Tranzakciód véglegesítésre került csere nélkül. ");
					break;
				case OrderFinalizingType.WithAccaptedExchange:
					Email.SendEmailsByOrderFinalizingWithAcceptedExchange(customer.EMail, customerName, vendor.EMail, vendorName);
					PushNotification.Send(userToSendPushNotification, "Csere-ajánlatod elfogadták! ");
					break;
				case OrderFinalizingType.WithDeniedExchange:
					Email.SendEmailsByOrderFinalizingWithDeniedExchange(customer.EMail, customerName, vendor.EMail, vendorName);
					PushNotification.Send(userToSendPushNotification, "Csere-ajánlatod elutasították. ");
					break;
			}
		}

		#endregion

		#endregion

		#region Step 4 - Close

		#region CloseOrderSuccessful

		public static void CloseOrderSuccessful(int userOrderId, int currentUserId)
		{
			CloseOrder(userOrderId, currentUserId, wasSuccessful: true);
		}

		#endregion

		#region CloseOrderUnsuccessful

		public static void CloseOrderUnsuccessful(int userOrderId, int currentUserId)
		{
			CloseOrder(userOrderId, currentUserId, wasSuccessful: false);
		}

		#endregion

		#region CloseOrder (private)

		private static void CloseOrder(int userOrderId, int currentUserId, bool wasSuccessful)
		{
			try
			{
				using(var ctx = new DBEntities())
				using(var transactionScope = new TransactionScope())
				{
					//var userOrder = GetUserOrderItem(ctx, currentUserId, userOrderId, statusesToCheck: new[] { UserOrderStatus.FinalizedCash, UserOrderStatus.FinalizedExchange }, checkCustomer: true, checkVendor: true);
					var userOrder = GetFinalizedOrFinishedUserOrderItem(ctx, currentUserId, userOrderId: userOrderId);
					userOrder.Date = DateTime.Now;
					userOrder.Status = (byte)UserOrderStatus.Finished;
					UserOrderManager.Update(ctx, userOrder);

					bool didCustomer = userOrder.CustomerUserProfileID == currentUserId;
					var customer = userOrder.CustomerUserProfile;
					var vendor = userOrder.VendorUserProfile;

					bool isFirst = !userOrder.Feedbacks.Any();
					FeedbackManager.GiveFeedback(ctx, customer, vendor, userOrder, didCustomer, wasSuccessful, saveChanges: true);
					if(isFirst)
						CloseOrder_ManageCaches(ctx, customer, vendor, userOrder);

					transactionScope.Complete();

					Email.SendEmailByCloseOrder(wasSuccessful, didCustomer, customer.EMail, customer.FullName ?? customer.UserName, vendor.EMail, vendor.FullName ?? vendor.UserName);
					CloseOrder_PushNotification(didCustomer, wasSuccessful, customer.ID, vendor.ID);
				}
			}
			catch(Exception e)
			{
				var msg = string.Format("Nem sikerült lezárni a tranzakciót (sikeres/sikertelen). UserOrderId: {0}. ", userOrderId);
				throw new BookteraException(msg, e, BookteraExceptionCode.CloseOrder);
			}
		}

		private static void CloseOrder_PushNotification(bool didCustomer, bool wasSuccessful, int customerId, int vendorId)
		{
			var userToSend = didCustomer ? vendorId : customerId; // If the customer did the action, notify the vendor; and vica versa
			var msg = wasSuccessful ? "Tranzakciód sikeres értékelést kapott :)" : "Tranzakciód sikeretelen értékelést kapott :(";

			PushNotification.Send(userToSend, msg);
		}

		private static void CloseOrder_ManageCaches(DBEntities ctx, UserProfile customer, UserProfile vendor, UserOrder userOrder)
		{
			UserProfileManager.UpdateSellBuyCache(ctx, customer, vendor, UserOrderStatus.Finished, saveChanges: true);

			var productsInOrder = userOrder.ProductsInOrder;
			foreach(var productInOrder in productsInOrder)
			{
				var product = productInOrder.Product;
				var productGroup = product.ProductGroup;
				ProductGroupManager.IncrementSumOfBuys(ctx, productGroup, saveChanges: false);
			}
			ProductGroupManager.UpdateAfterwards(ctx);
		}

		#endregion

		#endregion

		#endregion
	}
}