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
	public static class FeedbackManager
	{
		#region CREATE

		#region Add

		public static void Add(Feedback feedback)
		{
			using(var ctx = new DBEntities())
			{
				Add(ctx, feedback);
			}
		}
		public static void Add(DBEntities ctx, Feedback feedback)
		{
			try
			{
				ctx.Feedback.Add(feedback);
				ctx.SaveChanges();
			}
			catch(Exception e)
			{
				ctx.Entry(feedback).State = EntityState.Detached;
				const string msg = "Nem siker�lt besz�rni a Feedback rekordot. ";
				throw new BookteraException(msg, e, BookteraExceptionCode.AddFeedback_InsertFailed);
			}
		}

		#endregion

		#region GiveFeedback

		public static void GiveFeedback(DBEntities ctx, UserProfile customer, UserProfile vendor, UserOrder userOrder, bool didCustomer, bool wasSuccessful, bool saveChanges = true)
		{
			int rateGiverUserID = didCustomer ? customer.ID : vendor.ID;
			int ratedUserID = didCustomer ? vendor.ID : customer.ID;
			byte ratingValue = (byte)(wasSuccessful ? 10 : 1);

			try
			{
				var feedback = new Feedback(true)
				{
					Description = string.Empty,
					IsPositive = null,
					Date = DateTime.Now,
					UserOrderID = userOrder.ID,
					// Depend on didCustomer
					IsCustomers = didCustomer,
					RateGiverUserID = rateGiverUserID,
					RatedUserID = ratedUserID,
					// Depend on wasSuccessful
					ProductsQuality = ratingValue,
					SellerContact = ratingValue,
					TransactionQuality = ratingValue,
					TransportAndBoxing = ratingValue,
					WasSuccessful = wasSuccessful,
				};

				if (saveChanges)
					Add(ctx, feedback);
				else
					ctx.Feedback.Add(feedback);
			}
			catch (Exception e)
			{
				var msg = string.Format("Nem siker�lt visszajelz�st k�sz�tenie a felhaszn�l�nak (UserID: {0}, {1}) a tranzakci�r�l (UserOrderID: {2})", rateGiverUserID, didCustomer ? "vev�" : "elad�", userOrder.ID);
				throw new BookteraException(msg, e, BookteraExceptionCode.GiveFeedback);
			}
		}

		#endregion


		#endregion

		#region READ

		#region GetByID

		public static Feedback Get(int id)
		{
			using(var ctx = new DBEntities())
			{
				return Get(ctx, id);
			}
		}
		public static Feedback Get(DBEntities ctx, int id)
		{
			try
			{
				return ctx.Feedback.Single(p => p.ID == id);
			}
			catch(Exception e)
			{
				var msg = String.Format("Nem tal�lhat� a Feedback rekord az adatb�zisban. ID: {0}. ", id);
				throw new BookteraException(msg, e, BookteraExceptionCode.GetFeedbackById);
			}
		}

		#endregion

		#endregion

		#region UPDATE

		#region Update

		public static void Update(Feedback feedback)
		{
			using(var ctx = new DBEntities())
			{
				Update(ctx, feedback);
			}
		}

		public static void Update(DBEntities ctx, Feedback feedback)
		{
			try
			{
				ctx.SaveChanges();
			}
			catch(Exception e)
			{
				ctx.Entry(feedback).State = EntityState.Unchanged;
				string msg = string.Format("Nem siker�lt a friss�teni a Feedback rekordot! ID: {0}. ", feedback.ID);
				throw new BookteraException(msg, e, BookteraExceptionCode.UpdateFeedback);
			}
		}

		#endregion

		#endregion

		#region DELETE

		#region Delete

		public static void Delete(Feedback feedback)
		{
			using(var ctx = new DBEntities())
			{
				Delete(ctx, feedback);
			}
		}
		public static void Delete(int id)
		{
			using(var ctx = new DBEntities())
			{
				var feedback = Get(ctx, id);
				Delete(ctx, feedback);
			}
		}
		public static void Delete(DBEntities ctx, Feedback feedback)
		{
			try
			{
				ctx.Feedback.Remove(feedback);
				ctx.SaveChanges();
			}
			catch(Exception e)
			{
				ctx.Entry(feedback).State = EntityState.Unchanged;
				string msg = string.Format("Nem siker�lt a Feedback rekord t�rl�se. ID: {0}. ", feedback.ID);
				throw new BookteraException(msg, e, BookteraExceptionCode.DeleteFeedback);
			}
		}

		#endregion

		#endregion
	
		
		#region OTHERS

		#region CopyFromProxy

		public static Feedback CopyFromProxy(Feedback feedback)
		{
			bool wasNew;
			AutoMapperInitializer<Feedback, Feedback>
				.InitializeIfNeeded(out wasNew, sourceProxy: feedback)
				.ForMemberIfNeeded(wasNew, feedback.Property(f => f.UserOrder), imce => imce.Ignore())
				.ForMemberIfNeeded(wasNew, feedback.Property(f => f.RateGiverUser), imce => imce.Ignore())
				.ForMemberIfNeeded(wasNew, feedback.Property(f => f.RatedUser), imce => imce.Ignore());
			return Mapper.Map<Feedback>(feedback);
		}

		#endregion

		#endregion
	}
}
