using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using CommonPortable.Models;
using CommonPortable.Models.ProductModels;
using Newtonsoft.Json;
using WinStoreClientProxy.ModelsObservable.ProductModelsObservable;

namespace WinStoreClientProxy
{
	public static class ProductGroupManager
	{
		private const string ProductGroupManagerServiceBaseAddress = "http://localhost:50135/EntityManagers/ProductGroupManagerService.svc/";

		#region GetFullDetailedAsync

		public static async Task<BookRowPLVM> GetFullDetailedAsync(string friendlyUrl, int pageNumber, int productsPerPage)
		{
			var requestUrl = BuildRequestUrl_GetFullDetailed(friendlyUrl, pageNumber, productsPerPage);
			var webRequest = WebRequest.Create(requestUrl);
			webRequest.Proxy = null;

			Task<WebResponse> responseAsync = webRequest.GetResponseAsync();
			WebResponse response = await responseAsync;

			string responseText;
			using (var streamReader = new StreamReader(response.GetResponseStream()))
			{
				responseText = streamReader.ReadToEnd();
			}

			var result = JsonConvert.DeserializeObject<BookRowPLVM>(responseText);
			return result;
		}

		/// <summary>
		/// Pl.: http://localhost:50135/EntityManagers/ProductGroupManagerService.svc/GetFullDetailed?friendlyUrl=Buddhizmus-es-asztrologia&pageNumber=1&productsPerPage=8
		/// </summary>
		private static string BuildRequestUrl_GetFullDetailed(string friendlyUrl, int pageNumber, int productsPerPage)
		{
			var stringBuilder = new StringBuilder();
			stringBuilder
				.Append(ProductGroupManagerServiceBaseAddress)
				.Append("GetFullDetailed")
				.Append("?friendlyUrl=")
				.Append(friendlyUrl)
				.Append("&pageNumber=")
				.Append(pageNumber)
				.Append("&productsPerPage=")
				.Append(productsPerPage);
			return stringBuilder.ToString();
		}

		#endregion

		#region SearchAutoCompleteAsync

		public static async Task<LabelValuePair[]> SearchAutoCompleteAsync(string searchText, int howMany)
		{
			var requestUrl = BuildRequestUrl_SearchAutoComplete(searchText, howMany);
			var webRequest = WebRequest.Create(requestUrl);
			webRequest.Proxy = null;

			Task<WebResponse> responseAsync = webRequest.GetResponseAsync();
			WebResponse response = await responseAsync;

			string responseText;
			using (var streamReader = new StreamReader(response.GetResponseStream()))
			{
				responseText = streamReader.ReadToEnd();
			}

			var result = JsonConvert.DeserializeObject<LabelValuePair[]>(responseText);
			return result;
		}

		/// <summary>
		/// Pl.: http://localhost:50135/EntityManagers/ProductGroupManagerService.svc/SearchAutoComplete?searchText=al&howMany=10
		/// </summary>
		private static string BuildRequestUrl_SearchAutoComplete(string searchText, int howMany)
		{
			var stringBuilder = new StringBuilder();
			stringBuilder
				.Append(ProductGroupManagerServiceBaseAddress)
				.Append("SearchAutoComplete")
				.Append("?searchText=")
				.Append(searchText)
				.Append("&howMany=")
				.Append(howMany);
			return stringBuilder.ToString();
		}

		#endregion

		#region SearchAutoCompletePgAsync

		public static async Task<SearchPgAcVm[]> SearchAutoCompletePgAsync(string searchText, int howMany)
		{
			var requestUrl = BuildRequestUrl_SearchAutoCompletePg(searchText, howMany);
			var webRequest = WebRequest.Create(requestUrl);
			webRequest.Proxy = null;

			Task<WebResponse> responseAsync = webRequest.GetResponseAsync();
			WebResponse response = await responseAsync;

			string responseText;
			using (var streamReader = new StreamReader(response.GetResponseStream()))
			{
				responseText = streamReader.ReadToEnd();
			}

			var result = JsonConvert.DeserializeObject<SearchPgAcVm[]>(responseText);
			return result;
		}

		/// <summary>
		/// Pl.: http://localhost:50135/EntityManagers/ProductGroupManagerService.svc/SearchAutoCompletePg?searchText=al&howMany=10
		/// </summary>
		private static string BuildRequestUrl_SearchAutoCompletePg(string searchText, int howMany)
		{
			var stringBuilder = new StringBuilder();
			stringBuilder
				.Append(ProductGroupManagerServiceBaseAddress)
				.Append("SearchAutoCompletePg")
				.Append("?searchText=")
				.Append(searchText)
				.Append("&howMany=")
				.Append(howMany);
			return stringBuilder.ToString();
		}

		#endregion

		#region SearchWithGroupedByCategoryAsync

		/// <summary>
		/// Pl.: http://localhost:50135/EntityManagers/ProductGroupManagerService.svc/SearchWithGroupedByCategory?searchText=alma&pageNumber=1&productsPerPage=100
		/// </summary>
		public static async Task<InCategoryCwplvmObservable> SearchWithGroupedByCategoryAsync(string searchText, int pageNumber, int productsPerPage)
		{
			var requestUrl = BuildRequestUrl_SearchWithGroupedByCategory(searchText, pageNumber, productsPerPage);
			var webRequest = WebRequest.Create(requestUrl);
			webRequest.Proxy = null;

			Task<WebResponse> responseAsync = webRequest.GetResponseAsync();
			WebResponse response = await responseAsync;

			string responseText;
			using (var streamReader = new StreamReader(response.GetResponseStream()))
			{
				responseText = streamReader.ReadToEnd();
			}

			var result = JsonConvert.DeserializeObject<InCategoryCwplvmObservable>(responseText);
			return result;
		}

		private static string BuildRequestUrl_SearchWithGroupedByCategory(string searchText, int pageNumber, int productsPerPage)
		{
			return new StringBuilder()
				.Append(ProductGroupManagerServiceBaseAddress)
				.Append("SearchWithGroupedByCategory")
				.Append("?searchText=")
				.Append(searchText)
				.Append("&pageNumber=")
				.Append(pageNumber)
				.Append("&productsPerPage=")
				.Append(productsPerPage)
				.ToString();
		}

		#endregion
	}
}