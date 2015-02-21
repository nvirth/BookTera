package utils.Annotations;

import play.data.Form;
import utils.ValidationConstants;

import javax.validation.Constraint;
import javax.validation.Payload;
import java.lang.annotation.ElementType;
import java.lang.annotation.Retention;
import java.lang.annotation.RetentionPolicy;
import java.lang.annotation.Target;

import static utils.ValidationConstants.ContraintNames;

@Constraint(validatedBy = RemoteValidator.class)
@Target({ElementType.FIELD})
@Retention(RetentionPolicy.RUNTIME)
@Form.Display(name = ContraintNames.REMOTE )
public @interface Remote
{
    Class<?>[] groups() default {};
    Class<? extends Payload>[] payload() default {};

    String message() default RemoteValidator.message;
    String url();
    String httpMethod() default "POST";
}