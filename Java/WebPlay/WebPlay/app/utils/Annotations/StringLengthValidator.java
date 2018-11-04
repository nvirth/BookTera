package utils.Annotations;

import play.data.validation.Constraints;
import play.libs.F;

import javax.validation.ConstraintValidator;

public class StringLengthValidator
    extends Constraints.Validator<String>
    implements ConstraintValidator<StringLength, String>
{
    public static final String message = "error.stringLength";

    private int min;
    private int max;

    public StringLengthValidator()
    {
    }

    @Override
    public void initialize(StringLength constraintAnnotation)
    {
        min = constraintAnnotation.min();
        max = constraintAnnotation.max();
    }

    @Override
    public boolean isValid(String value)
    {
        boolean isValid = value.length() <= max && value.length() >= min;
        return isValid;
    }

    @Override
    public F.Tuple<String, Object[]> getErrorMessageKey()
    {
        return new F.Tuple<String, Object[]>(message, new Object[]{});
    }
}
