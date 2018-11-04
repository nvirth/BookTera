package utils;

import controllers.AccountController;
import org.apache.axis.AxisFault;
import play.libs.F;
import play.mvc.Action;
import play.mvc.Http;
import play.mvc.SimpleResult;
import scala.concurrent.Future;

public class HostForbiddenAction extends Action.Simple
{
    @Override
    public F.Promise<SimpleResult> call(Http.Context ctx) throws Throwable
    {
        try
        {
            return delegate.call(ctx);
        }
        catch (RuntimeException e)
        {
            // The built in Security.Authenticator wrappes all the Exceptions...
            if (e.getCause() instanceof AxisFault)
                return handleForbidden((AxisFault) e.getCause());
            else
                throw e;
        }
        catch (AxisFault e)
        {
            return handleForbidden(e);
        }
    }
    private F.Promise<SimpleResult> handleForbidden(AxisFault e) throws AxisFault
    {
        // At the Asp's WcfHost the user's auth session is already expired.
        // We log him/her out from this site, and redirect him/her to the Login page

        if (e.getFaultReason().equalsIgnoreCase("(403)Forbidden"))
        {
            F.Promise<SimpleResult> redirectToLogin = F.Promise.promise(new F.Function0<SimpleResult>()
            {
                public SimpleResult apply() throws Throwable
                {
                    AccountController.LogOff_Core();
                    return AccountController.RedirectToLogin();
                }

            });

            return redirectToLogin;
        }

        throw e;
    }
}
