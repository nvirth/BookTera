using System.Web.Mvc;

namespace UtilsShared
{
	public class JsonStringResult : ContentResult
	{
		public JsonStringResult(string json)
		{
			Content = json;
			ContentType = "application/json";
		}

		public JsonStringResult(bool boolJson)
			:this(boolJson ? "true" : "false")
		{
		}

		public JsonStringResult(object json)
			: this(json.ToString())
		{
		}
	}
}
