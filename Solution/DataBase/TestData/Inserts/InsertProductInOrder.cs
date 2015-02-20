using System;
using System.Collections.Generic;
using CommonModels.Models.EntityFramework;
using DAL.EntityFramework;

namespace ebookTestData.Inserts
{
	internal class InsertProductInOrder : Insert
	{
		private List<ProductInOrder> productsInOrders;

		protected override sealed void Start()
		{
			using(var ctx = new DBEntities())
			{
				productsInOrders = new List<ProductInOrder>();

				foreach(UserOrder userOrder in ctx.UserOrder)
				{
					// Egy rendelésben egy product csak 1x szerepelhet
					List<Product> productsTmp = new List<Product>(ctx.Product);

					// Hány különbözõ termék van a kosárban
					// 1% 4+, ~4% 2-4, ~5% 2, ~90% 1
					int max = Random.Next(100) < 90 ? 1 : 2;
					max = Random.Next(100) < 95 ? max : Random.Next(2, 5);
					max = Random.Next(100) < 99 ? max : Random.Next(5, 50);
					for(int j = 0; j < max; j++)
					{
						// Egy termékbõl mennyit vesz
						int howMany = Random.Next(100) < 90 ? 1 : 2;
						howMany = Random.Next(100) < 99 ? howMany : Random.Next(3, 100);

						// Keresünk egy Product-ot, ami benne lehet a rendelésben
						Product product;
						int idx = Random.Next(productsTmp.Count);
						int countOfCycles = 0;
						bool cantBeInThisOrder = false;
						do
						{
							idx++;
							product = productsTmp[idx % productsTmp.Count];
							countOfCycles++;
							cantBeInThisOrder = (countOfCycles > productsTmp.Count)
												|| productsTmp.Count == 0;
						} while(!(userOrder.Date > product.UploadedDate)
								 && !cantBeInThisOrder);

						// Ha találtunk Product-ot, ami benne lehet a rendelésben
						if(!cantBeInThisOrder)
						{
							productsInOrders.Add(new ProductInOrder(true)
							{
								ProductID = product.ID,
								UserOrderID = userOrder.ID,
								HowMany = howMany
							});
							// Kivesszük a listából a felhasznált product-ot
							productsTmp.RemoveAt(idx % productsTmp.Count);
							//x productsTmp.Remove(product);
						}
					}
				}
			}
		}

		protected void ExecuteInDB()
		{
			using(var ctx = new DBEntities())
			{
				foreach (var productInOrder in productsInOrders)
				{
					// Stored Procedure
					//ctx.AddProductInOrder(productInOrder.ProductID, productInOrder.UserOrderID, productInOrder.HowMany);
					throw new NotImplementedException();
				}
				ctx.SaveChanges();
			}
		}
	}
}
