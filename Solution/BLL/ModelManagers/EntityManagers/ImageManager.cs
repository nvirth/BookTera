using System;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using AutoMapper;
using CommonModels.Methods;
using CommonModels.Methods.ManagerRelief;
using CommonModels.Models.EntityFramework;
using CommonPortable.Enums;
using CommonPortable.Exceptions;
using DAL.EntityFramework;
using UtilsLocal;
using UtilsShared;
using UtilsSharedPortable;
using GeneralFunctions = UtilsShared.GeneralFunctions;

namespace BLL.EntityManagers
{
	/// <summary>
	/// Három fajta kép van a rendszerben, attól függõen, hogy kihez tartozik. 
	/// - User         - U-(userName)-random
	/// - Product      - P-(id)-random
	/// - ProductGroup - UP-(friendlyUrl)-random
	/// </summary>
	public static class ImageManager
	{
		// -- Properties

		public static string[] AcceptedImageExtensions = (ConfigurationManager.AppSettings["AcceptedImageExtensions"] ?? ".jpg;.jpeg;.bmp;.png;.gif").Split(';');

		// -- Methods

		#region CREATE

		#region Add

		public static void Add(Image image)
		{
			using (var ctx = new DBEntities())
			{
				Add(ctx, image);
			}
		}
		public static void Add(DBEntities ctx, Image image)
		{
			try
			{
				ctx.Image.Add(image);
				ctx.SaveChanges();
			}
			catch (Exception e)
			{
				ctx.Entry(image).State = EntityState.Detached;
				const string msg = "Nem sikerült beszúrni a Image rekordot. ";
				throw new BookteraException(msg, e, BookteraExceptionCode.AddImage_InsertFailed);
			}
		}

		#endregion

		#region AddImageDeleteIfFailed

		public static void AddImageDeleteIfFailed(DBEntities ctx, Image image, Object userProfile_product_productGroup = null, bool needSelectUppg = false)
		{
			try
			{
				Add(ctx, image);
			}
			catch(BookteraException addImageException)
			{
				var msg = addImageException.Message;

				// Törlés a háttértárról
				BookteraException deleteFromHddException =
					AddImageDeleteIfFailed_DeleteFromHdd(image, ref msg);

				// Törlés a UserProfile táblából (update)
				BookteraException deleteFromDbException =
					AddImageDeleteIfFailed_DeleteFromDb(ctx, ref msg, userProfile_product_productGroup, needSelectUppg);

				// Exception-ök összeszedése
				deleteFromHddException = deleteFromHddException ?? new BookteraException();
				deleteFromDbException = deleteFromDbException ?? new BookteraException();
				var innerExceptions = new AggregateException(addImageException, deleteFromHddException, deleteFromDbException);

				// Ha mind2 törlõ mûvelet sikerült is, eredileg beszúrni akartunk, az nem sikerült ezen a ponton.
				throw new BookteraException(msg, innerExceptions, BookteraExceptionCode.AddImageDeleteIfFailed);
			}
		}
		private static BookteraException AddImageDeleteIfFailed_DeleteFromDb(DBEntities ctx, ref string msg, object userProfile_product_productGroup, bool needSelectUppg)
		{
			var tableName = "[No table name]";

			try
			{
				var userProfile = userProfile_product_productGroup as UserProfile;
				var product = userProfile_product_productGroup as Product;
				var productGroup = userProfile_product_productGroup as ProductGroup;

				if((userProfile != null) || (product != null) || (productGroup != null))
				{
					if(userProfile != null)
					{
						if(needSelectUppg)
						{
							ctx.Entry(userProfile).State = EntityState.Detached;
							userProfile = ctx.UserProfile.Single(up => up.ID == userProfile.ID);
						}
						userProfile.ImageUrl = null;
						tableName = "UserProfile";
					}
					else if(product != null)
					{
						if(needSelectUppg)
						{
							ctx.Entry(product).State = EntityState.Detached;
							product = ctx.Product.Single(p => p.ID == product.ID);
						}
						product.ImageUrl = null;
						tableName = "Product";
					}
					else //if (productGroup != null)
					{
						if(needSelectUppg)
						{
							ctx.Entry(productGroup).State = EntityState.Detached;
							productGroup = ctx.ProductGroup.Single(pg => pg.ID == productGroup.ID);
						}
						productGroup.ImageUrl = null;
						tableName = "ProductGroup";
					}

					ctx.SaveChanges();
					msg += "Sikerült törölni a képet az adatbázisból. ";
				}
				// else{} // Ilyenkor csak az Image táblában szerepelt a kép

				return null;
			}
			catch(Exception ex)
			{
				var msg2 = String.Format("Nem sikerült törölni a képet a {0} táblából. ", tableName);
				msg += msg2;
				return new BookteraException(msg2, ex, BookteraExceptionCode.AddImageDeleteIfFailed_DeleteFromDb);
			}
		}
		private static BookteraException AddImageDeleteIfFailed_DeleteFromHdd(Image image, ref string msg)
		{
			try
			{
				DeleteImageFromDisc(image);

				msg += "Sikerült törölni a képet a háttértárról. ";
				return null;
			}
			catch(BookteraException ex)
			{
				const string msg2 = "Nem sikerült törölni a képet a háttértárról. ";
				msg += msg2;
				return new BookteraException(msg2, ex, BookteraExceptionCode.AddImageDeleteIfFailed_DeleteFromHdd);
			}
		}

		#endregion

		#endregion

		#region READ

		#region GetByID

		public static Image Get(int id)
		{
			using (var ctx = new DBEntities())
			{
				return Get(ctx, id);
			}
		}
		public static Image Get(DBEntities ctx, int id)
		{
			try
			{
				return ctx.Image.Single(p => p.ID == id);
			}
			catch (Exception e)
			{
				var msg = String.Format("Nem található a Image rekord az adatbázisban. ID: {0}. ", id);
				throw new BookteraException(msg, e, BookteraExceptionCode.GetImageById);
			}
		}

		#endregion
	
		#region GetUsersAvatar

		public static string GetUsersAvatar(int userId)
		{
			var userProfile = UserProfileManager.Get(userId);

			if(TestUserImageExist(userProfile.ImageUrl))
				return userProfile.ImageUrl;

			return "default.jpg";
		}

		#endregion

		#endregion

		#region UPDATE

		#region Update

		public static void Update(Image image)
		{
			using (var ctx = new DBEntities())
			{
				Update(ctx, image);
			}
		}

		public static void Update(DBEntities ctx, Image image)
		{
			try
			{
				ctx.SaveChanges();
			}
			catch (Exception e)
			{
				ctx.Entry(image).State = EntityState.Unchanged;
				string msg = string.Format("Nem sikerült a frissíteni a Image rekordot! ID: {0}. ", image.ID);
				throw new BookteraException(msg, e, BookteraExceptionCode.UpdateImage);
			}
		}

		#endregion

		#endregion

		#region DELETE

		#region Delete

		public static void Delete(Image image)
		{
			using (var ctx = new DBEntities())
			{
				Delete(ctx, image);
			}
		}
		public static void Delete(int id)
		{
			using (var ctx = new DBEntities())
			{
				var image = Get(ctx, id);
				Delete(ctx, image);
			}
		}
		public static void Delete(DBEntities ctx, Image image)
		{
			try
			{
				ctx.Image.Remove(image);
				ctx.SaveChanges();
			}
			catch (Exception e)
			{
				ctx.Entry(image).State = EntityState.Unchanged;
				string msg = string.Format("Nem sikerült a Image rekord törlése. ID: {0}. ", image.ID);
				throw new BookteraException(msg, e, BookteraExceptionCode.DeleteImage);
			}
		}

		#endregion

		#endregion


		#region OTHERS

		#region CopyFromProxy

		public static Image CopyFromProxy(Image image)
		{
			bool wasNew;
			AutoMapperInitializer<Image, Image>
				.InitializeIfNeeded(out wasNew, sourceProxy: image)
				.ForMemberIfNeeded(wasNew, image.Property(i => i.ProductGroup), imce => imce.Ignore())
				.ForMemberIfNeeded(wasNew, image.Property(i => i.UserProfile), imce => imce.Ignore())
				.ForMemberIfNeeded(wasNew, image.Property(i => i.Product), imce => imce.Ignore());
			return Mapper.Map<Image>(image);
		}

		#endregion

		#region File System Operations

		#region MoveImageToItsFolder

		public static string MoveImageToItsFolder(string fromFile, object userProfile_product_productGroup, string friendlyUrlForProduct = null)
		{
			string fullPath;
			string imageName;
			BuildImageNameAndPath(out imageName, out fullPath, fromFile, userProfile_product_productGroup, friendlyUrlForProduct);

			File.Move(fromFile, fullPath);

			return imageName;
		}

		#endregion

		#region TakeImageToItsFolder

		public static string TakeImageToItsFolder(Stream stream, string fileName, object userProfile_product_productGroup, string friendlyUrlForProduct = null)
		{
			using (var imageFromStream = System.Drawing.Image.FromStream(stream))
			{
				string extension = Path.GetExtension(fileName);
				CheckExtension(extension);

				string fromFile = Path.GetFileName(fileName);
				string imageName;
				string fullPath;
				BuildImageNameAndPath(out imageName, out fullPath, fromFile, userProfile_product_productGroup, friendlyUrlForProduct);

				imageFromStream.Save(fullPath);
				return imageName;
			}
		}
		private static void CheckExtension(string extension)
		{
			if(!AcceptedImageExtensions.Contains(extension.ToLower()))
			{
				const string msg = "Nem megfelelõ fájl formátum. ";
				throw new BookteraException(msg, code: BookteraExceptionCode.ImageFileExtensionWrong);
			}
		}

		#endregion

		#region CopyImageToItsFolder

		/// <summary>
		/// A kapott UserProfile | Product | ProductGroup -tól függõen átnevezi, és a megfelelõ WEB-es mappába másolja a "fromFile"-t. 
		/// Megj.: Product esetén kitöltendõ a "friendlyUrlForProduct" is, ez benne lesz a file névben.
		/// </summary>
		/// <returns>A képfájl neve</returns>
		public static string CopyImageToItsFolder(string fromFile, object userProfile_product_productGroup, string friendlyUrlForProduct = null)
		{
			string fullPath;
			string imageName;
			BuildImageNameAndPath(out imageName, out fullPath, fromFile, userProfile_product_productGroup, friendlyUrlForProduct);

			File.Copy(fromFile, fullPath);

			return imageName;
		}

		#endregion

		#region BuildImageNameAndPath

		private static void BuildImageNameAndPath(out string imageName, out string fullPath, string fromFile, object userProfile_product_productGroup, string friendlyUrlForProduct = null)
		{
			var userProfile = userProfile_product_productGroup as UserProfile;
			var product = userProfile_product_productGroup as Product;
			var productGroup = userProfile_product_productGroup as ProductGroup;

			if((userProfile == null) && (product == null) && (productGroup == null))
			{
				const string msg = "A \"CopyImageToItsFolder\" függvény a következõk közül pontosan egyet vár: UserProfile | Product | ProductGroup. ";
				throw new BookteraException(msg, code: BookteraExceptionCode.CopyImageToItsFolder_ArgumentParseFailed);
			}

			if((product != null) && (String.IsNullOrWhiteSpace(friendlyUrlForProduct)))
			{
				const string msg = "Product kép áthelyezéséhez kötelezõ megadni \"friendlyUrlForProduct\"-t. ";
				throw new BookteraException(msg, code: BookteraExceptionCode.CopyImageToItsFolder_ArgumentWrong_ProductFriendlyUrl);
			}

			var fileExtension = Path.GetExtension(fromFile);
			var random = new Random(DateTime.Now.Millisecond);
			var prefix = new StringBuilder();
			string toDirectory;

			if(productGroup != null)
			{
				prefix.Append("PG-").Append(productGroup.FriendlyUrl).Append("-");
				toDirectory = Paths.Web_productGroupImagesPath;
			}
			else if(product != null)
			{
				prefix.Append("P-").Append(friendlyUrlForProduct).Append("-");
				toDirectory = Paths.Web_productImagesPath;
			}
			else //if(userProfile != null)
			{
				prefix.Append("U-").Append(userProfile.FriendlyUrl).Append("-");
				toDirectory = Paths.Web_userImagesPath;
			}

			do
			{
				imageName = Path.ChangeExtension(prefix.Append(random.Next(1000000)).ToString(), fileExtension);
				fullPath = Path.Combine(toDirectory, imageName);
			} while(File.Exists(fullPath));
		}

		#endregion

		#region Test...ImageExist (3)

		// Ezek a metódusok ki lettek emelve a Common.dll -be

		public static bool TestProductGroupImageExist(string imageUrl)
		{
			return ImageManagerRelief.TestProductGroupImageExist(imageUrl);
		}
		public static bool TestProductImageExist(string imageUrl)
		{
			return ImageManagerRelief.TestProductImageExist(imageUrl);
		}
		public static bool TestUserImageExist(string imageUrl)
		{
			return ImageManagerRelief.TestUserImageExist(imageUrl);
		}

		#endregion

		#region DeleteImageFromDisc

		public static void DeleteImageFromDisc(Image image)
		{
			try
			{
				string fullPath;
				if(image.UserID != null)
					fullPath = Path.Combine(Paths.Web_userImagesPath, image.Url);
				else if(image.ProductID != null)
					fullPath = Path.Combine(Paths.Web_productImagesPath, image.Url);
				else if(image.ProductGroupID != null)
					fullPath = Path.Combine(Paths.Web_productGroupImagesPath, image.Url);
				else
				{
					const string msg = "Az Image objektum nem tartozik se User-hez, se Product-hoz, se ProductGroup-hoz. ";
					throw new BookteraException(msg, code: BookteraExceptionCode.DeleteImageFromDisc_ImageForeignKeyNotExist);
				}

				if(File.Exists(fullPath))
				{
					File.Delete(fullPath);
				}
				else
				{
					const string msg = "Nem található a képfájl a háttértáron. ";
					throw new BookteraException(msg, code: BookteraExceptionCode.DeleteImageFromDisc_FileNotExist);
				}
			}
			catch(Exception e)
			{
				const string msg = "Nem sikerült törölni a megadott képfájlt a háttértárról. ";
				throw new BookteraException(msg, e, BookteraExceptionCode.DeleteImageFromDisc);
			}
		}

		#endregion

		#region Clear...ImageDirectory, ClearImageDirectories

		public static void ClearImageDirectories()
		{
			ClearProductImageDirectory();
			ClearProductGroupImageDirectory();
			ClearUserImageDirectory();
		}

		public static void ClearProductImageDirectory()
		{
			GeneralFunctions.DeleteDirectoryIfExist(Paths.Web_productImagesPath);

			string defaultImageFrom = Path.Combine(Paths.Test_productImagesPath, "default.jpg");
			string defaultImageTo = Path.Combine(Paths.Web_productImagesPath, "default.jpg");
			File.Copy(defaultImageFrom, defaultImageTo);
		}

		public static void ClearProductGroupImageDirectory()
		{
			GeneralFunctions.DeleteDirectoryIfExist(Paths.Web_productGroupImagesPath);

			string defaultImageFrom = Path.Combine(Paths.Test_productGroupImagesPath, "default.jpg");
			string defaultImageTo = Path.Combine(Paths.Web_productGroupImagesPath, "default.jpg");
			File.Copy(defaultImageFrom, defaultImageTo);
		}

		public static void ClearUserImageDirectory()
		{
			GeneralFunctions.DeleteDirectoryIfExist(Paths.Web_userImagesPath);

			string defaultImageFrom = Path.Combine(Paths.Test_userImagesPath, "default.jpg");
			string defaultImageTo = Path.Combine(Paths.Web_userImagesPath, "default.jpg");
			File.Copy(defaultImageFrom, defaultImageTo);
		}

		#endregion

		#endregion

		#endregion
	}
}
