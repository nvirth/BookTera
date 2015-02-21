package utils;

import play.data.Form;

// Nincs használva
public class MyForm<T> extends Form<T>
{
    private final Class<T> backedType;

    public Class<T> getBackedType()
    {
        return backedType;
    }

    public MyForm(Class<T> clazz)
    {
        super(clazz);

        backedType = clazz;
    }


}
