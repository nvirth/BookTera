package models.Search.Partial;

import com.booktera.data.CommonModels_Models.DetailedSearchVMDetailedSearchInputs;
import utils.Annotations.DisplayName;

import java.lang.Boolean;
import java.lang.Integer;
import java.lang.String;

public class DetailedSearchInputsVm extends DetailedSearchVMDetailedSearchInputs
{
    @DisplayName("Keresőkifejezés")
    private String SearchingText;

    @DisplayName("Szerző")
    private String Author;

    @DisplayName("Kiadó")
    private String Publisher;

    @DisplayName("Cím")
    private String Title;

    @DisplayName("Alcím")
    private String Subtitle;

    @DisplayName("Leírás")
    private String Description;

    @DisplayName("Kiadás éve")
    private Integer PublishYearFrom;
    private Integer PublishYearTo;

    @DisplayName("Oldalszám")
    private Integer PageNumberFrom;
    private Integer PageNumberTo;

    @DisplayName("Ár")
    private Integer PriceFrom;
    private Integer PriceTo;

    @DisplayName("Csak letölthető")
    private Boolean IsDownloadable;

    @DisplayName("Csak nem letölthető")
    private Boolean IsUsed;

    @DisplayName("Szűrés könyvekre")
    private Boolean IsBook;

    @DisplayName("Szűrés hangoskönyvekre")
    private Boolean IsAudio;

    @DisplayName("Szűrés videókra")
    private Boolean IsVideo;

    @DisplayName("Kategória")
    private Integer CategoryId;

    // Getters, Setters

    @Override
	public String getSearchingText()
    {
        return SearchingText;
    }
    @Override
	public void setSearchingText(String searchingText)
    {
        SearchingText = searchingText;
    }
    @Override
	public String getAuthor()
    {
        return Author;
    }
    @Override
	public void setAuthor(String author)
    {
        Author = author;
    }
    @Override
	public String getPublisher()
    {
        return Publisher;
    }
    @Override
	public void setPublisher(String publisher)
    {
        Publisher = publisher;
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
	public String getSubtitle()
    {
        return Subtitle;
    }
    @Override
	public void setSubtitle(String subtitle)
    {
        Subtitle = subtitle;
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
	public Integer getPublishYearFrom()
    {
        return PublishYearFrom;
    }
    @Override
	public void setPublishYearFrom(Integer publishYearFrom)
    {
        PublishYearFrom = publishYearFrom;
    }
    @Override
	public Integer getPublishYearTo()
    {
        return PublishYearTo;
    }
    @Override
	public void setPublishYearTo(Integer publishYearTo)
    {
        PublishYearTo = publishYearTo;
    }
    @Override
	public Integer getPageNumberFrom()
    {
        return PageNumberFrom;
    }
    @Override
	public void setPageNumberFrom(Integer pageNumberFrom)
    {
        PageNumberFrom = pageNumberFrom;
    }
    @Override
	public Integer getPageNumberTo()
    {
        return PageNumberTo;
    }
    @Override
	public void setPageNumberTo(Integer pageNumberTo)
    {
        PageNumberTo = pageNumberTo;
    }
    @Override
	public Integer getPriceFrom()
    {
        return PriceFrom;
    }
    @Override
	public void setPriceFrom(Integer priceFrom)
    {
        PriceFrom = priceFrom;
    }
    @Override
	public Integer getPriceTo()
    {
        return PriceTo;
    }
    @Override
	public void setPriceTo(Integer priceTo)
    {
        PriceTo = priceTo;
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
	public Integer getCategoryId()
    {
        return CategoryId;
    }
    @Override
	public void setCategoryId(Integer categoryId)
    {
        CategoryId = categoryId;
    }
}
