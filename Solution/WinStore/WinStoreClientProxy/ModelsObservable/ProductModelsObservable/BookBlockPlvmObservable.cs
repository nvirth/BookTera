using System.Collections.ObjectModel;
using CommonPortable.Enums;
using CommonPortable.Models;
using CommonPortable.Models.ProductModels;

namespace WinStoreClientProxy.ModelsObservable.ProductModelsObservable
{
	public class BookBlockPlvmObservable
	{
		public BookBlockType BookBlockType { get; set; }

		public ObservableCollection<InBookBlockPVM> Products { get; set; }
		public Paging Paging { get; set; }
	}
}
