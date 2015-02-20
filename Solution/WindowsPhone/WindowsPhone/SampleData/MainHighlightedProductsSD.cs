using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Threading.Tasks;
using WindowsPhone.SampleData.Base;
using WinPhoneClientProxy.ProductManagerService;
using Newtonsoft.Json;

namespace WindowsPhone.SampleData
{
	public class MainHighlightedProductsSD : Helpers
	{
		#region MainHighlightedProducts

		public BookBlockPLVM MainHighlightedProducts{ get; set; }

		#endregion
		
		public MainHighlightedProductsSD()
		{
			string readToEnd;

			try
			{
				// Case for: Offline Device
				using(var streamReader = new StreamReader(SampleDataRootOnWP + "MainHighlightedProductsSD.json"))
				{
					readToEnd = streamReader.ReadToEnd();
				}
			}
			catch (Exception e)
			{
				// Case for: Designer
				using(var streamReader = new StreamReader(SampleDataRootOnPC + "MainHighlightedProductsSD.json"))
				{
					readToEnd = streamReader.ReadToEnd();
				}
			}

			MainHighlightedProducts = JsonConvert.DeserializeObject<BookBlockPLVM>(readToEnd);
		}
	}
}
