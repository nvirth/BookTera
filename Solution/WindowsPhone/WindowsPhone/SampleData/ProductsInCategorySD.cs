using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Threading.Tasks;
using WindowsPhone.SampleData.Base;
using WinPhoneClientProxy.ProductManagerService;
using Newtonsoft.Json;

namespace WindowsPhone.SampleData
{
	public class ProductsInCategorySD : Helpers
	{
		public InCategoryPLVM Products { get; set; }

		public ProductsInCategorySD()
		{
			string readToEnd;

			try
			{
				// Case for: Offline Device
				using(var streamReader = new StreamReader(SampleDataRootOnWP + "ProductsInCategorySD.json"))
				{
					readToEnd = streamReader.ReadToEnd();
				}
			}
			catch(Exception e)
			{
				// Case for: Designer
				using(var streamReader = new StreamReader(SampleDataRootOnPC + "ProductsInCategorySD.json"))
				{
					readToEnd = streamReader.ReadToEnd();
				}
			}

			Products = JsonConvert.DeserializeObject<InCategoryPLVM>(readToEnd);
		}
	}
}
