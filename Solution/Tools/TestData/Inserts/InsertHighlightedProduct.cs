using System;
using System.Collections.Generic;
using System.Linq;
using CommonModels.Models.EntityFramework;
using DAL.EntityFramework;
using UtilsShared;
using GeneralFunctions = UtilsSharedPortable.GeneralFunctions;

namespace ebookTestData.Inserts
{
	internal class InsertHighlightedProduct : Insert
	{
		private List<HighlightedProduct> highlightedProducts;

		protected override sealed void Start()
		{
			using(var ctx = new DBEntities())
			{
				highlightedProducts = new List<HighlightedProduct>();

				int[] highlightTypeIDs = (from hp in ctx.HighlightType
										  select hp.ID).ToArray();

				var usersJoinWithProducts =
					(from p in ctx.Product
					 join u in ctx.UserProfile on p.UserID equals u.ID
					 select new
					 {
						 productId = p.ID,
						 minDate = p.UploadedDate,
						 maxDate = u.LastLoginDate
					 }).ToArray();

				// Az i átlagban 10-zel nõ körönként, csak véletlenszerûen
				for(int i = 0; i < usersJoinWithProducts.Length; i = i + Random.Next(1, 20))
				{
					var uap = usersJoinWithProducts[i];

					int highlightedTypeID = highlightTypeIDs[Random.Next(highlightTypeIDs.Length)];
					DateTime fromDate = GeneralFunctions.GetRandomDateTimeBetween(uap.minDate, uap.maxDate);
					DateTime toDate = fromDate.AddDays(Random.Next(3, 30));
					toDate = toDate > DateTime.Now ? DateTime.Now : toDate;

					highlightedProducts.Add(new HighlightedProduct(true)
					{
						ProductID = uap.productId,
						FromDate = fromDate,
						ToDate = toDate,
						HighlightTypeID = highlightedTypeID
					});

					// Hogy a fõoldalon legyenek tesztadatok
					if(highlightedTypeID != 1)
					{
						toDate = DateTime.Now.AddDays(Random.Next(3, 30));

						highlightedProducts.Add(new HighlightedProduct(true)
						{
							ProductID = uap.productId,
							FromDate = fromDate,
							ToDate = toDate,
							HighlightTypeID = 1
						});
					}
				}
			}
		}

		protected void ExecuteInDB()
		{
			using(var ctx = new DBEntities())
			{
				foreach (var hp in highlightedProducts)
				{
					ctx.HighlightedProduct.Add(hp);
				}
				ctx.SaveChanges();
			}
		}
	}
}
