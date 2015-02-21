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
@Constraint(validatedBy = CompareAtClientValidator.class)
@Form.Display(name = ContraintNames.COMPARE_AT_CLIENT)
public @interface CompareAtClient
{
    String message() default ContraintNames.COMPARE_AT_CLIENT;

    Class<?>[] groups() default {};

    Class<? extends Payload>[] payload() default {};

    String other();
}
