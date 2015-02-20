using System.Web.Optimization;

namespace WEB
{
	public class BundleConfig
	{
		// For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
		public static void RegisterBundles(BundleCollection bundles)
		{
			// -- MyScripts

			bundles.Add(new ScriptBundle("~/bundles/AutoCompletes").Include(
						"~/Scripts/Site/AutoCompletes.js"));

			bundles.Add(new ScriptBundle("~/bundles/LayoutBoxes").Include(
						"~/Scripts/Site/LayoutBoxes.js"));

			bundles.Add(new ScriptBundle("~/bundles/DetailedSearch").Include(
						"~/Scripts/Site/DetailedSearch.js"));

			bundles.Add(new ScriptBundle("~/bundles/Register").Include(
						"~/Scripts/Site/Register.js"));

			bundles.Add(new ScriptBundle("~/bundles/Paging").Include(
						"~/Scripts/Site/Paging.js"));

			bundles.Add(new ScriptBundle("~/bundles/AddProductToCartOrExchange").Include(
						"~/Scripts/Site/AddProductToCartOrExchange.js"));

			bundles.Add(new ScriptBundle("~/bundles/Addresses").Include(
						"~/Scripts/Site/Addresses.js"));

			bundles.Add(new ScriptBundle("~/bundles/UserGroup").Include(
						"~/Scripts/Site/UserGroup.js"));

			bundles.Add(new ScriptBundle("~/bundles/OrderOperations").Include(
						"~/Scripts/Site/CartAndExchangeOperations.js",
						"~/Scripts/Site/TransactionOperations.js"));

			bundles.Add(new ScriptBundle("~/bundles/UploadProduct").Include(
						"~/Scripts/Site/UploadProduct.js"));

			// -- JQuery

			bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
						"~/Scripts/Extensions/CookieFunctions.js",
						"~/Scripts/Extensions/QueryStringFunctions.js",
						"~/Scripts/Extensions/StringFunctions.js",
						"~/Scripts/Extensions/Constants.js",
						"~/Scripts/NuGet/jquery-{version}.js",
						"~/Scripts/Extensions/JQueryHelpers.Animations.js",
						"~/Scripts/Extensions/JQueryHelpers.DropDowns.js"));

			bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
						"~/Scripts/NuGet/jquery-ui-{version}.js"));

			bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
						"~/Scripts/NuGet/jquery.unobtrusive*",
						"~/Scripts/NuGet/jquery.validate*"));

			// Use the development version of Modernizr to develop with and learn from. Then, when you're
			// ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
			bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
						"~/Scripts/NuGet/modernizr-*"));

			bundles.Add(new StyleBundle("~/Content/css").Include("~/Content/site.css"));

			//bundles.Add(new StyleBundle("~/Content/jqueryui").Include(
			//			"~/Content/themes/base/jquery.ui.core.css",
			//			"~/Content/themes/base/jquery.ui.resizable.css",
			//			"~/Content/themes/base/jquery.ui.selectable.css",
			//			"~/Content/themes/base/jquery.ui.accordion.css",
			//			"~/Content/themes/base/jquery.ui.autocomplete.css",
			//			"~/Content/themes/base/jquery.ui.button.css",
			//			"~/Content/themes/base/jquery.ui.dialog.css",
			//			"~/Content/themes/base/jquery.ui.slider.css",
			//			"~/Content/themes/base/jquery.ui.tabs.css",
			//			"~/Content/themes/base/jquery.ui.datepicker.css",
			//			"~/Content/themes/base/jquery.ui.progressbar.css",
			//			"~/Content/themes/base/jquery.ui.theme.css"));

			bundles.Add(new StyleBundle("~/Content/jqueryui").Include(
						"~/Content/themes/base/jquery-ui.css"));

			//bundles.Add(new StyleBundle("~/Content/themes/css").Include(
			//"~/Content/themes/BookBlock.css",
			//"~/Content/themes/DetailedSearch.css",
			//"~/Content/themes/Footer.css",
			//"~/Content/themes/Header.css",
			//"~/Content/themes/LeftMenu.css",
			//"~/Content/themes/MainMenu.css",
			//"~/Content/themes/Site.css"));

			bundles.Add(new StyleBundle("~/Content/themes/main").IncludeDirectory(
				"~/Content/themes/main", "*.css", searchSubdirectories: false));

			bundles.Add(new StyleBundle("~/Content/themes/BookBlock").Include(
			"~/Content/themes/BookBlock.css",
			"~/Content/themes/Paging.css"));

			bundles.Add(new StyleBundle("~/Content/themes/BookRow").Include(
			"~/Content/themes/BookRow.css",
			"~/Content/themes/Paging.css"));

			bundles.Add(new StyleBundle("~/Content/themes/DetailedSearch").Include(
			"~/Content/themes/DetailedSearch.css"));

			bundles.Add(new StyleBundle("~/Content/themes/Register").Include(
			"~/Content/themes/Register.css"));
		}
	}
}