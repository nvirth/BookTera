using System;
using BLL.EntityManagers;
using ebookTestData.HelperClasses;
using ebookTestData.Inserts;
using UtilsShared;
using UtilsSharedPortable;

namespace ebookTestData
{
	public class TestData
	{
		public static void Main(string[] args)
		{
			//var regex = new Regex(@"\w");
			//Console.WriteLine(regex.IsMatch("á"));


			//Console.ReadKey();
			//Environment.Exit(0);

			UtilsShared.HelpersShared.SetDefaultCultureToEnglish();
			MessagePresenterManager.WireToConsole();

			Action insertTestData = InsertTestData;
			insertTestData.ExecuteWithTimeMeasuring("Full");
			
			MessagePresenter.WriteLine("");
			MessagePresenter.WriteLine("--End--");
			Console.ReadKey();
		}

		public static void InsertTestData()
		{
			// Init
			ImageManager.ClearImageDirectories();

			// Nem függnek senkitől, de tőlük függnek
			new InsertHighlightedType();
			new InsertUserGroup();
			new InsertCategory();

			// Függ az előzőleg beszúrtaktól
			new RegisterUsers(); // USER

			// Függ tőle: USER
			//new InsertUserAddress(); // ADDRESS
			new UploadProduct(); // PRODUCT

			// Függ tőle: PRODUCT
			//new InsertImage();
			//new InsertUserViewProduct();
			//new InsertComment();
			//new InsertRating();
			//new InsertHighlightedProduct();

			// Függ tőle: ADDRESS
			//new InsertUserOrder(); // ORDER
			//new SetDefaultUserAddress();

			// Függ tőle: ORDER
			//new InsertProductInOrder();

			new DoSomeBuys();
		}
	}
}
