using System.IO;
using UtilsShared;

namespace UtilsLocal
{
	public static class Paths
	{
		//public static string ebookTestDataPath = ConfigurationManager.AppSettings["ebookTestDataPath"];
		//public static string ebookWebPath = ConfigurationManager.AppSettings["ebookWebPath"];


		public const string SolutoinDirectoryName = "Solution";
		public static readonly string SolutoinsRootPath = ProjectInfos.GetSolutionsRootDircetory(SolutoinDirectoryName).FullName + "\\";

		// -- WebPath
		public static readonly string WebPath = SolutoinsRootPath + @"WEB\";

		public static readonly string Web_ImagesPath = WebPath + @"Content\Images\";
		public static readonly string Web_ScriptsPath = WebPath + @"Scripts\";
		public static readonly string Web_ThemesPath = WebPath + @"Content\themes\";

		public static readonly string Web_userImagesPath = Web_ImagesPath + @"UserImages\";
		public static readonly string Web_productImagesPath = Web_ImagesPath + @"ProductImages\";
		public static readonly string Web_productGroupImagesPath = Web_ImagesPath + @"ProductImages\";

		// -- TestDataPath
		public static readonly string TestDataPath = SolutoinsRootPath + @"Tools\TestData\";

		public static readonly string Test_resources = TestDataPath + @"Resources\";

		public static readonly string Test_txtPath = Test_resources + @"txt\";
		public static readonly string Test_productImagesPath = Test_resources + @"Images\ProductImages\";
		public static readonly string Test_productGroupImagesPath = Test_resources + @"Images\ProductImages\";
		public static readonly string Test_userImagesPath = Test_resources + @"Images\UserImages\";

		// -- InitSolution
		public static readonly string InitSolutionPath = SolutoinsRootPath + @"Tools\InitSolution\";
		public static readonly string InitSolution_log = InitSolutionPath + @"init.log";

		// -- PlayPath
		public static readonly string PlayPath = Path.GetFullPath(Path.Combine(SolutoinsRootPath, @"..\Java\WebPlay\"));
		public static readonly string Play_publicPath = PlayPath + @"public\";

		public static readonly string Play_imgJuncPath = Play_publicPath + @"images\";
		public static readonly string Play_jsJuncPath = Play_publicPath + @"javascripts\";
		public static readonly string Play_cssJuncPath = Play_publicPath + @"stylesheets\shared\";


		#region GetProjectsRootDirectory: ThisProjects, OtherProjects

		//public static string GetCurrentProjectsRootDirectory()
		//{
		//	return GetThisProjectsRootDirectoryInfo().FullName + "\\";
		//}

		//private static DirectoryInfo GetThisProjectsRootDirectoryInfo()
		//{
		//	string projectName = Assembly.GetExecutingAssembly().GetName().Name;
		//	return ProjectInfos.GetSolutionsRootDircetory(projectName);
		//}

		//public static string GetOtherProjectsRootDirectory(string otherProjectsName, DirectoryInfo currentProjectsDirectory)
		//{
		//	return currentProjectsDirectory.Parent.FullName + "\\" + otherProjectsName + "\\";
		//}

		//public static string GetOtherProjectsRootDirectory(string otherProjectsName)
		//{
		//	var s = GetThisProjectsRootDirectoryInfo().Parent.FullName + "\\" + otherProjectsName + "\\";
		//	return GetThisProjectsRootDirectoryInfo().Parent.FullName + "\\" + otherProjectsName + "\\";
		//}

		#endregion

	}
}
