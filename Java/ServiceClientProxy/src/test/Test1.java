package test;

import java.rmi.RemoteException;

import javax.xml.rpc.ServiceException;
import javax.xml.rpc.holders.BooleanWrapperHolder;
import javax.xml.rpc.holders.IntegerWrapperHolder;

import com.booktera.proxy.AuthenticationManager;
import com.booktera.proxy.ProductManager;
import org.apache.axis.client.Call;
import org.apache.axis.client.Stub;
import org.apache.axis.transport.http.HTTPConstants;

import com.booktera.services.Authentication.*;

/**
 * Tapasztalatok: Jobb, ha minden kérés előtt újra példányosítjuk a
 * service-eket, mert miután már kiküldtünk egy kérést, azzal a módszerrel,
 * ahogy az 1.höz sütiket rendeltünk; azzal a módszerrel a 2. kéréshez már nem
 * adja hozzá a sütiket (nem csinál semmit)
 * 
 */

public class Test1
{

	private static IBookteraAuthenticationServiceProxy	proxy;

	public static void main(String[] args) throws RemoteException, ServiceException
	{
		// test234(123, 345, 345);
		// try1();
		// try2();
		try3();
	}

	private static void try3() throws RemoteException
	{
        ProductManager.getNewests(1, 8, 8);

		AuthenticationManager.login("ZomiDudu", "asdqwe123", /* persistent */false);

	}

	// private static void try2() throws RemoteException {
	//
	// BookteraAuthenticationBasicStub proxy = new
	// BookteraAuthenticationBasicStub();
	//
	// BooleanWrapperHolder wasSuccessful = new BooleanWrapperHolder();
	// IntegerWrapperHolder userId = new IntegerWrapperHolder();
	// proxy.loginAndGetId("ZomiDudu", "asdqwe123", /* persistent */false,
	// wasSuccessful, userId);
	//
	// System.out.println("wasSuccesful: " + wasSuccessful.value);
	// System.out.println("userId: " + userId.value);
	// }

	private static void test234(int integet, int j, int k)
	{
		// TODO Auto-generated method stub
		int a;
		a = integet;

	}

	private static void try1() throws RemoteException, ServiceException
	{
		// proxy = new IBookteraAuthenticationServiceProxy();
		// BooleanWrapperHolder wasSuccessful = new BooleanWrapperHolder();
		// IntegerWrapperHolder userId = new IntegerWrapperHolder();
		// proxy.loginAndGetId("ZomiDudu", "asdqwe123", /* persistent */false,
		// wasSuccessful, userId);

		BookteraAuthenticationServiceLocator locator = new BookteraAuthenticationServiceLocator();
		IBookteraAuthenticationService service = locator.getBookteraAuthenticationBasic();

		Stub stub = (Stub) service;

		stub._setProperty(Call.SESSION_MAINTAIN_PROPERTY, new Boolean(true));
		String asdf = "AuthToken=abc123;aaa=vvv,fff=dfg4";
		stub._setProperty(HTTPConstants.HEADER_COOKIE, asdf);

		Object cookie1 = stub._getProperty(HTTPConstants.HEADER_COOKIE);
		Object setCookie1 = stub._getProperty(HTTPConstants.HEADER_SET_COOKIE);

		BooleanWrapperHolder wasSuccessful = new BooleanWrapperHolder();
		IntegerWrapperHolder userId = new IntegerWrapperHolder();
		service.loginAndGetId("ZomiDudu", "asdqwe123", /* persistent */false, wasSuccessful, userId);

		// request
		Object cookie2 = stub._getProperty(HTTPConstants.HEADER_COOKIE);
		Object serCookie2 = stub._getProperty(HTTPConstants.HEADER_SET_COOKIE);

		// response
		Object cookie3 = stub._getCall().getMessageContext().getProperty(HTTPConstants.HEADER_COOKIE);
		Object setCookie3 = stub._getCall().getMessageContext().getProperty(HTTPConstants.HEADER_SET_COOKIE);

		// ((Stub) service)._getCall().getMessageContext()
		// .setProperty(HTTPConstants.HEADER_COOKIE, property3);

		// ((Stub) service)._setProperty(HTTPConstants.HEADER_COOKIE,
		// join(";", (String[])property3));

		// stub._setProperty(HTTPConstants.HEADER_SET_COOKIE,
		// "AuthToken=abc123");

		service.logout();

		System.out.println("wasSuccesful: " + wasSuccessful.value);
		System.out.println("userId: " + userId.value);
	}
}
