package utils.Annotations;

import play.data.validation.Constraints;
import play.libs.F;

import javax.validation.ConstraintValidator;

public class RemoteValidator
    extends Constraints.Validator<String>
    implements ConstraintValidator<Remote, String>
{
    public static final String message = "error.remote";

    public RemoteValidator()
    {
    }

    @Override
    public void initialize(Remote constraintAnnotation)
    {
    }

    @Override
    public boolean isValid(String value)
    {
        // This validator is only a helper for client side validation
        // It has no effect at server side
        //
        return true;
    }

    @Override
    public F.Tuple<String, Object[]> getErrorMessageKey()
    {
        return new F.Tuple<String, Object[]>(message, new Object[]{});
    }
}
