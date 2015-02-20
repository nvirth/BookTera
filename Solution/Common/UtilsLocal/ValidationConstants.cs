namespace UtilsLocal
{
	public static class ValidationConstants
	{
		public const string RequiredErrorMessageFormat = "{0} megadása kötelező";
		public const string StringLengthMinMaxErrorMessageFormat = "A(z) {0} legalább {2}, legfeljebb {1} karakter hosszú kell legyen";
		public const string StringLengthMaxErrorMessageFormat = "A(z) {0} legfeljebb {1} karakter hosszú lehet";
		public const string RangeMinMaxErrorMessageFormat = "A(z) {0} {2} és {1} közötti érték lehet";
		public const string RangeMinErrorMessageFormat = "A(z) {0} legalább {1} kell legyen";

		#region RegEx

		private const string HuChar = @"[a-zA-ZíéáőúűóüöÍÉÁŐÚŰÓÜÖ]";
		private const string HuCharOrSpace = @"[a-zA-ZíéáőúűóüöÍÉÁŐÚŰÓÜÖ ]";
		private const string HuCharOrSpaceOrComma = @"[a-zA-ZíéáőúűóüöÍÉÁŐÚŰÓÜÖ ,]";
		private const string HuCharOrDigit = @"([a-zA-ZíéáőúűóüöÍÉÁŐÚŰÓÜÖ]|\d)";
		private const string HuCharOrDigitOrSeparator = @"([a-zA-ZíéáőúűóüöÍÉÁŐÚŰÓÜÖ ,;.]|\d)";
		private const string EnChar = @"([a-zA-Z])";
		private const string EnCharOrSpace = @"([a-zA-Z] )";
		private const string EnCharOrDigit = @"([a-zA-Z]|\d)";

		public const string RegEx_START_EnChar_EnCharOrDigit_0Ti_END = "^" + EnChar + EnCharOrDigit + "*" + "$";
		public const string RegExErrMsg_START_EnChar_EnCharOrDigit_0Ti_END = "{0}: Csak angol betük és számok megengedettek (betüvel kell kezdődnie)";

		public const string RegEx_START_HuChar_HuCharOrDigitOrSeparator_0Ti_END = "^" + HuChar + HuCharOrDigitOrSeparator + "*" + "$";
		public const string RegExErrMsg_START_HuChar_HuCharOrDigitOrSeparator_0Ti_END = "{0}: Csak magyar betük megengedettek (betüvel kell kezdődnie), a szóköz karater és ezek: , ; .";

		public const string RegEx_START_HuChar_HuCharOrSpace_0Ti_END = "^" + HuChar + HuCharOrSpace + "*" + "$";
		public const string RegExErrMsg_START_HuChar_HuCharOrSpace_0Ti_END = "{0}: Csak magyar betük megengedettek és a szóköz karater (betüvel kell kezdődnie)";

		public const string RegEx_START_HuChar_HuCharOrSpaceOrComma_0Ti_END = "^" + HuChar + HuCharOrSpaceOrComma + "*" + "$";
		public const string RegExErrMsg_START_HuChar_HuCharOrSpaceOrComma_0Ti_END = "{0}: Csak magyar betük megengedettek, a szóköz és a vessző (,) karater (betüvel kell kezdődnie)";

		public const string RegEx_START_Digit_7T20_END = @"^\d{7,20}$";
		public const string RegExErrMsg_START_Digit_7T20_END = "{0}: Legalább 7, legfeljebb 20 szám lehet";

		public const string RegEx_START_Digit_4T4_END = @"^\d{4}$";
		public const string RegExErrMsg_START_Digit_4T4_END = "{0}: 4db szám kell legyen";
		
		public const string RegEx_Number = @"^\d*$";
		public const string RegExErrMsg_Number = "{0}: szám kell legyen";

		public const string RegEx_ImageExtension = @"^.+(\.jpg|\.jpeg|\.bmp|\.png|\.gif)$";
		public const string RegExErrMsg_ImageExtension = "{0}: A file kiterjesztése a következők lehetnek:jpg, jpeg, bmp, png, gif";

		#endregion
	}
}
