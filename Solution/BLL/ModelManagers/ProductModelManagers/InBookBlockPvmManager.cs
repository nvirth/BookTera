using System;
using CommonModels.Methods.ManagerRelief;
using CommonModels.Models.EntityFramework;
using CommonModels.Models.ProductModels;
using CommonPortable.Enums;
using CommonPortable.Exceptions;
using CommonPortable.Models.ProductModels;
using UtilsLocal;
using UtilsShared;
using UtilsSharedPortable;

namespace BLL.ModelManagers.ProductModelManagers
{
	public static class InBookBlockPvmManager
	{
		/// <summary>
		///	Ha meg van adva Product, "Product"-os BookBlock lesz
		///	Ha nincs megadva Product, "ProductGroup"-os
		/// Ha a needCategory true, a ProductGroup a Category adatokat is tartalmazza majd (+1 lekérdezés)
		/// </summary>
		public static InBookBlockPVM DoConsturctorWork(this InBookBlockPVM instance, Product product = null, ProductGroup productGroup = null, bool needCategory = false)
		{
			if(instance == null)
				instance = new InBookBlockPVM();

			if((product == null) && (productGroup == null))
			{
				const string msg = "A \"InBookBlockPVM\" osztály konstruktora a következők közül legalább az egyiket kéri: Product | ProductGroup. ";
				throw new BookteraException(msg, code: BookteraExceptionCode.InBookBlockPVM_CtorArgumentWrong);
			}

			instance.Product = product == null
				? new InBookBlockPVM.ProductVM().DoConsturctorWork(productGroup)
				: new InBookBlockPVM.ProductVM().DoConsturctorWork(product);

			instance.ProductGroup = new InBookBlockPVM.ProductGroupVM()
				.DoConsturctorWork(productGroup ?? product.ProductGroup, needCategory);

			return instance;
		}

		/// <summary>
		/// CartItem, InProgressOrderItem vagy ProductOnlyToList BookBlockType-ú view model-t készít
		/// </summary>
		public static InBookBlockPVM DoConsturctorWork(this InBookBlockPVM instance, Product product, ProductInOrder productInOrder)
		{
			if(instance == null)
				instance = new InBookBlockPVM();

			instance.DoConsturctorWork(product); // this call in ctr

			instance.Product.HowMany = productInOrder.HowMany;
			instance.Product.PriceString = productInOrder.UnitPrice.ToString("c0", Constants.CultureInfoHu);
			instance.Product.ProductInOrderId = productInOrder.ID;

			return instance;
		}

		public static InBookBlockPVM.ProductVM DoConsturctorWork(this InBookBlockPVM.ProductVM instance, Product product)
		{
			if(instance == null)
				instance = new InBookBlockPVM.ProductVM();

			// Null-like property values
			instance.ProductInOrderId = -1;

			instance.ID = product.ID;
			instance.ImageUrl = product.ImageUrl;
			instance.PriceString = product.Price.ToString("c0", Constants.CultureInfoHu);
			instance.HowMany = product.HowMany;
			instance.Description = product.Description;
			instance.IsDownloadable = product.IsDownloadable;
			instance.UserName = product.UserName;
			instance.UserFriendlyUrl = instance.UserName.ToFriendlyUrl();

			if(!ImageManagerRelief.TestProductImageExist(product.ImageUrl))
				instance.ImageUrl = null;

			return instance;
		}

		public static InBookBlockPVM.ProductVM DoConsturctorWork(this InBookBlockPVM.ProductVM instance, ProductGroup productGroup)
		{
			if(instance == null)
				instance = new InBookBlockPVM.ProductVM();

			// Null-like property values
			instance.ID = -1;
			instance.HowMany = -1;
			instance.UserName = null;
			instance.Description = null;
			instance.IsDownloadable = false;
			instance.ProductInOrderId = -1;

			instance.ImageUrl = productGroup.ImageUrl;

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

			if(!ImageManagerRelief.TestProductGroupImageExist(productGroup.ImageUrl))
				instance.ImageUrl = null;

			return instance;
		}

		public static InBookBlockPVM.ProductGroupVM DoConsturctorWork(this InBookBlockPVM.ProductGroupVM instance, ProductGroup productGroup, bool needCategory = false)
		{
			if(instance == null)
				instance = new InBookBlockPVM.ProductGroupVM();

			instance.Title = productGroup.Title;
			instance.SubTitle = productGroup.SubTitle;
			instance.FriendlyUrl = productGroup.FriendlyUrl;
			instance.ImageUrl = productGroup.ImageUrl;
			instance.Description = productGroup.Description;
			instance.IsCheckedByAdmin = productGroup.IsCheckedByAdmin;
			instance.SumOfRatings = productGroup.SumOfRatings;
			instance.AuthorNames = productGroup.AuthorNames;
			instance.PublisherName = productGroup.PublisherName;

			if(needCategory)
			{
				var category = productGroup.Category;
				instance.CategoryFullPath = category.FullPath;
				instance.CategoryFriendlyUrl = category.FriendlyUrl;
			}

			if(!ImageManagerRelief.TestProductGroupImageExist(productGroup.ImageUrl))
				instance.ImageUrl = "default.jpg";

			instance.RatingPoints = instance.SumOfRatings == 0 ? 0 : (int)Math.Round((productGroup.SumOfRatingsValue / (float)instance.SumOfRatings) * 2);

			return instance;
		}
	}
}
