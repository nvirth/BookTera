package models.Shared.BookBlocksRows.Partials;

import com.booktera.data.CommonPortable_Enums.BookBlockType;

public class MainButtonsPartialVM
{
    private String userName;
    private int howMany;
    private int productId;
    private BookBlockType bookBlockType;
    private int productInOrderId;
    private int userOrderId;

    // -- Getters, Setters

    public String getUserName()
    {
        return userName;
    }

    public void setUserName(String userName)
    {
        this.userName = userName;
    }

    public int getHowMany()
    {
        return howMany;
    }

    public void setHowMany(int howMany)
    {
        this.howMany = howMany;
    }

    public int getProductId()
    {
        return productId;
    }

    public void setProductId(int productId)
    {
        this.productId = productId;
    }

    public BookBlockType getBookBlockType()
    {
        return bookBlockType;
    }

    public void setBookBlockType(BookBlockType bookBlockType)
    {
        this.bookBlockType = bookBlockType;
    }

    public int getProductInOrderId()
    {
        return productInOrderId;
    }

    public void setProductInOrderId(int productInOrderId)
    {
        this.productInOrderId = productInOrderId;
    }

    public int getUserOrderId()
    {
        return userOrderId;
    }

    public void setUserOrderId(int userOrderId)
    {
        this.userOrderId = userOrderId;
    }
}
