using System;
using System.ServiceModel.Configuration;

namespace UtilsLocal.WCF.Cookie
{
	public class CookieBehaviorExtensionElement : BehaviorExtensionElement
	{
		public override Type BehaviorType
		{
			get { return typeof(CookieBehavior); }
		}

		protected override object CreateBehavior()
		{
			return new CookieBehavior();
		}
	}
}