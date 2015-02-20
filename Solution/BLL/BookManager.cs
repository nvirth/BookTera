using System;
using System.Transactions;
using BLL.EntityManagers;
using CommonModels.Models.EntityFramework;
using CommonModels.Models.ProductModels;
using CommonPortable.Enums;
using CommonPortable.Exceptions;
using DAL.EntityFramework;
using UtilsLocal;
using UtilsLocal.Log;
using UtilsShared;

namespace BLL
{
	public class BookManager
	{
		#region CREATE

		#region UploadProduct

		/// <summary>
		/// - ProductGroup: Vagy visszajön egy ID, vagy egy teljes PG, de ID nélkül
		/// </summary>
		/// <param name="model"></param>
		/// <param name="currentUserId"></param>
		/// <returns></returns>
		public static Product UploadProduct(CreatePVM model, int currentUserId)
		{
			try
			{
				using(var ctx = new DBEntities())
				using(var transactionScope = new TransactionScope())
				{
					var userProfile = UserProfileManager.Get(ctx, currentUserId);
					var productGroup = UploadProduct_ManageProductGroup(ctx, model);
					var product = UploadProduct_BuildProductFromModel(model, userProfile, productGroup.ID);

					ProductManager.Add(ctx, product);
					UploadProduct_ManageImages(ctx, model, product, productGroup);
					UploadProduct_ManageUserProfile(ctx, userProfile);

					transactionScope.Complete();
					return product;
				}
			}
			catch(Exception e)
			{
				const string msg = "Nem sikerült feltölteni a könyvet. ";
				const BookteraExceptionCode code = BookteraExceptionCode.UploadProduct;

				e.AddBookteraExceptionCode(code, msg);
				BookteraLog.ger.LogException(msg, e, model);

				throw;
			}
		}

		/// <summary>
		/// Ha a felhasználó hozza létre a ProductGroup-t, akkor MinPrice == MaxPrice == Product.Price. 
		/// Ha már létezett, akkor frissíti ezeket, és SumOfActiveProductsInGroup++
		/// </summary>
		/// <param name="ctx"></param>
		/// <param name="model"></param>
		/// <returns></returns>
		private static ProductGroup UploadProduct_ManageProductGroup(DBEntities ctx, CreatePVM model)
		{
			ProductGroup productGroup;

			// A felhasználó hozza létre a ProductGroup-t (új)
			if(model.ProductGroup.Id == null)
			{
				productGroup = new ProductGroup(true)
				{
					AuthorNames = model.ProductGroup.AuthorNames,
					CategoryID = model.ProductGroup.CategoryId.HasValue ? model.ProductGroup.CategoryId.Value : -1, // Mindig van itt már éréke, csak így nem warning-os
					Title = model.ProductGroup.Title,
					SubTitle = model.ProductGroup.SubTitle,
					FriendlyUrl = model.ProductGroup.Title.ToFriendlyUrl(),
					ImageUrl = model.ProductGroup.ImageUrl,
					Description = model.ProductGroup.Description,
					MinPrice = model.Product.Price,
					MaxPrice = model.Product.Price,
					PublisherName = model.ProductGroup.PublisherName,
				};

				UploadProductGroup(ctx, productGroup);
			}
			// A felhasználó már létező ProductGroup-t választott
			else
			{
				productGroup = ProductGroupManager.Get(ctx, (int)model.ProductGroup.Id);
				productGroup.SumOfActiveProductsInGroup++;
				productGroup.MinPrice = productGroup.MinPrice > model.Product.Price ? model.Product.Price : productGroup.MinPrice;
				productGroup.MaxPrice = productGroup.MaxPrice < model.Product.Price ? model.Product.Price : productGroup.MaxPrice;
				ctx.SaveChanges();
			}
			return productGroup;
		}
		private static Product UploadProduct_BuildProductFromModel(CreatePVM model, UserProfile userProfile, int productGroupId)
		{
			return new Product(true)
			{
				UserID = userProfile.ID,
				UserName = userProfile.UserName,
				ProductGroupID = productGroupId,
				ImageUrl = model.Product.ImageUrl,
				Language = model.Product.Language,
				Description = model.Product.Description,
				PublishYear = model.Product.PublishYear,
				PageNumber = model.Product.PageNumber,
				Price = model.Product.Price,
				HowMany = model.Product.HowMany,
				Edition = model.Product.Edition,
				IsDownloadable = model.Product.IsDownloadable,
				IsBook = model.Product.IsBook,
				IsAudio = model.Product.IsAudio,
				IsVideo = model.Product.IsVideo,
				IsUsed = model.Product.IsUsed,
				ContainsOther = model.Product.ContainsOther,
			};
		}
		private static void UploadProduct_ManageImages(DBEntities ctx, CreatePVM model, Product product, ProductGroup productGroup)
		{
			// Product Image
			if(model.Product.ImageUrl != null)
			{
				var image = new Image(true)
				{
					ProductID = product.ID,
					Url = model.Product.ImageUrl,
					IsDefault = true
				};
				ImageManager.AddImageDeleteIfFailed(ctx, image, product);
			}
		}
		private static void UploadProduct_ManageUserProfile(DBEntities ctx, UserProfile userProfile)
		{
			// Feltöltött ugye +1 könyvet
			userProfile.SumOfActiveProducts++;

			// Ha eddig csak Leech volt, mostantól Seed
			UserProfileManager.LevelUpUser(ctx, userProfile, UserGroupEnum.Seed, isFree: true, saveChanges: false);

			// A módosításokat egy kérésben küldjük le
			UserProfileManager.Update(ctx, userProfile);
		}

		#endregion

		#region UploadProductGroup

		public static void UploadProductGroup(ProductGroup productGroup)
		{
			using(var transactionScope = new TransactionScope())
			using(var ctx = new DBEntities())
			{
				UploadProductGroup(ctx, productGroup);
				transactionScope.Complete();
			}
		}
		public static void UploadProductGroup(DBEntities ctx, ProductGroup productGroup)
		{
			try
			{
				UploadProductGroup_ManagePublisher(ctx, productGroup);
				UploadProductGroup_ManageAuthor(ctx, productGroup);
				ProductGroupManager.Add(ctx, productGroup);
				UploadProductGroup_ManageImage(ctx, productGroup);
			}
			catch(Exception e)
			{
				const string msg = "Nem sikerült a ProductGroup létrehozása. ";
				const BookteraExceptionCode code = BookteraExceptionCode.UploadProductGroup;

				e.AddData(productGroup);
				e.AddBookteraExceptionCode(code, msg);

				throw;
			}
		}

		/// <summary>
		/// Először megpróbálja beszúrni a Publisher rekordot. 
		/// Aztán ha nem ment, akkor megpróbálja lekérni (az esetek nagy részében úgyis már létezett)
		/// Végül beállítja a productGroup.PublisherID-t
		/// </summary>
		private static void UploadProductGroup_ManagePublisher(DBEntities ctx, ProductGroup productGroup)
		{
			Publisher publisher = null;
			int publisherId;
			var publisherFriendlyUrl = productGroup.PublisherName.ToFriendlyUrl();

			try
			{
				publisher = new Publisher(true)
				{
					DisplayName = productGroup.PublisherName,
					FriendlyUrl = publisherFriendlyUrl,
				};
				PublisherManager.Add(ctx, publisher);
				publisherId = publisher.ID;
			}
			catch(BookteraException e)
			{
				try
				{
					// Az esetek nagy részében már létezik a rekord. Ilyenkor megszüntetjük a beszúrási szándékot
					// és megpróbáljuk lekérni a rekordot. Ha ez sikerül, akkor tényleg így volt
					//ctx.Entry(publisher).State = EntityState.Detached;
					publisher = PublisherManager.Get(ctx, publisherFriendlyUrl);
					publisherId = publisher.ID;
				}
				catch(Exception ex)
				{
					const BookteraExceptionCode code = BookteraExceptionCode.UploadProductGroup_ManagePublisher;
					const string msg = "Nem található a Publisher az adatbázisban, és nem is sikerült beszúrni új rekordként. ";

					ex.AddBookteraExceptionCode(code, msg);
					ex.AddData("PublisherName", productGroup.PublisherName);

					throw;
				}
			}
			productGroup.PublisherID = publisherId;
		}

		/// <summary>
		/// Végigmegy a productGruop.Author mezőben vesszővel felsorolt Author-neveken. 
		/// Először megpróbálja őket beszúrni. 
		/// Aztán ha nem ment, akkor megpróbálja lekérni (az esetek nagy részében úgyis már létezett). 
		/// </summary>
		private static void UploadProductGroup_ManageAuthor(DBEntities ctx, ProductGroup productGroup)
		{
			string[] authors = productGroup.AuthorNames.Split(new char[] { ',' });
			int numOfGoods = 0;
			foreach(string authorNameNT in authors)
			{
				var authorName = authorNameNT.Trim();
				if(!string.IsNullOrWhiteSpace(authorName))
				{
					numOfGoods++;
					var authorFriendlyUrl = authorName.ToFriendlyUrl();

					try
					{
						var author = new Author(true)
						{
							DisplayName = authorName,
							FriendlyUrl = authorFriendlyUrl,
						};
						AuthorManager.Add(ctx, author);

						// Kapcsolótábla frissítése
						productGroup.Authors.Add(author);
					}
					catch(BookteraException e)
					{
						try
						{
							// Az esetek nagy részében már létezik a rekord. Ilyenkor megszüntetjük a beszúrási szándékot
							// és megpróbáljuk lekérni a rekordot. Ha ez sikerül, akkor tényleg így volt
							//ctx.Entry(author).State = EntityState.Detached;
							AuthorManager.Get(ctx, authorFriendlyUrl);
						}
						catch(Exception ex)
						{
							const BookteraExceptionCode code = BookteraExceptionCode.UploadProductGroup_ManageAuthor;
							const string msg = "Nem található az Author az adatbázisban, és nem is sikerült beszúrni új rekordként. ";

							ex.AddBookteraExceptionCode(code, msg);
							ex.AddData("AuthorName", authorName);

							throw;
						}
					}
				}
			}
			if(numOfGoods == 0)
			{
				var msg = string.Format("A feltöltött könyvhöz ({0}) valójában nem adtak meg Authort (AuthorNames: {1})", productGroup.Title, productGroup.AuthorNames);
				throw new BookteraException(msg, code: BookteraExceptionCode.UploadProductGroup_ManageAuthor_NoAuthors);
			}
		}
		private static void UploadProductGroup_ManageImage(DBEntities ctx, ProductGroup productGroup)
		{
			var image = new Image(true)
			{
				IsDefault = true,
				ProductGroupID = productGroup.ID,
				Url = productGroup.ImageUrl
			};
			ImageManager.AddImageDeleteIfFailed(ctx, image, productGroup);
		}

		#endregion

		#endregion
	}
}
