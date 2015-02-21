package controllers;

import utils.Config;
import models.Shared.BookBlocksRows.InBookBlockPvm;
import models.Shared.LayoutPartials.LoginBoxPartialVM;
import models.Shared.LayoutPartials.MainMenuPartialVM;
import com.booktera.data.CommonPortable_Enums.BookBlockType;
import com.booktera.data.CommonPortable_Models_ProductModels.InBookBlockPVM;
import play.api.templates.Html;
import play.mvc.Http.Cookie;
import play.mvc.Result;
import controllers.base.BookteraControllerBase;
import com.booktera.proxy.ImageManager;
import utils.Utils;
import views.html.Shared.BookBlocksRows.Partials.Block.Types.Product;
import views.html.Shared.BookBlocksRows.Partials.Block.Types.ProductForExchange;
import views.html.Shared.BookBlocksRows.Partials.Block.Types.ProductGroup;
import views.html.Shared.BookBlocksRows.Partials.Block.Types.ProductInCart;
import views.html.Shared.BookBlocksRows.Partials.Block.Types.ProductInExchangeCart;
import views.html.Shared.BookBlocksRows.Partials.Block.Types.ProductInOrder;
import views.html.Shared.LayoutPartials.LoginBoxPartial;
import views.html.Shared.LayoutPartials.MainMenuPartial;
import play.mvc.Http.Context;

import java.rmi.RemoteException;
import java.util.Map;


public class HomeController extends BookteraControllerBase
{
    public static Result Index()
    {
        return movedPermanently(routes.ProductController.Highlighteds(1));
    }

    // -- Layout Helpers

    public static Html RenderMainMenuPartial()
    {
        MainMenuPartialVM vm = new MainMenuPartialVM();
        Cookie cookie;

        cookie = request().cookie("main-menu-box");
        vm.boxOpenedCookieValue = cookie != null ? cookie.value() : "true";
        vm.boxDisplay = vm.boxOpenedCookieValue.equals("true") ? "block" : "none";

        cookie = request().cookie("main-menu-opened");
        vm.menusOpenedCookieValue = cookie != null ? cookie.value() : "";
        vm.openedMenuIds = vm.menusOpenedCookieValue.split(",");

//        String[] paths = request().path().split("/", 4); // "" "controller" "action" "..."?
//        vm.controller = paths[1];
//        vm.action = paths[2];
        vm.controller = Utils.getControllerName();
        vm.action = Utils.getActionName();

        vm.isOpened = false;

        vm.isUserAuthenticated = session(Config.SESSION_USER_NAME) != null;
        vm.titleIfDeactive = vm.isUserAuthenticated ? "" : Config.NoAuthFunction;

        Html render = MainMenuPartial.render(vm);
        return render;
    }

    public static Html RenderLoginBoxPartial() throws RemoteException
    {
        LoginBoxPartialVM vm = new LoginBoxPartialVM();
        Cookie cookie;

        cookie = request().cookie("loginBox");
        vm.cookieValue = cookie != null ? cookie.value() : "true";
        vm.display = vm.cookieValue.equals("true") ? "block" : "none";

        vm.returnUrl = request().uri();

        if (Config.isUserAuthenticated())
        {
            vm.userImageUrl = session(Config.SESSION_USER_IMAGE);
            if (vm.userImageUrl == null)
            {
                vm.userImageUrl = ImageManager.GetUsersAvatar();
                session(Config.SESSION_USER_IMAGE, vm.userImageUrl);
            }

            vm.userName = session(Config.SESSION_USER_NAME);
            vm.userImageTitle = vm.userImageUrl.equals("default.jpg") ? "Még nem töltöttél fel képet" : "";
        }

        Html render = LoginBoxPartial.render(vm);
        return render;
    }

    // -- Shared view renderers

    public static Html RenderBookBlockPartial(InBookBlockPVM model)
    {
        InBookBlockPvm Model = new InBookBlockPvm(model);

        // Place in the ViewBag the values, that all Types use

        Map<String, Object> viewData = Context.current().args;
        viewData.put("UserName", Model.getProduct().getUserName());
        viewData.put("HowMany", Model.getProduct().getHowMany());
        viewData.put("ProductId", Model.getProduct().getID());

        // Render the view for the Type

        Html partialToRender = Html.empty();
        BookBlockType bookBlockType = (BookBlockType) viewData.get("BookBlockType");
        if (bookBlockType == BookBlockType.Product)
            partialToRender = Product.render(Model);
        else if (bookBlockType == BookBlockType.ProductGroup)
            partialToRender = ProductGroup.render(Model);
        else if (bookBlockType == BookBlockType.ProductInOrder)
            partialToRender = ProductInOrder.render(Model);
        else if (bookBlockType == BookBlockType.ProductForExchange)
            partialToRender = ProductForExchange.render(Model);
        else if (bookBlockType == BookBlockType.ProductInCart)
            partialToRender = ProductInCart.render(Model);
        else if (bookBlockType == BookBlockType.ProductInExchangeCart)
            partialToRender = ProductInExchangeCart.render(Model);

        return partialToRender;
    }
}
