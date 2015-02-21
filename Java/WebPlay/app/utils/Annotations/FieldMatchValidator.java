package utils.Annotations;

import org.apache.commons.beanutils.BeanUtils;
import play.data.validation.Constraints;
import play.libs.F;

import javax.validation.ConstraintValidator;
import javax.validation.ConstraintValidatorContext;
import java.lang.reflect.Field;

public class FieldMatchValidator
    extends Constraints.Validator<Object>
    implements ConstraintValidator<FieldMatch, Object>
{
    private String firstFieldName;
    private String secondFieldName;

    public static final String message = "error.FieldMatch";

    @Override
    public void initialize(final FieldMatch constraintAnnotation)
    {
        firstFieldName = constraintAnnotation.first();
        secondFieldName = constraintAnnotation.second();
    }

    @Override
    public boolean isValid(Object value)
    {
        try
        {
            final Object firstObj = BeanUtils.getProperty(value, firstFieldName);
            final Object secondObj = BeanUtils.getProperty(value, secondFieldName);

            boolean isValid = (firstObj == null && secondObj == null)
                || (firstObj != null && firstObj.equals(secondObj));

            return isValid;
        } catch (final Exception ignore)
        {
            // ignore
        }
        return true;
    }

    @Override
    public F.Tuple<String, Object[]> getErrorMessageKey()
    {
        return new F.Tuple<String, Object[]>(message, new Object[]{});
    }

}