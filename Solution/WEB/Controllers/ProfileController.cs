using System;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Async;
using System.Web.Profile;
using System.Web.Routing;
using CommonModels.Models;
using CommonModels.Models.EntityFramework;
using CommonModels.WcfHelperModels;
using CommonPortable.Enums;
using UtilsLocal;
using UtilsShared;
using WEB.Controllers.Base;
using WEB.Filters;
using WebMatrix.WebData;

// With DAL reference
//using DAL.Models;
//using DAL.EntityFramework;
//using UserProfile = DAL.Models.EntityFramework.UserProfile;

namespace WEB.Controllers
{
	[Authorize]
	[InitializeSimpleMembership]
	public class ProfileController : BookteraControllerBase
	{
		#region UserProfile

		//
		// GET: /Profile/Edit

		public ActionResult Edit()
		{
			var userProfile = UserProfileManager.GetForEdit();
			return View("Edit", userProfile);
		}

		//
		// POST: /Profile/Edit

		[HttpPost]
		public ActionResult Edit(UserProfileEditVM userProfileEdit, HttpPostedFileBase imageFile)
		{
			if(ModelState.IsValid)
			{
				try
				{
					userProfileEdit.ImageUrl = ManageUserImageUpload(imageFile, WebSecurity.CurrentUserName.ToFriendlyUrl(), Session);

					UserProfileManager.Update(userProfileEdit);
					ViewBag.Success = "Profil frissítve!";
				}
				catch(Exception)
				{
					ModelState.AddModelError("", "Nem sikerült frissíteni a profilod. ");
				}
			}
			else
			{
				ModelState.AddModelError("", "Nem sikerült frissíteni a profilod. ");
			}

			return View("Edit", userProfileEdit);
		}

		// 
		// AJAX: /Profile/CheckEmailUnique/

		[HttpPost]
		public JsonStringResult CheckEmailUnique(string email)
		{
			bool exist = UserProfileManager.CheckNewEmailUnique(email);
			return new JsonStringResult(exist);
		}


		#endregion

		#region UserAddress

		//
		// GET: /Profile/Addresses

		public ActionResult Addresses()
		{
			var usersAddresses = UserAddressManager.GetUsersAddresses();
			return View("Addresses", usersAddresses);
		}

		//
		// GET: /Profile/AddressesToOrder

		public ActionResult AddressesToOrder(int userOrderId, bool isCustomer, int? ordersOldAddressId = null)
		{
			ViewBag.UserOrderId = userOrderId;
			ViewBag.UserAddressId = ordersOldAddressId;
			ViewBag.IsCustomer = isCustomer;

			return Addresses();
		}

		//
		// AJAX_GET: /Profile/CreateAddress

		public ActionResult CreateAddress()
		{
			ViewBag.Country = "Magyarország";
			return PartialView("Partials/CreateAddressPartial");
		}

		//
		// AJAX_POST: /Profile/CreateAddress

		[HttpPost]
		public ActionResult CreateAddress(UserAddressVM.WithValidation userAddressVm, int? userOrderId = null)
		{
			if(ModelState.IsValid)
			{
				try
				{
					userAddressVm.Id = UserAddressManager.AddViaViewModel(userAddressVm);
					ViewBag.UserOrderId = userOrderId;
					return PartialView("Partials/AddressRowPartial", userAddressVm);
				}
				catch(Exception)
				{
					ModelState.AddModelError("", "Nem sikerült rögzíteni a címedet. ");
				}
			}
			else
			{
				ModelState.AddModelError("", "Nem sikerült rögzíteni a címedet. ");
			}
			return PartialView("Partials/CreateAddressPartial", userAddressVm);
		}

		//
		// AJAX_POST: /Profile/EditAddress

		[HttpPost]
		public JsonStringResult EditAddress(UserAddressVM.WithValidation userAddressVm)
		{
			if(ModelState.IsValid)
			{
				try
				{
					UserAddressManager.UpdateViaViewModel(userAddressVm);
					return new JsonStringResult(true);
				}
				catch(Exception)
				{
				}
			}
			return new JsonStringResult(false);
		}

		//
		// AJAX_POST: /Profile/DeleteAddress

		[HttpPost]
		public JsonStringResult DeleteAddress(int userAddressId, bool isDefault)
		{
			try
			{
				UserAddressManager.Delete(userAddressId, isDefault);
				return new JsonStringResult(true);
			}
			catch(Exception)
			{
				return new JsonStringResult(false);
			}
		}

		//
		// AJAX_POST: /Profile/MakeAddressDefault

		[HttpPost]
		public JsonStringResult MakeAddressDefault(int userAddressId)
		{
			try
			{
				UserProfileManager.UpdateDefaultAddress(userAddressId);
				return new JsonStringResult(true);
			}
			catch(Exception)
			{
				return new JsonStringResult(false);
			}
		}

		//
		// AJAX_POST: /Profile/MakeOrdersAddress

		[HttpPost]
		public JsonStringResult MakeOrdersAddress(int userAddressId, int userOrderId)
		{
			try
			{
				UserOrderManager.UpdateUserOrdersAddress(userAddressId, userOrderId);
				return new JsonStringResult(true);
			}
			catch(Exception)
			{
				return new JsonStringResult(false);
			}
		}

		#endregion

		#region UserGroup

		//
		// GET: /Profile/Group

		public ActionResult Group()
		{
			int usersGroupId;
			var userGroups = UserGroupManager
				.GetAllWithUsers(WebSecurity.CurrentUserId, out usersGroupId)
				.Select(ug => new UserGroupAnnotated(ug))
				.ToList();

			ViewBag.UsersGroupId = usersGroupId;
			return View("Group", userGroups);
		}

		//
		// AJAX_POST: /Profile/LevelUp

		[HttpPost]
		public JsonStringResult LevelUp(UserGroupEnum toUserGroup)
		{
			bool leveledUp;
			try
			{
				leveledUp = UserProfileManager.LevelUpUser(toUserGroup, saveChanges: true);
			}
			catch(Exception)
			{
				leveledUp = false;
			}
			return new JsonStringResult(leveledUp);
		}

		#endregion

		#region Image

		/// <summary>
		/// Az online felületen feltöltött képet elnevezi, lement a lemezre; és visszadja a fájl nevet.
		/// </summary>
		public static string ManageUserImageUpload(HttpPostedFileBase imageFile, string userFriendlyUrl, HttpSessionStateBase session)
		{
			if(imageFile != null && imageFile.ContentLength > 0)
			{
				var userProfileMock = new UserProfile(/*withDefaults: false*/)
				{
					FriendlyUrl = userFriendlyUrl,
				};
				StringMcWrapper imageName = ImageManager.TakeImageToItsFolder(new ImageUploadStream
				{
					Stream = imageFile.InputStream,
					FileName = imageFile.FileName,
					UserProfile = userProfileMock,
					FriendlyUrlForProduct = null,
				});

				session["image"] = null;

				return imageName.String;
			}
			return null;
		}

		/// <summary>
		/// Az online felületen feltöltött képet elnevezi, lement a lemezre; és visszadja a fájl nevet.
		/// </summary>
		public static string ManageProductImageUpload(HttpPostedFileBase imageFile, string productFriendlyUrl)
		{
			if(imageFile != null && imageFile.ContentLength > 0)
			{
				var productMock = new Product(/*withDefaults: false*/);
				var imageName = ImageManager.TakeImageToItsFolder(new ImageUploadStream
				{
					FileName = imageFile.FileName,
					Product = productMock,
					FriendlyUrlForProduct = productFriendlyUrl,
					Stream = imageFile.InputStream,
				});
				return imageName.String;
			}
			return null;
		}

		/// <summary>
		/// Az online felületen feltöltött képet elnevezi, lement a lemezre; és visszadja a fájl nevet.
		/// </summary>
		public static string ManageProductGroupImageUpload(HttpPostedFileBase imageFile, string productGroupFriendlyUrl)
		{
			if(imageFile != null && imageFile.ContentLength > 0)
			{
				var productGroupMock = new ProductGroup(/*withDefaults: false*/)
				{
					FriendlyUrl = productGroupFriendlyUrl,
				};
				var imageName = ImageManager.TakeImageToItsFolder(new ImageUploadStream
				{
					FileName = imageFile.FileName,
					ProductGroup = productGroupMock,
					FriendlyUrlForProduct = null,
					Stream = imageFile.InputStream
				});
				return imageName.String;
			}
			return null;
		}

		#endregion

		#region NotImplemented

		#region Comment

		//
		// GET: /Profile/Comments

		public ActionResult Comments()
		{
			var comments = CommentManager.GetUsersComments();
			return View("Comments", comments);
		}

		#endregion

		#region Rating

		//
		// GET: /Profile/Ratings

		public ActionResult Ratings()
		{
			var ratings = RatingManager.GetUsersRatings();
			return View("Ratings", ratings);
		}

		#endregion

		#endregion
	}
}
