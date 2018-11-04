package models.Profile;

import com.booktera.data.CommonModels_Models.UserAddressVM;
import utils.Annotations.DisplayName;

import java.lang.Boolean;
import java.lang.Integer;
import java.lang.String;

public class UserAddressVm extends UserAddressVM
{
    @DisplayName("Irányítószám")
    private String zipCode;

    @DisplayName("Település")
    private String city;

    @DisplayName("Utca, házszám")
    private String streetAndHouseNumber;

    @DisplayName("Ország")
    private String country;

    @DisplayName("Alapértelmezett")
    private boolean isDefault;

    private Integer ID;

    // -- Getters, Setters

    @Override
    public String getCity()
    {
        return city;
    }
    @Override
    public void setCity(String city)
    {
        this.city = city;
    }

    @Override
    public String getCountry()
    {
        return country;
    }
    @Override
    public void setCountry(String country)
    {
        this.country = country;
    }

    @Override
    public String getStreetAndHouseNumber()
    {
        return streetAndHouseNumber;
    }
    @Override
    public void setStreetAndHouseNumber(String streetAndHouseNumber)
    {
        this.streetAndHouseNumber = streetAndHouseNumber;
    }

    @Override
    public String getZipCode()
    {
        return zipCode;
    }
    @Override
    public void setZipCode(String zipCode)
    {
        this.zipCode = zipCode;
    }

    @Override
    public Integer getId()
    {
        return ID;
    }
    @Override
    public void setId(Integer id)
    {
        this.ID = id;
    }
    public Integer getID()
    {
        return ID;
    }
    public void setID(Integer id)
    {
        this.ID = id;
    }

    @Override
    public Boolean getIsDefault()
    {
        return isDefault;
    }
    @Override
    public void setIsDefault(Boolean isDefault)
    {
        this.isDefault = isDefault;
    }
}

