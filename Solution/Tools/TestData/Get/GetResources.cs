using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using CommonModels.Models.EntityFramework;
using ebookTestData.HelperClasses;
using UtilsLocal;
using UtilsShared;
using GeneralFunctions = UtilsShared.GeneralFunctions;
using GeneralFunctionsPortable = UtilsSharedPortable.GeneralFunctions;

namespace ebookTestData.Get
{
	public static class GetResources
	{
		#region Properties, Fields

		private static readonly Random random = new Random(DateTime.Now.Millisecond);

		#endregion

		#region Get Partial Resources

		public static string[] GetUserNames()
		{
			return GeneralFunctions.ReadInFile(Paths.Test_txtPath + "felhasználónevek.txt");
		}

		public static string[] GetEmailDomains()
		{
			return GeneralFunctions.ReadInFile(Paths.Test_txtPath + "emailDomains.txt");
		}

		public static string[] GetPhoneDomains()
		{
			return GeneralFunctions.ReadInFile(Paths.Test_txtPath + "phoneDomains.txt");
		}

		public static string[] GetUserImages()
		{
			//string[] fullPaths = Directory.GetFiles(userImagesPath);
			//string[] fileNames = new string[fullPaths.Length];
			//for(int i = 0; i < fullPaths.Length; i++)
			//{
			//	fileNames[i] = new FileInfo(fullPaths[i]).Name;
			//}
			//return fileNames;
			return Directory.GetFiles(Paths.Test_userImagesPath);
		}

		public static string[] GetFullNames(int howMany)
		{
			string[] eredmenyLista = new string[howMany];

			List<string> csaladNevek = new List<string>(GeneralFunctions.ReadInFile(Paths.Test_txtPath + "családnevek.txt"));
			List<string> keresztNevek = new List<string>(GeneralFunctions.ReadInFile(Paths.Test_txtPath + "keresztnevek.txt"));
			string[] viccesFullNevek = GeneralFunctions.ReadInFile(Paths.Test_txtPath + "viccesNevek.txt");

			int i;
			int max = Math.Min(viccesFullNevek.Length, howMany);
			for(i = 0; i < max; i++)
			{
				eredmenyLista[i] = viccesFullNevek[i];
			}

			if(i < howMany)
			{
				for(; i < howMany; i++)
				{
					int cn = random.Next(csaladNevek.Count);
					int kn = random.Next(keresztNevek.Count);
					eredmenyLista[i] = csaladNevek.ElementAt(cn) + " " + keresztNevek.ElementAt(kn);
				}
			}
			return eredmenyLista;
		}

		public static string[] GetStreets()
		{
			return GeneralFunctions.ReadInFile(Paths.Test_txtPath + "utcák.txt");
		}

		public static string[] GetComments()
		{
			return GeneralFunctions.ReadInFile(Paths.Test_txtPath + "kommentSzövegek.txt");
		}

		public static string[] GetExistingAuthorsWithDuplicates()
		{
			return GetProductResources().Select(pr => pr.Authors.Split(',')[0].Trim()).ToArray();
		}

		public static string[] GetExistingPublishersWithDuplicates()
		{
			return GetProductResources().Select(pr => pr.PublisherName).ToArray();
		}

		public static string[] GetLanguages()
		{
			return GeneralFunctions.ReadInFile(Paths.Test_txtPath + "nyelvek.txt");
		}

		public static string[] GetProductDescriptions()
		{
			return GeneralFunctions.ReadInFile(Paths.Test_txtPath + "productDescriptions.txt");
		}

		public static string[,] GetHungarianCitiesWithZip()
		{
			string[] citiesAndZips = GeneralFunctions.ReadInFile(Paths.Test_txtPath + "települések.txt");
			var CitiesAndZips = new String[citiesAndZips.Length, 2];
			for(int i = 0; i < citiesAndZips.Length; i++)
			{
				string[] sT = citiesAndZips[i].Split('\t');
				CitiesAndZips[i, 0] = sT[0];
				CitiesAndZips[i, 1] = sT[1];
			}
			return CitiesAndZips;
		}

		#endregion

		#region Get FullTable Resources

		#region GetProductResources

		public static IEnumerable<ProductResource> GetProductResources()
		{
			XElement xmlDoc = XElement.Load(Path.Combine(Paths.Test_txtPath, "Products.xml"));
			return
				(from pr in xmlDoc.Elements("ProductResource")
				 select new ProductResource
				 {
					 Title = ((string)pr.Element("Title")).Trim(),
					 SubTitle = ((string)pr.Element("SubTitle")).Trim(),
					 Price = (int)pr.Element("Price"),
					 PublishYear = (int)pr.Element("PublishYear"),
					 PageNumber = (int)pr.Element("PageNumber"),
					 PublisherName = ((string)pr.Element("PublisherName")).Trim(),
					 Authors = ((string)pr.Element("Authors")).Trim(),
					 Description = ((string)pr.Element("Description")).Trim(),
					 CategoryId = (int)pr.Element("CategoryId"),
					 ImageUrl = ((string)pr.Element("ImageUrl")).Trim()
				 });
		}

		#endregion

		#region GetCategoryResources

		public static IEnumerable<Category> GetCategoryResources()
		{
			XElement xmlDoc = XElement.Load(Path.Combine(Paths.Test_txtPath, "Categories.xml"));

			return xmlDoc.Elements("CategoryResource")
				.Select(category =>
				        {
					        string fullPath = ((string) category.Element("FullPath")).Trim();
					        string friendlyUrl = fullPath.ToFriendlyUrl();
					        
							return new Category(true)
					        {
						        DisplayName = ((string) category.Element("DisplayName")).Trim(),
						        Sort = ((string) category.Element("Sort")).Trim(),
						        ParentCategoryID = string.IsNullOrWhiteSpace(category.Element("ParentCategoryID").Value) ? null : (int?) category.Element("ParentCategoryID"),
						        FriendlyUrl = friendlyUrl,
								FullPath = fullPath,
								IsParent = (bool) category.Element("IsParent"),
					        };
				        }
				);
		}

		#endregion

		#region GetHighlightTypeResources

		public static IEnumerable<HighlightType> GetHighlightTypeResources()
		{
			XElement xmlDoc = XElement.Load(Path.Combine(Paths.Test_txtPath, "HighlightedTypes.xml"));
			return
				(from highlightType in xmlDoc.Elements("HighlightTypeResource")
				 select new HighlightType(true)
				 {
					 Description = ((string)highlightType.Element("Description")).Trim(),
					 Price = (int)highlightType.Element("Price"),
				 });
		}

		#endregion

		#region GetUserGroupResources

		public static IEnumerable<UserGroup> GetUserGroupResources()
		{
			XElement xmlDoc = XElement.Load(Path.Combine(Paths.Test_txtPath, "UserGroups.xml"));
			return
				(from userGroup in xmlDoc.Elements("UserGroupResource")
				 select new UserGroup(true)
				 {
					 GroupName = ((string)userGroup.Element("GroupName")).Trim(),
					 BuyFeePercent = (byte)(int)userGroup.Element("BuyFeePercent"),
					 SellFeePercent = (byte)(int)userGroup.Element("SellFeePercent"),
					 MonthsToKeepBooks = (byte)(int)userGroup.Element("MonthsToKeepBooks"),
					 Price = (int)userGroup.Element("Price")
				 });
		}

		#endregion

		#endregion
	}
}
