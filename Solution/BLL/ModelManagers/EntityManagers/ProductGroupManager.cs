using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.Script.Serialization;
using AutoMapper;
using BLL.ModelManagers.ProductModelManagers;
using CommonModels.Models;
using CommonModels.Models.EntityFramework;
using CommonModels.Models.ProductModels;
using CommonPortable.Enums;
using CommonPortable.Exceptions;
using CommonPortable.Models;
using CommonPortable.Models.ProductModels;
using DAL.EntityFramework;
using Newtonsoft.Json;
using UtilsLocal;
using UtilsShared;
using UtilsSharedPortable;
using GeneralFunctions = UtilsShared.GeneralFunctions;

namespace BLL.EntityManagers
{
	public static class ProductGroupManager
	{
		#region CREATE

		#region Add

		public static void Add(ProductGroup productGroup)
		{
			using(var ctx = new DBEntities())
			{
				Add(ctx, productGroup);
			}
		}
		public static void Add(DBEntities ctx, ProductGroup productGroup)
		{
			try
			{
				ctx.ProductGroup.Add(productGroup);
				ctx.SaveChanges();
			}
			catch(Exception e)
			{
				ctx.Entry(productGroup).State = EntityState.Detached;
				const string msg = "Nem sikerült beszúrni a ProductGroup rekordot. ";
				throw new BookteraException(msg, e, BookteraExceptionCode.AddProductGroup_InsertFailed);
			}
		}

		#endregion

		#endregion

		#region READ

		#region GetByID

		public static ProductGroup Get(int id)
		{
			using(var ctx = new DBEntities())
			{
				return Get(ctx, id);
			}
		}
		public static ProductGroup Get(DBEntities ctx, int id)
		{
			try
			{
				return ctx.ProductGroup.Single(p => p.ID == id);
			}
			catch(Exception e)
			{
				var msg = String.Format("Nem található a ProductGroup rekord az adatbázisban. ID: {0}. ", id);
				throw new BookteraException(msg, e, BookteraExceptionCode.GetProductGroupById);
			}
		}

		#endregion

		#region GetByFriendlyUrl

		public static ProductGroup Get(string friendlyUrl)
		{
			using(var ctx = new DBEntities())
			{
				return Get(ctx, friendlyUrl);
			}
		}

		public static ProductGroup Get(DBEntities ctx, string friendlyUrl)
		{
			try
			{
				return ctx.ProductGroup.Single(p => p.FriendlyUrl == friendlyUrl);
			}
			catch(Exception e)
			{
				var msg = String.Format("Nem található a ProductGroup rekord az adatbázisban. FriendlyUrl: {0}. ", friendlyUrl);
				throw new BookteraException(msg, e, BookteraExceptionCode.GetProductGroupByFriendlyUrl);
			}
		}

		#endregion

		#region GetFullDetailed

		public static BookRowPLVM GetFullDetailed(string friendlyUrl, int pageNumber, int productsPerPage)
		{
			using(var ctx = new DBEntities())
			{
				var productGroup = Get(ctx, friendlyUrl);
				return new BookRowPLVM().DoConsturctorWork(productGroup, pageNumber, productsPerPage);
			}
		}

		#endregion

		#region GetAllSortedJson

		public static List<SelectListItemWithClass> GetAllSortedJson(int? selectedId = null)
		{
			using(var ctx = new DBEntities())
			{
				bool initIsSelected = selectedId == null;
				var notInListItem = new SelectListItemWithClass()
				{
					Text = "Nincs a listában",
					Value = "-1",
					Selected = selectedId == -1
				};

				var result = GeneralFunctions.CreateSelectListWithInit(initIsSelected, new[] { notInListItem });

				foreach(var productGroup in ctx.ProductGroup.OrderBy(pg => pg.Title))
				{
					bool selected = selectedId == productGroup.ID;
					//var text = string.Format("Cím: {0}<br/>", productGroup.Title);
					var text = productGroup.Title;

					result.Add(new SelectListItemWithClass()
					{
						Text = text,
						Value = productGroup.ID.ToString(Constants.CultureInfoHu),
						Selected = selected,
					});
				}
				return result;
			}
		}

		#endregion

		#region Search

		public static BookBlockPLVM Search(string searchText, int pageNumber, int productsPerPage, bool needCategory = false)
		{
			using(var ctx = new DBEntities())
			{
				var productGroups =
					(from pg in ctx.ProductGroup
					 where String.IsNullOrEmpty(searchText)
						   || pg.Title.Contains(searchText)
						   || pg.SubTitle.Contains(searchText)
						   || pg.Description.Contains(searchText)
					 where pg.SumOfActiveProductsInGroup > 0
					 orderby pg.ID //skip-take miatti order by
					 select pg);

				return new BookBlockPLVM().DoConsturctorWork(pageNumber, productsPerPage, productGroups, needCategory: needCategory);
			}
		}

		#endregion

		#region SearchWithGroupedByCategory

		public static InCategoryCWPLVM SearchWithGroupedByCategory(string searchText, int pageNumber, int productsPerPage)
		{
			using(var ctx = new DBEntities())
			{
				var groupedProductGroups =
					(from pg in ctx.ProductGroup
					 where String.IsNullOrEmpty(searchText)
						   || pg.Title.Contains(searchText)
						   || pg.SubTitle.Contains(searchText)
						   || pg.Description.Contains(searchText)
					 where pg.SumOfActiveProductsInGroup > 0
					 orderby pg.ID //skip-take miatti order by
					 group pg by pg.CategoryID into pgGroup
					 select pgGroup);

				var result = new InCategoryCWPLVM
				{
					ChildCategoriesWithProducts = new List<InCategoryPLVM>()
				};
				foreach(var productGroupsInGroup in groupedProductGroups)
				{
					//TODO: itt sokszor lekérjük a Category-t
					int categoryId = productGroupsInGroup.Key;
					var category = CategoryManager.Get(ctx, categoryId);

					var productGroups = productGroupsInGroup.AsQueryable();

					var inCategoryPlvm = new InCategoryPLVM().DoConsturctorWork(pageNumber, productsPerPage, productGroups, category);
					result.ChildCategoriesWithProducts.Add(inCategoryPlvm);
				}

				return result;
			}
		}

		#endregion

		#region SearchAutoComplete

		public static string SearchAutoCompleteJson(string searchText, int howMany)
		{
			using(var ctx = new DBEntities())
			{
				var result = SearchAutoCompleteCoreLvp(ctx, searchText, howMany);
				return JsonConvert.SerializeObject(result);
			}
		}

		public static LabelValuePair[] SearchAutoComplete(string searchText, int howMany)
		{
			using(var ctx = new DBEntities())
			{
				return SearchAutoCompleteCoreLvp(ctx, searchText, howMany).ToArray();
			}
		}

		public static SearchPgAcVm[] SearchAutoCompletePg(string searchText, int howMany)
		{
			using(var ctx = new DBEntities())
			{
				return SearchAutoCompleteCorePg(ctx, searchText, howMany)
					.Select(pg => new SearchPgAcVm
					{
						Title = pg.Title,
						SubTitle = pg.SubTitle,
						ImageUrl = pg.ImageUrl,
						FriendlyUrl = pg.FriendlyUrl,
					})
					.ToArray();
			}
		}

		private static IQueryable<LabelValuePair> SearchAutoCompleteCoreLvp(DBEntities ctx, string searchText, int howMany)
		{
			var resultList = SearchAutoCompleteCorePg(ctx, searchText, howMany)
				.Select(pg => new LabelValuePair
				{
					label = pg.Title,
					value = pg.FriendlyUrl
				});

			return resultList;
		}

		private static IQueryable<ProductGroup> SearchAutoCompleteCorePg(DBEntities ctx, string searchText, int howMany)
		{
			var resultList =
				(from pg in ctx.ProductGroup
				 where (pg.SumOfActiveProductsInGroup > 0)
				 where (String.IsNullOrEmpty(searchText) || pg.Title.Contains(searchText))
				 select pg).Take(howMany);

			return resultList;
		}

		#endregion

		#region SearchDetailed

		public static BookBlockPLVM SearchDetailed(DetailedSearchVM.DetailedSearchInputs dsi, int pageNumber, int productsPerPage)
		{
			using(var ctx = new DBEntities())
			{
				// Olyanra inicializáljuk, ami nem fordulhat elõ
				int[] categoryIds = new[] { -1 };

				if(dsi.CategoryId != null)
					categoryIds = CategoryManager.GetIdsCategoryWithChildren(ctx, (int)dsi.CategoryId);

				bool filterUsed = false;
				bool filterNew = false;
				if(dsi.IsUsed != null)
					if((bool)dsi.IsUsed)
						filterUsed = true;
					else
						filterNew = true;

				bool filterDownloadable = false;
				bool filterNotDownloadable = false;
				if(dsi.IsDownloadable != null)
					if((bool)dsi.IsDownloadable)
						filterDownloadable = true;
					else
						filterNotDownloadable = true;

				var productGroups =
					(from p in ctx.Product
					 join pg in ctx.ProductGroup on p.ProductGroupID equals pg.ID
					 // Flags
					 where (!filterUsed || p.IsUsed)
					 where (!filterNew || !p.IsUsed)
					 where (!filterDownloadable || p.IsDownloadable)
					 where (!filterNotDownloadable || !p.IsDownloadable)
					 where (!dsi.IsBook || p.IsBook)
					 where (!dsi.IsAudio || p.IsAudio)
					 where (!dsi.IsVideo || p.IsVideo)
					 // Numbers
					 where (dsi.PublishYearFrom == null || p.PublishYear >= dsi.PublishYearFrom)
					 where (dsi.PublishYearTo == null || p.PublishYear <= dsi.PublishYearTo)
					 where (dsi.PageNumberFrom == null || p.PageNumber >= dsi.PageNumberFrom)
					 where (dsi.PageNumberTo == null || p.PageNumber <= dsi.PageNumberTo)
					 where (dsi.PriceFrom == null || p.Price >= dsi.PriceFrom)
					 where (dsi.PriceTo == null || p.Price <= dsi.PriceTo)
					 // Strings
					 where (String.IsNullOrEmpty(dsi.Author) || pg.AuthorNames.Contains(dsi.Author))
					 where (String.IsNullOrEmpty(dsi.Title) || pg.Title.Contains(dsi.Title))
					 where (String.IsNullOrEmpty(dsi.Subtitle) || pg.SubTitle.Contains(dsi.Subtitle))
					 where (String.IsNullOrEmpty(dsi.Description) || pg.Description.Contains(dsi.Description))
					 where (String.IsNullOrEmpty(dsi.Publisher) || pg.Publisher.DisplayName.Contains(dsi.Publisher))
					 // Int - Category
					 where (dsi.CategoryId == null || categoryIds.Contains(pg.CategoryID))
					 // Strings/SearchingText
					 where (String.IsNullOrEmpty(dsi.SearchingText)
							|| pg.AuthorNames.Contains(dsi.SearchingText)
							|| pg.Title.Contains(dsi.SearchingText)
							|| pg.SubTitle.Contains(dsi.SearchingText)
							|| pg.Description.Contains(dsi.SearchingText)
							|| pg.Publisher.DisplayName.Contains(dsi.SearchingText))
					 select pg)
					.GroupBy(pg => pg.ID)
					.Select(group => @group.FirstOrDefault())
					.OrderBy(pg => pg.ID);

				return new BookBlockPLVM().DoConsturctorWork(pageNumber, productsPerPage, productGroups);
			}
		}

		#endregion

		#endregion

		#region UPDATE

		#region Update

		public static void Update(ProductGroup productGroup)
		{
			using(var ctx = new DBEntities())
			{
				Update(ctx, productGroup);
			}
		}
		public static void Update(DBEntities ctx, ProductGroup productGroup)
		{
			try
			{
				ctx.SaveChanges();
			}
			catch(Exception e)
			{
				ctx.Entry(productGroup).State = EntityState.Unchanged;
				string msg = String.Format("Nem sikerült frissíteni a ProductGroup rekordot! ID: {0}. ", productGroup.ID);
				throw new BookteraException(msg, e, BookteraExceptionCode.UpdateProductGroup);
			}
		}
		public static void UpdateAfterwards(DBEntities ctx)
		{
			try
			{
				ctx.SaveChanges();
			}
			catch(Exception e)
			{
				const string msg = "Nem sikerült frissíteni a ProductGroup rekordo(ka)t!";
				throw new BookteraException(msg, e, BookteraExceptionCode.UpdateProductGroupAfterwards);
			}
		}

		#endregion

		#region SetProductInGroupToSoldOutOrBack

		/// <summary>
		/// Frissíti a ProductGroup táblát, amikor elfogy egy termék; vagy amikor egy elfogyott termék újra kapható
		/// </summary>
		/// <param name="becameActive">True: a termék passzív volt, mennyisége 0 volt; most pedig a mennyiség nõtt, újra aktív. False: A termék elfogyott</param>
		public static void SetProductInGroupToSoldOutOrBack(DBEntities ctx, Product product, bool becameActive, UserProfile userProfile = null, bool saveChanges = true)
		{
			try
			{
				var productGroup = product.ProductGroup;
				userProfile = userProfile ?? product.UserProfile;

				if(becameActive)
				{
					productGroup.SumOfActiveProductsInGroup++;
					productGroup.SumOfPassiveProductsInGroup--;
					userProfile.SumOfActiveProducts++;
					userProfile.SumOfPassiveProducts--;
				}
				else
				{
					productGroup.SumOfActiveProductsInGroup--;
					productGroup.SumOfPassiveProductsInGroup++;
					userProfile.SumOfActiveProducts--;
					userProfile.SumOfPassiveProducts++;
				}

				if(saveChanges)
					Update(ctx, productGroup);
			}
			catch(Exception e)
			{
				const string msg = "Nem sikerült a ProductGroup aktív-passzív termékeinek számát frissíteni. ";
				throw new BookteraException(msg, e, BookteraExceptionCode.SetProductToSoldOutOrBack);
			}
		}

		#endregion

		#region IncrementSumOfBuys

		public static void IncrementSumOfBuys(DBEntities ctx, ProductGroup productGroup, bool saveChanges = true)
		{
			try
			{
				productGroup.SumOfBuys++;

				if(saveChanges)
					Update(ctx, productGroup);
			}
			catch(Exception e)
			{
				var msg = string.Format("Nem sikerült növelni a ProductGroup (ID: {0}) SumOfBuys cache mezejét. ", productGroup.ID);
				throw new BookteraException(msg, e, BookteraExceptionCode.IncrementSumOfBuys);
			}
		}

		#endregion

		#endregion

		#region DELETE

		#region Delete

		public static void Delete(ProductGroup productGroup)
		{
			using(var ctx = new DBEntities())
			{
				Delete(ctx, productGroup);
			}
		}
		public static void Delete(int id)
		{
			using(var ctx = new DBEntities())
			{
				var productGroup = Get(ctx, id);
				Delete(ctx, productGroup);
			}
		}
		public static void Delete(DBEntities ctx, ProductGroup productGroup)
		{
			try
			{
				ctx.ProductGroup.Remove(productGroup);
				ctx.SaveChanges();
			}
			catch(Exception e)
			{
				ctx.Entry(productGroup).State = EntityState.Unchanged;
				string msg = String.Format("Nem sikerült a ProductGroup rekord törlése. ID: {0}. ", productGroup.ID);
				throw new BookteraException(msg, e, BookteraExceptionCode.DeleteProductGroup);
			}
		}

		#endregion

		#endregion


		#region OTHERS

		#region CopyFromProxy

		public static ProductGroup CopyFromProxy(ProductGroup productGroup)
		{
			bool wasNew;
			AutoMapperInitializer<ProductGroup, ProductGroup>
				.InitializeIfNeeded(out wasNew, sourceProxy: productGroup)
				.ForMemberIfNeeded(wasNew, productGroup.Property(pg => pg.Category), imce => imce.Ignore())
				.ForMemberIfNeeded(wasNew, productGroup.Property(pg => pg.Comments), imce => imce.Ignore())
				.ForMemberIfNeeded(wasNew, productGroup.Property(pg => pg.Images), imce => imce.Ignore())
				.ForMemberIfNeeded(wasNew, productGroup.Property(pg => pg.ProductsInGroup), imce => imce.Ignore())
				.ForMemberIfNeeded(wasNew, productGroup.Property(pg => pg.Publisher), imce => imce.Ignore())
				.ForMemberIfNeeded(wasNew, productGroup.Property(pg => pg.Ratings), imce => imce.Ignore())
				.ForMemberIfNeeded(wasNew, productGroup.Property(pg => pg.UserViews), imce => imce.Ignore())
				.ForMemberIfNeeded(wasNew, productGroup.Property(pg => pg.Authors), imce => imce.Ignore());
			return Mapper.Map<ProductGroup>(productGroup);
		}

		#endregion

		#endregion
	}
}
