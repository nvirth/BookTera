package utils.Helpers;

import play.api.templates.Html;
import play.data.Form;
import play.data.validation.ValidationError;
import play.libs.F;
import play.mvc.Http;

import java.util.*;

public class HtmlHelpers
{
    // -- InputText

    public static <T> Html inputText(Form.Field field, Class<T> clazz)
    {
        return inputText(field, clazz, "");
    }
    public static <T> Html inputText(Form.Field field, Class<T> clazz, String htmlClass)
    {
        return inputText(field, clazz, htmlClass, "");
    }
    public static <T> Html inputText(Form.Field field, Class<T> clazz, String htmlClass, String htmlAttributes)
    {
        return input(field, clazz, htmlClass, htmlAttributes, "text", /*withValue*/ true, /*withDivsAround*/ false, /*withValidationSpan*/ false);
    }

    public static <T> Html inputTextWithErrors(Form.Field field, Class<T> clazz, String htmlClass)
    {
        return inputTextWithErrors(field, clazz, htmlClass, "");
    }
    public static <T> Html inputTextWithErrors(Form.Field field, Class<T> clazz, String htmlClass, String htmlAttributes)
    {
        return input(field, clazz, htmlClass, htmlAttributes, "text", /*withValue*/ true, /*withDivsAround*/ false, /*withValidationSpan*/ true);
    }

    public static <T> Html inputTextFull(Form.Field field, Class<T> clazz)
    {
        return inputTextFull(field, clazz, "");
    }
    public static <T> Html inputTextFull(Form.Field field, Class<T> clazz, String htmlClass)
    {
        return inputTextFull(field, clazz, htmlClass, "");
    }
    public static <T> Html inputTextFull(Form.Field field, Class<T> clazz, String htmlClass, String htmlAttributes)
    {
        return input(field, clazz, htmlClass, htmlAttributes, "text", /*withValue*/ true, /*withDivsAround*/ true, /*withValidationSpan*/ true);
    }

    // -- InputPassword

    public static <T> Html inputPasswordFull(Form.Field field, Class<T> clazz, String htmlClass)
    {
        return inputPasswordFull(field, clazz, htmlClass, "");
    }
    public static <T> Html inputPasswordFull(Form.Field field, Class<T> clazz, String htmlClass, String htmlAttributes)
    {
        return input(field, clazz, htmlClass, htmlAttributes, "password", /*withValue*/ false, /*withDivsAround*/ true, /*withValidationSpan*/ true);
    }

    // -- InputEmail

    public static <T> Html inputEmailFull(Form.Field field, Class<T> clazz)
    {
        return inputEmailFull(field, clazz, "");
    }
    public static <T> Html inputEmailFull(Form.Field field, Class<T> clazz, String htmlClass)
    {
        return inputEmailFull(field, clazz, htmlClass, "");
    }
    public static <T> Html inputEmailFull(Form.Field field, Class<T> clazz, String htmlClass, String htmlAttributes)
    {
        return input(field, clazz, htmlClass, htmlAttributes, "email", /*withValue*/ true, /*withDivsAround*/ true, /*withValidationSpan*/ true);
    }

    // -- TextArea

    public static <T> Html textAreaFull(Form.Field field, Class<T> clazz)
    {
        return textAreaFull(field, clazz, "");
    }
    public static <T> Html textAreaFull(Form.Field field, Class<T> clazz, String htmlClass)
    {
        return textAreaFull(field, clazz, htmlClass, "");
    }
    public static <T> Html textAreaFull(Form.Field field, Class<T> clazz, String htmlClass, String htmlAttributes)
    {
        return input(field, clazz, htmlClass, htmlAttributes, "textarea", /*withValue*/ true, /*withDivsAround*/ true, /*withValidationSpan*/ true);
    }

    public static <T> Html textArea(Form.Field field, Class<T> clazz)
    {
        return textArea(field, clazz, "");
    }
    public static <T> Html textArea(Form.Field field, Class<T> clazz, String htmlClass)
    {
        return textArea(field, clazz, htmlClass, "");
    }
    public static <T> Html textArea(Form.Field field, Class<T> clazz, String htmlClass, String htmlAttributes)
    {
        return input(field, clazz, htmlClass, htmlAttributes, "textarea", /*withValue*/ true, /*withDivsAround*/ false, /*withValidationSpan*/ false);
    }

    // -- Input

    public static <T> Html input(Form.Field field, Class<T> clazz, String htmlClass, String htmlAttributes, String type, boolean withValue, boolean withDivsAround, boolean withValidationSpan)
    {
        String value = getValue(withValue, field.value(), field.name());
        String classIfInvalid = field.errors().isEmpty() ? "" : " input-validation-error";
        boolean isTextArea = type.toLowerCase().equals("textarea");

        ValidationErrorHandler<T> validationHandler = new ValidationErrorHandler<T>(clazz, field);

        StringBuilder sb = new StringBuilder();

        if (withDivsAround)
        {
            sb.append("<div class=\"editor-label\">");
            sb.append("<label for=\"").append(field.name()).append("\">")
                .append(validationHandler.getDisplayName())
                .append("</label>");
            sb.append("</div>");
            sb.append("<div class=\"editor-field\">");
        }

        if (isTextArea)
            sb.append("<textarea");
        else
            sb.append("<input")
                .append(" type=\"").append(type).append("\"")
                .append(" value=\"").append(value).append("\"");

        sb.append(" name=\"").append(field.name()).append("\"")
            .append(" id=\"").append(field.name()).append("\"")
            .append(" class=\"").append(htmlClass).append(classIfInvalid).append("\"")
            .append(" ").append(htmlAttributes).append(" ");
        generateJqueryValidationAttributes(sb, validationHandler);
        sb.append(">");

        if (isTextArea)
            sb.append(value)
                .append("</textarea>");

        if (withValidationSpan)
            errorsFor(sb, validationHandler);

        if (withDivsAround)
            sb.append("</div>");

        return Html.apply(sb.toString());
    }
    public static String getValue(boolean withValue, String fieldValue, String fieldName)
    {
        if (!withValue)
            return "";

        if (fieldValue != null && !fieldValue.isEmpty())
            return fieldValue;

        String fieldNameLower = fieldName.substring(0, 1).toLowerCase() + fieldName.substring(1, fieldName.length());
        String fieldNameUpper = fieldName.substring(0, 1).toUpperCase() + fieldName.substring(1, fieldName.length());


        Object argsValue = Http.Context.current().args.get(fieldNameLower);
        if (argsValue != null) // If there is here something, we've put it there
            return argsValue.toString();

        argsValue = Http.Context.current().args.get(fieldNameUpper);
        if (argsValue != null) // If there is here something, we've put it there
            return argsValue.toString();


        String flashValue = Http.Context.current().flash().get(fieldNameLower);
        if (flashValue != null) // If there is here something, we've put it there
            return flashValue;

        flashValue = Http.Context.current().flash().get(fieldNameUpper);
        if (flashValue != null) // If there is here something, we've put it there
            return flashValue;


        String requestValue = Form.form().bindFromRequest(fieldName).get(fieldNameLower);
        if (requestValue != null && !requestValue.isEmpty())
            return requestValue;

        requestValue = Form.form().bindFromRequest(fieldName).get(fieldNameUpper);
        if (requestValue != null && !requestValue.isEmpty())
            return requestValue;


        return "";
    }

    private static <T> void generateJqueryValidationAttributes(StringBuilder sb, ValidationErrorHandler<T> validationHandler)
    {
        Form.Field field = validationHandler.getFieldOnForm();

        if (!field.constraints().isEmpty())
            sb.append(" data-val=\"true\"");

        for (F.Tuple<String, List<Object>> tuple : field.constraints())
        {
            String constraint = tuple._1;
            String errorMsg = validationHandler.calculateErrorMsg(constraint);

            switch (validationHandler.getConstraintEnum())
            {
                case Required:
                    sb.append(" data-val-required=\" ").append(errorMsg).append("\"");
                    break;

                case MaxLength:
                    sb
                        .append(" data-val-length=\" ").append(errorMsg).append("\"")
                        .append(" data-val-length-max=\"").append(validationHandler.getErrorArgs()[1]).append("\"");
                    break;

                case MinLength:
                    sb
                        .append(" data-val-length=\" ").append(errorMsg).append("\"")
                        .append(" data-val-length-min=\"").append(validationHandler.getErrorArgs()[1]).append("\"");
                    break;

                case StringLength:
                    sb
                        .append(" data-val-length=\" ").append(errorMsg).append("\"")
                        .append(" data-val-length-max=\"").append(validationHandler.getErrorArgs()[1]).append("\"")
                        .append(" data-val-length-min=\"").append(validationHandler.getErrorArgs()[2]).append("\"");
                    break;

                case Remote:
                    sb
                        .append(" data-val-remote=\" ").append(errorMsg).append("\"")
                        .append(" data-val-remote-additionalfields=\"*.").append(field.name()).append("\"")
                        .append(" data-val-remote-url=\"").append(validationHandler.getErrorArgs()[1]).append("\"")
                        .append(" data-val-remote-type=\"").append(validationHandler.getErrorArgs()[2]).append("\"");
                    break;

                case Email:
                    sb.append(" data-val-email=\" ").append(errorMsg).append("\"");
                    break;

                case Pattern:
                    sb
                        .append(" data-val-regex=\" ").append(errorMsg).append("\"")
                        .append(" data-val-regex-pattern=\"").append(validationHandler.getErrorArgs()[1]).append("\"");
                    break;

                case CompareAtClient:
                    sb
                        .append(" data-val-equalto=\" ").append(errorMsg).append("\"")
                        .append(" data-val-equalto-other=\"*.").append(validationHandler.getErrorArgs()[1]).append("\"");
                    break;

                case Min:
                    sb
                        .append(" data-val-range=\" ").append(errorMsg).append("\"")
                        .append(" data-val-range-min=\"").append(validationHandler.getErrorArgs()[1]).append("\"")
                        .append(" data-val-range-max=\"").append(Integer.MAX_VALUE).append("\"")
                        .append(" data-val-number=\"").append(String.format("A(z) '%1$s' mezőnek számot kell tartalmaznia. ", validationHandler.getErrorArgs()[0])).append("\"");
                    break;

                case Max:
                default:
                    throw new RuntimeException("The \"input\" method is not implemented yet for: " + constraint);
            }
        }
    }

    // -- Errors

    public static <T> Html errorsFor(Form.Field field, Class<T> clazz)
    {
        StringBuilder sb = new StringBuilder();
        ValidationErrorHandler<T> validationHandler = new ValidationErrorHandler<T>(clazz, field);

        errorsFor(sb, validationHandler);

        return Html.apply(sb.toString());
    }
    public static <T> void errorsFor(StringBuilder sb, ValidationErrorHandler<T> validationHandler)
    {
        Form.Field field = validationHandler.getFieldOnForm();

        if (field.errors().isEmpty()) // no errors
        {
            sb.append("<span class=\"field-validation-valid\" data-valmsg-replace=\"true\" data-valmsg-for=\"")
                .append(field.name())
                .append("\"></span>");
        }
        else // there are errors
        {
            ValidationError error = field.errors().get(0);
            String errorMsg = validationHandler.calculateErrorMsg(error.message(), error.arguments());

            sb.append("<span class=\"field-validation-error\" data-valmsg-replace=\"true\" data-valmsg-for=\"")
                .append(field.name())
                .append("\"><span for=\"").append(field.name()).append("\" class=\"\"> ")
                .append(errorMsg)
                .append("</span></span>");
        }
    }

    public static <T> Html errorSummary(Form<T> form, Class<T> clazz)
    {
        return errorSummary(form, clazz, false);
    }
    public static <T> Html errorSummary(Form<T> form, Class<T> clazz, boolean excludeFieldErrors)
    {
        StringBuilder sb = new StringBuilder();

        sb.append("<div data-valmsg-summary=\"true\" class=\"validation-summary-errors\">");
        sb.append("<ul>");

        if (form.errors().isEmpty())
        {
            sb.append("<li style=\"display:none\"></li>");
        }
        else
        {
            if (excludeFieldErrors)
                appendErrors(sb, clazz, form.errors().get(""));
            else
                for (Map.Entry<String, List<ValidationError>> entry : form.errors().entrySet())
                    appendErrors(sb, clazz, entry.getValue());
        }

        sb.append("</ul>");
        sb.append("</div>");

        return Html.apply(sb.toString());
    }
    private static <T> void appendErrors(StringBuilder sb, Class<T> clazz, List<ValidationError> entryValue)
    {
        for (ValidationError error : entryValue)
        {
            ValidationErrorHandler<T> validationHandler = new ValidationErrorHandler<T>(clazz, error.key());
            String errorMsg = validationHandler.calculateErrorMsg(error.message(), error.arguments());

            sb.append("<li>").append(errorMsg).append("</li>");
        }
    }

    // -- DisplayName

    public static <T> Html getDisplayName(Form.Field field, Class<T> clazz)
    {
        ValidationErrorHandler<T> validationHandler = new ValidationErrorHandler<T>(clazz, field);
        String displayName = validationHandler.getDisplayName();

        return Html.apply(displayName);
    }
    public static <T> Html getDisplayName(String fieldName, Class<T> clazz)
    {
        ValidationErrorHandler<T> validationHandler = new ValidationErrorHandler<T>(clazz, fieldName);
        String displayName = validationHandler.getDisplayName();

        return Html.apply(displayName);
    }
}
