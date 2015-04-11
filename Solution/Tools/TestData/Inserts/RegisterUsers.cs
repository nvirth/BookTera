using System;
using BLL;
using BLL.EntityManagers;
using CommonModels.Models;
using CommonModels.Models.AccountModels;
using CommonPortable.Exceptions;
using UtilsLocal;
using UtilsShared;
using DAL.EntityFramework;
using ebookTestData.Get;
using UtilsSharedPortable;
using GeneralFunctions = UtilsSharedPortable.GeneralFunctions;
using UserProfile = CommonModels.Models.EntityFramework.UserProfile;

namespace ebookTestData.Inserts
{
	/// <summary>
	/// Beszúr a következõkbe:
	/// - UserProfile
	/// - Image (default)
	/// - UserAddresses (default)
	/// - Author (with userId)
	/// - Publisher (with userId)
	/// 
	/// Megj.: userGroupId: 1-4-5 lesz csak
	/// </summary>
	class RegisterUsers : Insert
	{
		private RegisterVM _registerVm;

		#region ResourceProperties

		private string[] userNames;
		private string[] emailDomains;
		private string[] phoneDomains;
		private string[] imageFilePaths;
		private string[] fullNames;
		private string[] authors;
		private string[] publishers;
		private string[,] citiesAndZips;
		private string[] streets;

		#endregion

		protected sealed override void Start()
		{
			SetResourceProperties();

			for(int i = 0; i < userNames.Length; i++)
			{
				BuildRegisterModel(i);
				RegisterTheUser();
			}
			CorrectTestData();
		}

		#region Privates

		#region Main Functions

		private void BuildRegisterModel(int i)
		{
			string imageUrl = null;
			if(Random.Next(100) < 85)
			{
				// Kamu példány a képnévhez
				var userProfile = new UserProfile(false)
				{
					FriendlyUrl = userNames[i].ToFriendlyUrl()
				};
				var inImageUrl = imageFilePaths[i];
				imageUrl = ImageManager.CopyImageToItsFolder(inImageUrl, userProfile);
			}

			string phoneNumber = "06" + phoneDomains[i % phoneDomains.Length];
			phoneNumber += Random.Next(1111111, 9999999).ToString(Constants.CultureInfoHu);
			phoneNumber = Random.Next(100) < 85 ? phoneNumber : null;

			string eMail = userNames[i] + "@" + emailDomains[i % emailDomains.Length];
			const string testPassword = "asdqwe123";
			var userAddress = createTestUserAddress(citiesAndZips, streets);

			string authorName = null;
			string publisherName = null;
			if(Random.Next(100) < 50)
				authorName = Random.Next(100) < 20 ? authors[i % authors.Length] : null;
			else
				publisherName = Random.Next(100) < 20 ? publishers[i % authors.Length] : null;

			_registerVm = new RegisterVM()
			{
				UserName = userNames[i],
				EMail = eMail,
				PhoneNumber = phoneNumber,
				FullName = fullNames[i],
				Password = testPassword,
				ConfirmPassword = testPassword,
				ImageUrl = imageUrl,
				AuthorName = authorName,
				PublisherName = publisherName,
				UserAddress = userAddress,
			};
		}

		private void RegisterTheUser()
		{
			try
			{
				RegistrationManager.RegisterUser(_registerVm, isTest: true);
			}
			catch(BookteraException e)
			{
				e.WriteWithInnerMessagesColorful(goodExceptionCodes, neutralExceptionCodes);
			}
		}

		/// <summary>
		/// Teszt adatokkal tölti ki:
		/// - UserProfile.RegistrationDate
		/// - UserProfile.LastLoginDate
		/// - UserProfile.PreviousLoginDate
		/// </summary>
		private void CorrectTestData()
		{
			using(var ctx = new DBEntities())
			{
				foreach(var userProfile in ctx.UserProfile)
				{
					int randomYears = Random.Next(4);

					DateTime registrationDate = DateTime.Now.AddYears(-randomYears).AddMonths(-Random.Next(3, 12)).AddDays(-Random.Next(30));

					DateTime lastLoginDate = registrationDate.AddYears(Random.Next(randomYears)).AddMonths(Random.Next(12)).AddDays(Random.Next(30));
					lastLoginDate = lastLoginDate > DateTime.Now ? DateTime.Now : lastLoginDate;
					lastLoginDate = lastLoginDate.AddHours(-Random.Next(24)).AddMinutes(-Random.Next(60)).AddSeconds(-Random.Next(60));
					lastLoginDate = lastLoginDate < registrationDate ? registrationDate : lastLoginDate;

					DateTime previousLoginDate = GeneralFunctions.GetRandomDateTimeBetween(registrationDate, lastLoginDate);

					userProfile.RegistrationDate = registrationDate;
					userProfile.LastLoginDate = lastLoginDate;
					userProfile.PreviousLoginDate = previousLoginDate;
				}
				ctx.SaveChanges();
			}
		}

		#endregion

		private void SetResourceProperties()
		{
			userNames = GetResources.GetUserNames();
			emailDomains = GetResources.GetEmailDomains();
			phoneDomains = GetResources.GetPhoneDomains();
			imageFilePaths = GetResources.GetUserImages();
			fullNames = GetResources.GetFullNames(userNames.Length);
			authors = GetResources.GetExistingAuthorsWithDuplicates();
			publishers = GetResources.GetExistingPublishersWithDuplicates();
			citiesAndZips = GetResources.GetHungarianCitiesWithZip(); // [*,0]:Zip, [*,1]:City
			streets = GetResources.GetStreets();
		}

		private UserAddressVM createTestUserAddress(string[,] citiesAndZips, string[] streets)
		{
			UserAddressVM userAddress = null;

			// A kötelező-a-cím-a-vásárláshoz dolog kivezetése miatt inkább minden teszt
			// felhasználónak lesz alapértelmezett címe
			//
			//if(Random.Next(100) < 30)
			//{
				int idx = Random.Next(citiesAndZips.GetLength(0));
				userAddress = new UserAddressVM
				{
					ZipCode = citiesAndZips[idx, 0],
					City = citiesAndZips[idx, 1],
					StreetAndHouseNumber = streets[Random.Next(streets.Length)] + " " + Random.Next(1, 200),
					Country = "Magyarország",
				};
			//}
			return userAddress;
		}

		#endregion
	}
}
