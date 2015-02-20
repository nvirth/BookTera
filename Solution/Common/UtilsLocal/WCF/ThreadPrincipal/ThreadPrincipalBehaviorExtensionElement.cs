using System;
using System.ServiceModel.Configuration;
using UtilsLocal.WCF.Cookie;

namespace UtilsLocal.WCF.ThreadPrincipal
{
	public class ThreadPrincipalBehaviorExtensionElement : BehaviorExtensionElement
	{
		public override Type BehaviorType
		{
			get { return typeof(ThreadPrincipalBehavior); }
		}

		protected override object CreateBehavior()
		{
			return new ThreadPrincipalBehavior();
		}
	}
}