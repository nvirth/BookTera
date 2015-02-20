using BLL.EntityManagers;
using CommonModels.Models.EntityFramework;
using CommonModels.WcfHelperModels;
using UtilsLocal.WCF;
using WcfInterfaces.EntityManagers;
using WebMatrix.WebData;

namespace WcfHost.EntityManagers
{
	public class ImageManagerService : IImageManager, IImageManagerRest
	{
		[AuthorizeWcf]
		public string GetUsersAvatar()
		{
			return ImageManager.GetUsersAvatar(WebSecurity.CurrentUserId);
		}

		public StringMcWrapper TakeImageToItsFolder(ImageUploadStream imageUploadStream)
		{
			var friendlyUrlForProduct = imageUploadStream.FriendlyUrlForProduct;
			object userProfile_product_productGroup = imageUploadStream.UserProfile ?? imageUploadStream.Product ?? (object)imageUploadStream.ProductGroup;
			var stream = imageUploadStream.Stream;
			var fileName = imageUploadStream.FileName;

			return new StringMcWrapper
			{
				String = ImageManager.TakeImageToItsFolder(stream, fileName, userProfile_product_productGroup, friendlyUrlForProduct)
			};
		}
	}
}