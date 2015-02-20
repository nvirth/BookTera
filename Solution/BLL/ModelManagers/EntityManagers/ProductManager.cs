using System;
using System.Data;
using System.Linq;
using AutoMapper;
using BLL.ModelManagers.ProductModelManagers;
using CommonModels.Models.EntityFramework;
using CommonModels.Models.ProductModels;
using CommonPortable.Enums;
using CommonPortable.Exceptions;
using CommonPortable.Models.ProductModels;
using DAL.EntityFramework;
using UtilsLocal;
using UtilsLocal.Log;
using UtilsShared;
using UtilsSharedPortable;

namespace BLL.EntityManagers
{
	public static class ProductManager
	{
		#region CREATE

		#region Add

		public static void Add(Product product)
		{
			using(var ctx = new DBEntities())
			{
				Add(ctx, product);
			}
		}
		public static void Add(DBEntities ctx, Product product)
		{
			try
			{
				ctx.Product.Add(product);
				ctx.SaveChanges();
			}
			catch(Exception e)
			{
				ctx.Entry(product).State = EntityState.Detached;
				const string msg = "Nem sikerült beszúrni a Product rekordot. ";
				throw new BookteraException(msg, e, BookteraExceptionCode.AddProduct_InsertFailed);
			}
		}

		#endregion

		#endregion

		#region READ

		#region GetByID

		public static Product Get(int id)
		{
			using(var ctx = new DBEntities())
			{
				return Get(ctx, id);
			}
		}
		public static Product Get(DBEntities ctx, int id)
		{
			try
			{
				return ctx.Product.Single(p => p.ID == id);
			}
			catch(Exception e)
			{
				var msg = String.Format("Nem található a Product rekord az adatbázisban. ID: {0}. ", id);
				throw new BookteraException(msg, e, BookteraExceptionCode.GetProductById);
			}
		}

		#endregion

		#region GetProductsInCategory

		public static InCategoryPLVM GetProductsInCategory(string categoryFriendlyUrl, int pageNumber, int productsPerPage)
		{
			using(var ctx = new DBEntities())
			{
				return GetProductsInCategory(ctx, categoryFriendlyUrl, pageNumber, productsPerPage);
			}
		}

		public static InCategoryPLVM GetProductsInCategory(DBEntities ctx, string categoryFriendlyUrl, int pageNumber, int productsPerPage)
		{
			var category = CategoryManager.Get(ctx, categoryFriendlyUrl);
			int[] categoryIds = CategoryManager.GetIdsCategoryWithChildren(ctx, category);

			var productGroups = ctx.ProductGroup
								   .Where(pg => categoryIds.Contains(pg.CategoryID))
								   .Where(pg => pg.SumOfActiveProductsInGroup > 0)
								   .OrderBy(pg => pg.ID);

			return new InCategoryPLVM().DoConsturctorWork(pageNumber, productsPerPage, productGroups, category);
		}

		public static InCategoryPLVM GetProductsInCategory(Category category, int pageNumber, int productsPerPage)
		{
			using(var ctx = new DBEntities())
			{
				return GetProductsInCategory(ctx, category, pageNumber, productsPerPage);
			}
		}

		public static InCategoryPLVM GetProductsInCategory(DBEntities ctx, Category category, int pageNumber, int productsPerPage)
		{
			int[] categoryIds = CategoryManager.GetIdsCategoryWithChildren(ctx, category);

			var productGroups = ctx.ProductGroup
								   .Where(pg => categoryIds.Contains(pg.CategoryID))
								   .Where(pg => pg.SumOfActiveProductsInGroup > 0)
								   .OrderBy(pg => pg.ID);

			return new InCategoryPLVM().DoConsturctorWork(pageNumber, productsPerPage, productGroups, category);
		}

		#endregion

		#region GetMainHighlighteds

		public static BookBlockPLVM GetMainHighlighteds(int pageNumber, int productsPerPage)
		{
			using(var ctx = new DBEntities())
			{
				// Highlighted Products to main page
				var mainHighlightedProducts =
					(from hp in ctx.HighlightedProduct
					 join p in ctx.Product on hp.ProductID equals p.ID
					 where hp.HighlightTypeID == (byte)HighlightTypeEnum.ForefrontMainSite
					 where hp.ToDate > DateTime.Now
					 where p.HowMany > 0
					 orderby hp.FromDate
					 select p);

				int numOfProducts = mainHighlightedProducts.Count();

				var mhpBookBlockVM = new BookBlockPLVM().DoConsturctorWork(pageNumber, productsPerPage, mainHighlightedProducts, numOfProducts);

				// If there aren't enough, add to them the last uploadeds; and we ignore function parameter productsPerPage
				if(numOfProducts < productsPerPage)
				{
					var products = ctx.Product
									  .Where(p => p.HowMany > 0)
									  .OrderByDescending(p => p.UploadedDate)
									  .Take(productsPerPage - mhpBookBlockVM.Products.Count);

					mhpBookBlockVM.AddProductsToList(products);
				}

				return mhpBookBlockVM;
			}
		}

		#endregion

		#region GetNewests

		public static BookBlockPLVM GetNewests(int pageNumber, int productsPerPage, int numOfProducts)
		{
			using(var ctx = new DBEntities())
			{
				var newestProducts = ctx.Product
										.Where(p => p.HowMany > 0)
										.OrderByDescending(p => p.UploadedDate);

				return new BookBlockPLVM().DoConsturctorWork(pageNumber, productsPerPage, newestProducts, numOfProducts);
			}
		}

		#endregion

		#region GetUsersProducts

		public static BookBlockPLVM GetUsersProducts(string friendlyUrl, int pageNumber, int productsPerPage, out string userName, bool forExchange = false)
		{
			using(var ctx = new DBEntities())
			{
				var userProfile = UserProfileManager.Get(ctx, friendlyUrl);
				userName = userProfile.UserName;

				return GetUsersProducts(ctx, userProfile.ID, pageNumber, productsPerPage, forExchange);
			}
		}
		public static BookBlockPLVM GetUsersProducts(int userID, int pageNumber, int productsPerPage, out string userName, bool forExchange = false)
		{
			using(var ctx = new DBEntities())
			{
				var usersProducts = GetUsersProducts(ctx, userID, pageNumber, productsPerPage, forExchange);
				userName = usersProducts.Products.Count == 0
					? UserProfileManager.Get(ctx, userID).UserName
					: usersProducts.Products[0].Product.UserName;

				return usersProducts;
			}
		}
		public static BookBlockPLVM GetUsersProducts(int userID, int pageNumber, int productsPerPage, bool forExchange = false)
		{
			using(var ctx = new DBEntities())
			{
				return GetUsersProducts(ctx, userID, pageNumber, productsPerPage, forExchange);
			}
		}
		public static BookBlockPLVM GetUsersProducts(DBEntities ctx, int userID, int pageNumber, int productsPerPage, bool forExchange = false)
		{
			var usersProducts = ctx.Product
				.Where(p => p.UserID == userID)
				.Where(p => !forExchange || p.HowMany != 0)
				.OrderBy(p => p.UploadedDate);

			return new BookBlockPLVM().DoConsturctorWork(pageNumber, productsPerPage, usersProducts, isForExchange: forExchange);
		}

		#endregion

		#endregion

		#region UPDATE

		#region Update

		public static void Update(Product product)
		{
			using(var ctx = new DBEntities())
			{
				Update(ctx, product);
			}
		}
		public static void Update(DBEntities ctx, Product product)
		{
			try
			{
				ctx.SaveChanges();
			}
			catch(Exception e)
			{
				ctx.Entry(product).State = EntityState.Unchanged;
				string msg = String.Format("Nem sikerült a frissíteni a Product rekordot! ID: {0}. ", product.ID);
				throw new BookteraException(msg, e, BookteraExceptionCode.UpdateProduct);
			}
		}

		#endregion

		#region UpdateQuantity

		public static void UpdateQuantity(DBEntities ctx, Product product, int howManyDifference, UserProfile userProfile = null, bool saveChanges = true)
		{
			try
			{
				if(product.IsDownloadable)
					return;

				bool isProductActiveAgain = (product.HowMany == 0) && (howManyDifference > 0);

				product.HowMany += howManyDifference;
				if(product.HowMany < 0)
				{
					ctx.Entry(product).State = EntityState.Unchanged;
					const string msg = "Negatívba ment a termék mennyisége. ";
					throw new BookteraException(msg, code: BookteraExceptionCode.UpdateProductsQuantity_Negative);
				}

				if(saveChanges)
					Update(ctx, product);

				if((product.HowMany == 0) || (isProductActiveAgain))
					ProductGroupManager.SetProductInGroupToSoldOutOrBack(ctx, product, isProductActiveAgain, userProfile, saveChanges);
			}
			catch(Exception e)
			{
				const string msg = "Nem sikerült frissíteni a Product mennyiségét. ";
				throw new BookteraException(msg, e, BookteraExceptionCode.UpdateProductsQuantity);
			}
		}

		#endregion

		#endregion

		#region DELETE

		#region Delete

		public static void Delete(Product product)
		{
			using(var ctx = new DBEntities())
			{
				Delete(ctx, product);
			}
		}
		public static void Delete(int id)
		{
			using(var ctx = new DBEntities())
			{
				var product = Get(ctx, id);
				Delete(ctx, product);
			}
		}
		public static void Delete(DBEntities ctx, Product product)
		{
			try
			{
				ctx.Product.Remove(product);
				ctx.SaveChanges();
			}
			catch(Exception e)
			{
				ctx.Entry(product).State = EntityState.Unchanged;
				string msg = String.Format("Nem sikerült a Product rekord törlése. ID: {0}. ", product.ID);
				throw new BookteraException(msg, e, BookteraExceptionCode.DeleteProduct);
			}
		}

		#endregion

		#endregion


		#region OTHER

		#region CheckExistEnoughToBuy

		public static void CheckExistEnoughToBuy(Product product, int howManyNeededMore)
		{
			bool existEnough;
			if(product.IsDownloadable)
				existEnough = true;
			else
				existEnough = product.HowMany >= howManyNeededMore;

			if(!existEnough)
			{
				var msg = String.Format("Nincs elég termék a vásárolni kívánt mennyiséghez. ProductID: {0}. ", product.ID);
				throw new BookteraException(msg, code: BookteraExceptionCode.CheckExistEnoughToBuy_NotEnoughProducts);
			}
		}

		#endregion

		#region CheckUser

		public static void CheckUser(Product product, int userId, bool checkCustomersOwnProduct = false, bool checkProductIsCustomers = false)
		{
			if(checkProductIsCustomers && product.UserID != userId)
			{
				var msg = string.Format("Az eladó nem a vevõ könyvét tenné a csere-kosarába. UserID: {0}, ProductID: {1}. ", userId, product.ID);
				throw new BookteraException(msg, code: BookteraExceptionCode.AddExchangeProductsToOrder_CheckProduct);
			}
			if(checkCustomersOwnProduct && product.UserID == userId)
			{
				var msg = string.Format("A felhasználó a saját könyvét tenné a saját kosarába. UserID: {0}, ProductID: {1}. ", userId, product.ID);
				throw new BookteraException(msg, code: BookteraExceptionCode.AddProductToCart_OwnProductToOwnCart);
			}
		}

		#endregion

		#region CopyFromProxy

		public static Product CopyFromProxy(Product product)
		{
			bool wasNew;
			AutoMapperInitializer<Product, Product>
				.InitializeIfNeeded(out wasNew, sourceProxy: product)
				.ForMemberIfNeeded(wasNew, product.Property(p => p.ProductsHighlights), imce => imce.Ignore())
				.ForMemberIfNeeded(wasNew, product.Property(p => p.Images), imce => imce.Ignore())
				.ForMemberIfNeeded(wasNew, product.Property(p => p.ProductGroup), imce => imce.Ignore())
				.ForMemberIfNeeded(wasNew, product.Property(p => p.UserProfile), imce => imce.Ignore())
				.ForMemberIfNeeded(wasNew, product.Property(p => p.ProductByOrder), imce => imce.Ignore())
				.ForMemberIfNeeded(wasNew, product.Property(p => p.UserViews), imce => imce.Ignore());
			return Mapper.Map<Product>(product);
		}

		#endregion

		#endregion
	}
}
