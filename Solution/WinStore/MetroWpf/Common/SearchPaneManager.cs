using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Search;
using Windows.Storage.Streams;
using Windows.UI.Xaml;
using WinStoreClientProxy;

namespace MetroWpf.Common
{
	public class SearchPaneManager
	{
		private static int BindCout = 0;

		private readonly SearchPane _searchPane = SearchPane.GetForCurrentView();
		
		private Action<string> _onQuerySubmitted;
		private Action<string> _onResultSuggestionChosen;

		public SearchPaneManager(Action<string> onQuerySubmitted, Action<string> onResultSuggestionChosen)
		{
			if (BindCout == 0)
			{
				InitSearchPane();
				BindSearchPane(onQuerySubmitted, onResultSuggestionChosen);
			}
		}

		private void InitSearchPane()
		{
			_searchPane.PlaceholderText = "Keresés a BookTerán...";
			_searchPane.ShowOnKeyboardInput = false;

			var settings = new LocalContentSuggestionSettings()
			{
				Enabled = false,
			};
			_searchPane.SetLocalContentSuggestionSettings(settings);
		}

		public void BindSearchPane(Action<string> onQuerySubmitted, Action<string> onResultSuggestionChosen)
		{
			_onQuerySubmitted = onQuerySubmitted;
			_onResultSuggestionChosen = onResultSuggestionChosen;

			_searchPane.QuerySubmitted += SearchProductGroup;
			_searchPane.ResultSuggestionChosen += NavigateToProductGroup;
			_searchPane.SuggestionsRequested += SearchProductGroupAc;

			BindCout++;
		}

		public void UnBindSearchPane()
		{
			_searchPane.QuerySubmitted -= SearchProductGroup;
			_searchPane.ResultSuggestionChosen -= NavigateToProductGroup;
			_searchPane.SuggestionsRequested -= SearchProductGroupAc;

			BindCout--;
		}

		private void SearchProductGroup(SearchPane sender, SearchPaneQuerySubmittedEventArgs args)
		{
			_onQuerySubmitted(sender.QueryText);
		}

		private void NavigateToProductGroup(SearchPane sender, SearchPaneResultSuggestionChosenEventArgs args)
		{
			var productGroupFriendlyUrl = args.Tag;
			_onResultSuggestionChosen(productGroupFriendlyUrl);

		}

		private async void SearchProductGroupAc(SearchPane sender, SearchPaneSuggestionsRequestedEventArgs args)
		{
			if (sender.QueryText.Length >= 2)
			{
				var deferral = args.Request.GetDeferral();

				var productGroupAcs = await ProductGroupManager.SearchAutoCompletePgAsync(sender.QueryText, 10);
				var suggestions = args.Request.SearchSuggestionCollection;

				foreach (var pg in productGroupAcs)
				{
					var productImagesDirFormat = (string) Application.Current.Resources["ProductImagesDirFormat"];
					var imageUrl = string.Format(productImagesDirFormat, pg.ImageUrl);				//PL: http://localhost:50308/Content/Images/ProductImages/P-Kemiai-elemek-687268.jpg
					var image = RandomAccessStreamReference.CreateFromUri(new Uri(imageUrl));

					suggestions.AppendResultSuggestion(pg.Title, pg.SubTitle, pg.FriendlyUrl, image, pg.Title);
				}

				if (suggestions.Size == 0)
				{
					var uriMock = RandomAccessStreamReference.CreateFromUri(new Uri("http://valid-uri"));
					suggestions.AppendResultSuggestion("Nincs találat", "", " ", uriMock, "");
				}

				deferral.Complete();
			}
		}
	}
}
