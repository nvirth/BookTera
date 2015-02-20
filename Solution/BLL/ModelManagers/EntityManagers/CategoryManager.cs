using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using AutoMapper;
using BLL.ModelManagers.ProductModelManagers;
using CommonModels.Models.EntityFramework;
using CommonModels.Models.ProductModels;
using CommonPortable.Enums;
using CommonPortable.Exceptions;
using CommonPortable.Models.ProductModels;
using DAL.EntityFramework;
using UtilsLocal;
using UtilsShared;
using UtilsSharedPortable;
using GeneralFunctions = UtilsShared.GeneralFunctions;

namespace BLL.EntityManagers
{
	public static class CategoryManager
	{
		#region CREATE

		#region Add

		public static void Add(Category category)
		{
			using (var ctx = new DBEntities())
			{
				Add(ctx, category);
			}
		}
		public static void Add(DBEntities ctx, Category category)
		{
			try
			{
				ctx.Category.Add(category);
				ctx.SaveChanges();
			}
			catch (Exception e)
			{
				ctx.Entry(category).State = EntityState.Detached;
				const string msg = "Nem sikerült beszúrni a Category rekordot. ";
				throw new BookteraException(msg, e, BookteraExceptionCode.AddCategory_InsertFailed);
			}
		}

		#endregion

		#endregion

		#region READ

		#region GetByID

		public static Category Get(int id)
		{
			using (var ctx = new DBEntities())
			{
				return Get(ctx, id);
			}
		}
		public static Category Get(DBEntities ctx, int id)
		{
			try
			{
				return ctx.Category.Single(c => c.ID == id);
			}
			catch (Exception e)
			{
				var msg = String.Format("Nem található a Category rekord az adatbázisban. ID: {0}. ", id);
				throw new BookteraException(msg, e, BookteraExceptionCode.GetCategoryById);
			}
		}

		#endregion

		#region GetByFriendlyUrl

		public static Category Get(DBEntities ctx, string friendlyUrl)
		{
			try
			{
				return ctx.Category.Single(c => c.FriendlyUrl == friendlyUrl);
			}
			catch(Exception e)
			{
				var msg = string.Format("Nem található a Category rekord az adatbázisban. FriendlyUrl: {0}. ", friendlyUrl);
				throw new BookteraException(msg, e, BookteraExceptionCode.GetCategoryByFriendlyUrl);
			}
		}

		#endregion

		#region GetTopLevelCategories

		public static string[] GetTopLevelCategoryFus()
		{
			using(var ctx = new DBEntities())
			{
				return GetTopLevelCategoryFus(ctx);
			}
		}

		internal static string[] GetTopLevelCategoryFus(DBEntities ctx)
		{
			return GetTopLevelCategoryFusIEnumerable(ctx).ToArray();
		}

		internal static IEnumerable<string> GetTopLevelCategoryFusIEnumerable(DBEntities ctx)
		{
			return GetTopLevelCategoriesIEnumerable(ctx).Select(c => c.FriendlyUrl);
		}

		internal static IEnumerable<Category> GetTopLevelCategoriesIEnumerable(DBEntities ctx)
		{
			return ctx.Category.Where(c => c.ParentCategoryID == null);
		}

		#endregion

		#region GetCategoriesWithProductsInCategory

		public static InCategoryCWPLVM GetCategoriesWithProductsInCategory(int pageNumber, int productsPerPage, string baseCategoryFu = null)
		{
			using (var ctx = new DBEntities())
			{
				// Nincs szülõ kategória; a legmagasabb szintû kategóriák a "gyerekek"
				if (String.IsNullOrEmpty(baseCategoryFu))
				{
					var childCategoryFus = GetTopLevelCategoryFus(ctx);
					return new InCategoryCWPLVM().DoConstructorDork(ctx, childCategoryFus, pageNumber, productsPerPage);
				}
				else
				{
					var baseCategory = Get(ctx, baseCategoryFu);

					// A keresett kategória szülõ
					if (baseCategory.IsParent)
					{
						var childCategoryFus = GetCategorysChildrensFus(ctx, baseCategory);
						return new InCategoryCWPLVM().DoConstructorDork(ctx, childCategoryFus, pageNumber, productsPerPage, baseCategory);
					}
						// A keresett kategória levél
					else
					{
						// Egylõre az összes Product-ot átadjuk ilyenkore a Category-ból
						return new InCategoryCWPLVM().DoConstructorDork(ctx, pageNumber, 100, baseCategory);
					}
				}
			}
		}

		#endregion

		#region GetAllForMenu

		public static string GetAllForMenu(string selected, string[] openedIds)
		{
			using(var ctx = new DBEntities())
			{
				var sortedCategories = ctx.Category.OrderBy(c => c.Sort).ToArray();
				int fromIndex = 0;
				var result = GetAllCategoriesForMenuRecursive(sortedCategories, new StringBuilder(), ref fromIndex, sortedCategories.Length - 1, selected, openedIds);
				return result.ToString();
			}
		}
		private static int GetAllCategoriesForMenu_GetChildrenEndIndex(Category[] categories, int parentIndex)
		{
			int i;
			for(i = parentIndex + 1; i < categories.Length; i++)
			{
				if(!categories[i].Sort.StartsWith(categories[parentIndex].Sort))
				{
					return i - 1;
				}
			}
			return i - 1;
		}
		private static StringBuilder GetAllCategoriesForMenuRecursive(Category[] sortedCategories, StringBuilder Acc, ref int fromIndex, int toIndex, string selected, string[] openedIds)
		{
			for(/*fromIndex*/; fromIndex <= toIndex; fromIndex++)
			{
				var actual = sortedCategories[fromIndex];

				bool actualIsOpened = openedIds.Contains(actual.Sort);

				string liIsSelected = selected == actual.FriendlyUrl ? "selected" : "";
				string liIsTopLevel = actual.ParentCategoryID == null ? "level1" : "";
				string liIsOpened = actual.IsParent ? (actualIsOpened ? "opened" : "closed") : "";
				string liClass = string.Format(" class=\"{0} {1} {2}\" ", liIsSelected, liIsTopLevel, liIsOpened);

				string aIsOpenable = actual.IsParent ? "ul-openable" : "";
				string aClass = string.Format(" class=\"{0}\" ", aIsOpenable);
				string aHref = string.Format(" href=\"/Category?friendlyUrl={0}\" ", actual.FriendlyUrl);
				string aId = string.Format(" id=\"{0}\" ", actual.Sort);

				string ulIsOpened = actual.IsParent ? (actualIsOpened ? "block" : "none") : "block";
				string ulStyle = string.Format(" style=\"display:{0}\" ", ulIsOpened);

				Acc.Append("<li" + liClass + ">");
				//Acc.Append("<a" + aId + aClass + aHref + ">");

				Acc.Append("<a" + aId + aClass);
				Acc.Append(actual.IsParent ? "" : aHref);
				Acc.Append(">" + actual.DisplayName + "</a>");

				int childrenEndIndex = GetAllCategoriesForMenu_GetChildrenEndIndex(sortedCategories, parentIndex: fromIndex);
				if(childrenEndIndex != fromIndex)
				{
					Acc.Append("<ul" + ulStyle + ">");
					fromIndex++;
					GetAllCategoriesForMenuRecursive(sortedCategories, Acc, ref fromIndex, childrenEndIndex, selected, openedIds);
					Acc.Append("</ul>");
				}
				Acc.Append("</li>");
			}
			fromIndex--;
			return Acc;
		}

		#endregion

		#region GetAllSortedJson

		public static List<SelectListItemWithClass> GetAllSortedJson(int? selectedCategoryId = null)
		{
			using(var ctx = new DBEntities())
			{
				bool initIsSelected = selectedCategoryId == null;
				var result = GeneralFunctions.CreateSelectListWithInit(initIsSelected);

				foreach(var category in ctx.Category.OrderBy(c => c.Sort))
				{
					int level = CalculateLevel(category.Sort);
					bool selected = selectedCategoryId == category.ID;
					//var text = " - ".Repeat(level - 1) + category.DisplayName;
					var text = category.FullPath;
					var @class = "select-option-level-" + level;

					result.Add(new SelectListItemWithClass()
					{
						Text = text,
						Value = category.ID.ToString(Constants.CultureInfoHu),
						Class = @class,
						Selected = selected,
					});
				}
				return result;
			}
		}

		#endregion

		#region GetIdsCategoryWithChildren

		public static int[] GetIdsCategoryWithChildren(DBEntities ctx, int categoryId)
		{
			var category = Get(ctx, categoryId);
			return GetIdsCategoryWithChildren(ctx, category);
		}

		public static int[] GetIdsCategoryWithChildren(DBEntities ctx, Category category)
		{
			return
				(from c in ctx.Category
				 where c.Sort.StartsWith(category.Sort)
				 select c.ID).ToArray();
		}

		#endregion

		#region GetCategorysChildrensFus <-- Nincs benne a szülõ kategória

		internal static string[] GetCategorysChildrensFus(DBEntities ctx, string categoryFu)
		{
			var category = CategoryManager.Get(ctx, categoryFu);
			return GetCategorysChildrensFus(ctx, category);
		}

		internal static string[] GetCategorysChildrensFus(DBEntities ctx, Category category)
		{
			return
				(from c in ctx.Category
				 where c.Sort.StartsWith(category.Sort)
				 where c.Sort != category.Sort
				 select c.FriendlyUrl).ToArray();
		}

		#endregion

		#endregion

		#region UPDATE

		#region Update

		public static void Update(Category category)
		{
			using (var ctx = new DBEntities())
			{
				Update(ctx, category);
			}
		}

		public static void Update(DBEntities ctx, Category category)
		{
			try
			{
				ctx.SaveChanges();
			}
			catch (Exception e)
			{
				ctx.Entry(category).State = EntityState.Unchanged;
				string msg = string.Format("Nem sikerült a frissíteni a Category rekordot! ID: {0}. ", category.ID);
				throw new BookteraException(msg, e, BookteraExceptionCode.UpdateCategory);
			}
		}

		#endregion

		#endregion

		#region DELETE

		#region Delete

		public static void Delete(Category category)
		{
			using (var ctx = new DBEntities())
			{
				Delete(ctx, category);
			}
		}
		public static void Delete(int id)
		{
			using (var ctx = new DBEntities())
			{
				var category = Get(ctx, id);
				Delete(ctx, category);
			}
		}
		public static void Delete(DBEntities ctx, Category category)
		{
			try
			{
				ctx.Category.Remove(category);
				ctx.SaveChanges();
			}
			catch (Exception e)
			{
				ctx.Entry(category).State = EntityState.Unchanged;
				string msg = string.Format("Nem sikerült a Category rekord törlése. ID: {0}. ", category.ID);
				throw new BookteraException(msg, e, BookteraExceptionCode.DeleteCategory);
			}
		}

		#endregion

		#endregion


		#region OTHERS

		#region CalculateLevel

		public static int CalculateLevel(string sort)
		{
			return sort.Length / 3 + 1;
		}

		#endregion

		#region CopyFromProxy

		public static Category CopyFromProxy(Category category)
		{
			bool wasNew;
			AutoMapperInitializer<Category, Category>
				.InitializeIfNeeded(out wasNew, sourceProxy: category)
				.ForMemberIfNeeded(wasNew, category.Property(c => c.ChildCategories), imce => imce.Ignore())
				.ForMemberIfNeeded(wasNew, category.Property(c => c.ParentCategory), imce => imce.Ignore())
				.ForMemberIfNeeded(wasNew, category.Property(c => c.ProductGroupsInCategory), imce => imce.Ignore());
			return Mapper.Map<Category>(category);
		}

		#endregion

		#endregion
	}
}
