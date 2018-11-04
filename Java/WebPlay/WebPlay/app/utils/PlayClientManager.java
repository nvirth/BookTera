package utils;

import play.mvc.Http;
import com.booktera.proxy.Cookie.IClientManager;
import utils.Helpers.CookieHelpers;

import java.net.HttpCookie;
import java.util.ArrayList;
import java.util.List;

public class PlayClientManager implements IClientManager
{
    private final String COOKIE_HEADER = "Cookie";
    private final String SET_COOKIE_HEADER = "Set-Cookie";

    @Override
    public List<HttpCookie> getCookiesForService()
    {
        String[] cookies = Http.Context.current().request().headers().get(COOKIE_HEADER);
        if (cookies == null || cookies.length == 0)
            return null;
        if (cookies.length == 1 && (cookies[0] == null || cookies[0].isEmpty()))
            return null;

        ArrayList<HttpCookie> results = new ArrayList<HttpCookie>();
        for(String cookieStr : cookies[0].split("; ")){
            String[] cookieSplit = cookieStr.split("=", 2);
            String cookieName = cookieSplit[0];

            Http.Cookie playCookie = Http.Context.current().request().cookie(cookieName);
            results.add(CookieHelpers.Convert(playCookie));
        }

        return results;
    }

    @Override
    public void setCookiesForClient(List<HttpCookie> newCookies)
    {
        if (newCookies == null || newCookies.isEmpty())
            return;

        for (HttpCookie newCookie : newCookies)
            CookieHelpers.setPlayCookie(newCookie);
    }

    // This old version is held only for saftey sake
    public void setCookiesForClient_OLD(List<HttpCookie> newCookies)
    {
        if (newCookies == null || newCookies.isEmpty())
            return;

        List<HttpCookie> originalCookies = getCookiesForService();
        for (HttpCookie newCookie : newCookies)
        {
            boolean contains = false;

            for (HttpCookie originalCookie : originalCookies)
                if (originalCookie.getName().equals(newCookie.getName()))
                {
                    contains = true;
                    if(!originalCookie.getValue().equals(newCookie.getValue()))
                        CookieHelpers.setPlayCookie(newCookie);
                }

            if(!contains)
                CookieHelpers.setPlayCookie(newCookie);
        }
    }
}
