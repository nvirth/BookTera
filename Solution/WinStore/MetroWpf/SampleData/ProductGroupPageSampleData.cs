using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonPortable.Models.ProductModels;
using WinStoreClientProxy;
using WinStoreClientProxy.ModelsObservable.ProductModelsObservable;

namespace MetroWpf.SampleData
{
	public class ProductGroupPageSampleData
	{
		private const string ProductGroupFu = "Sub-Rosa";

		public BookRowPLVM BookRowPlvm { get; set; }

		public ProductGroupPageSampleData()
		{
			Task.Run(
				async () =>
				{
					BookRowPlvm = await ProductGroupManager.GetFullDetailedAsync(ProductGroupFu, 1, 100);
				}).Wait();
		}
	}
}
