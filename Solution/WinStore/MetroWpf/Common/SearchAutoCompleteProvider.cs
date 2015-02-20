//using System;
//using System.Collections;
//using System.Collections.Generic;
//using System.Collections.ObjectModel;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using WinStoreClientProxy;
//using WinStoreClientProxy.HelperModels;
//using WpfControls;

//namespace MetroWpf.Common
//{
//	public class SearchAutoCompleteProvider : ISuggestionProvider
//	{
//		private const int HowMany = 10;

//		public IEnumerable GetSuggestions(string filter)
//		{
//			return Search(filter);
//		}

//		private ObservableCollection<LabelValuePair> Search(string searchText)
//		{
//			ObservableCollection<LabelValuePair> result = null;

//			Task.Run(
//				async () =>
//					  {
//						  result = await ProductGroupManager.SearchAutoCompleteAsync(searchText, HowMany);
//					  }).Wait();

//			var test = result;

//			return result;
//		}
//	}
//}
