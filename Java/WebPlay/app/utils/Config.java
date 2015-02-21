package utils;

import play.mvc.Http;

public class Config
{
    public static final int ProductsPerPage = 8;
    public static final String MainTitleOfSite = "BookTera";
    public static final String NoAuthFunction = "Ezt a funkciót csak bejelentkezett felhasználók érhetik el";
    public static final int AutoCompleteResultCount = 8;
    public static final int NewestHowMany = 32;

    public static final String SESSION_USER_NAME = "UserName";
    public static final String SESSION_USER_ID = "UserId";
    public static final String SESSION_USER_IMAGE = "UserImage";
    public static final String COOKIE_ASPXAUTH = ".ASPXAUTH";

    public static boolean isUserAuthenticated()
    {
        return Http.Context.current().session().get(SESSION_USER_NAME) != null;
    }

}
