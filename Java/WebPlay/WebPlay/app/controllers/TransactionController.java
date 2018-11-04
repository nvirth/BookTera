package controllers;

import com.booktera.data.CommonModels_Models.UserOrderPLVM;
import com.booktera.data.CommonPortable_Enums.BookBlockType;
import com.booktera.data.CommonPortable_Models_ProductModels.InBookBlockPVM;
import com.booktera.proxy.TransactionManager;
import controllers.base.BookteraControllerBase;
import models.Shared.BookBlocksRows.InBookBlockPvm;
import play.api.templates.Html;
import play.data.DynamicForm;
import play.mvc.Http;
import play.mvc.Result;
import play.mvc.Security;
import utils.Authorize;
import utils.Config;
import utils.Utils;
import views.html.Shared.BookBlocksRows.Partials.Block.Types.*;

import java.util.Map;

// [Authorize]
// [InitializeSimpleMembership]
@Security.Authenticated(Authorize.class)
public class TransactionController extends BookteraControllerBase
{
    // Step 1 - Buy

    public static Result SendOrder(/*int userOrderId*/)
    {
        DynamicForm postedData = DynamicForm.form().bindFromRequest();
        Integer userOrderId = Utils.parseInteger(postedData.get("userOrderId"));

        try
        {
            TransactionManager.sendOrder(userOrderId);
            return ok(Boolean.TRUE.toString());
        }
        catch (Exception e)
        {
            return ok(Boolean.FALSE.toString());
        }
    }

    // Step 2 - Sell

    public static Result SendExchangeOffer(/*int userOrderId*/)
    {
        DynamicForm postedData = DynamicForm.form().bindFromRequest();
        Integer userOrderId = Utils.parseInteger(postedData.get("userOrderId"));

        try
        {
            TransactionManager.sendExchangeOffer(userOrderId);
            return ok(Boolean.TRUE.toString());
        }
        catch (Exception e)
        {
            return ok(Boolean.FALSE.toString());
        }
    }

    public static Result FinalizeOrderWithoutExchange(/*int userOrderId*/)
    {
        DynamicForm postedData = DynamicForm.form().bindFromRequest();
        Integer userOrderId = Utils.parseInteger(postedData.get("userOrderId"));

        try
        {
            TransactionManager.finalizeOrderWithoutExchange(userOrderId);
            return ok(Boolean.TRUE.toString());
        }
        catch (Exception e)
        {
            return ok(Boolean.FALSE.toString());
        }
    }

    // (Step 3) - Buy

    public static Result FinalizeOrderAcceptExchange(/*int userOrderId*/)
    {
        DynamicForm postedData = DynamicForm.form().bindFromRequest();
        Integer userOrderId = Utils.parseInteger(postedData.get("userOrderId"));

        try
        {
            TransactionManager.finalizeOrderAcceptExchange(userOrderId);
            return ok(Boolean.TRUE.toString());
        }
        catch (Exception e)
        {
            return ok(Boolean.FALSE.toString());
        }
    }

    public static Result FinalizeOrderDenyExchange(/*int userOrderId*/)
    {
        DynamicForm postedData = DynamicForm.form().bindFromRequest();
        Integer userOrderId = Utils.parseInteger(postedData.get("userOrderId"));

        try
        {
            TransactionManager.finalizeOrderDenyExchange(userOrderId);
            return ok(Boolean.TRUE.toString());
        }
        catch (Exception e)
        {
            return ok(Boolean.FALSE.toString());
        }
    }

    // Step 4 - Buy & Sell

    public static Result CloseOrderSuccessful(/*int userOrderId*/)
    {
        DynamicForm postedData = DynamicForm.form().bindFromRequest();
        Integer userOrderId = Utils.parseInteger(postedData.get("userOrderId"));

        try
        {
            TransactionManager.closeOrderSuccessful(userOrderId);
            return ok(Boolean.TRUE.toString());
        }
        catch (Exception e)
        {
            return ok(Boolean.FALSE.toString());
        }
    }

    public static Result CloseOrderUnsuccessful(/*int userOrderId*/)
    {
        DynamicForm postedData = DynamicForm.form().bindFromRequest();
        Integer userOrderId = Utils.parseInteger(postedData.get("userOrderId"));

        try
        {
            TransactionManager.closeOrderUnsuccessful(userOrderId);
            return ok(Boolean.TRUE.toString());
        }
        catch (Exception e)
        {
            return ok(Boolean.FALSE.toString());
        }
    }
}