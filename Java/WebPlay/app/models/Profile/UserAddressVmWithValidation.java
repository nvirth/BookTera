package models.Profile;

import play.data.validation.Constraints;
import utils.Annotations.DisplayName;

import static utils.ValidationConstants.*;

public class UserAddressVmWithValidation extends UserAddressVm
    {
        @Constraints.Required(message = Required)
        @Constraints.MaxLength(value = 100, message = MaxLength)
        @Constraints.Pattern( value = RegEx_START_Digit_4T4_END, message = RegExErrMsg_START_Digit_4T4_END)
        @DisplayName("Irányítószám")
        private String zipCode;

        @Constraints.Required(message = Required)
        @Constraints.MaxLength(value = 100, message = MaxLength)
        @Constraints.Pattern( value = RegEx_START_HuChar_HuCharOrSpace_0Ti_END, message = RegExErrMsg_START_HuChar_HuCharOrSpace_0Ti_END)
        @DisplayName("Település")
        private String city;

        @Constraints.Required(message = Required)
        @Constraints.MaxLength(value = 100, message = MaxLength)
        @Constraints.Pattern( value = RegEx_START_HuChar_HuCharOrDigitOrSeparator_0Ti_END, message = RegExErrMsg_START_HuChar_HuCharOrDigitOrSeparator_0Ti_END)
        @DisplayName("Utca, házszám")
        private String streetAndHouseNumber;

        @Constraints.Required(message = Required)
        @Constraints.MaxLength(value = 100, message = MaxLength)
        @Constraints.Pattern( value = RegEx_START_HuChar_HuCharOrSpace_0Ti_END, message = RegExErrMsg_START_HuChar_HuCharOrSpace_0Ti_END)
        @DisplayName("Ország")
        private String country;

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
    }
