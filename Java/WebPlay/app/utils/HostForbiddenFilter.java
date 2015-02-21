package utils;

import controllers.AccountController;
import org.apache.axis.AxisFault;
import play.api.libs.iteratee.Done;
import play.api.libs.iteratee.Iteratee;
import play.api.mvc.EssentialAction;
import play.api.mvc.EssentialFilter;
import play.api.mvc.RequestHeader;
import play.api.mvc.SimpleResult;
import scala.runtime.AbstractFunction1;

// Nincs használva, de itt van példának; mivel nem 5 perc volt összerakni
public class HostForbiddenFilter implements EssentialFilter
{
    @Override
    public EssentialAction apply(final EssentialAction next)
    {

        return new JavaEssentialAction() {
            @Override
            public EssentialAction apply()
            {
//                try
//                {
                    return next.apply();
//                } catch (AxisFault e)
//                {
                    // Ez nem az a módszer, amivel ezt kezelni lehet
                    // Ugye itt azt akartam kezelni, amikor az ASP oldalon
                    // már lejárt a session; akkor egy AxisFault 403 Forbidden
                    // jön vissza kivételként
                    //return Done.apply(AccountController.LogOff_Core(), null);
//                }
            }

            @Override
            public Iteratee<byte[], SimpleResult> apply(RequestHeader v1)
            {
                return next.apply(v1);
            }
        };
    }

    public abstract class JavaEssentialAction
            extends AbstractFunction1<RequestHeader, Iteratee<byte[], SimpleResult>>
            implements EssentialAction
    {
    }
}
