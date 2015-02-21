package models.Profile;

import com.booktera.data.CommonModels_Models.UserProfileEditVM;
import play.data.validation.Constraints;
import utils.Annotations.DisplayName;
import utils.Annotations.Remote;
import utils.ValidationConstants;

import static utils.ValidationConstants.*;

public class UserProfileEditVm extends UserProfileEditVM
{
    @Constraints.Required(message = Required)
    @Constraints.MaxLength(value = 100, message = MaxLength)
    @Constraints.Email(message = "Nem megfelelő e-mail cím")
    @Remote(url = "/Profile/CheckEmailUnique", message = ValidationConstants.Remote, httpMethod = "POST")
    @DisplayName("E-mail cím")
    private String EMail;

    @Constraints.Pattern(value = RegEx_START_HuChar_HuCharOrSpace_0Ti_END, message = RegExErrMsg_START_HuChar_HuCharOrSpace_0Ti_END)
    @Constraints.MaxLength(value = 100, message = MaxLength)
    @DisplayName("Teljes név")
    private String FullName;

    @Constraints.Pattern(value = RegEx_START_Digit_7T20_END, message = RegExErrMsg_START_Digit_7T20_END)
    @Constraints.MaxLength(value = 50, message = MaxLength)
    @DisplayName("Telefonszám")
    private String PhoneNumber;

    @DisplayName("Avatar kép feltöltése")
    private String ImageUrl;

    // Ctors
    public UserProfileEditVm(UserProfileEditVM core)
    {
        EMail = core.getEMail();
        FullName = core.getFullName();
        PhoneNumber = core.getPhoneNumber();
        ImageUrl = core.getImageUrl();
    }

    public UserProfileEditVm()
    {
    }

    // -- Getters, Setters

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
}
