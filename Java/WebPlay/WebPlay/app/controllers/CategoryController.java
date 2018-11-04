package controllers;

import com.booktera.data.CommonPortable_Models_ProductModels.InCategoryPLVM;
import com.booktera.data.UtilsShared.SelectListItemWithClass;
import com.booktera.proxy.ProductManager;
import com.fasterxml.jackson.databind.JsonNode;
import controllers.base.BookteraControllerBase;
import models.Shared.LayoutPartials.CategoryMenuPartialVM;
import play.api.templates.Html;
import play.data.Form;
import play.libs.Json;
import play.mvc.Http;
import play.mvc.Http.Cookie;
import play.mvc.Result;
import com.booktera.proxy.CategoryManager;
import utils.Config;
import utils.HelperModels.SelectListItemWithClass_ForJson;
import utils.Utils;
import views.html.Shared.BookBlocksRows.BookBlockList;
import views.html.Shared.LayoutPartials.CategoryMenuPartial;

import java.rmi.RemoteException;
import java.util.Arrays;
import java.util.List;
import java.util.Map;
import java.util.stream.Collector;
import java.util.stream.Collectors;
import java.util.stream.Stream;

public class CategoryController extends BookteraControllerBase
{

    // List of products in the Category specified by the friendlyUrl
    // GET: /Category/
    // POST (ajax, paging)
    public static Result Index_Paging() throws RemoteException
    {
        String friendlyUrl = Form.form().bindFromRequest().get("friendlyUrl");
        int pageNumber = Integer.parseInt(Form.form().bindFromRequest().get("pageNumber"));

        return Index(friendlyUrl, pageNumber);
    }
    public static Result Index(String friendlyUrl, int pageNumber) throws RemoteException
    {
        InCategoryPLVM model = ProductManager.getProductsInCategory(friendlyUrl, pageNumber, Config.ProductsPerPage);

        Http.Context.current().args.put("siteTitle", model.getCategory().getDisplayName());
        flash("selectedCategoryFriendlyUrl", friendlyUrl);

        Html render = BookBlockList.render(model);
        return ok(render);
    }

    public static Html CategoryMenu() throws RemoteException
    {
        Cookie cookie;

        String selected = flash("selectedCategoryFriendlyUrl");

        cookie = request().cookie("category-opened");
        String openedCookieValue = cookie == null ? "" : cookie.value();
        String[] openedIds = openedCookieValue.split(",");

        String rawHtml = CategoryManager.getAllForMenu(selected, openedIds);

        // view's data

        cookie = request().cookie("category-box");
        String boxCookieValue = cookie == null ? "true" : cookie.value();
        String display = boxCookieValue == "true" ? "block" : "none";


        CategoryMenuPartialVM vm = new CategoryMenuPartialVM();
        vm.cookieValue = boxCookieValue;
        vm.display = display;
        vm.rawHtml = rawHtml;

        Html render = CategoryMenuPartial.render(vm);
        return render;
    }

    // [HttpPost]
    public static Result GetCategoryListJson(/*int? selectedId = null*/) throws RemoteException
    {
        Map<String, String> postedData = Form.form().bindFromRequest().data();
        Integer selectedId = Utils.parseInteger(postedData.get("selectedId"));

        SelectListItemWithClass[] categorySelectList = CategoryManager.getAllSortedJson(selectedId);

        JsonNode result = Utils.toJson(categorySelectList);
        return ok(result);

//        List<SelectListItemWithClass_ForJson> result = Arrays.stream(categorySelectList)
//            .map(SelectListItemWithClass_ForJson::new)
//            .collect(Collectors.toList());
//
//        return ok(Json.toJson(result));
    }
}