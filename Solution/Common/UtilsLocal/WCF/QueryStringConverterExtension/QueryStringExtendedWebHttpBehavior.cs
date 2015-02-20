using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using UtilsLocal.WCF.QueryStringConverterExtension.Steps;

namespace UtilsLocal.WCF.QueryStringConverterExtension
{
	public class QueryStringExtendedWebHttpBehavior : WebHttpBehavior
	{
		protected override QueryStringConverter GetQueryStringConverter(OperationDescription operationDescription)
		{
			return new QueryStringExtendedConverter();
		}
	}
}
