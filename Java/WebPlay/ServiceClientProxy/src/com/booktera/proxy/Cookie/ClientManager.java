package com.booktera.proxy.Cookie;

import java.net.HttpCookie;
import java.util.List;

public class ClientManager implements IClientManager
{
    // -- Singleton

    public static final ClientManager Instance = new ClientManager();

    private ClientManager()
    {
    }

    // -- Core

    private IClientManager core;

    public void setCore(IClientManager core)
    {
        this.core = core;
    }

    // -- Implementing/Delegating methods

    @Override
    public List<HttpCookie> getCookiesForService()
    {
        checkCore();
        return core.getCookiesForService();
    }

    @Override
    public void setCookiesForClient(List<HttpCookie> cookies)
    {
        checkCore();
        core.setCookiesForClient(cookies);
    }

    // -- Helpers

    private void checkCore()
    {
        if (core == null)
            throw new RuntimeException("The singleton's core must be initialized. ");
    }
}
