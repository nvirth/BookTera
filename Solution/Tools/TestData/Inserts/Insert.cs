using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using CommonPortable.Enums;
using UtilsLocal;
using UtilsSharedPortable;

namespace ebookTestData.Inserts
{
	abstract class Insert
	{
		protected readonly Random Random;

		protected static readonly ReadOnlyCollection<BookteraExceptionCode> goodExceptionCodes =
			new ReadOnlyCollection<BookteraExceptionCode>(
				new List<BookteraExceptionCode>()
				{
					BookteraExceptionCode.CheckExistEnoughToBuy_NotEnoughProducts,
					BookteraExceptionCode.AddProductToCart_CreateOrUpdatePio_DownloadableProduct,
					BookteraExceptionCode.CheckExistEnoughToBuy_NotEnoughProducts,
				});

		protected static readonly ReadOnlyCollection<BookteraExceptionCode> neutralExceptionCodes =
			new ReadOnlyCollection<BookteraExceptionCode>(
				new List<BookteraExceptionCode>()
			{
				BookteraExceptionCode.None,
				BookteraExceptionCode.AddProductToCart,
				BookteraExceptionCode.RegisterUser_SuccesfulWithSomeProblems,
				BookteraExceptionCode.UpdateProductInCart,
			});

		protected Insert()
		{
			Random = new Random(DateTime.Now.Millisecond);

			// A Start() metódusban van a lényeg, csak közben időt mérünk
			Action start = Start;
			start.ExecuteWithTimeMeasuring(this.GetType().Name);
		}

		protected abstract void Start();
	}
}
