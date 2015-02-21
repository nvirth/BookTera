package models.Profile;

import com.booktera.data.CommonModels_Models.UserAddressVM;
import com.booktera.data.CommonModels_Models_EntityFramework.UserGroup;
import com.booktera.data.CommonModels_Models_EntityFramework.UserProfile;
import org.apache.axis.types.UnsignedByte;
import utils.Annotations.DisplayName;

import java.lang.Integer;
import java.lang.String;

public class UserGroupVm extends UserGroup
{
    @DisplayName("Vásárlási jutalék")
    private UnsignedByte buyFeePercent;

    @DisplayName("Név")
    private String groupName;

    @DisplayName("Hónap")
    private UnsignedByte monthsToKeepBooks;

    @DisplayName("Ár")
    private Integer price;

    @DisplayName("Eladási jutalék")
    private UnsignedByte sellFeePercent;

    private Integer ID;

    // Ctors

    public UserGroupVm(UserGroup userGroup)
    {
        this.buyFeePercent = userGroup.getBuyFeePercent();
        this.groupName = userGroup.getGroupName();
        this.monthsToKeepBooks = userGroup.getMonthsToKeepBooks();
        this.price = userGroup.getPrice();
        this.sellFeePercent = userGroup.getSellFeePercent();
        this.ID = userGroup.getID();
    }

    public UserGroupVm()
    {
    }

    // -- Getters, Setters

    @Override
    public UnsignedByte getBuyFeePercent()
    {
        return buyFeePercent;
    }
    @Override
    public void setBuyFeePercent(UnsignedByte buyFeePercent)
    {
        this.buyFeePercent = buyFeePercent;
    }
    @Override
    public String getGroupName()
    {
        return groupName;
    }
    @Override
    public void setGroupName(String groupName)
    {
        this.groupName = groupName;
    }
    @Override
    public Integer getID()
    {
        return ID;
    }
    @Override
    public void setID(Integer ID)
    {
        this.ID = ID;
    }
    @Override
    public UnsignedByte getMonthsToKeepBooks()
    {
        return monthsToKeepBooks;
    }
    @Override
    public void setMonthsToKeepBooks(UnsignedByte monthsToKeepBooks)
    {
        this.monthsToKeepBooks = monthsToKeepBooks;
    }
    @Override
    public Integer getPrice()
    {
        return price;
    }
    @Override
    public void setPrice(Integer price)
    {
        this.price = price;
    }
    @Override
    public UnsignedByte getSellFeePercent()
    {
        return sellFeePercent;
    }
    @Override
    public void setSellFeePercent(UnsignedByte sellFeePercent)
    {
        this.sellFeePercent = sellFeePercent;
    }
}

