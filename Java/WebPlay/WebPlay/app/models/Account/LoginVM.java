package models.Account;

import com.booktera.data.CommonModels_Models_AccountModels.LoginModel;
import play.data.validation.Constraints.*;
import utils.Annotations.CompareAtClient;
import utils.Annotations.DisplayName;
import utils.Annotations.FieldMatch;
import utils.Annotations.Remote;
import utils.ValidationConstants;

public class LoginVM extends LoginModel
{
    @Required(message = ValidationConstants.Required)
    @DisplayName("Felhasználó név")
    private String loginUserName;

    @Required(message = ValidationConstants.Required)
    @DisplayName("Jelszó")
    private String loginPassword;

    @DisplayName("Emlékezz rám")
    private boolean rememberMe;

    // -- Getters, Setters

    public String getLoginUserName()
    {
        return loginUserName;
    }

    public void setLoginUserName(String loginUserName)
    {
        this.loginUserName = loginUserName;
    }

    public String getLoginPassword()
    {
        return loginPassword;
    }

    public void setLoginPassword(String loginPassword)
    {
        this.loginPassword = loginPassword;
    }

    public boolean isRememberMe()
    {
        return rememberMe;
    }

    public void setRememberMe(boolean rememberMe)
    {
        this.rememberMe = rememberMe;
    }
}
