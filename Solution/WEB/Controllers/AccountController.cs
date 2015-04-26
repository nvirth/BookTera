using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using CommonModels.Methods;
using CommonModels.Methods.ManagerRelief;
using CommonModels.Models;
using CommonModels.Models.AccountModels;
using CommonPortable.Enums;
using CommonPortable.Exceptions;
using UtilsLocal;
using UtilsShared;
using WEB.Controllers.Base;
using WEB.Filters;
using WebMatrix.WebData;

// With DAL reference
//using DAL.Managers;
//using DAL.Models.AccountModels;
//using DAL.Models;
//using DAL.EntityFramework;
//using UserProfile = DAL.Models.AccountModels.UserProfile;

namespace WEB.Controllers
{
	[Authorize]
	[InitializeSimpleMembership]
	public class AccountController : BookteraControllerBase
	{
		#region LogIn - LogOff

		//
		// GET: /Account/Login

		[AllowAnonymous]
		public ActionResult Login(string returnUrl)
		{
			ViewBag.ReturnUrl = returnUrl;
			return View("Login");
		}

		//
		// POST: /Account/Login

		[HttpPost]
		[AllowAnonymous]
		[ValidateAntiForgeryToken]
		public ActionResult Login(LoginModel loginModel, string returnUrl)
		{
			if(ModelState.IsValid)
				if(AuthenticationManager.Login(loginModel.LoginUserName, loginModel.LoginPassword, loginModel.RememberMe))
				{
					// TODO Auth cookie name extract
					// This is here, because IE and Chrome won't set any cookie anymore with domain localhost
					Response.Cookies.Get(".ASPXAUTH").Domain = "";
					return RedirectToLocal(returnUrl);
				}

			// If we got this far, something failed, redisplay form
			ModelState.AddModelError("", "Hibás felhasználó név és/vagy jelszó");
			loginModel.LoginPassword = string.Empty;
			return View("Login", loginModel);
		}

		//
		// POST: /Account/LogOff

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult LogOff()
		{
			AuthenticationManager.Logout();	// Log out from "WcfHost" wep app
			WebSecurity.Logout();			// Log out from "Web" wep app
			Session.Abandon();

			return RedirectToAction("Index", "Home");
		}

		#endregion

		#region Register

		//
		// GET: /Account/Register

		[AllowAnonymous]
		public ActionResult Register()
		{
			return View("Register");
		}

		//
		// POST: /Account/Register

		[HttpPost]
		[AllowAnonymous]
		[ValidateAntiForgeryToken]
		public ActionResult Register(RegisterVM registerVm, HttpPostedFileBase imageFile)
		{
			if(ModelState.IsValid)
			{
				// The registration will continue, if there are errors here
				Register_ValidateImageAndAddress(registerVm, imageFile);

				try
				{
					RegistrationManager.RegisterUser(registerVm);
					WebSecurity.Login(registerVm.UserName, registerVm.Password);

					return RedirectToAction("RegisterSuccess");
				}
				catch(BookteraException e)
				{
					return Register_HandleBookteraException(e, registerVm);
				}
				catch
				{
					RegistrationManagerRelief.EmptyPasswords(registerVm);
					ModelState.AddModelError("", "Ismeretlen hiba történt. Próbáld meg később a regisztrációt");
					return View("Register", registerVm);
				}
			}

			// If we got this far, something failed, redisplay form
			return View("Register", registerVm);
		}
		private void Register_ValidateImageAndAddress(RegisterVM registerVm, HttpPostedFileBase imageFile)
		{
			bool wasValidationError = false;

			// Validating the Address manually, if it was given
			if(!UserAddressManagerRelief.CheckAllPropertiesNullOrEmpty(registerVm.UserAddress))
			{
				// Cast it from UserAddressVM to UserAddressVM.WithValidation to validate it
				var userAddressVm = new UserAddressVM.WithValidation(registerVm.UserAddress);
				if(!TryValidateModel(userAddressVm))
				{
					wasValidationError = true;
					registerVm.UserAddress = null;
					ModelState.AddModelError("", "Nem sikerült feltölteni a címed. Ha sikerült a regisztrációd, itt veheted fel: Főmenü -> Profilom -> Címeim. ");
					foreach(var propertyInfo in typeof(UserAddressVM).GetProperties())
					{
						if(ModelState.ContainsKey(propertyInfo.Name))
							ModelState[propertyInfo.Name].Errors.Clear();
					}
				}
			}

			// Try to save the uploaded image file
			try
			{
				registerVm.ImageUrl = ProfileController.ManageUserImageUpload(imageFile, registerVm.UserName.ToFriendlyUrl(), Session);
			}
			catch(BookteraException e)
			{
				wasValidationError = true;
				registerVm.ImageUrl = null;
				if(e.Code == BookteraExceptionCode.ImageFileExtensionWrong)
					ModelState.AddModelError("ImageUrl", "Nem sikerült feltölteni a képed, mert nem megfelelő a formátuma. ");
				else
					ModelState.AddModelError("ImageUrl", "Nem sikerült feltölteni a képed. ");
			}
			catch(Exception e)
			{
				wasValidationError = true;
				registerVm.ImageUrl = null;
				ModelState.AddModelError("ImageUrl", "Nem sikerült feltölteni a képed. ");
			}

			if(wasValidationError)
				TempData["ModelStateErrors"] = ModelState.CopyModelErrors();
		}
		private ActionResult Register_HandleBookteraException(BookteraException e, RegisterVM vm)
		{
			// Sikertelen
			if(e.Code == BookteraExceptionCode.RegisterUser)
			{
				RegistrationManagerRelief.EmptyPasswords(vm);
				//ModelState.AddModelError("", "Sikertelen regisztráció. ");

				var ei = e.InnerException as BookteraException;
				if(ei != null)
				{
					switch(ei.Code)
					{
						case BookteraExceptionCode.RegisterUser_UserIsBothAuthorAndPublisher:
							// TODO: log hack
							ModelState.AddModelError("", "Nem képviselhetsz egyszerre egy szerzőt és egy kiadót is. ");
							break;

						case BookteraExceptionCode.AddUserProfile_InsertFailed:
						case BookteraExceptionCode.AddWebpagesMembership_InsertFailed:
							// TODO: log validáció hibás, eljutottak a DB-ig a rosszul validált adatok
							ModelState.AddModelError("", "Nem sikerült rögzítenünk a regisztrációd az adatbázisunkban. Talán foglalt a felhasználóneved és/vagy email-címed. ");
							break;

						default:
							ModelState.AddModelError("", "Belső hiba történt. Próbáld újra később a regisztrációt. ");
							break;
					}
				}
				else
				{
					var eia = e.InnerException as AggregateException;
					if(eia != null)
					{
						foreach(var eiai in eia.InnerExceptions)
						{
							var innerBookteraException = eiai as BookteraException;
							if(innerBookteraException != null)
							{
								switch(innerBookteraException.Code)
								{
									case BookteraExceptionCode.RegisterUser_ManageAuthor_UnSuccesfulRollback:
										ModelState.AddModelError("", "Belső hiba történt, nem sikerült szerzőként regisztrálnod. Próbálj meg simán beregisztrálni, és utólag előléptetni a profilod szerzővé. ");
										break;

									case BookteraExceptionCode.RegisterUser_ManagePublisher_UnSuccesfulRollback:
										ModelState.AddModelError("", "Belső hiba történt, nem sikerült kiadóként regisztrálnod. Próbálj meg simán beregisztrálni, és utólag előléptetni a profilod kiadóvá. ");
										break;
								}
							}
							else
							{
								ModelState.AddModelError("", "Belső hiba történt. Próbáld újra később a regisztrációt. ");
							}
						}
					}
				}

				return View("Register", vm);
			}

			// Sikeres
			if(e.Code == BookteraExceptionCode.RegisterUser_SuccesfulWithSomeProblems)
			{
				var eia = e.InnerException as AggregateException;
				if(eia != null)
				{
					foreach(var eiai in eia.InnerExceptions)
					{
						var innerBookteraException = eiai as BookteraException;
						if(innerBookteraException != null)
						{
							switch(innerBookteraException.Code)
							{
								case BookteraExceptionCode.RegisterUser_ManageAuthor_SuccesfulRollback:
									ModelState.AddModelError("", "Belső hiba miatt nem sikerült szerzőként beregisztrálnod. A Főmenü->Profilom->Rangom menüpontban előléptetheted a profilod szerzővé. ");
									break;

								case BookteraExceptionCode.RegisterUser_ManagePublisher_SuccesfulRollback:
									ModelState.AddModelError("", "Belső hiba miatt nem sikerült kiadóként beregisztrálnod. A Főmenü->Profilom->Rangom menüpontban előléptetheted a profilod kiadóvá. ");
									break;

								case BookteraExceptionCode.AddUserAddress_InsertFailed:
									ModelState.AddModelError("", "Nem sikerült rögzíteni a megadott címed. Megadhatod újra itt: Főmenü->Profilom->Címeim. ");
									break;

								case BookteraExceptionCode.AddUserAddress_MakeItDefaultFailed:
									// A cím sikeresen felvéve, csak nem lett default. Erről a user-t nem értesítjük
									//return RedirectToAction("Addresses", "UserProfile");
									break;

								case BookteraExceptionCode.AddImageDeleteIfFailed:
									ModelState.AddModelError("", "Nem sikerült feltölteni az avatar képed. ");
									break;

								case BookteraExceptionCode.None:
									// Ez nem igazi hiba
									break;

								default:
									ModelState.AddModelError("", "Ismeretlen belső hiba történt. ");
									break;
							}
						}
						else
						{
							ModelState.AddModelError("", "Ismeretlen belső hiba történt. ");
						}
					}
				}
				else
				{
					ModelState.AddModelError("", "Ismeretlen belső hiba történt. ");
				}

				WebSecurity.Login(vm.UserName, vm.Password);
				TempData["ModelStateErrors"] = ModelState.CopyModelErrors();
				return RedirectToAction("RegisterSuccess");
			}

			// Elvileg lehetetlen, hogy ide elérjünk

			ModelState.AddModelError("", "Ismeretlen belső hiba történt. ");
			RegistrationManagerRelief.EmptyPasswords(vm);
			return View("Register", vm);
		}

		// 
		// GET: /Account/RegisterSuccess

		public ActionResult RegisterSuccess()
		{
			return View("RegisterSuccess");
		}

		// 
		// AJAX: /Account/CheckUserNameUnique/

		[HttpPost]
		[AllowAnonymous]
		public JsonStringResult CheckUserNameUnique(string userName)
		{
			bool isUnique = UserProfileManager.CheckUserNameUnique(userName);
			return new JsonStringResult(isUnique);
		}

		// 
		// AJAX: /Account/CheckEmailUnique/

		[HttpPost]
		[AllowAnonymous]
		public JsonStringResult CheckEmailUnique(string email)
		{
			bool isUnique = UserProfileManager.CheckEmailUnique(email);
			return new JsonStringResult(isUnique);
		}

		#endregion

		#region Helpers

		private ActionResult RedirectToLocal(string returnUrl)
		{
			if(Url.IsLocalUrl(returnUrl))
				return Redirect(returnUrl);
			else
				return RedirectToAction("Index", "Home");
		}

		#endregion
	}
}
