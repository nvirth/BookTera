package utils;

import play.data.format.Formatters;

import java.util.Locale;

public class StringFormatter extends Formatters.SimpleFormatter<String>
{
    @Override
    public String parse(String text, Locale locale) throws java.text.ParseException
    {
        if (text == null || text.isEmpty())
            return null;

        return text;
    }

    @Override
    public String print(String text, Locale locale)
    {
        if (text == null)
            return "";

        return text;
    }
}