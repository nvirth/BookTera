package models.Search.Partial;

import play.data.Form;

public class DetailedSearchViewHelper
{
    private Form<DetailedSearchInputsVm> core;

    public DetailedSearchViewHelper(Form<DetailedSearchInputsVm> core)
    {
        this.core = core;

        IsDownloadable = parseBool("IsDownloadable");
        IsUsed = parseBool("IsUsed");
        IsBook = parseBool("IsBook");
        IsAudio = parseBool("IsAudio");
        IsVideo = parseBool("IsVideo");
    }

    private Boolean parseBool(String fieldName)
    {
        String boolStr = core.apply(fieldName).value();
        if (boolStr == null || boolStr.isEmpty())
            return null;

        boolean bool = Boolean.parseBoolean(boolStr);
        return bool;
    }

    // IsDownloadable

    private Boolean IsDownloadable;

    public String isDownloadable_Null()
    {
        if (IsDownloadable == null)
            return "\" checked=\"checked ";
        return "";
    }
    public String isDownloadable_False()
    {
        if (IsUsed != null && !IsDownloadable)
            return "\" checked=\"checked ";
        return "";
    }
    public String isDownloadable_True()
    {
        if (IsUsed != null && IsDownloadable)
            return "\" checked=\"checked ";
        return "";
    }

    // IsUsed

    private Boolean IsUsed;

    public String isUsed_Null()
    {
        if (IsUsed == null)
            return "\" checked=\"checked ";
        return "";
    }
    public String isUsed_False()
    {
        if (IsUsed != null && !IsUsed)
            return "\" checked=\"checked ";
        return "";
    }
    public String isUsed_True()
    {
        if (IsUsed != null && IsUsed)
            return "\" checked=\"checked ";
        return "";
    }

    // Non-nullable booleans

    private Boolean IsBook;
    private Boolean IsAudio;
    private Boolean IsVideo;

    public String isBookChecked()
    {
        if (IsBook != null && IsBook)
            return "\" checked=\"checked ";
        return "";
    }
    public String isAudioChecked()
    {
        if (IsAudio != null && IsAudio)
            return "\" checked=\"checked ";
        return "";
    }
    public String isVideoChecked()
    {
        if (IsVideo != null && IsVideo)
            return "\" checked=\"checked ";
        return "";
    }
}
