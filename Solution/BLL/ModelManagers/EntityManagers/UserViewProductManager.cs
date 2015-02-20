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
	public static class UserViewManager
	{
		#region CREATE

		#region Add

		public static void Add(UserView userView)
		{
			using (var ctx = new DBEntities())
			{
				Add(ctx, userView);
			}
		}
		public static void Add(DBEntities ctx, UserView userView)
		{
			try
			{
				ctx.UserView.Add(userView);
				ctx.SaveChanges();
			}
			catch (Exception e)
			{
				ctx.Entry(userView).State = EntityState.Detached;
				const string msg = "Nem sikerült beszúrni a UserView rekordot. ";
				throw new BookteraException(msg, e, BookteraExceptionCode.AddUserView_InsertFailed);
			}
		}

		#endregion

		#endregion

		#region READ

		#region GetByID

		public static UserView Get(int id)
		{
			using (var ctx = new DBEntities())
			{
				return Get(ctx, id);
			}
		}
		public static UserView Get(DBEntities ctx, int id)
		{
			try
			{
				return ctx.UserView.Single(p => p.ID == id);
			}
			catch (Exception e)
			{
				var msg = String.Format("Nem található a UserView rekord az adatbázisban. ID: {0}. ", id);
				throw new BookteraException(msg, e, BookteraExceptionCode.GetUserViewById);
			}
		}

		#endregion

		#endregion

		#region UPDATE

		#region Update

		public static void Update(UserView userView)
		{
			using (var ctx = new DBEntities())
			{
				Update(ctx, userView);
			}
		}

		public static void Update(DBEntities ctx, UserView userView)
		{
			try
			{
				ctx.SaveChanges();
			}
			catch (Exception e)
			{
				ctx.Entry(userView).State = EntityState.Unchanged;
				string msg = string.Format("Nem sikerült a frissíteni a UserView rekordot! ID: {0}. ", userView.ID);
				throw new BookteraException(msg, e, BookteraExceptionCode.UpdateUserView);
			}
		}

		#endregion

		#endregion

		#region DELETE

		#region Delete

		public static void Delete(UserView userView)
		{
			using (var ctx = new DBEntities())
			{
				Delete(ctx, userView);
			}
		}
		public static void Delete(int id)
		{
			using (var ctx = new DBEntities())
			{
				var userView = Get(ctx, id);
				Delete(ctx, userView);
			}
		}
		public static void Delete(DBEntities ctx, UserView userView)
		{
			try
			{
				ctx.UserView.Remove(userView);
				ctx.SaveChanges();
			}
			catch (Exception e)
			{
				ctx.Entry(userView).State = EntityState.Unchanged;
				string msg = string.Format("Nem sikerült a UserView rekord törlése. ID: {0}. ", userView.ID);
				throw new BookteraException(msg, e, BookteraExceptionCode.DeleteUserView);
			}
		}

		#endregion

		#endregion
		
		#region OTHERS

		#region CopyFromProxy

		public static UserView CopyFromProxy(UserView userView)
		{
			bool wasNew;
			AutoMapperInitializer<UserView, UserView>
				.InitializeIfNeeded(out wasNew, sourceProxy: userView)
				.ForMemberIfNeeded(wasNew, userView.Property(uv => uv.Product), imce => imce.Ignore())
				.ForMemberIfNeeded(wasNew, userView.Property(uv => uv.ProductGroup), imce => imce.Ignore())
				.ForMemberIfNeeded(wasNew, userView.Property(uv => uv.UserProfile), imce => imce.Ignore());
			return Mapper.Map<UserView>(userView);
		}

		#endregion
		
		#endregion
	}
}
