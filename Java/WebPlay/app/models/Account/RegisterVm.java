package models.Account;

import com.booktera.data.CommonModels_Models.UserAddressVM;
import com.booktera.data.CommonModels_Models_AccountModels.RegisterVM;
import models.Profile.UserAddressVm;
import play.data.validation.Constraints.*;
import sun.reflect.generics.reflectiveObjects.NotImplementedException;
import utils.Annotations.*;

import java.lang.String;

import static utils.ValidationConstants.*;

public class RegisterVm extends RegisterVM
{
    @Required(message = Required)
    @MaxLength(value = 100, message = MaxLength)
    @Pattern(value = RegEx_START_EnChar_EnCharOrDigit_0Ti_END, message = RegExErrMsg_START_EnChar_EnCharOrDigit_0Ti_END)
    @Remote(url = "/Account/CheckUserNameUnique", message = Remote, httpMethod = "POST")
    @DisplayName("Felhasználó név")
    private String UserName;

    @Required(message = Required)
    @MaxLength(value = 100, message = MaxLength)
    @Email(message = "Nem megfelelő e-mail cím")
    @Remote(url = "/Account/CheckEmailUnique", message = Remote, httpMethod = "POST")
    @DisplayName("E-mail cím")
    private String EMail;

    @Required(message = Required)
    @StringLength(min = 6, max = 128, message = StringLengthMinMax)
    @DisplayName("Jelszó")
    private String Password;

    // -- ConfirmPassword

    @Required(message = Required)
    @CompareAtClient(other = "Password", message = _compareErrMsg)
    @DisplayName("Jelszó megerősítése")
    private String ConfirmPassword;

    private static final String _compareErrMsg = "A jelszó és a megerősített jelszó nem egyezik meg!";

    @FieldMatch(first = "Password", second = "ConfirmPassword", message = _compareErrMsg)
    private RegisterVm that = this;
    public RegisterVm getThat()
    {
        return that;
    }

    // -- Not required fields

    @Pattern(value = RegEx_START_HuChar_HuCharOrSpace_0Ti_END, message = RegExErrMsg_START_HuChar_HuCharOrSpace_0Ti_END)
    @MaxLength(value = 100, message = MaxLength)
    @DisplayName("Szerző")
    private String AuthorName;

    @Pattern(value = RegEx_START_HuChar_HuCharOrSpace_0Ti_END, message = RegExErrMsg_START_HuChar_HuCharOrSpace_0Ti_END)
    @MaxLength(value = 100, message = MaxLength)
    @DisplayName("Kiadó")
    private String PublisherName;

    @Pattern(value = RegEx_START_HuChar_HuCharOrSpace_0Ti_END, message = RegExErrMsg_START_HuChar_HuCharOrSpace_0Ti_END)
    @MaxLength(value = 100, message = MaxLength)
    @DisplayName("Teljes név")
    private String FullName;

    @Pattern(value = RegEx_START_Digit_7T20_END, message = RegExErrMsg_START_Digit_7T20_END)
    @MaxLength(value = 50, message = MaxLength)
    @DisplayName("Telefonszám")
    private String PhoneNumber;

    @DisplayName("Avatar kép feltöltése")
    private String ImageUrl;

    private UserAddressVm UserAddress;

    // -- Getters, Setters

    @Override
    public String getUserName()
    {
        return UserName;
    }

    @Override
    public void setUserName(String userName)
    {
        this.UserName = userName;
    }

    @Override
    public String getEMail()
    {
        return EMail;
    }

    @Override
    public void setEMail(String EMail)
    {
        this.EMail = EMail;
    }

    @Override
    public String getPassword()
    {
        return Password;
    }

    @Override
    public void setPassword(String password)
    {
        this.Password = password;
    }

    @Override
    public String getConfirmPassword()
    {
        return ConfirmPassword;
    }

    @Override
    public void setConfirmPassword(String confirmPassword)
    {
        this.ConfirmPassword = confirmPassword;
    }

    @Override
    public String getAuthorName()
    {
        return AuthorName;
    }

    @Override
    public void setAuthorName(String authorName)
    {
        this.AuthorName = authorName;
    }

    @Override
    public String getPublisherName()
    {
        return PublisherName;
    }

    @Override
    public void setPublisherName(String publisherName)
    {
        this.PublisherName = publisherName;
    }

    @Override
    public String getFullName()
    {
        return FullName;
    }

    @Override
    public void setFullName(String fullName)
    {
        this.FullName = fullName;
    }

    @Override
    public String getPhoneNumber()
    {
        return PhoneNumber;
    }

    @Override
    public void setPhoneNumber(String phoneNumber)
    {
        this.PhoneNumber = phoneNumber;
    }

    @Override
    public String getImageUrl()
    {
        return ImageUrl;
    }

    @Override
    public void setImageUrl(String imageUrl)
    {
        this.ImageUrl = imageUrl;
    }

    @Override
    public UserAddressVm getUserAddress()
    {
        return UserAddress;
    }

    @Override
    public void setUserAddress(UserAddressVM userAddress)
    {
        if (userAddress instanceof UserAddressVm)
            UserAddress = (UserAddressVm) userAddress;
        else
            throw new RuntimeException("Not implemented");
    }
}