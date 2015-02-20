using System.Collections.Generic;
using System.Linq;
using BLL.EntityManagers;
using CommonModels.Models.EntityFramework;
using WcfInterfaces.EntityManagers;

namespace WcfHost.EntityManagers
{
	public class AuthorManagerService : IAuthorManager
	{
		string IAuthorManager.GetSearchAutoComplete(string authorName, int howMany, bool isValuePlain)
		{
			return AuthorManager.GetSearchAutoComplete(authorName, howMany, isValuePlain);
		}
	}
}
