using System;
using System.Collections.Generic;
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
	public static class UserGroupManager
	{
		#region CREATE

		#region Add

		public static void Add(UserGroup userGroup)
		{
			using (var ctx = new DBEntities())
			{
				Add(ctx, userGroup);
			}
		}
		public static void Add(DBEntities ctx, UserGroup userGroup)
		{
			try
			{
				ctx.UserGroup.Add(userGroup);
				ctx.SaveChanges();
			}
			catch (Exception e)
			{
				ctx.Entry(userGroup).State = EntityState.Detached;
				const string msg = "Nem sikerült beszúrni a UserGroup rekordot. ";
				throw new BookteraException(msg, e, BookteraExceptionCode.AddUserGroup_InsertFailed);
			}
		}

		#endregion

		#endregion

		#region READ

		#region GetByID

		public static UserGroup Get(int id)
		{
			using (var ctx = new DBEntities())
			{
				return Get(ctx, id);
			}
		}
		public static UserGroup Get(DBEntities ctx, int id)
		{
			try
			{
				return ctx.UserGroup.Single(p => p.ID == id);
			}
			catch (Exception e)
			{
				var msg = String.Format("Nem található a UserGroup rekord az adatbázisban. ID: {0}. ", id);
				throw new BookteraException(msg, e, BookteraExceptionCode.GetUserGroupById);
			}
		}

		#endregion

		#region GetAll

		public static List<UserGroup> GetAll()
		{
			using (var ctx = new DBEntities())
			{
				return ctx.UserGroup.ToList();
			}
		}
		public static List<UserGroup> GetAllWithUsers(int currentUserId, out int usersGroupId)
		{
			using (var ctx = new DBEntities())
			{
				usersGroupId = UserProfileManager.GetUsersLevel(ctx, currentUserId);
				return ctx.UserGroup.ToList();
			}
		}

		#endregion

		#endregion

		#region UPDATE

		#region Update

		public static void Update(UserGroup userGroup)
		{
			using (var ctx = new DBEntities())
			{
				Update(ctx, userGroup);
			}
		}

		public static void Update(DBEntities ctx, UserGroup userGroup)
		{
			try
			{
				ctx.SaveChanges();
			}
			catch (Exception e)
			{
				ctx.Entry(userGroup).State = EntityState.Unchanged;
				string msg = string.Format("Nem sikerült a frissíteni a UserGroup rekordot! ID: {0}. ", userGroup.ID);
				throw new BookteraException(msg, e, BookteraExceptionCode.UpdateUserGroup);
			}
		}

		#endregion

		#endregion

		#region DELETE

		#region Delete

		public static void Delete(UserGroup userGroup)
		{
			using (var ctx = new DBEntities())
			{
				Delete(ctx, userGroup);
			}
		}
		public static void Delete(int id)
		{
			using (var ctx = new DBEntities())
			{
				var userGroup = Get(ctx, id);
				Delete(ctx, userGroup);
			}
		}
		public static void Delete(DBEntities ctx, UserGroup userGroup)
		{
			try
			{
				ctx.UserGroup.Remove(userGroup);
				ctx.SaveChanges();
			}
			catch (Exception e)
			{
				ctx.Entry(userGroup).State = EntityState.Unchanged;
				string msg = string.Format("Nem sikerült a UserGroup rekord törlése. ID: {0}. ", userGroup.ID);
				throw new BookteraException(msg, e, BookteraExceptionCode.DeleteUserGroup);
			}
		}

		#endregion

		#endregion
		
		#region OTHERS

		#region CopyFromProxy

		public static UserGroup CopyFromProxy(UserGroup userGroup)
		{
			bool wasNew;
			AutoMapperInitializer<UserGroup, UserGroup>
				.InitializeIfNeeded(out wasNew, sourceProxy: userGroup)
				.ForMemberIfNeeded(wasNew, userGroup.Property(ug => ug.UserProfiles), imce => imce.Ignore());
			return Mapper.Map<UserGroup>(userGroup);
		}

		#endregion

		#endregion
	}
}
