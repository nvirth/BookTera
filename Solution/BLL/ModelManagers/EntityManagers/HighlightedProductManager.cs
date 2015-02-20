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
	public static class HighlightedProductManager
	{
		#region CREATE

		#region Add

		public static void Add(HighlightedProduct highlightedProduct)
		{
			using (var ctx = new DBEntities())
			{
				Add(ctx, highlightedProduct);
			}
		}
		public static void Add(DBEntities ctx, HighlightedProduct highlightedProduct)
		{
			try
			{
				ctx.HighlightedProduct.Add(highlightedProduct);
				ctx.SaveChanges();
			}
			catch (Exception e)
			{
				ctx.Entry(highlightedProduct).State = EntityState.Detached;
				const string msg = "Nem sikerült beszúrni a HighlightedProduct rekordot. ";
				throw new BookteraException(msg, e, BookteraExceptionCode.AddHighlightedProduct_InsertFailed);
			}
		}

		#endregion

		#endregion

		#region READ

		#region GetByID

		public static HighlightedProduct Get(int id)
		{
			using (var ctx = new DBEntities())
			{
				return Get(ctx, id);
			}
		}
		public static HighlightedProduct Get(DBEntities ctx, int id)
		{
			try
			{
				return ctx.HighlightedProduct.Single(p => p.ID == id);
			}
			catch (Exception e)
			{
				var msg = String.Format("Nem található a HighlightedProduct rekord az adatbázisban. ID: {0}. ", id);
				throw new BookteraException(msg, e, BookteraExceptionCode.GetHighlightedProductById);
			}
		}

		#endregion

		#endregion

		#region UPDATE

		#region Update

		public static void Update(HighlightedProduct highlightedProduct)
		{
			using (var ctx = new DBEntities())
			{
				Update(ctx, highlightedProduct);
			}
		}

		public static void Update(DBEntities ctx, HighlightedProduct highlightedProduct)
		{
			try
			{
				ctx.SaveChanges();
			}
			catch (Exception e)
			{
				ctx.Entry(highlightedProduct).State = EntityState.Unchanged;
				string msg = string.Format("Nem sikerült a frissíteni a HighlightedProduct rekordot! ID: {0}. ", highlightedProduct.ID);
				throw new BookteraException(msg, e, BookteraExceptionCode.UpdateHighlightedProduct);
			}
		}

		#endregion

		#endregion

		#region DELETE

		#region Delete

		public static void Delete(HighlightedProduct highlightedProduct)
		{
			using (var ctx = new DBEntities())
			{
				Delete(ctx, highlightedProduct);
			}
		}
		public static void Delete(int id)
		{
			using (var ctx = new DBEntities())
			{
				var highlightedProduct = Get(ctx, id);
				Delete(ctx, highlightedProduct);
			}
		}
		public static void Delete(DBEntities ctx, HighlightedProduct highlightedProduct)
		{
			try
			{
				ctx.HighlightedProduct.Remove(highlightedProduct);
				ctx.SaveChanges();
			}
			catch (Exception e)
			{
				ctx.Entry(highlightedProduct).State = EntityState.Unchanged;
				string msg = string.Format("Nem sikerült a HighlightedProduct rekord törlése. ID: {0}. ", highlightedProduct.ID);
				throw new BookteraException(msg, e, BookteraExceptionCode.DeleteHighlightedProduct);
			}
		}

		#endregion

		#endregion
		
		
		#region OTHERS

		#region CopyFromProxy

		public static HighlightedProduct CopyFromProxy(HighlightedProduct highlightedProduct)
		{
			bool wasNew;
			AutoMapperInitializer<HighlightedProduct, HighlightedProduct>
				.InitializeIfNeeded(out wasNew, sourceProxy: highlightedProduct)
				.ForMemberIfNeeded(wasNew, highlightedProduct.Property(hp => hp.HighlightType), imce => imce.Ignore())
				.ForMemberIfNeeded(wasNew, highlightedProduct.Property(hp => hp.Product), imce => imce.Ignore());
			return Mapper.Map<HighlightedProduct>(highlightedProduct);
		}

		#endregion

		#endregion
	}
}
