package utils;

import controllers.AccountController;
import controllers.routes;
import play.mvc.Http;
import play.mvc.Result;
import play.mvc.Security;

public class Authorize extends Security.Authenticator
{
    @Override
    public String getUsername(Http.Context ctx)
    {
        return ctx.session().get(Config.SESSION_USER_NAME);  //"UserName"
    }

    @Override
    public Result onUnauthorized(Http.Context ctx)
    {
        /*String returnUrl = ctx.request().path();
        return redirect(routes.AccountController.Login(returnUrl));*/

        return AccountController.RedirectToLogin();
    }
}
