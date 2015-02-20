using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WEB.Controllers.Base;

namespace WEB.Controllers
{
    public class ErrorController : BookteraControllerBase
    {
        //
        // GET: /Error/

        public ActionResult Index(int? httpErrorCode)
        {
            return View("Error");
        }
    }
}
