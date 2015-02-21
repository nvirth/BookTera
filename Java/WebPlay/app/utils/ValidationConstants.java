package utils;

public class ValidationConstants
{
    public static final String Required = "%1$s megadása kötelező";
    public static final String MaxLength = "A(z) %1$s legfeljebb %2$s karakter hosszú lehet";
    public static final String MinLength = "A(z) %1$s legalább %2$s karakter hosszú kell legyen";

    public static final String StringLengthMinMax = "A(z) %1$s legalább %3$s, legfeljebb %2$s karakter hosszú kell legyen";
    public static final String MinMax = "A(z) %1$s %3$s és %2$s közötti érték lehet";
    public static final String Max = "A(z) %1$s legfeljebb %2$s lehet";
    public static final String Min = "A(z) %1$s legalább %2$s kell legyen";

    public static final String Remote = "A(z) %1$s foglalt";

    // -- RegEx

    private static final String HuChar = "[a-zA-ZíéáőúűóüöÍÉÁŐÚŰÓÜÖ]";
    private static final String HuCharOrSpace = "[a-zA-ZíéáőúűóüöÍÉÁŐÚŰÓÜÖ ]";
    private static final String HuCharOrSpaceOrComma = "[a-zA-ZíéáőúűóüöÍÉÁŐÚŰÓÜÖ ,]";
    private static final String HuCharOrDigit = "([a-zA-ZíéáőúűóüöÍÉÁŐÚŰÓÜÖ]|\\d)";
    private static final String HuCharOrDigitOrSeparator = "([a-zA-ZíéáőúűóüöÍÉÁŐÚŰÓÜÖ ,;.]|\\d)";
    private static final String EnChar = "([a-zA-Z])";
    private static final String EnCharOrSpace = "([a-zA-Z] )";
    private static final String EnCharOrDigit = "([a-zA-Z]|\\d)";

    public static final String RegEx_START_EnChar_EnCharOrDigit_0Ti_END = "^" + EnChar + EnCharOrDigit + "*" + "$";
    public static final String RegExErrMsg_START_EnChar_EnCharOrDigit_0Ti_END = "%1$s: Csak angol betük és számok megengedettek (betüvel kell kezdődnie)";

    public static final String RegEx_START_HuChar_HuCharOrDigitOrSeparator_0Ti_END = "^" + HuChar + HuCharOrDigitOrSeparator + "*" + "$";
    public static final String RegExErrMsg_START_HuChar_HuCharOrDigitOrSeparator_0Ti_END = "%1$s: Csak magyar betük megengedettek (betüvel kell kezdődnie), a szóköz karater és ezek: , ; .";

    public static final String RegEx_START_HuChar_HuCharOrSpace_0Ti_END = "^" + HuChar + HuCharOrSpace + "*" + "$";
    public static final String RegExErrMsg_START_HuChar_HuCharOrSpace_0Ti_END = "%1$s: Csak magyar betük megengedettek és a szóköz karater (betüvel kell kezdődnie)";

    public static final String RegEx_START_HuChar_HuCharOrSpaceOrComma_0Ti_END = "^" + HuChar + HuCharOrSpaceOrComma + "*" + "$";
    public static final String RegExErrMsg_START_HuChar_HuCharOrSpaceOrComma_0Ti_END = "%1$s: Csak magyar betük megengedettek, a szóköz és a vessző (,) karater (betüvel kell kezdődnie)";

    public static final String RegEx_START_Digit_7T20_END = "^\\d{7,20}$";
    public static final String RegExErrMsg_START_Digit_7T20_END = "%1$s: Legalább 7, legfeljebb 20 szám lehet";

    public static final String RegEx_START_Digit_4T4_END = "^\\d{4}$";
    public static final String RegExErrMsg_START_Digit_4T4_END = "%1$s: 4db szám kell legyen";

    public static final String RegEx_Number = "^\\d*$";
    public static final String RegExErrMsg_Number = "%1$s: szám kell legyen";

    public static final String RegEx_ImageExtension = "^.+(\\.jpg|\\.jpeg|\\.bmp|\\.png|\\.gif)$";
    public static final String RegExErrMsg_ImageExtension = "%1$s: A file kiterjesztése a következők lehetnek:jpg, jpeg, bmp, png, gif";

    // --

    public enum ContraintNames
    {
        Required(ContraintNames.REQUIRED),
        MaxLength(ContraintNames.MAX_LENGTH),
        MinLength(ContraintNames.MIN_LENGTH),
        Max(ContraintNames.MAX),
        Min(ContraintNames.MIN),
        Email(ContraintNames.EMAIL),
        Pattern(ContraintNames.PATTERN),

        Remote(ContraintNames.REMOTE),
        CompareAtClient(ContraintNames.COMPARE_AT_CLIENT),
        StringLength(ContraintNames.STRING_LENGTH),
        FieldMatch(ContraintNames.FIELD_MATCH);

        public static final String REQUIRED = "constraint.required";
        public static final String MAX_LENGTH = "constraint.maxLength";
        public static final String MIN_LENGTH = "constraint.minLength";
        public static final String MAX = "constraint.max";
        public static final String MIN = "constraint.min";
        public static final String EMAIL = "constraint.email";
        public static final String PATTERN = "constraint.pattern";

        public static final String REMOTE = "constraint.remote";
        public static final String COMPARE_AT_CLIENT = "constraint.compareAtClient";
        public static final String STRING_LENGTH = "constraint.stringLength";
        public static final String FIELD_MATCH = "constraint.fieldMatch";

        ContraintNames(String text)
        {
            this.text = text;
        }

        private String text;
        public String getText()
        {
            return this.text;
        }

        public static ContraintNames fromString(String text)
        {
            if (text != null)
                for (ContraintNames cn : ContraintNames.values())
                    if (text.equalsIgnoreCase(cn.text))
                        return cn;
            return null;
        }
    }

}
