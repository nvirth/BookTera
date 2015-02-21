package com.booktera.proxy.Cookie;

import org.apache.axis.client.Stub;

import java.net.HttpCookie;
import java.util.List;

public class ManagerStatic
{
    public static void beforeRequest(Stub service)
    {
        List<HttpCookie> cookies = ClientManager.Instance.getCookiesForService();
        ServiceManager.Instance.setCookiesForService(cookies, service);
    }

    public static void afterResponse(Stub service)
    {
        List<HttpCookie> cookies = ServiceManager.Instance.getCookiesForClient(service);
        ClientManager.Instance.setCookiesForClient(cookies);
    }
}
