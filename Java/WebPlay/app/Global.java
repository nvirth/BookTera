import java.io.File;
import java.lang.reflect.Method;
import java.text.SimpleDateFormat;
import java.util.Date;
import java.util.Locale;

import play.data.format.Formatters;
import utils.PlayClientManager;
import play.Application;
import play.Configuration;
import play.GlobalSettings;
import play.api.mvc.Handler;
import play.libs.F.Promise;
import play.mvc.Action;
import play.mvc.Http.Request;
import play.mvc.Http.RequestHeader;
import play.mvc.SimpleResult;
import com.booktera.proxy.Cookie.ClientManager;
import utils.StringFormatter;

public class Global extends GlobalSettings
{
    @Override
    public void onStart(Application app)
    {
        super.onStart(app);

        Formatters.register(String.class, new StringFormatter()); // Register formatters. See in the book at 120. page

        ClientManager.Instance.setCore(new PlayClientManager());
    }

    // --

    @Override
    public void beforeStart(Application app)
    {
        // TODO Auto-generated method stub
        super.beforeStart(app);
    }

    @Override
    public void onStop(Application app)
    {
        // TODO Auto-generated method stub
        super.onStop(app);
    }

    @Override
    public Promise<SimpleResult> onError(RequestHeader request, Throwable t)
    {
        // TODO Auto-generated method stub
        return super.onError(request, t);
    }

    @Override
    public Action onRequest(Request request, Method actionMethod)
    {
        // TODO Auto-generated method stub
        return super.onRequest(request, actionMethod);
    }

    @Override
    public Handler onRouteRequest(RequestHeader request)
    {
        // TODO Auto-generated method stub
        return super.onRouteRequest(request);
    }

    @Override
    public Promise<SimpleResult> onHandlerNotFound(RequestHeader request)
    {
        // TODO Auto-generated method stub
        return super.onHandlerNotFound(request);
    }

    @Override
    public Promise<SimpleResult> onBadRequest(RequestHeader request, String error)
    {
        // TODO Auto-generated method stub
        return super.onBadRequest(request, error);
    }

    @Override
    public Configuration onLoadConfig(Configuration config, File path, ClassLoader classloader)
    {
        // TODO Auto-generated method stub
        return super.onLoadConfig(config, path, classloader);
    }

}
