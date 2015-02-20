using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Threading.Tasks;
using WindowsPhone.SampleData.Base;
using WinPhoneClientProxy.ProductGroupManagerService;
using Newtonsoft.Json;
using InCategoryPLVM = WinPhoneClientProxy.ProductManagerService.InCategoryPLVM;

namespace WindowsPhone.SampleData
{
	public class PgFullDetailedSD : Helpers
	{
		public BookRowPLVM Model { get; set; }

		public PgFullDetailedSD()
		{
			string readToEnd;

			try
			{
				// Case for: Offline Device
				using(var streamReader = new StreamReader(SampleDataRootOnWP + "PgFullDetailedSD.json"))
				{
					readToEnd = streamReader.ReadToEnd();
				}
			}
			catch(Exception e)
			{
				// Case for: Designer
				using(var streamReader = new StreamReader(SampleDataRootOnPC + "PgFullDetailedSD.json"))
				{
					readToEnd = streamReader.ReadToEnd();
				}
			}

			Model = JsonConvert.DeserializeObject<BookRowPLVM>(readToEnd);
		}
	}
}
