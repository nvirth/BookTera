using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Moq;

namespace WcfHost
{
	public class Validator
	{
		#region class ValidatorController

		private class ValidatorController : Controller
		{
			public bool TryValidateModelExtend(object model)
			{
				return TryValidateModel(model);
			}
		}

		#endregion

		private readonly ValidatorController _validatorController;

		public Validator()
		{
			var context = new Mock<HttpContextBase>(MockBehavior.Strict);
			_validatorController = new ValidatorController();
			_validatorController.ControllerContext = 
				new ControllerContext(context.Object, new RouteData(), _validatorController);

		}

		#region Delegating Members

		public bool TryValidateModel(object model)
		{
			return _validatorController.TryValidateModelExtend(model);
		}

		public ModelStateDictionary ModelState
		{
			get { return _validatorController.ModelState; }
		}

		#endregion

	}
}