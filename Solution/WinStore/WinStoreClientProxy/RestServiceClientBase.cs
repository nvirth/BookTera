using System;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using WinStoreClientProxy.ModelsObservable.ProductModelsObservable;

namespace WinStoreClientProxy.test
{

	//todo átszervezni a kódot, hogy ezt használja
	public abstract class RestServiceClientBase
	{
		protected string BaseAddress;

		protected RestServiceClientBase(string baseAddress)
		{
			BaseAddress = baseAddress;
		}

		protected async Task<T> GetAsync<T>(string requestUrl)
		{
			var webRequest = WebRequest.Create(requestUrl);
			webRequest.Proxy = null;

			Task<WebResponse> responseAsync = webRequest.GetResponseAsync();
			WebResponse response = await responseAsync;

			string responseText;
			using(var streamReader = new StreamReader(response.GetResponseStream()))
			{
				responseText = streamReader.ReadToEnd();
			}

			var result = JsonConvert.DeserializeObject<T>(responseText);
			return result;
		}
	}

	//Egy próba osztály, így lehet használni leszármaztatással:
	//
	//public class asdf : RestServiceClientBase
	//{
	//	public asdf()
	//	{
	//		baseAddress = "http://localhost:50135/EntityManagers/CategoryManagerService.svc/";
	//	}

	//	public async Task<InCategoryCwplvmObservable> GetCategoriesWithPsroductsInCategoryAsync(int pageNumber, int productsPerPage, string baseCategoryFu = null)
	//	{
	//		var requestUrl = BuildRequestUrl_GetCategoriesWithProductsInCategory(pageNumber, productsPerPage, baseCategoryFu);
	//		return await GetAsync<InCategoryCwplvmObservable>(requestUrl);
	//	}

	//	/// <summary>
	//	/// Pl.: http://localhost:50135/EntityManagers/CategoryManagerService.svc/GetCategoriesWithProductsInCategory?pageNumber=1&productsPerPage=8
	//	/// </summary>
	//	private string BuildRequestUrl_GetCategoriesWithProductsInCategory(int pageNumber, int productsPerPage, string baseCategoryFu)
	//	{
	//		var stringBuilder = new StringBuilder();
	//		stringBuilder
	//			.Append(baseAddress)
	//			.Append("GetCategoriesWithProductsInCategory")
	//			.Append("?pageNumber=")
	//			.Append(pageNumber)
	//			.Append("&productsPerPage=")
	//			.Append(productsPerPage);

	//		if(!String.IsNullOrWhiteSpace(baseCategoryFu))
	//			stringBuilder
	//				.Append("&baseCategoryFu=")
	//				.Append(baseCategoryFu);

	//		return stringBuilder.ToString();
	//	}
	//}
}