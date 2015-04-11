using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using BLL;
using BLL.EntityManagers;
using CommonModels.Models.EntityFramework;
using CommonModels.Models.ProductModels;
using CommonPortable.Enums;
using DAL.EntityFramework;
using ebookTestData.HelperClasses;
using ebookTestData.Get;
using UtilsLocal;
using UtilsShared;
using GeneralFunctions = UtilsSharedPortable.GeneralFunctions;

namespace ebookTestData.Inserts
{
	internal class UploadProduct : Insert
	{
		#region ResourceProperties

		private string[] languages;
		private string[] productDescriptions;
		private UserProfile[] userProfiles;
		private IEnumerable<ProductResource> productResources;
		private int[] highlightTypeIds;

		#endregion

		protected override sealed void Start()
		{
			using(var ctx = new DBEntities())
			{
				SetResourceProperties(ctx);
				UploadTheProducts(ctx);
				CorrectTestData(ctx);
			}
		}

		#region Privates

		#region Main Functions

		private void SetResourceProperties(DBEntities ctx)
		{
			productResources = GetResources.GetProductResources();
			userProfiles = ctx.UserProfile.ToArray();
			languages = GetResources.GetLanguages();
			productDescriptions = GetResources.GetProductDescriptions();
			highlightTypeIds = Enum.GetValues(typeof(HighlightTypeEnum)).Cast<HighlightTypeEnum>().Where(hte => hte != HighlightTypeEnum.Nincs).Select(hte => (int)hte).ToArray();
		}

		private void UploadTheProducts(DBEntities ctx)
		{
			foreach(ProductResource productResource in productResources)
			{
				// Elõször ID nélkül, hogy beszúrja
				var productGroup = BuildProductGroupWithoutId(productResource);

				int to = Random.Next(100) < 70 ? 1 : Random.Next(100) < 70 ? Random.Next(2, 5) : Random.Next(5, 20);
				for(int i = 0; i < to; i++)
				{
					var product = BuildProduct(productResource);
					var productCreateViewModel = BuildProductCreateViewModel(productGroup, product);
					var currentUserId = GetCurrentUserId();

					try
					{
						BookManager.UploadProduct(productCreateViewModel, currentUserId);
					}
					catch(Exception e)
					{
						e.WriteWithInnerMessagesColorful(goodExceptionCodes, neutralExceptionCodes);
					}

					// A 2. körtõl a már meglévõ PG alá pakolja a P-ket
					productGroup.Id = ctx.ProductGroup.OrderByDescending(pg => pg.ID).First().ID;
				}
			}
		}

		private void CorrectTestData(DBEntities ctx)
		{
			foreach(var productGroup in ctx.ProductGroup)
			{
				var productsInGroup = productGroup.ProductsInGroup.OrderBy(p => p.ID);
				var firstProduct = productsInGroup.First();
				var userProfile = firstProduct.UserProfile;

				// A ProductGroup feltöltési dátuma a User regisztrációja és utolsó belépése közötti
				productGroup.UploadedDate = GeneralFunctions.GetRandomDateTimeBetween(userProfile.RegistrationDate, userProfile.LastLoginDate);

				foreach(var product in productsInGroup)
				{
					// Az 1. P a PG-ben ugyanakkor szúródott be, mint a PG; a többi késõbb, de a User utolsó belépése elõtt
					if(product.ID == firstProduct.ID)
						product.UploadedDate = productGroup.UploadedDate;
					else
						product.UploadedDate = GeneralFunctions.GetRandomDateTimeBetween(productGroup.UploadedDate, userProfile.LastLoginDate);

					// A Highlight-ok kezdõdátuma a Product feltöltési dátuma, végdátuma pedig annál nagyobb
					int productId = product.ID;
					var highlightedProducts = ctx.HighlightedProduct.Where(hp => hp.ProductID == productId);
					foreach(var highlightedProduct in highlightedProducts)
					{
						highlightedProduct.FromDate = product.UploadedDate;
						highlightedProduct.ToDate = highlightedProduct.FromDate.AddDays(Random.Next(7, 31));
					}
				}
			}
			ctx.SaveChanges();
		}

		#endregion

		private int GetCurrentUserId()
		{
			int idx = Random.Next(0, userProfiles.Length);
			return userProfiles[idx].ID;
		}

		private CreatePVM BuildProductCreateViewModel(CreatePVM.ProductGroupVM productGroupVm, CreatePVM.ProductVM productVm)
		{
			return new CreatePVM()
			{
				ProductGroup = productGroupVm,
				Product = productVm
			};
		}

		/// <summary>
		/// Elsõ alkalommal ID nélkül hozzuk létre a ProductGroup-ot, hogy beszúrja a DB-be.
		/// </summary>
		/// <param name="productResource"></param>
		/// <returns></returns>
		private CreatePVM.ProductGroupVM BuildProductGroupWithoutId(ProductResource productResource)
		{
			// Image kezelése

			// Kamu példány a képhez
			var productGroup = new ProductGroup(false)
			{
				FriendlyUrl = productResource.Title.ToFriendlyUrl()
			};

			var inImageUrl = Path.Combine(Paths.Test_productImagesPath, productResource.ImageUrl);
			var imageUrl = ImageManager.CopyImageToItsFolder(inImageUrl, productGroup);

			return new CreatePVM.ProductGroupVM()
			{
				PublisherName = productResource.PublisherName,
				CategoryId = productResource.CategoryId,
				Title = productResource.Title,
				SubTitle = productResource.SubTitle,
				AuthorNames = productResource.Authors,
				ImageUrl = imageUrl,
				Description = productResource.Description,
			};
		}

		private CreatePVM.ProductVM BuildProduct(ProductResource productResource)
		{
			// 90%-ban magyar, 8%-ban angol, 2%-ban egyéb nyelvûek a könyvek
			int idx = Random.Next(100) < 90 ? 0 : (Random.Next(100) < 80 ? 1 : (Random.Next(2, languages.Length)));
			var language = languages[idx];

			// 90%-ban elsõ, 8%-ban 2-6. és 2%-ban 7-19. kiadásúak a könyvek
			int edition = Random.Next(100) < 90 ? 1 : (Random.Next(100) < 80 ? Random.Next(2, 7) : Random.Next(7, 20));

			// 70%-ban használtak a köynvek
			var isUsed = Random.Next(100) < 70;

			// 70%-ban fizikaiak a köynvek, 30%-ban elektronikusak (letölthetõk)
			var isDownloadable = (Random.Next(100) < 30) && !isUsed;

			//TODO: könyvesboltok, szerzõk, kiadók mivoltának figyelembe vétele (?)
			// Könyvek mennyisége: csak ha fizikai (70%), ennek 80%-a (össz 56%) 1 db, maradék fele 2-3db, fele 4-99db (pl könyvesbolt)
			int howMany = 1;
			if(!isDownloadable)
				howMany = Random.Next(100) < 80 ? 1 : (Random.Next(100) < 50 ? Random.Next(2, 4) : Random.Next(4, 100));

			// 90% könyv, 10% hangoskönyv, 3% videó
			var isBook = Random.Next(100) < 90;
			var isAudio = Random.Next(100) < 10;
			var isVideo = !isBook && !isAudio;

			// 3% tartalmaz plusz dolgokat
			var containsOther = Random.Next(100) < 3;

			// 80%-120% közötti árak
			var price = (int)(productResource.Price * ((double)Random.Next(80, 120)) / 100);

			// Image kezelése
			string imageUrl = null;
			if((Random.Next(100) < 85) && (!isDownloadable))
			{
				// Kamu példány a képhez
				var product = new Product(false);

				var inImageUrl = Path.Combine(Paths.Test_productImagesPath, productResource.ImageUrl);
				var forImageName = productResource.Title.ToFriendlyUrl();
				imageUrl = ImageManager.CopyImageToItsFolder(inImageUrl, product, forImageName);
			}

			return new CreatePVM.ProductVM()
			{
				ImageUrl = imageUrl,
				Language = language,
				Description = productDescriptions[Random.Next(0, productDescriptions.Length)],
				PublishYear = productResource.PublishYear,
				Price = price,
				IsDownloadable = isDownloadable,
				IsBook = isBook,
				IsAudio = isAudio,
				IsVideo = isVideo,
				IsUsed = isUsed,
				ContainsOther = containsOther,
				HowMany = howMany,
				Edition = edition,
				PageNumber = productResource.PageNumber,
			};
		}

		#endregion
	}
}