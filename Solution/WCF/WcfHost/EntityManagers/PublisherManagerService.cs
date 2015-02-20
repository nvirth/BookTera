using System.Collections.Generic;
using System.Linq;
using BLL.EntityManagers;
using CommonModels.Models.EntityFramework;
using WcfInterfaces.EntityManagers;

namespace WcfHost.EntityManagers
{
	public class PublisherManagerService : IPublisherManager 
	{
		string IPublisherManager.GetSearchAutoComplete(string publisherName, int howMany, bool isValuePlain)
		{
			return PublisherManager.GetSearchAutoComplete(publisherName, howMany, isValuePlain);
		}
	}
}