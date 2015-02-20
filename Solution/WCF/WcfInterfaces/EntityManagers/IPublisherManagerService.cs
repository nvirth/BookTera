using System.Collections.Generic;
using System.ServiceModel;
using CommonModels.Models.EntityFramework;
using System.ServiceModel.Web;

namespace WcfInterfaces.EntityManagers
{
	[ServiceContract]
	public interface IPublisherManager
	{
		[OperationContract]
		[WebGet]
		string GetSearchAutoComplete(string publisherName, int howMany, bool isValuePlain = false);
	}
}