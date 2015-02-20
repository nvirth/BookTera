using System.Web.Mvc;
using WEB.Controllers.Base;


namespace WEB.Controllers
{
	public class HomeController : BookteraControllerBase
	{
		//
		// GET: /Home/
		
		public ActionResult Index()
		{
			return RedirectToActionPermanent("Highlighteds", "Product");
		}
	}
}
