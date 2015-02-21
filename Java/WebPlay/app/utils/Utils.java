package utils;

import com.booktera.data.UtilsShared.SelectListItemWithClass;
import com.fasterxml.jackson.databind.JsonNode;
import models.Account.LoginVM;
import play.api.templates.Html;
import play.data.Form;
import play.data.Form.*;
import play.data.validation.Constraints;
import play.data.validation.ValidationError;
import play.libs.F;
import play.libs.Json;
import play.mvc.Http;
import play.mvc.Http.*;
import utils.HelperModels.SelectListItemWithClass_ForJson;

import java.lang.reflect.*;
import java.lang.reflect.Field;
import java.net.HttpCookie;
import java.text.NumberFormat;
import java.text.SimpleDateFormat;
import java.util.*;
import java.util.stream.Collectors;

public class Utils
{
    public static SimpleDateFormat dateFormatterShort = new SimpleDateFormat("yyyy.MM.dd");
    public static NumberFormat currencyFormatterHu = NumberFormat.getCurrencyInstance(Locale.forLanguageTag("HU-HU"));

    /**
     * Check if the request was made via Ajax or not
     *
     * @return
     */
    public static Boolean isAjax()
    {
        Request request = Context.current().request();

        String requestWithHeader = "X-Requested-With";
        String requestWithHeaderValueForAjax = "XMLHttpRequest";

        String[] value = request.headers().get(requestWithHeader);
        return
            value != null &&
                value.length > 0 &&
                value[0].equals(requestWithHeaderValueForAjax);
    }

    public static Boolean isPost()
    {
        Request request = Context.current().request();

        if (request.method().toUpperCase().equals("POST"))
            return true;

        return false;
    }

    public static Boolean isGet()
    {
        Request request = Context.current().request();

        if (request.method().toUpperCase().equals("GET"))
            return true;

        return false;
    }

    public static String truncate(String text, int maxLetters)
    {
        if (text.length() > maxLetters)
            return text.substring(0, maxLetters - 1) + "...";
        else
            return text;
    }

    public static Integer parseInteger(String text)
    {
        return parseIntegerOr(text, null);
    }
    public static Integer parseIntegerOr(String text, Integer defaultValue)
    {
        Integer result = defaultValue;
        if (text != null && !text.isEmpty())
            result = Integer.parseInt(text);

        return result;
    }

    public static Boolean parseBoolean(String text)
    {
        return parseBooleanOr(text, null);
    }
    public static Boolean parseBooleanOr(String text, Boolean defaultValue)
    {
        Boolean result = defaultValue;
        if (text != null && !text.isEmpty())
            result = Boolean.parseBoolean(text);

        return result;
    }

    public static String getActionName()
    {
        String[] paths = Http.Context.current().request().path()
            .split("/", 4); // "" "controller" "action" "..."?

        if (paths.length >= 3)
            return paths[2];
        else
            return "Index";
    }
    public static String getControllerName()
    {
        String[] paths = Http.Context.current().request().path()
            .split("/", 4); // "" "controller" "action" "..."?

        return paths[1];
    }

    public static JsonNode toJson(SelectListItemWithClass[] selectList)
    {
        List<SelectListItemWithClass_ForJson> result = Arrays.stream(selectList)
            .map(SelectListItemWithClass_ForJson::new)
            .collect(Collectors.toList());

        return Json.toJson(result);
    }

    public static int getCurrentUserId()
    {
        String str = Context.current().session().get(Config.SESSION_USER_ID);
        int currentUserId = Integer.parseInt(str);
        return currentUserId;
    }
}
