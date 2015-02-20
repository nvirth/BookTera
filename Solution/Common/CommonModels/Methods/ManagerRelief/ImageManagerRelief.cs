using System;
using System.IO;
using UtilsLocal;

namespace CommonModels.Methods.ManagerRelief
{
	public static class ImageManagerRelief
	{
		public static bool TestProductGroupImageExist(string imageUrl)
		{
			if(String.IsNullOrWhiteSpace(imageUrl))
				return false;

			return File.Exists(Path.Combine(Paths.Web_productGroupImagesPath, imageUrl));
		}
		public static bool TestProductImageExist(string imageUrl)
		{
			if(String.IsNullOrWhiteSpace(imageUrl))
				return false;

			return File.Exists(Path.Combine(Paths.Web_productImagesPath, imageUrl));
		}
		public static bool TestUserImageExist(string imageUrl)
		{
			if(String.IsNullOrWhiteSpace(imageUrl))
				return false;

			return File.Exists(Path.Combine(Paths.Web_userImagesPath, imageUrl));
		}
	}
}
