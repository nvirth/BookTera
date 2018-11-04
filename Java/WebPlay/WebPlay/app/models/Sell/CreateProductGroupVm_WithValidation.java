package models.Sell;

import com.booktera.data.CommonModels_Models_ProductModels.CreatePVMProductGroupVM;
import play.data.validation.Constraints.*;
import utils.Annotations.DisplayName;

import static utils.ValidationConstants.*;

public class CreateProductGroupVm_WithValidation extends CreatePVMProductGroupVM
{
    @DisplayName("Melyik könyv?")
    private Integer Id;

    @DisplayName("Kategória")
    @Required(message = Required)
    private Integer CategoryId;

    @DisplayName("Kiadó")
    @Pattern(value = RegEx_START_HuChar_HuCharOrSpace_0Ti_END, message = RegExErrMsg_START_HuChar_HuCharOrSpace_0Ti_END)
    @MaxLength(value = 100, message = MaxLength)
    @Required(message = Required)
    private String PublisherName;

    @DisplayName("Szerző(k)")
    @Pattern(value = RegEx_START_HuChar_HuCharOrSpaceOrComma_0Ti_END, message = RegExErrMsg_START_HuChar_HuCharOrSpaceOrComma_0Ti_END)
    @MaxLength(value = 100, message = MaxLength)
    @Required(message = Required)
    private String AuthorNames;

    @DisplayName("Cím")
    @MaxLength(value = 100, message = MaxLength)
    @Required(message = Required)
    private String Title;

    @DisplayName("Alcím")
    @MaxLength(value = 100, message = MaxLength)
    private String SubTitle;

    @DisplayName("Leírás")
    @Required(message = Required)
    private String Description;

    @DisplayName("Kép feltöltése")
    // Validation in Controller and Manager
    private String ImageUrl;

    // -- Getters, Setters

    @Override
    public Integer getId()
    {
        return Id;
    }
    @Override
    public void setId(Integer id)
    {
        Id = id;
    }
    @Override
    public Integer getCategoryId()
    {
        return CategoryId;
    }
    @Override
    public void setCategoryId(Integer categoryId)
    {
        CategoryId = categoryId;
    }
    @Override
    public String getPublisherName()
    {
        return PublisherName;
    }
    @Override
    public void setPublisherName(String publisherName)
    {
        PublisherName = publisherName;
    }
    @Override
    public String getAuthorNames()
    {
        return AuthorNames;
    }
    @Override
    public void setAuthorNames(String authorNames)
    {
        AuthorNames = authorNames;
    }
    @Override
    public String getTitle()
    {
        return Title;
    }
    @Override
    public void setTitle(String title)
    {
        Title = title;
    }
    @Override
    public String getSubTitle()
    {
        return SubTitle;
    }
    @Override
    public void setSubTitle(String subTitle)
    {
        SubTitle = subTitle;
    }
    @Override
    public String getDescription()
    {
        return Description;
    }
    @Override
    public void setDescription(String description)
    {
        Description = description;
    }
    @Override
    public String getImageUrl()
    {
        return ImageUrl;
    }
    @Override
    public void setImageUrl(String imageUrl)
    {
        ImageUrl = imageUrl;
    }
}
