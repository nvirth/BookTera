using System;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using CommonPortable.Models.ProductModels;
using Newtonsoft.Json;
using WinStoreClientProxy.ModelsObservable.ProductModelsObservable;

namespace WinStoreClientProxy
{
	public static class CategoryManager
	{
		private const string CategoryManagerServiceBaseAddress = "http://localhost:50135/EntityManagers/CategoryManagerService.svc/";

		#region GetCategoriesWithProductsInCategoryAsync

		public static async Task<InCategoryCwplvmObservable> GetCategoriesWithProductsInCategoryAsync(int pageNumber, int productsPerPage, string baseCategoryFu = null)
		{
			var requestUrl = BuildRequestUrl_GetCategoriesWithProductsInCategory(pageNumber, productsPerPage, baseCategoryFu);
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

		/// <summary>
		/// Pl.: http://localhost:50135/EntityManagers/CategoryManagerService.svc/GetCategoriesWithProductsInCategory?pageNumber=1&productsPerPage=8
		/// </summary>
		private static string BuildRequestUrl_GetCategoriesWithProductsInCategory(int pageNumber, int productsPerPage, string baseCategoryFu)
		{
			var stringBuilder = new StringBuilder();
			stringBuilder
				.Append(CategoryManagerServiceBaseAddress)
				.Append("GetCategoriesWithProductsInCategory")
				.Append("?pageNumber=")
				.Append(pageNumber)
				.Append("&productsPerPage=")
				.Append(productsPerPage);

			if (!String.IsNullOrWhiteSpace(baseCategoryFu))
				stringBuilder
					.Append("&baseCategoryFu=")
					.Append(baseCategoryFu);

			return stringBuilder.ToString();
		}

		#endregion
	}
}