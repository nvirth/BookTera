package controllers;

import com.booktera.data.CommonModels_Models.UserOrderPLVM;
import com.booktera.data.CommonPortable_Models_ProductModels.BookBlockPLVM;
import com.booktera.data.CommonPortable_Models_ProductModels.holders.BookBlockPLVMHolder;
import com.booktera.data.UtilsShared.SelectListItemWithClass;
import com.booktera.proxy.*;
import com.fasterxml.jackson.databind.JsonNode;
import controllers.base.BookteraControllerBase;
import models.Sell.CreatePvm;
import models.Shared.TransactionLists.TransactionListViewHelper;
import play.api.templates.Html;
import play.data.DynamicForm;
import play.data.Form;
import play.data.validation.ValidationError;
import play.libs.Json;
import play.mvc.Http;
import play.mvc.Result;
import play.mvc.Security;
import utils.Authorize;
import utils.Config;
import utils.HelperModels.SelectListItemWithClass_ForJson;
import utils.Utils;
import views.html.Sell.UploadProduct;
import views.html.Shared.BookBlocksRows.BookBlockList;
import views.html.Shared.TransactionLists.TransactionList;

import javax.xml.rpc.holders.StringHolder;
import java.io.File;
import java.rmi.RemoteException;
import java.util.Arrays;
import java.util.List;
import java.util.Map;
import java.util.stream.Collectors;

// [Authorize]
// [InitializeSimpleMembership]
@Security.Authenticated(Authorize.class)
public class SellController extends BookteraControllerBase
{
    public static Form<CreatePvm> uploadProductForm = Form.form(CreatePvm.class);

    public static Result UploadProduct()
    {
        Http.Context.current().args.put("Product.Language", "Magyar");
        Http.Context.current().args.put("Product.Edition", 1);
        //Http.Context.current().args.put("Product.IsBook", true); // -> Default value is set in view

        Html render = UploadProduct.render(uploadProductForm);
        return ok(render);
    }

    // [HttpPost]
    public static Result UploadProduct_POST(/*CreatePvm createModel, HttpPostedFileBase productGroupImageFile, HttpPostedFileBase productImageFile, String productGroupName*/)
    {
        Form<CreatePvm> postedForm = uploadProductForm.bindFromRequest();
        String productGroupName = postedForm.field("productGroupName").value();

        if (!postedForm.hasErrors())
        {
            try
            {
                BookManager.uploadProductNr(postedForm.get());

                Http.Context.current().args.put("Success", "Sikeres könyvfeltöltés!");

                // image

                Http.MultipartFormData.FilePart productGroupImageFile =
                    request().body().asMultipartFormData().getFile("productGroupImageFile");
                Http.MultipartFormData.FilePart productImageFile =
                    request().body().asMultipartFormData().getFile("productImageFile");

                if (productGroupImageFile != null)
                {
                    File file = productGroupImageFile.getFile();
                    //TODO képfeltöltés
                }
            }
            catch (RemoteException e)
            {
                postedForm.errors().put("", Arrays.asList(new ValidationError("", "Nem sikerült feltölteni a könyvet. ")));
            }
        }
        else
        {
            postedForm.errors().put("", Arrays.asList(new ValidationError("", "Nem sikerült feltölteni a könyvet. ")));
        }

        Html render = UploadProduct.render(postedForm);
        return ok(render);
    }

    // [HttpPost]
    public static Result GetProductGroupListJson(/*int? selectedId = null*/) throws RemoteException
    {
        DynamicForm form = Form.form().bindFromRequest();
        String selectedIdStr = (String) form.get().getData().values().iterator().next();
        Integer selectedId = Utils.parseInteger(selectedIdStr);

        SelectListItemWithClass[] selectList = ProductGroupManager.getAllSortedJson(selectedId);

        JsonNode result = Utils.toJson(selectList);
        return ok(result);
    }

    public static Result UploadedProducts(int pageNumber /*=1*/) throws RemoteException
    {
        Http.Context.current().args.put("siteTitle", "Feltöltött könyveim");
        Http.Context.current().args.put("EmptyMessage", "Még nem töltöttél fel könyvet");

        BookBlockPLVM usersProducts = ProductManager.getUsersProducts(Utils.getCurrentUserId(), pageNumber, Config.ProductsPerPage, /*forExchange*/ false);

        Html render = BookBlockList.render(usersProducts);
        return ok(render);
    }

    public static Result UploadedProducts_Paging() throws RemoteException
    {
        DynamicForm postedData = DynamicForm.form().bindFromRequest();
        Integer pageNumber = Utils.parseIntegerOr(postedData.data().values().iterator().next(), 1);

        return UploadedProducts(pageNumber);
    }

    // -- TransactionList

    public static Result FinishedTransactions() throws RemoteException
    {
        Http.Context.current().args.put("SiteTitle", "Befejezett tranzakcióim");
        Http.Context.current().args.put("EmptyMessage", "Nem vásároltak még tőled. ");

        UserOrderPLVM[] transactions = TransactionManager.getUsersFinishedTransactionsVM(/*customerId*/ null, /*vendorId*/ Utils.getCurrentUserId());
        Html render = TransactionList.render(transactions, new TransactionListViewHelper());
        return ok(render);
    }

    public static Result InProgressTransactions() throws RemoteException
    {
        Http.Context.current().args.put("SiteTitle", "Folyamatban lévő tranzakcióim");
        Http.Context.current().args.put("EmptyMessage", "Nem vásároltak még tőled. ");

        UserOrderPLVM[] transactions = TransactionManager.getUsersInProgressOrdersVM(/*customerId*/ null, /*vendorId*/ Utils.getCurrentUserId());
        Html render = TransactionList.render(transactions, new TransactionListViewHelper());
        return ok(render);
    }

    public static Result InCartTransactions() throws RemoteException
    {
        Http.Context.current().args.put("SiteTitle", "Mások által kosárba tett könyveim");
        Http.Context.current().args.put("EmptyMessage", "Jelenleg senki nem tette kosárba semelyik könyved. ");

        UserOrderPLVM[] transactions = TransactionManager.getUsersCartsVM(/*customerId*/ null, /*vendorId*/ Utils.getCurrentUserId());
        Html render = TransactionList.render(transactions, new TransactionListViewHelper());
        return ok(render);
    }

    public static Result SelectExchangeBooks(String userFriendlyUrl, int userOrderID, int pageNumber /*= 1*/) throws RemoteException
    {
        BookBlockPLVMHolder usersProducts = new BookBlockPLVMHolder();
        StringHolder userName = new StringHolder();
        ProductManager.getUsersProductsByFriendlyUrl(userFriendlyUrl, pageNumber, Config.ProductsPerPage, /*forExchange*/ true, usersProducts, userName);

        Http.Context.current().args.put("siteTitle", String.format("%1$s könyvei a csere-kosárba", userName.value));
        Http.Context.current().args.put("UserOrderID", userOrderID);

        Html render = BookBlockList.render(usersProducts.value);
        return ok(render);
    }

    public static Result AddToExchange(/*int productID, int userOrderID*/)
    {
        DynamicForm postedData = DynamicForm.form().bindFromRequest();
        Integer userOrderID = Utils.parseInteger(postedData.get("userOrderID"));
        Integer productID = Utils.parseInteger(postedData.get("productID"));

        try
        {
            TransactionManager.addExchangeProduct(productID, userOrderID);
            return ok(Boolean.TRUE.toString());
        }
        catch (Exception e)
        {
            return ok(Boolean.FALSE.toString());
        }
    }

    public static Result ModifyExchangeProductsQuantity(/*int productInOrderId, int newQuantity*/)
    {
        DynamicForm postedData = DynamicForm.form().bindFromRequest();
        Integer newQuantity = Utils.parseInteger(postedData.get("newQuantity"));
        Integer productInOrderId = Utils.parseInteger(postedData.get("productInOrderId"));

        try
        {
            TransactionManager.updateExchangeProduct(productInOrderId, newQuantity);
            return ok(Boolean.TRUE.toString());
        }
        catch (Exception e)
        {
            return ok(Boolean.FALSE.toString());
        }
    }

    public static Result RemoveFromExchangeCart(/*int productInOrderId*/)
    {
        DynamicForm postedData = DynamicForm.form().bindFromRequest();
        Integer productInOrderId = Utils.parseInteger(postedData.get("productInOrderId"));

        try
        {
            TransactionManager.removeExchangeProduct(productInOrderId);
            return ok(Boolean.TRUE.toString());
        }
        catch (Exception e)
        {
            return ok(Boolean.FALSE.toString());
        }
    }
}