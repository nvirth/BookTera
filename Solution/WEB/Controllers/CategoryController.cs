using System.Web;
using System.Web.Mvc;
using CommonModels.Models.ProductModels;
// With DAL reference
//using DAL.Models;
//using DAL.EntityFramework;
//using DAL.Models.ProductModels;
using CommonPortable.Models.ProductModels;
using WEB.Controllers.Base;


namespace WEB.Controllers
{
	public class CategoryController : BookteraControllerBase
    {

		// List of products in the Category specified by the friendlyUrl
        // GET: /Category/
		// POST (ajax, paging)

		public ActionResult Index(string friendlyUrl, int pageNumber = 1)
		{
			InCategoryPLVM model = ProductManager.GetProductsInCategory(friendlyUrl, pageNumber, Config.ProductsPerPage);

			ViewBag.siteTitle = model.Category.DisplayName;
			TempData["selectedCategoryFriendlyUrl"] = friendlyUrl;
			//TempData.Add("selectedCategoryFriendlyUrl", friendlyUrl);
			//ViewBag.friendlyUrl = model.Category.FriendlyUrl;

			return View("BookBlocksRows/BookBlockList", model);
		}

		// Creates the left side menu to the Layout

		[ChildActionOnly]
		public ActionResult CategoryMenu()
		{
			string selected = (string)TempData["selectedCategoryFriendlyUrl"];
			string openedCookieValue = (Request.Cookies["category-opened"] ?? new HttpCookie("", "")).Value;
			var openedIds = openedCookieValue.Split(',');
			var model = CategoryManager.GetAllForMenu(selected, openedIds);

			return View("LayoutPartials/CategoryMenuPartial", null, model);
		}

		// 
		// AJAX_POST: /Category/GetCategoryListJson/

		[HttpPost]
	    public JsonResult GetCategoryListJson(int? selectedId = null)
		{
			var categorySelectList = CategoryManager.GetAllSortedJson(selectedId);
			return Json(categorySelectList);
		}
    }
}
