using System.Configuration;

namespace WEB
{
	public static class Config
	{
		public static readonly int ProductsPerPage = int.Parse(ConfigurationManager.AppSettings["ProductsPerPage"]);
		public static readonly string MainTitleOfSite = ConfigurationManager.AppSettings["MainTitleOfSite"];
		public static readonly string NoAuthFunction = ConfigurationManager.AppSettings["NoAuthFunction"];
		public static readonly int AutoCompleteResultCount = int.Parse(ConfigurationManager.AppSettings["AutoCompleteResultCount"]);
		public static readonly int NewestHowMany = int.Parse(ConfigurationManager.AppSettings["NewestHowMany"]);
	}
}