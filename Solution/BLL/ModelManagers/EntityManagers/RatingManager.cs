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
	public static class RatingManager
	{
		#region CREATE

		#region Add

		public static void Add(Rating rating, ProductGroup ratingsProductGroup = null)
		{
			using(var ctx = new DBEntities())
			using(var transactionScope = new TransactionScope())
			{
				Add(ctx, rating, ratingsProductGroup);
				transactionScope.Complete();
			}
		}
		public static void Add(DBEntities ctx, Rating rating, ProductGroup ratingsProductGroup = null)
		{
			try
			{
				ctx.Rating.Add(rating);

				var productGroup = ratingsProductGroup ?? rating.ProductGroup;
				productGroup.SumOfRatings++;
				productGroup.SumOfRatingsValue += rating.Value;

				ctx.SaveChanges();
			}
			catch (Exception e)
			{
				ctx.Entry(rating).State = EntityState.Detached;
				const string msg = "Nem sikerült beszúrni a Rating rekordot. ";
				throw new BookteraException(msg, e, BookteraExceptionCode.AddRating_InsertFailed);
			}
		}

		#endregion

		#endregion

		#region READ

		#region GetByID

		public static Rating Get(int id)
		{
			using (var ctx = new DBEntities())
			{
				return Get(ctx, id);
			}
		}
		public static Rating Get(DBEntities ctx, int id)
		{
			try
			{
				return ctx.Rating.Single(p => p.ID == id);
			}
			catch (Exception e)
			{
				var msg = String.Format("Nem található a Rating rekord az adatbázisban. ID: {0}. ", id);
				throw new BookteraException(msg, e, BookteraExceptionCode.GetRatingById);
			}
		}

		#endregion
	
		#region GetUsersRatings

		public static List<RatingWithProductGroupVM> GetUsersRatings(int userId)
		{
			using(var ctx = new DBEntities())
			{
				return GetUsersRatings(ctx, userId);
			}
		}

		public static List<RatingWithProductGroupVM> GetUsersRatings(DBEntities ctx, int userId)
		{
			var ratings = ctx.Rating.Where(r => r.UserID == userId).OrderByDescending(r => r.Date);
			
			var result = new List<RatingWithProductGroupVM>();
			foreach(Rating rating in ratings)
			{
				result.Add(new RatingWithProductGroupVM().DoConsturctorWork(rating));
			}
			return result;
		}

		#endregion

		#endregion

		#region UPDATE

		#region Update

		public static void Update(Rating rating)
		{
			using (var ctx = new DBEntities())
			{
				Update(ctx, rating);
			}
		}

		public static void Update(DBEntities ctx, Rating rating)
		{
			try
			{
				ctx.SaveChanges();
			}
			catch (Exception e)
			{
				ctx.Entry(rating).State = EntityState.Unchanged;
				string msg = string.Format("Nem sikerült a frissíteni a Rating rekordot! ID: {0}. ", rating.ID);
				throw new BookteraException(msg, e, BookteraExceptionCode.UpdateRating);
			}
		}

		#endregion

		#endregion

		#region DELETE

		#region Delete

		public static void Delete(Rating rating)
		{
			using (var ctx = new DBEntities())
			{
				Delete(ctx, rating);
			}
		}
		public static void Delete(int id)
		{
			using (var ctx = new DBEntities())
			{
				var rating = Get(ctx, id);
				Delete(ctx, rating);
			}
		}
		public static void Delete(DBEntities ctx, Rating rating)
		{
			try
			{
				ctx.Rating.Remove(rating);
				ctx.SaveChanges();
			}
			catch (Exception e)
			{
				ctx.Entry(rating).State = EntityState.Unchanged;
				string msg = string.Format("Nem sikerült a Rating rekord törlése. ID: {0}. ", rating.ID);
				throw new BookteraException(msg, e, BookteraExceptionCode.DeleteRating);
			}
		}

		#endregion

		#endregion


		#region OTHERS

		#region CopyFromProxy

		public static Rating CopyFromProxy(Rating rating)
		{
			bool wasNew;
			AutoMapperInitializer<Rating, Rating>
				.InitializeIfNeeded(out wasNew, sourceProxy: rating)
				.ForMemberIfNeeded(wasNew, rating.Property(r => r.ProductGroup), imce => imce.Ignore())
				.ForMemberIfNeeded(wasNew, rating.Property(r => r.UserProfile), imce => imce.Ignore());
			return Mapper.Map<Rating>(rating);
		}

		#endregion
		
		#endregion
	}
}
