package models.Sell;

import com.booktera.data.CommonModels_Models_ProductModels.CreatePVMProductVM;
import play.data.validation.Constraints.*;
import utils.Annotations.DisplayName;
import utils.ValidationConstants;

import static utils.ValidationConstants.*;

public class CreateProductVm extends CreatePVMProductVM
{
    // String

    @DisplayName("Nyelv")
    @Required(message = Required)
    @Pattern(value = RegEx_START_HuChar_HuCharOrSpace_0Ti_END, message = RegExErrMsg_START_HuChar_HuCharOrSpace_0Ti_END)
    @MaxLength(value = 50, message = MaxLength)
    private String Language;

    @DisplayName("Leírás")
    @Required(message = Required)
    private String Description;

    @DisplayName("Kép feltöltése")
    // Validation in Controller and Manager
    private String ImageUrl;

    // Number

    @DisplayName("Kiadás éve")
    @Required(message = Required)
    @Pattern(value = RegEx_Number, message = RegExErrMsg_Number)
    @Min(value = 1, message = Min)
    private Integer PublishYear;

    @DisplayName("Oldalszám")
    @Required(message = Required)
    @Pattern(value = RegEx_Number, message = RegExErrMsg_Number)
    @Min(value = 1, message = Min)
    private Integer PageNumber;

    @DisplayName("Ár")
    @Required(message = Required)
    @Pattern(value = RegEx_Number, message = RegExErrMsg_Number)
    @Min(value = 1, message = Min)
    private Integer Price;

    @DisplayName("Mennyiség")
    @Required(message = Required)
    @Pattern(value = RegEx_Number, message = RegExErrMsg_Number)
    @Min(value = 1, message = Min)
    private Integer HowMany;

    @DisplayName("Kiadás száma")
    @Required(message = Required)
    @Pattern(value = RegEx_Number, message = RegExErrMsg_Number)
    @Min(value = 1, message = Min)
    private Integer Edition;

    // Flag - Validation in Controller and Manager

    @DisplayName("Könyv")
    private Boolean IsBook;

    @DisplayName("Hangoskönyv")
    private Boolean IsAudio;

    @DisplayName("Videó")
    private Boolean IsVideo;

    @DisplayName("Használt")
    private Boolean IsUsed;

    @DisplayName("Elektronikus")
    private Boolean IsDownloadable;

    // -- Getters, Setters

    @Override
	public String getLanguage()
    {
        return Language;
    }
    @Override
	public void setLanguage(String language)
    {
        Language = language;
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
    @Override
	public Integer getPublishYear()
    {
        return PublishYear;
    }
    @Override
	public void setPublishYear(Integer publishYear)
    {
        PublishYear = publishYear;
    }
    @Override
	public Integer getPageNumber()
    {
        return PageNumber;
    }
    @Override
	public void setPageNumber(Integer pageNumber)
    {
        PageNumber = pageNumber;
    }
    @Override
	public Integer getPrice()
    {
        return Price;
    }
    @Override
	public void setPrice(Integer price)
    {
        Price = price;
    }
    @Override
	public Integer getHowMany()
    {
        return HowMany;
    }
    @Override
	public void setHowMany(Integer howMany)
    {
        HowMany = howMany;
    }
    @Override
	public Integer getEdition()
    {
        return Edition;
    }
    @Override
	public void setEdition(Integer edition)
    {
        Edition = edition;
    }
    @Override
	public Boolean getIsBook()
    {
        return IsBook;
    }
    @Override
	public void setIsBook(Boolean isBook)
    {
        IsBook = isBook;
    }
    @Override
	public Boolean getIsAudio()
    {
        return IsAudio;
    }
    @Override
	public void setIsAudio(Boolean isAudio)
    {
        IsAudio = isAudio;
    }
    @Override
	public Boolean getIsVideo()
    {
        return IsVideo;
    }
    @Override
	public void setIsVideo(Boolean isVideo)
    {
        IsVideo = isVideo;
    }
    @Override
	public Boolean getIsUsed()
    {
        return IsUsed;
    }
    @Override
	public void setIsUsed(Boolean isUsed)
    {
        IsUsed = isUsed;
    }
    @Override
	public Boolean getIsDownloadable()
    {
        return IsDownloadable;
    }
    @Override
	public void setIsDownloadable(Boolean isDownloadable)
    {
        IsDownloadable = isDownloadable;
    }
}