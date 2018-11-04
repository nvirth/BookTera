package com.booktera.proxy.Cookie;

import org.apache.axis.client.Stub;

import java.net.HttpCookie;
import java.util.List;

public interface IServiceManager
{
    public List<HttpCookie> getCookiesForClient(Stub service);
    public void setCookiesForService(List<HttpCookie> cookies, Stub service);
}
