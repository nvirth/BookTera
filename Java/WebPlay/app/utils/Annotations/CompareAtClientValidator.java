package utils.Annotations;

import org.apache.commons.beanutils.BeanUtils;

import javax.validation.ConstraintValidator;
import javax.validation.ConstraintValidatorContext;

public class CompareAtClientValidator
    // extends Constraints.Validator<Object> // We don't need this; it's only for client side validation
    implements ConstraintValidator<CompareAtClient, Object>
{
    private String otherFieldName;

    @Override
    public void initialize(final CompareAtClient constraintAnnotation)
    {
        otherFieldName = constraintAnnotation.other();
    }

    @Override
    public boolean isValid(final Object value, final ConstraintValidatorContext context)
    {
        try
        {
            // Here we can't get an instance of the model object. So we can't compare
            // it's two properties.
            // We could do that via tha FieldMatch annotation. Play's validation don't bear
            // with annotating the model class. So the recommended way to do the client side
            // pair of this is like in the RegisterVM class
            return true;
        }
        catch (final Exception ignore)
        {
            // ignore
        }
        return true;
    }
}