using System;
using System.Diagnostics;
using CommonModels.Models.EntityFramework;

namespace ebookTestData
{
	public static class Util
	{
		#region CanUserViewProduct

		public static bool CanUserViewProduct(UserProfile user, Product product)
		{
			return user.LastLoginDate >= product.UploadedDate;
		}

		#endregion
	}
}
