using System.Web.Mvc;
using CommonModels.Models;
// With DAL reference
//using DAL.Models;
//using DAL.EntityFramework;
using UtilsShared;
using WEB.Controllers.Base;

namespace WEB.Controllers
{
	public class SearchController : BookteraControllerBase
	{
		// Search in ProductGroups. 2 modes: simple/detaild (2 buttons)
		// GET: /Search/ProductGroup

		public ActionResult ProductGroup(string searchBoxText, string btnSearch = null, int pageNumber = 1)
		{
			// Simple search: real searching
			if(btnSearch != null)
			{
				ViewBag.siteTitle = "Találatok";
				var viewModel = BookteraControllerBase.ProductGroupManager.Search(searchBoxText, pageNumber, Config.ProductsPerPage);
				return View("BookBlocksRows/BookBlockList", viewModel);
			}

			// Detailed search: get the detailedSearch main page (not searching)
			else
			{
				return RedirectToAction("Detailed", new { searchBoxText });
			}
		}

		// The main page of detailedSearch (not searching yet)
		// GET: /Search/Detailed/

		[HttpGet]
		public ActionResult Detailed(string searchBoxText)
		{
			ViewBag.SearchingText = searchBoxText;
			return View("DetailedSearch");
		}

		// DetailedSearch: searching
		// AJAX_POST: /Search/Detailed/

		[HttpPost]
		public ActionResult Detailed(DetailedSearchVM.DetailedSearchInputs detailedSearchInputs, int pageNumber = 1, bool isPaging = false)
		{
			ViewBag.siteTitle = "Találatok";
			ViewBag.isPaging = isPaging;
			ViewBag.isSearching = !isPaging;

			var detailedSearchModel = new DetailedSearchVM()
			{
				SearchInputs = detailedSearchInputs,
				SearchResults = ProductGroupManager.SearchDetailed(detailedSearchInputs, pageNumber, Config.ProductsPerPage),
			};

			return View("DetailedSearch", detailedSearchModel);
		}

		#region AutoComplete

		//
		// AJAX: /Search/ProductGroupAutoComplete/

		[HttpPost]
		public JsonStringResult ProductGroupAutoComplete(string searchBoxText)
		{
			var jsonString = ProductGroupManager.SearchAutoCompleteJson(searchBoxText, Config.AutoCompleteResultCount);
			return new JsonStringResult(jsonString);
		}

		// 
		// AJAX: /Search/AuthorAutoComplete/

		[HttpPost]
		public JsonStringResult AuthorAutoComplete(string authorName, bool withPlainValue = false)
		{
			var jsonString = AuthorManager.GetSearchAutoComplete(authorName, Config.AutoCompleteResultCount, withPlainValue);
			return new JsonStringResult(jsonString);
		}

		// 
		// AJAX: /Search/PublisherAutoComplete/

		[HttpPost]
		public JsonStringResult PublisherAutoComplete(string publisherName, bool withPlainValue = false)
		{
			var jsonString = PublisherManager.GetSearchAutoComplete(publisherName, Config.AutoCompleteResultCount, withPlainValue);
			return new JsonStringResult(jsonString);
		}

		#endregion
	}
}
