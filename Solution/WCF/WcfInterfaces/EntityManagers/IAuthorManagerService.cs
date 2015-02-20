using System.Collections.Generic;
using System.ServiceModel;
using CommonModels.Models.EntityFramework;
using System.ServiceModel.Web;

namespace WcfInterfaces.EntityManagers
{
	[ServiceContract]
	public interface IAuthorManager
	{
		[OperationContract]
		[WebGet]
		string GetSearchAutoComplete(string authorName, int howMany, bool isValuePlain = false);
	}
}
