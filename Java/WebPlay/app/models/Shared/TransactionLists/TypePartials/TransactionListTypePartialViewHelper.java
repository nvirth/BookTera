package models.Shared.TransactionLists.TypePartials;

import models.Shared.TransactionLists.TransactionListViewHelper;
import play.mvc.Http;
import utils.Utils;

import java.text.NumberFormat;
import java.util.Locale;

public class TransactionListTypePartialViewHelper extends TransactionListViewHelper
{
    public boolean hasAddress;
    public boolean hasExchange;
    public boolean needFeedback;

    // --

    public String toCurrency(String viewBagKey)
    {
        Object item = Http.Context.current().args.get(viewBagKey);

        Integer num = null;
        if (item.getClass().equals(int.class) || item instanceof Integer)
            num = (Integer)item;
        else if(item instanceof String)
            num = Utils.parseInteger((String)item);

        if(num == null)
            throw new RuntimeException("The 'toCurrency' method is not implemented for this type: " + item.getClass());

        String format = Utils.currencyFormatterHu.format(num);
        return format;
    }
}
