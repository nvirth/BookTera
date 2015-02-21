package com.booktera.proxy.Cookie;

import org.apache.axis.client.Stub;

import java.net.HttpCookie;
import java.util.List;

public class ServiceManager implements IServiceManager
{
    // -- Singleton

    public static final ServiceManager Instance = new ServiceManager();

    private ServiceManager()
    {
    }

    // -- Core

    private IServiceManager core = new ServiceManagerImpl();

    public void setCore(IServiceManager core)
    {
        this.core = core;
    }

    // -- Implementing/Delegating methods

    @Override
    public List<HttpCookie> getCookiesForClient(Stub service)
    {
        checkCore();
        return core.getCookiesForClient(service);
    }

    @Override
    public void setCookiesForService(List<HttpCookie> cookies, Stub service)
    {
        checkCore();
        core.setCookiesForService(cookies, service);
    }

    // -- Helpers

    private void checkCore()
    {
        if (core == null)
            throw new RuntimeException("The singleton's core must be initialized. ");
    }
}
