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
	public static class HighlightTypeManager
	{
		#region CREATE

		#region Add

		public static void Add(HighlightType highlightType)
		{
			using (var ctx = new DBEntities())
			{
				Add(ctx, highlightType);
			}
		}
		public static void Add(DBEntities ctx, HighlightType highlightType)
		{
			try
			{
				ctx.HighlightType.Add(highlightType);
				ctx.SaveChanges();
			}
			catch (Exception e)
			{
				ctx.Entry(highlightType).State = EntityState.Detached;
				const string msg = "Nem sikerült beszúrni a HighlightType rekordot. ";
				throw new BookteraException(msg, e, BookteraExceptionCode.AddHighlightType_InsertFailed);
			}
		}

		#endregion

		#endregion

		#region READ

		#region GetByID

		public static HighlightType Get(int id)
		{
			using (var ctx = new DBEntities())
			{
				return Get(ctx, id);
			}
		}
		public static HighlightType Get(DBEntities ctx, int id)
		{
			try
			{
				return ctx.HighlightType.Single(p => p.ID == id);
			}
			catch (Exception e)
			{
				var msg = String.Format("Nem található a HighlightType rekord az adatbázisban. ID: {0}. ", id);
				throw new BookteraException(msg, e, BookteraExceptionCode.GetHighlightTypeById);
			}
		}

		#endregion

		#endregion

		#region UPDATE

		#region Update

		public static void Update(HighlightType highlightType)
		{
			using (var ctx = new DBEntities())
			{
				Update(ctx, highlightType);
			}
		}

		public static void Update(DBEntities ctx, HighlightType highlightType)
		{
			try
			{
				ctx.SaveChanges();
			}
			catch (Exception e)
			{
				ctx.Entry(highlightType).State = EntityState.Unchanged;
				string msg = string.Format("Nem sikerült a frissíteni a HighlightType rekordot! ID: {0}. ", highlightType.ID);
				throw new BookteraException(msg, e, BookteraExceptionCode.UpdateHighlightType);
			}
		}

		#endregion

		#endregion

		#region DELETE

		#region Delete

		public static void Delete(HighlightType highlightType)
		{
			using (var ctx = new DBEntities())
			{
				Delete(ctx, highlightType);
			}
		}
		public static void Delete(int id)
		{
			using (var ctx = new DBEntities())
			{
				var highlightType = Get(ctx, id);
				Delete(ctx, highlightType);
			}
		}
		public static void Delete(DBEntities ctx, HighlightType highlightType)
		{
			try
			{
				ctx.HighlightType.Remove(highlightType);
				ctx.SaveChanges();
			}
			catch (Exception e)
			{
				ctx.Entry(highlightType).State = EntityState.Unchanged;
				string msg = string.Format("Nem sikerült a HighlightType rekord törlése. ID: {0}. ", highlightType.ID);
				throw new BookteraException(msg, e, BookteraExceptionCode.DeleteHighlightType);
			}
		}

		#endregion

		#endregion


		#region OTHERS

		#region CalculatePrice

		public static int CalculatePrice(DBEntities ctx, int highlightTypeId, DateTime from, DateTime to)
		{
			var highlightType = Get(ctx, highlightTypeId);

			return CalculatePrice(from, to, highlightType.Price);
		}
		public static int CalculatePrice(DateTime from, DateTime to, int price)
		{
			var days = (to - from).Days;
			var result = price*(days/7);

			return result;
		}

		#endregion

		#region CopyFromProxy

		public static HighlightType CopyFromProxy(HighlightType highlightType)
		{
			bool wasNew;
			AutoMapperInitializer<HighlightType, HighlightType>
				.InitializeIfNeeded(out wasNew, sourceProxy: highlightType)
				.ForMemberIfNeeded(wasNew, highlightType.Property(ht => ht.HighlightedProductsInType), imce => imce.Ignore());
			return Mapper.Map<HighlightType>(highlightType);
		}

		#endregion

		#endregion
	}
}
