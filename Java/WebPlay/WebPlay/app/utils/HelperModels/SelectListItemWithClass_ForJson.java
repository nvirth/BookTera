package utils.HelperModels;

import com.booktera.data.UtilsShared.SelectListItemWithClass;

import java.lang.Boolean;
import java.lang.String;

public class SelectListItemWithClass_ForJson
{
    public Boolean Selected;
    public String Text;
    public String Value;
    public String Class;

    public SelectListItemWithClass_ForJson(SelectListItemWithClass core)
    {
        Selected = core.getSelected();
        Text = core.getText();
        Value = core.getValue();
        Class = core.get_class();
    }
}
