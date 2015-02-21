package controllers;

import com.booktera.data.CommonPortable_Models_ProductModels.BookRowPLVM;
import com.booktera.data.CommonPortable_Models_ProductModels.holders.BookBlockPLVMHolder;
import com.booktera.proxy.ProductGroupManager;
import controllers.base.BookteraControllerBase;
import play.data.DynamicForm;
import play.data.Form;
import utils.Config;
import com.booktera.data.CommonPortable_Models_ProductModels.BookBlockPLVM;
import play.api.templates.Html;
import play.mvc.Http;
import play.mvc.Result;
import com.booktera.proxy.ProductManager;
import utils.Utils;
import views.html.Shared.BookBlocksRows.BookBlockList;
import views.html.Shared.BookBlocksRows.BookRowList;

import javax.xml.rpc.holders.StringHolder;
import java.rmi.RemoteException;

public class ProductController extends BookteraControllerBase
{
    public static Result Details(String friendlyUrl, int productId /*= -1*/, int pageNumber /* = 1*/) throws RemoteException
    {
        BookRowPLVM model = ProductGroupManager.getFullDetailed(friendlyUrl, pageNumber, Config.ProductsPerPage);

        Html render = BookRowList.render(model);
        return ok(render);
    }
    public static Result Details_Paging() throws RemoteException
    {
        // Delegating the POST-ed version
        DynamicForm postedData = DynamicForm.form().bindFromRequest();
        String friendlyUrl = postedData.get("friendlyUrl");
        Integer productId = Utils.parseIntegerOr(postedData.get("productId"), -1);
        Integer pageNumber = Utils.parseIntegerOr(postedData.get("pageNumber"), 1);

        return Details(friendlyUrl, productId, pageNumber);
    }

    public static Result Highlighteds(int pageNumber) throws RemoteException
    {
        Http.Context.current().args.put("siteTitle", "Kiemelt ajánlataink");

        BookBlockPLVM model = ProductManager.getMainHighlighteds(pageNumber, Config.ProductsPerPage);

        Html render = BookBlockList.render(model);
        return ok(render);
    }
    public static Result Highlighteds_Paging() throws RemoteException
    {
        int pageNumber = Integer.parseInt(Form.form().bindFromRequest().get("pageNumber"));
        return Highlighteds(pageNumber);
    }

    public static Result Newests(int pageNumber) throws RemoteException
    {
        Http.Context.current().args.put("siteTitle", "Legújabb könyveink");

        BookBlockPLVM model = ProductManager.getNewests(pageNumber, Config.ProductsPerPage, Config.NewestHowMany);

        Html render = BookBlockList.render(model);
        return ok(render);
    }
    public static Result Newests_Paging() throws RemoteException
    {
        int pageNumber = Integer.parseInt(Form.form().bindFromRequest().get("pageNumber"));
        return Newests(pageNumber);
    }

    public static Result Users(String friendlyUrl, int pageNumber /*= 1*/) throws RemoteException
    {
        BookBlockPLVMHolder usersProducts = new BookBlockPLVMHolder();
        StringHolder userName = new StringHolder();
        ProductManager.getUsersProductsByFriendlyUrl(friendlyUrl, pageNumber, Config.ProductsPerPage, /*forExchange*/ false, usersProducts, userName);

        String siteTitle = String.format("%1$s könyvei", userName.value);
        if (Config.isUserAuthenticated())
        {
            boolean isSelf = userName.value.toLowerCase().equals(session(Config.SESSION_USER_NAME).toLowerCase());
            siteTitle = isSelf ? "Feltöltött könyveim" : siteTitle;
        }
        Http.Context.current().args.put("siteTitle", siteTitle);

        Html render = BookBlockList.render(usersProducts.value);
        return ok(render);
    }
    public static Result Users_Paging() throws RemoteException
    {
        DynamicForm postedData = DynamicForm.form().bindFromRequest();
        String friendlyUrl = postedData.get("friendlyUrl");
        Integer pageNumber = Utils.parseIntegerOr(postedData.get("pageNumber"), 1);

        return Users(friendlyUrl, pageNumber);
    }
}