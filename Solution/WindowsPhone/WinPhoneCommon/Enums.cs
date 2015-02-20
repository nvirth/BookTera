namespace WinPhoneCommon
{
	public enum AppBarItem : byte
	{
		Login = 0,
		Settings = 1,
		Logout = 2,
	}
	public enum CategoryPagePivotItem : byte
	{
		SubCategories = 0,
		ProductsInCategory = 1,
	}
	public enum HttpPostVerb : byte
	{
		NON_POST__GET = 0,
		POST = 1,
		PUT = 2,
		DELETE = 3,
	}
	public enum UserOrderStatusConverterTpye : byte
	{
		ToStirng,
		ToStatusBlockVisibility,
		ToAddExchangeButtonVisibility,
		ToColor,
		ToFinishedVisibility,
	}

	public enum ParticipantType : byte
	{
		None = 0,
		Customer,
		Vendor,
	}
}
