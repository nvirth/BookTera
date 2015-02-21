package models.Search;

import com.booktera.data.CommonPortable_Models_ProductModels.BookBlockPLVM;
import models.Search.Partial.DetailedSearchInputsVm;
import play.data.Form;

public class DetailedSearchVm
{
    public Form<DetailedSearchInputsVm> SearchInputs;
    public BookBlockPLVM SearchResults;

    public DetailedSearchVm()
    {
        SearchInputs = Form.form(DetailedSearchInputsVm.class);
    }

    public DetailedSearchVm(Form<DetailedSearchInputsVm> searchInputs)
    {
        SearchInputs = searchInputs;
    }

    public DetailedSearchVm(Form<DetailedSearchInputsVm> searchInputs, BookBlockPLVM searchResults)
    {
        SearchInputs = searchInputs;
        SearchResults = searchResults;
    }
}
