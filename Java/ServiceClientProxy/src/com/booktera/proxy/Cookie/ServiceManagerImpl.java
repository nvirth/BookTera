package com.booktera.proxy.Cookie;

import org.apache.axis.client.Call;
import org.apache.axis.client.Stub;
import org.apache.axis.transport.http.HTTPConstants;

import java.net.HttpCookie;
import java.util.ArrayList;
import java.util.List;

public class ServiceManagerImpl implements IServiceManager
{
    // -- After Response

    @Override
    public List<HttpCookie> getCookiesForClient(Stub service)
    {
        // In normal case, here we would use HEADER_SET_COOKIE; but this framework works other way
        // If there are only cookies we SENT and those were NOT MODIFIED at service side, then we
        // will get a String. If there are modified/new cookies, we will get a String[]; and in there,
        // we can get the original/unModified cookies in the 0. item; and the new/modified cookies
        // in the 1. item.
        //
        // Long story short, this object can contain:
        // - null     <-- no cookies at all
        // - String   <-- original/unModified cookies
        // - String[]
        //      - [0] <-- original/unModified cookies
        // -    - [1] <-- new/modified cookies
        //
        Object cookie = service._getCall().getMessageContext().getProperty(HTTPConstants.HEADER_COOKIE);
        if (cookie == null)
            return null;

        if (cookie instanceof String[])
        {
            List<HttpCookie> result = new ArrayList<HttpCookie>();

            String[] newOrModifiedCookies = ((String[]) cookie)[1].split(";");
            for (String c : newOrModifiedCookies)
                if (c != null && !c.isEmpty())
                    result.add(HttpCookie.parse(c).get(0));

            return result;
        }

        return null;
    }

    // This version is only held for safety sake
    public List<HttpCookie> getCookiesForClient_OLD(Stub service)
    {
        // In normal case, here we would use HEADER_SET_COOKIE; but this framework works other way
        // If there are only cookies we SENT and those were NOT MODIFIED at service side, then we
        // will get a String. If there are modified/new cookies, we will get a String[]; and in there,
        // we can get the original/unModified cookies in the 0. item; and the new/modified cookies
        // in the 1. item.
        //
        // Long story short, this object can contain:
        // - String <-- original/unModified cookies
        // - String[]
        //      - [0] <-- original/unModified cookies
        // -    - [1] <-- new/modified cookies
        //
        Object cookie = service._getCall().getMessageContext().getProperty(HTTPConstants.HEADER_COOKIE);
        if (cookie == null)
            return null;

        List<HttpCookie> result;
        if (cookie instanceof String[])
        {
            result = new ArrayList<HttpCookie>();
            for (String c : (String[]) cookie)
                if (c != null && !c.isEmpty())
                    result.add(HttpCookie.parse(c).get(0));
        } else if (cookie instanceof String)
        {
            result = HttpCookie.parse((String) cookie);
        } else
        {
            throw new RuntimeException("The Cookie property did not contain String[], nor String. ");
        }

        return result;
    }

    // -- Before Request

    @Override
    public void setCookiesForService(List<HttpCookie> httpCookies, Stub service)
    {
        String cookie = getCookiesBeforeRequest(httpCookies);

        service._setProperty(Call.SESSION_MAINTAIN_PROPERTY, true);
        service._setProperty(HTTPConstants.HEADER_COOKIE, cookie);
    }

    private static String getCookiesBeforeRequest(List<HttpCookie> cookies)
    {
        if (cookies == null || cookies.isEmpty())
            return "";

        StringBuilder sb = new StringBuilder();
        for (HttpCookie httpCookie : cookies)
        {
            httpCookie.setVersion(0); // toString so generates, what we want
            sb.append(httpCookie.toString()).append("; ");
        }
        sb.delete(sb.length() - 2, sb.length()); // remove last "; "

        return sb.toString();
    }
}
