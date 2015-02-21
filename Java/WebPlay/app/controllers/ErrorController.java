package controllers;

import controllers.base.BookteraControllerBase;
import play.api.templates.Html;
import play.mvc.Result;
import views.html.Shared.*;

public class ErrorController extends BookteraControllerBase
{
    //public static Result Index(int? httpErrorCode)
    // a default érték: -1
    public static Result Index(Integer httpErrorCode)
    {
        String msg = "";
        //if (httpErrorCode != null) //...

        Html render = views.html.Shared.Error.render(Html.apply(msg));
        return ok(render);
    }
}