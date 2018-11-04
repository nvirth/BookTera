package models.Shared.TransactionLists;

import play.mvc.Http;

import java.util.Map;

public class TransactionListViewHelper
{
    public boolean isBuy;
    public String titlePre;
    public String siteTitle;

    public Map<String,Object> viewData = Http.Context.current().args;

    public void viewDataPutSilent(String key, Object value){
        viewData.put(key, value);
    }
}
