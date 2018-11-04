package utils.Helpers;

import play.data.Form;
import play.data.validation.Constraints;
import utils.Annotations.CompareAtClient;
import utils.Annotations.DisplayName;
import utils.Annotations.Remote;
import utils.Annotations.StringLength;
import utils.ValidationConstants;

import java.lang.reflect.Field;
import java.util.List;

public class ValidationErrorHandler<T>
{
    // -- Ctors

    public ValidationErrorHandler(Class<T> clazz, String fieldName)
    {
        this.clazz = clazz;
        this.fieldName = fieldName;
    }

    public ValidationErrorHandler(Class<T> clazz, Form.Field fieldOnForm)
    {
        this.clazz = clazz;
        this.fieldOnForm = fieldOnForm;
    }

    // -- Input fields

    private Class<T> clazz;
    public Class<T> getClazz()
    {
        return clazz;
    }

    private Form.Field fieldOnForm;
    public Form.Field getFieldOnForm()
    {
        if (fieldOnForm == null)
            throw new RuntimeException("Form.Field was not set (via ctor). ");

        return fieldOnForm;
    }

    // -- Properties

    private String fieldName;
    public String getFieldName()
    {
        if (fieldName == null)
            fieldName = fieldOnForm.name();

        return fieldName;
    }

    private Field fieldOnClass;
    public Field getFieldOnClass()
    {
        if (fieldOnClass == null)
        {
            if (getFieldName().equals(""))
                return null;

            try
            {
                classRecursiveHelper classHelp =
                    new ValidationErrorHandler.classRecursiveHelper(getFieldName(), getClazz());

                fieldOnClass = classHelp.getClazz().getDeclaredField(classHelp.getFieldName());
            } catch (NoSuchFieldException e)
            {
                e.printStackTrace();
                throw new RuntimeException("NoSuchFieldException: " + getFieldName());
            }
        }

        return fieldOnClass;
    }

    private class classRecursiveHelper
    {
        private String fieldName;
        private Class clazz;

        private classRecursiveHelper(String fieldName, Class clazz) throws NoSuchFieldException
        {
            setClassRecursive(fieldName, clazz);
        }

        public String getFieldName()
        {
            return fieldName;
        }
        public Class getClazz()
        {
            return clazz;
        }

        private Class setClassRecursive(String fieldName, Class clazz) throws NoSuchFieldException
        {
            // fieldName e.g.: registerVm.userAddress.city

            String[] split = fieldName.split("\\.", 2);
            if (split.length == 1) // No more "." in the String, only the fieldName remains
            {
                this.fieldName = fieldName;
                this.clazz = clazz;

                return clazz;
            }

            Class innerClass = clazz.getDeclaredField(split[0]).getType();
            return setClassRecursive(split[1], innerClass);
        }
    }

    private String displayName;
    public String getDisplayName()
    {
        if (getFieldOnClass() == null) // No such field, manually added error message
            return "";

        DisplayName annotation = getFieldOnClass().getAnnotation(DisplayName.class);
        if (annotation == null)
            return getFieldOnClass().getName();

        return annotation.value() == null ? getFieldOnClass().getName() : annotation.value();
    }

    // --

    private String constraintName;
    public String getConstraintName()
    {
        if (constraintName == null)
            throw new RuntimeException("The constraintName property was not set (via calculateErrorMsg method) . ");

        return constraintName;
    }

    private ValidationConstants.ContraintNames constraintEnum;
    public ValidationConstants.ContraintNames getConstraintEnum()
    {
        if (constraintEnum == null)
            throw new RuntimeException("The error message was not calculated yet. ");

        return constraintEnum;
    }

    private String errorMsgFormat;
    public String getErrorMsgFormat()
    {
        if (errorMsgFormat == null)
            throw new RuntimeException("The error message was not calculated yet. ");

        return errorMsgFormat;
    }

    private String errorMsg;
    public String getErrorMsg()
    {
        if (errorMsg == null)
            throw new RuntimeException("The error message was not calculated yet. ");

        return errorMsg;
    }

    private Object[] errorArgs;
    public Object[] getErrorArgs()
    {
        if (errorArgs == null)
            throw new RuntimeException("The error message was not calculated yet. ");

        return errorArgs;
    }

    public String calculateErrorMsg(String constraintName)
    {
        this.constraintName = constraintName;
        this.constraintEnum = ValidationConstants.ContraintNames.fromString(constraintName);
        if (constraintEnum == null)
            throw new RuntimeException("The calculateErrorMsg method is not implemented yet for: " + constraintName);

        String format;
        Object[] args = null;

        switch (constraintEnum)
        {
            case Required:
                Constraints.Required annRequired = getFieldOnClass().getAnnotation(Constraints.Required.class);
                format = annRequired.message();
                break;

            case MaxLength:
                Constraints.MaxLength annMaxLength = getFieldOnClass().getAnnotation(Constraints.MaxLength.class);
                format = annMaxLength.message();
                args = new Object[]{annMaxLength.value()};
                break;

            case MinLength:
                Constraints.MinLength annMinLength = getFieldOnClass().getAnnotation(Constraints.MinLength.class);
                format = annMinLength.message();
                args = new Object[]{annMinLength.value()};
                break;

            case StringLength:
                StringLength annStringLength = getFieldOnClass().getAnnotation(StringLength.class);
                format = annStringLength.message();
                args = new Object[]{annStringLength.max(), annStringLength.min()};
                break;

            case Remote:
                Remote annRemote = getFieldOnClass().getAnnotation(Remote.class);
                format = annRemote.message();
                args = new Object[]{annRemote.url(), annRemote.httpMethod()};
                break;

            case Email:
                Constraints.Email annEmail = getFieldOnClass().getAnnotation(Constraints.Email.class);
                format = annEmail.message();
                break;

            case Pattern:
                Constraints.Pattern annPattern = getFieldOnClass().getAnnotation(Constraints.Pattern.class);
                format = annPattern.message();
                args = new Object[]{annPattern.value()};
                break;

            case CompareAtClient:
                CompareAtClient annCompare = getFieldOnClass().getAnnotation(CompareAtClient.class);
                format = annCompare.message();
                args = new Object[]{annCompare.other()};
                break;

            case Min:
                Constraints.Min annMin = getFieldOnClass().getAnnotation(Constraints.Min.class);
                format = annMin.message();
                args = new Object[]{annMin.value()};
                break;

            case Max:
            default:
                throw new RuntimeException("The calculateErrorMsg method is not implemented yet for: " + constraintName);
        }

        calculateErrorMsg(format, args);
        return getErrorMsg();
    }

    public String calculateErrorMsg(String format, List<Object> args)
    {
        return calculateErrorMsg(format, args.toArray());
    }
    public String calculateErrorMsg(String format, Object... args)
    {
        int length = args == null ? 1 : args.length + 1;

        this.errorMsgFormat = format;

        this.errorArgs = new Object[length];
        this.errorArgs[0] = getDisplayName();

        for (int i = 1; i < length; i++)
            this.errorArgs[i] = args[i - 1];

        this.errorMsg = String.format(format, this.errorArgs);
        return this.errorMsg;
    }
}
