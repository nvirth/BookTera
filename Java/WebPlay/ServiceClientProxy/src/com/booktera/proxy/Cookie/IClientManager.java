package com.booktera.proxy.Cookie;

import java.net.HttpCookie;
import java.util.List;

public interface IClientManager
{
    public List<HttpCookie> getCookiesForService();
    public void setCookiesForClient(List<HttpCookie> cookies);
}
