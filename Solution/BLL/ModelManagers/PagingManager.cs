using System;
using CommonModels.Models;
using CommonPortable.Models;

namespace BLL.ModelManagers
{
	public static class PagingManager
	{
		public static Paging DoConsturctorWork(this Paging instance, int numberOfProducts, int actualPageNumber, int productsPerPage)
		{
			if(instance == null)
				instance = new Paging();
				
			instance.NumberOfProducts = numberOfProducts;
			instance.ActualPageNumber = actualPageNumber;
			instance.ProductsPerPage = productsPerPage;
			CalculateNumberOfPages(instance);

			return instance;
		}

		public static void CalculateNumberOfPages(this Paging instance)
		{
			if(instance.ProductsPerPage != 0)
				instance.NumberOfPages = (int)Math.Ceiling(instance.NumberOfProducts / (double)instance.ProductsPerPage);
		}
	}
}
