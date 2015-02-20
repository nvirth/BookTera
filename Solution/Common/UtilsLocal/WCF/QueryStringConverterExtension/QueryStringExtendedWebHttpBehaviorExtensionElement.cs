using System;
using System.ServiceModel.Configuration;

namespace UtilsLocal.WCF.QueryStringConverterExtension
{
	/// <summary>
	/// Megj.: A Host-ban ezt nem szükséges felhasználni a web.config-ban, mert a
	/// CustomWebServiceHost osztályban hozzáadjuk a webHttpBinding-os Behavior-ökhöz
	/// </summary>
	public class QueryStringExtendedWebHttpBehaviorExtensionElement : BehaviorExtensionElement
	{
		public override Type BehaviorType
		{
			get { return typeof(QueryStringExtendedWebHttpBehavior); }
		}

		protected override object CreateBehavior()
		{
			return new QueryStringExtendedWebHttpBehavior();
		}
	}
}