package utils.Helpers;

import play.mvc.Http;

import java.net.HttpCookie;

public class CookieHelpers
{
    public static HttpCookie Convert(Http.Cookie playCookie)
    {
        HttpCookie cookie = new HttpCookie(playCookie.name(), playCookie.value());
        //cookie.setComment();
        //cookie.setVersion(); --> 1
        cookie.setDomain(playCookie.domain());
        cookie.setHttpOnly(playCookie.httpOnly());
        cookie.setMaxAge(convertMaxAge_ToStandard(playCookie));
        cookie.setPath(playCookie.path());
        cookie.setSecure(playCookie.secure());

        return cookie;
    }

    public static Http.Cookie Convert(HttpCookie cookie)
    {
        Http.Cookie playCookie = new Http.Cookie(
                cookie.getName(),
                cookie.getValue(),
                convertMaxAge_ToPlay(cookie),
                cookie.getPath(),
                cookie.getDomain(),
                cookie.getSecure(),
                cookie.isHttpOnly()
        );

        return playCookie;
    }

    public static void setPlayCookie(HttpCookie cookie)
    {
        Http.Context.current().response().setCookie(
                cookie.getName(),
                cookie.getValue(),
                convertMaxAge_ToPlay(cookie),
                cookie.getPath(),
                cookie.getDomain(),
                cookie.getSecure(),
                cookie.isHttpOnly()
        );
    }

    private static long convertMaxAge_ToStandard(Http.Cookie playCookie)
    {
        Integer expiry = playCookie.maxAge();   // normal cookie
        if (playCookie.maxAge() == null)         // session cookie
            expiry = -1;
        else if (playCookie.maxAge() < 0)        // cookie expired
            expiry = 0;

        return expiry;
    }

    private static Integer convertMaxAge_ToPlay(HttpCookie cookie)
    {
        Integer playExpiry = (int) cookie.getMaxAge();   // normal cookie
        if (cookie.getMaxAge() < 0)                      // session cookie
            playExpiry = null;
        else if (cookie.getMaxAge() == 0)                // cookie expired
            playExpiry = -1;

        return playExpiry;
    }
}
