using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Transactions;
using AutoMapper;
using BLL.ModelManagers;
using CommonModels.Models;
using CommonModels.Models.EntityFramework;
using CommonPortable.Enums;
using CommonPortable.Exceptions;
using DAL.EntityFramework;
using UtilsLocal;
using UtilsShared;
using UtilsSharedPortable;

namespace BLL.EntityManagers
{
	public static class CommentManager
	{
		#region CREATE

		#region Add

		public static void Add(Comment comment, ProductGroup commentsProductGroup = null)
		{
			using(var ctx = new DBEntities())
			using(var transactionScope = new TransactionScope())
			{
				Add(ctx, comment, commentsProductGroup);
				transactionScope.Complete();
			}
		}
		public static void Add(DBEntities ctx, Comment comment, ProductGroup commentsProductGroup = null)
		{
			try
			{
				ctx.Comment.Add(comment);

				var productGroup = commentsProductGroup ?? comment.ProductGroup;
				productGroup.SumOfComments++;

				ctx.SaveChanges();
			}
			catch(Exception e)
			{
				ctx.Entry(comment).State = EntityState.Detached;
				const string msg = "Nem sikerült beszúrni a Comment rekordot. ";
				throw new BookteraException(msg, e, BookteraExceptionCode.AddComment_InsertFailed);
			}
		}

		#endregion

		#endregion

		#region READ

		#region GetByID

		public static Comment Get(int id)
		{
			using(var ctx = new DBEntities())
			{
				return Get(ctx, id);
			}
		}
		public static Comment Get(DBEntities ctx, int id)
		{
			try
			{
				return ctx.Comment.Single(p => p.ID == id);
			}
			catch(Exception e)
			{
				var msg = String.Format("Nem található a Comment rekord az adatbázisban. ID: {0}. ", id);
				throw new BookteraException(msg, e, BookteraExceptionCode.GetCommentById);
			}
		}

		#endregion

		#region GetUsersComments

		public static List<CommentWithProductGroupVM> GetUsersComments(int userId)
		{
			using(var ctx = new DBEntities())
			{
				return GetUsersComments(ctx, userId);
			}
		}

		public static List<CommentWithProductGroupVM> GetUsersComments(DBEntities ctx, int userId)
		{
			var comments = ctx.Comment.Where(uo => uo.UserID == userId).OrderByDescending(uo => uo.CreatedDate);

			var result = new List<CommentWithProductGroupVM>();
			foreach(Comment comment in comments)
			{
				result.Add(new CommentWithProductGroupVM().DoConsturctorWork(comment));
			}
			return result;
		}

		#endregion

		#endregion

		#region UPDATE

		#region Update

		public static void Update(Comment comment)
		{
			using(var ctx = new DBEntities())
			{
				Update(ctx, comment);
			}
		}

		public static void Update(DBEntities ctx, Comment comment)
		{
			try
			{
				ctx.SaveChanges();
			}
			catch(Exception e)
			{
				ctx.Entry(comment).State = EntityState.Unchanged;
				string msg = string.Format("Nem sikerült a frissíteni a Comment rekordot! ID: {0}. ", comment.ID);
				throw new BookteraException(msg, e, BookteraExceptionCode.UpdateComment);
			}
		}

		#endregion

		#endregion

		#region DELETE

		#region Delete

		public static void Delete(Comment comment)
		{
			using(var ctx = new DBEntities())
			{
				Delete(ctx, comment);
			}
		}
		public static void Delete(int id)
		{
			using(var ctx = new DBEntities())
			{
				var comment = Get(ctx, id);
				Delete(ctx, comment);
			}
		}
		public static void Delete(DBEntities ctx, Comment comment)
		{
			try
			{
				ctx.Comment.Remove(comment);
				ctx.SaveChanges();
			}
			catch(Exception e)
			{
				ctx.Entry(comment).State = EntityState.Unchanged;
				string msg = string.Format("Nem sikerült a Comment rekord törlése. ID: {0}. ", comment.ID);
				throw new BookteraException(msg, e, BookteraExceptionCode.DeleteComment);
			}
		}

		#endregion

		#endregion
	
		
		#region OTHERS

		#region CopyFromProxy

		public static Comment CopyFromProxy(Comment comment)
		{
			bool wasNew;
			AutoMapperInitializer<Comment, Comment>
				.InitializeIfNeeded(out wasNew, sourceProxy: comment)
				.ForMemberIfNeeded(wasNew, comment.Property(c => c.ChildComments), imce => imce.Ignore())
				.ForMemberIfNeeded(wasNew, comment.Property(c => c.ParentComment), imce => imce.Ignore())
				.ForMemberIfNeeded(wasNew, comment.Property(c => c.ProductGroup), imce => imce.Ignore())
				.ForMemberIfNeeded(wasNew, comment.Property(c => c.UserProfile), imce => imce.Ignore());
			return Mapper.Map<Comment>(comment);
		}

		#endregion

		#endregion
	}
}


