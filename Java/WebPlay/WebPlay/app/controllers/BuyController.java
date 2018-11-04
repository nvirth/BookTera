package controllers;

import com.booktera.data.CommonModels_Models.UserOrderPLVM;
import com.booktera.proxy.TransactionManager;
import controllers.base.BookteraControllerBase;
import models.Shared.TransactionLists.TransactionListViewHelper;
import play.api.templates.Html;
import play.data.DynamicForm;
import play.mvc.Http;
import play.mvc.Result;
import play.mvc.Security;
import utils.Authorize;
import utils.Config;
import utils.Utils;
import views.html.Shared.TransactionLists.TransactionList;

import java.rmi.RemoteException;

// [Authorize]
// [InitializeSimpleMembership]
@Security.Authenticated(Authorize.class)
public class BuyController extends BookteraControllerBase
{
    // Cart opartaions

    public static Result AddToCart(/*int productID*/)
    {
        DynamicForm postedData = DynamicForm.form().bindFromRequest();
        Integer productID = Utils.parseInteger(postedData.get("productID"));

        try
        {
            TransactionManager.addProductToCart(productID);
            return ok(Boolean.TRUE.toString());
        }
        catch (Exception e)
        {
            return ok(Boolean.FALSE.toString());
        }
    }

    public static Result RemoveFromCart(/*int productInOrderId*/)
    {
        DynamicForm postedData = DynamicForm.form().bindFromRequest();
        Integer productInOrderId = Utils.parseInteger(postedData.get("productInOrderId"));

        try
        {
            TransactionManager.removeProductFromCart(productInOrderId);
            return ok(Boolean.TRUE.toString());
        }
        catch (Exception e)
        {
            return ok(Boolean.FALSE.toString());
        }
    }

    public static Result DeleteCart(/*int userOrderId*/)
    {
        DynamicForm postedData = DynamicForm.form().bindFromRequest();
        Integer userOrderId = Utils.parseInteger(postedData.get("userOrderId"));

        try
        {
            TransactionManager.removeUsersCart(userOrderId);
            return ok(Boolean.TRUE.toString());
        }
        catch (Exception e)
        {
            return ok(Boolean.FALSE.toString());
        }
    }

    public static Result DeleteAllCarts()
    {
        try
        {
            TransactionManager.removeUsersAllCarts();
            return ok(Boolean.TRUE.toString());
        }
        catch (Exception e)
        {
            return ok(Boolean.FALSE.toString());
        }
    }

    public static Result ModifyProductsQuantity(/*int productInOrderId, int newQuantity*/)
    {
        DynamicForm postedData = DynamicForm.form().bindFromRequest();
        Integer newQuantity = Utils.parseInteger(postedData.get("newQuantity"));
        Integer productInOrderId = Utils.parseInteger(postedData.get("productInOrderId"));

        try
        {
            TransactionManager.updateProductInCart(productInOrderId, newQuantity);
            return ok(Boolean.TRUE.toString());
        }
        catch (Exception e)
        {
            return ok(Boolean.FALSE.toString());
        }
    }

    // -- TransactionList

    public static Result Carts() throws RemoteException
    {
        Http.Context.current().args.put("SiteTitle", "Kosaraim");
        Http.Context.current().args.put("EmptyMessage", "Nincs kosarad. ");

        UserOrderPLVM[] carts = TransactionManager.getUsersCartsVM(/*customerId*/ Utils.getCurrentUserId(), /*vendorId*/ null);
        Html render = TransactionList.render(carts, new TransactionListViewHelper());
        return ok(render);
    }

    public static Result InProgressOrders() throws RemoteException
    {
        Http.Context.current().args.put("SiteTitle", "Megrendelt könyveim");
        Http.Context.current().args.put("EmptyMessage", "Nincsenek megrendelt könyveid. ");

        UserOrderPLVM[] orders = TransactionManager.getUsersInProgressOrdersVM(/*customerId*/ Utils.getCurrentUserId(), /*vendorId*/null);
        Html render = TransactionList.render(orders, new TransactionListViewHelper());
        return ok(render);
    }

    public static Result EarlierOrders() throws RemoteException
    {
        Http.Context.current().args.put("SiteTitle", "Korábbi vásárlásaim");
        Http.Context.current().args.put("EmptyMessage", "Nem vásároltál még. ");

        UserOrderPLVM[] orders = TransactionManager.getUsersFinishedTransactionsVM(/*customerId*/ Utils.getCurrentUserId(), /*vendorId*/null);
        Html render = TransactionList.render(orders, new TransactionListViewHelper());
        return ok(render);
    }
}