package controllers;

import com.booktera.proxy.RegistrationManager;
import com.booktera.proxy.UserProfileManager;
import controllers.base.BookteraControllerBase;
import models.Account.LoginVM;
import models.Account.RegisterVm;
import play.api.templates.Html;
import play.data.DynamicForm;
import play.data.Form;
//import play.api.data.Form;
import play.data.validation.ValidationError;
import play.mvc.Http;
import play.mvc.Result;
import play.mvc.Security;
import play.mvc.SimpleResult;
import com.booktera.proxy.AuthenticationManager;
import utils.Authorize;
import utils.Config;
import views.html.Account.Login;
import views.html.Account.Register;
import views.html.Account.RegisterSuccess;

import javax.xml.rpc.holders.BooleanWrapperHolder;
import javax.xml.rpc.holders.IntegerWrapperHolder;
import java.io.File;
import java.rmi.RemoteException;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;

// [Authorize]
// [InitializeSimpleMembership]
public class AccountController extends BookteraControllerBase
{
    public static final Form<LoginVM> loginForm = Form.form(LoginVM.class);
    public static final Form<RegisterVm> registerForm = Form.form(RegisterVm.class);

    // [AllowAnonymous]
    public static Result Login(String returnUrl)
    {
        Http.Context.current().args.put("returnUrl", returnUrl);

        Html render = Login.render(loginForm);
        return ok(render);
    }

    // [HttpPost]
    // [AllowAnonymous]
    // [ValidateAntiForgeryToken]
    public static Result Login_POST(String returnUrl /*, LoginModel loginModel*/) throws RemoteException
    {
        Form<LoginVM> postedForm = loginForm.bindFromRequest();

        if (!postedForm.hasErrors())
        {
            LoginVM loginModel = postedForm.get();

            boolean successfullyLoggedIn = Login_Core(loginModel);
            if (successfullyLoggedIn)
                return redirect(returnUrl);
            else
                postedForm.errors().put("", Arrays.asList(new ValidationError("", "Hibás felhasználó név és/vagy jelszó")));
        }

        // If we got this far, something failed, redisplay form

        Http.Context.current().args.put("returnUrl", returnUrl);
        return ok(Login.render(postedForm));
    }

    public static boolean Login_Core(RegisterVm registerModel) throws RemoteException
    {
        return Login_Core(registerModel.getUserName(), registerModel.getPassword(), /*rememberMe*/ false);
    }
    public static boolean Login_Core(LoginVM loginModel) throws RemoteException
    {
        return Login_Core(loginModel.getLoginUserName(), loginModel.getLoginPassword(), loginModel.isRememberMe());
    }
    public static boolean Login_Core(String userName, String password, boolean rememberMe) throws RemoteException
    {
        BooleanWrapperHolder loggedIn = new BooleanWrapperHolder();
        IntegerWrapperHolder userId = new IntegerWrapperHolder();
        AuthenticationManager.loginAndGetId(userName, password, rememberMe, loggedIn, userId);
        if (loggedIn.value)
        {
            session().clear();
            session(Config.SESSION_USER_NAME, userName);
            session(Config.SESSION_USER_ID, userId.value.toString());

            return true;
        }

        return false;
    }

    // [HttpPost]
    // [ValidateAntiForgeryToken]
    @Security.Authenticated(Authorize.class)
    public static Result LogOff() throws RemoteException
    {
        AuthenticationManager.logout();

        LogOff_Core();

        return redirect(routes.HomeController.Index());
    }

    public static void LogOff_Core()
    {
        session().clear();
        Http.Context.current().response().discardCookie(Config.COOKIE_ASPXAUTH);
    }

    public static SimpleResult RedirectToLogin()
    {
        String returnUrl = request().uri();
        return redirect(routes.AccountController.Login(returnUrl));
    }

    // [AllowAnonymous]
    public static Result Register()
    {
        //Http.Context.current().args.put("returnUrl", returnUrl);

        Html render = Register.render(registerForm);
        return ok(render);
    }

    // [HttpPost]
    // [AllowAnonymous]
    // [ValidateAntiForgeryToken]
    public static Result Register_POST(/*RegisterVM registerVm, HttpPostedFileBase imageFile*/) throws RemoteException
    {
        Form<RegisterVm> postedForm = registerForm.bindFromRequest();

        if (!postedForm.hasErrors())
            try
            {
                RegisterVm registerModel = postedForm.get();
                RegistrationManager.registerUser(registerModel);
                Login_Core(registerModel);

                // image

                Http.MultipartFormData.FilePart imageFile =
                    request().body().asMultipartFormData().getFile("imageFile");

                if (imageFile != null)
                {
                    File file = imageFile.getFile();
                    //TODO képfeltöltés
                }

                return redirect(routes.AccountController.RegisterSuccess());
            }
            catch (RemoteException e)
            {
                postedForm.errors().put("", Arrays.asList(new ValidationError("","Nem sikerült a regisztráció. Kérjük, engedélyezze a javascriptet a böngészőjében, hogy további információkhoz juthasson a hibával kapcsolatban.")));
            }

        // If we got this far, something failed, redisplay form

        return ok(Register.render(postedForm));
    }

    public static Result RegisterSuccess()
    {
        ArrayList<String> errors = new ArrayList<String>();

        String error = flash().get("ModelStateErrors");
        if (error != null)
            errors.add(error);

        Html render = RegisterSuccess.render((List<String>)errors);
        return ok(render);
    }

    // [HttpPost]
    // [AllowAnonymous]
    public static Result CheckUserNameUnique(/*String userName*/) throws RemoteException
    {
        DynamicForm form = Form.form().bindFromRequest();
        String userName = (String) form.get().getData().values().iterator().next();

        Boolean isUnique = UserProfileManager.checkUserNameUnique(userName);
        return ok(isUnique.toString());
    }

    // [HttpPost]
    // [AllowAnonymous]
    public static Result CheckEmailUnique(/*String email*/) throws RemoteException
    {
        DynamicForm form = Form.form().bindFromRequest();
        String email = (String) form.get().getData().values().iterator().next();

        Boolean isUnique = UserProfileManager.checkEmailUnique(email);
        return ok(isUnique.toString());
    }
}