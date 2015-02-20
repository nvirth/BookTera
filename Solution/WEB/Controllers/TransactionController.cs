using System;
using System.Web.Mvc;
using UtilsShared;
using WEB.Controllers.Base;
using WEB.Filters;
using WebMatrix.WebData;

// With DAL reference
//using DAL.Managers;
//using DAL.EntityFramework;
//using DAL.Models.ProductModels;

namespace WEB.Controllers
{
	[Authorize]
	[InitializeSimpleMembership]
	public class TransactionController : BookteraControllerBase
	{
		#region Step 1 - Buy

		//
		// AJAX_POST: /Transaction/SendOrder

		public ActionResult SendOrder(int userOrderId)
		{
			try
			{
				TransactionManager.SendOrder(userOrderId);
				return new JsonStringResult(true);
			}
			catch (Exception)
			{
				return new JsonStringResult(false);
			}
		}

		#endregion

		#region Step 2 - Sell

		//
		// AJAX_POST: /Transaction/SendExchangeOffer

		public ActionResult SendExchangeOffer(int userOrderId)
		{
			try
			{
				TransactionManager.SendExchangeOffer(userOrderId);
				return new JsonStringResult(true);
			}
			catch (Exception)
			{
				return new JsonStringResult(false);
			}
		}

		//
		// AJAX_POST: /Transaction/FinalizeOrderWithoutExchange

		public ActionResult FinalizeOrderWithoutExchange(int userOrderId)
		{
			try
			{
				TransactionManager.FinalizeOrderWithoutExchange(userOrderId);
				return new JsonStringResult(true);
			}
			catch (Exception)
			{
				return new JsonStringResult(false);
			}
		}

		#endregion

		#region (Step 3) - Buy

		//
		// AJAX_POST: /Transaction/FinalizeOrderAcceptExchange

		public ActionResult FinalizeOrderAcceptExchange(int userOrderId)
		{
			try
			{
				TransactionManager.FinalizeOrderAcceptExchange(userOrderId);
				return new JsonStringResult(true);
			}
			catch (Exception)
			{
				return new JsonStringResult(false);
			}
		}

		//
		// AJAX_POST: /Transaction/FinalizeOrderDenyExchange

		public ActionResult FinalizeOrderDenyExchange(int userOrderId)
		{
			try
			{
				TransactionManager.FinalizeOrderDenyExchange(userOrderId);
				return new JsonStringResult(true);
			}
			catch (Exception)
			{
				return new JsonStringResult(false);
			}
		}

		#endregion

		#region Step 4 - Buy & Sell

		//
		// AJAX_POST: /Transaction/CloseOrderSuccessful

		public ActionResult CloseOrderSuccessful(int userOrderId)
		{
			try
			{
				TransactionManager.CloseOrderSuccessful(userOrderId);
				return new JsonStringResult(true);
			}
			catch (Exception)
			{
				return new JsonStringResult(false);
			}
		}

		//
		// AJAX_POST: /Transaction/CloseOrderUnsuccessful

		public ActionResult CloseOrderUnsuccessful(int userOrderId)
		{
			try
			{
				TransactionManager.CloseOrderUnsuccessful(userOrderId);
				return new JsonStringResult(true);
			}
			catch (Exception)
			{
				return new JsonStringResult(false);
			}
		}

		#endregion
	}
}
