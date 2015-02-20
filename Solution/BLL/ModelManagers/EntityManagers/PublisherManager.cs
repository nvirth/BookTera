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
	public static class PublisherManager
	{
		#region CREATE

		#region Add

		public static void Add(Publisher publisher)
		{
			using(var ctx = new DBEntities())
			{
				Add(ctx, publisher);
			}
		}
		public static void Add(DBEntities ctx, Publisher publisher)
		{
			try
			{
				ctx.Publisher.Add(publisher);
				ctx.SaveChanges();
			}
			catch(Exception e)
			{
				ctx.Entry(publisher).State = EntityState.Detached;
				const string msg = "Nem sikerült beszúrni a Publisher rekordot. ";
				throw new BookteraException(msg, e, BookteraExceptionCode.AddPublisher_InsertFailed);
			}
		}

		#endregion

		#endregion

		#region READ

		#region GetByID

		public static Publisher Get(int id)
		{
			using(var ctx = new DBEntities())
			{
				return Get(ctx, id);
			}
		}
		public static Publisher Get(DBEntities ctx, int id)
		{
			try
			{
				return ctx.Publisher.Single(p => p.ID == id);
			}
			catch(Exception e)
			{
				var msg = String.Format("Nem található a Publisher rekord az adatbázisban. ID: {0}. ", id);
				throw new BookteraException(msg, e, BookteraExceptionCode.GetPublisherById);
			}
		}

		#endregion

		#region Get by FriendlyUrl && UserID

		public static Publisher Get(DBEntities ctx, string friendlyUrl, int? userId = null)
		{
			try
			{
				return ctx.Publisher
						  .Where(p => p.FriendlyUrl == friendlyUrl)
						  .Single(p => (userId == null && p.UserID == null) || (p.UserID == userId));
			}
			catch(Exception e)
			{
				const string msg = "Nem található a keresett Publisher rekord. (Vagy több is van, ez lehetetlen esemény). ";
				throw new BookteraException(msg, e, BookteraExceptionCode.GetPublisherByFriendlyUrl);
			}
		}

		#endregion

		#region GetAll

		public static List<Publisher> GetAllPublishers()
		{
			using(var ctx = new DBEntities())
			{
				return ctx.Publisher.OrderBy(p => p.DisplayName).ToList();
			}
		}

		#endregion

		#region GetAllNotUserPublishers

		public static List<Publisher> GetAllNotUserPublishers()
		{
			using(var ctx = new DBEntities())
			{
				return ctx.Publisher.Where(p => p.UserID == null).OrderBy(p => p.DisplayName).ToList();
			}
		}

		#endregion

		#region GetSearchAutoComplete

		public static string GetSearchAutoComplete(string publisherName, int howMany, bool isValuePlain = false)
		{
			using(var ctx = new DBEntities())
			{
				var resultList =
					ctx.Publisher
						.Where(p => String.IsNullOrEmpty(publisherName) || p.DisplayName.Contains(publisherName))
						.Where(p => p.UserID == null)
						.Select(p => new
						{
							label = p.DisplayName,
							value = isValuePlain ? p.DisplayName : p.FriendlyUrl,
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

		public static void Update(Publisher publisher)
		{
			using(var ctx = new DBEntities())
			{
				Update(ctx, publisher);
			}
		}

		public static void Update(DBEntities ctx, Publisher publisher)
		{
			try
			{
				ctx.SaveChanges();
			}
			catch(Exception e)
			{
				ctx.Entry(publisher).State = EntityState.Unchanged;
				string msg = string.Format("Nem sikerült a frissíteni a Publisher rekordot! ID: {0}. ", publisher.ID);
				throw new BookteraException(msg, e, BookteraExceptionCode.UpdatePublisher);
			}
		}

		#endregion

		#endregion

		#region DELETE

		#region Delete

		public static void Delete(Publisher publisher)
		{
			using(var ctx = new DBEntities())
			{
				Delete(ctx, publisher);
			}
		}
		public static void Delete(int id)
		{
			using(var ctx = new DBEntities())
			{
				var publisher = Get(ctx, id);
				Delete(ctx, publisher);
			}
		}
		public static void Delete(DBEntities ctx, Publisher publisher)
		{
			try
			{
				ctx.Publisher.Remove(publisher);
				ctx.SaveChanges();
			}
			catch(Exception e)
			{
				ctx.Entry(publisher).State = EntityState.Unchanged;
				string msg = string.Format("Nem sikerült a Publisher rekord törlése. ID: {0}. ", publisher.ID);
				throw new BookteraException(msg, e, BookteraExceptionCode.DeletePublisher);
			}
		}

		#endregion

		#endregion
		
		
		#region OTHERS

		#region CopyFromProxy

		public static Publisher CopyFromProxy(Publisher publisher)
		{
			bool wasNew;
			AutoMapperInitializer<Publisher, Publisher>
				.InitializeIfNeeded(out wasNew, sourceProxy: publisher)
				.ForMemberIfNeeded(wasNew, publisher.Property(p => p.ProductGroups), imce => imce.Ignore())
				.ForMemberIfNeeded(wasNew, publisher.Property(p => p.UserProfile), imce => imce.Ignore());
			return Mapper.Map<Publisher>(publisher);
		}

		#endregion
		
		#endregion
	}
}
