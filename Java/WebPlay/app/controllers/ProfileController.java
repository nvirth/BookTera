package controllers;

import com.booktera.data.CommonModels_Models.CommentWithProductGroupVM;
import com.booktera.data.CommonModels_Models.RatingWithProductGroupVM;
import com.booktera.data.CommonModels_Models.UserAddressVM;
import com.booktera.data.CommonModels_Models.UserProfileEditVM;
import com.booktera.data.CommonModels_Models_EntityFramework.UserGroup;
import com.booktera.data.CommonModels_Models_EntityFramework.holders.ArrayOfUserGroupHolder;
import com.booktera.data.CommonPortable_Enums.UserGroupEnum;
import com.booktera.proxy.*;
import controllers.base.BookteraControllerBase;
import models.Account.LoginVM;
import models.Profile.AddressesViewHelper;
import models.Profile.UserAddressVmWithValidation;
import models.Profile.UserGroupVm;
import models.Profile.UserProfileEditVm;
import play.api.templates.Html;
import play.data.DynamicForm;
import play.data.Form;
import play.data.validation.ValidationError;
import play.mvc.Http;
import play.mvc.Result;
import play.mvc.Security;
import utils.Authorize;
import utils.Config;
import utils.EnumHelpers.UserGroupEnumHelper;
import utils.Utils;
import views.html.Profile.*;
import views.html.Profile.Partials.AddressRowPartial;
import views.html.Profile.Partials.CreateAddressPartial;

import javax.xml.rpc.holders.IntegerWrapperHolder;
import javax.xml.ws.spi.http.HttpContext;
import java.rmi.RemoteException;
import java.text.NumberFormat;
import java.util.*;

// [Authorize]
// [InitializeSimpleMembership]
@Security.Authenticated(Authorize.class)
public class ProfileController extends BookteraControllerBase
{
    // -- UserProfile

    public static final Form<UserProfileEditVm> userProfileEditForm = Form.form(UserProfileEditVm.class);

    public static Result Edit() throws RemoteException
    {
        UserProfileEditVM userProfile = UserProfileManager.getForEdit();
        Form<UserProfileEditVm> form = userProfileEditForm.fill(new UserProfileEditVm(userProfile));

        Html render = Edit.render(form);
        return ok(render);
    }

    // [HttpPost]
    public static Result Edit_POST(/*userprofileeditvm userprofileedit, httppostedfilebase imagefile*/) throws RemoteException
    {
        Form<UserProfileEditVm> postedForm = userProfileEditForm.bindFromRequest();

        if (!postedForm.hasErrors())
            try
            {
                UserProfileEditVm userProfileEdit = postedForm.get();

                // todo képfeltöltés
                // userProfileEdit.ImageUrl = ManageUserImageUpload(imageFile, WebSecurity.CurrentUserName.ToFriendlyUrl(), Session);

                UserProfileManager.update(userProfileEdit);

                Http.Context.current().args.put("Success", "Profil frissítve!");
            }
            catch (Exception e)
            {
                postedForm.errors().put("", Arrays.asList(new ValidationError("", "Nem sikerült frissíteni a profilod. ")));
            }
        else
        {
            postedForm.errors().put("", Arrays.asList(new ValidationError("", "Nem sikerült frissíteni a profilod. ")));
        }

        Html render = Edit.render(postedForm);
        return ok(render);
    }

    // [HttpPost]
    public static Result CheckEmailUnique(/*String email*/) throws RemoteException
    {
        DynamicForm form = Form.form().bindFromRequest();
        String email = (String) form.get().getData().values().iterator().next();

        Boolean exist = UserProfileManager.checkNewEmailUnique(email);
        return ok(exist.toString());
    }

// Ezek helper-ek voltak (jobban private lennének)
//
//    public static String ManageUserImageUpload(HttpPostedFileBase imageFile, String userFriendlyUrl, HttpSessionStateBase session)
//    {
//        return _TODO;
//    }
//
//    public static String ManageProductImageUpload(HttpPostedFileBase imageFile, String productFriendlyUrl)
//    {
//        return _TODO;
//    }
//
//    public static String ManageProductGroupImageUpload(HttpPostedFileBase imageFile, String productGroupFriendlyUrl)
//    {
//        return _TODO;
//    }

    // -- UserAddress

    public static final Form<UserAddressVmWithValidation> addressForm = Form.form(UserAddressVmWithValidation.class);
    public static final Form<UserAddressVM> addressFormNonValidated = Form.form(UserAddressVM.class);

    public static Result Addresses() throws RemoteException
    {
        UserAddressVM[] usersAddresses = UserAddressManager.getUsersAddresses();

        Html render = Addresses.render(usersAddresses, new AddressesViewHelper());
        return ok(render);
    }

    public static Result AddressesToOrder(int userOrderId, boolean isCustomer, Integer ordersOldAddressId) throws RemoteException
    {
        Http.Context.current().args.put("UserOrderId", userOrderId);
        Http.Context.current().args.put("UserAddressId", ordersOldAddressId);
        Http.Context.current().args.put("IsCustomer", isCustomer);

        return Addresses();
    }

    public static Result CreateAddress()
    {
        Http.Context.current().args.put("Country", "Magyarország");

        Html render = CreateAddressPartial.render(addressForm);
        return ok(render);
    }

    // [HttpPost]
    public static Result CreateAddress_POST(/*UserAddressVMWithValidation userAddressVm, int?userOrderId=null*/)
    {
        Form<UserAddressVmWithValidation> boundForm = addressForm.bindFromRequest();
        if (!boundForm.hasErrors())
        {
            try
            {
                UserAddressVmWithValidation userAddressVm = boundForm.get();

                Integer id = UserAddressManager.addViaViewModel(userAddressVm);
                userAddressVm.setId(id);

                Integer userOrderId = Utils.parseInteger(boundForm.data().get("userOrderId"));
                Http.Context.current().args.put("UserOrderId", userOrderId);

                Html render = AddressRowPartial.render(userAddressVm);
                return ok(render);

            }
            catch (Exception ignored)
            {
                boundForm.errors().put("", Arrays.asList(
                    new ValidationError("", "Nem sikerült rögzíteni a címedet. ")));
            }
        }
        else
        {
            boundForm.errors().put("", Arrays.asList(
                new ValidationError("", "Nem sikerült rögzíteni a címedet. ")));
        }

        Html render = CreateAddressPartial.render(boundForm);
        return ok(render);
    }

    // [HttpPost]
    public static Result EditAddress(/*UserAddressVMWithValidation userAddressVm*/)
    {
        Form<UserAddressVmWithValidation> boundForm = addressForm.bindFromRequest();
        if (!boundForm.hasErrors())
        {
            try
            {
                UserAddressVmWithValidation userAddressVm = boundForm.get();

                UserAddressManager.updateViaViewModel(userAddressVm);

                return ok(Boolean.TRUE.toString());
            }
            catch (Exception ignored)
            {
            }
        }
        return ok(Boolean.FALSE.toString());
    }

    // [HttpPost]
    public static Result DeleteAddress(/*int userAddressId, boolean isDefault*/)
    {
        try
        {
            Map<String, String> postedData = Form.form().bindFromRequest().data();
            int userAddressId = Integer.parseInt(postedData.get("userAddressId"));
            boolean isDefault = Boolean.parseBoolean(postedData.get("isDefault"));

            UserAddressManager.delete(userAddressId, isDefault);

            return ok(Boolean.TRUE.toString());
        }
        catch (Exception ignored)
        {
        }

        return ok(Boolean.FALSE.toString());
    }

    // [HttpPost]
    public static Result MakeAddressDefault(/*int userAddressId*/)
    {
        try
        {
            Map<String, String> postedData = Form.form().bindFromRequest().data();
            int userAddressId = Integer.parseInt(postedData.get("userAddressId"));

            UserProfileManager.updateDefaultAddress(userAddressId);

            return ok(Boolean.TRUE.toString());
        }
        catch (Exception ignored)
        {
        }

        return ok(Boolean.FALSE.toString());
    }

    // [HttpPost]
    public static Result MakeOrdersAddress(/*int userAddressId, int userOrderId*/)
    {
        try
        {
            Map<String, String> postedData = Form.form().bindFromRequest().data();
            int userAddressId = Integer.parseInt(postedData.get("userAddressId"));
            int userOrderId = Integer.parseInt(postedData.get("userOrderId"));

            UserOrderManager.updateUserOrdersAddress(userAddressId, userOrderId);

            return ok(Boolean.TRUE.toString());
        }
        catch (Exception ignored)
        {
        }

        return ok(Boolean.FALSE.toString());
    }

    // -- UserGroup ...

    public static Result Group() throws RemoteException
    {
        ArrayOfUserGroupHolder userGroups = new ArrayOfUserGroupHolder();
        IntegerWrapperHolder usersGroupId = new IntegerWrapperHolder();

        UserGroupManager.getAllWithUsers(Utils.getCurrentUserId(), userGroups, usersGroupId);

        UserGroupVm[] userGroupVms = Arrays.stream(userGroups.value)
            .map(ug -> new UserGroupVm(ug))
            .toArray(UserGroupVm[]::new);

        UserGroupVm usersGroup = Arrays.stream(userGroupVms)
            .filter(ug -> ug.getID().equals(usersGroupId.value))
            .findFirst().get();

        Html render = Group.render(userGroupVms, usersGroup);
        return ok(render);
    }

    // [HttpPost]
    public static Result LevelUp(/*UserGroupEnum toUserGroup*/) throws RemoteException
    {
        DynamicForm form = Form.form().bindFromRequest();
        String toUserGroup = (String) form.get().getData().values().iterator().next();

        UserGroupEnum userGroupEnum = UserGroupEnumHelper.get(Integer.parseInt(toUserGroup));

        Boolean leveledUp;
        try
        {
            leveledUp = UserProfileManager.levelUpUser(userGroupEnum, true);
        }
        catch (Exception e)
        {
            leveledUp = false;
        }
        return ok(leveledUp.toString());
    }

    public static Result Comments() throws RemoteException
    {
        CommentWithProductGroupVM[] comments = CommentManager.getUsersComments();

        Html render = Comments.render(comments);
        return ok(render);
    }

    public static Result Ratings() throws RemoteException
    {
        RatingWithProductGroupVM[] ratings = RatingManager.getUsersRatings();

        Html render = Ratings.render(ratings);
        return ok(render);
    }
}