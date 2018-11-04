package controllers;

import com.booktera.data.CommonPortable_Models_ProductModels.BookBlockPLVM;
import com.booktera.proxy.AuthorManager;
import com.booktera.proxy.ProductGroupManager;
import com.booktera.proxy.PublisherManager;
import controllers.base.BookteraControllerBase;
import models.Search.DetailedSearchVm;
import models.Search.Partial.DetailedSearchInputsVm;
import play.api.templates.Html;
import play.data.DynamicForm;
import play.data.Form;
import play.mvc.Http;
import play.mvc.Result;
import utils.Config;
import utils.Utils;
import views.html.Search.DetailedSearch;
import views.html.Shared.BookBlocksRows.BookBlockList;

import java.rmi.RemoteException;

public class SearchController extends BookteraControllerBase
{
    public static final Form<DetailedSearchInputsVm> searchForm = Form.form(DetailedSearchInputsVm.class);

    // Search in ProductGroups. 2 modes: simple/detaild (2 buttons)
    // GET: /Search/ProductGroup
    public static Result ProductGroup(String searchBoxText, String btnSearch, int pageNumber) throws RemoteException
    {
        // Simple search: real searching
        if (btnSearch != null)
        {
            Http.Context.current().args.put("siteTitle", "Találatok");
            BookBlockPLVM viewModel = ProductGroupManager
                .search(searchBoxText, pageNumber, Config.ProductsPerPage, /*needCategory*/ false);

            Html render = BookBlockList.render(viewModel);
            return ok(render);
        }

        // Detailed search: get the detailedSearch main page (not searching)
        else
        {
            return redirect(routes.SearchController.Detailed(searchBoxText));
        }
    }

    // Delegating to the GET version...
    public static Result ProductGroup_POST() throws RemoteException
    {
        DynamicForm postedData = DynamicForm.form().bindFromRequest();
        String searchBoxText = postedData.get("searchBoxText");
        String btnSearch = postedData.get("btnSearch");
        int pageNumber = Utils.parseIntegerOr(postedData.get("pageNumber"), 1);

        return ProductGroup(searchBoxText, btnSearch, pageNumber);
    }

    // The main page of detailedSearch (not searching yet)
    // [HttpGet]
    public static Result Detailed(String searchBoxText)
    {
        Http.Context.current().args.put("SearchingText", searchBoxText);

        Html render = DetailedSearch.render(new DetailedSearchVm(searchForm));
        return ok(render);
    }

    // [HttpPost]
    // POST /Search/Detailed controllers.SearchController.Detailed(detailedSearchInputs: DetailedSearchVMDetailedSearchInputs, pageNumber: Int ?= 1, isPaging: Boolean ?= false)
    //DetailedSearchVMDetailedSearchInputs detailedSearchInputs, int pageNumber, boolean isPaging
    public static Result Detailed_POST() throws RemoteException
    {
        // Fetch dynamic form values
        DynamicForm dynamicForm = DynamicForm.form().bindFromRequest();
        int pageNumber = Utils.parseIntegerOr(dynamicForm.get("pageNumber"), 1);
        boolean isPaging = Utils.parseBooleanOr(dynamicForm.get("isPaging"), false);

        // Handle the posted search-data
        Form<DetailedSearchInputsVm> postedForm = searchForm.bindFromRequest();
        BookBlockPLVM searchResults = ProductGroupManager.searchDetailed(postedForm.get(), pageNumber, Config.ProductsPerPage);

        DetailedSearchVm model = new DetailedSearchVm(postedForm, searchResults);

        Http.Context.current().args.put("siteTitle", "Találatok");
        Http.Context.current().args.put("isPaging", isPaging);
        Http.Context.current().args.put("isSearching", !isPaging);

        Html render = DetailedSearch.render(model);
        return ok(render);
    }

    // -- AutoComplete

    // [HttpPost]
    public static Result ProductGroupAutoComplete(/*String searchBoxText*/) throws RemoteException
    {
        DynamicForm dynamicForm = DynamicForm.form().bindFromRequest();
        String searchBoxText = (String) dynamicForm.get().getData().values().iterator().next();

        String result = ProductGroupManager.searchAutoCompleteJson(searchBoxText, Config.AutoCompleteResultCount);
        return ok(result);
    }

    // [HttpPost]
    public static Result AuthorAutoComplete(/*String authorName, boolean withPlainValue*/) throws RemoteException
    {
        DynamicForm dynamicForm = DynamicForm.form().bindFromRequest();
        String authorName = dynamicForm.get("authorName");
        boolean withPlainValue = Utils.parseBooleanOr(dynamicForm.get("withPlainValue"), false);

        String result = AuthorManager.getSearchAutoComplete(authorName, Config.AutoCompleteResultCount, withPlainValue);
        return ok(result);
    }

    // [HttpPost]
    public static Result PublisherAutoComplete(/*String publisherName, boolean withPlainValue*/) throws RemoteException
    {
        DynamicForm dynamicForm = DynamicForm.form().bindFromRequest();
        String publisherName = dynamicForm.get("publisherName");
        boolean withPlainValue = Utils.parseBooleanOr(dynamicForm.get("withPlainValue"), false);

        String result = PublisherManager.getSearchAutoComplete(publisherName, Config.AutoCompleteResultCount, withPlainValue);
        return ok(result);
    }
}