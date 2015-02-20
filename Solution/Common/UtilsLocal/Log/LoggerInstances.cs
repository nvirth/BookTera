namespace UtilsLocal.Log
{
	public static class BookteraLog
	{
		public static BookteraLogger ger { get; private set; }

		static BookteraLog()
		{
			ger = new BookteraLogger("Booktera");
		}
	}
}