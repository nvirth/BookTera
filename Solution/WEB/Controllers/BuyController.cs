using System;
using System.Web.Mvc;
using UtilsShared;
using WEB.Controllers.Base;
using WEB.Filters;
using WebMatrix.WebData;

// With DAL reference
//using DAL.Managers;
//using DAL.EntityFramework;


namespace WEB.Controllers
{
	[Authorize]
	[InitializeSimpleMembership]
	public class BuyController : BookteraControllerBase
	{
		#region Cart opartaions

		//
		// AJAX_POST: /Buy/AddToCart

		[HttpPost]
		public JsonStringResult AddToCart(int productID)
		{
			try
			{
				TransactionManager.AddProductToCart(productID);
				return new JsonStringResult(true);
			}
			catch(Exception)
			{
				//TODO: okok kezelése
				return new JsonStringResult(false);
			}
		}

		//
		// AJAX_POST: /Buy/RemoveFromCart

		public JsonStringResult RemoveFromCart(int productInOrderId)
		{
			try
			{
				TransactionManager.RemoveProductFromCart(productInOrderId);
				return new JsonStringResult(true);
			}
			catch (Exception)
			{
				return new JsonStringResult(false);
			}
		}

		//
		// AJAX_POST: /Buy/DeleteCart

		public ActionResult DeleteCart(int userOrderId)
		{
			try
			{
				TransactionManager.RemoveUsersCart(userOrderId);
				return new JsonStringResult(true);
			}
			catch(Exception)
			{
				return new JsonStringResult(false);
			}
		}

		//
		// AJAX_POST: /Buy/DeleteAllCarts

		public ActionResult DeleteAllCarts()
		{
			try
			{
				TransactionManager.RemoveUsersAllCarts();
				return new JsonStringResult(true);
			}
			catch(Exception)
			{
				return new JsonStringResult(false);
			}
		}

		//
		// AJAX_POST: /Buy/ModifyProductsQuantity

		public ActionResult ModifyProductsQuantity(int productInOrderId, int newQuantity)
		{
			try
			{
				TransactionManager.UpdateProductInCart(productInOrderId, newQuantity);
				return new JsonStringResult(true);
			}
			catch(Exception)
			{
				return new JsonStringResult(false);
			}
		}

		#endregion

		#region TransactionLists
		
		//
		// GET: /Buy/Carts

		public ActionResult Carts()
		{
			ViewBag.SiteTitle = "Kosaraim";
			ViewBag.EmptyMessage = "Nincs kosarad. ";
			var carts = TransactionManager.GetUsersCartsVM(customerId: WebSecurity.CurrentUserId, vendorId:null);
			return View("TransactionLists/TransactionList", carts);
		}

		//
		// GET: /Buy/InProgressOrders

		public ActionResult InProgressOrders()
		{
			ViewBag.SiteTitle = "Megrendelt könyveim";
			ViewBag.EmptyMessage = "Nincsenek megrendelt könyveid. ";
			var orders = TransactionManager.GetUsersInProgressOrdersVM(customerId: WebSecurity.CurrentUserId, vendorId:null);
			return View("TransactionLists/TransactionList", orders);
		}

		//
		// GET: /Buy/EarlierOrders

		public ActionResult EarlierOrders()
		{
			ViewBag.SiteTitle = "Korábbi vásárlásaim";
			ViewBag.EmptyMessage = "Nem vásároltál még. ";
			var orders = TransactionManager.GetUsersFinishedTransactionsVM(customerId: WebSecurity.CurrentUserId, vendorId:null);
			return View("TransactionLists/TransactionList", orders);
		}

		#endregion
	}
}
