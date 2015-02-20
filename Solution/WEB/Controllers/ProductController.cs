using System;
using System.IO;
using System.Text;
using System.Web.Mvc;
using System.Xml;
using System.Xml.Serialization;
using CommonModels.Models.EntityFramework;
using log4net;
using UtilsLocal;
using UtilsShared;
using WEB.Controllers.Base;
using WebMatrix.WebData;
using Formatting = Newtonsoft.Json.Formatting;

// With DAL reference
//using DAL.EntityFramework;

namespace WEB.Controllers
{
	public class ProductController : BookteraControllerBase
	{
		#region Details

		//
		// GET: /Product/Details/

		public ActionResult Details(string friendlyUrl, int productId = -1, int pageNumber = 1)
		{
			var model = ProductGroupManager.GetFullDetailed(friendlyUrl, pageNumber, Config.ProductsPerPage);

			return View("BookBlocksRows/BookRowList", model);
		}

		#endregion

		#region List

		//
		// GET: /Product/Highlighteds

		public ActionResult Highlighteds(int pageNumber = 1)
		{
			ViewBag.siteTitle = "Kiemelt ajánlataink";
			var model = ProductManager.GetMainHighlighteds(pageNumber, Config.ProductsPerPage);

			return View("BookBlocksRows/BookBlockList", model);
		}

		//
		// GET: /Product/Newests

		public ActionResult Newests(int pageNumber = 1)
		{
			ViewBag.siteTitle = "Legújabb könyveink";
			var model = ProductManager.GetNewests(pageNumber, Config.ProductsPerPage, Config.NewestHowMany);

			return View("BookBlocksRows/BookBlockList", model);
		}

		//
		// GET: /Product/Users

		public ActionResult Users(string friendlyUrl, int pageNumber = 1)
		{
			string userName;
			var usersProducts = ProductManager.GetUsersProductsByFriendlyUrl(friendlyUrl, pageNumber, Config.ProductsPerPage, out userName);
			bool isSelf = userName.ToLower() == WebSecurity.CurrentUserName.ToLower();
			ViewBag.siteTitle = isSelf ? "Feltöltött könyveim" : string.Format("{0} könyvei", userName);

			return View("BookBlocksRows/BookBlockList", usersProducts);
		}

		#endregion
	}
}
