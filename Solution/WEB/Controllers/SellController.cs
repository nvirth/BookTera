using System;
using System.Web;
using System.Web.Mvc;
using CommonModels.Models.ProductModels;
using CommonPortable.Enums;
using CommonPortable.Exceptions;
using UtilsLocal;
using UtilsShared;
using UtilsSharedPortable;
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
	public class SellController : BookteraControllerBase
	{
		#region Product

		// 
		// AJAX_POST: /Sell/GetProductGroupListJson/

		[HttpPost]
		public JsonResult GetProductGroupListJson(int? selectedId = null)
		{
			var selectList = ProductGroupManager.GetAllSortedJson(selectedId);
			return Json(selectList);
		}

		//
		// GET: /Sell/UploadProduct

		public ActionResult UploadProduct()
		{
			ViewBag.Product = new
			{
				Language = "Magyar",
				Edition = 1,
				IsBook = true,
			};
			return View("UploadProduct");
		}

		//
		// POST: /Sell/UploadProduct

		[HttpPost]
		public ActionResult UploadProduct(CreatePVM createModel, HttpPostedFileBase productGroupImageFile, HttpPostedFileBase productImageFile, string productGroupName)
		{
			if(ModelState.IsValid)
			{
				var validationErrors = UploadProduct_ValidationsAndImages(createModel, productGroupImageFile, productImageFile, productGroupName);
				if(validationErrors != null)
					return validationErrors;

				try
				{
					BookManager.UploadProductNr(createModel);

					ViewBag.Success = "Sikeres könyvfeltöltés!";
					return View("UploadProduct", createModel);
				}
				catch(Exception e)
				{
					ModelState.AddModelError("", "Nem sikerült feltölteni a könyvet. ");
					return View("UploadProduct", createModel);
				}
			}

			ModelState.AddModelError("", "Nem sikerült feltölteni a könyvet. ");
			return View("UploadProduct", createModel);
		}
		private ActionResult UploadProduct_ValidationsAndImages(CreatePVM createModel, HttpPostedFileBase productGroupImageFile, HttpPostedFileBase productImageFile, string productGroupName)
		{
			string friendlyUrl;
			bool isNewProductGroup = createModel.ProductGroup.Id == -1;
			if(isNewProductGroup)
			{
				// Cast it from ProductGroup to ProductGroup.WithValidation to validate it
				var productGroupVm = BookManager.CreateProductGroupWithValidation(createModel.ProductGroup);
				if(!TryValidateModel(productGroupVm))
				{
					foreach(var propertyInfo in typeof(CreatePVM.ProductGroupVM).GetProperties())
						ModelState.RenameKeyIfExist(propertyInfo.Name, "ProductGroup." + propertyInfo.Name);

					return View("UploadProduct", createModel);
				}

				friendlyUrl = createModel.ProductGroup.Title.ToFriendlyUrl();

				// Try to save the uploaded ProductGroup image file
				try
				{
					createModel.ProductGroup.ImageUrl = ProfileController.ManageProductGroupImageUpload(productGroupImageFile, friendlyUrl);
					if(createModel.ProductGroup.ImageUrl == null)
					{
						ModelState.AddModelError("productGroupImageFile", "Kötelező képet feltölteni a termék csoportjába. ");
						return View("UploadProduct", createModel);
					}
				}
				catch(BookteraException e)
				{
					if(e.Code == BookteraExceptionCode.ImageFileExtensionWrong)
						ModelState.AddModelError("ProductGroup.ImageUrl", "Nem sikerült feltölteni a képed, mert nem megfelelő a formátuma. ");
					else
						ModelState.AddModelError("ProductGroup.ImageUrl", "Nem sikerült feltölteni a képed. ");
					return View("UploadProduct", createModel);
				}
				catch(Exception e)
				{
					ModelState.AddModelError("ProductGroup.ImageUrl", "Nem sikerült feltölteni a képed. ");
					return View("UploadProduct", createModel);
				}
			}
			else
			{
				friendlyUrl = productGroupName.ToFriendlyUrl();
			}

			// Try to save the uploaded Product image file
			try
			{
				createModel.Product.ImageUrl = ProfileController.ManageProductImageUpload(productImageFile, friendlyUrl);
			}
			catch(BookteraException e)
			{
				if(e.Code == BookteraExceptionCode.ImageFileExtensionWrong)
					ModelState.AddModelError("Product.ImageUrl", "Nem sikerült feltölteni a képed, mert nem megfelelő a formátuma. ");
				else
					ModelState.AddModelError("Product.ImageUrl", "Nem sikerült feltölteni a képed. ");
				return View("UploadProduct", createModel);
			}
			catch(Exception e)
			{
				ModelState.AddModelError("Product.ImageUrl", "Nem sikerült feltölteni a képed. ");
				return View("UploadProduct", createModel);
			}

			// -- Validating the flags

			if(createModel.Product.IsUsed && createModel.Product.IsDownloadable)
			{
				ModelState.AddModelError("", "Elektronikus könyv nem lehet használt. ");
				return View("UploadProduct", createModel);
			}
			if(createModel.Product.IsDownloadable && createModel.Product.HowMany != 1)
			{
				ModelState.AddModelError("", "Elektronikus könyv mennyisége mindig 1. ");
				return View("UploadProduct", createModel);
			}
			if(!createModel.Product.IsBook && !createModel.Product.IsAudio && !createModel.Product.IsVideo)
			{
				ModelState.AddModelError("", "A könyvet be kell sorolni a 3 kategóriából legalább 1-be: Könyv|Hangoskönyv|Videó. ");
				return View("UploadProduct", createModel);
			}

			// If all is valid, clear the "Id==-1" to null. It was only for the dropDownList
			if(isNewProductGroup)
				createModel.ProductGroup.Id = null;

			return null;
		}

		//
		// GET: /Sell/UploadedProducts

		public ActionResult UploadedProducts(int pageNumber = 1)
		{
			ViewBag.siteTitle = "Feltöltött könyveim";
			ViewBag.EmptyMessage = "Még nem töltöttél fel könyvet";
			var usersProducts = ProductManager.GetUsersProducts(WebSecurity.CurrentUserId, pageNumber, Config.ProductsPerPage, forExchange: false);
			return View("BookBlocksRows/BookBlockList", usersProducts);
		}

		#endregion

		#region TransactionLists

		//
		// GET: /Sell/FinishedTransactions

		public ActionResult FinishedTransactions()
		{
			ViewBag.SiteTitle = "Befejezett tranzakcióim";
			ViewBag.EmptyMessage = "Nem vásároltak még tőled. ";
			var transactions = TransactionManager.GetUsersFinishedTransactionsVM(vendorId: WebSecurity.CurrentUserId, customerId: null);
			return View("TransactionLists/TransactionList", transactions);
		}

		//
		// GET: /Sell/InProgressTransactions

		public ActionResult InProgressTransactions()
		{
			ViewBag.SiteTitle = "Folyamatban lévő tranzakcióim";
			ViewBag.EmptyMessage = "Nem vásároltak még tőled. ";
			var transactions = TransactionManager.GetUsersInProgressOrdersVM(vendorId: WebSecurity.CurrentUserId, customerId: null);
			return View("TransactionLists/TransactionList", transactions);
		}

		//
		// GET: /Sell/InCartTransactions

		public ActionResult InCartTransactions()
		{
			ViewBag.SiteTitle = "Mások által kosárba tett könyveim";
			ViewBag.EmptyMessage = "Jelenleg senki nem tette kosárba semelyik könyved. ";
			var transactions = TransactionManager.GetUsersCartsVM(vendorId: WebSecurity.CurrentUserId, customerId: null);
			return View("TransactionLists/TransactionList", transactions);
		}

		#endregion

		#region BuyedOrderOperations

		//
		// GET: /Sell/SelectExchangeBooks

		public ActionResult SelectExchangeBooks(string userFriendlyUrl, int userOrderID, int pageNumber = 1)
		{
			string userName;
			var usersProducts = ProductManager.GetUsersProductsByFriendlyUrl(userFriendlyUrl, pageNumber, Config.ProductsPerPage, out userName, /*forExchange*/ true);
			ViewBag.siteTitle = string.Format("{0} könyvei a csere-kosárba", userName);
			ViewBag.UserOrderID = userOrderID;

			return View("BookBlocksRows/BookBlockList", usersProducts);
		}

		//
		// AJAX_POST: /Sell/AddToExchange

		public ActionResult AddToExchange(int productID, int userOrderID)
		{
			try
			{
				TransactionManager.AddExchangeProduct(productID, userOrderID);
				return new JsonStringResult(true);
			}
			catch(Exception)
			{
				return new JsonStringResult(false);
			}
		}

		//
		// AJAX_POST: /Sell/ModifyExchangeProductsQuantity

		public ActionResult ModifyExchangeProductsQuantity(int productInOrderId, int newQuantity)
		{
			try
			{
				TransactionManager.UpdateExchangeProduct(productInOrderId, newQuantity);
				return new JsonStringResult(true);
			}
			catch(Exception)
			{
				return new JsonStringResult(false);
			}
		}

		//
		// AJAX_POST: /Sell/RemoveFromExchangeCart

		public JsonStringResult RemoveFromExchangeCart(int productInOrderId)
		{
			try
			{
				TransactionManager.RemoveExchangeProduct(productInOrderId);
				return new JsonStringResult(true);
			}
			catch(Exception)
			{
				return new JsonStringResult(false);
			}
		}

		#endregion
	}
}
