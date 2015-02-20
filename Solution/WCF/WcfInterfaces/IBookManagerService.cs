using System.ServiceModel;
using CommonModels.Models.EntityFramework;
using CommonModels.Models.ProductModels;
using System.ServiceModel.Web;

namespace WcfInterfaces
{
	[ServiceContract]
	public interface IBookManager
	{
		[OperationContract]
		[WebInvoke(BodyStyle = WebMessageBodyStyle.WrappedRequest)]
		Product UploadProduct(CreatePVM model);

		[OperationContract]
		[WebInvoke(BodyStyle = WebMessageBodyStyle.WrappedRequest)]
		void UploadProductNr(CreatePVM model);

		[OperationContract]
		[WebInvoke(BodyStyle = WebMessageBodyStyle.WrappedRequest)]
		CreatePVM.ProductGroupVM.WithValidation CreateProductGroupWithValidation(CreatePVM.ProductGroupVM nonValidatedProductGroup);
	}	
}
