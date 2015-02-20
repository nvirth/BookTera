using System;
using System.Collections.Generic;
using System.Linq;
using CommonModels.Methods.ManagerRelief;
using CommonModels.Models;
using CommonModels.Models.EntityFramework;
using CommonModels.Models.ProductModels;
using CommonPortable.Models;
using CommonPortable.Models.ProductModels;
using UtilsShared;
using UtilsSharedPortable;

namespace BLL.ModelManagers.ProductModelManagers
{
	public static class BookRowPlvmManager
	{
		public static BookRowPLVM DoConsturctorWork(this BookRowPLVM instance, ProductGroup productGroup, int pageNumber, int productsPerPage)
		{
			if(instance == null)
				instance = new BookRowPLVM();
				
			instance.ProductGroup = new BookRowPLVM.ProductGroupVM().DoConsturctorWork(productGroup);
			var productsInGroup = productGroup.ProductsInGroup;

			instance.Paging = new Paging().DoConsturctorWork(productsInGroup.Count, pageNumber, productsPerPage);

			instance.ProductsInGroup = new List<BookRowPLVM.ProductVM>();
			if(pageNumber <= instance.Paging.NumberOfPages) // Ha esetleg átírnák a query string-et, és túllapoznák
			{
				var productsPaged = productsInGroup.Skip((pageNumber - 1) * productsPerPage).Take(productsPerPage);
				foreach(var product in productsPaged)
				{
					instance.ProductsInGroup.Add(new BookRowPLVM.ProductVM().DoConsturctorWork(product));
				}
			}

			return instance;
		}

		public static BookRowPLVM.ProductVM DoConsturctorWork(this BookRowPLVM.ProductVM instance, Product product)
		{
			if(instance == null)
				instance = new BookRowPLVM.ProductVM();

			instance.ID = product.ID;
			instance.Language = product.Language;
			instance.Description = product.Description;
			instance.PublishYear = product.PublishYear;
			instance.PageNumber = product.PageNumber;
			instance.PriceString = product.Price.ToString("c0", Constants.CultureInfoHu);
			instance.HowMany = product.HowMany;
			instance.Edition = product.Edition;
			instance.IsBook = product.IsBook;
			instance.IsAudio = product.IsAudio;
			instance.IsVideo = product.IsVideo;
			instance.IsUsed = product.IsUsed;
			instance.IsDownloadable = product.IsDownloadable;

			instance.UserName = product.UserName;
			instance.UserFriendlyUrl = instance.UserName.ToFriendlyUrl();

			instance.Images = new List<string>();
			if(product.ImageUrl != null)
				instance.Images.Add(product.ImageUrl);	// default, first

			foreach(var image in product.Images)
			{
				if((image.Url != product.ImageUrl)
				&& (ImageManagerRelief.TestProductImageExist(image.Url)))
					instance.Images.Add(image.Url);
			}
			if(instance.Images.Count == 0)
				instance.Images.Add("default.jpg");

			return instance;
		}

		public static BookRowPLVM.ProductGroupVM DoConsturctorWork(this BookRowPLVM.ProductGroupVM instance, ProductGroup productGroup)
		{
			if(instance == null)
				instance = new BookRowPLVM.ProductGroupVM();

			instance.Title = productGroup.Title;
			instance.SubTitle = productGroup.SubTitle;
			instance.FriendlyUrl = productGroup.FriendlyUrl;
			instance.Description = productGroup.Description;
			instance.SumOfActiveProductsInGroup = productGroup.SumOfActiveProductsInGroup;
			instance.SumOfPassiveProductsInGroup = productGroup.SumOfPassiveProductsInGroup;
			instance.SumOfBuys = productGroup.SumOfBuys;
			instance.AuthorNames = productGroup.AuthorNames;
			instance.PublisherName = productGroup.PublisherName;

			// Rating
			instance.SumOfRatings = productGroup.SumOfRatings;
			instance.RatingPoints = instance.SumOfRatings == 0 ? 0 : (int)Math.Round((productGroup.SumOfRatingsValue / (float)instance.SumOfRatings) * 2);

			// PriceString
			if(productGroup.MinPrice == productGroup.MaxPrice)
			{
				instance.PriceString = productGroup.MinPrice.ToString("c0", Constants.CultureInfoHu);
			}
			else
			{
				var minPriceString = productGroup.MinPrice.ToString("c0", Constants.CultureInfoHu);
				var maxPriceString = productGroup.MaxPrice.ToString("c0", Constants.CultureInfoHu);
				instance.PriceString = string.Format("{0} - {1}", minPriceString, maxPriceString);
			}

			// Image
			instance.ImageUrl = productGroup.ImageUrl;
			if(!ImageManagerRelief.TestProductGroupImageExist(productGroup.ImageUrl))
				instance.ImageUrl = "default.jpg";

			// Category
			var category = productGroup.Category;
			instance.CategoryFullPath = category.FullPath;
			instance.CategoryFriendlyUrl = category.FriendlyUrl;

			return instance;
		}
	}
}
