package utils.Annotations;

import play.data.Form;

import javax.validation.Constraint;
import javax.validation.Payload;
import java.lang.annotation.ElementType;
import java.lang.annotation.Retention;
import java.lang.annotation.Target;

import static java.lang.annotation.RetentionPolicy.RUNTIME;
import static utils.ValidationConstants.ContraintNames;


@Target({ElementType.FIELD})
@Retention(RUNTIME)
@Constraint(validatedBy = StringLengthValidator.class)
@Form.Display(name = ContraintNames.STRING_LENGTH)
public @interface StringLength
{
    int max() default Integer.MAX_VALUE;
    int min() default Integer.MIN_VALUE;
    String message() default ContraintNames.STRING_LENGTH;

    Class<?>[] groups() default {};

    Class<? extends Payload>[] payload() default {};
}
