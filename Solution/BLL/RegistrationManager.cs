using System;
using System.Transactions;
using System.Web.Helpers;
using BLL.EntityManagers;
using CommonModels.Methods;
using CommonModels.Methods.ManagerRelief;
using CommonModels.Models;
using CommonModels.Models.AccountModels;
using CommonModels.Models.EntityFramework;
using CommonPortable.Enums;
using CommonPortable.Exceptions;
using DAL.EntityFramework;
using UtilsLocal;
using UtilsShared;
using UserProfile = CommonModels.Models.EntityFramework.UserProfile;

namespace BLL
{
	public class RegistrationManager
	{
		#region CREATE

		#region RegisterUser

		/// <summary>
		/// 
		/// </summary>
		/// <param name="registerVm"></param>
		/// <param name="isTest"></param>
		/// <returns></returns>
		public static void RegisterUser(RegisterVM registerVm, bool isTest = false)
		{
			try
			{
				using(var ctx = new DBEntities())
				using(var transactionScope = new TransactionScope())
				{
					int userGroupId = RegisterUser_CheckingsAndMakeUserGroupId(registerVm.AuthorName, registerVm.PublisherName);

					var userProfile = RegisterUser_ManageUserProfile(ctx, registerVm, userGroupId, isTest);
					var imageException = RegisterUser_ManageImage(ctx, registerVm, userProfile);
					var addressException = RegisterUser_ManageAddress(ctx, registerVm.UserAddress, userProfile);
					var authorException = RegisterUser_ManageAuthor(ctx, userProfile.ID, registerVm.AuthorName, userProfile);
					var publisherException = RegisterUser_ManagePublisher(ctx, userProfile.ID, registerVm.PublisherName, userProfile);

					RegisterUser_ManageErrorsAndCommit(transactionScope, imageException, addressException, authorException, publisherException);
				}
			}
			catch(Exception e)
			{
				// Ha a regisztráció sikeres volt, de voltak problémák, amiket sikerült kezelni, és/vagy nem voltak fontosak
				var eb = e as BookteraException;
				if((eb != null) && (eb.Code == BookteraExceptionCode.RegisterUser_SuccesfulWithSomeProblems))
					throw eb;

				// Minden más hibánál
				const string msg = "Nem sikerült a felhasználó regisztrálása. ";
				throw new BookteraException(msg, e, BookteraExceptionCode.RegisterUser);
			}
		}

		private static void RegisterUser_ManageErrorsAndCommit(TransactionScope transactionScope, BookteraException imageException, BookteraException addressException, BookteraException authorException, BookteraException publisherException)
		{
			AggregateException innerExceptions = null;

			// Ha volt valami hiba, összeállítjuk az Exception-csomagot
			if((imageException != null) || (addressException != null) || (authorException != null) || (publisherException != null))
			{
				imageException = imageException ?? new BookteraException();
				addressException = addressException ?? new BookteraException();
				authorException = authorException ?? new BookteraException();
				publisherException = publisherException ?? new BookteraException();

				innerExceptions = new AggregateException(imageException, addressException, authorException, publisherException);
			}

			// Ha olyan hiba történt, amit nem sikerült rendesen kezelni, akkor rollback a regisztrációra
			if((authorException != null && authorException.Code == BookteraExceptionCode.RegisterUser_ManageAuthor_UnSuccesfulRollback)
				|| (publisherException != null && publisherException.Code == BookteraExceptionCode.RegisterUser_ManagePublisher_UnSuccesfulRollback))
			{
				throw innerExceptions;
			}

			// Commit
			transactionScope.Complete();

			// Ha voltak "nem fontos" hibák, akkor azokról azért beszámolunk
			if(innerExceptions != null)
			{
				const string msg = "A regisztráció sikeres volt, de voltak azért problémák. ";
				throw new BookteraException(msg, innerExceptions, BookteraExceptionCode.RegisterUser_SuccesfulWithSomeProblems);
			}
		}
		private static UserProfile RegisterUser_ManageUserProfile(DBEntities ctx, RegisterVM registerVm, int userGroupId, bool isTest)
		{
			// UserProfile

			var isAuthor = userGroupId == (int)UserGroupEnum.Author;
			var isPublisher = userGroupId == (int)UserGroupEnum.Publisher;

			var userProfile = new UserProfile(true)
			{
				UserName = registerVm.UserName,
				EMail = registerVm.EMail,
				FullName = registerVm.FullName,
				FriendlyUrl = registerVm.UserName.ToFriendlyUrl(),
				PhoneNumber = registerVm.PhoneNumber,
				ImageUrl = registerVm.ImageUrl,
				IsAuthor = isAuthor,
				IsPublisher = isPublisher,
				UserGroupID = userGroupId,
			};

			UserProfileManager.Add(ctx, userProfile);

			// Membership

			var webpagesMembership = new webpages_Membership()
			{
				Password = Crypto.HashPassword(registerVm.Password),
				PasswordSalt = string.Empty,
				PasswordFailuresSinceLastSuccess = 0,
				PasswordChangedDate = DateTime.Now,
				IsConfirmed = true,
				CreateDate = DateTime.Now,
				UserId = userProfile.ID,
			};

			WebpagesMembershipManager.Add(ctx, webpagesMembership);

			return userProfile;
		}
		private static int RegisterUser_CheckingsAndMakeUserGroupId(string authorName, string publisherName)
		{
			if(authorName != null && publisherName != null)
			{
				const string msg = "Egy felhasználó nem lehet egyszerre kiadó is és szerző is!";
				throw new BookteraException(msg, code: BookteraExceptionCode.RegisterUser_UserIsBothAuthorAndPublisher);
			}

			int userGroupId = (int)UserGroupEnum.Leech;

			if(authorName != null)
				userGroupId = (int)UserGroupEnum.Author;

			if(publisherName != null)
				userGroupId = (int)UserGroupEnum.Publisher;

			return userGroupId;
		}

		/// <summary>
		/// Author regisztrál felhasználónak. 
		/// Az ő Author.DisplayName-je így néz ki: (name)-(userid); pl "Kis Miska-1234". 
		/// </summary>
		/// <param name="ctx"></param>
		/// <param name="userId"></param>
		/// <param name="authorName"></param>
		/// <param name="userProfile"></param>
		/// <returns></returns>
		private static BookteraException RegisterUser_ManageAuthor(DBEntities ctx, int userId, string authorName, UserProfile userProfile)
		{
			if(authorName != null)
			{
				Author author = null;

				try
				{
					author = new Author(true)
					{
						DisplayName = authorName,
						FriendlyUrl = authorName.ToFriendlyUrl(),
						UserID = userId,
					};
					AuthorManager.Add(ctx, author);
				}
				catch(BookteraException e)
				{
					// Ha nem sikerült beszúrni az Author rekordot, a UserProfile se lesz Author
					try
					{
						userProfile.IsAuthor = false;
						ctx.SaveChanges();

						var msg = e.Message + "Sikerült visszavonni a UserProfile rekord IsAuthor-át. ";
						return new BookteraException(msg, e, BookteraExceptionCode.RegisterUser_ManageAuthor_SuccesfulRollback);
					}
					catch(Exception ex)
					{
						var innerExceptions = new AggregateException(e, ex);
						var msg = e.Message + "Nem sikerült visszavonni a UserProfile rekord IsAuthor-át.  ";
						return new BookteraException(msg, innerExceptions, BookteraExceptionCode.RegisterUser_ManageAuthor_UnSuccesfulRollback);
					}
				}
			}
			return null;
		}

		/// <summary>
		/// Publisher regisztrál felhasználónak. 
		/// Az ő Publisher.DisplayName-je így néz ki: (name)-(userid); pl "Volga Könyvkiadó-1234". 
		/// </summary>
		/// <param name="ctx"></param>
		/// <param name="userId"></param>
		/// <param name="publisherName"></param>
		/// <param name="userProfile"></param>
		/// <returns></returns>
		private static BookteraException RegisterUser_ManagePublisher(DBEntities ctx, int userId, string publisherName, UserProfile userProfile)
		{
			if(publisherName != null)
			{
				Publisher publisher = null;

				try
				{
					publisher = new Publisher(true)
					{
						DisplayName = publisherName,
						FriendlyUrl = publisherName.ToFriendlyUrl(),
						UserID = userId,
					};
					PublisherManager.Add(ctx, publisher);
				}
				catch(BookteraException e)
				{
					// Ha nem sikerült beszúrni a Publisher rekordot, a UserProfile se lesz Publisher
					try
					{
						userProfile.IsPublisher = false;
						ctx.SaveChanges();

						string msg = e.Message + "Sikerült visszavonni a UserProfile rekord IsPublisher-ét. ";
						return new BookteraException(msg, e, BookteraExceptionCode.RegisterUser_ManagePublisher_SuccesfulRollback);
					}
					catch(Exception ex)
					{
						var innerExceptions = new AggregateException(e, ex);
						string msg = e.Message + "Nem sikerült visszavonni a UserProfile rekord IsPublisher-ét. ";
						return new BookteraException(msg, innerExceptions, BookteraExceptionCode.RegisterUser_ManagePublisher_UnSuccesfulRollback);
					}
				}
			}
			return null;
		}
		private static BookteraException RegisterUser_ManageAddress(DBEntities ctx, UserAddressVM userAddressVM, UserProfile userProfile)
		{
			if(userAddressVM != null && !UserAddressManagerRelief.CheckAllPropertiesNullOrEmpty(userAddressVM))
			{
				try
				{
					var userAddress = new UserAddress(false)
					{
						ZipCode = userAddressVM.ZipCode,
						City = userAddressVM.City,
						Country = userAddressVM.Country,
						StreetAndHouseNumber = userAddressVM.StreetAndHouseNumber,
						UserID = userProfile.ID,
					};
					UserAddressManager.Add(ctx, userAddress, /*isDefault*/ true, userProfile);
				}
				catch(BookteraException e)
				{
					return e;
				}
			}
			return null;
		}
		private static BookteraException RegisterUser_ManageImage(DBEntities ctx, RegisterVM registerVm, UserProfile userProfile)
		{
			if(registerVm.ImageUrl != null)
			{
				try
				{
					var image = new Image(true)
					{
						Url = registerVm.ImageUrl,
						UserID = userProfile.ID,
						IsDefault = true,
					};

					ImageManager.AddImageDeleteIfFailed(ctx, image, userProfile);
				}
				catch(BookteraException e)
				{
					return e;
				}
			}
			return null;
		}

		#endregion

		#endregion
	}
}