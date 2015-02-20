using BLL;
using BLL.EntityManagers;
using CommonModels.Models.EntityFramework;
using CommonModels.Models.ProductModels;
using UtilsLocal.WCF;
using WcfInterfaces;
using WebMatrix.WebData;

namespace WcfHost
{
	[AuthorizeWcf]
	public class BookManagerService : IBookManager
	{
		CreatePVM.ProductGroupVM.WithValidation IBookManager.CreateProductGroupWithValidation(CreatePVM.ProductGroupVM nonValidatedProductGroup)
		{
			return new CreatePVM.ProductGroupVM.WithValidation(nonValidatedProductGroup);
		}

		Product IBookManager.UploadProduct(CreatePVM model)
		{
			var product = BookManager.UploadProduct(model, WebSecurity.CurrentUserId);
			return ProductManager.CopyFromProxy(product);
		}

		void IBookManager.UploadProductNr(CreatePVM model)
		{
			BookManager.UploadProduct(model, WebSecurity.CurrentUserId);
		}
	}
}
