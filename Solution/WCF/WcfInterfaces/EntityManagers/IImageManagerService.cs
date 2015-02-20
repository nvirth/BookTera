using System.ServiceModel;
using System.ServiceModel.Web;
using CommonModels.Models.EntityFramework;
using CommonModels.WcfHelperModels;

namespace WcfInterfaces.EntityManagers
{
	[ServiceContract(Namespace = "ImageManager.Basic")]
	public interface IImageManager
	{
		[OperationContract]
		string GetUsersAvatar();

		[OperationContract]
		StringMcWrapper TakeImageToItsFolder(ImageUploadStream imageUploadStream);
	}

	[ServiceContract(Namespace = "ImageManager.Rest")]
	public interface IImageManagerRest
	{
		[OperationContract]
		[WebGet]
		string GetUsersAvatar();
	}
}