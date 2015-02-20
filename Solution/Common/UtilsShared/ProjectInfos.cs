using System;
using System.IO;
using System.Reflection;

namespace UtilsShared
{
	public static class ProjectInfos
	{
		public static DirectoryInfo GetSolutionsRootDircetory(string solutionName)
		{
			try
			{
				//var directory = new DirectoryInfo(Directory.GetCurrentDirectory());
				var directoryPath = (new Uri(Assembly.GetExecutingAssembly().CodeBase)).AbsolutePath;
				var directory = new DirectoryInfo(directoryPath).Parent;

				while(directory.Name != solutionName)
				{
					directory = directory.Parent;
				}

				return directory;
			}
			catch (Exception e)
			{
				const string msg = "Nem sikerült megtalálni a Solution root könyvtárát. ";
				throw new Exception(msg, e);
			}
		}
	}
}
