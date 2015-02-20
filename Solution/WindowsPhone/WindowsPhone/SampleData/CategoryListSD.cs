using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Threading.Tasks;
using WindowsPhone.SampleData.Base;
using WinPhoneClientProxy.CategoryManagerService;
using Newtonsoft.Json;
using BookBlockPLVM = WinPhoneClientProxy.ProductManagerService.BookBlockPLVM;

namespace WindowsPhone.SampleData
{
	/// <summary>
	/// Also can use for SearchSampleData
	/// </summary>
	public class CategoryListSD : Helpers
	{
		public InCategoryCWPLVM SubCategories { get; set; }

		public CategoryListSD()
		{
			string readToEnd;

			try
			{
				// Case for: Offline Device
				using(var streamReader = new StreamReader(SampleDataRootOnWP + "CategoryListSD.json"))
				{
					readToEnd = streamReader.ReadToEnd();
				}
			}
			catch (Exception e)
			{
				// Case for: Designer
				using(var streamReader = new StreamReader(SampleDataRootOnPC + "CategoryListSD.json"))
				{
					readToEnd = streamReader.ReadToEnd();
				}
			}

			SubCategories = JsonConvert.DeserializeObject<InCategoryCWPLVM>(readToEnd);
		}
	}
}
