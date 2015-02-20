using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.Script.Serialization;
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
	public static class AuthorManager
	{
		#region CREATE

		#region Add

		public static void Add(Author author)
		{
			using(var ctx = new DBEntities())
			{
				Add(ctx, author);
			}
		}
		public static void Add(DBEntities ctx, Author author)
		{
			try
			{
				ctx.Author.Add(author);
				ctx.SaveChanges();
			}
			catch(Exception e)
			{
				ctx.Entry(author).State = EntityState.Detached;
				const string msg = "Nem sikerült beszúrni az Author rekordot. ";
				throw new BookteraException(msg, e, BookteraExceptionCode.AddAuthor_InsertFailed);
			}
		}

		#endregion

		#endregion

		#region READ

		#region GetByID

		public static Author Get(int id)
		{
			using(var ctx = new DBEntities())
			{
				return Get(ctx, id);
			}
		}
		public static Author Get(DBEntities ctx, int id)
		{
			try
			{
				return ctx.Author.Single(a => a.ID == id);
			}
			catch(Exception e)
			{
				var msg = String.Format("Nem található az Author rekord az adatbázisban. ID: {0}. ", id);
				throw new BookteraException(msg, e, BookteraExceptionCode.GetAuthorById);
			}
		}

		#endregion

		#region Get by FriendlyUrl && UserID

		public static Author Get(DBEntities ctx, string friendlyUrl, int? userId = null)
		{
			try
			{
				return ctx.Author
				          .Where(a => a.FriendlyUrl == friendlyUrl)
				          .Single(a => (userId == null && a.UserID == null) || (a.UserID == userId));
			}
			catch(Exception e)
			{
				var msg = String.Format("Nem található az Author rekord az adatbázisban. FriendlyUrl: {0}. ", friendlyUrl);
				throw new BookteraException(msg, e, BookteraExceptionCode.GetAuthorByFriendlyUrl);
			}
		}

		#endregion

		#region GetAll

		public static List<Author> GetAll()
		{
			using(var ctx = new DBEntities())
			{
				return ctx.Author.OrderBy(a => a.DisplayName).ToList();
			}
		}

		#endregion

		#region GetAllNotUserAuthors

		public static List<Author> GetAllNotUserAuthors()
		{
			using(var ctx = new DBEntities())
			{
				return ctx.Author.Where(a => a.UserID == null).OrderBy(a => a.DisplayName).ToList();
			}
		}

		#endregion

		#region GetSearchAutoComplete

		public static string GetSearchAutoComplete(string authorName, int howMany, bool isValuePlain = false)
		{
			using(var ctx = new DBEntities())
			{
				var resultList =
					ctx.Author
						.Where(a => String.IsNullOrEmpty(authorName) || a.DisplayName.Contains(authorName))
						.Where(a => a.UserID == null)
						.Select(a => new
						{
							label = a.DisplayName,
							value = isValuePlain ? a.DisplayName : a.FriendlyUrl,
						})
						.Take(howMany);

				var jsonString = new JavaScriptSerializer().Serialize(resultList);
				return jsonString;
			}
		}

		#endregion

		#endregion

		#region UPDATE

		#region Update

		public static void Update(Author author)
		{
			using(var ctx = new DBEntities())
			{
				Update(ctx, author);
			}
		}

		public static void Update(DBEntities ctx, Author author)
		{
			try
			{
				ctx.SaveChanges();
			}
			catch(Exception e)
			{
				ctx.Entry(author).State = EntityState.Unchanged;
				string msg = string.Format("Nem sikerült a frissíteni a Author rekordot! ID: {0}. ", author.ID);
				throw new BookteraException(msg, e, BookteraExceptionCode.UpdateAuthor);
			}
		}

		#endregion

		#endregion

		#region DELETE

		#region Delete

		public static void Delete(Author author)
		{
			using(var ctx = new DBEntities())
			{
				Delete(ctx, author);
			}
		}
		public static void Delete(int id)
		{
			using(var ctx = new DBEntities())
			{
				var author = Get(ctx, id);
				Delete(ctx, author);
			}
		}
		public static void Delete(DBEntities ctx, Author author)
		{
			try
			{
				ctx.Author.Remove(author);
				ctx.SaveChanges();
			}
			catch(Exception e)
			{
				ctx.Entry(author).State = EntityState.Unchanged;
				string msg = string.Format("Nem sikerült a Author rekord törlése. ID: {0}. ", author.ID);
				throw new BookteraException(msg, e, BookteraExceptionCode.DeleteAuthor);
			}
		}

		#endregion

		#endregion

	
		#region OTHERS

		#region CopyFromProxy

		public static Author CopyFromProxy(Author author)
		{
			bool wasNew;
			AutoMapperInitializer<Author, Author>
				.InitializeIfNeeded(out wasNew, sourceProxy: author)
				.ForMemberIfNeeded(wasNew, author.Property(a => a.UserProfile), imce => imce.Ignore())
				.ForMemberIfNeeded(wasNew, author.Property(a => a.ProductGroups), imce => imce.Ignore());
			return Mapper.Map<Author>(author);
		}

		#endregion

		#endregion
	}
}
