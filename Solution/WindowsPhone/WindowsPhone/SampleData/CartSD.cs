using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Threading.Tasks;
using WindowsPhone.SampleData.Base;
using WinPhoneClientProxy.CategoryManagerService;
using CommonModels.Models;
using Newtonsoft.Json;
using WinPhoneCommon.Models;
using BookBlockPLVM = WinPhoneClientProxy.ProductManagerService.BookBlockPLVM;

namespace WindowsPhone.SampleData
{
	/// <summary>
	/// For all kind of TransactionItems...
	/// </summary>
	public class CartSD : Helpers
	{
		public List<UserOrderPlvmWp> Data { get; set; }

		public CartSD()
		{
			string readToEnd;

			try
			{
				// Case for: Offline Device
				using(var streamReader = new StreamReader(SampleDataRootOnWP + "CartSD.json"))
				{
					readToEnd = streamReader.ReadToEnd();
				}
			}
			catch (Exception e)
			{
				// Case for: Designer
				using(var streamReader = new StreamReader(SampleDataRootOnPC + "CartSD.json"))
				{
					readToEnd = streamReader.ReadToEnd();
				}
			}

			var plvms = JsonConvert.DeserializeObject<List<UserOrderPlvmWp>>(readToEnd);

			// change/calculate the viewmodel
			foreach(var userOrderPlvm in plvms)
				userOrderPlvm.InitAfterDeserialization(t => { }, t => { });

			Data = plvms;
		}
	}
}
