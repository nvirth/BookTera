using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using CommonModels.Models;
using CommonModels.Models.AccountModels;

namespace WcfInterfaces
{
	[ServiceContract]
	public interface IForGeneratingModels
	{
		[OperationContract]
		void DoNothing(
			LoginModel a1,
			DetailedSearchVM a2
			);
	}
}
