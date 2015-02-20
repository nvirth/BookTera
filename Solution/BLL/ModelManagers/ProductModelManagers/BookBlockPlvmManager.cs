using System;
using System.Collections.Generic;
using System.Linq;
using CommonModels.Models;
using CommonModels.Models.EntityFramework;
using CommonModels.Models.ProductModels;
using CommonPortable.Enums;
using CommonPortable.Exceptions;
using CommonPortable.Models;
using CommonPortable.Models.ProductModels;
using UtilsLocal;

namespace BLL.ModelManagers.ProductModelManagers
{
	public static class BookBlockPlvmManager
	{
		/// <summary>
		///  Három féle BookBlockType-hoz hozza létre a lapozható könyvlistát:
		///		Product
		///		ProductGroup
		///		ProductForExchange
		/// </summary>
		public static BookBlockPLVM DoConsturctorWork(this BookBlockPLVM instance, int pageNumber, int productsPerPage, IQueryable<Object> productsOrProductGroups, int numberOfProducts = -1, bool isForExchange = false, bool needCategory = false)
		{
			if(instance == null)
				instance = new BookBlockPLVM();

			// Paging

			if(numberOfProducts == -1)
				numberOfProducts = productsOrProductGroups.Count();

			instance.Paging = new Paging().DoConsturctorWork(numberOfProducts, pageNumber, productsPerPage);

			// Products

			instance.Products = new List<InBookBlockPVM>();
			if(pageNumber <= instance.Paging.NumberOfPages) // Ha esetleg átírnák a query string-et, és túllapoznák
			{
				var productsPaged = productsOrProductGroups.Skip((pageNumber - 1) * productsPerPage).Take(productsPerPage);
				var ranOutProducts = new List<InBookBlockPVM>();
				foreach(var p in productsPaged)
				{
					InBookBlockPVM inBookBlock;
					var product = p as Product;
					var productGroup = p as ProductGroup;

					if(product != null)
						inBookBlock = new InBookBlockPVM().DoConsturctorWork(product: product);
					else if(productGroup != null)
						inBookBlock = new InBookBlockPVM().DoConsturctorWork(productGroup: productGroup, needCategory: needCategory);
					else
						throw new BookteraException("A \"BookBlockPLVM\" konstruktora egy Product vagy ProductGroup listát vár. ", code: BookteraExceptionCode.BookBlockPLVM_CtorArgumentWrong);

					if(inBookBlock.Product.HowMany == 0)
						ranOutProducts.Add(inBookBlock);
					else
						instance.Products.Add(inBookBlock);
				}

				bool firstIsProduct = (productsPaged.FirstOrDefault() as Product) != null;
				instance.BookBlockType = firstIsProduct ? BookBlockType.Product : BookBlockType.ProductGroup;

				// Az elfogyottakat a végére tesszük
				instance.Products.AddRange(ranOutProducts);
			}

			instance.BookBlockType = isForExchange ? BookBlockType.ProductForExchange : instance.BookBlockType;

			return instance;
		}

		public static void AddProductsToList(this BookBlockPLVM instance, IEnumerable<Product> products)
		{
			foreach(var product in products)
				instance.Products.Add(new InBookBlockPVM().DoConsturctorWork(product));

			instance.Paging.NumberOfProducts = instance.Products.Count;
			instance.Paging.CalculateNumberOfPages();
		}
	}
}
